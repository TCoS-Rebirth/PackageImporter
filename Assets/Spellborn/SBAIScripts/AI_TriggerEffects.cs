﻿using System;
using System.Collections.Generic;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AI_TriggerEffects : AIRegistered
    {
        [FoldoutGroup("TriggerEffects")]
        public bool EffectsArePermanent;

        [FoldoutGroup("TriggerEffects")]
        public bool ApplyOnBegin;

        [FoldoutGroup("TriggerEffects")]
        public bool RemoveOnDeathOrEnd;

        [FoldoutGroup("TriggerEffects")]
        public bool CheckRequirementsOnRemove;

        [FoldoutGroup("TriggerEffects")]
        public List<FSkill_EffectClass_AudioVisual> AudioVisualEffects = new List<FSkill_EffectClass_AudioVisual>();

        [FoldoutGroup("TriggerEffects")]
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();

        public AI_TriggerEffects()
        {
        }
    }
}
/*
function bool CheckRequirements(Game_AIController aController) {
local int reqI;
reqI = 0;                                                                   
while (reqI < Requirements.Length) {                                        
if (Requirements[reqI] != None
&& !Requirements[reqI].CheckPawn(Game_Pawn(aController.Pawn))) {
return False;                                                           
}
reqI++;                                                                   
}
return True;                                                                
}
function OnEnd(Game_AIController aController) {
if (EffectsArePermanent && RemoveOnDeathOrEnd
&& (!CheckRequirementsOnRemove || CheckRequirements(aController))) {
RemoveAudioVisualEffects(Game_Pawn(aController.Pawn));                    
}
Super.OnEnd(aController);                                                   
}
function bool OnDeath(Game_AIController aController,Actor aCollaborator) {
if (EffectsArePermanent && RemoveOnDeathOrEnd
&& (!CheckRequirementsOnRemove || CheckRequirements(aController))) {
RemoveAudioVisualEffects(Game_Pawn(aController.Pawn));                    
}
return Super.OnDeath(aController,aCollaborator);                            
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
local int i;
local array<Game_AIController> registeredControllers;
if (EffectsArePermanent) {                                                  
registeredControllers = GetRegistered();                                  
i = 0;                                                                    
while (i < registeredControllers.Length) {                                
if (!CheckRequirementsOnRemove
|| CheckRequirements(registeredControllers[i])) {
RemoveAudioVisualEffects(Game_Pawn(registeredControllers[i].Pawn));   
}
i++;                                                                    
}
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
local int i;
local int j;
local array<Game_AIController> registeredControllers;
registeredControllers = GetRegistered();                                    
i = 0;                                                                      
while (i < registeredControllers.Length) {                                  
if (CheckRequirements(registeredControllers[i])) {                        
j = 0;                                                                  
while (j < AudioVisualEffects.Length) {                                 
if (EffectsArePermanent) {                                            
ApplyAudioVisualEffect(Game_Pawn(registeredControllers[i].Pawn),AudioVisualEffects[j]);
} else {                                                              
ApplyOneShotAudioVisualEffect(Game_Pawn(registeredControllers[i].Pawn),AudioVisualEffects[j]);
}
j++;                                                                  
}
}
ChangeToNextScript(registeredControllers[i]);                             
i++;                                                                      
}
}
function OnBegin(Game_AIController aController) {
local int i;
Super.OnBegin(aController);                                                 
if (ApplyOnBegin && CheckRequirements(aController)) {                       
i = 0;                                                                    
while (i < AudioVisualEffects.Length) {                                   
if (AudioVisualEffects[i] != None) {                                    
if (EffectsArePermanent) {                                            
ApplyAudioVisualEffect(Game_Pawn(aController.Pawn),AudioVisualEffects[i]);
goto jl00A0;                                                        
}
ApplyOneShotAudioVisualEffect(Game_Pawn(aController.Pawn),AudioVisualEffects[i]);
}
i++;                                                                    
}
ChangeToNextScript(aController);                                          
}
}
*/