using System;
using Engine;

namespace SBBase
{
    [Serializable] public class DB_Character : Base_DBObject
    {
        public int Id;

        public byte Dead;

        public int AccountID;

        public Vector Location;

        public int worldID;

        public int Money;

        public int AppearancePart1;

        public int AppearancePart2;

        public Rotator Rotation;

        public int FactionId;

        public int LastUsedTimestamp;

        public string Name = string.Empty;

        public DB_Character()
        {
        }
    }
}