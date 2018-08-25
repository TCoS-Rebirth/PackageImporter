﻿using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBAIScripts
{
    [Serializable] public class AIScript_DAF_Grome : AI_Script
    {
        [FoldoutGroup("Grome")]
        [FieldConst()]
        public NavigationPoint ActionCenter;

        [FoldoutGroup("Grome")]
        [FieldConst()]
        public float ActionRadius;

        [FoldoutGroup("Grome")]
        [FieldConst()]
        public string ActionOutsideRadiusEvent = string.Empty;

        [FoldoutGroup("Grome")]
        [FieldConst()]
        public FSkill_Type StartBuff;

        [FoldoutGroup("Grome")]
        [FieldConst()]
        public FSkill_EffectClass_AudioVisual GromeFreedEffect;

        [FoldoutGroup("Grome")]
        [FieldConst()]
        public float DefeatDelay;

        [FoldoutGroup("Grome")]
        [FieldConst()]
        public string DefeatEvent = string.Empty;

        [FoldoutGroup("Grome")]
        [FieldConst()]
        public string DemonGateUnEvent = string.Empty;

        [FoldoutGroup("Grome")]
        [FieldConst()]
        public NavigationPoint DemonGateAttackPoint;

        [FoldoutGroup("Grome")]
        [FieldConst()]
        public NavigationPoint DemonGateAttackTarget;

        [FoldoutGroup("Grome")]
        public FSkill_Type DemonGateAttackSkill;

        [FoldoutGroup("Grome")]
        [FieldConst()]
        public List<participant> Participants = new List<participant>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public participant Grome;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<participant> CurrentParticipants = new List<participant>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int ArrivedCounter;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public FSkill_Type CurrentSkill;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float WaitTimeOut;

        public AIScript_DAF_Grome()
        {
        }

        [Serializable] public struct participant
        {
            public NPC_Type NPCType;

            public FSkill_Type DiedBuff;

            public string DiedEvent;

            public string SpawnEvent;

            public Game_AIController Controller;

            public Vector StartLocation;
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local ActorRelation newRelation;
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(DefeatEvent,static.RGB(100,100,255),"DefeatEvent:" @ DefeatEvent,oRelations);
GetTaggedRelations(DemonGateUnEvent,static.RGB(255,100,100),"DemonGateUnEvent:" @ DemonGateUnEvent,oRelations);
if (ActionCenter != None) {                                                 
newRelation.mActor = ActionCenter;                                        
newRelation.mDescription = "ActionCenter";                                
newRelation.mColour = static.RGB(100,255,100);                            
oRelations[oRelations.Length] = newRelation;                              
}
if (DemonGateAttackPoint != None) {                                         
newRelation.mActor = DemonGateAttackPoint;                                
newRelation.mDescription = "DemonGateAttackPoint";                        
newRelation.mColour = static.RGB(100,255,100);                            
oRelations[oRelations.Length] = newRelation;                              
}
if (DemonGateAttackTarget != None) {                                        
newRelation.mActor = DemonGateAttackTarget;                               
newRelation.mDescription = "DemonGateAttackTarget";                       
newRelation.mColour = static.RGB(100,255,100);                            
oRelations[oRelations.Length] = newRelation;                              
}
}
function ApplySkillOnGrome(Game_AIController aController,export editinline FSkill_Type aSkill) {
if (CurrentSkill != None) {                                                 
RemoveSkillDuffs(Game_Pawn(Grome.Controller.Pawn),CurrentSkill);          
}
if (aSkill != None) {                                                       
ApplySkillEffects(aSkill,Game_Pawn(aController.Pawn),Game_Pawn(Grome.Controller.Pawn));
}
CurrentSkill = aSkill;                                                      
}
function bool OnDeath(Game_AIController aController,Actor aCollaborator) {
local int i;
i = 0;                                                                      
while (i < CurrentParticipants.Length) {                                    
if (aController == CurrentParticipants[i].Controller) {                   
ApplySkillOnGrome(CurrentParticipants[i].Controller,CurrentParticipants[i].DiedBuff);
TriggerEvent(name(CurrentParticipants[i].DiedEvent),None,None);         
CurrentParticipants.Remove(i,1);                                        
goto jl008A;                                                            
}
i++;                                                                      
}
if (CurrentParticipants.Length == 1) {                                      
GotoState('DefeatedWaitingState');                                        
}
return Super.OnDeath(aController,aCollaborator);                            
}
function bool OnDamage(Game_AIController aController,Actor cause,float aDamage) {
local int i;
switch (aController) {                                                      
case Grome.Controller :                                                   
i = 0;                                                                  
while (i < CurrentParticipants.Length) {                                
if (CurrentParticipants[i].Controller != Grome.Controller) {          
DealDamage(None,Game_Pawn(CurrentParticipants[i].Controller.Pawn),aDamage / (CurrentParticipants.Length - 1));
}
i++;                                                                  
}
return True;                                                            
default:                                                                  
return Super.OnDamage(aController,cause,aDamage);                       
}
}
}
function ResetEncounter() {
local int i;
ApplySkillOnGrome(Grome.Controller,StartBuff);                              
i = 0;                                                                      
while (i < CurrentParticipants.Length) {                                    
if (!HasPausedAI(CurrentParticipants[i].Controller)) {                    
PauseAI(CurrentParticipants[i].Controller);                             
}
if (CurrentParticipants[i].Controller != Grome.Controller) {              
SetDetection(CurrentParticipants[i].Controller,True);                   
}
SetHealth(CurrentParticipants[i].Controller,GetMaxHealth(CurrentParticipants[i].Controller));
i++;                                                                      
}
}
function InitParticipant(Game_AIController aController,out participant aParticipant) {
aParticipant.Controller = aController;                                      
aParticipant.StartLocation = aController.Pawn.Location;                     
CurrentParticipants.Insert(CurrentParticipants.Length,1);                   
CurrentParticipants[CurrentParticipants.Length - 1] = aParticipant;         
}
function OnBegin(Game_AIController aController) {
local int i;
Super.OnBegin(aController);                                                 
PauseAI(aController);                                                       
SetInvulnerable(aController,True);                                          
i = 0;                                                                      
while (i < Participants.Length) {                                           
if (Participants[i].NPCType == Game_NPCPawn(aController.Pawn).NPCType) {  
InitParticipant(aController,Participants[i]);                           
if (i == 0) {                                                           
Grome = Participants[0];                                              
}
}
i++;                                                                      
}
}
state DefeatedState {
function bool OnArrived(Game_AIController aController,SBPoint aControlPoint,SBPoint aDestinationPoint,Vector aLocation) {
PerformSkill(Grome.Controller,DemonGateAttackSkill,DemonGateAttackTarget.Location);
return OnArrived(aController,aControlPoint,aDestinationPoint,aLocation);
}
function bool OnStateSignal(Game_AIController aController,AIState aState,byte aSignal) {
if (aSignal == 13) {                                                    
UntriggerEvent(name(DemonGateUnEvent),None,None);                     
StopScript(Grome.Controller,self);                                    
}
return OnStateSignal(aController,aState,aSignal);                       
}
function BeginState() {
MoveTo(Grome.Controller,DemonGateAttackPoint.Location);                 
}
}
state DefeatedWaitingState {
event bool OnTick(Game_AIController aController,float DeltaTime) {
WaitTimeOut -= DeltaTime;                                               
if (WaitTimeOut <= 0) {                                                 
GotoState('DefeatedState');                                           
}
return OnTick(aController,DeltaTime);                                   
}
function BeginState() {
TriggerEvent(name(DefeatEvent),None,None);                              
ApplySkillOnGrome(Grome.Controller,None);                               
ApplyAudioVisualEffect(Game_Pawn(Grome.Controller.Pawn),GromeFreedEffect);
if (!HasPausedAI(Grome.Controller)) {                                   
PauseAI(Grome.Controller);                                            
}
WaitTimeOut = DefeatDelay;                                              
}
}
state ReturningState {
function bool OnArrived(Game_AIController aController,SBPoint aControlPoint,SBPoint aDestinationPoint,Vector aLocation) {
ArrivedCounter++;                                                       
if (ArrivedCounter == CurrentParticipants.Length) {                     
GotoState('ReturnedDelayState');                                      
}
return OnArrived(aController,aControlPoint,aDestinationPoint,aLocation);
}
function BeginState() {
local int i;
TriggerEvent(name(ActionOutsideRadiusEvent),None,None);                 
i = 0;                                                                  
while (i < CurrentParticipants.Length) {                                
PauseAI(CurrentParticipants[i].Controller);                           
MoveTo(CurrentParticipants[i].Controller,CurrentParticipants[i].StartLocation);
i++;                                                                  
}
ArrivedCounter = 0;                                                     
}
}
state FightingState {
event bool OnTick(Game_AIController aController,float DeltaTime) {
if (VSize(aController.Pawn.Location - ActionCenter.Location) > ActionRadius) {
Debug("GROME: too far away:" @ string(aController)
@ string(VSize(aController.Pawn.Location - ActionCenter.Location)));
GotoState('ReturningState');                                          
}
return OnTick(aController,DeltaTime);                                   
}
function ExitState() {
local int i;
i = 0;                                                                  
while (i < CurrentParticipants.Length) {                                
SetInvulnerable(CurrentParticipants[i].Controller,True);              
i++;                                                                  
}
}
function BeginState() {
local int i;
i = 0;                                                                  
while (i < CurrentParticipants.Length) {                                
if (HasPausedAI(CurrentParticipants[i].Controller)) {                 
ContinueAI(CurrentParticipants[i].Controller);                      
}
SetInvulnerable(CurrentParticipants[i].Controller,False);             
i++;                                                                  
}
}
}
state AlertState {
function bool OnDetectEnemy(Game_AIController aController,Game_Pawn anEnemy) {
if (aController != Grome.Controller) {                                  
GotoState('FightingState');                                           
}
return OnDetectEnemy(aController,anEnemy);                              
}
function BeginState() {
ResetEncounter();                                                       
}
}
state ReturnedDelayState {
event bool OnTick(Game_AIController aController,float DeltaTime) {
WaitTimeOut -= DeltaTime;                                               
if (WaitTimeOut <= 0
&& CurrentParticipants.Length == Participants.Length) {
GotoState('AlertState');                                              
}
return OnTick(aController,DeltaTime);                                   
}
function BeginState() {
local int i;
WaitTimeOut = DefeatDelay;                                              
if (CurrentParticipants.Length < Participants.Length) {                 
i = 0;                                                                
while (i < Participants.Length) {                                     
if (Participants[i].Controller == None
|| Participants[i].Controller.IsDead()) {
Debug("Spawn" @ Participants[i].SpawnEvent
@ string(Participants[i].Controller));
TriggerEvent(name(Participants[i].SpawnEvent),None,None);         
}
i++;                                                                
}
}
}
}
auto state InitialiseState {
event Trigger(Actor Other,Pawn EventInstigator) {
if (CurrentParticipants.Length == Participants.Length) {                
GotoState('ReturnedDelayState');                                      
}
}
}
*/