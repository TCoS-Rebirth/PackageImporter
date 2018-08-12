using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBBase
{
    [Serializable] public class SBWorldRules : UObject
    {
        [FoldoutGroup("SBWorldRules")]
        public bool AllowPvP;

        [FoldoutGroup("SBWorldRules")]
        public bool AllowChallenge;

        [FoldoutGroup("SBWorldRules")]
        public bool AllowCombat;

        [FoldoutGroup("SBWorldRules")]
        public bool InviteOnly;

        public SBWorldRules()
        {
        }
    }
}