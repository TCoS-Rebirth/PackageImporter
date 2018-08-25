﻿using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Shop_Base : UObject
    {
        [FoldoutGroup("Shop_Base")]
        [FieldConst()]
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();

        [FoldoutGroup("Shop_Base")]
        [FieldConst()]
        public List<byte> ShopOptions = new List<byte>();

        [FoldoutGroup("Shop_Base")]
        public List<LootTable> Stock = new List<LootTable>();

        [FoldoutGroup("Shop_Base")]
        public List<byte> BuyList = new List<byte>();

        [FoldoutGroup("Shop_Base")]
        public string ShopName = string.Empty;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<Game_Item> mStockItems = new List<Game_Item>();

        public Shop_Base()
        {
        }
    }
}
/*
native function bool HasItemInStock(int aItemTypeID,int aAmount);
function bool IsValidRecipeItem(Game_Item aItem,byte aShopOption,export out editinline IC_Recipe aOutRecipeComponent) {
local export editinline IC_Recipe recipeComp;
local export editinline IC_BodySlot bodyslotComp;
if (aItem == None || aItem.Type.ItemType != 33) {                           
return False;                                                             
}
recipeComp = IC_Recipe(aItem.Type.GetComponentByClass(Class'IC_Recipe'));   
if (recipeComp == None
|| recipeComp.ProducedItem == None) {          
return False;                                                             
}
aOutRecipeComponent = recipeComp;                                           
switch (aShopOption) {                                                      
case 32 :                                                                 
return True;                                                            
case 31 :                                                                 
return recipeComp.ProducedItem.ItemType == 37;                          
case 27 :                                                                 
switch (recipeComp.ProducedItem.ItemType) {                             
case 11 :                                                             
case 12 :                                                             
case 13 :                                                             
case 14 :                                                             
case 15 :                                                             
case 16 :                                                             
case 17 :                                                             
case 18 :                                                             
case 19 :                                                             
case 20 :                                                             
case 21 :                                                             
case 22 :                                                             
case 23 :                                                             
case 24 :                                                             
case 34 :                                                             
case 35 :                                                             
case 25 :                                                             
case 26 :                                                             
case 27 :                                                             
case 28 :                                                             
case 29 :                                                             
case 1 :                                                              
case 2 :                                                              
return True;                                                        
default:                                                              
return False;                                                       
case 34 :                                                             
switch (recipeComp.ProducedItem.ItemType) {                         
case 36 :                                                         
case 5 :                                                          
return True;                                                    
default:                                                          
return False;                                                   
default:                                                          
if (recipeComp.ProducedItem.ItemType == 0) {                    
bodyslotComp = IC_BodySlot(recipeComp.ProducedItem.GetComponentByClass(Class'IC_BodySlot'));
if (bodyslotComp == None) {                                   
return False;                                               
}
switch (aShopOption) {                                        
case 28 :                                                   
return bodyslotComp.Type == 1;                            
case 29 :                                                   
return bodyslotComp.Type == 2;                            
case 30 :                                                   
return bodyslotComp.Type == 0;                            
default:                                                    
}
return False;                                                 
}
}
}
}
}
}
}
}
function bool CanBuyItem(byte aItemType) {
local int i;
if (BuyList.Length == 0) {                                                  
return True;                                                              
}
i = 0;                                                                      
while (i < BuyList.Length) {                                                
if (BuyList[i] == aItemType) {                                            
return True;                                                            
}
++i;                                                                      
}
return False;                                                               
}
native function array<Game_Item> GetItems();
function bool CanEnterShop(Game_PlayerPawn aPlayerPawn,byte aSubOption) {
local int i;
i = 0;                                                                      
while (i < Requirements.Length) {                                           
if (Requirements[i] != None
&& !Requirements[i].CheckPawn(aPlayerPawn)) {
return False;                                                           
}
i++;                                                                      
}
i = 0;                                                                      
while (i < ShopOptions.Length) {                                            
if (ShopOptions[i] == aSubOption) {                                       
return True;                                                            
}
++i;                                                                      
}
return False;                                                               
}
function sv_EnterShop(Game_PlayerPawn aPlayerPawn,byte aOption) {
if (aPlayerPawn != None && aPlayerPawn.Trading != None
&& CanEnterShop(aPlayerPawn,aOption)) {
aPlayerPawn.Trading.sv_EnterShop(self,aOption);                           
}
}
event RadialMenuCollect(Pawn aPlayerPawn,byte aMainOption,out array<byte> aSubOptions) {
local int i;
local int Count;
i = 0;                                                                      
while (i < Requirements.Length) {                                           
if (Requirements[i] != None
&& !Requirements[i].CheckPawn(Game_PlayerPawn(aPlayerPawn))) {
return;                                                                 
}
i++;                                                                      
}
Count = aSubOptions.Length;                                                 
aSubOptions.Length = Count + ShopOptions.Length;                            
i = 0;                                                                      
while (i < ShopOptions.Length) {                                            
aSubOptions[Count + i] = ShopOptions[i];                                  
++i;                                                                      
}
}
*/