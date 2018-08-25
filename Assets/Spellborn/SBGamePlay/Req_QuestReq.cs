using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_QuestReq : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public Quest_Type quest;

        public Req_QuestReq()
        {
        }
    }
}