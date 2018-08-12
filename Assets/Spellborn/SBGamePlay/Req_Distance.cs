using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_Distance : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        public string ActorTag = string.Empty;

        [FoldoutGroup("Requirement")]
        public int Distance;

        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public byte Operator;

        public Req_Distance()
        {
        }
    }
}