using System;
using SBBase;

namespace Database
{
    [Serializable]
    public class DBPlayerCharacter
    {
        public DB_Character Character;
        public DB_CharacterSheet Sheet;

        public DBPlayerCharacter(DB_Character ch, DB_CharacterSheet sh)
        {
            Character = ch;
            Sheet = sh;
        }
    }
}
