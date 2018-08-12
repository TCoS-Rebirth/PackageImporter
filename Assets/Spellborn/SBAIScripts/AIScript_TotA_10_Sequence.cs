using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_TotA_10_Sequence : AI_Script
    {
        [FoldoutGroup("AIScript_TotA_10_Sequence")]
        public List<FSkill_EffectClass_AudioVisual> TeleportEffects = new List<FSkill_EffectClass_AudioVisual>();

        [FoldoutGroup("AIScript_TotA_10_Sequence")]
        public NavigationPoint TeleportPointHome;

        [FoldoutGroup("AIScript_TotA_10_Sequence")]
        public NavigationPoint TeleportPointMiddle;

        [FoldoutGroup("AIScript_TotA_10_Sequence")]
        public NavigationPoint TeleportPointFront;

        [FoldoutGroup("AIScript_TotA_10_Sequence")]
        public string SpawnEvent = string.Empty;

        [FoldoutGroup("AIScript_TotA_10_Sequence")]
        public float TeleportTimerMax;

        [FoldoutGroup("AIScript_TotA_10_Sequence")]
        public float TeleportTimerMin;

        [FoldoutGroup("AIScript_TotA_10_Sequence")]
        public float SpawnTimer;

        [FoldoutGroup("AIScript_TotA_10_Sequence")]
        public float MaxTeleportDistance;

        [FoldoutGroup("AIScript_TotA_10_Sequence")]
        public string ChatEventOnBegin = string.Empty;

        [FoldoutGroup("AIScript_TotA_10_Sequence")]
        public string ChatEventOnSpawn = string.Empty;

        [FoldoutGroup("AIScript_TotA_10_Sequence")]
        public string ChatEventOnTeleport = string.Empty;

        [FoldoutGroup("AIScript_TotA_10_Sequence")]
        public float OnSpawnTimeout;

        [FoldoutGroup("AIScript_TotA_10_Sequence")]
        public string SuccesEvent = string.Empty;

        public float VulnerableHealth;

        public byte UlthagorState;

        public Vector TeleportTargetLocation;

        public int MinionSpawnCount;

        public Game_AIController UlthagorController;

        public bool bFinalDamage;

        public AIScript_TotA_10_Sequence()
        {
        }

        public enum EUlthagorStates
        {
            ULT_INVULNERABLE,

            ULT_VULNERABLE,

            ULT_TELEPORTEDTOFRONT,

            ULT_TELEPORTEDTOMIDDLE,
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(SpawnEvent,static.RGB(100,100,255),"SpawnEvent:" @ SpawnEvent,oRelations);
GetTaggedRelations(ChatEventOnBegin,static.RGB(100,100,255),"ChatEventOnBegin:" @ ChatEventOnBegin,oRelations);
GetTaggedRelations(ChatEventOnSpawn,static.RGB(100,100,255),"ChatEventOnSpawn:" @ ChatEventOnSpawn,oRelations);
GetTaggedRelations(ChatEventOnTeleport,static.RGB(100,100,255),"ChatEventOnTeleport:" @ ChatEventOnTeleport,oRelations);
GetTaggedRelations(SuccesEvent,static.RGB(100,100,255),"SuccesEvent:" @ SuccesEvent,oRelations);
}
event Trigger(Actor Other,Pawn EventInstigator) {
switch (UlthagorState) {                                                    
case 2 :                                                                  
StartTimer(UlthagorController,'TeleportToMiddle',0.00000000);           
ChangeState(UlthagorController,0);                                      
break;                                                                  
case 3 :                                                                  
StartTimer(UlthagorController,'TeleportToHome',0.00000000);             
ChangeState(UlthagorController,0);                                      
break;                                                                  
default:                                                                  
}
}
event bool OnCheckHabitat(Game_AIController aController,Vector aLocation,NPC_Habitat aHabitat) {
return True;                                                                
}
function DoTeleport(Game_AIController aController) {
local int i;
SetControllerLocation(aController,TeleportTargetLocation);                  
aController.SetHomeLocation(TeleportTargetLocation);                        
i = 0;                                                                      
while (i < TeleportEffects.Length) {                                        
ApplyOneShotAudioVisualEffect(Game_Pawn(aController.Pawn),TeleportEffects[i]);
i++;                                                                      
}
ContinueAI(aController);                                                    
}
function StartTeleportTo(Game_AIController aController,Actor aTarget) {
local int i;
local Vector Extent;
Extent = aController.Pawn.GetCollisionExtent();                             
TeleportTargetLocation = Class'Content_API'.RandomRadiusLocation(aTarget,MaxTeleportDistance,MaxTeleportDistance,False,aController.Pawn.GetCollisionExtent(),True);
TeleportTargetLocation.Z -= Extent.Z;                                       
if (TeleportTargetLocation == vect(0.000000, 0.000000, 0.000000)
|| !Class'Content_API'.ValidLocation(aTarget,TeleportTargetLocation,Extent)) {
TeleportTargetLocation = Class'Content_API'.NearestValidLocation(aTarget,aTarget.Location,Extent,aController.Pawn.IsGrounded());
} else {                                                                    
TeleportTargetLocation.Z += Extent.Z;                                     
}
PauseAI(aController);                                                       
StopMovement(aController);                                                  
i = 0;                                                                      
while (i < TeleportEffects.Length) {                                        
ApplyOneShotAudioVisualEffect(Game_Pawn(aController.Pawn),TeleportEffects[i]);
i++;                                                                      
}
StartTimer(aController,'DoTeleport',1.00000000);                            
}
function ChangeState(Game_AIController aController,byte aState) {
StopTimer(aController,'RandomTeleport');                                    
StopTimer(aController,'SpawnMinions');                                      
UlthagorState = aState;                                                     
}
function bool OnDebuff(Game_AIController Victim,Game_Pawn aInstigator,export editinline FSkill_EffectClass aEffect,float aValue) {
if (UlthagorState == 0) {                                                   
return True;                                                              
} else {                                                                    
return Super.OnDebuff(Victim,aInstigator,aEffect,aValue);                 
}
}
function bool OnBuff(Game_AIController Victim,Game_Pawn aInstigator,export editinline FSkill_EffectClass aEffect,float aValue) {
if (UlthagorState == 0) {                                                   
return True;                                                              
} else {                                                                    
return Super.OnBuff(Victim,aInstigator,aEffect,aValue);                   
}
}
function bool OnDamage(Game_AIController aController,Actor cause,float aDamage) {
local float Health;
local int currentBracket;
local int newBracket;
Health = GetHealth(aController) - aDamage;                                  
if (bFinalDamage) {                                                         
bFinalDamage = False;                                                     
} else {                                                                    
switch (UlthagorState) {                                                  
case 0 :                                                                
return True;                                                          
case 1 :                                                                
currentBracket = Round(5.00000000 * GetHealth(aController) / GetMaxHealth(aController));
newBracket = Round(5.00000000 * Health / GetMaxHealth(aController));  
if (newBracket < currentBracket) {                                    
bFinalDamage = True;                                                
ReceiveDamage(aController,Game_Pawn(cause),GetHealth(aController) - GetMaxHealth(aController) / 5 * newBracket);
StartTimer(aController,'TeleportToFront',0.00000000);               
ChangeState(aController,0);                                         
return True;                                                        
}
break;                                                                
case 2 :                                                                
if (Health <= GetMaxHealth(aController) / 2) {                        
bFinalDamage = True;                                                
ReceiveDamage(aController,Game_Pawn(cause),GetHealth(aController) - GetMaxHealth(aController) / 2);
StartTimer(aController,'TeleportToMiddle',0.00000000);              
ChangeState(aController,0);                                         
return True;                                                        
}
break;                                                                
case 3 :                                                                
if (Health <= 0) {                                                    
StartTimer(aController,'TeleportToHome',0.00000000);                
ChangeState(aController,0);                                         
return True;                                                        
}
break;                                                                
default:                                                                
}
}
return Super.OnDamage(aController,cause,aDamage);                           
}
function bool OnTimerEnded(Game_AIController aController,Actor aInstigator,name aTag) {
local int i;
switch (aTag) {                                                             
case 'BecomeVulnerable' :                                                 
VulnerableHealth = GetHealth(aController);                              
ChangeState(aController,1);                                             
break;                                                                  
case 'TeleportToFront' :                                                  
VulnerableHealth = GetHealth(aController);                              
Game_Pawn(aController.Pawn).SetHealth(GetMaxHealth(aController));       
StartTeleportTo(aController,TeleportPointFront);                        
TriggerEvent(name(ChatEventOnTeleport),self,None);                      
ChangeState(aController,2);                                             
StartTimer(aController,'RandomTeleport',static.FRandRange(TeleportTimerMin,Max(TeleportTimerMin,TeleportTimerMax)));
StartTimer(aController,'SpawnMinions',SpawnTimer);                      
break;                                                                  
case 'TeleportToMiddle' :                                                 
StartTeleportTo(aController,TeleportPointMiddle);                       
TriggerEvent(name(ChatEventOnTeleport),self,None);                      
ChangeState(aController,3);                                             
UntriggerEvent(name(SpawnEvent),self,None);                             
StartTimer(aController,'RandomTeleport',static.FRandRange(TeleportTimerMin,Max(TeleportTimerMin,TeleportTimerMax)));
StartTimer(aController,'SpawnMinions',SpawnTimer);                      
break;                                                                  
case 'TeleportToHome' :                                                   
Game_Pawn(aController.Pawn).SetHealth(VulnerableHealth);                
StartTeleportTo(aController,TeleportPointHome);                         
TriggerEvent(name(ChatEventOnTeleport),self,None);                      
UntriggerEvent(name(SpawnEvent),self,None);                             
ChangeState(aController,1);                                             
break;                                                                  
case 'RandomTeleport' :                                                   
switch (UlthagorState) {                                                
case 2 :                                                              
StartTeleportTo(aController,TeleportPointFront);                    
break;                                                              
case 3 :                                                              
StartTeleportTo(aController,TeleportPointMiddle);                   
break;                                                              
default:                                                              
}
StartTimer(aController,'RandomTeleport',static.FRandRange(TeleportTimerMin,Max(TeleportTimerMin,TeleportTimerMax)));
break;                                                                  
case 'DoTeleport' :                                                       
DoTeleport(aController);                                                
break;                                                                  
case 'SpawnMinions' :                                                     
i = 0;                                                                  
while (i < MinionSpawnCount) {                                          
TriggerEvent(name(SpawnEvent),aController.Pawn,None);                 
i++;                                                                  
}
TriggerEvent(name(ChatEventOnSpawn),self,None);                         
break;                                                                  
default:                                                                  
}
return False;                                                               
}
function ResetSequence(Game_AIController aController) {
ChangeState(aController,0);                                                 
UntriggerEvent(name(SpawnEvent),self,None);                                 
UlthagorController = None;                                                  
}
event OnEnd(Game_AIController aController) {
ResetSequence(aController);                                                 
Super.OnEnd(aController);                                                   
}
event OnDespawn(Game_AIController aController) {
ResetSequence(aController);                                                 
Super.OnDespawn(aController);                                               
}
function bool OnDeath(Game_AIController aController,Actor aCollaborator) {
ResetSequence(aController);                                                 
TriggerEvent(name(SuccesEvent),self,None);                                  
return Super.OnDeath(aController,aCollaborator);                            
}
function OnBegin(Game_AIController aController) {
UlthagorController = aController;                                           
TriggerEvent(name(ChatEventOnBegin),self,None);                             
StartTimer(aController,'BecomeVulnerable',OnSpawnTimeout);                  
ChangeState(aController,0);                                                 
}
*/