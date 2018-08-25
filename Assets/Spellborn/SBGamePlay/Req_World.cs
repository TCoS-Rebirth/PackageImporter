using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_World : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public int RequiredWorld;

        public Req_World()
        {
        }
    }
}