using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_Race : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public byte RequiredRace;

        public Req_Race()
        {
        }
    }
}