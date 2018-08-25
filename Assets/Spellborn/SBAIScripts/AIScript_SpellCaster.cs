﻿using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBAIScripts
{
    [Serializable] public class AIScript_SpellCaster : AI_Script
    {
        [FoldoutGroup("SpellCaster")]
        public List<FSkill_Type> CastSkills = new List<FSkill_Type>();

        [FoldoutGroup("SpellCaster")]
        public NPC_Type TargetNPCType;

        [FoldoutGroup("SpellCaster")]
        public Actor TargetActor;

        [FoldoutGroup("SpellCaster")]
        public byte EnemyDetection;

        [FoldoutGroup("SpellCaster")]
        public float CastIntervalMax;

        [FoldoutGroup("SpellCaster")]
        public float CastIntervalMin;

        [FoldoutGroup("SpellCaster")]
        public bool IsTriggerable;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<Caster> Casters = new List<Caster>();

        public bool IsActive;

        public AIScript_SpellCaster()
        {
        }

        [Serializable] public struct Caster
        {
            public Game_AIController Controller;

            public Vector CastLocation;

            public bool Casting;

            public bool Returning;
        }

        public enum ECasterEnemyDetection
        {
            CED_Default,

            CED_OnAttack,

            CED_OnAttackAny,

            CED_Never,
        }
    }
}
/*
function LookAtTarget(Game_AIController aController) {
local Actor Target;
if (TargetNPCType != None) {                                                
Target = GetNPC(TargetNPCType);                                           
}
if (Target == None && TargetActor != None) {                                
Target = TargetActor;                                                     
}
if (Target != None) {                                                       
SetTarget(aController,Target);                                            
goto jl005D;                                                              
}
}
function bool FindCasterIndex(Game_AIController aController,out int outIndex) {
local int i;
i = 0;                                                                      
while (i < Casters.Length) {                                                
if (Casters[i].Controller == aController) {                               
outIndex = i;                                                           
return True;                                                            
}
i++;                                                                      
}
outIndex = -1;                                                              
return False;                                                               
}
function bool OnDetectEnemy(Game_AIController aController,Game_Pawn aEnemy) {
local int casterIndex;
if (IsActive && EnemyDetection == 0
&& FindCasterIndex(aController,casterIndex)
&& Casters[casterIndex].Casting) {
if (Game_NPCPawn(aEnemy) == None
|| Game_NPCPawn(aEnemy).NPCType != TargetNPCType) {
SetCasting(aController,False);                                          
}
}
return Super.OnDetectEnemy(aController,aEnemy);                             
}
function bool OnCheckFriendly(Game_AIController aController,Game_Pawn potentialAlly) {
local int casterIndex;
if (FindCasterIndex(aController,casterIndex)) {                             
if (Game_NPCPawn(potentialAlly) != None
&& Game_NPCPawn(potentialAlly).NPCType == TargetNPCType) {
return True;                                                            
}
if (IsActive && EnemyDetection != 0
&& (Casters[casterIndex].Casting || EnemyDetection == 3)) {
return True;                                                            
}
}
return Super.OnCheckFriendly(aController,potentialAlly);                    
}
function bool OnCheckEnemy(Game_AIController aController,Game_Pawn potentialEnemy) {
local int casterIndex;
if (FindCasterIndex(aController,casterIndex)) {                             
if (Game_NPCPawn(potentialEnemy) != None
&& Game_NPCPawn(potentialEnemy).NPCType == TargetNPCType) {
return False;                                                           
}
if (IsActive && EnemyDetection != 0
&& (Casters[casterIndex].Casting || EnemyDetection == 3)) {
return False;                                                           
}
}
return Super.OnCheckEnemy(aController,potentialEnemy);                      
}
event OnEnd(Game_AIController aController) {
local int casterIndex;
if (FindCasterIndex(aController,casterIndex)) {                             
Casters.Remove(casterIndex,1);                                            
}
Super.OnEnd(aController);                                                   
}
event OnDespawn(Game_AIController aController) {
local int casterIndex;
if (FindCasterIndex(aController,casterIndex)) {                             
Casters.Remove(casterIndex,1);                                            
}
Super.OnDespawn(aController);                                               
}
function bool OnDeath(Game_AIController aController,Actor aCollaborator) {
local int casterIndex;
if (FindCasterIndex(aController,casterIndex)) {                             
Casters.Remove(casterIndex,1);                                            
}
return Super.OnDeath(aController,aCollaborator);                            
}
function bool OnDamage(Game_AIController Victim,Actor cause,float aDamage) {
local int i;
if (IsActive && EnemyDetection != 3) {                                      
i = 0;                                                                    
while (i < Casters.Length) {                                              
if (Casters[i].Casting
&& (EnemyDetection == 2
|| Casters[i].Controller == Victim)) {
SetCasting(Casters[i].Controller,False);                              
}
i++;                                                                    
}
}
return Super.OnDamage(Victim,cause,aDamage);                                
}
function bool OnStateSignal(Game_AIController aController,AIState aState,byte aSignal) {
local int casterIndex;
if (IsActive
&& FindCasterIndex(aController,casterIndex)) {           
switch (aSignal) {                                                        
case 13 :                                                               
if (Casters[casterIndex].Casting) {                                   
StartTimer(aController,'DoCast',static.FRandRange(CastIntervalMin,Max(CastIntervalMin,CastIntervalMax)));
}
break;                                                                
case 22 :                                                               
if (Casters[casterIndex].Returning && !Casters[casterIndex].Casting) {
SetCasting(aController,True);                                       
}
break;                                                                
case 7 :                                                                
if (!Casters[casterIndex].Casting) {                                  
if (!HasPausedAI(aController)) {                                    
PauseAI(aController);                                             
}
StopMovement(aController);                                          
Casters[casterIndex].Returning = True;                              
MoveTo(aController,Casters[casterIndex].CastLocation);              
}
break;                                                                
default:                                                                
}
}
return Super.OnStateSignal(aController,aState,aSignal);                     
}
function bool OnTimerEnded(Game_AIController aController,Actor aInstigator,name aTag) {
local int casterIndex;
local export editinline FSkill_Type Skill;
if (IsActive
&& FindCasterIndex(aController,casterIndex)
&& aInstigator == self
&& aTag == 'DoCast') {
if (Casters[casterIndex].Casting && CastSkills.Length > 0) {              
Skill = CastSkills[Rand(CastSkills.Length)];                            
if (CanPerformSkill(aController,Skill)) {                               
if (!HasPausedAI(aController)) {                                      
PauseAI(aController);                                               
}
LookAtTarget(aController);                                            
PerformSkill(aController,Skill,aController.Pawn.Location);            
if (EnemyDetection == 0 && HasPausedAI(aController)) {                
ContinueAI(aController);                                            
}
return False;                                                         
}
return True;                                                            
}
}
return False;                                                               
}
function SetCasting(Game_AIController aController,bool aCasting) {
local int casterIndex;
if (FindCasterIndex(aController,casterIndex)) {                             
if (!Casters[casterIndex].Casting && aCasting) {                          
Casters[casterIndex].Casting = True;                                    
Casters[casterIndex].Returning = False;                                 
if (!HasPausedAI(aController)) {                                        
PauseAI(aController);                                                 
}
DrawWeapon(aController,3);                                              
LookAtTarget(aController);                                              
StartTimer(aController,'DoCast',static.FRandRange(CastIntervalMin,Max(CastIntervalMin,CastIntervalMax)));
} else {                                                                  
if (Casters[casterIndex].Casting && !aCasting) {                        
StopTimer(aController,'DoCast');                                      
StopTimer(aController,'Return');                                      
Casters[casterIndex].Casting = False;                                 
if (HasPausedAI(aController)) {                                       
ContinueAI(aController);                                            
}
}
}
}
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
local int i;
if (IsTriggerable && IsActive) {                                            
IsActive = False;                                                         
i = 0;                                                                    
while (i < Casters.Length) {                                              
SetCasting(Casters[i].Controller,False);                                
i++;                                                                    
}
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
local int i;
if (IsTriggerable && !IsActive) {                                           
IsActive = True;                                                          
i = 0;                                                                    
while (i < Casters.Length) {                                              
Casters[i].Returning = True;                                            
Casters[i].Casting = False;                                             
if (!HasPausedAI(Casters[i].Controller)) {                              
PauseAI(Casters[i].Controller);                                       
}
MoveTo(Casters[i].Controller,Casters[i].CastLocation);                  
i++;                                                                    
}
}
}
function OnBegin(Game_AIController aController) {
Super.OnBegin(aController);                                                 
Casters.Insert(Casters.Length,1);                                           
Casters[Casters.Length - 1].Controller = aController;                       
Casters[Casters.Length - 1].CastLocation = aController.Pawn.Location;       
if (IsActive) {                                                             
SetCasting(aController,True);                                             
}
}
event PostBeginPlay() {
IsActive = !IsTriggerable;                                                  
Super.PostBeginPlay();                                                      
}
*/