using System;

namespace SBGame
{
    [Serializable]
    public class Game_NPCController: Game_Controller
    {
        public NPC_Type NPCType;

        public bool bDespawned;

        public bool BreakAI;

        public override void WriteLoginStream(IPacketWriter packetWriter)
        {
            throw new NotImplementedException();
        }

        public Game_NPCPawn GetNPCPawn()
        {
            return Pawn as Game_NPCPawn;
        }

        public void sv_OnSpawn(int aFameLevel, int aPePRank, NPC_Taxonomy aFaction) { throw new NotImplementedException(); }

        public LootTable sv_GetLootTable()
        {
            return null;
        }

        public void sv_Despawn() { throw new NotImplementedException(); }
    }
}
/*
function sv_InitInternal();
*/
