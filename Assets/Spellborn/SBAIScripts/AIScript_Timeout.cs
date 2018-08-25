﻿using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_Timeout : AIRegistered
    {
        [FoldoutGroup("Timeout")]
        [FieldConst()]
        public float Timeout;

        [FoldoutGroup("Timeout")]
        [FieldConst()]
        public float TimeoutRange;

        [FoldoutGroup("Timeout")]
        [FieldConst()]
        public bool TriggerAble;

        [FoldoutGroup("Timeout")]
        [FieldConst()]
        public bool StartOnAttach;

        [FoldoutGroup("Events")]
        [FieldConst()]
        public string UnEvent = string.Empty;

        public float CurrentTime;

        public AIScript_Timeout()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(UnEvent,static.RGB(255,100,100),"UnEvent:" @ UnEvent,oRelations);
}
state ActiveState {
protected event sv_OnScriptFrame(float DeltaTime) {
local int i;
local array<RegisteredAI> Register;
CurrentTime += DeltaTime;                                               
if (CurrentTime >= Timeout) {                                           
Debug("Timer ended after" @ string(CurrentTime)
@ "seconds");
if (GetRegisterSize() > 0) {                                          
Register = GetRegister();                                           
i = 0;                                                              
while (i < Register.Length) {                                       
ChangeToNextScript(Register[i].Controller);                       
i++;                                                              
}
}
TriggerEvent(Event,self,None);                                        
if (UnEvent != "None" && UnEvent != "") {                             
UntriggerEvent(name(UnEvent),self,None);                            
}
GotoState('InactiveState');                                           
}
}
protected function OnRegisterEmptied() {
GotoState('InactiveState');                                             
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
GotoState('InactiveState');                                             
}
event Trigger(Actor Other,Pawn EventInstigator) {
Debug("Reset timer because of trigger from"
@ string(EventInstigator));
ResetTimer();                                                           
}
function ResetTimer() {
CurrentTime = 0.00000000;                                               
if (TimeoutRange > 0) {                                                 
CurrentTime -= FRand() * TimeoutRange;                                
}
}
function BeginState() {
Debug("Timer started");                                                 
ResetTimer();                                                           
}
}
state InactiveState {
protected function OnRegister(RegisteredAI aRegisteredAI) {
if (StartOnAttach) {                                                    
GotoState('ActiveState');                                             
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
if (TriggerAble) {                                                      
GotoState('ActiveState');                                             
}
}
}
auto state Initialize {
function BeginState() {
if (TriggerAble || StartOnAttach) {                                     
GotoState('InactiveState');                                           
} else {                                                                
GotoState('ActiveState');                                             
}
}
}
*/