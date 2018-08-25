using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_QuestActive : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public Quest_Type RequiredQuest;

        public Req_QuestActive()
        {
        }
    }
}