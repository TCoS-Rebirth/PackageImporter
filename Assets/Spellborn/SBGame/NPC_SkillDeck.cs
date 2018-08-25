using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class NPC_SkillDeck : Content_Type
    {
        [FoldoutGroup("Tiers")]
        public List<NPC_SkillDeckTier> Tiers = new List<NPC_SkillDeckTier>();

        public NPC_SkillDeck()
        {
        }
    }
}