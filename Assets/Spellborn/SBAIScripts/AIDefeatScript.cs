﻿using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBAIScripts
{
    [Serializable] public class AIDefeatScript : AIRegistered
    {
        [FoldoutGroup("DefeatQuest")]
        public NPC_Type NPC_Type;

        [FoldoutGroup("DefeatQuest")]
        public Quest_Type quest;

        [FoldoutGroup("DefeatQuest")]
        public int objective;

        [FoldoutGroup("DefeatQuest")]
        public float NapTime;

        [FoldoutGroup("DefeatQuest")]
        public bool Heal;

        public NameProperty NAPTag;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<Game_Pawn> mParticipants = new List<Game_Pawn>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Game_AIController DefeatNPC;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Game_Pawn Killer;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool NPCInvulnerable;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool bFinalDamage;

        public AIDefeatScript()
        {
        }
    }
}
/*
protected function OnUnRegister(RegisteredAI aRegisteredAI) {
if (aRegisteredAI.Controller == DefeatNPC) {                                
GotoState('Initialize');                                                  
}
Super.OnUnRegister(aRegisteredAI);                                          
}
state NAPState {
function EndState() {
if (DefeatNPC != None) {                                                
if (NextScript != None) {                                             
ChangeToNextScript(DefeatNPC,Killer);                               
}
goto jl0029;                                                          
}
}
event bool OnTimerEnded(Game_AIController aController,Actor aInstigator,name aTag) {
if (aController == DefeatNPC && aTag == NAPTag) {                       
GotoState('DamageState');                                             
} else {                                                                
return OnTimerEnded(aController,aInstigator,aTag);                    
}
}
protected function bool CheckNAP(Actor aActor) {
local Game_PlayerPawn Player;
Player = Game_PlayerPawn(aActor);                                       
return Player != None
&& quest.Targets[objective].Check(Player.questLog.GetTargetProgress(quest,objective));
}
function bool OnDebuff(Game_AIController Victim,Game_Pawn aInstigator,export editinline FSkill_EffectClass aEffect,float aValue) {
if (Victim == DefeatNPC && CheckNAP(aInstigator)) {                     
return True;                                                          
}
return OnDebuff(Victim,aInstigator,aEffect,aValue);                     
}
function bool OnBuff(Game_AIController Victim,Game_Pawn aInstigator,export editinline FSkill_EffectClass aEffect,float aValue) {
if (Victim == DefeatNPC && CheckNAP(aInstigator)) {                     
return True;                                                          
}
return OnBuff(Victim,aInstigator,aEffect,aValue);                       
}
function bool OnDamage(Game_AIController Victim,Actor aInstigator,float aDamage) {
if (Victim == DefeatNPC && CheckNAP(aInstigator)) {                     
return True;                                                          
}
return OnDamage(Victim,aInstigator,aDamage);                            
}
function bool OnCheckFriendly(Game_AIController aGame_AIController,Game_Pawn potentialEnemy) {
if (aGame_AIController == DefeatNPC
&& CheckNAP(potentialEnemy)) {
return True;                                                          
} else {                                                                
return OnCheckFriendly(aGame_AIController,potentialEnemy);            
}
}
function BeginState() {
local Game_NPCPawn NPC;
NPC = Game_NPCPawn(DefeatNPC.Pawn);                                     
if (NPC != None && Heal) {                                              
SetHealth(DefeatNPC,GetMaxHealth(DefeatNPC));                         
}
if (NapTime >= 0.00000000) {                                            
Debug("NAP for" @ string(NapTime) @ "sec");                           
StartTimer(DefeatNPC,NAPTag,NapTime);                                 
ReturnHome(DefeatNPC);                                                
} else {                                                                
Debug("No NAP phase");                                                
GotoState('DamageState');                                             
}
TriggerEvent(Event,self,Killer);                                        
}
}
state LastWordsState {
function EndState() {
if (DefeatNPC != None) {                                                
SetInvulnerable(DefeatNPC,NPCInvulnerable);                           
ContinueAI(DefeatNPC);                                                
}
}
function bool OnCheckFriendly(Game_AIController aGame_AIController,Game_Pawn potentialEnemy) {
return True;                                                            
}
event bool OnEndConversation(Game_AIController aGame_AIController,Actor partner) {
local Game_PlayerPawn participant;
local int ti;
if (aGame_AIController == DefeatNPC) {                                  
participant = Game_PlayerPawn(partner);                               
ti = 0;                                                               
while (ti < mParticipants.Length) {                                   
if (mParticipants[ti] == participant) {                             
Debug("Conversations ended for" @ CharName(partner)
@ "Found to be participant"
@ string(ti)
$ "/"
$ string(mParticipants.Length));
goto jl00B7;                                                      
}
ti++;                                                               
}
if (ti < mParticipants.Length) {                                      
if (participant != None
&& participant.questLog.GetTargetProgress(quest,objective) == 0) {
Debug("Failing defeat objective for" @ CharName(participant));    
participant.questLog.sv_SetTargetProgress(quest.Targets[objective],-1,Game_Pawn(DefeatNPC.Pawn));
}
if (mParticipants.Length > 1) {                                     
mParticipants[ti] = mParticipants[mParticipants.Length - 1];      
}
mParticipants.Length = mParticipants.Length - 1;                    
Debug("Waiting for" @ string(mParticipants.Length)
@ "participants to finish their conversation");
if (mParticipants.Length == 0) {                                    
GotoState('NAPState');                                            
}
} else {                                                              
Debug("Conversations ended for" @ CharName(partner)
@ "who is not a participant");
}
}
return OnEndConversation(aGame_AIController,partner);                   
}
function BeginState() {
local export editinline QT_Defeat defeatObjective;
local int ti;
local Game_NPCPawn NPC;
local bool convoStarted;
Debug(" lastwords state started" @ string(DefeatNPC));                  
NPC = Game_NPCPawn(DefeatNPC.Pawn);                                     
defeatObjective = QT_Defeat(quest.Targets[objective]);                  
Debug("Lastwords"
@ string(defeatObjective.LastWords)
@ "for"
@ string(mParticipants.Length)
@ "players");
SetInvulnerable(DefeatNPC,True);                                        
PauseAI(DefeatNPC);                                                     
if (defeatObjective.LastWords != None) {                                
convoStarted = False;                                                 
ti = 0;                                                               
while (ti < mParticipants.Length) {                                   
if (StartConversation(DefeatNPC,mParticipants[ti],defeatObjective.LastWords)) {
convoStarted = True;                                              
}
ti++;                                                               
}
if (!convoStarted) {                                                  
GotoState('NAPState');                                              
}
} else {                                                                
ti = 0;                                                               
while (ti < mParticipants.Length) {                                   
Game_Controller(mParticipants[ti].Controller).sv_FireHook(2,NPC,0); 
ti++;                                                               
}
mParticipants.Length = 0;                                             
GotoState('NAPState');                                                
}
}
}
state WaitingForTeamWipeState {
function EndState() {
if (DefeatNPC != None) {                                                
SetInvulnerable(DefeatNPC,NPCInvulnerable);                           
}
}
protected function OnUnRegister(RegisteredAI aRegisteredAI) {
if (aRegisteredAI.Controller != DefeatNPC
&& GetRegisterSize() == 1) {
GotoState('LastWordsState');                                          
}
Global.OnUnRegister(aRegisteredAI);                                     
}
function bool OnCheckFriendly(Game_AIController aGame_AIController,Game_Pawn potentialEnemy) {
return True;                                                            
}
function BeginState() {
Debug(" waiting state started" @ string(DefeatNPC));                    
SetInvulnerable(DefeatNPC,True);                                        
}
}
state DamageState {
function EndState() {
if (DefeatNPC != None && DefeatNPC.Pawn != None) {                      
RemoveAllDuffs(Game_Pawn(DefeatNPC.Pawn));                            
SetInvulnerable(DefeatNPC,NPCInvulnerable);                           
Idle(DefeatNPC);                                                      
}
}
protected function bool CollectParticipants() {
local Game_NPCPawn NPC;
local Game_PlayerPawn creditEnemy;
local Game_PlayerPawn creditMember;
local int ti;
local array<Game_Pawn> CreditTeam;
local bool ret;
NPC = Game_NPCPawn(DefeatNPC.Pawn);                                     
Killer = NPC.CombatStats.sv_GetKiller();                                
creditEnemy = Game_PlayerPawn(Killer);                                  
if (creditEnemy == None) {                                              
return False;                                                         
}
Game_PlayerController(creditEnemy.Controller).GroupingTeams.sv_GetCreditTeam(CreditTeam,DefeatNPC.Pawn.Location);
Debug("Found credit team of" @ CharName(creditEnemy)
@ "team size="
@ string(CreditTeam.Length));
mParticipants.Length = 0;                                               
ti = 0;                                                                 
while (ti < CreditTeam.Length) {                                        
creditMember = Game_PlayerPawn(CreditTeam[ti]);                       
if (creditMember == None) {                                           
Debug("Credit Team member" @ CharName(CreditTeam[ti])
@ "did not qualify, due to type not being a player");
} else {                                                              
if (!creditMember.questLog.GetTargetActivation(quest,objective)) {  
Debug("Credit Team member" @ CharName(creditMember)
@ "did not qualify, due to not having the objective");
goto jl039C;                                                      
}
if (quest.Targets[objective].Failed(creditMember.questLog.GetTargetProgress(quest,objective))) {
Debug("Credit Team member" @ CharName(creditMember)
@ "did not qualify, due to having failed the objective");
goto jl039C;                                                      
}
if (!Game_Controller(creditMember.Controller).ConversationControl.CanConverse(NPC)) {
Debug("Credit Team member" @ CharName(creditMember)
@ "did not qualify, due to being unavailable for conversation");
} else {                                                            
Debug("Credit Team member" @ CharName(creditMember)
@ "qualified for quest progress");
mParticipants[mParticipants.Length] = creditMember;               
ret = True;                                                       
}
}
ti++;                                                                 
}
return ret;                                                             
}
function bool OnDamage(Game_AIController aController,Actor aCollaborator,float aDamage) {
local export editinline QT_Defeat defeatObjective;
local float Health;
local float currentHealth;
local float MaxHealth;
if (aController == DefeatNPC) {                                         
if (bFinalDamage) {                                                   
Debug("Final damage received" @ string(aDamage)
@ "by"
@ CharName(aCollaborator));
return OnDamage(aController,aCollaborator,aDamage);                 
}
defeatObjective = QT_Defeat(quest.Targets[objective]);                
currentHealth = GetHealth(aController);                               
MaxHealth = GetMaxHealth(aController);                                
Debug("Damage" @ string(aDamage) @ "on"
@ CharName(aController)
@ "Health:"
@ string(currentHealth)
$ "/"
$ string(MaxHealth));
Health = (currentHealth - aDamage) / MaxHealth;                       
if (Health <= defeatObjective.DefeatFraction
|| currentHealth - aDamage <= 0) {
if (CollectParticipants()) {                                        
Health = currentHealth / MaxHealth - defeatObjective.DefeatFraction;
if (Health > 0.00000000) {                                        
Health *= MaxHealth;                                            
if (Health >= currentHealth) {                                  
Health = currentHealth - 1;                                   
}
bFinalDamage = True;                                            
ReceiveDamage(aController,Game_Pawn(aCollaborator),Health);     
bFinalDamage = False;                                           
}
if (GetRegisterSize() == 1) {                                     
GotoState('LastWordsState');                                    
} else {                                                          
GotoState('WaitingForTeamWipeState');                           
}
return True;                                                      
} else {                                                            
Debug("No enemies with the quest active and near found");         
return OnDamage(aController,aCollaborator,aDamage);               
}
} else {                                                              
Debug("Not yet under required health percentage"
@ string(Health * 100.00000000)
$ "/"
$ string(defeatObjective.DefeatFraction * 100.00000000));
return OnDamage(aController,aCollaborator,aDamage);                 
}
} else {                                                                
return OnDamage(aController,aCollaborator,aDamage);                   
}
}
function BeginState() {
Debug(" damage state started" @ string(DefeatNPC));                     
SetInvulnerable(DefeatNPC,False);                                       
mParticipants.Length = 0;                                               
}
}
auto state Initialize {
function SetDefeatNPC(Game_AIController aController) {
if (NPC_Type != None) {                                                 
if (Game_NPCPawn(aController.Pawn).NPCType == NPC_Type) {             
DefeatNPC = aController;                                            
}
} else {                                                                
DefeatNPC = aController;                                              
}
if (DefeatNPC != None) {                                                
Debug(CharName(DefeatNPC.Pawn) @ "Spawned with Health:"
@ string(GetHealth(DefeatNPC))
@ string(GetMaxHealth(DefeatNPC)));
NPCInvulnerable = GetInvulnerable(DefeatNPC);                         
GotoState('DamageState');                                             
}
}
protected function OnRegister(RegisteredAI aRegisteredAI) {
if (quest == None) {                                                    
Failure("Quest not specified");                                       
} else {                                                                
if (!quest.Targets[objective].IsA('QT_Defeat')) {                     
Failure("Target" @ string(objective) @ "of"
@ string(quest)
@ "is not a defeat objective");
}
}
if (DefeatNPC == None) {                                                
SetDefeatNPC(aRegisteredAI.Controller);                               
}
Global.OnRegister(aRegisteredAI);                                       
}
function BeginState() {
Debug(" Initialize state started" @ string(DefeatNPC));                 
DefeatNPC = None;                                                       
}
}
*/