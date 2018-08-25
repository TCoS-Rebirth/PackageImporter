﻿using System;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class NE_Slots : NE_SlotsBase
    {
        [FoldoutGroup("Equipment")]
        public byte ClothColor1;

        [FoldoutGroup("Equipment")]
        public byte ClothColor2;

        [FoldoutGroup("Equipment")]
        public byte ArmorColor1;

        [FoldoutGroup("Equipment")]
        public byte ArmorColor2;

        public NE_Slots()
        {
        }
    }
}
/*
function Apply(Game_Pawn aPawn) {
local export editinline Game_NPCItemManager itemManager;
local array<Item_Type> Items;
itemManager = Game_NPCItemManager(aPawn.itemManager);                       
if (itemManager != None) {                                                  
PutItem(W01_MeleeWeapon,Items);                                           
PutItem(W02_RangedWeapon,Items);                                          
PutItem(W03_Shield,Items);                                                
PutItem(C01_Chest,Items);                                                 
PutItem(C02_LeftGlove,Items);                                             
PutItem(C03_RightGlove,Items);                                            
PutItem(C04_Pants,Items);                                                 
PutItem(C05_Shoes,Items);                                                 
PutItem(A01_Helmet,Items);                                                
PutItem(A02_RightShoulder,Items);                                         
PutItem(A03_LeftShoulder,Items);                                          
PutItem(A04_RightGauntlet,Items);                                         
PutItem(A05_LeftGauntlet,Items);                                          
PutItem(A06_ChestArmour,Items);                                           
PutItem(A07_Belt,Items);                                                  
PutItem(A08_LeftThigh,Items);                                             
PutItem(A09_RightThigh,Items);                                            
PutItem(A10_LeftShin,Items);                                              
PutItem(A11_RightShin,Items);                                             
PutItem(J01_LeftRing,Items);                                              
PutItem(J02_RightRing,Items);                                             
PutItem(J03_Necklace,Items);                                              
itemManager.InitializeArray(Items,ClothColor1,ClothColor2,ArmorColor1,ArmorColor2);
}
}
protected function PutItem(export editinline Item_Type aItem,out array<Item_Type> oItems) {
if (aItem != None) {                                                        
oItems[oItems.Length] = aItem;                                            
}
}
*/