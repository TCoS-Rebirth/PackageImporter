﻿using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_AQOrmo_Ormoburu : AI_Script
    {
        [FoldoutGroup("Ormoburu")]
        [FieldConst()]
        public string SpawnBehindEvent = string.Empty;

        [FoldoutGroup("Ormoburu")]
        [FieldConst()]
        public List<RangedSpawn> SpawnRangeEvents = new List<RangedSpawn>();

        [FoldoutGroup("Ormoburu")]
        [FieldConst()]
        public Range SpawnInterval;

        [FoldoutGroup("Ormoburu")]
        [FieldConst()]
        public float InitialSpawnDelay;

        public Game_AIController OrmoController;

        public float SpawnTimeout;

        public AIScript_AQOrmo_Ormoburu()
        {
        }

        [Serializable] public struct RangedSpawn
        {
            public string Event;

            public Range Distance;
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local int i;
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(SpawnBehindEvent,static.RGB(100,100,255),"SpawnBehindEvent;:" @ SpawnBehindEvent,oRelations);
i = 0;                                                                      
while (i < SpawnRangeEvents.Length) {                                       
GetTaggedRelations(SpawnRangeEvents[i].Event,static.RGB(100,100,255),"SpawnRange" @ string(i) @ ":" @ SpawnRangeEvents[i].Event,oRelations);
i++;                                                                      
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
ChangeToNextScript(OrmoController);                                         
}
event bool OnTick(Game_AIController aController,float DeltaTime) {
local Game_PlayerController lController;
local float dist;
local int i;
SpawnTimeout -= DeltaTime;                                                  
if (SpawnTimeout <= 0) {                                                    
foreach AllActors(Class'Game_PlayerController',lController) {             
if ((aController.Pawn.Location - lController.Pawn.Location) Dot vector(aController.Pawn.Rotation) > 0) {
Debug("Spawn behind" @ string(name(SpawnBehindEvent))
@ string(lController.Pawn));
TriggerEvent(name(SpawnBehindEvent),lController.Pawn,None);           
} else {                                                                
dist = VSize(aController.Pawn.Location - lController.Pawn.Location);  
Debug("Distance spawn:" @ string(dist));                              
i = 0;                                                                
while (i < SpawnRangeEvents.Length) {                                 
if (dist >= SpawnRangeEvents[i].Distance.Min
&& dist < SpawnRangeEvents[i].Distance.Max) {
TriggerEvent(name(SpawnRangeEvents[i].Event),lController.Pawn,None);
PlayControllerAnimation(aController,RandomInt(1,2),Class'SBAnimationFlags'.57);
goto jl01D0;                                                      
}
i++;                                                                
}
}
}
SpawnTimeout = static.FRandRange(SpawnInterval.Min,SpawnInterval.Max);    
}
return Super.OnTick(aController,DeltaTime);                                 
}
event OnBegin(Game_AIController aController) {
local int i;
Super.OnBegin(aController);                                                 
i = 0;                                                                      
while (i < SpawnRangeEvents.Length) {                                       
i++;                                                                      
}
OrmoController = aController;                                               
SpawnTimeout = InitialSpawnDelay;                                           
SetInvulnerable(aController,True);                                          
}
*/