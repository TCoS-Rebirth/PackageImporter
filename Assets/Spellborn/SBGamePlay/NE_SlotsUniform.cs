using System;

namespace SBGamePlay
{
    [Serializable] public class NE_SlotsUniform : NE_SlotsBase
    {
        public NE_SlotsUniform()
        {
        }
    }
}
/*
function Apply(Game_Pawn aPawn) {
local export editinline Game_NPCItemManager itemManager;
local export editinline NPC_Taxonomy Faction;
local int ClothColor1;
local int ClothColor2;
local int ArmorColor1;
local int ArmorColor2;
ClothColor1 = 0;                                                            
ClothColor2 = 0;                                                            
ArmorColor1 = 0;                                                            
ArmorColor2 = 0;                                                            
Faction = aPawn.Character.GetFaction();                                     
if (Faction != None) {                                                      
ClothColor1 = Faction.GetClothColor1();                                   
ClothColor2 = Faction.GetClothColor2();                                   
ArmorColor1 = Faction.GetArmorColor1();                                   
ArmorColor2 = Faction.GetArmorColor2();                                   
}
itemManager = Game_NPCItemManager(aPawn.itemManager);                       
if (itemManager != None) {                                                  
itemManager.InitializeSingleItem(W01_MeleeWeapon,-1,-1);                  
itemManager.InitializeSingleItem(W02_RangedWeapon,-1,-1);                 
itemManager.InitializeSingleItem(W03_Shield,-1,-1);                       
itemManager.InitializeSingleItem(C01_Chest,ClothColor1,ClothColor2);      
itemManager.InitializeSingleItem(C02_LeftGlove,ClothColor1,ClothColor2);  
itemManager.InitializeSingleItem(C03_RightGlove,ClothColor1,ClothColor2); 
itemManager.InitializeSingleItem(C04_Pants,ClothColor1,ClothColor2);      
itemManager.InitializeSingleItem(C05_Shoes,ClothColor1,ClothColor2);      
itemManager.InitializeSingleItem(A01_Helmet,ArmorColor1,ArmorColor2);     
itemManager.InitializeSingleItem(A02_RightShoulder,ArmorColor1,ArmorColor2);
itemManager.InitializeSingleItem(A03_LeftShoulder,ArmorColor1,ArmorColor2);
itemManager.InitializeSingleItem(A04_RightGauntlet,ArmorColor1,ArmorColor2);
itemManager.InitializeSingleItem(A05_LeftGauntlet,ArmorColor1,ArmorColor2);
itemManager.InitializeSingleItem(A06_ChestArmour,ArmorColor1,ArmorColor2);
itemManager.InitializeSingleItem(A07_Belt,ArmorColor1,ArmorColor2);       
itemManager.InitializeSingleItem(A08_LeftThigh,ArmorColor1,ArmorColor2);  
itemManager.InitializeSingleItem(A09_RightThigh,ArmorColor1,ArmorColor2); 
itemManager.InitializeSingleItem(A10_LeftShin,ArmorColor1,ArmorColor2);   
itemManager.InitializeSingleItem(A11_RightShin,ArmorColor1,ArmorColor2);  
itemManager.InitializeSingleItem(J01_LeftRing,-1,-1);                     
itemManager.InitializeSingleItem(J02_RightRing,-1,-1);                    
itemManager.InitializeSingleItem(J03_Necklace,-1,-1);                     
}
}
*/