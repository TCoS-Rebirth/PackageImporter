﻿using System;
using SBGame;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Engine
{
    [Serializable] public class Pawn : Actor, IActorPacketStream
    {
        public Controller Controller;

        [FieldConst()]
        [NonSerialized, HideInInspector]
        public bool bReducedSpeed;

        [NonSerialized, HideInInspector]
        public bool bUseCompressedPosition = true;

        [NonSerialized, HideInInspector]
        public byte Visibility;

        [NonSerialized, HideInInspector]
        public float DesiredSpeed;

        [NonSerialized, HideInInspector]
        public float MaxDesiredSpeed;

        [FoldoutGroup("aI")]
        [NonSerialized, HideInInspector]
        public NameProperty AIScriptTag;

        [FoldoutGroup("Pawn")]
        [NonSerialized, HideInInspector]
        public float SkillModifier;

        [NonSerialized, HideInInspector]
        public float MeleeRange;

        [NonSerialized, HideInInspector]
        public float NavigationPointRange;

        [NonSerialized, HideInInspector]
        public NavigationPoint Anchor;

        [FoldoutGroup("Movement")]
        public float GroundSpeed = 220;

        [NonSerialized, HideInInspector]
        public float WaterSpeed = 200;

        [NonSerialized, HideInInspector]
        public float AirSpeed = 200;

        [NonSerialized, HideInInspector]
        public float AccelRate = 500;

        [NonSerialized, HideInInspector]
        public float JumpZ = 325;

        [NonSerialized, HideInInspector]
        public float AirControl = 0.05f;

        [NonSerialized, HideInInspector]
        public float WalkingPct;

        [NonSerialized, HideInInspector]
        public float CrouchedPct;

        [NonSerialized, HideInInspector]
        public float MaxFallSpeed;

        [NonSerialized, HideInInspector]
        public string OwnerName = string.Empty;

        [TypeProxyDefinition(TypeName = "AIController")]
        public Type ControllerClass;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public CompressedPosition PawnPosition;

        [NonSerialized, HideInInspector]
        public float MaxRotation;

        public virtual void WriteLoginStream(IPacketWriter writer) { throw new NotImplementedException(); }

    }
}
/*
simulated function ClientSetDesiredMovement(Vector aVector) {
desiredMovement = aVector;                                                  
}
function SetDesiredMovement(Vector aVector) {
desiredMovement = aVector;                                                  
ClientSetDesiredMovement(aVector);                                          
}
simulated function Vector GetTargetLocation() {
return Location;                                                            
}
function float RangedAttackTime() {
return 0.00000000;                                                          
}
function bool CheatFly() {
UnderWaterTime = default.UnderWaterTime;                                    
SetCollision(True,True);                                                    
bCollideWorld = True;                                                       
return True;                                                                
}
function bool CheatGhost() {
UnderWaterTime = -1.00000000;                                               
SetCollision(False,False);                                                  
bCollideWorld = False;                                                      
return True;                                                                
}
function bool CheatWalk() {
UnderWaterTime = default.UnderWaterTime;                                    
SetCollision(True,True);                                                    
SetPhysics(1);                                                              
bCollideWorld = True;                                                       
return True;                                                                
}
simulated function RawInput(float DeltaTime,float aBaseX,float aBaseY,float aBaseZ,float aMouseX,float aMouseY,float aForward,float aTurn,float aStrafe,float aUp,float aLookUp) {
}
function PlayVictoryAnimation();
simulated event PlayLandingAnimation(float impactVel);
function PlayLanded(float impactVel) {
if (!bPhysicsAnimUpdate) {                                                  
PlayLandingAnimation(impactVel);                                          
}
}
simulated function PlayWaiting();
simulated function PlayMoving();
simulated event PlayFalling();
simulated event PlayJump();
function bool CannotJumpNow() {
return False;                                                               
}
simulated event AnimEnd(int Channel) {
if (Channel == 0) {                                                         
PlayWaiting();                                                            
}
}
simulated event ChangeAnimation() {
if (Controller != None && Controller.bControlAnimations) {                  
return;                                                                   
}
PlayWaiting();                                                              
PlayMoving();                                                               
}
function PlayTakeHit(Vector HitLoc,int Damage,class<DamageType> DamageType) {
local Sound DesiredSound;
if (Damage == 0) {                                                          
return;                                                                   
}
DesiredSound = DamageType.GetPawnDamageSound();                             
if (DesiredSound != None) {                                                 
PlayOwnedSound(DesiredSound,1);                                           
}
}
simulated function PlayFiring(optional float Rate,optional name FiringMode);
simulated event PlayDying(class<DamageType> DamageType,Vector HitLoc) {
AmbientSound = None;                                                        
GotoState('Dying');                                                         
if (bPhysicsAnimUpdate) {                                                   
bReplicateMovement = False;                                               
bTearOff = True;                                                          
Velocity += TearOffMomentum;                                              
SetPhysics(2);                                                            
}
bPlayedDeath = True;                                                        
}
simulated event SetAnimAction(name NewAction);
simulated function TurnOff() {
SetCollision(True,False);                                                   
AmbientSound = None;                                                        
Velocity = vect(0.000000, 0.000000, 0.000000);                              
SetPhysics(0);                                                              
bPhysicsAnimUpdate = False;                                                 
bIsIdle = True;                                                             
bWaitForAnim = False;                                                       
StopAnimating();                                                            
bIgnoreForces = True;                                                       
}
function PlayHit(float Damage,Pawn instigatedBy,Vector HitLocation,class<DamageType> DamageType,Vector Momentum) {
local Vector BloodOffset;
local Vector Mo;
local Vector HitNormal;
local class<Effects> DesiredEffect;
local class<Emitter> DesiredEmitter;
local PlayerController Hearer;
if (DamageType == None) {                                                   
return;                                                                   
}
if (Damage <= 0
&& (Controller == None || !Controller.bGodMode)) {    
return;                                                                   
}
if (Damage > DamageType.default.DamageThreshold) {                          
HitNormal = Normal(HitLocation - Location);                               
if (EffectIsRelevant(Location,True)) {                                    
DesiredEffect = DamageType.GetPawnDamageEffect(HitLocation,Damage,Momentum,self,Level.bDropDetail || Level.DetailMode == 0);
if (DesiredEffect != None) {                                            
BloodOffset = 0.20000000 * CollisionRadius * HitNormal;               
BloodOffset.Z = BloodOffset.Z * 0.50000000;                           
Mo = Momentum;                                                        
if (Mo.Z > 0) {                                                       
Mo.Z *= 0.50000000;                                                 
}
Spawn(DesiredEffect,self,,HitLocation + BloodOffset,rotator(Mo));     
}
DesiredEmitter = DamageType.GetPawnDamageEmitter(HitLocation,Damage,Momentum,self,Level.bDropDetail || Level.DetailMode == 0);
if (DesiredEmitter != None) {                                           
Spawn(DesiredEmitter,,,HitLocation + HitNormal,rotator(HitNormal));   
}
}
}
if (GetHealth() <= 0) {                                                     
if (PhysicsVolume.bDestructive
&& PhysicsVolume.ExitActor != None) {
Spawn(PhysicsVolume.ExitActor);                                         
}
return;                                                                   
}
if (Level.TimeSeconds - LastPainTime > 0.10000000) {                        
if (instigatedBy != None && DamageType != None
&& DamageType.default.bDirectDamage) {
Hearer = PlayerController(instigatedBy.Controller);                     
}
if (Hearer != None) {                                                     
Hearer.bAcuteHearing = True;                                            
}
PlayTakeHit(HitLocation,Damage,DamageType);                               
if (Hearer != None) {                                                     
Hearer.bAcuteHearing = False;                                           
}
LastPainTime = Level.TimeSeconds;                                         
}
}
function PlayDyingSound();
function PlayMoverHitSound();
event bool DoJump() {
if (!bIsCrouched && !bWantsToCrouch
&& (Physics == 1 || Physics == 11 || Physics == 9)) {
if (Physics == 9) {                                                       
Velocity = GetJumpZ() * Floor;                                          
} else {                                                                  
if (Physics == 11) {                                                    
if (PhysicsVolume.IsA('LadderVolume')) {                              
Velocity = LadderVolume(PhysicsVolume).LookDir;                     
Velocity *= -GetJumpZ() * 0.50000000;                               
} else {                                                              
Velocity.Z = 0.00000000;                                            
}
} else {                                                                
Velocity.Z = GetJumpZ();                                              
}
}
if (Base != None && !Base.bWorldGeometry) {                               
Velocity.Z += Base.Velocity.Z;                                          
}
SetPhysics(18);                                                           
return True;                                                              
}
return False;                                                               
}
final native event float GetJumpZ();
function bool CheckWaterJump(out Vector WallNormal) {
local Actor HitActor;
local Vector HitLocation;
local Vector HitNormal;
local Vector checkpoint;
local Vector Start;
local Vector checkNorm;
if (AIController(Controller) != None) {                                     
checkpoint = Acceleration;                                                
checkpoint.Z = 0.00000000;                                                
}
if (checkpoint == vect(0.000000, 0.000000, 0.000000)) {                     
checkpoint = vector(Rotation);                                            
}
checkpoint.Z = 0.00000000;                                                  
checkNorm = Normal(checkpoint);                                             
checkpoint = Location + 1.20000005 * CollisionRadius * checkNorm;           
HitActor = Trace(HitLocation,HitNormal,checkpoint,Location,True,GetCollisionExtent());
if (HitActor != None && Pawn(HitActor) == None) {                           
WallNormal = -1 * HitNormal;                                              
Start = Location;                                                         
Start.Z += 1.10000002 * 25.00000000;                                      
checkpoint = Start + 2 * CollisionRadius * checkNorm;                     
HitActor = Trace(HitLocation,HitNormal,checkpoint,Start,True);            
if (HitActor == None || HitNormal.Z > 0.69999999) {                       
return True;                                                            
}
}
return False;                                                               
}
function TakeDrowningDamage();
event BreathTimer() {
TakeDrowningDamage();                                                       
if (GetHealth() > 0) {                                                      
BreathTime = 2.00000000;                                                  
}
}
function bool IsInPain() {
local PhysicsVolume V;
foreach TouchingActors(Class'PhysicsVolume',V) {                            
if (V.bPainCausing
&& V.DamageType != ReducedDamageType
&& V.DamagePerSec > 0) {
return True;                                                            
}
}
return False;                                                               
}
function bool TouchingWaterVolume() {
local PhysicsVolume V;
foreach TouchingActors(Class'PhysicsVolume',V) {                            
if (V.bWaterVolume) {                                                     
return True;                                                            
}
}
return False;                                                               
}
event HeadVolumeChange(PhysicsVolume newHeadVolume) {
if (Level.NetMode == 3 || Controller == None) {                             
return;                                                                   
}
if (HeadVolume != None && HeadVolume.bWaterVolume) {                        
if (newHeadVolume != None && !newHeadVolume.bWaterVolume) {               
if (Controller.bIsPlayer && BreathTime > 0
&& BreathTime < 8) {
Gasp();                                                               
}
BreathTime = -1.00000000;                                               
}
} else {                                                                    
if (newHeadVolume != None && newHeadVolume.bWaterVolume) {                
BreathTime = UnderWaterTime;                                            
}
}
}
event HitWall(Vector HitNormal,Actor Wall);
event Falling() {
if (Controller != None) {                                                   
Controller.SetFall();                                                     
}
}
function Died(Controller Killer,class<DamageType> DamageType,Vector HitLocation) {
}
function Controller GetKillerController() {
return Controller;                                                          
}
function SetDelayedDamageInstigatorController(Controller C) {
DelayedDamageInstigatorController = C;                                      
}
function TakeDamage(int Damage,Pawn instigatedBy,Vector HitLocation,Vector Momentum,class<DamageType> DamageType) {
local int actualDamage;
local Controller Killer;
if (DamageType == None) {                                                   
if (instigatedBy != None) {                                               
Warn("No damagetype for damage by " $ string(instigatedBy));            
}
DamageType = Class'DamageType';                                           
}
if (Role < 4) {                                                             
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
if (Physics == 0) {                                                         
SetMovementPhysics();                                                     
}
if (Physics == 1
&& DamageType.default.bExtraMomentumZ) {             
Momentum.Z = FMax(Momentum.Z,0.40000001 * VSize(Momentum));               
}
if (instigatedBy == self) {                                                 
Momentum *= 0.60000002;                                                   
}
Momentum = Momentum / Mass;                                                 
if (instigatedBy != None && instigatedBy.HasUDamage()) {                    
Damage *= 2;                                                              
}
actualDamage = Damage;                                                      
if (DamageType.default.bArmorStops && actualDamage > 0) {                   
actualDamage = ShieldAbsorb(actualDamage);                                
}
IncreaseHealth(-actualDamage);                                              
if (HitLocation == vect(0.000000, 0.000000, 0.000000)) {                    
HitLocation = Location;                                                   
}
PlayHit(actualDamage,instigatedBy,HitLocation,DamageType,Momentum);         
if (GetHealth() <= 0) {                                                     
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
} else {                                                                    
AddVelocity(Momentum);                                                    
}
MakeNoise(1.00000000);                                                      
}
function int ShieldAbsorb(int Damage) {
return Damage;                                                              
}
function bool HasUDamage() {
return False;                                                               
}
function SetMovementPhysics();
function Gasp();
simulated function SetMesh() {
if (Mesh != None) {                                                         
return;                                                                   
}
LinkMesh(default.Mesh);                                                     
}
event PostBeginPlay() {
Super.PostBeginPlay();                                                      
SplashTime = 0.00000000;                                                    
SpawnTime = Level.TimeSeconds;                                              
EyeHeight = BaseEyeHeight;                                                  
OldRotYaw = Rotation.Yaw;                                                   
if (Level.bStartup && GetHealth() > 0) {                                    
if (ControllerClass != None && Controller == None) {                      
Controller = Spawn(ControllerClass);                                    
}
if (Controller != None) {                                                 
AIController(Controller).Skill += SkillModifier;                        
}
}
}
event PreBeginPlay() {
Super.PreBeginPlay();                                                       
Instigator = self;                                                          
DesiredRotation = Rotation;                                                 
if (bDeleteMe) {                                                            
return;                                                                   
}
if (BaseEyeHeight == 0) {                                                   
BaseEyeHeight = 0.80000001 * CollisionHeight;                             
}
EyeHeight = BaseEyeHeight;                                                  
if (MenuName == "") {                                                       
MenuName = GetItemName(string(Class));                                    
}
}
simulated event Destroyed() {
if (Shadow != None) {                                                       
Shadow.Destroy();                                                         
}
Super.Destroyed();                                                          
}
simulated function Vector EyePosition() {
return EyeHeight * vect(0.000000, 0.000000, 1.000000) + WalkBob;            
}
singular event BaseChange() {
if (bInterpolating) {                                                       
return;                                                                   
}
if (Base == None && Physics == 0) {                                         
SetPhysics(2);                                                            
}
}
function JumpOffPawn() {
Velocity += (100 + CollisionRadius) * VRand();                              
Velocity.Z = 200.00000000 + CollisionHeight;                                
SetPhysics(2);                                                              
bNoJumpAdjust = True;                                                       
if (Controller != None) {                                                   
Controller.SetFall();                                                     
}
}
function GibbedBy(Actor Other) {
if (Role < 4) {                                                             
return;                                                                   
}
if (Pawn(Other) != None) {                                                  
Died(Pawn(Other).Controller,Class'DamTypeTelefragged',Location);          
} else {                                                                    
Died(None,Class'Gibbed',Location);                                        
}
}
event EncroachedBy(Actor Other) {
}
event bool EncroachingOn(Actor Other) {
if (Other.bWorldGeometry || Other.bBlocksTeleport) {                        
return True;                                                              
}
if ((Controller == None || !Controller.bIsPlayer
|| bWarping)
&& Pawn(Other) != None) {
return True;                                                              
}
return False;                                                               
}
function int LimitPitchFirstPersonView(int Pitch) {
Pitch = Pitch & 65535;                                                      
if (Pitch > PitchUpLimitFirstPersonView
&& Pitch < PitchDownLimit) {  
if (Pitch - PitchUpLimitFirstPersonView < PitchDownLimit - Pitch) {       
Pitch = PitchUpLimitFirstPersonView;                                    
} else {                                                                  
Pitch = PitchDownLimit;                                                 
}
}
return Pitch;                                                               
}
function int LimitPitchBehindView(int Pitch) {
Pitch = Pitch & 65535;                                                      
if (Pitch > PitchUpLimitBehindView && Pitch < PitchDownLimit) {             
if (Pitch - PitchUpLimitBehindView < PitchDownLimit - Pitch) {            
Pitch = PitchUpLimitBehindView;                                         
} else {                                                                  
Pitch = PitchDownLimit;                                                 
}
}
return Pitch;                                                               
}
simulated function FaceRotation(Rotator NewRotation,float DeltaTime) {
if (IsRotationFrozen() || Physics == 19
|| Physics == 20) {           
return;                                                                   
}
if (Physics == 11 && OnLadder != None) {                                    
SetRotation(OnLadder.WallDir);                                            
} else {                                                                    
if (Physics == 1 || Physics == 2 || Physics == 18) {                      
NewRotation.Pitch = 0;                                                  
}
SetRotation(NewRotation);                                                 
}
}
event bool IsRotationFrozen() {
return False;                                                               
}
function KilledBy(Pawn EventInstigator) {
TakeDamage(99999,EventInstigator,Location,vect(0.000000, 0.000000, 0.000000),Class'DamageType');
}
function AddVelocity(Vector newVelocity) {
if (bIgnoreForces
|| newVelocity == vect(0.000000, 0.000000, 0.000000)) {
return;                                                                   
}
if (Physics == 1 || Physics == 19 || Physics == 20
|| (Physics == 11 || Physics == 9)
&& newVelocity.Z > default.JumpZ) {
SetPhysics(2);                                                            
}
if (Velocity.Z > 380 && newVelocity.Z > 0) {                                
newVelocity.Z *= 0.50000000;                                              
}
Velocity += newVelocity;                                                    
}
function RestartPlayer();
event StartCrouch(float HeightAdjust) {
EyeHeight += HeightAdjust;                                                  
OldZ -= HeightAdjust;                                                       
BaseEyeHeight = FMin(0.80000001 * CrouchHeight,CrouchHeight - 10);          
}
event EndCrouch(float HeightAdjust) {
EyeHeight -= HeightAdjust;                                                  
OldZ += HeightAdjust;                                                       
BaseEyeHeight = default.BaseEyeHeight;                                      
}
function ShouldCrouch(bool Crouch) {
if (bWantsToCrouch != Crouch) {                                             
bWantsToCrouch = Crouch;                                                  
}
}
event FellOutOfWorld(byte KillType) {
if (Level.NetMode == 3) {                                                   
return;                                                                   
}
if (Controller != None && Controller.AvoidCertainDeath()) {                 
return;                                                                   
}
Died(None,Class'fell',Location);                                            
}
simulated event ModifyVelocity(float DeltaTime,Vector OldVelocity);
function JumpOutOfWater(Vector jumpDir) {
Falling();                                                                  
Velocity = jumpDir * WaterSpeed;                                            
SetAcceleration(jumpDir * AccelRate);                                       
Velocity.Z = FMax(380.00000000,GetJumpZ());                                 
bUpAndOut = True;                                                           
}
function FinishedInterpolation() {
DropToGround();                                                             
}
function SetDefaultDisplayProperties() {
Style = default.Style;                                                      
Texture = default.Texture;                                                  
bUnlit = default.bUnlit;                                                    
bUpdatingDisplay = False;                                                   
}
function SetDisplayProperties(byte NewStyle,Material NewTexture,bool bLighting) {
Style = NewStyle;                                                           
Texture = NewTexture;                                                       
bUnlit = bLighting;                                                         
bUpdatingDisplay = False;                                                   
}
function bool CanTrigger(Trigger t) {
return True;                                                                
}
function Trigger(Actor Other,Pawn EventInstigator) {
if (Controller != None) {                                                   
Controller.Trigger(Other,EventInstigator);                                
}
}
function float AdjustedStrength() {
return 0.00000000;                                                          
}
function bool LineOfSightTo(Actor Other) {
return Controller != None
&& Controller. Super.LineOfSightTo(Other);  
}
function SetMoveTarget(Actor NewTarget) {
if (Controller != None) {                                                   
Controller.MoveTarget = NewTarget;                                        
}
}
function Actor GetMoveTarget() {
if (Controller == None) {                                                   
return None;                                                              
}
return Controller.MoveTarget;                                               
}
final simulated function bool PressingAltFire() {
return Controller != None && Controller.bAltFire != 0;                      
}
final simulated function bool PressingFire() {
return Controller != None && Controller.bFire != 0;                         
}
function bool NearMoveTarget() {
if (Controller == None || Controller.MoveTarget == None) {                  
return False;                                                             
}
return ReachedDestination(Controller.MoveTarget);                           
}
final function bool InGodMode() {
return Controller != None && Controller.bGodMode;                           
}
simulated function SetViewRotation(Rotator NewRotation) {
if (Controller != None) {                                                   
Controller.SetRotation(NewRotation);                                      
}
}
simulated function Rotator GetViewRotation() {
if (Controller == None) {                                                   
return Rotation;                                                          
}
return Controller.GetViewRotation();                                        
}
simulated function bool IsFirstPerson() {
local PlayerController PC;
PC = PlayerController(Controller);                                          
return PC != None && !PC.bBehindView && Viewport(PC.Player) != None;        
}
simulated function bool IsLocallyControlled() {
if (Level.NetMode == 0) {                                                   
return True;                                                              
}
if (Controller == None) {                                                   
return False;                                                             
}
if (PlayerController(Controller) == None) {                                 
return True;                                                              
}
return Viewport(PlayerController(Controller).Player) != None;               
}
simulated function bool IsHumanControlled() {
return PlayerController(Controller) != None;                                
}
simulated function bool WasPlayerPawn() {
return False;                                                               
}
simulated event bool IsPlayerPawn() {
return Controller != None && Controller.bIsPlayer;                          
}
final native function bool IsNPC();
final native function bool IsRemotePlayer();
final native function bool IsLocalPlayer();
simulated function DisplayDebug(Canvas Canvas,out float YL,out float YPos) {
local string t;
Super.DisplayDebug(Canvas,YL,YPos);                                         
Canvas.SetDrawColor(255,255,255);                                           
Canvas.SetPos(4.00000000,YPos);                                             
Canvas.DrawText("Anchor " $ string(Anchor) $ " Serpentine Dist "
$ string(SerpentineDist)
$ " Time "
$ string(SerpentineTime));
YPos += YL;                                                                 
Canvas.SetPos(4.00000000,YPos);                                             
t = "Floor " $ string(Floor) $ " DesiredSpeed "
$ string(DesiredSpeed)
$ " Crouched "
$ string(bIsCrouched)
$ " Try to uncrouch "
$ string(UncrouchTime);
if (OnLadder != None || Physics == 11) {                                    
t = t $ " on lAdder " $ string(OnLadder);                                 
}
Canvas.DrawText(t);                                                         
YPos += YL;                                                                 
Canvas.SetPos(4.00000000,YPos);                                             
Canvas.DrawText("EyeHeight " $ string(EyeHeight)
$ " BaseEyeHeight "
$ string(BaseEyeHeight)
$ " Physics Anim "
$ string(bPhysicsAnimUpdate));
YPos += YL;                                                                 
Canvas.SetPos(4.00000000,YPos);                                             
if (Controller == None) {                                                   
Canvas.SetDrawColor(255,0,0);                                             
Canvas.DrawText("NO CONTROLLER");                                         
YPos += YL;                                                               
Canvas.SetPos(4.00000000,YPos);                                           
} else {                                                                    
Controller.DisplayDebug(Canvas,YL,YPos);                                  
}
}
function ClimbLadder(LadderVolume L) {
OnLadder = L;                                                               
if (OnLadder == None) {                                                     
return;                                                                   
}
SetRotation(OnLadder.WallDir);                                              
SetPhysics(11);                                                             
}
function EndClimbLadder(LadderVolume OldLadder) {
if (Controller != None) {                                                   
Controller.EndClimbLadder();                                              
}
if (Physics == 11) {                                                        
SetPhysics(2);                                                            
}
}
simulated function AddAcceleration(Vector newAcceleration) {
if (Acceleration != newAcceleration) {                                      
Acceleration += newAcceleration;                                          
}
}
simulated function SetVelocity(Vector newVelocity) {
if (Velocity != newVelocity) {                                              
Velocity = newVelocity;                                                   
}
}
simulated function SetAcceleration(Vector newAcceleration) {
if (Acceleration != newAcceleration) {                                      
Acceleration = newAcceleration;                                           
}
}
simulated function bool CanSplash() {
if (Level.TimeSeconds - SplashTime > 0.15000001
&& (Physics == 2 || Physics == 4)
&& Abs(Velocity.Z) > 100) {
SplashTime = Level.TimeSeconds;                                           
return True;                                                              
}
return False;                                                               
}
event SetWalking(bool bNewIsWalking) {
if (bNewIsWalking != bIsWalking) {                                          
bIsWalking = bNewIsWalking;                                               
ChangeAnimation();                                                        
}
}
function bool CanGrabLadder() {
if (IsRemotePlayer()) {                                                     
return bCanClimbLadders;                                                  
}
return bCanClimbLadders && Controller != None
&& Physics != 11
&& (Physics != 2 || Abs(Velocity.Z) <= GetJumpZ());
}
function DropToGround() {
bCollideWorld = True;                                                       
bInterpolating = False;                                                     
if (GetHealth() > 0) {                                                      
SetCollision(True,True);                                                  
SetPhysics(2);                                                            
AmbientSound = None;                                                      
if (IsHumanControlled()) {                                                
Controller.GotoState(LandMovementState);                                
}
}
}
function BecomeViewTarget() {
bUpdateEyeheight = True;                                                    
}
simulated function bool PointOfView() {
return False;                                                               
}
function PlayTeleportEffect(bool bOut,bool bSound) {
MakeNoise(1.00000000);                                                      
}
function bool SpectatorSpecialCalcView(PlayerController Viewer,out Actor ViewActor,out Vector CameraLocation,out Rotator CameraRotation);
function bool SpecialCalcView(out Actor ViewActor,out Vector CameraLocation,out Rotator CameraRotation);
simulated function SpecialDrawCrosshair(Canvas C);
function DrawHUD(Canvas Canvas);
function float ModifyThreat(float current,Pawn Threat) {
return current;                                                             
}
function bool NeedToTurn(Vector targ) {
local Vector LookDir;
local Vector AimDir;
LookDir = vector(Rotation);                                                 
LookDir.Z = 0.00000000;                                                     
LookDir = Normal(LookDir);                                                  
AimDir = targ - Location;                                                   
AimDir.Z = 0.00000000;                                                      
AimDir = Normal(AimDir);                                                    
return LookDir Dot AimDir < 0.93000001;                                     
}
function bool FireOnRelease() {
return False;                                                               
}
function bool IsFiring() {
return False;                                                               
}
function float RefireRate() {
return 0.00000000;                                                          
}
function bool TooCloseToAttack(Actor Other) {
return False;                                                               
}
function bool CanAttack(Actor Other) {
return False;                                                               
}
function bool RecommendLongRangedAttack() {
return False;                                                               
}
simulated function AltFire(optional float F) {
}
simulated function Fire(optional float F) {
}
function Actor GetPathTo(Actor Dest) {
if (PlayerController(Controller) == None) {                                 
return Dest;                                                              
}
return PlayerController(Controller).GetPathTo(Dest);                        
}
function DeactivateSpawnProtection() {
SpawnTime = -100000.00000000;                                               
}
function Pawn GetAimTarget() {
return self;                                                                
}
simulated function SetBaseEyeheight() {
if (!bIsCrouched) {                                                         
BaseEyeHeight = default.BaseEyeHeight;                                    
} else {                                                                    
BaseEyeHeight = FMin(0.80000001 * CrouchHeight,CrouchHeight - 10);        
}
EyeHeight = BaseEyeHeight;                                                  
}
native function ForceCrouch();
native function bool ReachedDestination(Actor Goal);
function SetHealth(float aHealth) {
}
function IncreaseHealth(float aDelta) {
}
function float GetHealth() {
return 0.00000000;                                                          
}
simulated event SetHeadScale(float NewScale);
native simulated function int Get4WayDirection();
native simulated function SetTwistLook(int twist,int look);
native simulated function SetViewPitch(int NewPitch);
static function StaticPrecache(LevelInfo L);
*/