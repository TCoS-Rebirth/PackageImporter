using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_Area : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        public string AreaTag = string.Empty;

        public Req_Area()
        {
        }
    }
}