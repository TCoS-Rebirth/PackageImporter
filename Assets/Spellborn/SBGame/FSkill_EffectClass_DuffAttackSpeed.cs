using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_DuffAttackSpeed : FSkill_EffectClass_Duff
    {
        [FoldoutGroup("AttackSpeed")]
        [FieldConst()]
        public FSkill_ValueSpecifier Value;

        public FSkill_EffectClass_DuffAttackSpeed()
        {
        }
    }
}