﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------



namespace SBGamePlay
{


    public class NE_SlotsFullColor : NE_SlotsBase
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Equipment")]
        public NE_ItemColor W01_MeleeWeaponColor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Equipment")]
        public NE_ItemColor W02_RangedWeaponColor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Equipment")]
        public NE_ItemColor W03_ShieldColor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Equipment")]
        public NE_ItemColor C01_ChestColor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Equipment")]
        public NE_ItemColor C02_LeftGloveColor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Equipment")]
        public NE_ItemColor C03_RightGloveColor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Equipment")]
        public NE_ItemColor C04_PantsColor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Equipment")]
        public NE_ItemColor C05_ShoesColor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Equipment")]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public NE_ItemColor C_AllClothing;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Equipment")]
        public NE_ItemColor A01_HelmetColor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Equipment")]
        public NE_ItemColor A02_RightShoulderColor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Equipment")]
        public NE_ItemColor A03_LeftShoulderColor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Equipment")]
        public NE_ItemColor A04_RightGauntletColor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Equipment")]
        public NE_ItemColor A05_LeftGauntletColor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Equipment")]
        public NE_ItemColor A06_ChestArmourColor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Equipment")]
        public NE_ItemColor A07_BeltColor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Equipment")]
        public NE_ItemColor A08_LeftThighColor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Equipment")]
        public NE_ItemColor A09_RightThighColor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Equipment")]
        public NE_ItemColor A10_LeftShinColor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Equipment")]
        public NE_ItemColor A11_RightShinColor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Equipment")]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public NE_ItemColor A_AllArmour;
        
        public NE_SlotsFullColor()
        {
        }
    }
}
/*
function Apply(Game_Pawn aPawn) {
local export editinline Game_NPCItemManager itemManager;
itemManager = Game_NPCItemManager(aPawn.itemManager);                       
if (itemManager != None) {                                                  
itemManager.InitializeSingleItem(W01_MeleeWeapon,W01_MeleeWeaponColor.Color1,W01_MeleeWeaponColor.Color2);
itemManager.InitializeSingleItem(W02_RangedWeapon,W02_RangedWeaponColor.Color1,W02_RangedWeaponColor.Color2);
itemManager.InitializeSingleItem(W03_Shield,W03_ShieldColor.Color1,W03_ShieldColor.Color2);
itemManager.InitializeSingleItem(C01_Chest,C01_ChestColor.Color1,C01_ChestColor.Color2);
itemManager.InitializeSingleItem(C02_LeftGlove,C02_LeftGloveColor.Color1,C02_LeftGloveColor.Color2);
itemManager.InitializeSingleItem(C03_RightGlove,C03_RightGloveColor.Color1,C03_RightGloveColor.Color2);
itemManager.InitializeSingleItem(C04_Pants,C04_PantsColor.Color1,C04_PantsColor.Color2);
itemManager.InitializeSingleItem(C05_Shoes,C05_ShoesColor.Color1,C05_ShoesColor.Color2);
itemManager.InitializeSingleItem(A01_Helmet,A01_HelmetColor.Color1,A01_HelmetColor.Color2);
itemManager.InitializeSingleItem(A02_RightShoulder,A02_RightShoulderColor.Color1,A02_RightShoulderColor.Color2);
itemManager.InitializeSingleItem(A03_LeftShoulder,A03_LeftShoulderColor.Color1,A03_LeftShoulderColor.Color2);
itemManager.InitializeSingleItem(A04_RightGauntlet,A04_RightGauntletColor.Color1,A04_RightGauntletColor.Color2);
itemManager.InitializeSingleItem(A05_LeftGauntlet,A05_LeftGauntletColor.Color1,A05_LeftGauntletColor.Color2);
itemManager.InitializeSingleItem(A06_ChestArmour,A06_ChestArmourColor.Color1,A06_ChestArmourColor.Color2);
itemManager.InitializeSingleItem(A07_Belt,A07_BeltColor.Color1,A07_BeltColor.Color2);
itemManager.InitializeSingleItem(A08_LeftThigh,A08_LeftThighColor.Color1,A08_LeftThighColor.Color2);
itemManager.InitializeSingleItem(A09_RightThigh,A09_RightThighColor.Color1,A09_RightThighColor.Color2);
itemManager.InitializeSingleItem(A10_LeftShin,A10_LeftShinColor.Color1,A10_LeftShinColor.Color2);
itemManager.InitializeSingleItem(A11_RightShin,A11_RightShinColor.Color1,A11_RightShinColor.Color2);
itemManager.InitializeSingleItem(J01_LeftRing,0,0);                       
itemManager.InitializeSingleItem(J02_RightRing,0,0);                      
itemManager.InitializeSingleItem(J03_Necklace,0,0);                       
}
}
*/
