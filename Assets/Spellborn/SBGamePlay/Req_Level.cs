using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_Level : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public int RequiredLevel;

        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public byte Operator;

        public Req_Level()
        {
        }
    }
}
/*
event string ToString() {
return "L" $ OperatorToString(Operator)
$ string(RequiredLevel);      
}
*/