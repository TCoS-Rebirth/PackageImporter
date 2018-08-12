using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_PePRank : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public int RequiredPep;

        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public byte Operator;

        public Req_PePRank()
        {
        }
    }
}
/*
event string ToString() {
return "P" $ OperatorToString(Operator)
$ string(RequiredPep);        
}
*/