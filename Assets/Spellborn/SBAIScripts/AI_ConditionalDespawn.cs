﻿using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AI_ConditionalDespawn : AIRegistered
    {
        [FoldoutGroup("AI_ConditionalDespawn")]
        [FieldConst()]
        public float DespawnTimeout;

        [FoldoutGroup("AI_ConditionalDespawn")]
        [FieldConst()]
        [TypeProxyDefinition(TypeName = "AIState")]
        public List<Type> ResettingStates = new List<Type>();

        [FoldoutGroup("AI_ConditionalDespawn")]
        [FieldConst()]
        public bool TriggerAble;

        [FieldConst()]
        public NameProperty DespawnTag;

        public AI_ConditionalDespawn()
        {
        }
    }
}
/*
protected function OnRegisterEmptied() {
GotoState('UninitializedState');                                            
}
state ActiveState {
function EndState() {
StopTimers();                                                           
}
protected function StopTimers() {
local int i;
local array<Game_AIController> reg;
reg = GetRegistered();                                                  
i = 0;                                                                  
while (i < reg.Length) {                                                
StopTimer(reg[i],DespawnTag);                                         
i++;                                                                  
}
}
protected function StartTimers() {
local int i;
local array<Game_AIController> reg;
local AIState AIState;
reg = GetRegistered();                                                  
i = 0;                                                                  
while (i < reg.Length) {                                                
AIState = reg[i].GetActiveAIState();                                  
if (!CheckStates(reg[i],AIState)) {                                   
Debug("Starting with timer for" @ CharName(reg[i])
@ "in"
@ string(AIState));
StartTimer(reg[i],DespawnTag,DespawnTimeout);                       
} else {                                                              
Debug("Starting without timer for" @ CharName(reg[i])
@ "in"
@ string(AIState));
}
i++;                                                                  
}
}
protected function ResetTimers() {
StopTimers();                                                           
StartTimers();                                                          
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
GotoState('InactiveState');                                             
}
event Trigger(Actor Other,Pawn EventInstigator) {
Reset();                                                                
}
protected function bool CheckStates(Game_AIController aRegistered,AIState aCheckState) {
local int i;
if (aRegistered != None) {                                              
i = 0;                                                                
while (i < ResettingStates.Length) {                                  
if (aCheckState.IsA(ResettingStates[i].Name)
|| aCheckState == None && ResettingStates[i] == None) {
return True;                                                      
}
i++;                                                                
}
}
return False;                                                           
}
function bool OnStateComplete(Game_AIController aController,AIState aState,byte aResult) {
if (CheckStates(aController,aState)) {                                  
Debug("Restarting timer for" @ CharName(aController)
@ "after"
@ string(aState));
StartTimer(aController,DespawnTag,DespawnTimeout);                    
}
return OnStateComplete(aController,aState,aResult);                     
}
function bool OnStateBegin(Game_AIController aController,AIState aState) {
if (CheckStates(aController,aState)) {                                  
Debug("Stopping timer for" @ CharName(aController)
@ "in"
@ string(aState));
StopTimer(aController,DespawnTag);                                    
}
return OnStateBegin(aController,aState);                                
}
function bool OnTimerEnded(Game_AIController aController,Actor aInstigator,name aTag) {
if (aTag == DespawnTag) {                                               
Debug("Despawning" @ CharName(aController));                          
TriggerEvent(Event,self,aController.Pawn);                            
Despawn(aController);                                                 
return False;                                                         
} else {                                                                
return OnTimerEnded(aController,aInstigator,aTag);                    
}
}
function OnBegin(Game_AIController aController) {
local AIState AIState;
OnBegin(aController);                                                   
AIState = aController.GetActiveAIState();                               
if (!CheckStates(aController,AIState)) {                                
Debug("Starting timer for" @ CharName(aController)
@ "starting in"
@ string(AIState));
StartTimer(aController,DespawnTag,DespawnTimeout);                    
} else {                                                                
Debug("No timer for" @ CharName(aController)
@ "starting in"
@ string(AIState));
}
}
function BeginState() {
StartTimers();                                                          
}
}
state InactiveState {
event Trigger(Actor Other,Pawn EventInstigator) {
GotoState('ActiveState');                                               
}
}
auto state UninitializedState {
function OnBegin(Game_AIController aController) {
OnBegin(aController);                                                   
if (!TriggerAble) {                                                     
GotoState('ActiveState');                                             
}
}
function BeginState() {
if (TriggerAble) {                                                      
GotoState('InactiveState');                                           
}
}
}
*/