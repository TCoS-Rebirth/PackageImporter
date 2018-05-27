using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Engine;
using Framework.Common;
using TCosReborn;
using UnityEditor;
using UnityEngine;

namespace Framework.PackageExtractor
{
    class SBFileLoader: MonoBehaviour
    {

        [SerializeField] string dataFilePath;
        const string MapExtension = "sbw";
        const string PackageExtension = "sbg";
        const string StaticFileExtension = "s";

        [ContextMenu("Cleanup")]
        void Cleanup()
        {
            Resources.UnloadUnusedAssets();
            GC.Collect();
        }

        [ContextMenu("Load Gameplay packages")]
        void LoadGameplayPackages()
        {
            if (string.IsNullOrEmpty(dataFilePath)) dataFilePath = EditorUtility.OpenFolderPanel("", "", "");
            if (!IsDataFolder(dataFilePath))
            {
                Debug.LogError("Wrong path (should be [GameDirectory]/data )");
                return;
            }
            Resources.UnloadUnusedAssets();
            GC.Collect();
            var start = Time.realtimeSinceStartup;
            LoadAllPackages(GetGameplayPackagePaths());
            Debug.Log("Loading took: " + (Time.realtimeSinceStartup - start));
        }

        [ContextMenu("Load Map packages")]
        void LoadMapPackages()
        {
            if (string.IsNullOrEmpty(dataFilePath)) dataFilePath = EditorUtility.OpenFolderPanel("", "", "");
            if (!IsDataFolder(dataFilePath))
            {
                Debug.LogError("Wrong path (should be [GameDirectory]/data )");
                return;
            }
            Resources.UnloadUnusedAssets();
            GC.Collect();
            var start = Time.realtimeSinceStartup;
            LoadAllPackages(GetMapPackagePaths());
            Debug.Log("Loading took: " + (Time.realtimeSinceStartup - start));
        }

        bool IsDataFolder(string path)
        {
            var dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                Debug.LogError("directory doesn't exist: " + path);
                return false;
            }
            return dirInfo.Name.Equals("data", StringComparison.OrdinalIgnoreCase);
        }

        List<string> GetGameplayPackagePaths()
        {
            var path = Path.Combine(dataFilePath, "gameplay");
            return new List<string>(Directory.GetFiles(path, string.Format("*.{0}", PackageExtension), SearchOption.AllDirectories));
        }

        List<string> GetMapPackagePaths()
        {
            var path = Path.Combine(dataFilePath, "environment");
            return new List<string>(Directory.GetFiles(path, string.Format("*.{0}", MapExtension), SearchOption.AllDirectories));
        }

        string GetProgressDataFilePath()
        {
            return Path.Combine(Path.Combine(dataFilePath, "static"), "level_progression.s");
        }

        string GetResourceListingFilePath()
        {
            return Path.Combine(Path.Combine(dataFilePath, "static"), "resources.s");
        }

        static void LoadAllPackages(List<string> paths)
        {
            PackageObjectDescription.ResetIDs();
            var packages = new SBResourcePackage[paths.Count];
            var descriptions = new List<PackageObjectDescription>[paths.Count];
            var imports = new Queue<ImportLink>(70000);
            for (var i = 0; i < packages.Length; i++)
            {
                packages[i] = new GameObject(Path.GetFileNameWithoutExtension(paths[i])).AddComponent<SBResourcePackage>();
                descriptions[i] = new List<PackageObjectDescription>(128);
            }
            try
            {
                for (var i = 0; i < packages.Length; i++)
                {
                    if (EditorUtility.DisplayCancelableProgressBar("Loading Packages", string.Format("{0}/{1} - {2}", i, packages.Length, packages[i].name),
                        Mathf.Clamp01((float) i / packages.Length) * 0.5f))
                    {
                        if (EditorUtility.DisplayDialog("Cancel?", "temporary objects will not be cleaned up", "Yes", "No")) throw new Exception("Loading aborted");
                    }
                    new PackageDeserializer().Load(paths[i], imports, ref packages[i], descriptions[i]);
                }
                PackageImportResolver.Resolve(imports, descriptions);
                for (int i = 0; i < packages.Length; i++)
                {
                    EditorUtility.SetDirty(packages[i]);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }
        }

        public bool LoadLevelProgressData()
        {
            if (!IsDataFolder(dataFilePath)) return false;
            var path = GetProgressDataFilePath();
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
            {
                Debug.LogError("Path to levelprogression file is invalid");
                return false;
            }
            Debug.Log("Loading Levelprogression data");
            using (var reader = new BinaryReader(File.OpenRead(path)))
            {
                reader.ReadInt32(); //header
                var count = reader.ReadInt32();
                for (var i = 0; i < count; i++)
                {
                    var pd = new ProgressData
                    {
                        level = reader.ReadByte(),
                        skillTier = reader.ReadByte(),
                        combatTierRows = reader.ReadByte(),
                        combatTierColumns = reader.ReadByte(),
                        totalSkills = reader.ReadByte(),
                        skillUpgrades = reader.ReadByte(),
                        statPoints = reader.ReadByte(),
                        bodySlots = reader.ReadByte(),
                        decks = reader.ReadByte(),
                        special = reader.ReadByte(),
                        requiredFamePoints = reader.ReadInt32(),
                        killFame = reader.ReadInt32(),
                        questFame = reader.ReadInt32()
                    };
                    LevelProgression.ProgressData.Add(pd);
                }
            }
            return true;
        }

        public bool LoadResourceIDListing()
        {
            if (!IsDataFolder(dataFilePath)) return false;
            var path = GetResourceListingFilePath();
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
            {
                Debug.LogError("Path to resource listing file is invalid");
                return false;
            }
            Debug.Log("Loading resource listing file");
            using (var reader = new BinaryReader(File.OpenRead(path)))
            {
                reader.ReadInt32(); //header
                var count = reader.ReadInt32();
                try
                {
                    for (var i = 0; i < count; i++)
                    {
                        var resID = reader.ReadInt32();
                        var stringLength = reader.ReadInt32();
                        var stringBytes = reader.ReadBytes(stringLength);
                        var stringValue = Encoding.UTF8.GetString(stringBytes);
                        SBResourceListing.Resources.Add(resID, stringValue);
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
