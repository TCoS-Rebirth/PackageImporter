﻿using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class Trigger : Triggers
    {
        [FoldoutGroup("Trigger")]
        public ETriggerType TriggerType;

        [FoldoutGroup("Trigger")]
        public string Message = string.Empty;

        [FoldoutGroup("Trigger")]
        public bool bTriggerOnceOnly;

        [FoldoutGroup("Trigger")]
        public bool bInitiallyActive;

        [FoldoutGroup("Trigger")]
        [TypeProxyDefinition(TypeName = "Actor")]
        public Type ClassProximityType;

        [FoldoutGroup("Trigger")]
        public float RepeatTriggerTime;

        [FoldoutGroup("Trigger")]
        public float ReTriggerDelay;

        public Trigger()
        {
        }

        public enum ETriggerType
        {
            TT_PlayerProximity,

            TT_PawnProximity,

            TT_ClassProximity,

            TT_AnyProximity,

            TT_Shoot,

            TT_HumanPlayerProximity,

            TT_LivePlayerProximity,
        }
    }
}
/*
function UnTouch(Actor Other) {
if (IsRelevant(Other)) {                                                    
UntriggerEvent(Event,self,Other.Instigator);                              
}
}
function TakeDamage(int Damage,Pawn instigatedBy,Vector HitLocation,Vector Momentum,class<DamageType> DamageType) {
if (bInitiallyActive && TriggerType == 4
&& Damage >= DamageThreshold
&& instigatedBy != None) {
if (ReTriggerDelay > 0) {                                                 
if (Level.TimeSeconds - TriggerTime < ReTriggerDelay) {                 
return;                                                               
}
TriggerTime = Level.TimeSeconds;                                        
}
TriggerEvent(Event,self,instigatedBy);                                    
if (bTriggerOnceOnly) {                                                   
SetCollision(False);                                                    
}
}
}
function Timer() {
local bool bKeepTiming;
local Actor A;
bKeepTiming = False;                                                        
foreach TouchingActors(Class'Actor',A) {                                    
if (IsRelevant(A)) {                                                      
bKeepTiming = True;                                                     
Touch(A);                                                               
}
}
if (bKeepTiming) {                                                          
SetTimer(RepeatTriggerTime,False);                                        
}
}
function Touch(Actor Other) {
local int i;
if (IsRelevant(Other)) {                                                    
Other = FindInstigator(Other);                                            
if (ReTriggerDelay > 0) {                                                 
if (Level.TimeSeconds - TriggerTime < ReTriggerDelay) {                 
return;                                                               
}
TriggerTime = Level.TimeSeconds;                                        
}
TriggerEvent(Event,self,Other.Instigator);                                
if (Pawn(Other) != None && Pawn(Other).Controller != None) {              
i = 0;                                                                  
while (i < 4) {                                                         
if (Pawn(Other).Controller.GoalList[i] == self) {                     
Pawn(Other).Controller.GoalList[i] = None;                          
goto jl0112;                                                        
}
i++;                                                                  
}
}
if (bTriggerOnceOnly) {                                                   
SetCollision(False);                                                    
} else {                                                                  
if (RepeatTriggerTime > 0) {                                            
SetTimer(RepeatTriggerTime,False);                                    
}
}
}
}
function Actor FindInstigator(Actor Other) {
return Other;                                                               
}
function bool IsRelevant(Actor Other) {
local Actor Inst;
Inst = FindInstigator(Other);                                               
if (!bInitiallyActive) {                                                    
return False;                                                             
}
switch (TriggerType) {                                                      
case 5 :                                                                  
return Pawn(Other) != None
&& Pawn(Other).IsHumanControlled();
case 0 :                                                                  
return Pawn(Other) != None
&& (Pawn(Other).IsPlayerPawn() || Pawn(Other).WasPlayerPawn());
case 6 :                                                                  
return Pawn(Other) != None && Pawn(Other).IsPlayerPawn();               
case 1 :                                                                  
return Pawn(Other) != None && Pawn(Other).CanTrigger(self);             
case 2 :                                                                  
return ClassIsChildOf(Other.Class,ClassProximityType)
&& Pawn(Inst).IsPlayerPawn();
case 3 :                                                                  
return True;                                                            
default:                                                                  
}
}
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
if (Event == Tag) {                                                         
return;                                                                   
}
bInitiallyActive = False;                                                   
}
event Trigger(Actor Other,Pawn EventInstigator) {
local bool bWasActive;
if (Event == Tag) {                                                         
return;                                                                   
}
bWasActive = bInitiallyActive;                                              
bInitiallyActive = True;                                                    
if (!bWasActive) {                                                          
CheckTouchList();                                                         
}
}
function CheckTouchList() {
local Actor A;
foreach TouchingActors(Class'Actor',A) {                                    
Touch(A);                                                                 
}
}
function Actor SpecialHandling(Pawn Other) {
local Actor A;
if (bTriggerOnceOnly && !bCollideActors) {                                  
return None;                                                              
}
if (TriggerType == 5 && !Other.IsHumanControlled()) {                       
return None;                                                              
}
if (TriggerType == 0 && !Other.IsPlayerPawn()) {                            
return None;                                                              
}
if (!bInitiallyActive) {                                                    
if (TriggerActor == None) {                                               
FindTriggerActor();                                                     
}
if (TriggerActor == None) {                                               
return None;                                                            
}
if (TriggerActor2 != None
&& VSize(TriggerActor2.Location - Other.Location) < VSize(TriggerActor.Location - Other.Location)) {
return TriggerActor2;                                                   
} else {                                                                  
return TriggerActor;                                                    
}
}
if (TriggerType == 4) {                                                     
return self;                                                              
}
if (IsRelevant(Other)) {                                                    
foreach TouchingActors(Class'Actor',A) {                                  
if (A == Other) {                                                       
Touch(Other);                                                         
}
}
return self;                                                              
}
return self;                                                                
}
function FindTriggerActor() {
local Actor A;
TriggerActor = None;                                                        
TriggerActor2 = None;                                                       
foreach AllActors(Class'Actor',A) {                                         
if (A.Event == Tag) {                                                     
if (TriggerActor == None) {                                             
TriggerActor = A;                                                     
} else {                                                                
TriggerActor2 = A;                                                    
return;                                                               
}
}
}
}
function Reset() {
Super.Reset();                                                              
bInitiallyActive = bSavedInitialActive;                                     
SetCollision(bSavedInitialCollision,bBlockActors);                          
}
function PostBeginPlay() {
if (!bInitiallyActive) {                                                    
FindTriggerActor();                                                       
}
if (TriggerType == 4) {                                                     
bHidden = False;                                                          
bProjTarget = True;                                                       
SetDrawType(0);                                                           
}
bSavedInitialActive = bInitiallyActive;                                     
bSavedInitialCollision = bCollideActors;                                    
Super.PostBeginPlay();                                                      
}
function PreBeginPlay() {
Super.PreBeginPlay();                                                       
if (TriggerType == 0 || TriggerType == 1
|| TriggerType == 5
|| TriggerType == 6
|| TriggerType == 2
&& ClassIsChildOf(ClassProximityType,Class'Pawn')) {
OnlyAffectPawns(True);                                                    
}
}
function bool SelfTriggered() {
return bInitiallyActive;                                                    
}
function PlayerToucherDied(Pawn P) {
if (bInitiallyActive && TriggerType == 6) {                                 
UntriggerEvent(Event,self,P);                                             
}
}
state() OtherTriggerTurnsOff {
function Trigger(Actor Other,Pawn EventInstigator) {
bInitiallyActive = False;                                               
}
}
state() OtherTriggerTurnsOn {
function Trigger(Actor Other,Pawn EventInstigator) {
local bool bWasActive;
bWasActive = bInitiallyActive;                                          
bInitiallyActive = True;                                                
if (!bWasActive) {                                                      
CheckTouchList();                                                     
}
}
}
state() OtherTriggerToggles {
function Trigger(Actor Other,Pawn EventInstigator) {
bInitiallyActive = !bInitiallyActive;                                   
if (bInitiallyActive) {                                                 
CheckTouchList();                                                     
}
}
}
state() NormalTrigger {
}
*/