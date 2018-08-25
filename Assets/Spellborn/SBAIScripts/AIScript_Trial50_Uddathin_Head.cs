﻿using System;
using Engine;
using SBAI;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_Trial50_Uddathin_Head : AI_Script
    {
        [FoldoutGroup("UddathinHead")]
        public float SubmergePercentage;

        [FoldoutGroup("UddathinHead")]
        public LocalizedString WelcomeChat;

        [FoldoutGroup("UddathinHead")]
        public float SubmergeTime;

        [FoldoutGroup("UddathinHead")]
        public string Phase1Event = string.Empty;

        public Game_AIController Controller;

        public float SubmergeHealth;

        public bool IsSubmerged;

        public float SubmergeTimeout;

        public int SubmergeCountDown;

        public bool IsActive;

        public bool IsInPhase2;

        public AIScript_Trial50_Uddathin_Head()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(Phase1Event,static.RGB(100,100,255),"Phase1Event:" @ Phase1Event,oRelations);
}
event bool OnDeath(Game_AIController aController,Actor aDeceasedActor) {
Controller = None;                                                          
return Super.OnDeath(aController,aDeceasedActor);                           
}
function Emerge(Game_AIController aController) {
if (IsSubmerged) {                                                          
ContinueAI(aController);                                                  
IsSubmerged = False;                                                      
Game_Pawn(aController.Pawn).SetPhysics(22);                               
SetInvulnerable(aController,False);                                       
}
}
function Submerge(Game_AIController aController) {
local float checkHealth;
if (IsInPhase2) {                                                           
checkHealth = GetHealth(aController);                                     
} else {                                                                    
checkHealth = GetMaxHealth(aController);                                  
}
if (!IsSubmerged && SubmergeCountDown > 0) {                                
SubmergeCountDown--;                                                      
SubmergeHealth = SubmergePercentage * (SubmergeCountDown + 1) * GetMaxHealth(aController);
if (!checkHealth > SubmergeHealth) goto jl0046;                           
if (!IsInPhase2) {                                                        
TriggerEvent(name(Phase1Event),None,None);                              
}
Game_Pawn(aController.Pawn).SetPhysics(21);                               
SubmergeTimeout = SubmergeTime;                                           
IsSubmerged = True;                                                       
PauseAI(aController);                                                     
SetInvulnerable(aController,True);                                        
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
if (!IsActive) {                                                            
IsActive = True;                                                          
Emerge(Controller);                                                       
if (WelcomeChat.Id > 0) {                                                 
LocalizedChat(Controller,WelcomeChat);                                  
}
} else {                                                                    
if (!IsInPhase2) {                                                        
Game_Pawn(Controller.Pawn).SetHealth(GetMaxHealth(Controller));         
Emerge(Controller);                                                     
IsInPhase2 = True;                                                      
}
}
}
function bool OnDamage(Game_AIController Victim,Actor cause,float aDamage) {
Debug("HEAD DAMAGE  h:" @ string(GetHealth(Victim))
@ " d:"
@ string(aDamage)
@ " pd:"
@ string(GetHealth(Victim) - aDamage)
@ " lim:"
@ string(SubmergeHealth)
@ " #:"
@ string(SubmergeCountDown));
if (GetHealth(Victim) - aDamage < SubmergeHealth) {                         
Submerge(Victim);                                                         
}
return Super.OnDamage(Victim,cause,aDamage);                                
}
event bool OnTick(Game_AIController aController,float DeltaTime) {
if (IsSubmerged && IsInPhase2) {                                            
SubmergeTimeout -= DeltaTime;                                             
if (SubmergeTimeout <= 0) {                                               
Emerge(aController);                                                    
}
}
return Super.OnTick(aController,DeltaTime);                                 
}
function OnBegin(Game_AIController aController) {
Super.OnBegin(aController);                                                 
if (SubmergePercentage <= 0 || SubmergePercentage >= 1) {                   
Failure("AIScript_Trial50_Uddathin_Head; SubmergePercentage outside <0,1> range!");
}
Controller = aController;                                                   
IsInPhase2 = False;                                                         
IsActive = False;                                                           
IsSubmerged = True;                                                         
SubmergeHealth = SubmergePercentage * GetMaxHealth(aController);            
SubmergeCountDown = 1 / SubmergePercentage - 1;                             
PauseAI(aController);                                                       
}
*/