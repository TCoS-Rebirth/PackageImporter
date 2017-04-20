using System;
using System.Collections.Generic;
using System.IO;
using TCosReborn.Application;
using TCosReborn.Framework.Common;

namespace TCosReborn.Framework.PackageExtractor
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

        Dictionary<string, SBResourcePackage> loadedPackages = new Dictionary<string, SBResourcePackage>();
        Dictionary<string, SBResourcePackage> loadedMaps = new Dictionary<string, SBResourcePackage>();

        public bool GetPackage(string name, out SBResourcePackage package)
        {
            return loadedPackages.TryGetValue(name, out package);
        }

        public bool GetMap(string name, out SBResourcePackage map)
        {
            return loadedMaps.TryGetValue(name, out map);
        }

        bool IsDataFolder(string path)
        {
            var dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                Logger.LogError("directory doesn't exist: " + path);
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

        public bool LoadGameplayPackages()
        {
            if (!IsDataFolder(dataFilePath)) return false;
            Logger.Log("Loading packages..");
            var packageFilePaths = GetPackageFiles();
            List<PackageDeserializer.LinkerLink> links = new List<PackageDeserializer.LinkerLink>();
            for (var i = 0; i < packageFilePaths.Count; i++)
            {
                var fileName = Path.GetFileNameWithoutExtension(packageFilePaths[i]);
                if (string.IsNullOrEmpty(fileName))
                {
                    Logger.LogError("Invalid Package filename: " + packageFilePaths);
                    return false;
                }
                Logger.Log("Loading: " + fileName);
                links.AddRange(new PackageDeserializer().DeserializePackage(packageFilePaths[i]));
                //loadedPackages.Add(fileName, pkg);
            }
            //resolver.Resolve(loadedPackages);
            GameplayPackageResolver.Resolve(SBPackageResources.ObjectsByName, links);
            return true;
        }

        public bool LoadMaps()
        {
            if (!IsDataFolder(dataFilePath)) return false;
            Logger.Log("Loading maps..");
            var mapFilePaths = GetMapFiles();
            for (var i = 0; i < mapFilePaths.Count; i++)
            {
                var path = Path.GetDirectoryName(mapFilePaths[i]);
                if (path == null || path.EndsWith("base", StringComparison.OrdinalIgnoreCase))
                {
                    Logger.Log("Skipping: " + mapFilePaths[i]);
                    continue;
                }
                var fileName = Path.GetFileNameWithoutExtension(mapFilePaths[i]);
                if (string.IsNullOrEmpty(fileName))
                {
                    Logger.LogError("Invalid map filename: " + mapFilePaths);
                    return false;
                }
                Logger.Log("Loading: " + fileName);
                new PackageDeserializer().DeserializePackage(mapFilePaths[i]);
                //loadedMaps.Add(fileName, pkg);
            }
            return true;
        }
    }
}
