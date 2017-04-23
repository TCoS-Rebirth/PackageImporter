using System;
using TCosReborn.Application;
using TCosReborn.Framework.Common;
using TCosReborn.Framework.PackageExtractor;

namespace TCosReborn
{
    class Program
    {
        static void Main(string[] args)
        {
            InitRessources(args);
            Exit();
        }

        static void InitRessources(string[] args)
        {
            var start = DateTime.Now;
            if (args.Length == 0)
            {
                Logger.LogWarning("Specify the game data directory as argument");
                Exit(1);
            }
            var loader = new SBFileLoader(args[0]);
            if (!loader.LoadGameplayPackages())
            {
                Logger.LogError("Error loading packages");
                Exit(1);
            }
            Logger.LogOk("Packages loaded");
            if (!loader.LoadMaps())
            {
                Logger.LogError("Error loading maps");
                Exit(1);
            }
            Logger.LogOk("Maps loaded");
            if (!loader.LoadLevelProgressData())
            {
                Logger.LogError("Error loading levelprogression file");
                Exit(1);
            }
            Logger.LogOk("Level progress data loaded");
            if (!loader.LoadResourceIDListing())
            {
                Logger.LogError("Error loading resourceID listing file");
                Exit(1);
            }
            Logger.LogOk("Resource data loaded");
            Logger.Log(string.Format("{0} packages loaded", SBPackages.Packages.Count));
            Logger.Log(string.Format("{0} Maps loaded", SBMaps.Maps.Count));
            var duration = DateTime.Now - start;
            Logger.LogOk(string.Format("Finished loading in {0} seconds", duration.Seconds));
            Exit();
        }

        static void Exit(int errorCode = 0)
        {
            Logger.Log("Exiting");
            Console.ReadKey();
            Environment.Exit(errorCode);
        }
    }
}
