﻿using System;

namespace Engine
{
    [Serializable] public abstract class AIController : Controller
    {
        public bool bHunting;

        public bool bAdjustFromWalls;

        public bool bPlannedJump;

        public AIScript MyScript;

        public float Skill;

    }
}
/*
function Startle(Actor A);
function bool PriorityObjective() {
return False;                                                               
}
function MoverFinished() {
if (PendingMover.myMarker.ProceedWithMove(Pawn)) {                          
PendingMover = None;                                                      
bPreparingMove = False;                                                   
}
}
function WaitForMover(Mover M) {
if (Enemy != None
&& Level.TimeSeconds - LastSeenTime < 3.00000000) { 
Focus = Enemy;                                                            
}
PendingMover = M;                                                           
bPreparingMove = True;                                                      
Pawn.Acceleration = vect(0.000000, 0.000000, 0.000000);                     
}
event PrepareForMove(NavigationPoint Goal,ReachSpec Path);
function name GetOrders() {
return 'None';                                                              
}
function Actor GetOrderObject() {
return None;                                                                
}
function SetOrders(name NewOrders,Controller OrderGiver);
function int GetFacingDirection() {
local float strafeMag;
local Vector Focus2D;
local Vector Loc2D;
local Vector Dest2D;
local Vector dir;
local Vector LookDir;
local Vector Y;
Focus2D = FocalPoint;                                                       
Focus2D.Z = 0.00000000;                                                     
Loc2D = Pawn.Location;                                                      
Loc2D.Z = 0.00000000;                                                       
Dest2D = Destination;                                                       
Dest2D.Z = 0.00000000;                                                      
LookDir = Normal(Focus2D - Loc2D);                                          
dir = Normal(Dest2D - Loc2D);                                               
strafeMag = LookDir Dot dir;                                                
Y = LookDir Cross vect(0.000000, 0.000000, 1.000000);                       
if (Y Dot (Dest2D - Loc2D) < 0) {                                           
return 49152 + 16384 * strafeMag;                                         
} else {                                                                    
return 16384 - 16384 * strafeMag;                                         
}
}
function DisplayDebug(Canvas Canvas,out float YL,out float YPos) {
local int i;
local string t;
Super.DisplayDebug(Canvas,YL,YPos);                                         
Canvas.DrawColor.B = 255;                                                   
if (Pawn != None && MoveTarget != None
&& Pawn.ReachedDestination(MoveTarget)) {
Canvas.DrawText("     Skill " $ string(Skill) $ " NAVIGATION MoveTarget "
$ GetItemName(string(MoveTarget))
$ "(REACHED) PendingMover "
$ string(PendingMover)
$ " MoveTimer "
$ string(MoveTimer),False);
} else {                                                                    
Canvas.DrawText("     Skill " $ string(Skill) $ " NAVIGATION MoveTarget "
$ GetItemName(string(MoveTarget))
$ " PendingMover "
$ string(PendingMover)
$ " MoveTimer "
$ string(MoveTimer),False);
}
YPos += YL;                                                                 
Canvas.SetPos(4.00000000,YPos);                                             
t = "      Destination " $ string(Destination)
$ " Focus "
$ GetItemName(string(Focus));
if (bPreparingMove) {                                                       
t = t $ " (Preparing Move)";                                              
}
Canvas.DrawText(t,False);                                                   
YPos += YL;                                                                 
Canvas.SetPos(4.00000000,YPos);                                             
Canvas.DrawText("      RouteGoal " $ GetItemName(string(RouteGoal))
$ " RouteDist "
$ string(RouteDist),False);
YPos += YL;                                                                 
Canvas.SetPos(4.00000000,YPos);                                             
i = 0;                                                                      
while (i < 16) {                                                            
if (RouteCache[i] == None) {                                              
if (i > 5) {                                                            
t = t $ "--"
$ GetItemName(string(RouteCache[i - 1]));    
}
break;                                                                  
} else {                                                                  
if (i < 5) {                                                            
t = t
$ GetItemName(string(RouteCache[i]))
$ "-";
}
}
i++;                                                                      
}
Canvas.DrawText("RouteCache: " $ t,False);                                  
YPos += YL;                                                                 
Canvas.SetPos(4.00000000,YPos);                                             
}
function bool TriggerScript(Actor Other,Pawn EventInstigator) {
if (MyScript != None) {                                                     
MyScript.Trigger(EventInstigator,Pawn);                                   
return True;                                                              
}
return False;                                                               
}
function Trigger(Actor Other,Pawn EventInstigator) {
TriggerScript(Other,EventInstigator);                                       
}
function Reset() {
bHunting = False;                                                           
bPlannedJump = False;                                                       
Super.Reset();                                                              
}
event PreBeginPlay() {
Super.PreBeginPlay();                                                       
Skill = 1.00000000;                                                         
}
final native(510) latent function WaitToSeeEnemy();
*/