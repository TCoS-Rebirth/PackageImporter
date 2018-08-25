using System;
using Engine;
using SBAI;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_Trial45_Statue : AI_Script
    {
        [FoldoutGroup("Statue")]
        public NavigationPoint SalutePoint;

        [FoldoutGroup("Statue")]
        public byte WakeEmote;

        [FoldoutGroup("Statue")]
        public float WakeEmoteTime;

        [FoldoutGroup("Statue")]
        public byte SaluteEmote;

        [FoldoutGroup("Statue")]
        public float SaluteEmoteTime;

        [FoldoutGroup("Statue")]
        public float SaluteDelay;

        public byte StatueState;

        public Game_AIController Controller;

        public float CurrentTime;

        public bool Saluted;

        public AIScript_Trial45_Statue()
        {
        }

        public enum eStatueState
        {
            STATE_WAKEUP,

            STATE_WALKING,

            STATE_SALUTING,

            STATE_FIGHTING,
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local ActorRelation newRelation;
if (SalutePoint != None) {                                                  
newRelation.mActor = SalutePoint;                                         
newRelation.mDescription = "SalutePoint";                                 
newRelation.mColour = static.RGB(100,255,100);                            
oRelations[oRelations.Length] = newRelation;                              
}
}
event bool OnDeath(Game_AIController aController,Actor aDeceasedActor) {
Controller = None;                                                          
return Super.OnDeath(aController,aDeceasedActor);                           
}
function bool OnDebuff(Game_AIController Victim,Game_Pawn aInstigator,export editinline FSkill_EffectClass aEffect,float aValue) {
if (StatueState == 3) {                                                     
return Super.OnDebuff(Victim,aInstigator,aEffect,aValue);                 
}
return True;                                                                
}
function bool OnBuff(Game_AIController Victim,Game_Pawn aInstigator,export editinline FSkill_EffectClass aEffect,float aValue) {
if (StatueState == 3) {                                                     
return Super.OnBuff(Victim,aInstigator,aEffect,aValue);                   
}
return True;                                                                
}
function bool OnDamage(Game_AIController Victim,Actor aInstigator,float aDamage) {
if (StatueState == 3) {                                                     
return Super.OnDamage(Victim,aInstigator,aDamage);                        
}
return True;                                                                
}
function bool OnStateSignal(Game_AIController aController,AIState aState,byte aSignal) {
switch (aSignal) {                                                          
case 22 :                                                                 
if (StatueState == 1) {                                                 
StatueState = 2;                                                      
CurrentTime = 0.00000000;                                             
}
break;                                                                  
default:                                                                  
}
return Super.OnStateSignal(aController,aState,aSignal);                     
}
event bool OnTick(Game_AIController aController,float DeltaTime) {
if (IsAIPaused(aController)) {                                              
CurrentTime += DeltaTime;                                                 
}
switch (StatueState) {                                                      
case 0 :                                                                  
if (CurrentTime >= WakeEmoteTime) {                                     
StatueState = 1;                                                      
MoveTo(aController,SalutePoint.Location);                             
}
break;                                                                  
case 1 :                                                                  
break;                                                                  
case 2 :                                                                  
if (CurrentTime >= SaluteDelay && !Saluted) {                           
PerformEmote(aController,SaluteEmote);                                
Saluted = True;                                                       
}
if (CurrentTime >= SaluteEmoteTime) {                                   
StatueState = 3;                                                      
ContinueAI(aController);                                              
}
break;                                                                  
default:                                                                  
}
return Super.OnTick(aController,DeltaTime);                                 
}
function OnBegin(Game_AIController aController) {
Super.OnBegin(aController);                                                 
Controller = aController;                                                   
PauseAI(aController);                                                       
StatueState = 0;                                                            
CurrentTime = 0.00000000;                                                   
PerformEmote(aController,WakeEmote);                                        
}
*/