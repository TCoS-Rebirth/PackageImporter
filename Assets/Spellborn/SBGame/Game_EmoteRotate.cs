using System;

namespace SBGame
{
    [Serializable] public class Game_EmoteRotate : Game_Emote
    {
        public int Yaw;

        public Game_EmoteRotate()
        {
        }
    }
}
/*
function OnClientExecute(Game_Pawn aPawn) {
Super.OnClientExecute(aPawn);                                               
}
function OnServerExecute(Game_Pawn aPawn) {
local Rotator DesiredRotation;
DesiredRotation.Yaw = Yaw;                                                  
Super.OnServerExecute(aPawn);                                               
aPawn.SetRotation(DesiredRotation);                                         
if (aPawn.IsPlayerPawn()) {                                                 
aPawn.sv_TeleportTo(aPawn.Location,DesiredRotation);                      
} else {                                                                    
aPawn.sv_TeleportTo(aPawn.Location,DesiredRotation);                      
}
}
*/