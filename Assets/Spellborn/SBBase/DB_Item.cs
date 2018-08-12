using System;

namespace SBBase
{
    [Serializable] public class DB_Item : Base_DBObject
    {
        public int Id;

        public int ItemTypeID;

        public int CharacterID;

        public byte LocationType;

        public int LocationID;

        public int LocationSlot;

        public int StackSize;

        public byte Attuned;

        public byte Color1;

        public byte Color2;

        public int Serial;

        public DB_Item()
        {
        }
    }
}