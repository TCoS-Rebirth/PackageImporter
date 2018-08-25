﻿using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_Trial50_Uddathin : AI_Script
    {
        [FoldoutGroup("uddathin")]
        public List<string> SpanwHeadEvents = new List<string>();

        [FoldoutGroup("uddathin")]
        public float AllHeadsEmergeDelay;

        [FoldoutGroup("uddathin")]
        public float IndividualHeadEmergeDelay;

        [FoldoutGroup("uddathin")]
        public string AllHeadsEmergeEvent = string.Empty;

        [FoldoutGroup("uddathin")]
        public string DeathEvent = string.Empty;

        [FoldoutGroup("uddathin")]
        public float AcidDamage;

        [FoldoutGroup("uddathin")]
        public float AcidDamageDelay;

        [FoldoutGroup("uddathin")]
        public SBMover AcidMover;

        public float HeadsEmergeTimeout;

        public float AcidDamageTimeout;

        public int CurrentHead;

        public byte UddathinState;

        public bool Active;

        public int AllHeadsDeathCounter;

        public Game_PlayerPawn playerPawn;

        public AIScript_Trial50_Uddathin()
        {
        }

        public enum EUddathinState
        {
            STATE_HIDDEN,

            STATE_WAITING_FOR_INDIVIDUAL_HEAD,

            STATE_INDIVIDUAL_HEADS,

            STATE_WAITING_FOR_ALL_HEADS,

            STATE_ALL_HEADS,
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local ActorRelation newRelation;
local int i;
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(AllHeadsEmergeEvent,static.RGB(100,100,255),"AllHeadsEmergeEvent:" @ AllHeadsEmergeEvent,oRelations);
GetTaggedRelations(DeathEvent,static.RGB(100,100,255),"DeathEvent:" @ DeathEvent,oRelations);
i = 0;                                                                      
while (i < SpanwHeadEvents.Length) {                                        
GetTaggedRelations(SpanwHeadEvents[i],static.RGB(100,100,255),"SpanwHead" @ string(i) @ "Event:"
@ SpanwHeadEvents[i],oRelations);
i++;                                                                      
}
if (AcidMover != None) {                                                    
newRelation.mActor = AcidMover;                                           
newRelation.mDescription = "AcidMover";                                   
newRelation.mColour = static.RGB(100,255,100);                            
oRelations[oRelations.Length] = newRelation;                              
}
}
function SpawnAllHeads() {
local Game_PlayerController lController;
local int i;
foreach AllActors(Class'Game_PlayerController',lController) {               
Game_Pawn(lController.Pawn).sv2clrel_PlayPawnEffect_CallStub(13);         
}
i = 0;                                                                      
while (i < SpanwHeadEvents.Length) {                                        
TriggerEvent(name(SpanwHeadEvents[i]),self,None);                         
i++;                                                                      
}
TriggerEvent(name(AllHeadsEmergeEvent),self,None);                          
UddathinState = 4;                                                          
}
function SpawnHead() {
TriggerEvent(name(SpanwHeadEvents[CurrentHead]),self,None);                 
}
event Trigger(Actor Other,Pawn EventInstigator) {
if (EventInstigator.IsA('Game_PlayerPawn')) {                               
playerPawn = Game_PlayerPawn(EventInstigator);                            
}
switch (UddathinState) {                                                    
case 0 :                                                                  
SpawnHead();                                                            
UddathinState = 2;                                                      
break;                                                                  
case 2 :                                                                  
CurrentHead += 1;                                                       
if (CurrentHead == SpanwHeadEvents.Length) {                            
UddathinState = 3;                                                    
HeadsEmergeTimeout = AllHeadsEmergeDelay;                             
} else {                                                                
UddathinState = 1;                                                    
HeadsEmergeTimeout = IndividualHeadEmergeDelay;                       
}
break;                                                                  
case 4 :                                                                  
AllHeadsDeathCounter += 1;                                              
if (AllHeadsDeathCounter == SpanwHeadEvents.Length) {                   
AcidMover.MoveTime = 10.00000000;                                     
TriggerEvent(name(DeathEvent),self,None);                             
}
break;                                                                  
default:                                                                  
}
}
protected event sv_OnScriptFrame(float DeltaTime) {
local float heightDiff;
switch (UddathinState) {                                                    
case 1 :                                                                  
HeadsEmergeTimeout -= DeltaTime;                                        
if (HeadsEmergeTimeout < 0) {                                           
SpawnHead();                                                          
UddathinState = 2;                                                    
}
break;                                                                  
case 3 :                                                                  
HeadsEmergeTimeout -= DeltaTime;                                        
if (HeadsEmergeTimeout < 0) {                                           
SpawnAllHeads();                                                      
UddathinState = 4;                                                    
}
break;                                                                  
case 4 :                                                                  
AcidDamageTimeout -= DeltaTime;                                         
heightDiff = playerPawn.Location.Z - playerPawn.CollisionHeight - AcidMover.Location.Z;
if (AcidDamageTimeout < 0) {                                            
if (heightDiff < 0) {                                                 
DealDamage(None,playerPawn,AcidDamage * -heightDiff);               
}
AcidDamageTimeout = AcidDamageDelay;                                  
}
default:                                                                  
}
}
event PostBeginPlay() {
local int i;
Super.PostBeginPlay();                                                      
UddathinState = 0;                                                          
i = 0;                                                                      
while (i < SpanwHeadEvents.Length) {                                        
i++;                                                                      
}
}
*/