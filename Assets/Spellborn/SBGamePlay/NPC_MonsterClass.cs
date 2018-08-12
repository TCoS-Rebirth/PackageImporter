using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class NPC_MonsterClass : NPC_Monster
    {
        [FoldoutGroup("Sheet")]
        public List<byte> ClassTypes = new List<byte>();

        [FoldoutGroup("Sheet")]
        public int ClassRank;

        public NPC_MonsterClass()
        {
        }
    }
}