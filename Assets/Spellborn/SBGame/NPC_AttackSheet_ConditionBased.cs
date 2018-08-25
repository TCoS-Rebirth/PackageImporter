using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class NPC_AttackSheet_ConditionBased : NPC_AttackSheet
    {
        [FoldoutGroup("Contexts")]
        public List<SkillContext> SkillContexts = new List<SkillContext>();

        public NPC_AttackSheet_ConditionBased()
        {
        }

        [Serializable] public struct SkillContext
        {
            public FSkill_Type Skill;

            public NPC_SkillCondition Condition;
        }
    }
}