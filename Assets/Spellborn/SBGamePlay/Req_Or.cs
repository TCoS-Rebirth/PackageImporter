using System;
using System.Collections.Generic;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_Or : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();

        public Req_Or()
        {
        }
    }
}