using System;
using Engine;
using SBBase;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Game_GameServer : Base_GameServer
    {
        public int FActorStatsWindowDummy1;

        public int FActorStatsWindowDummy2;

        public int FActorInspectInterfaceDummy1;

        public int FActorInspectInterfaceDummy2;

        public int FMemoryStatsWindowDummy1;

        public int FMemoryStatsWindowDummy2;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int FPathplanningWindowDummy1;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int FPathplanningWindowDummy2;

        public Game_GameServer()
        {
        }
    }
}