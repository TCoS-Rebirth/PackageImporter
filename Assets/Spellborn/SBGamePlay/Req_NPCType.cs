using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_NPCType : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public NPC_Type RequiredNPCType;

        public Req_NPCType()
        {
        }
    }
}