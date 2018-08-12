using System;
using System.Collections.Generic;

namespace Engine
{
    [Serializable] public class GameEngine : Engine
    {
        public string mGameType = string.Empty;

        public string mWorldFile = string.Empty;

        [FieldConfig()]
        public List<string> ServerActors = new List<string>();

        [FieldConfig()]
        public List<string> ServerPackages = new List<string>();

        [FieldConst()]
        public LevelInfo LevelInfo;

        [FieldConst()]
        public Level GLevel;

        [FieldConst()]
        public GameInfo GGameInfo;

        public GameEngine()
        {
        }

        [Serializable] public struct URL
        {
            public string Protocol;

            public string Host;

            public int Port;

            public string Map;

            public List<string> Op;

            public string Portal;

            public int Valid;
        }
    }
}
/*
final native function int GetInstanceID();
final native function bool IsInstance();
final native function int GetUniverseID();
final native function int GetWorldID();
final native function PlayerController GetPlayerController();
final native(1001) iterator function AllActors(class<Actor> BaseClass,out Actor Actor,optional name MatchTag);
final native(1000) function Actor Spawn(class<Actor> SpawnClass,optional Actor SpawnOwner,optional name SpawnTag,optional Vector SpawnLocation,optional Rotator SpawnRotation,optional int InstanceID);
*/