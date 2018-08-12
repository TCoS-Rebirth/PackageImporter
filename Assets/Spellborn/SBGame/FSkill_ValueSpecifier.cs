using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_ValueSpecifier : Content_Type
    {
        [FoldoutGroup("Base")]
        [FieldConst()]
        public bool AddConstant;

        [FoldoutGroup("Base")]
        [FieldConst()]
        public bool AddComboLength;

        [FoldoutGroup("Base")]
        [FieldConst()]
        public bool AddCharStatRelated;

        [FoldoutGroup("Base")]
        [FieldConst()]
        public bool AddTargetCountRelated;

        [FoldoutGroup("Base")]
        [FieldConst()]
        public bool DivideValue;

        [FoldoutGroup("Base")]
        [FieldConst()]
        public bool IgnoreFameModifier;

        [FoldoutGroup("Base")]
        [FieldConst()]
        public float AbsoluteMinimum;

        [FoldoutGroup("Base")]
        [FieldConst()]
        public float AbsoluteMaximum;

        [FoldoutGroup("Base")]
        [FieldConst()]
        public float LinkedAttributeModifier;

        [FoldoutGroup("Constant")]
        [FieldConst()]
        public float ConstantMinimum;

        [FoldoutGroup("Constant")]
        [FieldConst()]
        public float ConstantMaximum;

        [FoldoutGroup("ComboLength")]
        [FieldConst()]
        public float ComboLengthMinimum;

        [FoldoutGroup("ComboLength")]
        [FieldConst()]
        public float ComboLengthMaximum;

        [FoldoutGroup("CharRelated")]
        [FieldConst()]
        public byte CharacterStatistic;

        [FoldoutGroup("CharRelated")]
        [FieldConst()]
        public byte Source;

        [FoldoutGroup("CharRelated")]
        [FieldConst()]
        public float CharStatMinimumMultiplier;

        [FoldoutGroup("CharRelated")]
        [FieldConst()]
        public float CharStatMaximumMultiplier;

        [FoldoutGroup("TargetCountRelated")]
        [FieldConst()]
        public float TargetCountMinimumMultiplier;

        [FoldoutGroup("TargetCountRelated")]
        [FieldConst()]
        public float TargetCountMaximumMultiplier;

        [FoldoutGroup("TargetType")]
        [FieldConst()]
        public bool ApplyIncrease;

        [FoldoutGroup("TargetType")]
        [FieldConst()]
        public float SpiritIncrease;

        [FoldoutGroup("TargetType")]
        [FieldConst()]
        public float PlayerIncrease;

        [FoldoutGroup("TargetType")]
        [FieldConst()]
        public float NPCIncrease;

        [FoldoutGroup("TargetType")]
        [FieldConst()]
        public List<TaxonomyIncrease> TaxonomyIncreases = new List<TaxonomyIncrease>();

        public FSkill_ValueSpecifier()
        {
        }

        [Serializable] public struct TaxonomyIncrease
        {
            public NPC_Taxonomy Node;

            public float Increase;
        }
    }
}