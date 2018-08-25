﻿using System;
using System.Collections.Generic;
using Engine;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Item_TypeFilter : UObject
    {
        public bool mAllowFilterItems;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<byte> mFilterList = new List<byte>();

        public Item_TypeFilter()
        {
        }

        public enum ItemFilterGroup
        {
            IFG_ALL_WEAPONS,

            IFG_ARMOUR_UPPER_BODY,

            IFG_ARMOUR_LOWER_BODY,

            IFG_ALL_ARMOUR,

            IFG_CLOTHES_UPPER_BODY,

            IFG_CLOTHES_LOWER_BODY,

            IFG_ALL_CLOTHES,
        }
    }
}
/*
private function int GetFilterIndex(byte aTestItemType) {
local int i;
i = 0;                                                                      
while (i < mFilterList.Length) {                                            
if (mFilterList[i] == aTestItemType) {                                    
return i;                                                               
}
++i;                                                                      
}
return -1;                                                                  
}
event bool IsAllowedItemType(byte aTestItemType) {
local int foundIndex;
foundIndex = GetFilterIndex(aTestItemType);                                 
if (mAllowFilterItems) {                                                    
return foundIndex != -1;                                                  
}
return foundIndex == -1;                                                    
}
function RemoveFilterGroup(byte aGroupType) {
local array<byte> helper;
local int i;
GetFilterGroupTypes(aGroupType,helper);                                     
i = 0;                                                                      
while (i < helper.Length) {                                                 
ClearItemTypeFilter(helper[i]);                                           
++i;                                                                      
}
}
function AddFilterGroup(byte aGroupType) {
local array<byte> helper;
local int i;
GetFilterGroupTypes(aGroupType,helper);                                     
i = 0;                                                                      
while (i < helper.Length) {                                                 
AddItemTypeFilter(helper[i]);                                             
++i;                                                                      
}
}
protected function GetFilterGroupTypes(byte aGroupType,out array<byte> aResults) {
local int oldLength;
switch (aGroupType) {                                                       
case 0 :                                                                  
oldLength = aResults.Length;                                            
aResults.Length = oldLength + 5;                                        
aResults[oldLength + 0] = Class'Item_Type'.11;                          
aResults[oldLength + 1] = Class'Item_Type'.12;                          
aResults[oldLength + 2] = Class'Item_Type'.13;                          
aResults[oldLength + 3] = Class'Item_Type'.14;                          
aResults[oldLength + 4] = Class'Item_Type'.15;                          
break;                                                                  
case 1 :                                                                  
oldLength = aResults.Length;                                            
aResults.Length = oldLength + 7;                                        
aResults[oldLength + 0] = Class'Item_Type'.16;                          
aResults[oldLength + 1] = Class'Item_Type'.17;                          
aResults[oldLength + 2] = Class'Item_Type'.18;                          
aResults[oldLength + 3] = Class'Item_Type'.19;                          
aResults[oldLength + 4] = Class'Item_Type'.20;                          
aResults[oldLength + 5] = Class'Item_Type'.21;                          
aResults[oldLength + 6] = Class'Item_Type'.22;                          
break;                                                                  
case 2 :                                                                  
oldLength = aResults.Length;                                            
aResults.Length = oldLength + 4;                                        
aResults[oldLength + 0] = Class'Item_Type'.23;                          
aResults[oldLength + 1] = Class'Item_Type'.24;                          
aResults[oldLength + 2] = Class'Item_Type'.34;                          
aResults[oldLength + 3] = Class'Item_Type'.35;                          
break;                                                                  
case 3 :                                                                  
GetFilterGroupTypes(1,aResults);                                        
GetFilterGroupTypes(2,aResults);                                        
break;                                                                  
case 4 :                                                                  
oldLength = aResults.Length;                                            
aResults.Length = oldLength + 3;                                        
aResults[oldLength + 0] = Class'Item_Type'.25;                          
aResults[oldLength + 1] = Class'Item_Type'.26;                          
aResults[oldLength + 2] = Class'Item_Type'.27;                          
break;                                                                  
case 5 :                                                                  
oldLength = aResults.Length;                                            
aResults.Length = oldLength + 2;                                        
aResults[oldLength + 0] = Class'Item_Type'.28;                          
aResults[oldLength + 1] = Class'Item_Type'.29;                          
break;                                                                  
case 6 :                                                                  
GetFilterGroupTypes(4,aResults);                                        
GetFilterGroupTypes(5,aResults);                                        
break;                                                                  
default:                                                                  
break;                                                                  
}
}
function bool ItemTypePresent(byte aTestItemType) {
return GetFilterIndex(aTestItemType) != -1;                                 
}
function int GetNumberOfFilters() {
return mFilterList.Length;                                                  
}
function ResetFilters() {
mFilterList.Length = 0;                                                     
}
function SetItemTypeFilters(array<byte> aItemTypeFilters) {
local int i;
mFilterList.Length = aItemTypeFilters.Length;                               
i = 0;                                                                      
while (i < aItemTypeFilters.Length) {                                       
mFilterList[i] = aItemTypeFilters[i];                                     
++i;                                                                      
}
}
function ClearItemTypeFilter(byte aItemTypeToClear) {
local int i;
i = GetFilterIndex(aItemTypeToClear);                                       
if (i != -1) {                                                              
mFilterList.Remove(i,1);                                                  
}
}
function AddItemTypeFilter(byte aNewItemType) {
local int i;
local int currentLength;
i = GetFilterIndex(aNewItemType);                                           
if (i == -1) {                                                              
currentLength = mFilterList.Length;                                       
mFilterList.Length = currentLength + 1;                                   
mFilterList[currentLength] = aNewItemType;                                
}
}
function SetFilterMode(bool aAllowFilterItems) {
mAllowFilterItems = aAllowFilterItems;                                      
}
*/