using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_DuffDisableSkillUse : FSkill_EffectClass_Duff
    {
        [FoldoutGroup("DisableSkillUse")]
        [FieldConst()]
        public byte ByAttackType;

        [FoldoutGroup("DisableSkillUse")]
        [FieldConst()]
        public byte ByMagicType;

        [FieldConst()]
        public FSkill_ValueSpecifier _DisableSkillUseValue;

        public FSkill_EffectClass_DuffDisableSkillUse()
        {
        }
    }
}
/*
final native function bool MatchDisableSkillUse(byte aAttackType,byte aMagicType);
*/