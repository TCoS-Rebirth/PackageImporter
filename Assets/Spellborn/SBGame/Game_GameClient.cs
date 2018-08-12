using System;
using Engine;
using SBBase;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Game_GameClient : Base_GameClient
    {
        public int FActorStatsWindowDummy1;

        public int FActorStatsWindowDummy2;

        public int FActorInspectInterfaceDummy1;

        public int FActorInspectInterfaceDummy2;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int GroupingGatePtr;

        public Game_GameClient()
        {
        }
    }
}