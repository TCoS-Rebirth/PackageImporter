using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Interaction_Loot : Interaction_Component
    {
        [FoldoutGroup("Interaction_Loot")]
        public LootTable AcquireItem;

        [FoldoutGroup("Interaction_Loot")]
        public float LootTimerLimit;

        public Interaction_Loot()
        {
        }
    }
}
/*
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local array<LootTable> lootTableList;
local array<Game_Pawn> receivers;
local Loot_Manager lootManager;
Super.SvOnStart(aOwner,aInstigator);                                        
if (aOwner != None && AcquireItem != None) {                                
if (!aReverse) {                                                          
lootManager = Class'Loot_Manager'.static.sv_GetInstance();              
if (lootManager != None) {                                              
lootTableList.Length = 1;                                             
lootTableList[0] = AcquireItem;                                       
receivers.Length = 1;                                                 
receivers[0] = aInstigator;                                           
lootManager.sv_CreateTransaction(lootTableList,receivers,LootTimerLimit);
}
}
}
}
*/