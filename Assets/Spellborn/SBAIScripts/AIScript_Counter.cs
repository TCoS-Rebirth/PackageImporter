using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_Counter : AI_Script
    {
        [FoldoutGroup("Counter")]
        [FieldConst()]
        public int TotalCount;

        [FoldoutGroup("Counter")]
        [FieldConst()]
        public float TimeFrame;

        [FoldoutGroup("Counter")]
        [FieldConst()]
        public bool UseTimeFrame;

        [FoldoutGroup("Counter")]
        [FieldConst()]
        public bool TriggerAble;

        [FoldoutGroup("Counter")]
        [FieldConst()]
        public bool ResetWhenCountIsReached;

        [FoldoutGroup("Counter")]
        [FieldConst()]
        public bool ResetOnUntrigger;

        [FoldoutGroup("Events")]
        [FieldConst()]
        public string UnEvent = string.Empty;

        public List<float> Timestamps = new List<float>();

        public float CurrentTime;

        public bool Active;

        public AIScript_Counter()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(UnEvent,static.RGB(255,100,100),"UnEvent:" @ UnEvent,oRelations);
}
function Reset() {
CurrentTime = 0.00000000;                                                   
Timestamps.Remove(0,Timestamps.Length);                                     
}
function FlushTimestamps() {
local int i;
local int TimestampsToRemove;
i = 0;                                                                      
while (i < Timestamps.Length) {                                             
Timestamps[i] -= CurrentTime;                                             
if (Timestamps[i] + TimeFrame < 0) {                                      
TimestampsToRemove++;                                                   
}
i++;                                                                      
}
if (TimestampsToRemove > 0) {                                               
Timestamps.Remove(0,TimestampsToRemove);                                  
}
CurrentTime = 0.00000000;                                                   
}
function DoCount() {
if (Active) {                                                               
Timestamps[Timestamps.Length] = CurrentTime;                              
if (UseTimeFrame) {                                                       
FlushTimestamps();                                                      
}
if (Timestamps.Length == TotalCount) {                                    
if (Event != 'None') {                                                  
TriggerEvent(Event,self,None);                                        
}
if (UnEvent != "none" && UnEvent != "") {                               
UntriggerEvent(name(UnEvent),self,None);                              
}
if (ResetWhenCountIsReached) {                                          
Reset();                                                              
}
}
}
}
protected event sv_OnScriptFrame(float DeltaTime) {
if (Active) {                                                               
CurrentTime += DeltaTime;                                                 
}
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
if (ResetOnUntrigger && TriggerAble
&& Active) {                      
Reset();                                                                  
Active = False;                                                           
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
if (TriggerAble && !Active) {                                               
Reset();                                                                  
Active = True;                                                            
}
}
event PostBeginPlay() {
Super.PostBeginPlay();                                                      
Active = !TriggerAble;                                                      
}
*/