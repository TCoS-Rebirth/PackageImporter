using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class NPC_AttackSheet_ClassBased : NPC_AttackSheet
    {
        [FoldoutGroup("HealPhase")]
        public float HealthFraction;

        [FoldoutGroup("TargetPhase")]
        public float WarriorPriority;

        [FoldoutGroup("TargetPhase")]
        public float CasterPriority;

        [FoldoutGroup("TargetPhase")]
        public float RoguePriority;

        [FoldoutGroup("TargetPhase")]
        public float FriendlyPriority;

        [FoldoutGroup("TargetPhase")]
        public float SocialAggroPriority;

        [FoldoutGroup("TargetPhase")]
        public float ThreatMultiplier;

        [FoldoutGroup("TargetPhase")]
        public float LoveMultiplier;

        [FoldoutGroup("TargetPhase")]
        public float LowLevelPriority;

        [FoldoutGroup("TargetPhase")]
        public float HighLevelPriority;

        [FoldoutGroup("TargetPhase")]
        public float PlayerPriority;

        [FoldoutGroup("SkillPhase")]
        public float RangePriority;

        [FoldoutGroup("SkillPhase")]
        public List<SkillWeight> WarriorPreferences = new List<SkillWeight>();

        [FoldoutGroup("SkillPhase")]
        public List<SkillWeight> RoguePreferences = new List<SkillWeight>();

        [FoldoutGroup("SkillPhase")]
        public List<SkillWeight> CasterPreferences = new List<SkillWeight>();

        public NPC_AttackSheet_ClassBased()
        {
        }

        [Serializable] public struct SkillWeight
        {
            public float Weight;

            public byte Tag;
        }
    }
}