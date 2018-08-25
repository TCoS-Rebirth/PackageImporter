﻿using System;

namespace Engine
{
    [Serializable] public class LadderVolume : PhysicsVolume
    {
        public Pawn PendingClimber;

        public LadderVolume()
        {
        }
    }
}
/*
simulated event PhysicsChangedFor(Actor Other) {
if (Other.Physics == 2 || Other.Physics == 11
|| Other.bDeleteMe
|| Pawn(Other) == None
|| Pawn(Other).Controller == None) {
return;                                                                   
}
Spawn(Class'PotentialClimbWatcher',Other);                                  
}
simulated event PawnLeavingVolume(Pawn P) {
local Controller C;
if (P.OnLadder != self) {                                                   
return;                                                                   
}
Super.PawnLeavingVolume(P);                                                 
P.OnLadder = None;                                                          
P.EndClimbLadder(self);                                                     
if (P == PendingClimber) {                                                  
PendingClimber = None;                                                    
}
if (!InUse(P)) {                                                            
C = Level.ControllerList;                                                 
while (C != None) {                                                       
if (C.bPreparingMove && Ladder(C.MoveTarget) != None
&& Ladder(C.MoveTarget).MyLadder == self) {
C.bPreparingMove = False;                                             
PendingClimber = C.Pawn;                                              
return;                                                               
}
C = C.nextController;                                                   
}
}
}
simulated event PawnEnteredVolume(Pawn P) {
local Rotator PawnRot;
Super.PawnEnteredVolume(P);                                                 
if (!P.CanGrabLadder()) {                                                   
return;                                                                   
}
PawnRot = P.Rotation;                                                       
PawnRot.Pitch = 0;                                                          
if (vector(PawnRot) Dot LookDir > 0.89999998
|| AIController(P.Controller) != None
&& Ladder(P.Controller.MoveTarget) != None) {
P.ClimbLadder(self);                                                      
} else {                                                                    
if (!P.bDeleteMe && P.Controller != None) {                               
Spawn(Class'PotentialClimbWatcher',P);                                  
}
}
}
function bool InUse(Pawn Ignored) {
local Pawn StillClimbing;
foreach TouchingActors(Class'Pawn',StillClimbing) {                         
if (StillClimbing != Ignored && StillClimbing.bCollideActors
&& StillClimbing.bBlockActors) {
return True;                                                            
}
}
if (PendingClimber != None) {                                               
if (PendingClimber.Controller == None
|| !PendingClimber.bCollideActors
|| !PendingClimber.bBlockActors
|| Ladder(PendingClimber.Controller.MoveTarget) == None
|| Ladder(PendingClimber.Controller.MoveTarget).MyLadder != self) {
PendingClimber = None;                                                  
}
}
return PendingClimber != None && PendingClimber != Ignored;                 
}
simulated function PostBeginPlay() {
local Ladder L;
local Ladder M;
local Vector dir;
Super.PostBeginPlay();                                                      
LookDir = vector(WallDir);                                                  
if (!bAutoPath && LookDir.Z != 0) {                                         
ClimbDir = vect(0.000000, 0.000000, 1.000000);                            
L = LadderList;                                                           
while (L != None) {                                                       
M = LadderList;                                                         
while (M != None) {                                                     
if (M != L) {                                                         
dir = Normal(M.Location - L.Location);                              
if (dir Dot ClimbDir < 0) {                                         
dir *= -1;                                                        
}
ClimbDir += dir;                                                    
}
M = M.LadderList;                                                     
}
L = L.LadderList;                                                       
}
ClimbDir = Normal(ClimbDir);                                              
if (ClimbDir Dot vect(0.000000, 0.000000, 1.000000) < 0) {                
ClimbDir *= -1;                                                         
}
}
}
*/