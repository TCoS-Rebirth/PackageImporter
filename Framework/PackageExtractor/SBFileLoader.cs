using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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

        string GetProgressDataFilePath()
        {
            return Path.Combine(Path.Combine(dataFilePath, "static"), "level_progression.s");
        }

        string GetResourceListingFilePath()
        {
            return Path.Combine(Path.Combine(dataFilePath, "static"), "resources.s");
        }

        public bool LoadGameplayPackages()
        {
            if (!IsDataFolder(dataFilePath)) return false;
            Logger.Log("Loading packages..");
            var packageFilePaths = GetPackageFiles();
            var pendingImports = new Queue<ImportLink>();
            for (var i = 0; i < packageFilePaths.Count; i++)
            {
                var fileName = Path.GetFileNameWithoutExtension(packageFilePaths[i]);
                if (string.IsNullOrEmpty(fileName))
                {
                    Logger.LogError("Invalid Package filename: " + packageFilePaths);
                    return false;
                }
                Logger.Log("Loading: " + fileName);
                var package = new SBResourcePackage();
                new PackageDeserializer().Load(packageFilePaths[i], pendingImports, package);
                SBPackages.Packages.Add(fileName, package);
            }
            PackageImportResolver.Resolve(pendingImports);
            return true;
        }

        public bool LoadMaps()
        {
            if (!IsDataFolder(dataFilePath)) return false;
            Logger.Log("Loading maps..");
            var mapFilePaths = GetMapFiles();
            var pendingImports = new Queue<ImportLink>();
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
                var map = new SBMap();
                new PackageDeserializer().Load(mapFilePaths[i], pendingImports, map);
                SBMaps.Maps.Add(fileName, map);
            }
            PackageImportResolver.Resolve(pendingImports);
            return true;
        }

        public bool LoadLevelProgressData()
        {
            if (!IsDataFolder(dataFilePath)) return false;
            var path = GetProgressDataFilePath();
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
            {
                Logger.LogError("Path to levelprogression file is invalid");
                return false;
            }
            Logger.Log("Loading Levelprogression data");
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
                Logger.LogError("Path to resource listing file is invalid");
                return false;
            }
            Logger.Log("Loading resource listing file");
            using (var reader = new BinaryReader(File.OpenRead(path)))
            {
                reader.ReadInt32(); //header
                var count = reader.ReadInt32();
                try
                {
                    for (int i = 0; i < count; i++)
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
