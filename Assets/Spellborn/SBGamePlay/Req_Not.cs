using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_Not : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public Content_Requirement Requirement;

        public Req_Not()
        {
        }
    }
}