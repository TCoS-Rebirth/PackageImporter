using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_TargetProgress : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public Quest_Type quest;

        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public int objective;

        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public int Progress;

        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public byte Operator;

        public Req_TargetProgress()
        {
        }
    }
}