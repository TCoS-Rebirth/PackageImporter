﻿using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_DAF_Adin_Archer : AIScript_CollectEventinstigators
    {
        [FoldoutGroup("DemonArcher")]
        public FSkill_Type ArcherSkill;

        [FoldoutGroup("DemonArcher")]
        public float MinAttackDelay;

        [FoldoutGroup("DemonArcher")]
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