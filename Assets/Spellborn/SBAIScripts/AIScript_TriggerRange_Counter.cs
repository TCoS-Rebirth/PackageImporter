﻿using System;
using System.Collections.Generic;
using SBAI;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_TriggerRange_Counter : AI_Script
    {
        [FoldoutGroup("AIScript_TriggerRange_Counter")]
        public List<CountEvent> EventRanges = new List<CountEvent>();

        [FoldoutGroup("AIScript_TriggerRange_Counter")]
        public bool AllowNegativeCount;

        public int ActiveRange;

        public int Counted;

        public AIScript_TriggerRange_Counter()
        {
        }

        //[System.Serializable] public struct CountEvent
        //{

        //    public string EnterEvent;

        //    public string EnterUnEvent;

        //    public string ExitEvent;

        //    public string ExitUnEvent;

        //    public Range CountRange;
        //}
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local int i;
Super.GetActorRelations(oRelations);                                        
i = 0;                                                                      
while (i < EventRanges.Length) {                                            
GetTaggedRelations(EventRanges[i].EnterEvent,static.RGB(100,100,255),"EnterEvent:" @ EventRanges[i].EnterEvent,oRelations);
GetTaggedRelations(EventRanges[i].ExitEvent,static.RGB(100,100,255),"ExitEvent:" @ EventRanges[i].ExitEvent,oRelations);
GetTaggedRelations(EventRanges[i].EnterUnEvent,static.RGB(255,100,100),"EnterUnEvent:" @ EventRanges[i].EnterUnEvent,oRelations);
GetTaggedRelations(EventRanges[i].ExitUnEvent,static.RGB(255,100,100),"ExitUnEvent:" @ EventRanges[i].ExitUnEvent,oRelations);
i++;                                                                      
}
}
function HandleEventRanges() {
local int i;
local bool noRangeFound;
noRangeFound = True;                                                        
i = 0;                                                                      
while (i < EventRanges.Length) {                                            
if (Counted >= EventRanges[i].CountRange.Min
&& Counted <= EventRanges[i].CountRange.Max) {
if (ActiveRange != i) {                                                 
if (EventRanges[i].EnterEvent != ""
&& EventRanges[i].EnterEvent != "none") {
TriggerEvent(name(EventRanges[i].EnterEvent),self,None);            
}
if (EventRanges[i].EnterUnEvent != ""
&& EventRanges[i].EnterUnEvent != "none") {
TriggerEvent(name(EventRanges[i].EnterUnEvent),self,None);          
}
if (ActiveRange != -1) {                                              
if (EventRanges[ActiveRange].ExitEvent != ""
&& EventRanges[ActiveRange].ExitEvent != "none") {
TriggerEvent(name(EventRanges[ActiveRange].ExitEvent),None,None); 
}
if (EventRanges[ActiveRange].ExitUnEvent != ""
&& EventRanges[ActiveRange].ExitUnEvent != "none") {
UntriggerEvent(name(EventRanges[ActiveRange].ExitUnEvent),None,None);
}
}
ActiveRange = i;                                                      
}
noRangeFound = False;                                                   
goto jl01D9;                                                            
}
i++;                                                                      
}
if (noRangeFound) {                                                         
if (ActiveRange != -1) {                                                  
if (EventRanges[ActiveRange].ExitEvent != ""
&& EventRanges[ActiveRange].ExitEvent != "none") {
TriggerEvent(name(EventRanges[ActiveRange].ExitEvent),None,None);     
}
if (EventRanges[ActiveRange].ExitUnEvent != ""
&& EventRanges[ActiveRange].ExitUnEvent != "none") {
UntriggerEvent(name(EventRanges[ActiveRange].ExitUnEvent),None,None); 
}
}
ActiveRange = -1;                                                         
}
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
if (Counted > 0 || AllowNegativeCount) {                                    
Counted--;                                                                
HandleEventRanges();                                                      
}
Super.UnTrigger(Other,EventInstigator);                                     
}
event Trigger(Actor Other,Pawn EventInstigator) {
Super.Trigger(Other,EventInstigator);                                       
Counted++;                                                                  
HandleEventRanges();                                                        
}
*/