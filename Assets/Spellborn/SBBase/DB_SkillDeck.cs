using System;
using System.Collections.Generic;
using Engine;

namespace SBBase
{
    [Serializable] public class DB_SkillDeck : UObject
    {
        public int Id;

        public string mName = string.Empty;

        public List<int> mSkills = new List<int>();

        public DB_SkillDeck()
        {
        }
    }
}