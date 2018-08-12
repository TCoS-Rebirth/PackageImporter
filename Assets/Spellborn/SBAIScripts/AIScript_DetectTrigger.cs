using System;
using System.Collections.Generic;
using Engine;
using SBGame;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBAIScripts
{
    [Serializable] public class AIScript_DetectTrigger : AIRegistered
    {
        [FoldoutGroup("DetectTrigger")]
        [FieldConst()]
        public byte DetectMode;

        [FoldoutGroup("DetectTrigger")]
        [FieldConst()]
        public float Timeout;

        [FoldoutGroup("DetectTrigger")]
        [FieldConst()]
        public bool TriggerAble;

        [FoldoutGroup("DetectTrigger")]
        [FieldConst()]
        public bool DetectOnlyOnce;

        [FoldoutGroup("DetectTrigger")]
        [FieldConst()]
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private NameProperty mSavedState;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private float mResetTimeout;

        public AIScript_DetectTrigger()
        {
        }

        public enum EDetectMode
        {
            DM_DETECT_ENEMY,

            DM_DETECT_FRIENDLY,

            DM_DETECT_BOTH,
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
Super.GetActorRelations(oRelations);                                        
}
function RestoreState() {
GotoState(mSavedState);                                                     
}
function bool ConditionalSwitchState(name aNewState,Game_Pawn aPawn,Game_AIController anObserver) {
local int reqI;
TriggerEvent(Event,anObserver.Pawn,None);                                   
reqI = 0;                                                                   
while (reqI < Requirements.Length) {                                        
if (Requirements[reqI] != None
&& !Requirements[reqI].CheckPawn(aPawn)) {
return False;                                                           
}
reqI++;                                                                   
}
mSavedState = GetStateName();                                               
GotoState(aNewState);                                                       
return True;                                                                
}
function OnEnd(Game_AIController aController) {
GotoState('DisabledState');                                                 
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
if (TriggerAble) {                                                          
GotoState('DisabledState');                                               
}
}
protected function OnRegisterEmptied() {
if (!TriggerAble) {                                                         
GotoState('DisabledState');                                               
}
}
function GotoDetectState() {
switch (DetectMode) {                                                       
case 0 :                                                                  
GotoState('DetectEnemyState');                                          
break;                                                                  
case 1 :                                                                  
GotoState('DetectAllyState');                                           
break;                                                                  
case 2 :                                                                  
GotoState('DetectBothState');                                           
break;                                                                  
default:                                                                  
Failure("No valid detect mode!");                                       
break;                                                                  
}
}
state TimeoutState {
protected event sv_OnScriptFrame(float aDeltaTime) {
mResetTimeout -= aDeltaTime;                                            
if (mResetTimeout <= 0) {                                               
RestoreState();                                                       
}
Debug("timeout:" @ string(mResetTimeout));                              
}
function BeginState() {
mResetTimeout = Timeout;                                                
mScriptFrameTime = Timeout;                                             
ChangeAllToNextScript();                                                
if (DetectOnlyOnce) {                                                   
GotoState('DisabledState');                                           
}
}
}
state DetectBothState {
function bool OnDetectEnemy(Game_AIController anObserver,Game_Pawn anEnemy) {
ConditionalSwitchState('TimeoutState',anEnemy,anObserver);              
return OnDetectEnemy(anObserver,anEnemy);                               
}
function bool OnDetectAlly(Game_AIController anObserver,Game_Pawn anAlly) {
ConditionalSwitchState('TimeoutState',anAlly,anObserver);               
return OnDetectAlly(anObserver,anAlly);                                 
}
}
state DetectEnemyState {
function bool OnDetectEnemy(Game_AIController anObserver,Game_Pawn anEnemy) {
ConditionalSwitchState('TimeoutState',anEnemy,anObserver);              
return OnDetectEnemy(anObserver,anEnemy);                               
}
}
state DetectAllyState {
function bool OnDetectAlly(Game_AIController anObserver,Game_Pawn anAlly) {
ConditionalSwitchState('TimeoutState',anAlly,anObserver);               
return OnDetectAlly(anObserver,anAlly);                                 
}
}
auto state DisabledState {
event Trigger(Actor Other,Pawn EventInstigator) {
if (TriggerAble) {                                                      
GotoDetectState();                                                    
}
}
protected function OnRegister(RegisteredAI aRegisteredAI) {
if (!TriggerAble) {                                                     
GotoDetectState();                                                    
}
}
}
*/