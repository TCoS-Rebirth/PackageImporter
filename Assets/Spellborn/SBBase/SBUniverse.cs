using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;

namespace SBBase
{
    [Serializable] public class SBUniverse : UObject
    {
        [FoldoutGroup("Universe")]
        public SBUniverseRules GameRules;

        [FoldoutGroup("Universe")]
        public SBWorld EntryWorld;

        [FoldoutGroup("Universe")]
        public SBPortal EntryPortal;

        [FoldoutGroup("Universe")]
        public SBWorld LobbyWorld;

        [FoldoutGroup("Universe")]
        public int MaxPlayers;

        [FoldoutGroup("Universe")]
        public List<LocalizedString> LocalizedInstanceNames = new List<LocalizedString>();

        public List<SBWorld> Worlds = new List<SBWorld>();

        public SBUniverse()
        {
        }
    }
}