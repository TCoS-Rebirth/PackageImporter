﻿using System;
using Engine;
using SBAI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBAIScripts
{
    [Serializable] public class AIPatrolScript : AIRegistered
    {
        [FoldoutGroup("AIPatrolScript")]
        public PatrolPoint StartPoint;

        [FoldoutGroup("AIPatrolScript")]
        public bool TriggerAble;

        [FoldoutGroup("AIPatrolScript")]
        public float HabitatRange;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Game_AIController Leader;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public PatrolPoint CurrentPoint;

        public AIPatrolScript()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local ActorRelation newRelation;
Super.GetActorRelations(oRelations);                                        
if (StartPoint != None) {                                                   
newRelation.mActor = StartPoint;                                          
newRelation.mDescription = "StartPoint";                                  
newRelation.mColour = static.RGB(255,255,255);                            
oRelations[oRelations.Length] = newRelation;                              
}
}
protected function bool SpawnNear(Game_AIController aController,Vector aLocation,Rotator aRotation) {
local Vector loc;
local Vector Extent;
local Vector orgLocation;
Extent.X = aController.NPCType.GetCollisionRadius();                        
Extent.Y = Extent.X;                                                        
Extent.Z = aController.NPCType.GetCollisionHeight();                        
orgLocation = aController.Location;                                         
aController.SetLocation(aLocation);                                         
loc = Class'Content_API'.RandomRadiusLocation(aController,150.00000000,-1.00000000,True,Extent,True);
if (loc != vect(0.000000, 0.000000, 0.000000)) {                            
aController.SetLocation(loc);                                             
aController.SetRotation(aRotation);                                       
return True;                                                              
} else {                                                                    
aController.SetLocation(orgLocation);                                     
return False;                                                             
}
}
protected function Game_AIController FindNewLeader() {
local array<RegisteredAI> reg;
local int ri;
reg = GetRegister();                                                        
if (reg.Length == 1
&& !reg[ri].Controller.mStateMachine.IsA('AIGruntMachine')) {
return reg[0].Controller;                                                 
} else {                                                                    
ri = 0;                                                                   
while (ri < reg.Length) {                                                 
if (reg[ri].Controller.mStateMachine.IsA('AILeaderMachine')) {          
return reg[ri].Controller;                                            
} else {                                                                
if (!reg[ri].Controller.mStateMachine.IsA('AIGruntMachine')) {        
Warning("Group patrol has solo AI");                                
}
}
ri++;                                                                   
}
}
Debug("No new leader out of " @ string(reg.Length));                        
return None;                                                                
}
event bool OnCheckHabitat(Game_AIController aController,Vector aLocation,NPC_Habitat aHabitat) {
if (CurrentPoint != None) {                                                 
return VSize(aLocation - CurrentPoint.Location) < HabitatRange;           
} else {                                                                    
return Super.OnCheckHabitat(aController,aLocation,aHabitat);              
}
}
protected function SetHomeLocations() {
local array<RegisteredAI> reg;
local int ri;
reg = GetRegister();                                                        
ri = 0;                                                                     
while (ri < reg.Length) {                                                   
reg[ri].Controller.SetHomeLocation(reg[ri].Controller.Pawn.Location);     
ri++;                                                                     
}
}
protected function bool IsLeader(Game_AIController aGame_AIController) {
return Leader == aGame_AIController;                                        
}
protected function OnRegisterEmptied() {
Debug("No more NPCs. Script is being reset");                               
GotoState('Pending');                                                       
}
protected function OnUnRegister(RegisteredAI aRegisteredAI) {
Super.OnUnRegister(aRegisteredAI);                                          
if (!IsInState('Pending')
&& IsLeader(aRegisteredAI.Controller)) {    
Debug("Leader died:"
@ CharName(aRegisteredAI.Controller));       
GotoState('Stalled');                                                     
}
}
protected function OnRegister(RegisteredAI aRegisteredAI) {
OnUnRegister(aRegisteredAI);                                                
RegisteredPatrol(aRegisteredAI).HomeLocation = aRegisteredAI.Controller.GetHomeLocation();
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
GotoState('Finished');                                                      
}
state Finished {
function BeginState() {
local array<RegisteredAI> reg;
local int ri;
Debug("Finished");                                                      
reg = GetRegister();                                                    
CurrentPoint = None;                                                    
ri = 0;                                                                 
while (ri < reg.Length) {                                               
reg[ri].Controller.SetHomeLocation(RegisteredPatrol(reg[ri]).HomeLocation);
ri++;                                                                 
}
ri = 0;                                                                 
while (ri < reg.Length) {                                               
ChangeToNextScript(reg[ri].Controller);                               
ri++;                                                                 
}
TriggerEvent(Event,self,None);                                          
GotoState('Pending');                                                   
}
}
state Stalled {
function EndState() {
FrameOff();                                                             
}
protected event sv_OnScriptFrame(float DeltaTime) {
sv_OnScriptFrame(DeltaTime);                                            
Leader = FindNewLeader();                                               
if (Leader != None) {                                                   
if (Leader.GetActiveAIState().IsA('AIIdleState')) {                   
Debug("Stall ended, leader is idle, so continue patrolling");       
GotoState('Patrolling');                                            
} else {                                                              
Debug("Stall ended, leader is not idle, so continue interrupted");  
GotoState('Interrupted');                                           
}
}
}
function BeginState() {
Debug("Stalled");                                                       
FrameOn(0.50000000);                                                    
}
}
state Interrupted {
function bool OnSpawn(Game_AIController aSpawn,export editinline NPC_Type aType,Vector aLocation) {
return True;                                                            
}
function bool OnStateChange(Game_AIController aGame_AIController,AIState aState) {
if (aState.IsA('AIIdleState') && IsLeader(aGame_AIController)) {        
GotoState('Patrolling');                                              
}
return OnStateChange(aGame_AIController,aState);                        
}
function BeginState() {
Debug("Interrupted");                                                   
SetHomeLocations();                                                     
}
}
state Paused {
function bool OnSpawn(Game_AIController aSpawn,export editinline NPC_Type aType,Vector aLocation) {
return !SpawnNear(aSpawn,CurrentPoint.Location,aSpawn.Rotation);        
}
function bool OnStateComplete(Game_AIController aGame_AIController,AIState aState,byte aResult) {
if (aState.IsA('AIIdleState') && aResult == 5
&& IsLeader(aGame_AIController)) {
GotoState('Interrupted');                                             
}
return OnStateComplete(aGame_AIController,aState,aResult);              
}
function bool OnStateSignal(Game_AIController aGame_AIController,AIState aState,byte aSignal) {
if (aSignal == Class'AIState'.49 && IsLeader(aGame_AIController)
&& aGame_AIController.GetActiveAIState().IsA('AIIdleState')) {
Debug("Patrol: Continue, because we're bored");                       
GotoState('Patrolling');                                              
return True;                                                          
}
return OnStateSignal(aGame_AIController,aState,aSignal);                
}
function bool OnStateChange(Game_AIController aGame_AIController,AIState aState) {
if (aState.IsA('AIIdleState') && IsLeader(aGame_AIController)
&& !CurrentPoint.PausePatrolScript) {
GotoState('Patrolling');                                              
}
return OnStateChange(aGame_AIController,aState);                        
}
function BeginState() {
Debug("Paused");                                                        
SetHomeLocations();                                                     
}
}
state Patrolling {
function bool OnSpawn(Game_AIController aSpawn,export editinline NPC_Type aType,Vector aLocation) {
return !SpawnNear(aSpawn,Leader.Pawn.Location,Leader.Pawn.Rotation);    
}
function bool OnStateComplete(Game_AIController aGame_AIController,AIState aState,byte aResult) {
if (IsLeader(aGame_AIController)) {                                     
if (aState.IsA('AIPatrolState') && aResult == 5) {                    
CurrentPoint = aGame_AIController.mMovement.GetNextPatrolPoint();   
GotoState('Interrupted');                                           
Debug("Interrupted by end of state" @ string(aState));              
} else {                                                              
if (aState.IsA('AIStateMachine')) {                                 
GotoState('Interrupted');                                         
Debug("Interrupted by end of machine"
@ string(aState));
}
}
}
return OnStateComplete(aGame_AIController,aState,aResult);              
}
function bool OnArrived(Game_AIController aGame_AIController,SBPoint aControlPoint,SBPoint aDestinationPoint,Vector aLocation) {
if (aControlPoint == CurrentPoint) {                                    
Debug("Arrived at" @ string(aDestinationPoint));                      
CurrentPoint = PatrolPoint(aDestinationPoint);                        
if (CurrentPoint.GetControlDestination(Game_Pawn(aGame_AIController.Pawn)) == None) {
GotoState('Finished');                                              
} else {                                                              
GotoState('Paused');                                                
}
}
return OnArrived(aGame_AIController,aControlPoint,aDestinationPoint,aLocation);
}
function BeginState() {
Debug("Patrolling to:" @ string(CurrentPoint));                         
SetHomeLocations();                                                     
Patrol(Leader,CurrentPoint);                                            
}
}
auto state Pending {
function EndState() {
CurrentPoint = StartPoint;                                              
Leader = FindNewLeader();                                               
}
function Trigger(Actor aSource,Pawn aInstigator) {
if (TriggerAble && GetRegisterSize() > 0) {                             
GotoState('Patrolling');                                              
}
}
function OnBegin(Game_AIController aGame_AIController) {
OnBegin(aGame_AIController);                                            
if (!TriggerAble) {                                                     
GotoState('Patrolling');                                              
}
}
function BeginState() {
CurrentPoint = None;                                                    
Leader = None;                                                          
}
}
*/