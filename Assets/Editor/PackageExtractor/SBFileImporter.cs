using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Engine;
using Gameplay;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using NUnit.Framework;

namespace Framework.PackageExtractor
{

    class SBFileImporter: EditorWindow
    {

        [SerializeField] string dataFilePath;
        const string MapExtension = "sbw";
        const string PackageExtension = "sbg";
        const string StaticFileExtension = "s";

        bool pauseForDebugger;

        [MenuItem("Spellborn/PackageExtractor")]
        static void Open()
        {
            GetWindow<SBFileImporter>("Package Importer");
        }

        void OnGUI()
        {
            pauseForDebugger = EditorGUILayout.Toggle("Pause for debugger", pauseForDebugger);
            if (GUILayout.Button("Import Gameplay packages")) ImportGameplayPackages();
            if (GUILayout.Button("Import Maps")) ImportMapPackages();
            if (GUILayout.Button("Post process imported maps")) ProcessMaps();
            if (GUILayout.Button("Import LevelProgression file")) ImportLevelProgressData();
            if (GUILayout.Button("Import Resource Listing file")) ImportResourceList();
            if (GUILayout.Button("Assign ResourceIDs")) AssignResourceIDs();
            if (GUILayout.Button("Import CompleteUniverse package")) ImportCompleteUniverses();
            GUILayout.Space(20);
            if (GUILayout.Button("Re-Serialize All assets (careful !)"))
            {
                AssetDatabase.ForceReserializeAssets();
            }
        }

        void ImportGameplayPackages()
        {
            if (!CheckDataFolder(dataFilePath))
            {
                Debug.LogError("Wrong path (should be [GameDirectory]/data )");
                return;
            }
            Resources.UnloadUnusedAssets();
            GC.Collect();
            var start = Time.realtimeSinceStartup;
            LoadAllPackages(GetGameplayPackagePaths(), true, "Packages", new TransientImportLocator());
            Debug.Log("Loading took: " + (Time.realtimeSinceStartup - start)/60f+" minutes");
        }

        void ImportMapPackages()
        {
            if (!CheckDataFolder(dataFilePath))
            {
                Debug.LogError("Wrong path (should be [GameDirectory]/data )");
                return;
            }
            Resources.UnloadUnusedAssets();
            GC.Collect();
            var start = Time.realtimeSinceStartup;
            var importLocator = new HybridBaseFolderImportLocator("Packages");
            LoadAllPackages(GetMapPackagePaths(), false, "Maps", importLocator);
            Debug.Log("Loading took: " + (Time.realtimeSinceStartup - start)/60f+" minutes");
        }

        void ProcessMaps()
        {
            var currentScene = EditorSceneManager.GetActiveScene().path;
            var buildScenes = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes);
            buildScenes.Clear();
            try
            {   
                foreach (var item in AssetDatabase.FindAssets("t:" + typeof(SceneAsset).Name))
                {
                    EditorUtility.DisplayProgressBar("Loading scenes", string.Empty, 5);
                    var asset = AssetDatabase.GUIDToAssetPath(item);
                    if (string.IsNullOrEmpty(asset)) continue;
                    buildScenes.Add(new EditorBuildSettingsScene(asset, true));
                }
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }
            try
            {
                EditorBuildSettings.scenes = buildScenes.ToArray();
                for (int i = 0; i < buildScenes.Count; i++)
                {
                    EditorUtility.DisplayProgressBar("Processing scene", buildScenes[i].path, Mathf.Clamp01((float)i / buildScenes.Count));
                    var scene = EditorSceneManager.OpenScene(buildScenes[i].path, OpenSceneMode.Single);
                    EditorSceneManager.SetActiveScene(scene);
                    foreach(var actor in FindObjectsOfType<Actor>())
                    {
                        actor.transform.position = actor.Location;
                        EditorUtility.SetDirty(actor);
                    }
                    RenderSettings.skybox = null;
                    RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
                    RenderSettings.defaultReflectionMode = UnityEngine.Rendering.DefaultReflectionMode.Custom;
                    Lightmapping.bakedGI = false;
                    Lightmapping.realtimeGI = false;
                    Lightmapping.Clear();
                    EditorSceneManager.MarkSceneDirty(scene);
                    EditorSceneManager.SaveScene(scene);
                }
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }
            EditorSceneManager.OpenScene(currentScene, OpenSceneMode.Single);
        }
        
