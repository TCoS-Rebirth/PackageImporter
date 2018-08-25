﻿using System;
using System.Collections.Generic;
using Engine;
using SBBase;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Game_Looting : Base_Component
    {
        public const int LOOT_ITEM_REJECTED_INVENTORY_FULL = 1;

        public const int LOOT_ITEM_REJECTED_ALREADY_TAKEN = 0;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float mLootTimer;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<ServerLootInfo> ServerLoot = new List<ServerLootInfo>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<ClientLootInfo> ClientLoot = new List<ClientLootInfo>();

        public Game_Looting()
        {
        }

        [Serializable] public struct LootItem
        {
            public Game_Item GameItem;

            public bool Chosen;
        }

        [Serializable] public struct ReplicatedLootItem
        {
            public int ResourceId;

            public int LootItemID;

            public int Quantity;
        }

        [Serializable] public struct ServerLootInfo
        {
            public Loot_Transaction Transaction;

            public List<ReplicatedLootItem> lootItems;
        }

        [Serializable] public struct ClientLootInfo
        {
            public int TransactionID;

            public byte LootMode;

            public float Timer;

            public List<ReplicatedLootItem> lootItems;

            public List<LootItem> Items;

            public List<int> EligibleMembers;
        }
    }
}
/*
protected native function cl2sv_MasterLootChoice_CallStub();
final native event cl2sv_MasterLootChoice(array<int> aTransactionIDs,array<int> aLootItemIds,int aTarget);
protected native function cl2sv_GroupLootChoice_CallStub();
final native event cl2sv_GroupLootChoice(array<int> aTransactionIDs,array<int> aLootItemIds,bool aNeedFlag);
protected native function cl2sv_SelectItems_CallStub();
final native event cl2sv_SelectItems(array<int> aTransactionIDs,array<int> aLootItemIds);
protected native function cl2sv_EndTransaction_CallStub();
final native event cl2sv_EndTransaction(int aTransactionID);
protected native function cl2sv_EndTransactions_CallStub();
final native event cl2sv_EndTransactions(array<int> aTransactionIDs);
final native function cl_MasterLootChoice(array<Game_Item> aItems,int aTarget);
final function cl_GreedItems(array<Game_Item> aItems) {
cl_GroupLootChoice(aItems,False);                                           
}
final function cl_NeedItems(array<Game_Item> aItems) {
cl_GroupLootChoice(aItems,True);                                            
}
private final native function cl_GroupLootChoice(array<Game_Item> aItems,bool aNeedFlag);
final native function cl_SelectItems(array<Game_Item> aItems);
final event cl_ItemRejectedMessage(byte aReason) {
local Game_PlayerController PlayerController;
PlayerController = Game_PlayerController(Outer.Controller);                 
if (PlayerController != None
&& PlayerController.Player != None
&& PlayerController.Player.GUIDesktop != None) {
PlayerController.Player.GUIDesktop.AddScreenMessage(Class'StringReferences'.default.Loot_Item_Rejected.Text);
switch (aReason) {                                                        
case 0 :                                                                
PlayerController.Player.GUIDesktop.AddScreenMessage(Class'StringReferences'.default.Loot_Item_Already_Taken.Text);
break;                                                                
case 1 :                                                                
PlayerController.Player.GUIDesktop.AddScreenMessage(Class'StringReferences'.default.Inventory_Full.Text);
break;                                                                
default:                                                                
break;                                                                
}
}
}
final event cl_UpdateGUI(optional byte aLootMode) {
local Game_PlayerController PlayerController;
PlayerController = Game_PlayerController(Outer.Controller);                 
if (PlayerController != None && PlayerController.GUI != None) {             
switch (aLootMode) {                                                      
case Class'Loot_Transaction'.1 :                                        
PlayerController.GUI.UpdateGroupLoot();                               
break;                                                                
case Class'Loot_Transaction'.2 :                                        
PlayerController.GUI.UpdateMasterLoot();                              
break;                                                                
case Class'Loot_Transaction'.0 :                                        
default:                                                                
PlayerController.GUI.UpdateSingleLoot();                              
break;                                                                
}
}
}
function float cl_GetTransactionTimer(int aTransactionID) {
local int Index;
Index = cl_GetTransaction(aTransactionID);                                  
if (Index != -1) {                                                          
return ClientLoot[Index].Timer;                                           
}
return -1.00000000;                                                         
}
protected final native function int cl_GetTransaction(int aTransactionID);
final native function cl_EndLootingForTransactions(array<int> aTransactionIDs);
native function cl_OnFrame(float aDeltaSeconds);
protected native function sv2cl_ChangeLootMode_CallStub();
final native event sv2cl_ChangeLootMode(int aTransactionID,float aTimerValue,byte aLootMode,byte aBeforeLootMode);
protected native function sv2cl_LootItemRejected_CallStub();
final native event sv2cl_LootItemRejected(int aTransactionID,int aLootItemID,int aReason);
protected native function sv2cl_RemoveItem_CallStub();
final native event sv2cl_RemoveItem(int aTransactionID,int aLootItemID);
protected native function sv2cl_EndTransaction_CallStub();
final native event sv2cl_EndTransaction(int aTransactionID);
protected native function sv2cl_InitLootOffer_CallStub();
final native event sv2cl_InitLootOffer(int aTransactionID,float aTimerValue,byte aLootMode,array<ReplicatedLootItem> aLootItems,array<int> aEligibleMembers);
*/