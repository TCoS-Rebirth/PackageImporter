using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_TargetActive : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public Quest_Type quest;

        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public int objective;

        public Req_TargetActive()
        {
        }
    }
}