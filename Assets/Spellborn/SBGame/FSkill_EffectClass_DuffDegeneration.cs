using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_DuffDegeneration : FSkill_EffectClass_Duff
    {
        [FoldoutGroup("Degeneration")]
        [FieldConst()]
        public byte State;

        [FoldoutGroup("Degeneration")]
        [FieldConst()]
        public FSkill_ValueSpecifier Value;

        public FSkill_EffectClass_DuffDegeneration()
        {
        }
    }
}