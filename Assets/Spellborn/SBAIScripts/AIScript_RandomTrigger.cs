﻿using System;
using System.Collections.Generic;
using SBAI;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_RandomTrigger : AI_Script
    {
        [FoldoutGroup("RandomTrigger")]
        public List<RandomEvent> RandomEvents = new List<RandomEvent>();

        public int TotalChance;

        public AIScript_RandomTrigger()
        {
        }

        [Serializable] public struct RandomEvent
        {
            public string Event;

            public string UnEvent;

            public int Chance;
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local int i;
Super.GetActorRelations(oRelations);                                        
i = 0;                                                                      
while (i < RandomEvents.Length) {                                           
GetTaggedRelations(RandomEvents[i].Event,static.RGB(100,100,255),string(RandomEvents[i].Chance) @ "Event:"
@ RandomEvents[i].Event,oRelations);
GetTaggedRelations(RandomEvents[i].UnEvent,static.RGB(100,100,255),string(RandomEvents[i].Chance) @ "UnEvent:"
@ RandomEvents[i].UnEvent,oRelations);
i++;                                                                      
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
local int i;
local int pick;
local int lastChance;
Super.Trigger(Other,EventInstigator);                                       
lastChance = 0;                                                             
pick = Rand(TotalChance);                                                   
i = 0;                                                                      
while (i < RandomEvents.Length) {                                           
if (pick >= lastChance && pick < RandomEvents[i].Chance) {                
if (RandomEvents[i].Event != ""
&& RandomEvents[i].Event != "none") {
TriggerEvent(name(RandomEvents[i].Event),EventInstigator,None);       
}
if (RandomEvents[i].UnEvent != ""
&& RandomEvents[i].UnEvent != "none") {
UntriggerEvent(name(RandomEvents[i].UnEvent),EventInstigator,None);   
}
goto jl012D;                                                            
}
lastChance = RandomEvents[i].Chance;                                      
i++;                                                                      
}
}
event PostBeginPlay() {
local int i;
Super.PostBeginPlay();                                                      
TotalChance = 0;                                                            
i = 0;                                                                      
while (i < RandomEvents.Length) {                                           
RandomEvents[i].Chance += TotalChance;                                    
TotalChance = RandomEvents[i].Chance;                                     
i++;                                                                      
}
}
*/