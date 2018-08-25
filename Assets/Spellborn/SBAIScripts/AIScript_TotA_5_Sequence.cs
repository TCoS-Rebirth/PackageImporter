﻿using System;
using System.Collections.Generic;
using SBAI;
using SBGamePlay;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_TotA_5_Sequence : AI_Script
    {
        [FoldoutGroup("AIScript_TotA_5_Sequence")]
        public List<Spawn_Deployer> Spawners = new List<Spawn_Deployer>();

        [FoldoutGroup("AIScript_TotA_5_Sequence")]
        public string SpawnEvent = string.Empty;

        [FoldoutGroup("AIScript_TotA_5_Sequence")]
        public string FinishEvent = string.Empty;

        [FoldoutGroup("AIScript_TotA_5_Sequence")]
        public string SuccesEvent = string.Empty;

        [FoldoutGroup("AIScript_TotA_5_Sequence")]
        public string FailEvent = string.Empty;

        [FoldoutGroup("AIScript_TotA_5_Sequence")]
        public string SpawnerSelectedEvent = string.Empty;

        public List<TotA_5_Enemy> Enemies = new List<TotA_5_Enemy>();

        public int TargetSpawnerID;

        public int CurrentSpawnerID;

        public AIScript_TotA_5_Sequence()
        {
        }

        [Serializable] public struct TotA_5_Enemy
        {
            public Game_AIController Controller;

            public int SpawnerID;
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(SpawnEvent,static.RGB(100,100,255),"SpawnEvent:" @ SpawnEvent,oRelations);
GetTaggedRelations(FinishEvent,static.RGB(100,100,255),"FinishEvent:" @ FinishEvent,oRelations);
GetTaggedRelations(SuccesEvent,static.RGB(100,100,255),"SuccesEvent:" @ SuccesEvent,oRelations);
GetTaggedRelations(FailEvent,static.RGB(100,100,255),"FailEvent:" @ FailEvent,oRelations);
GetTaggedRelations(SpawnerSelectedEvent,static.RGB(100,100,255),"SpawnerSelectedEvent:" @ SpawnerSelectedEvent,oRelations);
}
function bool OnCheckFriendly(Game_AIController aController,Game_Pawn potentialAlly) {
if (IsFromCurrentSpawner(aController)
&& potentialAlly.IsA('Game_PlayerPawn')) {
return False;                                                             
} else {                                                                    
return True;                                                              
}
}
function bool OnCheckEnemy(Game_AIController aController,Game_Pawn potentialEnemy) {
if (IsFromCurrentSpawner(aController)
&& potentialEnemy.IsA('Game_PlayerPawn')) {
return True;                                                              
} else {                                                                    
return False;                                                             
}
}
function bool OnDebuff(Game_AIController Victim,Game_Pawn aInstigator,export editinline FSkill_EffectClass aEffect,float aValue) {
DetermineCurrentSpawner(Victim);                                            
if (IsFromCurrentSpawner(Victim)) {                                         
return Super.OnDebuff(Victim,aInstigator,aEffect,aValue);                 
} else {                                                                    
return True;                                                              
}
}
function bool OnBuff(Game_AIController Victim,Game_Pawn aInstigator,export editinline FSkill_EffectClass aEffect,float aValue) {
DetermineCurrentSpawner(Victim);                                            
if (IsFromCurrentSpawner(Victim)) {                                         
return Super.OnBuff(Victim,aInstigator,aEffect,aValue);                   
} else {                                                                    
return True;                                                              
}
}
function bool OnDamage(Game_AIController Victim,Actor cause,float aDamage) {
DetermineCurrentSpawner(Victim);                                            
if (IsFromCurrentSpawner(Victim)) {                                         
return Super.OnDamage(Victim,cause,aDamage);                              
} else {                                                                    
return True;                                                              
}
}
function bool OnDeath(Game_AIController aController,Actor aCollaborator) {
local int i;
local int lEnemyID;
local int lEnemySpawnerID;
local bool notwiped;
lEnemyID = FindEnemyID(aController);                                        
if (lEnemyID >= 0) {                                                        
lEnemySpawnerID = Enemies[lEnemyID].SpawnerID;                            
Enemies.Remove(lEnemyID,1);                                               
i = 0;                                                                    
while (i < Enemies.Length) {                                              
if (Enemies[i].SpawnerID == CurrentSpawnerID) {                         
notwiped = True;                                                      
goto jl0084;                                                          
}
i++;                                                                    
}
if (!notwiped) {                                                          
if (lEnemySpawnerID == TargetSpawnerID) {                               
TargetSpawnerID++;                                                    
CurrentSpawnerID = -1;                                                
if (TargetSpawnerID == Spawners.Length) {                             
TriggerEvent(name(FinishEvent),self,None);                          
} else {                                                              
TriggerEvent(name(SuccesEvent),self,None);                          
}
} else {                                                                
TriggerEvent(name(FailEvent),self,None);                              
ResetFight();                                                         
}
}
}
return Super.OnDeath(aController,aCollaborator);                            
}
function bool IsFromCurrentSpawner(Game_AIController aController) {
local int i;
i = 0;                                                                      
while (i < Enemies.Length) {                                                
if (Enemies[i].Controller == aController) {                               
return Enemies[i].SpawnerID == CurrentSpawnerID;                        
}
i++;                                                                      
}
}
function DetermineCurrentSpawner(Game_AIController aController) {
local int i;
if (CurrentSpawnerID == -1) {                                               
i = 0;                                                                    
while (i < Enemies.Length) {                                              
if (Enemies[i].Controller == aController) {                             
CurrentSpawnerID = Enemies[i].SpawnerID;                              
TriggerEvent(name(SpawnerSelectedEvent),self,aController.Pawn);       
goto jl007F;                                                          
}
i++;                                                                    
}
}
}
function int FindEnemyID(Game_AIController aController) {
local int i;
i = 0;                                                                      
while (i < Enemies.Length) {                                                
if (Enemies[i].Controller == aController) {                               
return i;                                                               
}
i++;                                                                      
}
return -1;                                                                  
}
function ResetFight() {
UntriggerEvent(name(SpawnEvent),self,None);                                 
Enemies.Length = 0;                                                         
}
event Trigger(Actor Other,Pawn EventInstigator) {
TargetSpawnerID = 0;                                                        
CurrentSpawnerID = -1;                                                      
Enemies.Length = 0;                                                         
TriggerEvent(name(SpawnEvent),self,None);                                   
}
function OnBegin(Game_AIController aController) {
local int i;
local int j;
Super.OnBegin(aController);                                                 
Enemies.Insert(Enemies.Length,1);                                           
Enemies[Enemies.Length - 1].Controller = aController;                       
i = 0;                                                                      
while (i < Spawners.Length) {                                               
j = 0;                                                                    
while (j < Spawners[i].Spawns.Length) {                                   
if (aController == Spawners[i].Spawns[j]) {                             
Enemies[Enemies.Length - 1].SpawnerID = i;                            
goto jl00BA;                                                          
}
j++;                                                                    
}
i++;                                                                      
}
}
*/