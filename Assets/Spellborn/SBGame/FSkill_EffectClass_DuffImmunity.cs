using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_DuffImmunity : FSkill_EffectClass_Duff
    {
        [FoldoutGroup("Immunity")]
        [FieldConst()]
        public byte ByAttackType;

        [FoldoutGroup("Immunity")]
        [FieldConst()]
        public byte ByMagicType;

        [FoldoutGroup("Immunity")]
        [FieldConst()]
        public byte ByEffectType;

        [FoldoutGroup("SharingFX")]
        [FieldConst()]
        public FSkill_EffectClass_AudioVisual_Emitter SourceFX;

        [FieldConst()]
        public FSkill_ValueSpecifier _ImmunityValue;

        public FSkill_EffectClass_DuffImmunity()
        {
        }
    }
}
/*
final native function bool MatchImmunity(byte aAttackType,byte aMagicType,byte aEffectType);
*/