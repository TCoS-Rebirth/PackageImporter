using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_QuestFinished : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public Quest_Type RequiredQuest;

        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public int TimesFinished;

        public Req_QuestFinished()
        {
        }
    }
}