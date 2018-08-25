﻿using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class IC_TokenSlot : Item_Component
    {
        [FoldoutGroup("TokenSlot")]
        [FieldConst()]
        public List<TokenSlot> slots = new List<TokenSlot>();

        public IC_TokenSlot()
        {
        }

        [Serializable] public struct TokenSlot
        {
            public int rank;

            public byte SlotType;
        }

        public enum ESigilSlotType
        {
            SST_None,

            SST_Weapon_1,

            SST_Weapon_2,

            SST_Weapon_3,

            SST_Weapon_PVP,

            SST_Weapon_Ranged,

            SST_Armor_1,

            SST_Armor_2,

            SST_Armor_3,

            SST_Jewelry_Exclusive,
        }
    }
}
/*
static event string GetSlotTypeBackground(byte aSlotType) {
switch (aSlotType) {                                                        
case 1 :                                                                  
return "Weapon_1_Slot";                                                 
case 2 :                                                                  
return "Weapon_2_Slot";                                                 
case 3 :                                                                  
return "Weapon_3_Slot";                                                 
case 4 :                                                                  
return "Weapon_3_Slot";                                                 
case 5 :                                                                  
return "Weapon_Ranged_Slot";                                            
case 6 :                                                                  
return "Armor_1_Slot";                                                  
case 7 :                                                                  
return "Armor_2_Slot";                                                  
case 8 :                                                                  
return "Armor_3_Slot";                                                  
case 9 :                                                                  
return "Jewelry_Exlusive_Slot";                                         
default:                                                                  
return "";                                                              
}
}
}
event OnUnequip(Game_Pawn aPawn,Game_Item aItem) {
if (aItem != None && IsServer()) {                                          
aItem.sv_StopTokens();                                                    
}
}
event OnEquip(Game_Pawn aPawn,Game_Item aItem) {
if (aItem != None && IsServer()) {                                          
aItem.sv_StartTokens();                                                   
}
}
*/