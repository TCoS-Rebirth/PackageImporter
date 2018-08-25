using System;
using Engine;

namespace SBBase
{
    [Serializable]
    public class DB_Character: Base_DBObject, IPacketWritable
    {
        public int Id;

        public byte Dead;

        public int AccountID;

        public string Name = string.Empty;

        public Vector Location;

        public int worldID;

        public int Money;

        public int AppearancePart1;

        public int AppearancePart2;

        public Rotator Rotation;

        public int FactionId;

        public int LastUsedTimestamp;

        public DB_Character()
        {
        }

        public void Write(IPacketWriter writer)
        {
            writer.WriteInt32(Id);
            writer.WriteByte(Dead);
            writer.WriteInt32(AccountID);
            writer.WriteString(Name);
            writer.WriteVector(Location);
            writer.WriteInt32(worldID);
            writer.WriteInt32(Money);
            writer.WriteInt32(AppearancePart1);
            writer.WriteInt32(AppearancePart2);
            writer.WriteRotator(Rotation);
            writer.WriteInt32(FactionId);
            writer.WriteInt32(LastUsedTimestamp);
        }
    }
}