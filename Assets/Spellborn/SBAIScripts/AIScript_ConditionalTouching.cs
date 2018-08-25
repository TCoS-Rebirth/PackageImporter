﻿using System;
using System.Collections.Generic;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_ConditionalTouching : AIRegistered
    {
        [FoldoutGroup("ConditionalTouching")]
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();

        [FoldoutGroup("ConditionalTouching")]
        public float TouchTime;

        public bool Active;

        public float TouchTimeOut;

        public AIScript_ConditionalTouching()
        {
        }
    }
}
/*
function AddTouchingNPC(RegisteredTouching aRegistered) {
aRegistered.WasTouching = SetTouching(aRegistered.Controller,True);         
}
function bool CheckRequirements(Game_AIController aController) {
local int reqI;
if (!aController.Pawn.IsA('Game_Pawn')) {                                   
return False;                                                             
}
if (Game_Pawn(aController.Pawn).SBRole == 1) {                              
reqI = 0;                                                                 
while (reqI < Requirements.Length) {                                      
if (Requirements[reqI] != None
&& !Requirements[reqI].CheckPawn(Game_Pawn(aController.Pawn))) {
return False;                                                         
}
reqI++;                                                                 
}
}
return True;                                                                
}
state TouchingState {
protected event sv_OnScriptFrame(float DeltaTime) {
TouchTimeOut -= DeltaTime;                                              
if (TouchTimeOut <= 0) {                                                
GotoState('DefaultState');                                            
}
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
GotoState('DefaultState');                                              
}
protected function OnRegister(RegisteredAI aRegistered) {
OnRegister(aRegistered);                                                
if (CheckRequirements(aRegistered.Controller)) {                        
AddTouchingNPC(RegisteredTouching(aRegistered));                      
}
}
function EndState() {
local int i;
local array<RegisteredAI> Register;
local RegisteredTouching lRegistered;
Register = GetRegister();                                               
i = 0;                                                                  
while (i < Register.Length) {                                           
lRegistered = RegisteredTouching(Register[i]);                        
SetTouching(lRegistered.Controller,lRegistered.WasTouching);          
ChangeToNextScript(lRegistered.Controller);                           
i++;                                                                  
}
}
}
auto state DefaultState {
event Trigger(Actor Other,Pawn EventInstigator) {
local int i;
local array<RegisteredAI> Register;
local RegisteredTouching lRegistered;
Register = GetRegister();                                               
i = 0;                                                                  
while (i < Register.Length) {                                           
lRegistered = RegisteredTouching(Register[i]);                        
if (CheckRequirements(lRegistered.Controller)) {                      
AddTouchingNPC(lRegistered);                                        
}
i++;                                                                  
}
TouchTimeOut = TouchTime;                                               
GotoState('TouchingState');                                             
}
}
*/