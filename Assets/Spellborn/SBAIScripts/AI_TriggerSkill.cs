﻿using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AI_TriggerSkill : AIRegistered
    {
        [FoldoutGroup("TriggerSkill")]
        public FSkill_Type Skill;

        [FoldoutGroup("TriggerSkill")]
        public Actor Target;

        [FoldoutGroup("TriggerSkill")]
        public float TickTime;

        [FoldoutGroup("TriggerSkill")]
        public bool UseGroundLocation;

        public Vector TargetLocation;

        public AI_TriggerSkill()
        {
        }
    }
}
/*
event UnTrigger(Actor Other,Pawn EventInstigator) {
local int i;
local array<RegisteredAI> Register;
local RegisteredSkillPerformer lRegistered;
Register = GetRegister();                                                   
i = 0;                                                                      
while (i < Register.Length) {                                               
lRegistered = RegisteredSkillPerformer(Register[i]);                      
if (lRegistered.Performing && !lRegistered.Returning) {                   
lRegistered.Performing = !FinishSkill(lRegistered);                     
}
i++;                                                                      
}
Super.UnTrigger(Other,EventInstigator);                                     
}
event Trigger(Actor Other,Pawn EventInstigator) {
local int i;
local array<RegisteredAI> Register;
local RegisteredSkillPerformer lRegistered;
Register = GetRegister();                                                   
i = 0;                                                                      
while (i < Register.Length) {                                               
lRegistered = RegisteredSkillPerformer(Register[i]);                      
if (!lRegistered.Performing) {                                            
lRegistered.StartWeaponDrawn = HasWeaponDrawn(lRegistered.Controller);  
lRegistered.Performing = True;                                          
}
i++;                                                                      
}
Super.Trigger(Other,EventInstigator);                                       
}
function bool OnArrived(Game_AIController aController,SBPoint aControlPoint,SBPoint aDestinationPoint,Vector aLocation) {
local RegisteredSkillPerformer lRegistered;
lRegistered = RegisteredSkillPerformer(GetRegistration(aController));       
if (lRegistered != None && lRegistered.Performing
&& lRegistered.Returning) {
FinishSkill(lRegistered);                                                 
lRegistered.Performing = False;                                           
lRegistered.Returning = False;                                            
}
return Super.OnArrived(aController,aControlPoint,aDestinationPoint,aLocation);
}
function bool OnStateSignal(Game_AIController aController,AIState aState,byte aSignal) {
local RegisteredSkillPerformer lRegistered;
lRegistered = RegisteredSkillPerformer(GetRegistration(aController));       
if (lRegistered != None && lRegistered.Performing
&& aSignal == 13) { 
lRegistered.Performing = !FinishSkill(lRegistered);                       
}
return Super.OnStateSignal(aController,aState,aSignal);                     
}
function bool FinishSkill(RegisteredSkillPerformer aRegistered) {
if (!aRegistered.Returning
&& aRegistered.StartLocation != vect(0.000000, 0.000000, 0.000000)) {
aRegistered.Returning = True;                                             
MoveTo(aRegistered.Controller,aRegistered.StartLocation);                 
return False;                                                             
}
if (HasPausedAI(aRegistered.Controller)) {                                  
if (!aRegistered.StartWeaponDrawn) {                                      
sheathWeapon(aRegistered.Controller);                                   
}
ContinueAI(aRegistered.Controller);                                       
}
aRegistered.StartLocation = vect(0.000000, 0.000000, 0.000000);             
aRegistered.Returning = False;                                              
aRegistered.TickTimer = 0.00000000;                                         
ChangeToNextScript(aRegistered.Controller);                                 
return True;                                                                
}
protected event sv_OnScriptFrame(float aDeltaTime) {
local float Distance;
local int i;
local array<RegisteredAI> Register;
local RegisteredSkillPerformer lRegistered;
Register = GetRegister();                                                   
i = 0;                                                                      
while (i < Register.Length) {                                               
lRegistered = RegisteredSkillPerformer(Register[i]);                      
if (lRegistered.Performing && !lRegistered.Returning) {                   
if (lRegistered.TickTimer < TickTime) {                                 
lRegistered.TickTimer += aDeltaTime;                                  
goto jl02DF;                                                          
}
lRegistered.TickTimer -= TickTime;                                      
if (!lRegistered.Controller.IsAIPaused()) {                             
Debug("pausing");                                                     
PauseAI(lRegistered.Controller);                                      
goto jl02DF;                                                          
}
if (!HasWeaponDrawn(lRegistered.Controller)) {                          
Debug("drawing");                                                     
DrawWeapon(lRegistered.Controller);                                   
} else {                                                                
LookAt(lRegistered.Controller,TargetLocation);                        
Distance = VSize(lRegistered.Controller.Pawn.Location - TargetLocation);
if (Distance < Skill.MinDistance || Distance > Skill.MaxDistance) {   
if (lRegistered.StartLocation == vect(0.000000, 0.000000, 0.000000)) {
lRegistered.StartLocation = lRegistered.Controller.Pawn.Location; 
}
MoveTo(lRegistered.Controller,TargetLocation,(Skill.MinDistance + Skill.MaxDistance) * 0.50000000);
Debug("approaching " @ string(Distance)
@ "between [Sirenix.OdinInspector.FoldoutGroup("
@ string(Skill.MinDistance)
@ "-"
@ string(Skill.MaxDistance)
@ "]");
} else {                                                              
if (CanPerformSkill(lRegistered.Controller,Skill)) {                
PerformSkill(lRegistered.Controller,Skill,TargetLocation);        
Debug("performing" @ string(Distance));                           
}
}
}
}
i++;                                                                      
}
}
event PostBeginPlay() {
if (Target == None) {                                                       
Failure("Target is not set!");                                            
} else {                                                                    
if (UseGroundLocation) {                                                  
TargetLocation = Class'Content_API'.ProjectLocationOnGround(Target,Target.Location);
} else {                                                                  
TargetLocation = Target.Location;                                       
}
}
}
*/