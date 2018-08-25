using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_DuffFreeze : FSkill_EffectClass_Duff
    {
        [FoldoutGroup("Freeze")]
        [FieldConst()]
        public bool Movement;

        [FoldoutGroup("Freeze")]
        [FieldConst()]
        public bool Rotation;

        [FoldoutGroup("Freeze")]
        [FieldConst()]
        public bool Animation;

        [FieldConst()]
        public FSkill_ValueSpecifier _FreezeValue;

        public FSkill_EffectClass_DuffFreeze()
        {
        }
    }
}