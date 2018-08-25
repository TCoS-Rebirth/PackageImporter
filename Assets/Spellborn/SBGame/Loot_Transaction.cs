using System;
using System.Collections.Generic;
using Engine;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Loot_Transaction : UObject
    {
        public const float MINIMUM_TIMER_VALUE = 0.5F;

        public const int LOOT_MODE_NR_OPTIONS = 3;

        public const int LOOT_MODE_MASTER = 2;

        public const int LOOT_MODE_GROUP = 1;

        public const int LOOT_MODE_FREE_FOR_ALL = 0;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int mTransactionID;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<DroppedLootItem> lootItems = new List<DroppedLootItem>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<Game_Pawn> mReceiverList = new List<Game_Pawn>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<GroupLootSelection> SelectedDroppedItems = new List<GroupLootSelection>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool mTimedTransaction;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float mCurrentTimerValue;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public byte mLootMode;

        public Loot_Transaction()
        {
        }

        [Serializable] public struct DroppedLootItem
        {
            public int LootItemID;

            public LootTable.DroppedItem Item;

            public bool Given;
        }

        [Serializable] public struct GroupLootSelection
        {
            public int DroppedItemIndex;

            public List<Game_Pawn> NeedList;

            public List<Game_Pawn> GreedList;
        }
    }
}
/*
final native function sv_GiveItemCompleted(int aErrorCode,int aLootItemID);
*/