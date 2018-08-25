﻿using System;
using System.Collections.Generic;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AI_HealthLevel_Trigger : AIRegistered
    {
        [FoldoutGroup("AI_HealthLevel_Trigger")]
        public List<HealthLevelEvent> HealthLevelEvents = new List<HealthLevelEvent>();

        [FoldoutGroup("AI_HealthLevel_Trigger")]
        public bool InvulnerableOnFinalLevel;

        [FoldoutGroup("AI_HealthLevel_Trigger")]
        public bool TriggerOnlyOnce;

        [FoldoutGroup("AI_HealthLevel_Trigger")]
        public bool StartDeactivated;

        public AI_HealthLevel_Trigger()
        {
        }

        [Serializable] public struct HealthLevelEvent
        {
            public float HealthFraction;

            public NameProperty EventTag;

            public List<Content_Requirement> Requirements;
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local int i;
Super.GetActorRelations(oRelations);                                        
i = 0;                                                                      
while (i < HealthLevelEvents.Length) {                                      
GetTaggedRelations(string(HealthLevelEvents[i].EventTag),static.RGB(100,100,255),string(HealthLevelEvents[i].HealthFraction * 100)
$ "% Event:"
@ string(HealthLevelEvents[i].EventTag),oRelations);
i++;                                                                      
}
}
protected function OnRegister(RegisteredAI aRegisteredAI) {
local RegisteredHealthLevel lRegistered;
lRegistered = RegisteredHealthLevel(aRegisteredAI);                         
lRegistered.LastEventNum = -1;                                              
}
state DeactivatedState {
event Trigger(Actor Other,Pawn EventInstigator) {
GotoState('ActivatedState');                                            
}
}
state ActivatedState {
function bool CheckRequirements(HealthLevelEvent anEvent,Game_Pawn aPawn) {
local int reqI;
reqI = 0;                                                               
while (reqI < anEvent.Requirements.Length) {                            
if (anEvent.Requirements[reqI] != None
&& !anEvent.Requirements[reqI].CheckPawn(aPawn)) {
Debug(CharName(aPawn) @ "failed requirement [Sirenix.OdinInspector.FoldoutGroup("
$ string(reqI)
$ "] for event"
@ string(anEvent.EventTag));
return False;                                                       
}
reqI++;                                                               
}
if (anEvent.Requirements.Length > 0) {                                  
Debug(CharName(aPawn)
@ "made all requirements for event"
@ string(anEvent.EventTag));
}
return True;                                                            
}
function bool OnDamage(Game_AIController Victim,Actor cause,float aDamage) {
local float currentFraction;
local float nextFraction;
local int i;
local RegisteredHealthLevel lRegistered;
if (HealthLevelEvents.Length > 0) {                                     
lRegistered = RegisteredHealthLevel(GetRegistration(Victim));         
if (lRegistered != None) {                                            
currentFraction = GetHealth(Victim) / GetMaxHealth(Victim);         
nextFraction = (GetHealth(Victim) - aDamage) / GetMaxHealth(Victim);
i = 0;                                                              
while (i < HealthLevelEvents.Length) {                              
Debug("Health for" @ CharName(Victim)
@ "went from"
@ string(currentFraction)
@ "to"
@ string(nextFraction)
@ "by"
@ CharName(cause));
if (currentFraction > HealthLevelEvents[i].HealthFraction
&& HealthLevelEvents[i].HealthFraction >= nextFraction
&& CheckRequirements(HealthLevelEvents[i],Game_Pawn(cause))) {
if (!TriggerOnlyOnce || i > lRegistered.LastEventNum) {         
TriggerEvent(HealthLevelEvents[i].EventTag,Victim,Game_Controller(cause).Pawn);
lRegistered.LastEventNum = i;                                 
if (InvulnerableOnFinalLevel
&& i == HealthLevelEvents.Length - 1) {
ReceiveDamage(Victim,Game_Pawn(Game_Controller(cause).Pawn),GetHealth(Victim) - HealthLevelEvents[i].HealthFraction * GetMaxHealth(Victim));
return True;                                                
}
}
goto jl0215;                                                    
}
i++;                                                              
}
if (InvulnerableOnFinalLevel
&& currentFraction <= HealthLevelEvents[HealthLevelEvents.Length - 1].HealthFraction) {
return True;                                                      
}
}
}
return OnDamage(Victim,cause,aDamage);                                  
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
GotoState('DeactivatedState');                                          
}
}
auto state InitializeState {
function BeginState() {
local int i;
i = 0;                                                                  
while (i < HealthLevelEvents.Length) {                                  
if (HealthLevelEvents[i].HealthFraction < 0
|| HealthLevelEvents[i].HealthFraction > 1) {
Failure("HealthLevelEvents " $ string(i)
$ ", HealthFraction was not in the 0 to 1 range but"
@ string(HealthLevelEvents[i].HealthFraction)
@ "!");
}
i++;                                                                  
}
if (StartDeactivated) {                                                 
GotoState('DeactivatedState');                                        
} else {                                                                
GotoState('ActivatedState');                                          
}
}
}
*/