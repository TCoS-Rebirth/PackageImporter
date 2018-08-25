using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Req_Inventory : Content_Requirement
    {
        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public Item_Type Item;

        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public int Amount;

        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public byte Operator;

        public Req_Inventory()
        {
        }
    }
}