using System;

namespace SBGame
{
    [Serializable] public class Game_EditorPawn : Game_Pawn
    {
        public byte OverwriteEquippedWeaponFlag;

        public Game_EditorPawn()
        {
        }
    }
}
/*
event byte GetEquippedWeaponFlag() {
return OverwriteEquippedWeaponFlag;                                         
}
event cl_OnFrame(float DeltaTime) {
local array<int> animFlags;
Super.cl_OnFrame(DeltaTime);                                                
if (!IsAnimating(0)) {                                                      
animFlags.Length = 2;                                                     
animFlags[0] = Class'SBAnimationFlags'.9;                                 
animFlags[1] = Class'SBAnimationFlags'.33;                                
QueueAnimation(animFlags,0,1.00000000,0.00000000,0.00000000,False);       
PlayQueuedAnimations(True,False);                                         
}
}
event cl_OnShutdown() {
}
event cl_OnInit() {
Character.cl_OnInit();                                                      
}
*/