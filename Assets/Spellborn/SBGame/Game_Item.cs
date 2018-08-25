﻿using System;
using Engine;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Game_Item : UObject
    {
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int DBID;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Item_Type Type;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public byte Color1;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public byte Color2;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float UseTime;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int StackSize;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public byte Attuned;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int CharacterID;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public byte LocationType;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int LocationID;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int LocationSlot;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public byte TempLocationType;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int TempLocationID;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int TempLocationSlot;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Game_ItemManager itemManager;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int mTokens;

        public Game_Item()
        {
        }

        [Serializable] public struct ReplicatedItem
        {
            public int DBID;

            public int ItemTypeID;

            public int StackSize;

            public byte Color1;

            public byte Color2;
        }

        public enum EItemLocationType
        {
            ILT_Unknown,

            ILT_Inventory,

            ILT_Equipment,

            ILT_BodySlot,

            ILT_Item,

            ILT_Mail,

            ILT_Auction,

            ILT_Skill,

            ILT_Trade,

            ILT_BodySlotInventory,

            ILT_SendMail,

            ILT_ShopBuy,

            ILT_ShopSell,

            ILT_ShopPaint,

            ILT_ShopCrafting,
        }
    }
}
/*
function Material GetLogo(Game_Pawn aPawn,optional bool aDragLogo) {
local Material itemMaterial;
local Material typeMaterial;
local Appearance_Base typeAppearance;
local ConstantColor itemColor;
local Combiner itemCombiner01;
local Combiner itemCombiner02;
local Combiner cooldownCombiner;
local TexScaler cooldownScaler;
local TexScaler itemScaler;
if (Type != None) {                                                         
if (aDragLogo) {                                                          
typeMaterial = Type.GetDragLogo(aPawn);                                 
} else {                                                                  
typeMaterial = Type.GetLogo(aPawn);                                     
}
typeAppearance = Type.GetAppearance();                                    
if (typeMaterial != None && typeAppearance != None
&& (Type.ItemType == 16 || Type.ItemType == 17
|| Type.ItemType == 18
|| Type.ItemType == 19
|| Type.ItemType == 20
|| Type.ItemType == 21
|| Type.ItemType == 22
|| Type.ItemType == 23
|| Type.ItemType == 24
|| Type.ItemType == 34
|| Type.ItemType == 35
|| Type.ItemType == 25
|| Type.ItemType == 26
|| Type.ItemType == 27
|| Type.ItemType == 28
|| Type.ItemType == 29)
&& (typeAppearance.ColorMode == 1 || typeAppearance.ColorMode == 2)) {
itemColor = new Class'ConstantColor';                                   
if (typeAppearance.ColorMode == 2) {                                    
itemColor.Color = typeAppearance.Palette2.GetPalColorAtIndex(Color2); 
} else {                                                                
itemColor.Color = typeAppearance.Palette1.GetPalColorAtIndex(Color1); 
}
itemCombiner01 = new Class'Combiner';                                   
itemCombiner01.CombineOperation = 2;                                    
itemCombiner01.AlphaOperation = 0;                                      
itemCombiner01.Material1 = typeMaterial;                                
itemCombiner01.Material2 = itemColor;                                   
itemCombiner02 = new Class'Combiner';                                   
itemCombiner02.CombineOperation = 5;                                    
itemCombiner02.AlphaOperation = 0;                                      
itemCombiner02.Material1 = itemCombiner01;                              
itemCombiner02.Material2 = typeMaterial;                                
itemCombiner02.Mask = typeMaterial;                                     
itemCombiner02.InvertMask = True;                                       
itemMaterial = itemCombiner02;                                          
} else {                                                                  
itemMaterial = typeMaterial;                                            
}
if (Type.UseCooldown > 0 && !aDragLogo) {                                 
cooldownScaler = new Class'TexScaler';                                  
cooldownScaler.UScale = 8.00000000;                                     
cooldownScaler.VScale = 8.00000000;                                     
cooldownScaler.UOffset = 224.00000000;                                  
cooldownScaler.VOffset = 224.00000000;                                  
cooldownScaler.Material = Texture'BodyslotCooldown';                    
cooldownCombiner = new Class'Combiner';                                 
cooldownCombiner.Material1 = itemMaterial;                              
cooldownCombiner.Material2 = cooldownScaler;                            
cooldownCombiner.Mask = cooldownScaler;                                 
cooldownCombiner.CombineOperation = 5;                                  
cooldownCombiner.AlphaOperation = 0;                                    
itemScaler = new Class'TexScaler';                                      
itemScaler.UScale = 0.12500000;                                         
itemScaler.VScale = 0.12500000;                                         
itemScaler.UOffset = 0.00000000;                                        
itemScaler.VOffset = 0.00000000;                                        
itemScaler.Material = cooldownCombiner;                                 
return itemScaler;                                                      
}
return itemMaterial;                                                      
}
return None;                                                                
}
final native function bool CanRemoveSigils(out byte outErrorMessage,out int outRemovalCost);
final native function bool CanForgeSigil(Game_Item aTokenItem,int aLocationSlot,out byte outErrorMessage,out int outForgeCost,out int outSlotTaken);
final native function int GetSigilsRemovalCost();
final native function AddToken(Game_Item aTokenItem,int aLocationSlot);
final native function sv_StopTokens();
final native event sv_StartTokens();
final native function int GetTokenCount();
final native function int GetTokenSlotCount();
final native function Game_Item GetToken(int aLocationSlot);
final native event int GetBreakdownValue();
final native event int GetSellValue();
event OnUnequip() {
if (Type != None) {                                                         
Type.OnUnequip(GetPawn(),self);                                           
}
}
event OnEquip() {
local Game_Pawn Pawn;
if (Type != None) {                                                         
Pawn = GetPawn();                                                         
Type.OnEquip(Pawn,self);                                                  
}
}
event OnItemUsed() {
UseTime = GetPawn().Level.TimeSeconds;                                      
if (GetPawn().SBRole == 1
&& Game_PlayerItemManager(itemManager) != None) {
Game_PlayerItemManager(itemManager).sv2cl_UsedItem_CallStub(DBID);        
}
}
event OnUse() {
local Game_Pawn Pawn;
if (Type != None) {                                                         
if (Type.ItemType == 37) {                                                
if (itemManager != None) {                                              
Game_PlayerItemManager(itemManager).sv_UseItem(self);                 
}
} else {                                                                  
Pawn = GetPawn();                                                       
if (Pawn != None) {                                                     
Type.OnUse(Pawn,self);                                                
}
}
}
}
event bool CanEquip() {
if (Type != None) {                                                         
return Type.CanEquip(GetPawn(),self);                                     
}
return False;                                                               
}
event bool CanUse() {
if (UseTime > 0
&& UseTime + Type.UseCooldown > GetPawn().Level.TimeSeconds) {
return False;                                                             
}
if (Type != None) {                                                         
return Type.sv_CanUse(GetPawn(),self);                                    
}
return False;                                                               
}
final native function ReplicatedItem GetReplicated();
final native function Game_Pawn GetItemManager();
final native function Game_Pawn GetPawn();
*/