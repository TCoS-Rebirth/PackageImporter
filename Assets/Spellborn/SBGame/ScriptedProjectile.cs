﻿using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class ScriptedProjectile : Game_Actor
    {
        [FoldoutGroup("Projectile")]
        [FieldConst()]
        public List<NavigationPoint> Targets = new List<NavigationPoint>();

        [FoldoutGroup("Projectile")]
        [FieldConst()]
        public float ReloadTimeout;

        [FoldoutGroup("Projectile")]
        [FieldConst()]
        public float LaunchTimeoutMax;

        [FoldoutGroup("Projectile")]
        [FieldConst()]
        public float LaunchTimeoutMin;

        [FoldoutGroup("Projectile")]
        [FieldConst()]
        public float ParabolaScale;

        [FoldoutGroup("Projectile")]
        [FieldConst()]
        public float MinFlightTime;

        [FoldoutGroup("Projectile")]
        [FieldConst()]
        public float MaxFlightTime;

        [FoldoutGroup("Projectile")]
        [FieldConst()]
        public bool StopSmokeEffectOnImpact;

        [FoldoutGroup("Projectile")]
        [FieldConst()]
        public bool HiddenWhileIdle;

        [FoldoutGroup("Projectile")]
        [FieldConst()]
        public bool TriggerAble;

        [FoldoutGroup("Projectile")]
        [FieldConst()]
        public bool FireOnlyOnce;

        [FoldoutGroup("Projectile")]
        [FieldConst()]
        public List<FSkill_EffectClass_AudioVisual> Effects_Smoke = new List<FSkill_EffectClass_AudioVisual>();

        [FoldoutGroup("Projectile")]
        [FieldConst()]
        public List<FSkill_EffectClass_AudioVisual> Effects_Explosion = new List<FSkill_EffectClass_AudioVisual>();

        public byte ProjectileState;

        public float ProjectileTimer;

        public Vector StartLocation;

        public Rotator StartRotation;

        public Vector TargetLocation;

        public Vector ProjectileSpeed;

        public Vector ProjLocation;

        public float LaunchTimeout;

        public float FlightDist;

        public Vector ProjSpeed;

        public Rotator ProjRot;

        public List<int> SmokeEffectHandles = new List<int>();

        public List<int> ExplosionEffectHandles = new List<int>();

        public float ParabolaHeight;

        public bool Triggered;

        public bool HasFired;

        public ScriptedProjectile()
        {
        }

        public enum ProjectileStates
        {
            STATE_LOADED,

            STATE_FIRED,

            STATE_EXPLODED,
        }
    }
}
/*
function StopEffects(out array<int> aEffectHandleArray) {
local int i;
i = 0;                                                                      
while (i < aEffectHandleArray.Length) {                                     
if (aEffectHandleArray[i] != 0) {                                         
Effects.cl_Stop(aEffectHandleArray[i]);                                 
}
i++;                                                                      
}
aEffectHandleArray.Length = 0;                                              
}
function StartEffects(array<FSkill_EffectClass_AudioVisual> aEffects,out array<int> aEffectHandleArray) {
local int i;
i = 0;                                                                      
while (i < aEffects.Length) {                                               
if (aEffects[i] != None) {                                                
aEffectHandleArray[aEffectHandleArray.Length] = Effects.cl_Start(aEffects[i],Class'Game_Effects'.-1073741824,Class'Game_Effects'.-1073741824.00000000,Class'Game_Effects'.-1073741824.00000000,Class'FSkill_EffectClass_AudioVisual'.-1.00000000);
}
i++;                                                                      
}
}
event cl_OnTick(float delta) {
local Vector TempLocation;
local float FlightTime;
Super.cl_OnTick(delta);                                                     
if (FireOnlyOnce && HasFired) {                                             
return;                                                                   
}
if (Triggered || !TriggerAble) {                                            
ProjectileTimer += delta;                                                 
switch (ProjectileState) {                                                
case 0 :                                                                
if (ProjectileTimer > LaunchTimeout) {                                
if (Targets.Length > 0) {                                           
TargetLocation = Targets[Rand(Targets.Length)].Location;          
FlightTime = static.FRandRange(MinFlightTime,MaxFlightTime);      
ProjLocation = Location;                                          
ProjectileSpeed = (TargetLocation - Location) / FlightTime;       
FlightDist = VSize(TargetLocation - Location);                    
if (FlightDist == 0) {                                            
FlightDist = 1.00000000;                                        
}
ParabolaHeight = FlightDist / 10 * ParabolaScale;                 
StartEffects(Effects_Smoke,SmokeEffectHandles);                   
ProjectileState = 1;                                              
if (HiddenWhileIdle) {                                            
bHidden = False;                                                
}
}
}
break;                                                                
case 1 :                                                                
ProjLocation = ProjLocation + ProjectileSpeed * delta;                
if (VSize(TargetLocation - ProjLocation) < VSize(ProjectileSpeed * delta * 1.50000000)) {
SetRotation(rotator(TargetLocation - Location));                    
SetLocation(TargetLocation);                                        
ProjectileTimer = 0.00000000;                                       
ProjectileState = 2;                                                
if (StopSmokeEffectOnImpact) {                                      
StopEffects(SmokeEffectHandles);                                  
}
StartEffects(Effects_Explosion,ExplosionEffectHandles);             
} else {                                                              
TempLocation = ProjLocation;                                        
TempLocation.Z += Sin(VSize(ProjLocation - TargetLocation) / FlightDist * 3.14159274) * ParabolaHeight;
SetRotation(rotator(TempLocation - Location));                      
SetLocation(TempLocation);                                          
}
break;                                                                
case 2 :                                                                
if (ProjectileTimer > ReloadTimeout) {                                
ProjectileTimer = 0.00000000;                                       
SetLocation(StartLocation);                                         
SetRotation(StartRotation);                                         
LaunchTimeout = static.FRandRange(LaunchTimeoutMin,LaunchTimeoutMax);
StopEffects(SmokeEffectHandles);                                    
StopEffects(ExplosionEffectHandles);                                
if (HiddenWhileIdle) {                                              
bHidden = True;                                                   
}
HasFired = True;                                                    
ProjectileState = 0;                                                
}
break;                                                                
default:                                                                
}
}
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
Triggered = False;                                                          
}
event Trigger(Actor Other,Pawn EventInstigator) {
Triggered = True;                                                           
}
event BeginPlay() {
SetPhysics(4);                                                              
StartLocation = Location;                                                   
StartRotation = Rotation;                                                   
ProjectileState = 0;                                                        
ProjectileTimer = 0.00000000;                                               
LaunchTimeout = static.FRandRange(LaunchTimeoutMin,Max(LaunchTimeoutMax,LaunchTimeoutMin));
}
*/