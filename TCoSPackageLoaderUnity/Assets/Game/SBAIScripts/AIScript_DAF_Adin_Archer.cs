﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Engine;
using SBAI;
using SBAIScripts;
using SBBase;
using SBGame;
using SBGamePlay;
using SBMiniGames;
using System;
using System.Collections;
using System.Collections.Generic;
using Framework.Attributes;

namespace SBAIScripts
{
    
    
    public class AIScript_DAF_Adin_Archer : AIScript_CollectEventinstigators
    {
        
        [FieldCategory(Category="DemonArcher")]
        public FSkill_Type ArcherSkill;
        
        [FieldCategory(Category="DemonArcher")]
        public float MinAttackDelay;
        
        [FieldCategory(Category="DemonArcher")]
        public float MaxAttackDelay;
        
        public float AttackTimeOut;
        
        public bool PendingDespawn;
        
        public AIScript_DAF_Adin_Archer()
        {
        }
    }
}
/*
function DoUnTriggerAction(Actor Other,Pawn EventInstigator) {
PendingDespawn = True;                                                      
}
event bool OnTick(Game_AIController aController,float DeltaTime) {
local int i;
AttackTimeOut -= DeltaTime;                                                 
if (AttackTimeOut <= 0) {                                                   
if (Instigators.Length > 0) {                                             
CleanInstigators();                                                     
i = Rand(Instigators.Length);                                           
if (!HasWeaponDrawn(aController)) {                                     
DrawWeapon(aController);                                              
} else {                                                                
if (Game_Pawn(aController.Pawn).IsHostile(Game_Pawn(Instigators[i].Pawn))) {
LookAt(aController,Instigators[i].Pawn.Location);                   
if (CanPerformSkill(aController,ArcherSkill)) {                     
PerformSkill(aController,ArcherSkill,Instigators[i].Pawn.Location);
}
}
}
AttackTimeOut = RandomFloat(MinAttackDelay,MaxAttackDelay);             
}
}
if (PendingDespawn) {                                                       
Despawn(aController);                                                     
}
return Super.OnTick(aController,DeltaTime);                                 
}
function AddInstigator(Game_Controller aInstigator) {
if (aInstigator.Pawn.IsA('Game_Pawn')) {                                    
Super.AddInstigator(aInstigator);                                         
}
}
function OnBegin(Game_AIController aController) {
Super.OnBegin(aController);                                                 
PauseAI(aController);                                                       
SetInvulnerable(aController,True);                                          
SetDetection(aController,True);                                             
AttackTimeOut = MaxAttackDelay;                                             
}
*/
