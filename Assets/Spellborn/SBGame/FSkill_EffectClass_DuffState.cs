using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_DuffState : FSkill_EffectClass_Duff
    {
        [FoldoutGroup("Attribute")]
        [FieldConst()]
        public byte Attribute;

        [FoldoutGroup("Attribute")]
        [FieldConst()]
        public FSkill_ValueSpecifier Value;

        public FSkill_EffectClass_DuffState()
        {
        }
    }
}