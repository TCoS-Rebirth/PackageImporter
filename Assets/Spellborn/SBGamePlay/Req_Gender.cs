using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_Gender : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public byte Gender;

        public Req_Gender()
        {
        }
    }
}