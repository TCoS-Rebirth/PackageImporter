using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class NPC_SkillDeckTier : UObject
    {
        [FoldoutGroup("skillTypes")]
        public List<FSkill_Type> Skills = new List<FSkill_Type>();

        public NPC_SkillDeckTier()
        {
        }
    }
}