﻿using System;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Game_PetPawn : Game_NPCPawn
    {
        public const float ErrorTimeOut = 3F;

        public byte MoveState;

        public byte AttackState;

        public EventNotification MoveStateChanged;

        public EventNotification AttackStateChanged;

        public Game_Pawn PetOwner;

        private bool ReceivedUpdate;

        [NonSerialized, HideInInspector]
        public float LastErrorTime;

        public Game_PetPawn()
        {
        }
    }
}
/*
function int GetAttackStateName() {
switch (AttackState) {                                                      
case 0 :                                                                  
return Class'StringReferences'.default.Pet_Attack_Aggressive.Id;        
case 1 :                                                                  
return Class'StringReferences'.default.Pet_Attack_Defensive.Id;         
case 2 :                                                                  
return Class'StringReferences'.default.Pet_Attack_Assist.Id;            
case 3 :                                                                  
return Class'StringReferences'.default.Pet_Attack_Passive.Id;           
default:                                                                  
}
}
}
function int GetMoveStateName() {
switch (MoveState) {                                                        
case 1 :                                                                  
return Class'StringReferences'.default.Pet_Move_Follow.Id;              
case 0 :                                                                  
return Class'StringReferences'.default.Pet_Move_Stay.Id;                
default:                                                                  
}
}
}
function byte GetAttackState() {
return AttackState;                                                         
}
function byte GetMoveState() {
return MoveState;                                                           
}
event cl_OnBaseline() {
Super.cl_OnBaseline();                                                      
PetOwner.cl_SetPet(self);                                                   
MoveStateChanged.Trigger();                                                 
AttackStateChanged.Trigger();                                               
}
protected native function sv2clrel_SetPetOwner_CallStub();
event sv2clrel_SetPetOwner(Game_Pawn aOwner) {
aOwner.cl_SetPet(self);                                                     
}
event cl_OnInit() {
Super.cl_OnInit();                                                          
MoveStateChanged = new Class'EventNotification';                            
AttackStateChanged = new Class'EventNotification';                          
PetOwner.cl_SetPet(self);                                                   
}
protected event sv_Callback() {
PetOwner.sv2cl_AddRelayScrollingCombatMessage_CallStub(self,Class'StringReferences'.default.Pet_Command_Callback.Id,Class'FSkill_Enums'.17);
}
protected event sv_Invalid() {
local float CurrentTime;
CurrentTime = Level.TimeSeconds;                                            
if (LastErrorTime < 0.00000000
|| CurrentTime > LastErrorTime + 3.00000000) {
PetOwner.sv2cl_AddRelayScrollingCombatMessage_CallStub(self,Class'StringReferences'.default.Pet_Command_Invalid.Id,Class'FSkill_Enums'.17);
LastErrorTime = CurrentTime;                                              
}
}
protected event sv_Defend(Game_Pawn aTarget) {
PetOwner.sv2cl_AddRelayScrollingCombatMessage_CallStub(self,Class'StringReferences'.default.Pet_Command_Guard.Id,Class'FSkill_Enums'.17);
}
protected event sv_Attack(Game_Pawn aTarget) {
PetOwner.sv2cl_AddRelayScrollingCombatMessage_CallStub(self,Class'StringReferences'.default.Pet_Command_Attack.Id,Class'FSkill_Enums'.17);
}
protected native function sv2clrel_SetPetAttackState_CallStub();
private event sv2clrel_SetPetAttackState(const byte aAttackState) {
if (AttackState != aAttackState) {                                          
AttackState = aAttackState;                                               
AttackStateChanged.Trigger();                                             
}
}
protected event sv_SetPetAttackState(const byte aAttackState) {
AttackState = aAttackState;                                                 
sv2clrel_SetPetAttackState_CallStub(AttackState);                           
PetOwner.sv2cl_AddRelayScrollingCombatMessage_CallStub(self,GetAttackStateName(),17);
}
protected native function sv2clrel_SetPetMoveState_CallStub();
private event sv2clrel_SetPetMoveState(const byte aMoveState) {
if (MoveState != aMoveState) {                                              
MoveState = aMoveState;                                                   
MoveStateChanged.Trigger();                                               
}
}
event sv_SetPetMoveState(const byte aMoveState) {
MoveState = aMoveState;                                                     
sv2clrel_SetPetMoveState_CallStub(MoveState);                               
PetOwner.sv2cl_AddRelayScrollingCombatMessage_CallStub(self,GetMoveStateName(),17);
}
state Dead {
function BeginState() {
Super.BeginState();                                                     
if (SBRole == 1) {                                                      
PetOwner.sv_DestroyPet(False);                                        
}
}
}
*/