using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_Money : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public int RequiredAmount;

        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public byte Operator;

        public Req_Money()
        {
        }
    }
}