        void ImportLevelProgressData()
        {
            if (!CheckDataFolder(dataFilePath))
            {
                Debug.LogError("Wrong path (should be [GameDirectory]/data )");
                return;
            }
            var path = GetProgressDataFilePath();
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
            {
                Debug.LogError("Path to levelprogression file is invalid");
                return;
            }
            using (var reader = new BinaryReader(File.OpenRead(path)))
            {
                var lpd = CreateInstance<LevelProgression>();
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
                    lpd.EditorAddProgressData(pd);
                }
                AssetDatabase.CreateAsset(lpd, "Assets/Data/LevelProgression.asset");
            }
        }

        void ImportResourceList()
        {
            if (!CheckDataFolder(dataFilePath))
            {
                Debug.LogError("Wrong path (should be [GameDirectory]/data )");
                return;
            }
            var path = GetResourceListingFilePath();
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
            {
                Debug.LogError("Path to resource listing file is invalid");
                return;
            }
            using (var reader = new BinaryReader(File.OpenRead(path)))
            {
                var rl = CreateInstance<SBResourceListing>();
                reader.ReadInt32(); //header
                var count = reader.ReadInt32();
                for (var i = 0; i < count; i++)
                {
                    var resID = reader.ReadInt32();
                    var stringLength = reader.ReadInt32();
                    var stringBytes = reader.ReadBytes(stringLength);
                    var stringValue = Encoding.UTF8.GetString(stringBytes);
                    rl.EditorAddResource(resID, stringValue);
                }
                AssetDatabase.CreateAsset(rl, "Assets/Data/ResourceListing.asset");
            }
        }

        void AssignResourceIDs()
        {
            var guids = AssetDatabase.FindAssets("t:GameObject", new[] {"Assets/Packages"});
            var pkgs = new List<SBResourcePackage>();
            for (int i = 0; i < guids.Length; i++)
            {
                var path = AssetDatabase.GUIDToAssetPath(guids[i]);
                var pkg = AssetDatabase.LoadAssetAtPath<SBResourcePackage>(path);
                if (pkg != null) pkgs.Add(pkg);
            }
            var resIDs = LoadResIDs().GetIDs();
            int assigned = 0;
            try
            {
                foreach (var package in pkgs)
                {
                    EditorUtility.DisplayProgressBar("Assigning IDs", package.name, Mathf.Clamp01((float) pkgs.IndexOf(package) / pkgs.Count));
                    var children = package.GetComponentsInChildren<UObject>();
                    for (int i = 0; i < children.Length; i++)
                    {
                        if (children[i].transform == package.transform) continue;
                        var path = AnimationUtility.CalculateTransformPath(children[i].transform, package.transform).Replace("/", ".");
                        if (!string.IsNullOrEmpty(path)) path = package.name + "." + path;
                        else
                        {
                            Debug.LogWarning("null?:" + children[i].name);
                        }
                        int resID;
                        if (resIDs.TryGetValue(path, out resID))
                        {
                            children[i].ResourceID = resID;
                            assigned += 1;
                        }
                        else
                        {
                            Debug.LogWarning("ID not found: " + path);
                        }
                    }
                    EditorUtility.SetDirty(package.gameObject);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            finally
            {
                EditorUtility.ClearProgressBar();
                Debug.Log(assigned + " IDs assigned");
                AssetDatabase.SaveAssets();
            }
        }

        void ImportCompleteUniverses()
        {
            if (!CheckDataFolder(dataFilePath))
            {
                Debug.LogError("Wrong path (should be [GameDirectory]/data )");
                return;
            }
            var job = new PackageLoadJob(GetCompleteUniversesFilePath(), "Packages", new TransientImportLocator());
            try
            {
                EditorUtility.DisplayProgressBar("Loading Complete_UniverseSBU", string.Empty, 33);
                job.LoadObjects(true);
                if (pauseForDebugger) EditorUtility.DisplayDialog("", "Attach debugger now", "Ok");
                EditorUtility.DisplayProgressBar("Loading Complete_UniverseSBU", string.Empty, 66);
                job.DeserializeObjectContent();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            finally
            {
                EditorUtility.ClearProgressBar();
                job.Finish();
            }
        }

        SBResourceListing LoadResIDs()
        {
            var guids = AssetDatabase.FindAssets("t:" + typeof(SBResourceListing).Name);
            if (guids.Length == 0) return null;
            var asset = AssetDatabase.LoadAssetAtPath<SBResourceListing>(AssetDatabase.GUIDToAssetPath(guids[0]));
            Assert.IsNotNull(asset);
            return asset;
        }

        [Test]
        public void TestLoadSBResourceListing()
        {
            Assert.IsNotNull(LoadResIDs());
        }

        [Test]
        public void TestFindAppearanceSetGP()
        {
            var importer = new HybridBaseFolderImportLocator("Packages");
            Assert.IsNotNull(importer.FindPackage("AppearanceSetGP"));
        }

        [Test]
        public void TestFindCivNPCsDeadSpellstormGP()
        {
            var importer = new HybridBaseFolderImportLocator("Packages");
            Assert.IsNotNull(importer.FindPackage("CIV_NPCs_DeadspellStormGP"));
        }

        bool CheckDataFolder(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                dataFilePath = EditorUtility.OpenFolderPanel("Select Spellborn Data Folder", "", "");
            }
            if (string.IsNullOrEmpty(dataFilePath)) return false;
            var dirInfo = new DirectoryInfo(dataFilePath);
            if (!dirInfo.Exists)
            {
                dataFilePath = EditorUtility.OpenFolderPanel("Select Spellborn Data Folder", "", "");
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

        string GetCompleteUniversesFilePath()
        {
            return Path.Combine(Path.Combine(dataFilePath, "universes"), "Complete_UniverseSBU.sbu");
        }

        class TransientImportLocator:IResourceLocator
        {
            readonly Dictionary<string, UObject> objects = new Dictionary<string, UObject>(StringComparer.OrdinalIgnoreCase);

            public bool RegisterExportedResource(string absolutePath, UObject obj)
            {
                if (obj == null) throw new NullReferenceException("object to register must not be null");
                if (objects.ContainsKey(absolutePath))
                {
                    return false;
                }
                objects.Add(absolutePath, obj);
                return true;
            }

            public virtual bool TryFindObject(string absolutePath, out UObject obj)
            {
                return objects.TryGetValue(absolutePath, out obj);
            }
        }

        class HybridBaseFolderImportLocator: TransientImportLocator
        {

            static readonly char[] splitChar = {'.'};

            readonly string packagePath;

            public HybridBaseFolderImportLocator(string packagePath)
            {
                this.packagePath = packagePath;
            }

            public override bool TryFindObject(string absolutePath, out UObject obj)
            {
                if (base.TryFindObject(absolutePath, out obj)) return true;
                var pathParts = new Queue<string>(absolutePath.Split(splitChar, StringSplitOptions.RemoveEmptyEntries));
                if (pathParts.Count <= 0) return false;
                var packageName = pathParts.Dequeue();
                var package = FindPackage(packageName); /*AssetDatabase.LoadAssetAtPath<SBResourcePackage>(string.Format("Assets/{0}/{1}.prefab", packagePath, packageName));*/
                if (package == null)
                {
                    return false;
                }
                var path = string.Empty;
                while (pathParts.Count > 0)
                {
                    path = string.IsNullOrEmpty(path) ? pathParts.Dequeue() : string.Format("{0}/{1}", path, pathParts.Dequeue());
                }
                var child = package.transform.Find(path);
                if (child == null)
                {
                    obj = null;
                    return false;
                }
                obj = child.GetComponent<UObject>();
                return obj != null;
            }

            public SBResourcePackage FindPackage(string name)
            {
                var path = string.Format("Assets/{0}", packagePath);
                var assets = AssetDatabase.FindAssets(string.Format("t:GameObject {0}", name), new[] {path});
                if (assets.Length == 0) return null;
                path = AssetDatabase.GUIDToAssetPath(assets[0]);
                var asset = AssetDatabase.LoadAssetAtPath<SBResourcePackage>(path);
                return asset;
            }
        }

        class PackageLoadJob
        {
            public SBResourcePackage Package;
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

            public void LoadObjects(bool createPrefabs)
            {
                Loader.Load(ref Package, Objects, createPrefabs);
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

        void LoadAllPackages(List<string> paths, bool isGameplayPackage, string targetProjectFolder, IResourceLocator resourceLocator)
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
                    jobs[i].LoadObjects(isGameplayPackage);
                }
                if (pauseForDebugger) EditorUtility.DisplayDialog("", "Attach debugger now", "Ok");
                for (var i = 0; i < jobs.Length; i++)
                {
                    if (EditorUtility.DisplayCancelableProgressBar("Importing Package Data", string.Format("{0}/{1} - {2}", i, jobs.Length, jobs[i].PackageName),
                        0.5f+Mathf.Clamp01((float) i / jobs.Length)*0.5f))
                    {
                        if (EditorUtility.DisplayDialog("Cancel?", "temporary objects will not be cleaned up", "Yes", "No")) throw new Exception("aborted");
                    }
                    jobs[i].DeserializeObjectContent();
                }
                if (!isGameplayPackage)
                {
                    for (var i = 0; i < jobs.Length; i++)
                    {
                        EditorUtility.DisplayProgressBar("Creating Map files", string.Format("{0}/{1} - {2}", i, jobs.Length, jobs[i].PackageName),Mathf.Clamp01((float) i / jobs.Length));
                        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
                        EditorSceneManager.MoveGameObjectToScene(jobs[i].Package.gameObject, scene);
                        while (jobs[i].Package.transform.childCount > 0)
                        {
                            jobs[i].Package.transform.GetChild(0).parent = null;
                        }
                        GameObject.DestroyImmediate(jobs[i].Package.gameObject, false);
                        EditorSceneManager.SaveScene(scene, string.Format("Assets/{0}/{1}.unity", targetProjectFolder, jobs[i].PackageName));
                        EditorSceneManager.CloseScene(scene, true);
                    }
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
                AssetDatabase.SaveAssets();
            }
        }

    }
}
