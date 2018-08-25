﻿using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
#pragma warning disable 414   

    [Serializable] public class Game_Actor : Actor
    {
        public Vector mNetLocation;

        public Vector mNetRotation;

        [FoldoutGroup("Game_Actor")]
        public bool IsEnabled;

        [FoldoutGroup("Game_Actor")]
        public byte mCollisionType;

        [FoldoutGroup("Appearance")]
        public List<FSkill_EffectClass_AudioVisual> EnabledEffects = new List<FSkill_EffectClass_AudioVisual>();

        [FoldoutGroup("Appearance")]
        public List<FSkill_EffectClass_AudioVisual> DisabledEffects = new List<FSkill_EffectClass_AudioVisual>();

        private List<int> RunningEffects = new List<int>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Game_Pawn mTargetPawn;

        public Game_Effects Effects;

        public Game_Actor()
        {
        }

        public enum CollisionType
        {
            COL_NoCollision,

            COL_Colliding,

            COL_Blocking,
        }
    }
}
/*
function cl_UpdateEnabledEffects() {
local int i;
local int H;
i = 0;                                                                      
while (i < RunningEffects.Length) {                                         
if (RunningEffects[i] != 0) {                                             
Effects.cl_Stop(RunningEffects[i]);                                     
}
i++;                                                                      
}
RunningEffects.Length = 0;                                                  
if (IsEnabled) {                                                            
i = 0;                                                                    
while (i < EnabledEffects.Length) {                                       
if (EnabledEffects[i] != None) {                                        
H = Effects.cl_Start(EnabledEffects[i],Class'Game_Effects'.-1073741824,Class'Game_Effects'.-1073741824.00000000,Class'Game_Effects'.-1073741824.00000000,Class'FSkill_EffectClass_AudioVisual'.-1.00000000);
RunningEffects[i] = H;                                                
}
i++;                                                                    
}
} else {                                                                    
i = 0;                                                                    
while (i < DisabledEffects.Length) {                                      
if (DisabledEffects[i] != None) {                                       
H = Effects.cl_Start(DisabledEffects[i],Class'Game_Effects'.-1073741824,Class'Game_Effects'.-1073741824.00000000,Class'Game_Effects'.-1073741824.00000000,Class'FSkill_EffectClass_AudioVisual'.-1.00000000);
RunningEffects[i] = H;                                                
}
i++;                                                                    
}
Effects.cl_SetInteractionEffect(Class'Game_Effects'.0);                   
}
}
function cl_SetEnabled(bool Enable) {
local bool updateeffects;
updateeffects = IsEnabled != Enable;                                        
IsEnabled = Enable;                                                         
if (updateeffects) {                                                        
cl_UpdateEnabledEffects();                                                
}
}
protected native function sv2clrel_SetEnabled_CallStub();
private event sv2clrel_SetEnabled(bool Enable) {
cl_SetEnabled(Enable);                                                      
}
native function sv_SetEnabled(bool Enable);
function Show(bool aShowFlag,optional float aTimeToShow) {
bHidden = !aShowFlag;                                                       
}
protected native function sv2clrel_Show_CallStub();
private event sv2clrel_Show(bool aShowFlag,optional float aFadeTimer) {
Show(aShowFlag,aFadeTimer);                                                 
}
function sv_Show(bool aShowFlag,optional float aFadeTimer) {
sv2clrel_Show_CallStub(aShowFlag,aFadeTimer);                               
Show(aShowFlag,aFadeTimer);                                                 
}
private function SetCollisionType(byte aCollisionType) {
mCollisionType = aCollisionType;                                            
switch (aCollisionType) {                                                   
case 0 :                                                                  
SetCollision(False,False);                                              
break;                                                                  
case 1 :                                                                  
SetCollision(True,False);                                               
break;                                                                  
case 2 :                                                                  
SetCollision(True,True);                                                
break;                                                                  
default:                                                                  
}
}
protected native function sv2clrel_SetCollisionType_CallStub();
private event sv2clrel_SetCollisionType(byte aCollisionType) {
SetCollisionType(aCollisionType);                                           
}
function sv_SetCollision(bool aBlocking,optional bool aColliding) {
if (aBlocking) {                                                            
SetCollisionType(2);                                                      
} else {                                                                    
if (aColliding) {                                                         
SetCollisionType(1);                                                    
} else {                                                                  
SetCollisionType(0);                                                    
}
}
sv2clrel_SetCollisionType_CallStub(mCollisionType);                         
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
Super.UnTrigger(Other,EventInstigator);                                     
if (IsServer()) {                                                           
sv_SetEnabled(False);                                                     
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
Super.Trigger(Other,EventInstigator);                                       
if (IsServer()) {                                                           
sv_SetEnabled(True);                                                      
}
}
function PostBeginPlay() {
Effects = new (self) Class'Game_Effects';                                   
if (bBlockActors) {                                                         
mCollisionType = 2;                                                       
} else {                                                                    
if (bCollideActors) {                                                     
mCollisionType = 1;                                                     
} else {                                                                  
mCollisionType = 0;                                                     
}
}
if (SBRole == 9 || SBRole == 1) {                                           
sv_SetEnabled(IsEnabled);                                                 
}
if (IsClient()) {                                                           
cl_UpdateEnabledEffects();                                                
SetCollisionType(mCollisionType);                                         
Show(!bHidden,0.00000000);                                                
}
}
event cl_OnTick(float aDeltaTime) {
if (Effects != None) {                                                      
Effects.cl_OnTick(aDeltaTime);                                            
}
}
event cl_OnUpdate() {
Super.cl_OnUpdate();                                                        
}
event cl_OnBaseline() {
Super.cl_OnBaseline();                                                      
if (Effects != None) {                                                      
Effects.cl_OnBaseline();                                                  
}
cl_UpdateEnabledEffects();                                                  
SetCollisionType(mCollisionType);                                           
}
*/