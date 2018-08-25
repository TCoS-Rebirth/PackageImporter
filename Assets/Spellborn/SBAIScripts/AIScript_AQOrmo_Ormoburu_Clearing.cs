﻿using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_AQOrmo_Ormoburu_Clearing : AI_Script
    {
        [FoldoutGroup("Ormoburu")]
        [FieldConst()]
        public float SuccessHealthLevel;

        [FoldoutGroup("Ormoburu")]
        [FieldConst()]
        public float SpawnHealthLevel;

        [FoldoutGroup("Ormoburu")]
        [FieldConst()]
        public string SpawnEvent = string.Empty;

        [FoldoutGroup("Ormoburu")]
        [FieldConst()]
        public string SuccessEvent = string.Empty;

        [FoldoutGroup("Ormoburu")]
        public List<NPC_Type> VhelgarHunterNPCTypes = new List<NPC_Type>();

        [FoldoutGroup("Ormoburu")]
        [FieldConst()]
        public FSkill_Type BreathAttack;

        [FoldoutGroup("Ormoburu")]
        [FieldConst()]
        public Actor BreathAttackLocation;

        [FoldoutGroup("Ormoburu")]
        [FieldConst()]
        public FSkill_EffectClass_AudioVisual AttachementSpellEffect;

        public Game_AIController OrmoController;

        public float SuccessHealth;

        public float SpawnHealth;

        public AIStateMachine OldMachine;

        public float Timeout;

        public bool Vulnerable;

        public bool HasSucceeded;

        public AIScript_AQOrmo_Ormoburu_Clearing()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(SpawnEvent,static.RGB(100,100,255),"SpawnEvent:" @ SpawnEvent,oRelations);
GetTaggedRelations(SuccessEvent,static.RGB(100,100,255),"SuccessEvent:" @ SuccessEvent,oRelations);
}
function bool OnDamage(Game_AIController aController,Actor cause,float aDamage) {
local float Health;
Health = GetHealth(aController) - aDamage;                                  
if (Health < SuccessHealth) {                                               
TriggerEvent(name(SuccessEvent),self,aController.Pawn);                   
HasSucceeded = True;                                                      
VhelgarHunterNPCTypes.Length = 0;                                         
aController.Pawn.SetHealth(GetMaxHealth(aController));                    
SetInvulnerable(aController,True);                                        
ApplyAudioVisualEffect(Game_Pawn(aController.Pawn),AttachementSpellEffect);
PauseAI(aController);                                                     
MoveTo(aController,BreathAttackLocation.Location,BreathAttack.MaxDistance);
return True;                                                              
} else {                                                                    
if (Health < SpawnHealth) {                                               
TriggerEvent(name(SpawnEvent),self,aController.Pawn);                   
PlayControllerAnimation(aController,RandomInt(1,2),Class'SBAnimationFlags'.57);
SpawnHealth -= GetMaxHealth(aController) * SpawnHealthLevel;            
}
}
return Super.OnDamage(aController,cause,aDamage);                           
}
event OnEnd(Game_AIController aController) {
if (HasPausedAI(aController)) {                                             
ContinueAI(aController);                                                  
}
Super.OnEnd(aController);                                                   
}
event bool OnCheckFriendly(Game_AIController aController,Game_Pawn potentialFriend) {
local int i;
if (VhelgarHunterNPCTypes.Length > 0) {                                     
if (potentialFriend.IsA('Game_NPCPawn')) {                                
i = 0;                                                                  
while (i < VhelgarHunterNPCTypes.Length) {                              
if (VhelgarHunterNPCTypes[i] == Game_NPCPawn(potentialFriend).NPCType) {
return False;                                                       
}
i++;                                                                  
}
}
return True;                                                              
}
return Super.OnCheckFriendly(aController,potentialFriend);                  
}
event bool OnTick(Game_AIController aController,float DeltaTime) {
if (HasSucceeded) {                                                         
Timeout -= DeltaTime;                                                     
if (!IsMoving(aController) && Timeout <= 0) {                             
PerformSkill(aController,BreathAttack,BreathAttackLocation.Location);   
LookAt(aController,BreathAttackLocation.Location);                      
}
}
return Super.OnTick(aController,DeltaTime);                                 
}
event Trigger(Actor Other,Pawn EventInstigator) {
local int i;
if (VhelgarHunterNPCTypes.Length > 0
&& EventInstigator.IsA('Game_NPCPawn')) {
i = 0;                                                                    
while (i < VhelgarHunterNPCTypes.Length) {                                
if (Game_NPCPawn(EventInstigator).NPCType == VhelgarHunterNPCTypes[i]) {
VhelgarHunterNPCTypes.Remove(i,1);                                    
goto jl0075;                                                          
}
i++;                                                                    
}
goto jl00B5;                                                              
}
if (!Vulnerable) {                                                          
Vulnerable = True;                                                        
SetInvulnerable(OrmoController,False);                                    
} else {                                                                    
SwapStateMachine(OrmoController,OldMachine);                              
ChangeToNextScript(OrmoController);                                       
}
}
event OnBegin(Game_AIController aController) {
Super.OnBegin(aController);                                                 
OrmoController = aController;                                               
SuccessHealth = GetMaxHealth(aController) * SuccessHealthLevel;             
SpawnHealth = GetMaxHealth(aController) * (1 - SpawnHealthLevel);           
SetInvulnerable(aController,True);                                          
TriggerEvent(name(SpawnEvent),aController.Pawn,None);                       
PlayControllerAnimation(aController,RandomInt(1,2),Class'SBAnimationFlags'.57);
OldMachine = SwapStateMachine(aController,new Class'AIKillingMachine');     
aController.SetHomeLocation(aController.Pawn.Location);                     
}
*/