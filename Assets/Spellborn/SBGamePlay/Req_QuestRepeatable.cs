using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_QuestRepeatable : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public bool Repeatable;

        [FoldoutGroup("quest")]
        [FieldConst()]
        public Quest_Type quest;

        public Req_QuestRepeatable()
        {
        }
    }
}