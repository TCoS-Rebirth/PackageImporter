﻿using System;
using System.Collections.Generic;
using Engine;
using Gameplay;
using SBGame;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBAIScripts
{
    [Serializable] public class AIScript_Group_Event_Manager : AIRegistered
    {
        [FoldoutGroup("Group_Event_Manager")]
        public string PlayerEnteredEvent = string.Empty;

        [FoldoutGroup("Group_Event_Manager")]
        public string PlayersExitedEvent = string.Empty;

        [FoldoutGroup("Group_Event_Manager")]
        public string PlayerEnteredUnEvent = string.Empty;

        [FoldoutGroup("Group_Event_Manager")]
        public string PlayersExitedUnEvent = string.Empty;

        [FoldoutGroup("Group_Event_Manager")]
        public bool DespawnOnPlayersExited;

        [FoldoutGroup("Group_Event_Manager")]
        public List<ScriptedTrigger> ScriptedTriggersToReset = new List<ScriptedTrigger>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<PlayerInRoom> PlayersInRoom = new List<PlayerInRoom>();

        public bool IsEnabled;

        public AIScript_Group_Event_Manager()
        {
        }

        [Serializable] public struct PlayerInRoom
        {
            public Game_PlayerPawn playerPawn;

            public List<Trigger> Triggers;
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(PlayerEnteredEvent,static.RGB(100,100,255),"PlayerEnteredEvent:" @ PlayerEnteredEvent,oRelations);
GetTaggedRelations(PlayersExitedEvent,static.RGB(100,100,255),"PlayersExitedEvent:" @ PlayersExitedEvent,oRelations);
}
function bool OnDebuff(Game_AIController Victim,Game_Pawn aInstigator,export editinline FSkill_EffectClass aEffect,float aValue) {
if (IsEnabled
&& aInstigator.IsA('Game_PlayerPawn')
&& !IsPlayerInRoom(Game_PlayerPawn(aInstigator))) {
return True;                                                              
} else {                                                                    
return Super.OnDebuff(Victim,aInstigator,aEffect,aValue);                 
}
}
function bool OnBuff(Game_AIController Victim,Game_Pawn aInstigator,export editinline FSkill_EffectClass aEffect,float aValue) {
if (IsEnabled
&& aInstigator.IsA('Game_PlayerPawn')
&& !IsPlayerInRoom(Game_PlayerPawn(aInstigator))) {
return True;                                                              
} else {                                                                    
return Super.OnBuff(Victim,aInstigator,aEffect,aValue);                   
}
}
function bool OnDamage(Game_AIController Victim,Actor cause,float aDamage) {
if (IsEnabled && cause.IsA('Game_PlayerPawn')
&& !IsPlayerInRoom(Game_PlayerPawn(cause))) {
return True;                                                              
} else {                                                                    
return Super.OnDamage(Victim,cause,aDamage);                              
}
}
function bool IsPlayerInRoom(Game_PlayerPawn aPlayerPawn) {
local int i;
local bool PlayerFound;
PlayerFound = False;                                                        
i = 0;                                                                      
while (i < PlayersInRoom.Length) {                                          
if (PlayersInRoom[i].playerPawn == aPlayerPawn) {                         
PlayerFound = True;                                                     
goto jl004E;                                                            
}
i++;                                                                      
}
return PlayerFound;                                                         
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
local int i;
local int j;
local Game_PlayerPawn lPlayerPawn;
local array<Game_AIController> registeredControllers;
if (IsEnabled) {                                                            
if (Other.IsA('Trigger')) {                                               
lPlayerPawn = Game_PlayerPawn(EventInstigator);                         
if (lPlayerPawn != None) {                                              
i = 0;                                                                
while (i < PlayersInRoom.Length) {                                    
if (PlayersInRoom[i].playerPawn == lPlayerPawn) {                   
j = 0;                                                            
while (j < PlayersInRoom[i].Triggers.Length) {                    
if (PlayersInRoom[i].Triggers[j] == Other) {                    
PlayersInRoom[i].Triggers.Remove(j,1);                        
goto jl00CF;                                                  
}
j++;                                                            
}
if (PlayersInRoom[i].Triggers.Length == 0) {                      
PlayersInRoom.Remove(i,1);                                      
Debug("Player Left Room");                                      
}
break;                                                            
}
i++;                                                                
}
}
} else {                                                                  
IsEnabled = False;                                                      
PlayersInRoom.Length = 0;                                               
}
if (PlayersInRoom.Length == 0) {                                          
Debug("All Players left the room");                                     
TriggerEvent(name(PlayersExitedEvent),self,EventInstigator);            
UntriggerEvent(name(PlayersExitedUnEvent),self,EventInstigator);        
i = 0;                                                                  
while (i < ScriptedTriggersToReset.Length) {                            
ScriptedTriggersToReset[i].Reset();                                   
i++;                                                                  
}
if (DespawnOnPlayersExited) {                                           
registeredControllers = GetRegistered();                              
i = 0;                                                                
while (i < registeredControllers.Length) {                            
Debug("despawning controller" @ string(i));                         
Despawn(registeredControllers[i]);                                  
i++;                                                                
}
}
}
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
local int i;
local int j;
local bool PlayerFound;
local bool TriggerFound;
local Game_PlayerPawn lPlayerPawn;
if (IsEnabled && Other.IsA('Trigger')) {                                    
lPlayerPawn = Game_PlayerPawn(EventInstigator);                           
if (lPlayerPawn != None && !lPlayerPawn.IsDead()) {                       
i = 0;                                                                  
while (i < PlayersInRoom.Length) {                                      
if (PlayersInRoom[i].playerPawn == lPlayerPawn) {                     
TriggerFound = False;                                               
j = 0;                                                              
while (j < PlayersInRoom[i].Triggers.Length) {                      
if (PlayersInRoom[i].Triggers[j] == Other) {                      
TriggerFound = True;                                            
goto jl00E0;                                                    
}
j++;                                                              
}
if (!TriggerFound) {                                                
PlayersInRoom[i].Triggers[PlayersInRoom[i].Triggers.Length] = Trigger(Other);
}
PlayerFound = True;                                                 
break;                                                              
}
i++;                                                                  
}
if (!PlayerFound) {                                                     
if (PlayersInRoom.Length == 0) {                                      
Debug("Player Entered Room");                                       
TriggerEvent(name(PlayerEnteredEvent),self,EventInstigator);        
UntriggerEvent(name(PlayerEnteredUnEvent),self,EventInstigator);    
}
PlayersInRoom.Insert(PlayersInRoom.Length,1);                         
PlayersInRoom[PlayersInRoom.Length - 1].playerPawn = lPlayerPawn;     
PlayersInRoom[PlayersInRoom.Length - 1].Triggers[PlayersInRoom[PlayersInRoom.Length - 1].Triggers.Length] = Trigger(Other);
}
}
}
}
*/