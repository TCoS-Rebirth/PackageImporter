﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Engine;
using SBAI;
using SBAIScripts;
using SBBase;
using SBGame;
using SBGamePlay;
using SBMiniGames;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SBAI
{
    
    
    public class Game_PetController : Game_AIController
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
