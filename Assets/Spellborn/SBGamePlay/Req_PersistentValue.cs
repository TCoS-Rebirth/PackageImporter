using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_PersistentValue : Content_Requirement
    {
        public Content_Type context;

        [FoldoutGroup("Requirement")]
        public int VariableID;

        [FoldoutGroup("Requirement")]
        public int Value;

        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public byte Operator;

        public Req_PersistentValue()
        {
        }
    }
}
/*
function bool ApiTracing() {
return True;                                                                
}
*/