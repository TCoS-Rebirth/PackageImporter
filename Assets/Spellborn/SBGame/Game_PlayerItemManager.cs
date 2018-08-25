﻿using System;
using System.Collections.Generic;
using Engine;
using UnityEngine;

namespace SBGame
{
#pragma warning disable 414   

    [Serializable] public class Game_PlayerItemManager : Game_ItemManager
    {
        public int mCharacterID;

        private List<Game_ItemContainerListener> mItemContainerListeners = new List<Game_ItemContainerListener>();

        //public delegate<OnItemAdded> @__OnItemAdded__Delegate;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int mDBAddItems;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int mDBRemoveItems;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int mDBAddItemCost;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int mDBRemoveItemCost;

        public Game_PlayerItemManager()
        {
        }

        [Serializable] public struct sv2cl_Item
        {
            public int DBID;

            public int ItemTypeID;

            public int CharacterID;

            public int LocationSlot;

            public int LocationID;

            public int StackSize;

            public int Attuned;

            public byte Color1;

            public byte Color2;

            public byte LocationType;

            public byte Dummy;
        }

        public enum EItemAddRemoveType
        {
            IART_Shop,

            IART_Quest,

            IART_Cheat,

            IART_Breakdown,
        }

        public enum EItemChangeNotification
        {
            ICN_Added,

            ICN_Removed,

            ICN_RemovedByType,

            ICN_Moved,

            ICN_Swapped,

            ICN_Stacked,

            ICN_Used,

            ICN_Split,

            ICN_Painted,

            ICN_Attuned,
        }

        public enum EItemMoveError
        {
            IME_NoError,

            IME_InternalError,

            IME_InsufficientSpace,

            IME_MoveToSelf,

            IME_ItemIsAttuned,

            IME_NotEquipable,

            IME_CombatReady,

            IME_LevelTooLow,

            IME_EquipmentDataError,

            IME_UnequipShield,

            IME_UnequipMeleeWeapon,

            IME_NotABodySlot,

            IME_BodySlotDataError,

            IME_BodySlotWrongClass,

            IME_BodySlotFakeSkill,

            IME_NotASkillToken,

            IME_IllegalSkillToken,

            IME_DuplicateSkillToken,

            IME_CantMoveSigil,

            IME_MoveToMail,
        }
    }
}
/*
native function bool cl_CanRemoveWeapons(int aMeleeCount,int aRangedCount);
native function bool cl_UnequipItem(Game_Item aItem);
native function bool cl_EquipItem(Game_Item aItem);
native function bool cl_SplitItem(Game_Item aItem,int aAmount,int aTargetLocationSlot);
native function bool cl_BreakdownItem(Game_Item aItem);
native function bool cl_UseItem(Game_Item aItem);
native function bool cl_MoveItem(Game_Item aItem,byte aTargetLocationType,int aTargetLocationSlot,int aTargetLocationID);
native function Game_ItemContainerListener cl_GetItemContainerListener(byte aLocationType,int aLocationSlot,int aLocationID);
protected native function cl2sv_UseItem_CallStub();
private native event cl2sv_UseItem(int aDBID);
protected native function cl2sv_SplitItem_CallStub();
private native event cl2sv_SplitItem(int aDBID,int aAmount,int aTargetLocationSlot);
protected native function cl2sv_BreakdownItem_CallStub();
private native event cl2sv_BreakdownItem(int aLocationSlot);
protected native function cl2sv_MoveItem_CallStub();
private native event cl2sv_MoveItem(byte aSourceLocationType,int aSourceLocationSlot,int aSourceLocationID,byte aTargetLocationType,int aTargetLocationSlot,int aTargetLocationID);
protected native function sv2cl_UsedItem_CallStub();
native event sv2cl_UsedItem(int aDBID);
protected native function sv2cl_RemoveItem_CallStub();
private native event sv2cl_RemoveItem(byte aLocationType,int aLocationSlot,int aLocationID);
protected native function sv2cl_SetItem_CallStub();
private native event sv2cl_SetItem(sv2cl_Item aClientItem,byte aNotification);
final native event bool sv_UpdateMoney(int aAmount,optional SBDBAsyncCallback aCallback);
final native event bool sv_SplitItem(Game_Item aItem,int aAmount,int aTargetLocationSlot);
final native event bool sv_UseItem(Game_Item aItem);
final native event bool sv_MoveItem(Game_Item aItem,byte aTargetLocationType,int aTargetLocationSlot,int aTargetLocationID,optional int aCost,optional SBDBAsyncCallback aCallback);
final native event bool sv_RemoveItems(array<Game_Item> aItems,byte aRemoveType,optional int aCost,optional SBDBAsyncCallback aCallback);
final native event bool sv_ExecuteRemoveByType(optional SBDBAsyncCallback aCallback);
final native event bool sv_QueueRemoveByType(export editinline Item_Type aItemType,int aAmount,optional int aCost);
final native event bool sv_ExecuteAddItems(byte aAddType,optional SBDBAsyncCallback aCallback);
final native event bool sv_QueueAddItem(export editinline Item_Type aItemType,int aAmount,int aTargetLocationSlot,byte aColour1,byte aColour2,optional int aCost);
function cl_OnInit() {
Super.cl_OnInit();                                                          
Init();                                                                     
}
private final native function Init();
delegate OnItemAdded(Game_Item aGameItem,int aAmount);
*/