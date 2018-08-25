﻿using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_CoA_3_Amsell_Script : AI_Script
    {
        [FoldoutGroup("AIScript_CoA_3_Amsell_Script")]
        public FSkill_EffectClass_AudioVisual PlayerFogEffect;

        [FoldoutGroup("AIScript_CoA_3_Amsell_Script")]
        public string FightPhaseStartTag = string.Empty;

        [FoldoutGroup("AIScript_CoA_3_Amsell_Script")]
        public List<Trigger> RuneTriggers = new List<Trigger>();

        [FoldoutGroup("AIScript_CoA_3_Amsell_Script")]
        public string RuneSmallTag = string.Empty;

        [FoldoutGroup("AIScript_CoA_3_Amsell_Script")]
        public string RuneLargeTag = string.Empty;

        [FoldoutGroup("AIScript_CoA_3_Amsell_Script")]
        public float TornadoLeadInTime;

        public Game_AIController Amsell;

        public int CurrentRune;

        public float BaseHealth;

        public AIScript_CoA_3_Amsell_Script()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local int i;
local ActorRelation newRelation;
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(FightPhaseStartTag,static.RGB(100,100,255),"FightPhaseStartTag:" @ FightPhaseStartTag,oRelations);
GetTaggedRelations(RuneSmallTag,static.RGB(100,100,255),"RuneSmallTag:" @ RuneSmallTag,oRelations);
GetTaggedRelations(RuneLargeTag,static.RGB(100,100,255),"RuneLargeTag:" @ RuneLargeTag,oRelations);
i = 0;                                                                      
while (i < RuneTriggers.Length) {                                           
if (RuneTriggers[i] != None) {                                            
newRelation.mActor = RuneTriggers[i];                                   
newRelation.mDescription = "RuneTrigger" @ string(i);                   
newRelation.mColour = static.RGB(100,255,100);                          
oRelations[oRelations.Length] = newRelation;                            
}
i++;                                                                      
}
}
event bool OnDeath(Game_AIController aController,Actor aDeceasedActor) {
Amsell = None;                                                              
return Super.OnDeath(aController,aDeceasedActor);                           
}
state RuneState {
event Trigger(Actor Other,Pawn EventInstigator) {
local float newhealth;
if (Other.IsA('Trigger')) {                                             
if (Other == RuneTriggers[CurrentRune]) {                             
newhealth = (RuneTriggers.Length - CurrentRune + 1) * BaseHealth / RuneTriggers.Length;
Game_Pawn(Amsell.Pawn).SetHealth(newhealth);                        
UntriggerEvent(name(RuneSmallTag $ string(CurrentRune)),self,None); 
TriggerEvent(name(RuneLargeTag $ string(CurrentRune)),self,None);   
CurrentRune++;                                                      
if (CurrentRune == RuneTriggers.Length) {                           
RemoveAudioVisualEffects(None);                                   
} else {                                                            
TriggerEvent(name(RuneSmallTag $ string(CurrentRune)),self,None); 
}
}
}
}
function BeginState() {
local Game_PlayerPawn playerPawn;
SetInvulnerable(Amsell,True);                                           
foreach AllActors(Class'Game_PlayerPawn',playerPawn) {                  
ApplyAudioVisualEffect(playerPawn,PlayerFogEffect);                   
}
CurrentRune = 0;                                                        
TriggerEvent(name(RuneSmallTag $ string(CurrentRune)),self,None);       
}
}
state TornadoState {
function bool OnTimerEnded(Game_AIController aGame_AIController,Actor aInstigator,name aTag) {
if (aTag == 'StartRunes') {                                             
GotoState('RuneState');                                               
}
return False;                                                           
}
function BeginState() {
SetInvulnerable(Amsell,True);                                           
}
}
state FightState {
function bool OnDamage(Game_AIController aController,Actor cause,float aDamage) {
if (GetHealth(aController) / GetMaxHealth(aController) > 0.20000000
&& (GetHealth(aController) - aDamage) / GetMaxHealth(aController) <= 0.20000000) {
GotoState('TornadoState');                                            
TriggerEvent(name(FightPhaseStartTag),self,None);                     
BaseHealth = GetHealth(aController);                                  
StartTimer(aController,'StartRunes',TornadoLeadInTime);               
return True;                                                          
}
return OnDamage(aController,cause,aDamage);                             
}
function BeginState() {
SetInvulnerable(Amsell,False);                                          
SetFreeze(Game_Pawn(Amsell.Pawn),False,True,True,False);                
}
}
auto state Initialize {
event Trigger(Actor Other,Pawn EventInstigator) {
GotoState('FightState');                                                
}
function OnBegin(Game_AIController aController) {
OnBegin(aController);                                                   
if (Amsell == None) {                                                   
Amsell = aController;                                                 
SetInvulnerable(Amsell,True);                                         
SetFreeze(Game_Pawn(Amsell.Pawn),True,True,True,False);               
} else {                                                                
Failure("AIScript_CoA_3_Amsell_Script: Trying to attach script to more than one controller!");
}
}
}
*/