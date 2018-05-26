using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Framework.Common;
using TCosReborn;
using UnityEngine;

namespace Framework.PackageExtractor
{
    class SBFileLoader
    {

        public SBFileLoader(string dataPath)
        {
            dataFilePath = dataPath;
        }

        string dataFilePath;
        const string MapExtension = "sbw";
        const string PackageExtension = "sbg";
        const string StaticFileExtension = "s";

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

        List<string> GetPackageFiles()
        {
            var path = Path.Combine(dataFilePath, "gameplay");
            return new List<string>(Directory.GetFiles(path, string.Format("*.{0}", PackageExtension), SearchOption.AllDirectories));
        }

        List<string> GetMapFiles()
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

        bool LoadPackages(List<string> paths, ref List<SBResourcePackage> packages, ref Dictionary<string, object> exportedObjects)
        {
            if (!IsDataFolder(dataFilePath))
            {
                packages = null;
                exportedObjects = null;
                return false;
            }
            var pendingImports = new Queue<ImportLink>(160000);
#if UNITY_EDITOR
            UnityEditor.EditorUtility.DisplayProgressBar("Loading packages", "", 0);
            try
            {
#endif
                for (var i = 0; i < paths.Count; i++)
                {
                    var fileName = Path.GetFileNameWithoutExtension(paths[i]);
                    if (string.IsNullOrEmpty(fileName))
                    {
                        Debug.LogError("Invalid Package filename: " + paths);
                        packages = null;
                        return false;
                    }
#if UNITY_EDITOR
                    UnityEditor.EditorUtility.DisplayProgressBar("Loading packages", fileName, Mathf.Clamp01((float) i / paths.Count));
#endif
                    var package = new SBResourcePackage {Name = fileName};
                    new PackageDeserializer().Load(paths[i], pendingImports, package, exportedObjects);
                    packages.Add(package);
                }
#if UNITY_EDITOR
                UnityEditor.EditorUtility.DisplayProgressBar("Resolving imports", "", 1f);
#endif
                PackageImportResolver.Resolve(pendingImports, exportedObjects);
#if UNITY_EDITOR
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            finally
            {
                UnityEditor.EditorUtility.ClearProgressBar();
            }
#endif
            return true;
        }

        bool LoadPackagesAsync(List<string> paths, ref List<SBResourcePackage> packages, ref Dictionary<string, object> exportedObjects)
        {
            if (!IsDataFolder(dataFilePath))
            {
                packages = null;
                exportedObjects = null;
                return false;
            }
            var pendingImports = new Queue<ImportLink>(160000);
            var jobs = new List<PackageLoadJob>();
            const int jobsPerThread = 15;
            for (var i = 0; i < paths.Count; i+=jobsPerThread)
            {
                var maxCount = Mathf.Min(jobsPerThread, paths.Count - i);
                var jobPaths = new string[maxCount];
                for (var j = i; j < i+maxCount; j++)
                {
                    var fileName = Path.GetFileNameWithoutExtension(paths[j]);
                    if (string.IsNullOrEmpty(fileName))
                    {
                        Debug.LogError("Invalid Package filename: " + paths);
                        packages = null;
                        return false;
                    }
                    jobPaths[j-i] = paths[j];
                }
                jobs.Add(new PackageLoadJob(jobPaths));
            }
            try
            {
                for (var i = 0; i < jobs.Count; i++)
                {
                    jobs[i].Start();
                }
                var numDone = 0;
                while (numDone < jobs.Count)
                {
                    numDone = 0;
                    for (var i = 0; i < jobs.Count; i++)
                    {
                        numDone += jobs[i].IsDone ? 1 : 0;
                    }
                    #if UNITY_EDITOR
                    if (UnityEditor.EditorUtility.DisplayCancelableProgressBar("Loading packages", "", Mathf.Clamp01((float) numDone / jobs.Count)))
                    {
                        for (var i = 0; i < jobs.Count; i++)
                        {
                            jobs[i].Cancel();
                        }
                        return false;
                    }
                    #endif
                    Thread.Sleep(100);
                }
                for (var i = 0; i < jobs.Count; i++)
                {
                    if (jobs[i].LastException != null)
                    {
                        Debug.LogException(jobs[i].LastException);
                        continue;
                    }
                    packages.AddRange(jobs[i].Packages);
                    foreach (var exportedObject in jobs[i].ExportedObjects)
                    {
                        exportedObjects.Add(exportedObject.Key, exportedObject.Value);
                    }
                    while (jobs[i].PendingImports.Count > 0)
                    {
                        pendingImports.Enqueue(jobs[i].PendingImports.Dequeue());
                    }
                }
#if UNITY_EDITOR
                UnityEditor.EditorUtility.DisplayProgressBar("Resolving imports", "", 1f);
#endif
                PackageImportResolver.Resolve(pendingImports, exportedObjects);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            #if UNITY_EDITOR
            finally
            {
                UnityEditor.EditorUtility.ClearProgressBar();
            }
            #endif
            return true;
        }

        public bool LoadGameplayPackages(out List<SBResourcePackage> packages, out Dictionary<string, object> exportedObjects)
        {
            packages = new List<SBResourcePackage>();
            exportedObjects = new Dictionary<string, object>(8000, StringComparer.OrdinalIgnoreCase);
            return LoadPackages(GetPackageFiles(), ref packages, ref exportedObjects);
        }

        public bool LoadGameplayPackagesAsync(out List<SBResourcePackage> packages, out Dictionary<string, object> exportedObjects)
        {
            packages = new List<SBResourcePackage>();
            exportedObjects = new Dictionary<string, object>(8000, StringComparer.OrdinalIgnoreCase);
            return LoadPackagesAsync(GetPackageFiles(), ref packages, ref exportedObjects);
        }

        public bool LoadMaps(ref Dictionary<string, object> exportedObjects, out List<SBResourcePackage> packages)
        {
            packages = new List<SBResourcePackage>();
            return LoadPackages(GetMapFiles(), ref packages, ref exportedObjects);
        }

        public bool LoadMapsAsync(ref Dictionary<string, object> exportedObjects, out List<SBResourcePackage> packages)
        {
            packages = new List<SBResourcePackage>();
            return LoadPackagesAsync(GetMapFiles(), ref packages, ref exportedObjects);
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

        class PackageLoadJob
        {
            volatile bool isDone;
            Thread workerThread;
            readonly string[] filePaths;
            public readonly List<SBResourcePackage> Packages;
            public readonly Queue<ImportLink> PendingImports;
            public Exception LastException;
            public readonly Dictionary<string, object> ExportedObjects;

            public bool IsDone
            {
                get
                {
                    lock (this)
                    {
                        return isDone;
                    }
                }
                private set
                {
                    lock (this)
                    {
                        isDone = value;
                    }
                }
            }

            public PackageLoadJob(string[] filePaths)
            {
                this.filePaths = filePaths;
                isDone = false;
                Packages = new List<SBResourcePackage>(filePaths.Length);
                PendingImports = new Queue<ImportLink>(256);
                ExportedObjects = new Dictionary<string, object>(256, StringComparer.OrdinalIgnoreCase);
            }

            public void Start()
            {
                workerThread = new Thread(DoWork);
                workerThread.Start();
            }

            public void Cancel()
            {
                workerThread.Abort();
            }

            void DoWork()
            {
                try
                {
                    IsDone = false;
                    for (var i = 0; i < filePaths.Length; i++)
                    {
                        var pkg = new SBResourcePackage {Name = Path.GetFileNameWithoutExtension(filePaths[i])};
                        new PackageDeserializer().Load(filePaths[i], PendingImports, pkg, ExportedObjects);
                        Packages.Add(pkg);
                    }
                }
                catch (Exception e)
                {
                    LastException = e;
                }
                finally
                {
                    IsDone = true;
                }
            }
        }
    }
}
