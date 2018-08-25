using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class NPC_SkillCondition_And : NPC_SkillCondition
    {
        [FoldoutGroup("Conditions")]
        [ArraySizeForExtraction(Size = 4)]
        public NPC_SkillCondition[] Conditions = new NPC_SkillCondition[0];

        public NPC_SkillCondition_And()
        {
        }
    }
}