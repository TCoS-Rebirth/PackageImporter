using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_DuffRegeneration : FSkill_EffectClass_Duff
    {
        [FoldoutGroup("Regeneration")]
        [FieldConst()]
        public byte State;

        [FoldoutGroup("Regeneration")]
        [FieldConst()]
        public FSkill_ValueSpecifier Value;

        public FSkill_EffectClass_DuffRegeneration()
        {
        }
    }
}