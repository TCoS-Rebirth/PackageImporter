using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_DuffAlterEffectInOutput : FSkill_EffectClass_Duff
    {
        [FoldoutGroup("AlterEffect")]
        [FieldConst()]
        public byte Mode;

        [FoldoutGroup("AlterEffect")]
        [FieldConst()]
        public byte AttackType;

        [FoldoutGroup("AlterEffect")]
        [FieldConst()]
        public byte MagicType;

        [FoldoutGroup("AlterEffect")]
        [FieldConst()]
        public byte EffectType;

        [FoldoutGroup("AlterEffect")]
        [FieldConst()]
        public FSkill_ValueSpecifier Value;

        [FoldoutGroup("AlterEffect")]
        [FieldConst()]
        public byte ValueMode;

        [FoldoutGroup("Uses")]
        [FieldConst()]
        public float UseInterval;

        [FoldoutGroup("Uses")]
        [FieldConst()]
        public int Uses;

        [FoldoutGroup("Uses")]
        [FieldConst()]
        public float IncreasePerUse;

        [FieldConst()]
        public FSkill_ValueSpecifier _AlterEffectValue;

        public FSkill_EffectClass_DuffAlterEffectInOutput()
        {
        }
    }
}
/*
final native function float AlterEffect(float aSkillValue,float aStoredValue,int aNumUses);
final native function bool MatchEffect(byte aMode,byte aAttackType,byte aMagicType,byte aEffectType);
*/