using System;

namespace SBBase
{
    [Serializable] public class DB_QuestRequirement : Base_DBObject
    {
        public int Id;

        public int CharacterID;

        public int QuestReqId;

        public int Param0;

        public int Param1;

        public int Param2;

        public int Param3;

        public int Param4;

        public int Param5;

        public byte Enabled;

        public byte Completed;

        public DB_QuestRequirement()
        {
        }
    }
}