using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_DuffAffinity : FSkill_EffectClass_Duff
    {
        [FoldoutGroup("Affinity")]
        [FieldConst()]
        public byte MagicType;

        [FoldoutGroup("Affinity")]
        [FieldConst()]
        public FSkill_ValueSpecifier Value;

        public FSkill_EffectClass_DuffAffinity()
        {
        }
    }
}