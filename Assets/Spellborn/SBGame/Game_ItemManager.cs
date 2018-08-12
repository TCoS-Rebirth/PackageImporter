using System;
using Engine;
using SBBase;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Game_ItemManager : Base_Component
    {
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int mItems;

        public Game_ItemManager()
        {
        }
    }
}
/*
native event int GetFreeSlots(byte aLocationType,optional int aLocationID);
final native function int CountItemsByType(byte aType,optional byte aLocationType);
final native function int CountItems(export editinline Item_Type aItemType,optional byte aLocationType);
native function bool IsValidSlot(byte aLocationType,int aLocationSlot,int aLocationID);
native function Game_Item GetItemByID(int aDBID);
native function Game_Item GetItem(byte aLocationType,int aLocationSlot,optional int aLocationID);
native function array<Game_Item> GetItems(byte aLocationType,optional int aLocationID);
*/