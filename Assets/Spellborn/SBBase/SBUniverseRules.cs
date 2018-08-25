using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBBase
{
    [Serializable] public class SBUniverseRules : UObject
    {
        [FoldoutGroup("SBUniverseRules")]
        public bool PvP;

        [FoldoutGroup("SBUniverseRules")]
        public bool Bla;

        [FoldoutGroup("SBUniverseRules")]
        public bool Muek;

        public SBUniverseRules()
        {
        }
    }
}