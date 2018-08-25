﻿using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_MatineeTrigger : AI_Script
    {
        [FoldoutGroup("AIScript_MatineeTrigger")]
        public string MatineeTag = string.Empty;

        [FoldoutGroup("AIScript_MatineeTrigger")]
        public float MatineeDuration;

        [FoldoutGroup("AIScript_MatineeTrigger")]
        [FieldConst()]
        public string EndTriggerEvent = string.Empty;

        [FoldoutGroup("AIScript_MatineeTrigger")]
        [FieldConst()]
        public string EndUnTriggerEvent = string.Empty;

        public List<Game_PlayerPawn> FrozenPawns = new List<Game_PlayerPawn>();

        public float MatineeTimer;

        public bool MatineePlaying;

        public AIScript_MatineeTrigger()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(EndTriggerEvent,static.RGB(100,100,255),"EndTriggerEvent:" @ EndTriggerEvent,oRelations);
GetTaggedRelations(EndUnTriggerEvent,static.RGB(255,100,100),"EndUnTriggerEvent:" @ EndTriggerEvent,oRelations);
GetTaggedRelations(MatineeTag,static.RGB(100,255,100),"Matinee:" @ MatineeTag,oRelations);
}
event Trigger(Actor Other,Pawn EventInstigator) {
local Game_PlayerPawn playerPawn;
if (!MatineePlaying) {                                                      
foreach AllActors(Class'Game_PlayerPawn',playerPawn) {                    
FrozenPawns[FrozenPawns.Length] = playerPawn;                           
SetFreeze(playerPawn,True,True,True,True,True);                         
ClientSideTrigger(None,MatineeTag,playerPawn);                          
}
MatineeTimer = 0.00000000;                                                
MatineePlaying = True;                                                    
goto jl0066;                                                              
}
}
protected event sv_OnScriptFrame(float aDelta) {
local int i;
if (MatineePlaying) {                                                       
MatineeTimer += aDelta;                                                   
if (MatineeTimer > MatineeDuration) {                                     
i = 0;                                                                  
while (i < FrozenPawns.Length) {                                        
SetFreeze(FrozenPawns[i],False,True,True,True,True);                  
i++;                                                                  
}
FrozenPawns.Length = 0;                                                 
TriggerEvent(name(EndTriggerEvent),self,None);                          
UntriggerEvent(name(EndUnTriggerEvent),self,None);                      
MatineePlaying = False;                                                 
}
}
}
*/