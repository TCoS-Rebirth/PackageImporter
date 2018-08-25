﻿using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AI_StateSwitch : AIRegistered
    {
        [FoldoutGroup("AI_StateSwitch")]
        [TypeProxyDefinition(TypeName = "AIStateMachine")]
        public Type TriggeredStateMachine;

        public AI_StateSwitch()
        {
        }
    }
}
/*
protected function OnRegisterEmptied() {
GotoState('UninitializedState');                                            
}
state SwappedState {
event UnTrigger(Actor Other,Pawn EventInstigator) {
GotoState('UnswappedState');                                            
}
protected function OnRegister(RegisteredAI aRegisteredAI) {
local RegisteredStateSwitch lRegistered;
lRegistered = RegisteredStateSwitch(aRegisteredAI);                     
lRegistered.OldStateMachine = SwapStateMachine(lRegistered.Controller,new TriggeredStateMachine);
Debug("Swapped"
@ CharName(lRegistered.Controller)
@ "from"
@ string(lRegistered.OldStateMachine)
@ "to"
@ string(TriggeredStateMachine));
}
function BeginState() {
local int i;
local array<RegisteredAI> Register;
local RegisteredStateSwitch lRegistered;
Register = GetRegister();                                               
Debug("Swapping" @ string(Register.Length)
@ "NPCs");         
i = 0;                                                                  
while (i < Register.Length) {                                           
lRegistered = RegisteredStateSwitch(Register[i]);                     
lRegistered.OldStateMachine = SwapStateMachine(lRegistered.Controller,new TriggeredStateMachine);
Debug("Swapped"
@ CharName(lRegistered.Controller)
@ "from"
@ string(lRegistered.OldStateMachine)
@ "to"
@ string(TriggeredStateMachine));
i++;                                                                  
}
if (NextScript != None && ChangeAllToNextScript()) {                    
GotoState('UninitializedState');                                      
}
}
}
state UnswappedState {
event Trigger(Actor Other,Pawn EventInstigator) {
GotoState('SwappedState');                                              
}
function BeginState() {
local int i;
local array<RegisteredAI> Register;
local RegisteredStateSwitch lRegistered;
Register = GetRegister();                                               
Debug("Unswapping" @ string(Register.Length)
@ "NPCs");       
i = 0;                                                                  
while (i < Register.Length) {                                           
lRegistered = RegisteredStateSwitch(Register[i]);                     
if (lRegistered.OldStateMachine != None) {                            
Debug("Swapping"
@ CharName(lRegistered.Controller)
@ "back to"
@ string(lRegistered.OldStateMachine));
SwapStateMachine(lRegistered.Controller,lRegistered.OldStateMachine);
}
i++;                                                                  
}
}
}
auto state UninitializedState {
protected function OnRegister(RegisteredAI aRegisteredAI) {
GotoState('UnswappedState');                                            
}
}
*/