using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_DuffDirectionalDamage : FSkill_EffectClass_Duff
    {
        [FoldoutGroup("Directional")]
        [FieldConst()]
        public byte Mode;

        [FoldoutGroup("Directional")]
        [FieldConst()]
        public FSkill_ValueSpecifier Value;

        public FSkill_EffectClass_DuffDirectionalDamage()
        {
        }
    }
}