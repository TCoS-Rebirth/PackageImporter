﻿using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class Teleporter : SmallNavigationPoint
    {
        [FoldoutGroup("Teleporter")]
        public string URL = string.Empty;

        [FoldoutGroup("Teleporter")]
        public NameProperty ProductRequired;

        [FoldoutGroup("Teleporter")]
        public bool bChangesVelocity;

        [FoldoutGroup("Teleporter")]
        public bool bChangesYaw;

        [FoldoutGroup("Teleporter")]
        public bool bReversesX;

        [FoldoutGroup("Teleporter")]
        public bool bReversesY;

        [FoldoutGroup("Teleporter")]
        public bool bReversesZ;

        [FoldoutGroup("Teleporter")]
        public bool bEnabled;

        [FoldoutGroup("Teleporter")]
        public Vector TargetVelocity;

        public Actor TriggerActor;

        public Actor TriggerActor2;

        public float LastFired;

        public Teleporter()
        {
        }
    }
}
/*
event int SpecialCost(Pawn Other,ReachSpec Path) {
if (Teleporter(Path.Start) == None || (Path.reachFlags & 32) == 0) {        
return 0;                                                                 
}
return 0;                                                                   
}
function Actor SpecialHandling(Pawn Other) {
local Vector Dist2D;
if (bEnabled
&& Teleporter(Other.Controller.RouteCache[1]) != None
&& string(Other.Controller.RouteCache[1].Tag) ~= URL) {
if (Abs(Location.Z - Other.Location.Z) < CollisionHeight + Other.CollisionHeight) {
Dist2D = Location - Other.Location;                                     
Dist2D.Z = 0.00000000;                                                  
if (VSize(Dist2D) < CollisionRadius + Other.CollisionRadius) {          
PostTouch(Other);                                                     
}
}
return self;                                                              
}
if (TriggerActor == None) {                                                 
FindTriggerActor();                                                       
if (TriggerActor == None) {                                               
return None;                                                            
}
}
if (TriggerActor2 != None
&& VSize(TriggerActor2.Location - Other.Location) < VSize(TriggerActor.Location - Other.Location)) {
return TriggerActor2;                                                     
}
return TriggerActor;                                                        
}
simulated function PostTouch(Actor Other) {
local Teleporter D;
local Teleporter Dest[16];
local int i;
foreach AllActors(Class'Teleporter',D) {                                    
if (string(D.Tag) ~= URL && D != self) {                                  
Dest[i] = D;                                                            
i++;                                                                    
if (i > 16) {                                                           
} else {                                                                
}
}
}
i = Rand(i);                                                                
if (Dest[i] != None) {                                                      
if (Other.IsA('Pawn')) {                                                  
Other.PlayTeleportEffect(False,True);                                   
}
Dest[i].Accept(Other,self);                                               
if (Pawn(Other) != None) {                                                
TriggerEvent(Event,self,Pawn(Other));                                   
}
}
}
event Touch(Actor Other) {
if (!bEnabled || Other == None) {                                           
return;                                                                   
}
if (Other.bCanTeleport
&& Other.PreTeleport(self) == False) {         
PendingTouch = Other.PendingTouch;                                        
Other.PendingTouch = self;                                                
}
}
function Trigger(Actor Other,Pawn EventInstigator) {
local Actor A;
bEnabled = !bEnabled;                                                       
if (bEnabled) {                                                             
foreach TouchingActors(Class'Actor',A) {                                  
PostTouch(A);                                                           
}
}
}
simulated function bool Accept(Actor Incoming,Actor Source) {
local Rotator newRot;
local Rotator OldRot;
local float mag;
local Vector oldDir;
local Controller P;
if (Incoming == None) {                                                     
return False;                                                             
}
Disable('Touch');                                                           
newRot = Incoming.Rotation;                                                 
if (bChangesYaw) {                                                          
OldRot = Incoming.Rotation;                                               
newRot.Yaw = Rotation.Yaw;                                                
if (Source != None) {                                                     
newRot.Yaw += 32768 + Incoming.Rotation.Yaw - Source.Rotation.Yaw;      
}
}
if (Pawn(Incoming) != None) {                                               
if (SBRole == 1) {                                                        
P = Level.ControllerList;                                               
while (P != None) {                                                     
if (P.Enemy == Incoming) {                                            
P.LineOfSightTo(Incoming);                                          
}
P = P.nextController;                                                 
}
}
if (!Pawn(Incoming).SetLocation(Location)) {                              
Log(string(self) $ " Teleport failed for "
$ string(Incoming));
return False;                                                           
}
if (SBRole == 1
|| Level.TimeSeconds - LastFired > 0.50000000) {  
newRot.Roll = 0;                                                        
Pawn(Incoming).SetRotation(newRot);                                     
Pawn(Incoming).SetViewRotation(newRot);                                 
LastFired = Level.TimeSeconds;                                          
}
if (Pawn(Incoming).Controller != None) {                                  
Pawn(Incoming).Controller.MoveTimer = -1.00000000;                      
Pawn(Incoming).Anchor = self;                                           
Pawn(Incoming).SetMoveTarget(self);                                     
}
Incoming.PlayTeleportEffect(False,True);                                  
} else {                                                                    
if (!Incoming.SetLocation(Location)) {                                    
Enable('Touch');                                                        
return False;                                                           
}
if (bChangesYaw) {                                                        
Incoming.SetRotation(newRot);                                           
}
}
Enable('Touch');                                                            
if (bChangesVelocity) {                                                     
Incoming.Velocity = TargetVelocity;                                       
} else {                                                                    
if (bChangesYaw) {                                                        
if (Incoming.Physics == 1) {                                            
OldRot.Pitch = 0;                                                     
}
oldDir = vector(OldRot);                                                
mag = Incoming.Velocity Dot oldDir;                                     
Incoming.Velocity = Incoming.Velocity - mag * oldDir + mag * vector(Incoming.Rotation);
}
if (bReversesX) {                                                         
Incoming.Velocity.X *= -1.00000000;                                     
}
if (bReversesY) {                                                         
Incoming.Velocity.Y *= -1.00000000;                                     
}
if (bReversesZ) {                                                         
Incoming.Velocity.Z *= -1.00000000;                                     
}
}
return True;                                                                
}
function FindTriggerActor() {
local Actor A;
TriggerActor = None;                                                        
TriggerActor2 = None;                                                       
foreach DynamicActors(Class'Actor',A) {                                     
if (A.Event == Tag) {                                                     
if (TriggerActor == None) {                                             
TriggerActor = A;                                                     
} else {                                                                
TriggerActor2 = A;                                                    
return;                                                               
}
}
}
}
function PostBeginPlay() {
local int i;
if (URL ~= "") {                                                            
SetCollision(False,False);                                                
}
if (!bEnabled) {                                                            
FindTriggerActor();                                                       
}
i = 0;                                                                      
while (i < PathList.Length) {                                               
if (Teleporter(PathList[i].End) != None) {                                
PathList[i].bForced = True;                                             
PathList[i].reachFlags = PathList[i].reachFlags | 256;                  
}
i++;                                                                      
}
Super.PostBeginPlay();                                                      
}
*/