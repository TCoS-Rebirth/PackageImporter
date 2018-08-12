using System;

namespace SBGame
{
    [Serializable] public class Game_NPCItemManager : Game_ItemManager
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