using System;

namespace SBBase
{
    [Serializable] public class DB_CharacterSheet : Base_DBObject
    {
        public int ClassId;

        public float FamePoints;

        public float PepPoints;

        public float Health;

        public int SelectedSkilldeckID;

        public byte ExtraBodyPoints;

        public byte ExtraMindPoints;

        public byte ExtraFocusPoints;

        public DB_CharacterSheet()
        {
        }
    }
}