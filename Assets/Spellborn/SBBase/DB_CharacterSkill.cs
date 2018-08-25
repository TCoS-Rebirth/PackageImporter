using System;

namespace SBBase
{
    [Serializable] public class DB_CharacterSkill : Base_DBObject
    {
        public int CharacterID;

        public int SkillID;

        public int TokenSlots;

        public DB_CharacterSkill()
        {
        }
    }
}