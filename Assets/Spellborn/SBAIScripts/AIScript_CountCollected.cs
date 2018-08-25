using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_CountCollected : AIScript_CollectEventinstigators
    {
        [FoldoutGroup("CollectEventinstigators")]
        public List<CountEvent> EventRanges = new List<CountEvent>();

        public int ActiveRange;

        public AIScript_CountCollected()
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
function HandleEventRanges(Game_Controller aInstigator) {
local int i;
local bool noRangeFound;
noRangeFound = True;                                                        
i = 0;                                                                      
while (i < EventRanges.Length) {                                            
if (Instigators.Length >= EventRanges[i].CountRange.Min
&& Instigators.Length <= EventRanges[i].CountRange.Max) {
if (ActiveRange != i) {                                                 
if (EventRanges[i].EnterEvent != ""
&& EventRanges[i].EnterEvent != "none") {
TriggerEvent(name(EventRanges[i].EnterEvent),self,aInstigator.Pawn);
}
if (EventRanges[i].EnterUnEvent != ""
&& EventRanges[i].EnterUnEvent != "none") {
TriggerEvent(name(EventRanges[i].EnterUnEvent),self,aInstigator.Pawn);
}
if (ActiveRange != -1) {                                              
if (EventRanges[ActiveRange].ExitEvent != ""
&& EventRanges[ActiveRange].ExitEvent != "none") {
TriggerEvent(name(EventRanges[ActiveRange].ExitEvent),self,aInstigator.Pawn);
}
if (EventRanges[ActiveRange].ExitUnEvent != ""
&& EventRanges[ActiveRange].ExitUnEvent != "none") {
UntriggerEvent(name(EventRanges[ActiveRange].ExitUnEvent),self,aInstigator.Pawn);
}
}
ActiveRange = i;                                                      
}
noRangeFound = False;                                                   
goto jl020F;                                                            
}
i++;                                                                      
}
if (noRangeFound) {                                                         
if (ActiveRange != -1) {                                                  
if (EventRanges[ActiveRange].ExitEvent != ""
&& EventRanges[ActiveRange].ExitEvent != "none") {
TriggerEvent(name(EventRanges[ActiveRange].ExitEvent),self,aInstigator.Pawn);
}
if (EventRanges[ActiveRange].ExitUnEvent != ""
&& EventRanges[ActiveRange].ExitUnEvent != "none") {
UntriggerEvent(name(EventRanges[ActiveRange].ExitUnEvent),self,aInstigator.Pawn);
}
}
ActiveRange = -1;                                                         
}
}
function RemoveInstigator(Game_Controller aInstigator) {
Super.RemoveInstigator(aInstigator);                                        
HandleEventRanges(aInstigator);                                             
}
function AddInstigator(Game_Controller aInstigator) {
Super.AddInstigator(aInstigator);                                           
HandleEventRanges(aInstigator);                                             
}
*/