using System;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class NPC_SkillCondition : Content_Type
    {
        [FoldoutGroup("Default")]
        public bool DefaultResult;

        public NPC_SkillCondition()
        {
        }
    }
}