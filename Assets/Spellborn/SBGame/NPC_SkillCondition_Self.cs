using System;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class NPC_SkillCondition_Self : NPC_SkillCondition
    {
        [FoldoutGroup("PMC")]
        public bool PhysiqueCheck;

        [FoldoutGroup("PMC")]
        public bool MoraleCheck;

        [FoldoutGroup("PMC")]
        public bool ConcentrationCheck;

        [FoldoutGroup("BMF")]
        public bool BodyCheck;

        [FoldoutGroup("BMF")]
        public bool MindCheck;

        [FoldoutGroup("BMF")]
        public bool FocusCheck;

        [FoldoutGroup("Misc")]
        public bool HealthCheck;

        [FoldoutGroup("Misc")]
        public bool MovementFrozenCheck;

        [FoldoutGroup("Misc")]
        public bool RotationFrozenCheck;

        [FoldoutGroup("Misc")]
        public bool MovementFrozenValue;

        [FoldoutGroup("Misc")]
        public bool RotationFrozenValue;

        [FoldoutGroup("PMC")]
        public byte PhysiqueOperator;

        [FoldoutGroup("PMC")]
        public byte MoraleOperator;

        [FoldoutGroup("PMC")]
        public byte ConcentrationOperator;

        [FoldoutGroup("BMF")]
        public byte BodyOperator;

        [FoldoutGroup("BMF")]
        public byte MindOperator;

        [FoldoutGroup("BMF")]
        public byte FocusOperator;

        [FoldoutGroup("Misc")]
        public byte HealthOperator;

        [FoldoutGroup("PMC")]
        public float PhysiqueValue;

        [FoldoutGroup("PMC")]
        public float MoraleValue;

        [FoldoutGroup("PMC")]
        public float ConcentrationValue;

        [FoldoutGroup("BMF")]
        public float BodyValue;

        [FoldoutGroup("BMF")]
        public float MindValue;

        [FoldoutGroup("BMF")]
        public float FocusValue;

        [FoldoutGroup("Misc")]
        public float HealthValue;

        public NPC_SkillCondition_Self()
        {
        }
    }
}