using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_DuffPePRank : FSkill_EffectClass_Duff
    {
        [FoldoutGroup("PePRank")]
        [FieldConst()]
        public FSkill_ValueSpecifier RankChange;

        public FSkill_EffectClass_DuffPePRank()
        {
        }
    }
}