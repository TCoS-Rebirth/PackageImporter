using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Engine;
using Framework.Common;
using TCosReborn;
using UnityEditor;
using UnityEngine;

namespace Framework.PackageExtractor
{
    class SBFileConverter: MonoBehaviour
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

        [ContextMenu("Import Gameplay packages")]
        void ImportGameplayPackages()
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
            LoadAllPackages(GetGameplayPackagePaths(), "Packages", new BaseImportLocator());
            Debug.Log("Loading took: " + (Time.realtimeSinceStartup - start)/60f+" minutes");
        }

        [ContextMenu("Import Map packages")]
        void ImportMapPackages()
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
            var importLocator = new MapImportsLocator("Packages");
            LoadAllPackages(GetMapPackagePaths(), "Maps", importLocator);
            Debug.Log("Loading took: " + (Time.realtimeSinceStartup - start)/60f+" minutes");
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

        class BaseImportLocator:IResourceLocator
        {
            readonly Dictionary<string, UObject> objects = new Dictionary<string, UObject>(StringComparer.OrdinalIgnoreCase);

            public void RegisterExportedResource(string absolutePath, UObject obj)
            {
                if (obj == null) throw new NullReferenceException("object to register must not be null");
                if (objects.ContainsKey(absolutePath))
                {
                    Debug.LogWarning("Duplicate object: " + absolutePath);
                    return;
                }
                objects.Add(absolutePath, obj);
            }

            public virtual bool TryFindObject(string absolutePath, out UObject obj)
            {
                return objects.TryGetValue(absolutePath, out obj);
            }
        }

        class MapImportsLocator: BaseImportLocator
        {

            static readonly char[] splitChar = {'.'};

            readonly string packagePath;

            public MapImportsLocator(string packagePath)
            {
                this.packagePath = packagePath;
            }

            public override bool TryFindObject(string absolutePath, out UObject obj)
            {
                if (base.TryFindObject(absolutePath, out obj)) return true;
                var pathParts = new Queue<string>(absolutePath.Split(splitChar, StringSplitOptions.RemoveEmptyEntries));
                if (pathParts.Count <= 0) return false;
                var packageName = pathParts.Dequeue();
                var package = AssetDatabase.LoadAssetAtPath<SBResourcePackage>(string.Format("Assets/{0}/{1}.prefab", packagePath, packageName));
                if (package == null)
                {
                    return false;
                }
                obj = package;
                while (pathParts.Count > 0)
                {
                    packageName = pathParts.Dequeue();
                    var child = obj.transform.Find(packageName);
                    if (child != null) obj = child.GetComponent<UObject>();
                    if (obj == null) return false;
                }
                return true;
            }
        }

        class PackageLoadJob
        {
            SBResourcePackage Package;
            PackageDeserializer Loader;
            List<PackageObject> Objects;

            public string PackageName
            {
                get { return Loader.PackageName; }
            }

            public PackageLoadJob(string path, string targetProjectFolder, IResourceLocator resourceLocator)
            {
                Package = new GameObject(Path.GetFileNameWithoutExtension(path)).AddComponent<SBResourcePackage>();
                Objects = new List<PackageObject>(256);
                Loader = new PackageDeserializer(path, targetProjectFolder, resourceLocator);
            }

            public void LoadObjects()
            {
                Loader.Load(ref Package, Objects);
            }

            public void DeserializeObjectContent()
            {
                for (var i = 0; i < Objects.Count; i++)
                {
                    Loader.ReadObject(Objects[i]);
                }
            }

            public void Finish()
            {
                Loader.Dispose();
            }
        }

        static void LoadAllPackages(List<string> paths, string targetProjectFolder, IResourceLocator resourceLocator)
        {
            PackageObject.ResetIDs();
            var jobs = new PackageLoadJob[paths.Count];
            for (var i = 0; i < paths.Count; i++)
            {
                jobs[i] = new PackageLoadJob(paths[i], targetProjectFolder, resourceLocator);
            }
            try
            {
                for (var i = 0; i < jobs.Length; i++)
                {
                    if (EditorUtility.DisplayCancelableProgressBar("Creating Structures", string.Format("{0}/{1} - {2}", i, jobs.Length, jobs[i].PackageName),
                        Mathf.Clamp01((float) i / jobs.Length)*0.5f))
                    {
                        if (EditorUtility.DisplayDialog("Cancel?", "temporary objects will not be cleaned up", "Yes", "No")) throw new Exception("aborted");
                    }
                    jobs[i].LoadObjects();
                }
                for (var i = 0; i < jobs.Length; i++)
                {
                    if (EditorUtility.DisplayCancelableProgressBar("Importing Package Data", string.Format("{0}/{1} - {2}", i, jobs.Length, jobs[i].PackageName),
                        0.5f+Mathf.Clamp01((float) i / jobs.Length)*0.5f))
                    {
                        if (EditorUtility.DisplayDialog("Cancel?", "temporary objects will not be cleaned up", "Yes", "No")) throw new Exception("aborted");
                    }
                    jobs[i].DeserializeObjectContent();
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            finally
            {
                for (var i = 0; i < jobs.Length; i++)
                {
                    jobs[i].Finish();
                }
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
