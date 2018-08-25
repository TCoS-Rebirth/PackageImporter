using System;

namespace SBGame
{
    [Serializable] public class ViewMap_Pawn : Game_Pawn
    {
        public bool GhostMode;

        public bool GodMode;

        public ViewMap_Pawn()
        {
        }
    }
}
/*
function bool CheatGhost() {
UnderWaterTime = -1.00000000;                                               
SetCollision(False,False);                                                  
bCollideWorld = False;                                                      
return True;                                                                
}
function bool CheatWalk() {
UnderWaterTime = default.UnderWaterTime;                                    
SetCollision(True,True);                                                    
SetPhysics(1);                                                              
bCollideWorld = True;                                                       
return True;                                                                
}
exec function Ghost() {
if (GhostMode == False) {                                                   
GhostMode = True;                                                         
Controller.GotoState('PlayerFlying');                                     
CheatGhost();                                                             
} else {                                                                    
GhostMode = False;                                                        
Controller.GotoState('Walking');                                          
CheatWalk();                                                              
}
}
exec function God() {
if (GodMode) {                                                              
GodMode = False;                                                          
return;                                                                   
}
GodMode = True;                                                             
}
event bool CanJump() {
return False;                                                               
}
simulated exec function Walk() {
Controller.GotoState('PlayerWalking');                                      
}
simulated exec function Fly() {
Controller.GotoState('PlayerFlying');                                       
}
native exec function ViewMapEditAppearance();
native event SetCharacterStatsDefaults();
event cl_OnInit() {
Appearance.cl_OnInit();                                                     
Game_PlayerAppearance(Appearance.GetBase()).SetRandom(65535,65535,True,False);
SetCharacterStatsDefaults();                                                
}
*/