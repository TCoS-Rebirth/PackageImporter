using System;
using System.Collections.Generic;
using Engine;

namespace SBBase
{
    [Serializable] public class DB_SkillDeck: Base_DBObject, IPacketWritable
    {
        public int Id;

        public string mName = string.Empty;

        public List<int> mSkills = new List<int>();

        public DB_SkillDeck()
        {
        }

        public void Write(IPacketWriter writer)
        {
            writer.WriteInt32(Id);
        }
    }
}