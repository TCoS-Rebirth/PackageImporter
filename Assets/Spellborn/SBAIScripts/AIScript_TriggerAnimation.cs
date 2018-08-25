﻿using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_TriggerAnimation : AIRegistered
    {
        [FoldoutGroup("TriggerAnimation")]
        [FieldConst()]
        public byte combatMode;

        [FoldoutGroup("TriggerAnimation")]
        [FieldConst()]
        public Range DefaultDuration;

        [FoldoutGroup("TriggerAnimation")]
        [FieldConst()]
        public bool TriggerAble;

        [FoldoutGroup("TriggerAnimation")]
        [FieldConst()]
        public bool SyncAnimations;

        [FoldoutGroup("TriggerAnimation")]
        [FieldConst()]
        public List<AnimStruct> Animations = new List<AnimStruct>();

        [FoldoutGroup("TriggerAnimation")]
        [FieldConst()]
        public Actor Target;

        [FoldoutGroup("TriggerAnimation")]
        [FieldConst()]
        public float TargetDistance;

        [FoldoutGroup("TriggerAnimation")]
        [FieldConst()]
        public int MaxAnimations;

        public float GlobalAnimTimeout;

        public AIScript_TriggerAnimation()
        {
        }

        [Serializable] public struct AnimStruct
        {
            public byte variation;

            public byte flag1;

            public byte flag2;

            public byte flag3;

            public Range Duration;
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local ActorRelation newRelation;
Super.GetActorRelations(oRelations);                                        
if (Target != None) {                                                       
newRelation.mActor = Target;                                              
newRelation.mDescription = "Animation Target";                            
newRelation.mColour = static.RGB(100,255,100);                            
oRelations[oRelations.Length] = newRelation;                              
}
}
state AnimatingState {
event bool OnArrived(Game_AIController aController,SBPoint aControlPoint,SBPoint aDestinationPoint,Vector aLocation) {
local RegisteredAnimation lRegistered;
lRegistered = RegisteredAnimation(GetRegistration(aController));        
lRegistered.IsAnimating = True;                                         
lRegistered.Timeout = 0.00000000;                                       
lRegistered.InCorrectCombatMode = DrawWeapon(lRegistered.Controller,combatMode)
|| combatMode == 0;
return OnArrived(aController,aControlPoint,aDestinationPoint,aLocation);
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
if (TriggerAble) {                                                      
GotoState('InactiveState');                                           
}
}
function PlayAnimation(RegisteredAnimation aRegistered,AnimStruct anAnimation) {
if (MaxAnimations > 0
&& aRegistered.AnimationCount >= MaxAnimations) {
if (!ChangeToNextScript(aRegistered.Controller)) {                    
GotoState('InactiveState');                                         
}
} else {                                                                
if (aRegistered.InCorrectCombatMode) {                                
PlayControllerAnimation(aRegistered.Controller,anAnimation.variation,anAnimation.flag1,anAnimation.flag2,anAnimation.flag3);
aRegistered.AnimationCount++;                                       
} else {                                                              
aRegistered.InCorrectCombatMode = DrawWeapon(aRegistered.Controller,combatMode);
}
}
}
protected event sv_OnScriptFrame(float DeltaTime) {
local int i;
local int Anim;
local array<RegisteredAI> Register;
local RegisteredAnimation lRegistered;
Register = GetRegister();                                               
if (SyncAnimations) {                                                   
GlobalAnimTimeout -= DeltaTime;                                       
if (GlobalAnimTimeout <= 0) {                                         
Anim = Rand(Animations.Length);                                     
GlobalAnimTimeout = RandomFloat(Animations[Anim].Duration.Min,Animations[Anim].Duration.Max);
i = 0;                                                              
while (i < Register.Length) {                                       
lRegistered = RegisteredAnimation(Register[i]);                   
if (lRegistered.IsAnimating) {                                    
PlayAnimation(lRegistered,Animations[Anim]);                    
}
i++;                                                              
}
}
} else {                                                                
i = 0;                                                                
while (i < Register.Length) {                                         
lRegistered = RegisteredAnimation(Register[i]);                     
if (lRegistered.IsAnimating) {                                      
lRegistered.Timeout -= DeltaTime;                                 
if (lRegistered.Timeout <= 0) {                                   
Anim = Rand(Animations.Length);                                 
lRegistered.Timeout = RandomFloat(Animations[Anim].Duration.Min,Animations[Anim].Duration.Max);
PlayAnimation(lRegistered,Animations[Anim]);                    
}
}
i++;                                                                
}
}
}
function StopAnimatedNPC(RegisteredAnimation aRegistered) {
aRegistered.Timeout = 0.00000000;                                       
aRegistered.IsAnimating = False;                                        
if (!aRegistered.HadWeaponDrawn && combatMode != 0) {                   
sheathWeapon(aRegistered.Controller);                                 
}
if (HasPausedAI(aRegistered.Controller)) {                              
ContinueAI(aRegistered.Controller);                                   
}
}
function PrepareAnimatedNPC(RegisteredAnimation aRegistered) {
PauseAI(aRegistered.Controller);                                        
aRegistered.HadWeaponDrawn = HasWeaponDrawn(aRegistered.Controller);    
aRegistered.AnimationCount = 0;                                         
if (combatMode != 0) {                                                  
aRegistered.InCorrectCombatMode = DrawWeapon(aRegistered.Controller,combatMode);
} else {                                                                
if (aRegistered.HadWeaponDrawn) {                                     
sheathWeapon(aRegistered.Controller);                               
}
}
if (Target != None) {                                                   
aRegistered.IsAnimating = False;                                      
if (TargetDistance > 0) {                                             
SetTarget(aRegistered.Controller,Target);                           
MoveTo(aRegistered.Controller,Target.Location,TargetDistance);      
} else {                                                              
MoveTo(aRegistered.Controller,Target.Location);                     
}
} else {                                                                
aRegistered.IsAnimating = True;                                       
}
}
protected function OnRegister(RegisteredAI aRegisteredAI) {
PrepareAnimatedNPC(RegisteredAnimation(aRegisteredAI));                 
}
function EndState() {
local int i;
local array<RegisteredAI> Register;
local RegisteredAnimation lRegistered;
Register = GetRegister();                                               
i = 0;                                                                  
while (i < Register.Length) {                                           
lRegistered = RegisteredAnimation(Register[i]);                       
StopAnimatedNPC(lRegistered);                                         
i++;                                                                  
}
GlobalAnimTimeout = 0.00000000;                                         
}
function BeginState() {
local int i;
local array<RegisteredAI> Register;
local RegisteredAnimation lRegistered;
Debug("animatingstate");                                                
Register = GetRegister();                                               
i = 0;                                                                  
while (i < Register.Length) {                                           
lRegistered = RegisteredAnimation(Register[i]);                       
PrepareAnimatedNPC(lRegistered);                                      
i++;                                                                  
}
}
}
state InactiveState {
event Trigger(Actor Other,Pawn EventInstigator) {
Debug("trigger");                                                       
GotoState('AnimatingState');                                            
}
function BeginState() {
Debug("inactivestate");                                                 
}
}
auto state Initialize {
function BeginState() {
local int i;
i = 0;                                                                  
while (i < Animations.Length) {                                         
if (Animations[i].Duration.Min == 0
&& Animations[i].Duration.Max == 0) {
Animations[i].Duration = DefaultDuration;                           
}
i++;                                                                  
}
if (!TriggerAble) {                                                     
GotoState('AnimatingState');                                          
} else {                                                                
GotoState('InactiveState');                                           
}
}
}
*/