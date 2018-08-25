using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class LootTable : Content_Type
    {
        public List<LootEntry> Entries = new List<LootEntry>();

        [FoldoutGroup("LootTable")]
        public string Name = string.Empty;

        [FoldoutGroup("LootTable")]
        public byte TableType;

        [FoldoutGroup("LootTable")]
        public int MinDropQuantity;

        [FoldoutGroup("LootTable")]
        public int MaxDropQuantity;

        [FoldoutGroup("LootTable")]
        public int MoneyBase;

        [FoldoutGroup("LootTable")]
        public int MoneyPerLevel;

        public LootTable()
        {
        }

        [Serializable] public struct DroppedItem
        {
            public Item_Type Item;

            public int Quantity;

            public int MinLevel;

            public int MaxLevel;
        }

        [Serializable] public struct LootEntry
        {
            public Item_Type Item;

            public int MinQuantity;

            public int MaxQuantity;

            public int Chance;

            public int MinLevel;

            public int MaxLevel;
        }

        public enum ETableType
        {
            ETT_Loot,

            ETT_Scavenge,

            ETT_ShopStock,
        }
    }
}
/*
native function InitDroppedItems(out array<DroppedItem> aResultItems);
function bool HasScavengeItems() {
return TableType == 1;                                                      
}
function bool HasLootItems() {
return TableType == 0;                                                      
}
*/