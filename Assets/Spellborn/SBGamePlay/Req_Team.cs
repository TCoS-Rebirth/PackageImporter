using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_Team : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public int RequiredSize;

        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public byte Operator;

        public Req_Team()
        {
        }
    }
}