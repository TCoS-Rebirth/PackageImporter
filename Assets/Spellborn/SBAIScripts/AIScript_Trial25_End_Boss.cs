﻿using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using SBGame;
using SBGamePlay;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_Trial25_End_Boss : AI_Script
    {
        [FoldoutGroup("EndBoss")]
        [FieldConst()]
        public NavigationPoint CenterPoint;

        [FoldoutGroup("EndBoss")]
        [FieldConst()]
        public FSkill_Type PlayerKillSkill;

        [FoldoutGroup("EndBoss")]
        [FieldConst()]
        public float StunTime;

        [FoldoutGroup("EndBoss")]
        [FieldConst()]
        public float SpawnDelay;

        [FoldoutGroup("EndBoss")]
        public float FirstSpawnDelay;

        [FoldoutGroup("EndBoss")]
        [FieldConst()]
        public float SpawnDelayRange;

        [FoldoutGroup("EndBoss")]
        [FieldConst()]
        public float RotationSpeed;

        [FoldoutGroup("EndBoss")]
        [FieldConst()]
        public string ActivationEvent = string.Empty;

        [FoldoutGroup("EndBoss")]
        [FieldConst()]
        public NPC_Type HeroNPCType;

        [FoldoutGroup("EndBoss")]
        [FieldConst()]
        public Spawn_Placed Spawner;

        [FoldoutGroup("EndBoss")]
        [FieldConst()]
        public List<FSkill_EffectClass_AudioVisual> EvilEffects = new List<FSkill_EffectClass_AudioVisual>();

        [FoldoutGroup("EndBoss")]
        [FieldConst()]
        public FSkill_EffectClass_AudioVisual PlayerFreezeEffect;

        [FoldoutGroup("EndBoss")]
        [FieldConst()]
        public string ChallengeFailTag = string.Empty;

        [FoldoutGroup("EndBoss")]
        [FieldConst()]
        public string ChallengeSucceedTag = string.Empty;

        public Game_AIController Controller;

        public float FlyingTargetRadius;

        public float SpawningTargetRadius;

        public float HeightOffset;

        public float HeightOffsetPhase;

        public float HeightOffsetAmplitude;

        public Vector centerLocation;

        public Vector TargetCenter;

        public float CenterLocationDivider;

        public float Radius;

        public float TargetRadius;

        public float RadiusDivider;

        public float Angle;

        public int CurrentEvilEffect;

        public Game_PlayerPawn playerPawn;

        public float DamageLimit;

        public AIScript_Trial25_End_Boss()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local ActorRelation newRelation;
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(ActivationEvent,static.RGB(100,100,255),"ActivationEvent:" @ ActivationEvent,oRelations);
GetTaggedRelations(string(Spawner.Tag),static.RGB(100,100,255),"Spawn Spirits",oRelations);
if (CenterPoint != None) {                                                  
newRelation.mActor = CenterPoint;                                         
newRelation.mDescription = "CenterPoint";                                 
newRelation.mColour = static.RGB(100,255,100);                            
oRelations[oRelations.Length] = newRelation;                              
}
}
function FailBattle() {
local Game_PlayerController lController;
Debug("Failbattle");                                                        
foreach AllActors(Class'Game_PlayerController',lController) {               
FireScriptHook(lController,name(ChallengeFailTag));                       
}
}
function WinBattle() {
local Game_PlayerController lController;
foreach AllActors(Class'Game_PlayerController',lController) {               
FireScriptHook(lController,name(ChallengeSucceedTag));                    
}
}
function OnGraidlonDied() {
Debug("Graidlon Died!");                                                    
FailBattle();                                                               
GotoState('HuntPlayerState');                                               
}
event bool OnDeath(Game_AIController aController,Actor aDeceasedActor) {
RemoveAudioVisualEffects(Game_Pawn(aController.Pawn));                      
WinBattle();                                                                
GotoState('PassiveState');                                                  
return Super.OnDeath(aController,aDeceasedActor);                           
}
function SetEffects(Game_AIController aController) {
local int evilEffect;
evilEffect = Min(3,4 - Round(4.00000000 * aController.Pawn.GetHealth() / Game_Pawn(aController.Pawn).CharacterStats.mRecord.MaxHealth));
if (evilEffect > CurrentEvilEffect) {                                       
RemoveAudioVisualEffects(Game_Pawn(aController.Pawn));                    
CurrentEvilEffect = evilEffect;                                           
ApplyAudioVisualEffect(Game_Pawn(aController.Pawn),EvilEffects[CurrentEvilEffect]);
}
}
function bool OnDamage(Game_AIController Victim,Actor cause,float aDamage) {
Debug("hit by: " @ string(cause) @ " ("
@ string(Game_NPCPawn(cause).NPCType)
@ "), with: "
@ string(aDamage)
@ ", health left after applying: "
@ string(Victim.Pawn.GetHealth() - aDamage));
if (Game_NPCPawn(cause).NPCType == HeroNPCType) {                           
SetEffects(Victim);                                                       
SetSpeed(Victim,GetSpeed(Victim) * 1.04999995);                           
GotoState('StunnedState');                                                
return Super.OnDamage(Victim,cause,aDamage);                              
}
return True;                                                                
}
function DoMovement(Game_AIController aController) {
local Vector Offset;
if (IsMoving(aController)) {                                                
return;                                                                   
}
Angle = (Angle + RotationSpeed) % 2 * 3.14159274;                           
Offset.X = Radius * Sin(Angle);                                             
Offset.Y = Radius * Sin(2.00000000 * Angle) * 0.50000000;                   
MoveTo(aController,centerLocation + Offset);                                
}
function EasePositions() {
if (centerLocation != TargetCenter) {                                       
centerLocation += (TargetCenter - centerLocation) / CenterLocationDivider;
}
if (Radius != TargetRadius) {                                               
Radius += (TargetRadius - Radius) / RadiusDivider;                        
if (Rand(100) < 3) {                                                      
Radius += 100;                                                          
}
}
}
function bool OnArrived(Game_AIController aGame_AIController,SBPoint aControlPoint,SBPoint aDestinationPoint,Vector aLocation) {
DoMovement(aGame_AIController);                                             
return Super.OnArrived(aGame_AIController,aControlPoint,aDestinationPoint,aLocation);
}
state PassiveState {
function OnGraidlonDied() {
}
function BeginState() {
StopTimer(Controller,'StunnedTimer');                                   
StopTimer(Controller,'SpawnTimer');                                     
Controller = None;                                                      
}
}
state HuntPlayerState {
function OnGraidlonDied() {
}
event bool OnUnreachable(Game_AIController aController,SBPoint aControlPoint,Vector aDestination) {
aController.Pawn.SetLocation(TargetCenter);                             
StopMovement(aController);                                              
if (playerPawn != None && !playerPawn.IsDead()) {                       
ApplySkillEffects(PlayerKillSkill,Game_Pawn(aController.Pawn),playerPawn);
} else {                                                                
GotoState('PassiveState');                                            
}
return OnUnreachable(aController,aControlPoint,aDestination);           
}
function bool OnArrived(Game_AIController aController,SBPoint aControlPoint,SBPoint aDestinationPoint,Vector aLocation) {
ApplySkillEffects(PlayerKillSkill,Game_Pawn(aController.Pawn),playerPawn);
return OnArrived(aController,aControlPoint,aDestinationPoint,aLocation);
}
event bool OnTick(Game_AIController aController,float DeltaTime) {
EasePositions();                                                        
if (playerPawn != None && !playerPawn.IsDead()) {                       
} else {                                                                
GotoState('PassiveState');                                            
}
return OnTick(aController,DeltaTime);                                   
}
function BeginState() {
local Game_PlayerController lController;
foreach AllActors(Class'Game_PlayerController',lController) {           
playerPawn = Game_PlayerPawn(lController.Pawn);                       
SetFreeze(playerPawn,True,True,True,True);                            
ApplyAudioVisualEffect(playerPawn,PlayerFreezeEffect);                
}
TargetCenter = playerPawn.Location;                                     
centerLocation = TargetCenter;                                          
TargetRadius = SpawningTargetRadius;                                    
Radius = 10.00000000;                                                   
HeightOffset = 0.00000000;                                              
MoveTo(Controller,TargetCenter);                                        
}
}
state StunnedState {
event bool OnTimerEnded(Game_AIController aController,Actor aInstigator,name aTag) {
if (aTag == 'StunnedTimer') {                                           
GotoState('FlyingState');                                             
return OnTimerEnded(aController,aInstigator,aTag);                    
}
}
function BeginState() {
StopMovement(Controller);                                               
StartTimer(Controller,'StunnedTimer',StunTime);                         
}
}
state SpawnState {
event bool OnTimerEnded(Game_AIController aController,Actor aInstigator,name aTag) {
if (aTag == 'SpawnTimer') {                                             
TriggerEvent(Spawner.Tag,aController.Pawn,None);                      
GotoState('FlyingState');                                             
}
return OnTimerEnded(aController,aInstigator,aTag);                      
}
event bool OnTick(Game_AIController aController,float DeltaTime) {
EasePositions();                                                        
return OnTick(aController,DeltaTime);                                   
}
function EndState() {
TargetRadius = FlyingTargetRadius;                                      
TargetCenter = CenterPoint.Location;                                    
HeightOffset = 0.00000000;                                              
}
function BeginState() {
TargetCenter = Controller.Pawn.Location;                                
TargetRadius = SpawningTargetRadius;                                    
HeightOffset = -50.00000000;                                            
StartTimer(Controller,'SpawnTimer',3.00000000);                         
}
}
state FlyingState {
event bool OnTimerEnded(Game_AIController aController,Actor aInstigator,name aTag) {
if (aTag == 'SpawnDelayTimer') {                                        
if (Spawner.GetSpawnsLeft() < Spawner.MaxSpawnsAlive) {               
GotoState('SpawnState');                                            
} else {                                                              
StartTimer(Controller,'SpawnDelayTimer',SpawnDelay + Rand(SpawnDelayRange));
}
}
return OnTimerEnded(aController,aInstigator,aTag);                      
}
event bool OnTick(Game_AIController aController,float DeltaTime) {
EasePositions();                                                        
if (HeightOffset > 0 && Rand(100) < 40) {                               
HeightOffset = 0.00000000;                                            
} else {                                                                
if (HeightOffset == 0 && Rand(100) < 7) {                             
HeightOffset = 250.00000000;                                        
}
}
return OnTick(aController,DeltaTime);                                   
}
function EndState() {
FirstSpawnDelay = SpawnDelay;                                           
}
function BeginState() {
TargetCenter = CenterPoint.Location;                                    
centerLocation = CenterPoint.Location;                                  
Radius = FlyingTargetRadius;                                            
TargetRadius = FlyingTargetRadius;                                      
HeightOffset = 0.00000000;                                              
DoMovement(Controller);                                                 
StartTimer(Controller,'SpawnDelayTimer',FirstSpawnDelay + Rand(SpawnDelayRange));
}
}
auto state Initialize {
function OnBegin(Game_AIController aController) {
OnBegin(aController);                                                   
PauseAI(aController);                                                   
Controller = aController;                                               
CurrentEvilEffect = -1;                                                 
SetEffects(aController);                                                
TriggerEvent(name(ActivationEvent),aController.Pawn,None);              
SetFreeze(Game_Pawn(aController.Pawn),True,False,False,False,True);     
GotoState('FlyingState');                                               
}
}
*/