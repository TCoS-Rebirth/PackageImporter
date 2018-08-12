using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_NPC_Exists : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public NPC_Type NPCType;

        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public bool MustBeAlive;

        public Req_NPC_Exists()
        {
        }
    }
}