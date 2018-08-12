using System;
using SBGame;

namespace SBAI
{
    [Serializable] public class Game_PetController : Game_AIController
    {
        public Game_Pawn PetOwner;

        public Game_Pawn PetMaster;

        public Game_Pawn PetTarget;

        public float OwnerDistance;

        public Game_PetController()
        {
        }
    }
}
/*
native function sv_PetCallBack();
native function sv_PetAttack(Game_Pawn Target);
native function byte sv_GetPetAttackState();
native function byte sv_GetPetMoveState();
native function sv_SetPetAttackState(byte aAttackState);
native function sv_SetPetMoveState(byte aMoveState);
function sv_SetPetOwner(Game_Pawn aOwner) {
PetOwner = aOwner;                                                          
}
*/