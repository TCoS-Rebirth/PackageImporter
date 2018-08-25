using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_Conditional : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public Content_Requirement Condition;

        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public Content_Requirement Requirement;

        public Req_Conditional()
        {
        }
    }
}