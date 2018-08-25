﻿using System;
using Engine;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_CoA_2_PoochAndTack_Script : AIRegistered
    {
        [FoldoutGroup("AIScript_CoA_2_PoochAndTack_Script")]
        public FSkill_Type MourningHowlSkill;

        [FoldoutGroup("AIScript_CoA_2_PoochAndTack_Script")]
        public string DoorTag = string.Empty;

        [FoldoutGroup("AIScript_CoA_2_PoochAndTack_Script")]
        [TypeProxyDefinition(TypeName = "AIStateMachine")]
        public Type ActiveStateMachine;

        public bool IsActive;

        public AIStateMachine OldMachine;

        public AIScript_CoA_2_PoochAndTack_Script()
        {
        }
    }
}
/*
event UnTrigger(Actor Other,Pawn EventInstigator) {
Reset();                                                                    
}
event bool OnDamage(Game_AIController Victim,Actor cause,float Damage) {
Activate();                                                                 
return Super.OnDamage(Victim,cause,Damage);                                 
}
event Trigger(Actor Other,Pawn EventInstigator) {
Activate();                                                                 
}
protected event GetActorRelations(out array<ActorRelation> oRelations) {
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(DoorTag,static.RGB(100,100,255),"DoorTag:" @ DoorTag,oRelations);
}
function Reset() {
local array<RegisteredAI> Register;
local int i;
if (IsActive) {                                                             
Register = GetRegister();                                                 
i = 0;                                                                    
while (i < Register.Length) {                                             
ReturnHome(Register[i].Controller);                                     
SwapStateMachine(Register[i].Controller,OldMachine);                    
SetHealth(Register[i].Controller,GetMaxHealth(Register[i].Controller)); 
i++;                                                                    
}
IsActive = False;                                                         
}
}
function Activate() {
local array<RegisteredAI> Register;
local int i;
if (!IsActive) {                                                            
Register = GetRegister();                                                 
i = 0;                                                                    
while (i < Register.Length) {                                             
OldMachine = SwapStateMachine(Register[i].Controller,new ActiveStateMachine);
i++;                                                                    
}
IsActive = True;                                                          
}
}
function bool OnTimerEnded(Game_AIController aController,Actor aInstigator,name aTag) {
if (aInstigator == self && aTag == 'DoCast') {                              
Debug("try perform skill");                                               
if (CanPerformSkill(aController,MourningHowlSkill)) {                     
if (!HasPausedAI(aController)) {                                        
PauseAI(aController);                                                 
}
PerformSkill(aController,MourningHowlSkill,aController.Pawn.Location);  
ContinueAI(aController);                                                
return False;                                                           
}
return True;                                                              
}
return False;                                                               
}
function bool OnDeath(Game_AIController aController,Actor aCollaborator) {
local bool ret;
local RegisteredAI lRegistered;
ret = Super.OnDeath(aController,aCollaborator);                             
lRegistered = GetFirstRegistered();                                         
Debug("death");                                                             
if (lRegistered != None) {                                                  
Debug("One left, Prepare for Mourning Howl skill ");                      
if (!HasPausedAI(lRegistered.Controller)) {                               
PauseAI(lRegistered.Controller);                                        
}
DrawWeapon(lRegistered.Controller,3);                                     
StartTimer(lRegistered.Controller,'DoCast',0.25000000);                   
} else {                                                                    
TriggerEvent(name(DoorTag),self,None);                                    
}
return ret;                                                                 
}
*/