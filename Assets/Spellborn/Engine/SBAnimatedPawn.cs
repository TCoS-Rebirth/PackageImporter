using System;
using System.Collections.Generic;
using UnityEngine;

namespace Engine
{
#pragma warning disable 414   

    [Serializable] public class SBAnimatedPawn : Pawn
    {
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private bool bSittingOnChair;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool bAnimationPaused;

        #region enums
        public enum SBAnimationType
        {
            SBAnimType_None = 0,

            SBAnimType_Idle = 1,

            SBAnimType_Emote = 2,

            SBAnimType_Movement = 3,

            SBAnimType_LightWound = 4,

            SBAnimType_Action = 5,

            SBAnimType_SpecialAction = 6,

            SBAnimType_HeavyWound = 7,

            SBAnimType_Death = 8,

            SBAnimType_AlwaysPlayed = 9,

            SBAnimType_Turning = 10,

            SBAnimType_Emerging = 11,
        }

        public enum EPawnSound
        {
            EPS_Command_Enemies = 0,

            EPS_Command_GetReady = 1,

            EPS_Command_Charge = 2,

            EPS_Command_Attack = 3,

            EPS_Command_Retreat = 4,

            EPS_Command_Follow = 5,

            EPS_Command_Wait = 6,

            EPS_Command_ComeOn = 7,

            EPS_Command_Assistance = 8,

            EPS_Command_OverHere = 9,

            EPS_Command_BackOff = 10,

            EPS_Command_North = 11,

            EPS_Command_East = 12,

            EPS_Command_West = 13,

            EPS_Command_South = 14,

            EPS_Command_Flank = 15,

            EPS_Command_GoRound = 16,

            EPS_Action = 17,

            EPS_CriticalWound = 18,

            EPS_Death = 19,

            EPS_Interaction_No = 20,

            EPS_Interaction_Yes = 21,

            EPS_Interaction_Greet = 22,

            EPS_Interaction_Bye = 23,

            EPS_Interaction_Thanks = 24,

            EPS_Interaction_PwnieQues = 25,

            EPS_Interaction_PwnieExcl = 26,

            EPS_Interaction_Trade = 27,

            EPS_Interaction_Excuse = 28,

            EPS_Interaction_Wait = 29,

            EPS_Interaction_Veto = 30,

            EPS_Interaction_Sarcasm = 31,

            EPS_Interaction_Hey = 32,

            EPS_Interaction_Oldskool = 33,

            EPS_Interaction_Outfit = 34,

            EPS_Interaction_FashionPolice = 35,

            EPS_Interaction_Jazz = 36,

            EPS_Sound_Clap = 37,

            EPS_Sound_Kiss = 38,

            EPS_Sound_Sigh = 39,

            EPS_Sound_Bored = 40,

            EPS_Sound_Pain = 41,

            EPS_Sound_Pst = 42,

            EPS_Sound_Angry = 43,

            EPS_Sound_Cry = 44,

            EPS_Sound_Maniacal = 45,

            EPS_Sound_Laugh = 46,

            EPS_Sound_Cough = 47,

            EPS_Sound_Cheer = 48,

            EPS_Sound_WhistleHappy = 49,

            EPS_Sound_WhistleAttention = 50,

            EPS_Sound_WhistleMusic = 51,

            EPS_Sound_WhistleNote = 52,

            EPS_Sound_Ahh = 53,

            EPS_Sound_Gasp = 54,

            EPS_Sound_Stretch = 55,

            EPS_Sound_Huf = 56,

            EPS_Sound_Bah = 57,

            EPS_Sound_Dismiss = 58,

            EPS_Taunt_Oracle = 59,

            EPS_Taunt_Battle = 60,

            EPS_Taunt_Praise = 61,

            EPS_Taunt_Mock = 62,

            EPS_Taunt_Attention = 63,

            EPS_Taunt_Death = 64,

            EPS_Taunt_Stop = 65,

            EPS_Taunt_AdmireRoom = 66,

            EPS_Taunt_Victory = 67,

            EPS_Taunt_Survive = 68,

            EPS_Taunt_Again = 69,

            EPS_Taunt_Try = 70,

            EPS_Taunt_LetsGo = 71,

            EPS_Taunt_RTFM = 72,

            EPS_Taunt_Unique = 73,

            EPS_Wound = 74,

            EPS_Goodbye = 75,

            EPS_Greet = 76,

            EPS_Thanks = 77,

            EPS_Yay = 78,

            EPS_Weee = 79,

            EPS_NONE = 80,
        }
        #endregion


    }
}
/*
native function RemoveAllAttachments();
native function InitializeAttachmentModel(string attachmentType,string boneTag,Object MeshObject);
native function PauseAnim(bool pause,optional byte AnimType);
native function PlayAnimType(name animName,byte AnimType,float Rate,float TweenTime,bool loop,bool keepLastFrame);
native function ClearAnimsByType(byte animationTypeId,float blendOutRate);
native function ClearPawnAnims();
function ClearAnims() {
ClearPawnAnims();                                                           
}
native function bool AnimationFlagsActive(array<int> ActionFlags,optional int directionFlag,optional int WeaponFlag,optional int varNumber);
native function bool AnimationPlaying(name AnimationName);
native function FadeInQueuedAnimations(float FadeInTime,optional bool keepLastFrame);
native function PlayQueuedAnimations(bool forceOverwrite,bool keepLastFrame,optional bool alowImmediateCull);
native function QueueAnimation(array<int> ActionFlags,int variationNr,float AnimSpeed,float BlendInTime,float BlendOutTime,bool isLooping,optional coerce int AnimationType);
native function Vector GetMovementDirectionVector();
native function float GetAnimationDuration(array<int> ActionFlags,int variationNr,float AnimSpeed);
event OnSheatheWeapon(byte WeaponFlag);
event OnDrawWeapon(byte WeaponFlag);
function PlayTopLevelAnim(name animName,float Rate,float TweenTime,bool loop,bool keepLastFrame) {
PlayAnimType(animName,9,Rate,TweenTime,loop,keepLastFrame);                 
}
event byte GetEquippedWeaponFlag() {
return 0;                                                                   
}
function sv_HackDamageActions(float aDamageFactor);
event FreezeRotation(bool aFreezeFlag);
event FreezeMovement(bool aFreezeFlag);
function ExecuteDeath(Pawn instigatedBy,Vector HitLocation,Vector Momentum,class<DamageType> DamageType) {
local Controller Killer;
if (DamageType.default.bCausedByWorld
&& (instigatedBy == None || instigatedBy == self)
&& LastHitBy != None) {
Killer = LastHitBy;                                                       
} else {                                                                    
if (instigatedBy != None) {                                               
Killer = instigatedBy.GetKillerController();                            
}
}
if (Killer == None
&& DamageType.default.bDelayedDamage) {            
Killer = DelayedDamageInstigatorController;                               
}
if (bPhysicsAnimUpdate) {                                                   
TearOffMomentum = Momentum;                                               
}
Died(Killer,DamageType,HitLocation);                                        
}
function TakeDamage(int Damage,Pawn instigatedBy,Vector HitLocation,Vector Momentum,class<DamageType> DamageType) {
local int actualDamage;
if (Damage <= 0) {                                                          
return;                                                                   
}
if (DamageType == Class'Crushed') {                                         
return;                                                                   
}
if (DamageType == None) {                                                   
if (instigatedBy != None) {                                               
Warn("No damagetype for damage by " $ string(instigatedBy));            
}
DamageType = Class'DamageType';                                           
}
if (SBRole != 1) {                                                          
return;                                                                   
}
if (GetHealth() <= 0) {                                                     
return;                                                                   
}
if ((instigatedBy == None
|| instigatedBy.Controller == None)
&& DamageType.default.bDelayedDamage
&& DelayedDamageInstigatorController != None) {
instigatedBy = DelayedDamageInstigatorController.Pawn;                    
}
if (Physics == 1
&& DamageType.default.bExtraMomentumZ) {             
Momentum.Z = FMax(Momentum.Z,0.40000001 * VSize(Momentum));               
}
if (instigatedBy == self) {                                                 
Momentum *= 0.60000002;                                                   
}
Momentum = Momentum / Mass;                                                 
actualDamage = Damage;                                                      
IncreaseHealth(-actualDamage);                                              
if (HitLocation == vect(0.000000, 0.000000, 0.000000)) {                    
HitLocation = Location;                                                   
}
if (GetHealth() <= 0) {                                                     
ExecuteDeath(instigatedBy,HitLocation,Momentum,DamageType);               
} else {                                                                    
AddVelocity(Momentum);                                                    
if (Controller != None) {                                                 
Controller.NotifyTakeHit(instigatedBy,HitLocation,actualDamage,DamageType,Momentum);
}
if (instigatedBy != None && instigatedBy != self) {                       
LastHitBy = instigatedBy.Controller;                                    
}
sv_HackDamageActions(actualDamage);                                       
}
MakeNoise(1.00000000);                                                      
}
function Died(Controller Killer,class<DamageType> DamageType,Vector HitLocation) {
local Trigger t;
local NavigationPoint N;
if (bDeleteMe || Level.bLevelChange
|| GetGameInfo() == None) {       
return;                                                                   
}
if (DamageType.default.bCausedByWorld
&& (Killer == None || Killer == Controller)
&& LastHitBy != None) {
Killer = LastHitBy;                                                       
}
SetHealth(Min(0,GetHealth()));                                              
if (Controller != None) {                                                   
Controller.WasKilledBy(Killer);                                           
goto jl00AA;                                                              
}
if (Killer != None) {                                                       
TriggerEvent(Event,self,Killer.Pawn);                                     
} else {                                                                    
TriggerEvent(Event,self,None);                                            
}
if (IsPlayerPawn() || WasPlayerPawn()) {                                    
PhysicsVolume.PlayerPawnDiedInVolume(self);                               
foreach TouchingActors(Class'Trigger',t) {                                
t.PlayerToucherDied(self);                                              
}
foreach TouchingActors(Class'NavigationPoint',N) {                        
if (N.bReceivePlayerToucherDiedNotify) {                                
N.PlayerToucherDied(self);                                            
}
}
}
Velocity.Z *= 1.29999995;                                                   
if (IsHumanControlled()) {                                                  
PlayerController(Controller).ForceDeathUpdate();                          
} else {                                                                    
PlayDying(DamageType,HitLocation);                                        
}
}
*/