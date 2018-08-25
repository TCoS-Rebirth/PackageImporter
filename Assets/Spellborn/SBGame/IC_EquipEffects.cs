using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class IC_EquipEffects : Item_Component
    {
        [FoldoutGroup("OnEquip")]
        [FieldConst()]
        public FSkill_Event_Duff EquipDuffEvent;

        [FoldoutGroup("OnEquip")]
        public byte EquipTattooSet;

        [FoldoutGroup("OnEquip")]
        public byte EquipTattooBodyPart;

        public IC_EquipEffects()
        {
        }

        public enum EEquipTattooBodyPart
        {
            ETBP_Torso,

            ETBP_LeftArm,

            ETBP_RightArm,

            ETBP_Head,
        }

        public enum EEquipTattooSet
        {
            ETS_None,

            ETS_BloodWarrior1,

            ETS_BloodWarrior2,

            ETS_BloodWarrior3,

            ETS_BloodWarrior4,

            ETS_RuneMage1,

            ETS_RuneMage2,

            ETS_RuneMage3,

            ETS_RuneMage4,
        }
    }
}
/*
private function UpdateClassTattoo(Game_Pawn aPawn,optional Game_Item aIgnoreItem) {
local int i;
local int newTattooSet;
local export editinline IC_EquipEffects otherEquipEffects;
local export editinline Game_EquippedAppearance Appearance;
local Game_Item Item;
local export editinline Game_ItemManager itemManager;
local array<Game_Item> tattooItems;
if (aPawn.Appearance != None) {                                             
Appearance = Game_EquippedAppearance(aPawn.Appearance.GetBase());         
if (Appearance != None) {                                                 
newTattooSet = 0;                                                       
itemManager = aPawn.itemManager;                                        
if (itemManager != None) {                                              
tattooItems = itemManager.GetItems(3);                                
i = 0;                                                                
while (i < tattooItems.Length) {                                      
Item = tattooItems[i];                                              
if (Item != None && Item != aIgnoreItem) {                          
otherEquipEffects = Item.Type.GetEquipEffectsTokenComponent();    
if (otherEquipEffects != None) {                                  
if (otherEquipEffects.EquipTattooSet != 0
&& otherEquipEffects.EquipTattooBodyPart == EquipTattooBodyPart) {
newTattooSet = otherEquipEffects.EquipTattooSet;              
goto jl0146;                                                  
}
}
}
++i;                                                                
}
}
Appearance.SetValue(24,newTattooSet,EquipTattooBodyPart);               
Appearance.Apply();                                                     
}
}
}
event OnUnequip(Game_Pawn aPawn,Game_Item aItem) {
if (IsServer() && EquipDuffEvent != None) {                                 
if (aPawn.Skills != None) {                                               
aPawn.Skills.sv_RemoveSpecialDuffEvent(EquipDuffEvent);                 
}
}
if (EquipTattooSet != 0) {                                                  
UpdateClassTattoo(aPawn,aItem);                                           
}
}
event OnEquip(Game_Pawn aPawn,Game_Item aItem) {
if (IsServer() && EquipDuffEvent != None) {                                 
EquipDuffEvent.RunUntilAbort = True;                                      
if (aPawn.Skills != None) {                                               
aPawn.Skills.sv_AddSpecialDuffEvent(EquipDuffEvent);                    
}
}
if (EquipTattooSet != 0) {                                                  
UpdateClassTattoo(aPawn);                                                 
}
}
*/