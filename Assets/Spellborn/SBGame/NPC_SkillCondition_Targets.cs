using System;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class NPC_SkillCondition_Targets : NPC_SkillCondition_Self
    {
        [FoldoutGroup("Misc")]
        public bool DistanceCheck;

        [FoldoutGroup("Misc")]
        public bool AliveCheck;

        [FoldoutGroup("Misc")]
        public byte DistanceOperator;

        [FoldoutGroup("PMC")]
        public byte PhysiqueContext;

        [FoldoutGroup("PMC")]
        public byte MoraleContext;

        [FoldoutGroup("PMC")]
        public byte ConcentrationContext;

        [FoldoutGroup("BMF")]
        public byte BodyContext;

        [FoldoutGroup("BMF")]
        public byte MindContext;

        [FoldoutGroup("BMF")]
        public byte FocusContext;

        [FoldoutGroup("Misc")]
        public byte HealthContext;

        [FoldoutGroup("Misc")]
        public byte MovementFrozenContext;

        [FoldoutGroup("Misc")]
        public byte RotationFrozenContext;

        [FoldoutGroup("Misc")]
        public byte DistanceContext;

        [FoldoutGroup("Misc")]
        public float DistanceValue;

        public NPC_SkillCondition_Targets()
        {
        }

        public enum ETargetContext
        {
            ETC_AnyFriendlyTarget,

            ETC_AnyEnemyTarget,

            ETC_AverageFriendlyTargets,

            ETC_AverageEnemyTargets,
        }
    }
}