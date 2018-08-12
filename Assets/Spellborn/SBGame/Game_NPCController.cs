using System;

namespace SBGame
{
    [Serializable] public class Game_NPCController : Game_Controller
    {
        public NPC_Type NPCType;

        public bool bDespawned;

        public bool BreakAI;

        public Game_NPCController()
        {
        }
    }
}
/*
function sv_InitInternal();
function Game_NPCPawn GetNPCPawn() {
return Game_NPCPawn(Pawn);                                                  
}
function LootTable sv_GetLootTable() {
return None;                                                                
}
final native function sv_Despawn();
native function sv_OnSpawn(int aFameLevel,int aPePRank,export editinline NPC_Taxonomy aFaction);
*/