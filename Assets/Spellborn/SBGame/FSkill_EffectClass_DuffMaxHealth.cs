using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_DuffMaxHealth : FSkill_EffectClass_Duff
    {
        [FoldoutGroup("MaxHealth")]
        [FieldConst()]
        public FSkill_ValueSpecifier AddedValue;

        public FSkill_EffectClass_DuffMaxHealth()
        {
        }
    }
}