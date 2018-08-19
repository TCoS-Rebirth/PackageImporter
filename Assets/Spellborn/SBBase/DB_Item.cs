using System;
using SBGame;

namespace SBBase
{
    [Serializable]
    public class DB_Item: Base_DBObject, IPacketWritable
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

        public void Write(IPacketWriter writer)
        {
            writer.WriteInt32(Id);
            writer.WriteInt32(ItemTypeID);
            writer.WriteByte(LocationType);
            writer.WriteInt32(LocationID);
            writer.WriteInt32(LocationSlot);
            writer.WriteInt32(CharacterID);
            writer.WriteInt32(StackSize);
            writer.WriteByte(Attuned);
            writer.WriteByte(Color1);
            writer.WriteByte(Color2);
            writer.WriteInt32(Serial);
        }
    }
}