﻿using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_TotA_8_Sequence : AIRegistered
    {
        [FoldoutGroup("AIScript_TotA_8_Sequence")]
        public FSkill_Type ProtectionSkill;

        [FoldoutGroup("AIScript_TotA_8_Sequence")]
        public NavigationPoint CenterPoint;

        [FoldoutGroup("AIScript_TotA_8_Sequence")]
        public string BaseSpawnEventString = string.Empty;

        [FoldoutGroup("AIScript_TotA_8_Sequence")]
        public float RespawnTimeout;

        [FoldoutGroup("AIScript_TotA_8_Sequence")]
        public int MaxWaves;

        [FoldoutGroup("AIScript_TotA_8_Sequence")]
        public string FinishEvent = string.Empty;

        [FoldoutGroup("AIScript_TotA_8_Sequence")]
        public List<FSkill_EffectClass_AudioVisual> TeleportEffects = new List<FSkill_EffectClass_AudioVisual>();

        [FoldoutGroup("AIScript_TotA_8_Sequence")]
        public float TeleportRadius;

        [FoldoutGroup("AIScript_TotA_8_Sequence")]
        public Actor TeleportCenter;

        [FoldoutGroup("AIScript_TotA_8_Sequence")]
        public FSkill_EffectClass_AudioVisual TargetEffect;

        public Game_AIController targetController;

        public int CurrentWave;

        public int ArrivedCount;

        public bool IsFinalWave;

        public float RespawnTimer;

        public AIScript_TotA_8_Sequence()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local int i;
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(FinishEvent,static.RGB(100,100,255),"FinishEvent:" @ FinishEvent,oRelations);
i = 1;                                                                      
while (i <= MaxWaves) {                                                     
GetTaggedRelations(BaseSpawnEventString $ string(i),static.RGB(100,100,255),"BaseSpawnEventString" $ string(i)
$ ":"
@ BaseSpawnEventString
$ string(i),oRelations);
i++;                                                                      
}
}
function bool OnDebuff(Game_AIController Victim,Game_Pawn aInstigator,export editinline FSkill_EffectClass aEffect,float aValue) {
Debug("received default debuff and blocked it");                            
return True;                                                                
}
function bool OnBuff(Game_AIController Victim,Game_Pawn aInstigator,export editinline FSkill_EffectClass aEffect,float aValue) {
Debug("received default buff and blocked it");                              
return True;                                                                
}
function bool OnDamage(Game_AIController Victim,Actor cause,float aDamage) {
Debug("received default damage and blocked it");                            
return True;                                                                
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
GotoState('InitializeState');                                               
}
state Phase2State {
function RandomTeleport(Game_AIController aController) {
local int i;
local Vector Destination;
local Vector Extent;
Extent = aController.Pawn.GetCollisionExtent();                         
Destination = Class'Content_API'.RandomRadiusLocation(TeleportCenter,TeleportRadius,TeleportRadius,False,Extent,True);
if (Destination == vect(0.000000, 0.000000, 0.000000)
|| !Class'Content_API'.ValidLocation(TeleportCenter,Destination,Extent)) {
Destination = Class'Content_API'.NearestValidLocation(TeleportCenter,TeleportCenter.Location,Extent,aController.Pawn.IsGrounded());
}
PauseAI(aController);                                                   
SetControllerLocation(aController,Destination);                         
ContinueAI(aController);                                                
Debug("randomteleport to: " @ string(Destination));                     
i = 0;                                                                  
while (i < TeleportEffects.Length) {                                    
ApplyOneShotAudioVisualEffect(Game_Pawn(aController.Pawn),TeleportEffects[i]);
i++;                                                                  
}
}
function FindMaxHealthController(optional Game_AIController aIgnoreController) {
local int i;
local array<RegisteredAI> Register;
local float MaxHealth;
local float tempHealth;
local Game_AIController bestController;
Register = GetRegister();                                               
if (Register.Length == 0) {                                             
TriggerEvent(name(FinishEvent),self,None);                            
GotoState('InitializeState');                                         
return;                                                               
} else {                                                                
if (Register.Length == 1) {                                           
bestController = aIgnoreController;                                 
Debug("Best controller ( last enemy ): "
@ string(bestController));
} else {                                                              
i = 0;                                                              
while (i < Register.Length) {                                       
tempHealth = GetHealth(Register[i].Controller) / GetMaxHealth(Register[i].Controller);
if (tempHealth > MaxHealth
&& Register[i].Controller != aIgnoreController) {
MaxHealth = tempHealth;                                         
bestController = Register[i].Controller;                        
}
i++;                                                              
}
Debug("Best controller: " @ string(bestController)
@ string(MaxHealth));
}
}
targetController = bestController;                                      
if (!Game_Pawn(targetController.Pawn).IsDead()) {                       
ApplyOneShotAudioVisualEffect(Game_Pawn(targetController.Pawn),TargetEffect);
}
ScriptAssert(targetController != None,"No TargetController found");     
}
function bool OnDeath(Game_AIController aController,Actor aCollaborator) {
local bool ret;
ret = OnDeath(aController,aCollaborator);                               
FindMaxHealthController();                                              
return ret;                                                             
}
function bool OnDebuff(Game_AIController Victim,Game_Pawn aInstigator,export editinline FSkill_EffectClass aEffect,float aValue) {
local bool hostile;
hostile = Game_Pawn(Victim.Pawn).IsHostile(aInstigator);                
if (hostile) {                                                          
if (Victim == targetController) {                                     
RandomTeleport(Victim);                                             
FindMaxHealthController(Victim);                                    
return OnDebuff(Victim,aInstigator,aEffect,aValue);                 
} else {                                                              
Debug("DEBUFFED WRONG PERSON! " @ string(hostile));                 
ApplyOneShotAudioVisualEffect(Game_Pawn(targetController.Pawn),TargetEffect);
return True;                                                        
}
}
return OnDebuff(Victim,aInstigator,aEffect,aValue);                     
}
function bool OnBuff(Game_AIController Victim,Game_Pawn aInstigator,export editinline FSkill_EffectClass aEffect,float aValue) {
local bool hostile;
hostile = Game_Pawn(Victim.Pawn).IsHostile(aInstigator);                
if (hostile) {                                                          
if (Victim == targetController) {                                     
RandomTeleport(Victim);                                             
FindMaxHealthController(Victim);                                    
return OnDebuff(Victim,aInstigator,aEffect,aValue);                 
} else {                                                              
Debug("BUFFED WRONG PERSON! " @ string(hostile));                   
ApplyOneShotAudioVisualEffect(Game_Pawn(targetController.Pawn),TargetEffect);
return True;                                                        
}
}
return OnDebuff(Victim,aInstigator,aEffect,aValue);                     
}
function bool OnDamage(Game_AIController Victim,Actor cause,float aDamage) {
return OnDamage(Victim,cause,aDamage);                                  
}
protected function OnRegister(RegisteredAI aRegisteredAI) {
OnRegister(aRegisteredAI);                                              
FindMaxHealthController();                                              
}
function BeginState() {
Debug("Entered Phase2 State");                                          
FindMaxHealthController();                                              
}
}
state Phase1SpawnAndWaitState {
protected event sv_OnScriptFrame(float delta) {
RespawnTimer += delta;                                                  
if (RespawnTimer >= RespawnTimeout) {                                   
Debug("timer ended" @ string(RespawnTimer));                          
GotoState('Phase1State');                                             
}
}
function DetermineNewTarget() {
local int i;
local array<Game_AIController> registeredControllers;
registeredControllers = GetRegistered();                                
targetController = GetRandomRegistered().Controller;                    
i = 0;                                                                  
while (i < registeredControllers.Length) {                              
if (registeredControllers[i] != targetController) {                   
ApplySkillEffects(ProtectionSkill,Game_Pawn(registeredControllers[i].Pawn),Game_Pawn(registeredControllers[i].Pawn));
}
i++;                                                                  
}
}
protected function OnRegister(RegisteredAI aRegisteredAI) {
OnRegister(aRegisteredAI);                                              
PauseAI(aRegisteredAI.Controller);                                      
if (GetRegisterSize() == CurrentWave) {                                 
DetermineNewTarget();                                                 
}
}
function EndState() {
local int i;
local array<Game_AIController> registeredControllers;
registeredControllers = GetRegistered();                                
i = 0;                                                                  
while (i < registeredControllers.Length) {                              
if (HasPausedAI(registeredControllers[i])) {                          
ContinueAI(registeredControllers[i]);                               
}
i++;                                                                  
}
}
function BeginState() {
local int i;
Debug("waiting... ");                                                   
RespawnTimer = 0.00000000;                                              
mScriptFrameTime = RespawnTimeout;                                      
if (CurrentWave == MaxWaves) {                                          
GotoState('Phase2State');                                             
} else {                                                                
CurrentWave++;                                                        
}
i = 1;                                                                  
while (i <= CurrentWave) {                                              
TriggerEvent(name(BaseSpawnEventString $ string(i)),self,None);       
Debug("::: i" @ string(i) @ "CurrentWave"
@ string(CurrentWave)
@ string(IsFinalWave));
i++;                                                                  
}
}
}
state Phase1ReturnState {
event bool OnArrived(Game_AIController aController,SBPoint aControlPoint,SBPoint aDestinationPoint,Vector aDestination) {
ArrivedCount++;                                                         
Debug("OnArrived" @ string(ArrivedCount)
@ string(GetRegisterSize()));
LookAt(aController,CenterPoint.Location);                               
if (ArrivedCount == GetRegisterSize()) {                                
GotoState('Phase1SpawnAndWaitState');                                 
}
return OnArrived(aController,aControlPoint,aDestinationPoint,aDestination);
}
function BeginState() {
local int i;
local array<Game_AIController> registeredControllers;
registeredControllers = GetRegistered();                                
Debug("Resetting fight!" @ string(CurrentWave));                        
i = 0;                                                                  
while (i < registeredControllers.Length) {                              
if (!HasPausedAI(registeredControllers[i])) {                         
PauseAI(registeredControllers[i]);                                  
}
sheathWeapon(registeredControllers[i]);                               
MoveTo(registeredControllers[i],registeredControllers[i].GetHomeLocation());
i++;                                                                  
}
ArrivedCount = 0;                                                       
}
}
state Phase1State {
function bool OnDebuff(Game_AIController Victim,Game_Pawn aInstigator,export editinline FSkill_EffectClass aEffect,float aValue) {
if (Victim != targetController) {                                       
return True;                                                          
} else {                                                                
return OnDebuff(Victim,aInstigator,aEffect,aValue);                   
}
}
function bool OnBuff(Game_AIController Victim,Game_Pawn aInstigator,export editinline FSkill_EffectClass aEffect,float aValue) {
if (Victim != targetController) {                                       
return True;                                                          
} else {                                                                
return OnBuff(Victim,aInstigator,aEffect,aValue);                     
}
}
function bool OnDamage(Game_AIController Victim,Actor cause,float aDamage) {
if (Victim != targetController) {                                       
return True;                                                          
} else {                                                                
return OnDamage(Victim,cause,aDamage);                                
}
}
function bool OnDeath(Game_AIController aController,Actor aCollaborator) {
local bool ret;
ret = OnDeath(aController,aCollaborator);                               
if (aController == targetController) {                                  
if (CurrentWave > 1) {                                                
GotoState('Phase1ReturnState');                                     
} else {                                                              
GotoState('Phase1SpawnAndWaitState');                               
}
}
return ret;                                                             
}
function EndState() {
local int i;
local array<Game_AIController> registeredControllers;
registeredControllers = GetRegistered();                                
i = 0;                                                                  
while (i < registeredControllers.Length) {                              
RemoveAllDuffs(Game_Pawn(registeredControllers[i].Pawn));             
RemoveAudioVisualEffects(Game_Pawn(registeredControllers[i].Pawn));   
if (HasPausedAI(registeredControllers[i])) {                          
ContinueAI(registeredControllers[i]);                               
}
i++;                                                                  
}
}
}
auto state InitializeState {
event Trigger(Actor Other,Pawn EventInstigator) {
GotoState('Phase1SpawnAndWaitState');                                   
}
function BeginState() {
CurrentWave = 0;                                                        
ArrivedCount = 0;                                                       
IsFinalWave = False;                                                    
}
}
*/