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
using Framework.Attributes;

namespace Engine
{
    
    
    public class Decoration : Actor
    {
        
        [FieldCategory(Category="Decoration")]
        [TypeProxyDefinition(TypeName="Actor")]
        public System.Type EffectWhenDestroyed;
        
        [FieldCategory(Category="Decoration")]
        public bool bPushable;
        
        [FieldCategory(Category="Decoration")]
        public bool bDamageable;
        
        public bool bPushSoundPlaying;
        
        public bool bSplash;
        
        [FieldCategory(Category="Decoration")]
        [IgnoreFieldExtraction()]
        public Sound PushSound;
        
        [FieldCategory(Category="Decoration")]
        [IgnoreFieldExtraction()]
        public Sound EndPushSound;
        
        [FieldConst()]
        public int numLandings;
        
        [FieldCategory(Category="Decoration")]
        public int NumFrags;
        
        [FieldCategory(Category="Decoration")]
        [IgnoreFieldExtraction()]
        public string FragSkin; // //texture
        
        [FieldCategory(Category="Decoration")]
        [TypeProxyDefinition(TypeName="Fragment")]
        public System.Type FragType;
        
        public Vector FragMomentum;
        
        [FieldCategory(Category="Decoration")]
        public int Health;
        
        [FieldCategory(Category="Decoration")]
        public float SplashTime;
        
        [FieldConst()]
        public NavigationPoint LastAnchor;
        
        public float LastValidAnchorTime;
        
        public Decoration()
        {
        }
    }
}
/*
function Bump(Actor Other) {
local float speed;
local float OldZ;
if (bPushable && Pawn(Other) != None
&& Other.Mass > 40) {            
OldZ = Velocity.Z;                                                        
speed = VSize(Other.Velocity);                                            
Velocity = Other.Velocity * FMin(120.00000000,20.00000000 + speed) / speed;
if (Physics == 0) {                                                       
Velocity.Z = 25.00000000;                                               
if (!bPushSoundPlaying) {                                               
PlaySound(PushSound,1);                                               
bPushSoundPlaying = True;                                             
}
} else {                                                                  
Velocity.Z = OldZ;                                                      
}
SetPhysics(2);                                                            
SetTimer(0.30000001,False);                                               
Instigator = Pawn(Other);                                                 
}
}
function Timer() {
PlaySound(EndPushSound,1);                                                  
bPushSoundPlaying = False;                                                  
}
simulated function Destroyed() {
local int i;
local Fragment s;
local float BaseSize;
if (SBRole == 1) {                                                          
TriggerEvent(Event,self,None);                                            
if (bPushSoundPlaying) {                                                  
PlaySound(EndPushSound,1);                                              
}
}
if (Level.NetMode != 1 && !PhysicsVolume.bDestructive
&& NumFrags > 0
&& FragType != None) {
BaseSize = 0.80000001 * Sqrt(CollisionRadius * CollisionHeight) / NumFrags;
i = 0;                                                                    
while (i < NumFrags) {                                                    
s = Spawn(FragType,Owner,,Location + CollisionRadius * VRand());        
s.CalcVelocity(FragMomentum);                                           
if (FragSkin != None) {                                                 
s.Skins[0] = FragSkin;                                                
}
s.SetDrawScale(BaseSize * (0.50000000 + 0.69999999 * FRand()));         
i++;                                                                    
}
}
Super.Destroyed();                                                          
}
singular function BaseChange() {
if (Velocity.Z < -500) {                                                    
TakeDamage(1 - Velocity.Z / 30,Instigator,Location,vect(0.000000, 0.000000, 0.000000),Class'Crushed');
}
if (Base == None) {                                                         
if (!bInterpolating && bPushable && Physics == 0) {                       
SetPhysics(2);                                                          
}
} else {                                                                    
if (Pawn(Base) != None) {                                                 
Base.TakeDamage((1 - Velocity.Z / 400) * Mass / Base.Mass,Instigator,Location,0.50000000 * Velocity,Class'Crushed');
Velocity.Z = 100.00000000;                                              
if (FRand() < 0.50000000) {                                             
Velocity.X += 70;                                                     
} else {                                                                
Velocity.Y += 70;                                                     
}
SetPhysics(2);                                                          
} else {                                                                  
if (Decoration(Base) != None && Velocity.Z < -500) {                    
Base.TakeDamage(1 - Mass / Base.Mass * Velocity.Z / 30,Instigator,Location,0.20000000 * Velocity,Class'Crushed');
Velocity.Z = 100.00000000;                                            
if (FRand() < 0.50000000) {                                           
Velocity.X += 70;                                                   
} else {                                                              
Velocity.Y += 70;                                                   
}
SetPhysics(2);                                                        
} else {                                                                
Instigator = None;                                                    
}
}
}
}
function Trigger(Actor Other,Pawn EventInstigator) {
Instigator = EventInstigator;                                               
TakeDamage(1000,Instigator,Location,vect(0.000000, 0.000000, 1.000000) * 900,Class'Crushed');
}
singular function PhysicsVolumeChange(PhysicsVolume NewVolume) {
if (NewVolume.bWaterVolume) {                                               
if (bSplash && !PhysicsVolume.bWaterVolume
&& Mass <= Buoyancy
&& (Abs(Velocity.Z) < 100 || Mass == 0)
&& FRand() < 0.05000000
&& !PlayerCanSeeMe()) {
bSplash = False;                                                        
SetPhysics(0);                                                          
}
}
if (PhysicsVolume.bWaterVolume && Buoyancy > Mass) {                        
if (Buoyancy > 1.10000002 * Mass) {                                       
Buoyancy = 0.94999999 * Buoyancy;                                       
} else {                                                                  
if (Buoyancy > 1.02999997 * Mass) {                                     
Buoyancy = 0.99000001 * Buoyancy;                                     
}
}
}
}
function TakeDamage(int NDamage,Pawn instigatedBy,Vector HitLocation,Vector Momentum,class<DamageType> DamageType) {
Instigator = instigatedBy;                                                  
if (!bDamageable || Health < 0) {                                           
return;                                                                   
}
if (Instigator != None) {                                                   
MakeNoise(1.00000000);                                                    
}
Health -= NDamage;                                                          
FragMomentum = Momentum;                                                    
if (Health < 0) {                                                           
Destroy();                                                                
} else {                                                                    
SetPhysics(2);                                                            
Momentum.Z = 1000.00000000;                                               
Velocity = Momentum / Mass;                                               
}
}
function HitWall(Vector HitNormal,Actor Wall) {
Landed(HitNormal);                                                          
}
function Landed(Vector HitNormal) {
local Rotator newRot;
if (Velocity.Z < -500) {                                                    
TakeDamage(100,Pawn(Owner),HitNormal,HitNormal * 10000,Class'Crushed');   
}
Velocity = vect(0.000000, 0.000000, 0.000000);                              
newRot = Rotation;                                                          
newRot.Pitch = 0;                                                           
newRot.Roll = 0;                                                            
SetRotation(newRot);                                                        
}
function Drop(Vector newVel);
function bool CanSplash() {
if (Level.TimeSeconds - SplashTime > 0.25000000
&& Physics == 2
&& Abs(Velocity.Z) > 100) {
SplashTime = Level.TimeSeconds;                                           
return True;                                                              
}
return False;                                                               
}
event NotReachableBy(Pawn P);
*/
