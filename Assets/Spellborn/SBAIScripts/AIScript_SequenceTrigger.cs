using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_SequenceTrigger : AI_Script
    {
        [FoldoutGroup("SequenceTrigger")]
        public string SolvedEvent = string.Empty;

        [FoldoutGroup("SequenceTrigger")]
        public string SolvedUnEvent = string.Empty;

        [FoldoutGroup("SequenceTrigger")]
        public string ErrorEvent = string.Empty;

        [FoldoutGroup("SequenceTrigger")]
        public string ErrorUnEvent = string.Empty;

        [FoldoutGroup("SequenceTrigger")]
        public int CheckInterval;

        [FoldoutGroup("SequenceTrigger")]
        public bool ResetOnError;

        [FoldoutGroup("SequenceTrigger")]
        public bool UseOnlyOnce;

        [FoldoutGroup("SequenceTrigger")]
        public bool UntriggerResets;

        [FoldoutGroup("SequenceTrigger")]
        public List<SequenceItem> Sequence = new List<SequenceItem>();

        public int SequenceIndex;

        public int TriggerIndex;

        public bool Disabled;

        public AIScript_SequenceTrigger()
        {
        }

        [Serializable] public struct SequenceItem
        {
            public Actor TriggerActor;

            public string ResetEvent;
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local int i;
local ActorRelation newRelation;
Super.GetActorRelations(oRelations);                                        
i = 0;                                                                      
while (i < Sequence.Length) {                                               
GetTaggedRelations(Sequence[i].ResetEvent,static.RGB(100,100,255),"ResetEvent:" @ Sequence[i].ResetEvent,oRelations);
if (Sequence[i].TriggerActor != None) {                                   
newRelation.mActor = Sequence[i].TriggerActor;                          
newRelation.mDescription = "[Sirenix.OdinInspector.FoldoutGroup(" $ string(i + 1) $ "]";                   
newRelation.mColour = static.RGB(100,255,100);                          
oRelations[oRelations.Length] = newRelation;                            
}
i++;                                                                      
}
GetTaggedRelations(SolvedEvent,static.RGB(100,100,255),"SolvedEvent:" @ SolvedEvent,oRelations);
GetTaggedRelations(ErrorEvent,static.RGB(100,100,255),"ErrorEvent:" @ ErrorEvent,oRelations);
GetTaggedRelations(SolvedUnEvent,static.RGB(255,100,100),"SolvedUnEvent:" @ SolvedUnEvent,oRelations);
GetTaggedRelations(ErrorUnEvent,static.RGB(255,100,100),"ErrorUnEvent:" @ ErrorUnEvent,oRelations);
}
function ResetSequence() {
local int i;
i = 0;                                                                      
while (i < Sequence.Length) {                                               
if (Sequence[i].ResetEvent != ""
&& Sequence[i].ResetEvent != "none") {
TriggerEvent(name(Sequence[i].ResetEvent),self,None);                   
}
i++;                                                                      
}
SequenceIndex = 0;                                                          
TriggerIndex = 0;                                                           
}
function ItemsMismatched() {
if (ErrorEvent != "" && ErrorEvent != "none") {                             
TriggerEvent(name(ErrorEvent),self,None);                                 
}
if (ErrorUnEvent != "" && ErrorUnEvent != "none") {                         
UntriggerEvent(name(ErrorUnEvent),self,None);                             
}
if (ResetOnError) {                                                         
ResetSequence();                                                          
}
}
function SequenceSolved() {
if (SolvedEvent != "" && SolvedEvent != "none") {                           
TriggerEvent(name(SolvedEvent),self,None);                                
}
if (SolvedUnEvent != "" && SolvedUnEvent != "none") {                       
UntriggerEvent(name(SolvedUnEvent),self,None);                            
}
if (UseOnlyOnce) {                                                          
Disabled = True;                                                          
}
ResetSequence();                                                            
}
function ItemsMatched() {
if (SequenceIndex == Sequence.Length) {                                     
SequenceSolved();                                                         
}
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
if (UntriggerResets) {                                                      
ResetSequence();                                                          
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
if (!Disabled) {                                                            
TriggerIndex++;                                                           
Debug("Triggered by" @ string(Other) @ "expecting"
@ string(Sequence[SequenceIndex].TriggerActor));
if (Other == Sequence[SequenceIndex].TriggerActor) {                      
SequenceIndex++;                                                        
}
if (CheckInterval == 1
|| TriggerIndex % CheckInterval == 0
|| SequenceIndex == Sequence.Length
|| TriggerIndex == Sequence.Length) {
if (TriggerIndex == SequenceIndex) {                                    
ItemsMatched();                                                       
} else {                                                                
ItemsMismatched();                                                    
}
}
}
Debug("SEQUENCETRIGGER: triggered! other"
@ string(Other)
@ " item"
@ string(Sequence[SequenceIndex].TriggerActor)
@ "ti:"
@ string(TriggerIndex)
@ "si:"
@ string(SequenceIndex)
@ "mod:"
@ string((SequenceIndex + 1) % CheckInterval));
}
event PostBeginPlay() {
Super.PostBeginPlay();                                                      
if (Min(Max(CheckInterval,0),Sequence.Length) != CheckInterval) {           
Warning("Checkinterval was not in the [1, Sequence length] range!");      
CheckInterval = Min(Max(CheckInterval,0),Sequence.Length);                
}
}
*/