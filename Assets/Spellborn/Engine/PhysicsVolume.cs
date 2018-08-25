﻿using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class PhysicsVolume : Volume
    {
        [FoldoutGroup("LevelArea")]
        public string RespawnPoint = string.Empty;

        public PhysicsVolume NextPhysicsVolume;

        public PhysicsVolume()
        {
        }
    }
}
/*
function CausePainTo(Actor Other) {
local float depth;
local Pawn P;
depth = 1.00000000;                                                         
P = Pawn(Other);                                                            
if (DamagePerSec > 0) {                                                     
if (Region.Zone.bSoftKillZ && Other.Physics != 1) {                       
return;                                                                 
}
Other.TakeDamage(DamagePerSec * depth,None,Location,vect(0.000000, 0.000000, 0.000000),DamageType);
if (P != None && P.Controller != None) {                                  
P.Controller.PawnIsInPain(self);                                        
}
goto jl00CE;                                                              
}
}
simulated function PlayExitSplash(Actor Other) {
if (ExitSound != None) {                                                    
Other.PlaySound(ExitSound,3,Other.TransientSoundVolume);                  
}
if (ExitActor != None && Level.NetMode != 1) {                              
Spawn(ExitActor,,,Other.Location - Other.CollisionHeight * vect(0.000000, 0.000000, 0.800000),rot(16384, 0, 0));
}
}
simulated event UnTouch(Actor Other) {
if (bWaterVolume && Other.CanSplash()) {                                    
PlayExitSplash(Other);                                                    
}
}
simulated function PlayEntrySplash(Actor Other) {
local Vector StartLoc;
local Vector Vel2D;
if (EntrySound != None) {                                                   
Other.PlaySound(EntrySound,3,Other.TransientSoundVolume);                 
if (Other.Instigator != None) {                                           
MakeNoise(1.00000000);                                                  
}
}
if (EntryActor != None && Level.NetMode != 1) {                             
StartLoc = Other.Location - Other.CollisionHeight * vect(0.000000, 0.000000, 0.800000);
if (Other.CollisionRadius > 0) {                                          
Vel2D = Other.Velocity;                                                 
Vel2D.Z = 0.00000000;                                                   
if (VSize(Vel2D) > 100) {                                               
StartLoc = StartLoc + Normal(Vel2D) * CollisionRadius;                
}
}
Spawn(EntryActor,,,StartLoc,rot(16384, 0, 0));                            
}
}
simulated event Touch(Actor Other) {
local Pawn P;
local bool bFoundPawn;
Super.Touch(Other);                                                         
if (Other == None) {                                                        
return;                                                                   
}
if (Other.SBRole == 1 || Other.bNetTemporary) {                             
if (bPainCausing) {                                                       
if (Other.bDestroyInPainVolume) {                                       
Other.Destroy();                                                      
return;                                                               
}
if (Other.bCanBeDamaged && !Other.bStatic) {                            
CausePainTo(Other);                                                   
if (Other == None) {                                                  
return;                                                             
}
if (SBRole == 1) {                                                    
if (PainTimer == None) {                                            
PainTimer = Spawn(Class'VolumeTimer',self);                       
} else {                                                            
if (Pawn(Other) != None) {                                        
foreach TouchingActors(Class'Pawn',P) {                         
if (P != Other && P.bCanBeDamaged) {                          
bFoundPawn = True;                                          
} else {                                                      
}
}
if (!bFoundPawn) {                                              
PainTimer.SetTimer(1.00000000,True);                          
}
}
}
}
}
}
}
if (bWaterVolume && Other.CanSplash()) {                                    
PlayEntrySplash(Other);                                                   
}
}
function Trigger(Actor Other,Pawn EventInstigator) {
local Pawn P;
if (DamagePerSec != 0) {                                                    
bPainCausing = !bPainCausing;                                             
if (bPainCausing) {                                                       
if (PainTimer == None) {                                                
PainTimer = Spawn(Class'VolumeTimer',self);                           
}
foreach TouchingActors(Class'Pawn',P) {                                 
CausePainTo(P);                                                       
}
}
}
}
function TimerPop(VolumeTimer t) {
local Actor A;
local bool bFound;
if (t == PainTimer) {                                                       
if (!bPainCausing) {                                                      
PainTimer.Destroy();                                                    
return;                                                                 
}
foreach TouchingActors(Class'Actor',A) {                                  
if (A.bCanBeDamaged && !A.bStatic) {                                    
CausePainTo(A);                                                       
bFound = True;                                                        
}
}
if (!bFound) {                                                            
PainTimer.Destroy();                                                    
}
}
}
singular event BaseChange() {
if (Base != None) {                                                         
bAlwaysRelevant = True;                                                   
}
}
function PlayerPawnDiedInVolume(Pawn Other) {
UntriggerEvent(Event,self,Other);                                           
}
event PawnLeavingVolume(Pawn Other) {
if (Other.IsPlayerPawn()) {                                                 
UntriggerEvent(Event,self,Other);                                         
}
}
simulated event PawnEnteredVolume(Pawn Other) {
local Vector HitLocation;
local Vector HitNormal;
local Actor SpawnedEntryActor;
if (bWaterVolume
&& Level.TimeSeconds - Other.SplashTime > 0.30000001
&& PawnEntryActor != None
&& !Level.bDropDetail
&& Level.DetailMode != 0
&& EffectIsRelevant(Other.Location,False)) {
if (!TraceThisActor(HitLocation,HitNormal,Other.Location - Other.CollisionHeight * vect(0.000000, 0.000000, 1.000000),Other.Location + Other.CollisionHeight * vect(0.000000, 0.000000, 1.000000))) {
SpawnedEntryActor = Spawn(PawnEntryActor,Other,,HitLocation,rot(16384, 0, 0));
}
}
if (SBRole == 1 && Other.IsPlayerPawn()) {                                  
TriggerEvent(Event,self,Other);                                           
}
}
event ActorLeavingVolume(Actor Other);
event ActorEnteredVolume(Actor Other);
event PhysicsChangedFor(Actor Other);
function Reset() {
Gravity = BACKUP_Gravity;                                                   
bPainCausing = BACKUP_bPainCausing;                                         
}
simulated function PostBeginPlay() {
Super.PostBeginPlay();                                                      
BACKUP_Gravity = Gravity;                                                   
BACKUP_bPainCausing = bPainCausing;                                         
if (VolumeEffect == None && bWaterVolume) {                                 
VolumeEffect = new (Level.XLevel) Class'EFFECT_WaterVolume';              
}
}
simulated function PreBeginPlay() {
if (Base == None) {                                                         
bAlwaysRelevant = False;                                                  
}
Super.PreBeginPlay();                                                       
}
*/