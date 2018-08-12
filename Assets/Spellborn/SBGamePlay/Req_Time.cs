using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_Time : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        public float BeginTime;

        [FoldoutGroup("Requirement")]
        public float EndTime;

        public Req_Time()
        {
        }
    }
}