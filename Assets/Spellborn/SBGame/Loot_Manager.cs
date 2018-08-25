using System;
using System.Collections.Generic;
using Engine;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Loot_Manager : Actor
    {
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int mLastID;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<Loot_Transaction> mTransactions = new List<Loot_Transaction>();

        public Loot_Manager()
        {
        }
    }
}
/*
final native function sv_CreateTransaction(array<LootTable> aLootTables,array<Game_Pawn> aReceivers,float aTimer,optional byte aLootMode);
final static native function Loot_Manager sv_GetInstance();
*/