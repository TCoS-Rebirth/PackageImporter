using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBBase
{
    [Serializable] public class SBUniverse : UObject
    {
        [FoldoutGroup("Universe")]
        [ReadOnly]
        public SBUniverseRules GameRules;

        [FoldoutGroup("Universe")]
        [ReadOnly]
        public SBWorld EntryWorld;

        [FoldoutGroup("Universe")]
        [ReadOnly]
        public SBPortal EntryPortal;

        [FoldoutGroup("Universe")]
        [ReadOnly]
        public SBWorld LobbyWorld;

        [FoldoutGroup("Universe")]
        public int MaxPlayers;

        public List<SBWorld> Worlds = new List<SBWorld>();
    }
}