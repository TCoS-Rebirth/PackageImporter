using System;
using SBBase;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class SBWorldPortal : SBBasePortal
    {
        void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "Portal.psd", true);
        }
    }
}
/*
function Touch(Actor Other) {
local Game_PlayerController PlayerController;
local Game_PlayerPawn playerPawn;
local Game_GameServer Engine;
Super.Touch(Other);                                                         
Engine = Game_GameServer(Class'Actor'.static.GetGameEngine());              
if (Engine != None && NavigationTag != "") {                                
playerPawn = Game_PlayerPawn(Other);                                      
if (playerPawn != None) {                                                 
PlayerController = Game_PlayerController(playerPawn.Controller);        
if (PlayerController != None) {                                         
if (playerPawn.sv_IsPayingPlayer() == False
&& IsFreeToPlayAllowed(Engine.GetPortalDestinationWorldID(self)) == False) {
playerPawn.sv2cl_FreeToPlayPortalForbidden_CallStub();              
return;                                                             
}
Engine.LoginToWorldByPortal(self,PlayerController.CharacterID);       
}
}
}
}
final native function bool IsFreeToPlayAllowed(int worldID);
*/