﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------



namespace SBGame
{


    public class Game_NPCItemManager : Game_ItemManager
    {
        
        public Game_NPCItemManager()
        {
        }
    }
}
/*
final native function InitializeSingleItem(export editinline Item_Type aItem,byte aColor1,byte aColor2);
final native function InitializeArray(array<Item_Type> aItems,byte aClothColor1,byte aClothColor2,byte aArmorColor1,byte aArmorColor2);
function cl_OnInit() {
local Game_NPCPawn NPC;
Super.cl_OnInit();                                                          
NPC = Game_NPCPawn(Outer);                                                  
if (NPC != None && NPC.NPCType.Equipment != None) {                         
NPC.NPCType.Equipment.Apply(Outer);                                       
}
}
*/
