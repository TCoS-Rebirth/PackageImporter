using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class NPC_AttackSheet_RoleBased : NPC_AttackSheet
    {
        [FoldoutGroup("Roles")]
        [ArraySizeForExtraction(Size = 8)]
        public byte[] Roles = new byte[0];

        public NPC_AttackSheet_RoleBased()
        {
        }
    }
}