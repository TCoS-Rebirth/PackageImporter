﻿using System;
using System.Collections.Generic;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AI_TriggerSkillEffects : AIRegistered
    {
        [FoldoutGroup("TriggerSkillEffects")]
        public bool ApplyOnBegin;

        [FoldoutGroup("TriggerSkillEffects")]
        public List<FSkill_Type> Skills = new List<FSkill_Type>();

        [FoldoutGroup("TriggerSkillEffects")]
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();

        [FoldoutGroup("TriggerSkillEffects")]
        public bool CheckRequirementsOnRemove;

        public AI_TriggerSkillEffects()
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
event UnTrigger(Actor Other,Pawn EventInstigator) {
local int i;
local int j;
local array<Game_AIController> registeredControllers;
registeredControllers = GetRegistered();                                    
if (!CheckRequirementsOnRemove
|| CheckRequirements(registeredControllers[i])) {
i = 0;                                                                    
while (i < registeredControllers.Length) {                                
j = 0;                                                                  
while (j < Skills.Length) {                                             
RemoveSkillDuffs(Game_Pawn(registeredControllers[i].Pawn),Skills[j]); 
j++;                                                                  
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
while (j < Skills.Length) {                                             
ApplySkillEffects(Skills[j],Game_Pawn(registeredControllers[i].Pawn),Game_Pawn(registeredControllers[i].Pawn));
j++;                                                                  
}
ChangeToNextScript(registeredControllers[i]);                           
}
i++;                                                                      
}
}
function OnBegin(Game_AIController aController) {
local int i;
Super.OnBegin(aController);                                                 
if (ApplyOnBegin && CheckRequirements(aController)) {                       
i = 0;                                                                    
while (i < Skills.Length) {                                               
if (Skills[i] != None) {                                                
ApplySkillEffects(Skills[i],Game_Pawn(aController.Pawn),Game_Pawn(aController.Pawn));
}
i++;                                                                    
}
ChangeToNextScript(aController);                                          
}
}
*/