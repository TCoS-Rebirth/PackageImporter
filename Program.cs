using System;
using TCosReborn.Application;
using TCosReborn.Framework.Utility;

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
            ReflectionHelper.Initialize();
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
            if (!loader.LoadMaps())
            {
                Logger.LogError("Error loading maps");
                Exit(1);
            }
        }

        static void Exit(int errorCode = 0)
        {
            Logger.Log("Exiting");
            Console.ReadKey();
            Environment.Exit(errorCode);
        }
    }
}
