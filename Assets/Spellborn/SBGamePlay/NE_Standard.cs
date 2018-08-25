using System;
using System.Collections.Generic;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class NE_Standard : NPC_Equipment
    {
        [FoldoutGroup("Equipment")]
        public List<Item_Type> Items = new List<Item_Type>();

        [FoldoutGroup("Equipment")]
        public byte Color1;

        [FoldoutGroup("Equipment")]
        public byte Color2;

        public NE_Standard()
        {
        }
    }
}
/*
function Apply(Game_Pawn aPawn) {
local export editinline Game_NPCItemManager itemManager;
itemManager = Game_NPCItemManager(aPawn.itemManager);                       
if (itemManager != None) {                                                  
itemManager.InitializeArray(Items,Color1,Color2,Color1,Color2);           
}
}
*/