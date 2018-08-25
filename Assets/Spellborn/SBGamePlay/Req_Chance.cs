using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_Chance : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        public float Chance;

        public Req_Chance()
        {
        }
    }
}