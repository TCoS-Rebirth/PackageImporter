﻿using System;
using System.Collections.Generic;
using Engine;
using SBGame;

namespace SBAI
{
#pragma warning disable 414   

    [Serializable] public class Game_AIController : Game_NPCController
    {
        public const float cSpawnInTimer = 2F;

        private MetaControllerManagerComponent mMetaControl;

        public MovementComponent mMovement;

        public TargetComponent mTargeting;

        public HormoneComponent mHypothalamus;

        public float ChaseRange;

        public float VisualRange;

        public float LineOfSightRange;

        public float ThreatRange;

        public float FollowRange;

        public float AggressionFactor;

        public float FearFactor;

        public float SocialFactor;

        public float BoredomFactor;

        public Vector HomeLocation;

        public NPC_Habitat Habitat;

        public AIPoint ControlPoint;

        private List<AITimerStruct> mTimer = new List<AITimerStruct>();

        public float mSpawnInTimer;

        public AIStateMachine mAbortedMachine;

        public AIStateMachine mStateMachine;

        [TypeProxyDefinition(TypeName = "AIStateMachine")]
        public Type mMachineClass;

        public byte mTickResult;

        [FieldConfig()]
        public bool bProfileStateMachines;

        [FieldConfig()]
        public bool bProfileMovementModes;

        public List<UObject> mPausers = new List<UObject>();

        public Game_Pawn mLastAttackPawn;

        public FSkill_EffectClass mLastAttackEffect;

        //public delegate<FollowFunction> @__FollowFunction__Delegate;

        public Game_AIController()
        {
        }

        [Serializable] public struct AITimerStruct
        {
            public Actor Instigator;

            public float Time;

            public float Timeout;

            public NameProperty Tag;
        }
    }
}
/*
function bool HasMetaController(NPC_AI aController) {
return mMetaControl.HasMetaController(aController);                         
}
native function bool MetaControllerMessage(byte aMessage,optional Actor aCollaborator,optional name aTag,optional Object aContext,optional float aValue,optional Vector aLocation);
native function RemoveMetaController(AI_MetaController aMetaController);
native function AI_MetaController AddMetaController(AI_MetaController aMetaController);
native function bool IsAIPausedBy(Object aPauser);
native function bool IsAIPaused();
native function ContinueAI(Object aPauser);
native function PauseAI(Object aPauser);
native function AIState GetActiveAIState();
native function AIStateMachine SetStateMachine(AIStateMachine aMachine);
function RemoveTimer(name aTag) {
local int ti;
ti = 0;                                                                     
while (ti < mTimer.Length) {                                                
if (mTimer[ti].Tag == aTag) {                                             
mTimer.Remove(ti,1);                                                    
ti--;                                                                   
}
ti++;                                                                     
}
}
function SetTimerTimeout(Actor aInstigator,name aTag,float aDuration) {
local AITimerStruct newTimer;
newTimer.Instigator = aInstigator;                                          
newTimer.Tag = aTag;                                                        
newTimer.Timeout = aDuration;                                               
newTimer.Time = 0.00000000;                                                 
mTimer[mTimer.Length] = newTimer;                                           
}
function Trigger(Actor aTrigger,Pawn anInstigator) {
MetaControllerMessage(17,aTrigger,,anInstigator);                           
}
function NPC_Taxonomy GetFaction() {
return Game_Pawn(Pawn).Character.GetFaction();                              
}
function SetControlPoint(AIPoint aControlPoint) {
ControlPoint = aControlPoint;                                               
}
final native function Vector GetHomeLocation();
final native function bool SetHomeLocation(Vector aLocation,optional bool aForce);
final native function SetLineOfSightRange(float aLineOfSightRange);
function float GetVisualRange() {
return VisualRange;                                                         
}
final native function SetVisualRange(float aVisualRange);
event bool sv_OnAttack(Game_Pawn aPawn,export editinline FSkill_EffectClass aEffect,bool WasNegativeEffect,float aValue) {
if (SpawnedIn()) {                                                          
return True;                                                              
} else {                                                                    
if (WasNegativeEffect) {                                                  
mLastAttackPawn = aPawn;                                                
mLastAttackEffect = aEffect;                                            
if (!MetaControllerMessage(8,aPawn,,aEffect,aValue)) {                  
StateSignal(35);                                                      
return False;                                                         
} else {                                                                
return True;                                                          
}
} else {                                                                  
if (!MetaControllerMessage(7,aPawn,,aEffect,aValue)) {                  
StateSignal(36);                                                      
return False;                                                         
} else {                                                                
return True;                                                          
}
}
}
}
event sv_OnOwnerAttack(bool WasNegativeEffect) {
if (WasNegativeEffect) {                                                    
StateSignal(37);                                                          
} else {                                                                    
StateSignal(38);                                                          
}
}
event sv_OnOwnerAggression() {
StateSignal(39);                                                            
}
event bool sv_OnDamage(Game_Pawn anEnemy,int aDamage) {
if (!Super.sv_OnDamage(anEnemy,aDamage)) {                                  
if (SpawnedIn()) {                                                        
return True;                                                            
} else {                                                                  
if (!MetaControllerMessage(6,anEnemy,,,aDamage)) {                      
return False;                                                         
}
}
}
return True;                                                                
}
final native function bool SpawnedIn();
native function StateSignal(byte aSignal);
event cl_OnShutdown() {
Super.cl_OnShutdown();                                                      
}
event cl_OnTick(float DeltaTime) {
Super.cl_OnTick(DeltaTime);                                                 
}
event cl_OnInit() {
Super.cl_OnInit();                                                          
}
event OnCreateComponents() {
Super.OnCreateComponents();                                                 
mMetaControl = new (self) Class'MetaControllerManagerComponent';            
mMovement = new (self) Class'MovementComponent';                            
mTargeting = new (self) Class'TargetComponent';                             
mHypothalamus = new (self) Class'HormoneComponent';                         
mDebugUtilsClass = None;                                                    
}
event sv_OnShutdown() {
if (mMetaControl != None) {                                                 
mMetaControl.sv_OnShutdown();                                             
}
if (mMovement != None) {                                                    
mMovement.sv_OnShutdown();                                                
}
if (mTargeting != None) {                                                   
mTargeting.sv_OnShutdown();                                               
}
if (mHypothalamus != None) {                                                
mHypothalamus.sv_OnShutdown();                                            
}
Super.sv_OnShutdown();                                                      
}
event sv_InitAI() {
if (mStateMachine == None && mMachineClass != None) {                       
SetStateMachine(new mMachineClass);                                       
}
MetaControllerMessage(1);                                                   
mSpawnInTimer = 2.00000000;                                                 
}
delegate bool FollowFunction(Actor aActor);
state PawnDead {
event cl_OnTick(float DeltaTime) {
cl_OnTick(DeltaTime);                                                   
Game_Pawn(Pawn).StopMoving();                                           
}
function BeginState() {
if (SBRole == 1) {                                                      
MetaControllerMessage(13,Pawn);                                       
Super.BeginState();                                                   
}
}
}
*/