﻿using System;
using UnityEngine;

namespace Engine
{
    [Serializable] public abstract class PlayerController : Controller
    {
        public const int UNREAL_UNIT_PI = 32768;

        [NonSerialized, HideInInspector]
        public int SBShowFlags;
    }
}
/*
simulated event LostChild(Actor Other) {
Super.LostChild(Other);                                                     
}
simulated event GainedChild(Actor Other) {
Super.GainedChild(Other);                                                   
}
function InvertLook() {
local bool Result;
Result = PlayerInput.InvertLook();                                          
}
function InvertMouse(optional string Invert) {
PlayerInput.InvertMouse(Invert);                                            
}
simulated function bool IsMouseInverted() {
return PlayerInput.bInvertMouse;                                            
}
event ClientCloseMenu(optional bool bCloseAll,optional bool bCancel) {
if (bCloseAll) {                                                            
Player.GUIController.CloseAll(bCancel,True);                              
} else {                                                                    
Player.GUIController.CloseMenu(bCancel);                                  
}
}
event ClientReplaceMenu(string Menu,optional bool bDisconnect,optional string Msg1,optional string Msg2) {
if (!Player.GUIController.bActive) {                                        
if (!Player.GUIController.ReplaceMenu(Menu,Msg1,Msg2)) {                  
UnPressButtons();                                                       
}
} else {                                                                    
Player.GUIController.ReplaceMenu(Menu,Msg1,Msg2);                         
}
}
event ClientOpenMenu(string Menu,optional string Msg1,optional string Msg2) {
if (!Player.GUIController.OpenMenu(Menu,Msg1,Msg2)) {                       
UnPressButtons();                                                         
}
}
singular event UnPressButtons() {
bFire = 0;                                                                  
bAltFire = 0;                                                               
bDuck = 0;                                                                  
bRun = 0;                                                                   
bVoiceTalk = 0;                                                             
ResetInput();                                                               
}
function ChangeAlwaysMouseLook(bool B) {
bAlwaysMouseLook = B;                                                       
if (bAlwaysMouseLook) {                                                     
bLookUpStairs = False;                                                    
}
}
function ChangeStairLook(bool B) {
bLookUpStairs = B;                                                          
if (bLookUpStairs) {                                                        
bAlwaysMouseLook = False;                                                 
}
}
function UpdateRotation(float DeltaTime,float maxPitch) {
local Rotator ViewRotation;
if (IsViewingCinematic()) {                                                 
return;                                                                   
}
ViewRotation = Rotation;                                                    
if (bFreeCam && bBehindView) {                                              
CameraDeltaYaw += 32.00000000 * DeltaTime * aTurn;                        
} else {                                                                    
DesiredRotation = ViewRotation;                                           
ViewRotation.Yaw += 32.00000000 * DeltaTime * aTurn;                      
}
ViewRotation.Pitch += 32.00000000 * DeltaTime * aLookUp;                    
if (bBehindView) {                                                          
ViewRotation.Pitch = Pawn.LimitPitchBehindView(ViewRotation.Pitch);       
} else {                                                                    
ViewRotation.Pitch = Pawn.LimitPitchFirstPersonView(ViewRotation.Pitch);  
}
SetRotation(ViewRotation);                                                  
Pawn.FaceRotation(ViewRotation,DeltaTime);                                  
}
function TurnAround() {
if (!bSetTurnRot) {                                                         
TurnRot180 = Rotation;                                                    
TurnRot180.Yaw += 32768;                                                  
bSetTurnRot = True;                                                       
}
DesiredRotation = TurnRot180;                                               
bRotateToDesired = DesiredRotation.Yaw != Rotation.Yaw;                     
}
function bool TurnTowardNearestEnemy();
function int BlendRot(float DeltaTime,int BlendC,int NewC) {
if (Abs(BlendC - NewC) > 32767) {                                           
if (BlendC > NewC) {                                                      
NewC += 65536;                                                          
} else {                                                                  
BlendC += 65536;                                                        
}
}
if (Abs(BlendC - NewC) > 4096) {                                            
BlendC = NewC;                                                            
} else {                                                                    
BlendC = BlendC + (NewC - BlendC) * FMin(1.00000000,24.00000000 * DeltaTime);
}
return BlendC & 65535;                                                      
}
function CalcFirstPersonView(out Vector CameraLocation,out Rotator CameraRotation) {
local Vector X;
local Vector Y;
local Vector Z;
local Vector AmbShakeOffset;
local Rotator AmbShakeRot;
local float FalloffScaling;
GetAxes(Rotation,X,Y,Z);                                                    
if (bEnableAmbientShake) {                                                  
if (AmbientShakeFalloffStartTime > 0
&& Level.TimeSeconds - AmbientShakeFalloffStartTime > AmbientShakeFalloffTime) {
bEnableAmbientShake = False;                                            
} else {                                                                  
if (AmbientShakeFalloffStartTime > 0) {                                 
FalloffScaling = 1.00000000 - (Level.TimeSeconds - AmbientShakeFalloffStartTime) / AmbientShakeFalloffTime;
FalloffScaling = FClamp(FalloffScaling,0.00000000,1.00000000);        
} else {                                                                
FalloffScaling = 1.00000000;                                          
}
AmbShakeOffset = AmbientShakeOffsetMag * FalloffScaling * Sin(Level.TimeSeconds * AmbientShakeOffsetFreq * 2 * 3.14159274);
AmbShakeRot = AmbientShakeRotMag * FalloffScaling * Sin(Level.TimeSeconds * AmbientShakeRotFreq * 2 * 3.14159274);
}
}
CameraRotation = static.Normalize(Rotation + ShakeRot + AmbShakeRot);       
CameraLocation = CameraLocation + Pawn.EyePosition() + Pawn.WalkBob + ShakeOffset.X * X + ShakeOffset.Y * Y + ShakeOffset.Z * Z + AmbShakeOffset;
}
event PlayerCalcView(out Actor ViewActor,out Vector CameraLocation,out Rotator CameraRotation) {
local Pawn PTarget;
if (LastPlayerCalcView == Level.TimeSeconds
&& CalcViewActor != None
&& CalcViewActor.Location == CalcViewActorLocation) {
ViewActor = CalcViewActor;                                                
CameraLocation = CalcViewLocation;                                        
CameraRotation = CalcViewRotation;                                        
return;                                                                   
}
if (Pawn != None && Pawn.bSpecialCalcView
&& ViewTarget == Pawn) {    
if (Pawn.SpecialCalcView(ViewActor,CameraLocation,CameraRotation)) {      
CacheCalcView(ViewActor,CameraLocation,CameraRotation);                 
return;                                                                 
}
}
if (ViewTarget == None || ViewTarget.bDeleteMe) {                           
if (Pawn != None && !Pawn.bDeleteMe) {                                    
SetViewTarget(Pawn);                                                    
} else {                                                                  
if (RealViewTarget != None) {                                           
SetViewTarget(RealViewTarget);                                        
} else {                                                                
SetViewTarget(self);                                                  
}
}
}
ViewActor = ViewTarget;                                                     
CameraLocation = ViewTarget.Location;                                       
if (ViewTarget == Pawn) {                                                   
if (bBehindView) {                                                        
CalcBehindView(CameraLocation,CameraRotation,CameraDist * Pawn.default.CollisionRadius);
} else {                                                                  
CalcFirstPersonView(CameraLocation,CameraRotation);                     
}
CacheCalcView(ViewActor,CameraLocation,CameraRotation);                   
return;                                                                   
}
if (ViewTarget == self) {                                                   
CameraRotation = Rotation;                                                
CacheCalcView(ViewActor,CameraLocation,CameraRotation);                   
return;                                                                   
}
CameraRotation = ViewTarget.Rotation;                                       
PTarget = Pawn(ViewTarget);                                                 
if (PTarget != None) {                                                      
if (Level.NetMode == 3 || Level.NetMode != 0) {                           
PTarget.SetViewRotation(TargetViewRotation);                            
CameraRotation = BlendedTargetViewRotation;                             
PTarget.EyeHeight = TargetEyeHeight;                                    
} else {                                                                  
if (PTarget.IsPlayerPawn()) {                                           
CameraRotation = PTarget.GetViewRotation();                           
}
}
if (PTarget.bSpecialCalcView
&& PTarget.SpectatorSpecialCalcView(self,ViewActor,CameraLocation,CameraRotation)) {
CacheCalcView(ViewActor,CameraLocation,CameraRotation);                 
return;                                                                 
}
if (!bBehindView) {                                                       
CameraLocation += PTarget.EyePosition();                                
}
}
if (bBehindView) {                                                          
CameraLocation = CameraLocation + (ViewTarget.default.CollisionHeight - ViewTarget.CollisionHeight) * vect(0.000000, 0.000000, 1.000000);
CalcBehindView(CameraLocation,CameraRotation,CameraDist * ViewTarget.default.CollisionRadius);
}
CacheCalcView(ViewActor,CameraLocation,CameraRotation);                     
}
function CacheCalcView(Actor ViewActor,Vector CameraLocation,Rotator CameraRotation) {
CalcViewActor = ViewActor;                                                  
if (ViewActor != None) {                                                    
CalcViewActorLocation = ViewActor.Location;                               
}
CalcViewLocation = CameraLocation;                                          
CalcViewRotation = CameraRotation;                                          
LastPlayerCalcView = Level.TimeSeconds;                                     
}
simulated function Rotator GetViewRotation() {
if (bBehindView && Pawn != None) {                                          
return Pawn.Rotation;                                                     
}
return Rotation;                                                            
}
function RemoveAllCameraEffects() {
while (CameraEffects.Length > 0) {                                          
CameraEffects.Remove(0,1);                                                
}
}
function CreateCameraEffect(class<CameraEffect> EffectClass) {
local CameraEffect effect;
effect = new EffectClass;                                                   
if (effect == None) {                                                       
} else {                                                                    
AddCameraEffect(effect,True);                                             
}
}
event RemoveCameraEffect(CameraEffect ExEffect) {
local int EffectIndex;
EffectIndex = 0;                                                            
while (EffectIndex < CameraEffects.Length) {                                
if (CameraEffects[EffectIndex].Class == ExEffect.Class) {                 
CameraEffects.Remove(EffectIndex,1);                                    
return;                                                                 
}
EffectIndex++;                                                            
}
}
event AddCameraEffect(CameraEffect NewEffect,optional bool RemoveExisting) {
if (NewEffect == None) {                                                    
return;                                                                   
}
if (RemoveExisting) {                                                       
RemoveCameraEffect(NewEffect);                                            
}
CameraEffects.Length = CameraEffects.Length + 1;                            
CameraEffects[CameraEffects.Length - 1] = NewEffect;                        
}
function CalcBehindView(out Vector CameraLocation,out Rotator CameraRotation,float dist) {
local Vector View;
local Vector HitLocation;
local Vector HitNormal;
local float ViewDist;
local float RealDist;
local Vector globalX;
local Vector globalY;
local Vector globalZ;
local Vector localX;
local Vector localY;
local Vector localZ;
CameraRotation = Rotation;                                                  
CameraRotation.Roll = 0;                                                    
CameraRotation.Yaw += CameraDeltaYaw;                                       
View = vect(1.000000, 0.000000, 0.000000) >> CameraRotation;                
RealDist = dist;                                                            
dist += CameraDeltaRad;                                                     
if (Trace(HitLocation,HitNormal,CameraLocation - dist * vector(CameraRotation),CameraLocation,False,vect(16.000000, 16.000000, 16.000000)) != None) {
ViewDist = FMin((CameraLocation - HitLocation) Dot View,dist);            
} else {                                                                    
ViewDist = dist;                                                          
}
if (!bBlockCloseCamera || !bValidBehindCamera
|| ViewDist > 16 + FMax(ViewTarget.CollisionRadius,ViewTarget.CollisionHeight)) {
bValidBehindCamera = True;                                                
OldCameraLoc = CameraLocation - ViewDist * View;                          
OldCameraRot = CameraRotation;                                            
} else {                                                                    
SetRotation(OldCameraRot);                                                
}
CameraLocation = OldCameraLoc + Pawn.EyePosition();                         
CameraRotation = OldCameraRot;                                              
CameraRotation.Pitch += CameraTiltAngle;                                    
GetAxes(CameraSwivel,globalX,globalY,globalZ);                              
localX = globalX >> CameraRotation;                                         
localY = globalY >> CameraRotation;                                         
localZ = globalZ >> CameraRotation;                                         
CameraRotation = static.OrthoRotation(localX,localY,localZ);                
}
function bool NotifyLanded(Vector HitNormal) {
return bUpdating;                                                           
}
simulated function ClientSetHUD(class<HUD> newHUDClass) {
}
function BehindView(bool B) {
ClientSetBehindView(B);                                                     
bBehindView = B;                                                            
}
function EnterStartState() {
local name newState;
if (Pawn.PhysicsVolume.bWaterVolume) {                                      
if (Pawn.HeadVolume.bWaterVolume) {                                       
Pawn.BreathTime = Pawn.UnderWaterTime;                                  
}
newState = Pawn.WaterMovementState;                                       
} else {                                                                    
newState = Pawn.LandMovementState;                                        
}
if (IsInState(newState)) {                                                  
BeginState();                                                             
} else {                                                                    
GotoState(newState);                                                      
}
}
function Typing(bool bTyping) {
bIsTyping = bTyping;                                                        
if (Pawn != None && !Pawn.bTearOff) {                                       
Pawn.bIsTyping = bIsTyping;                                               
}
}
function DamageAttitudeTo(Pawn Other,float Damage) {
if (Other != None && Other != Pawn && Damage > 0) {                         
Enemy = Other;                                                            
}
}
function ClientAdjustGlow(float Scale,Vector fog) {
ConstantGlowScale += Scale;                                                 
ConstantGlowFog += 0.00100000 * fog;                                        
}
function ClientFlash(float Scale,Vector fog) {
FlashScale = (Scale + (1 - ScreenFlashScaling) * (1 - Scale)) * vect(1.000000, 1.000000, 1.000000);
FlashFog = ScreenFlashScaling * 0.00100000 * fog;                           
}
function SetFOVAngle(float newFOV) {
FovAngle = newFOV;                                                          
}
function HandleWalking() {
if (Pawn != None) {                                                         
Pawn.SetWalking(bRun != 0
&& !Region.Zone.IsA('WarpZoneInfo'));   
}
}
function int CompressAccel(int C) {
if (C >= 0) {                                                               
C = Min(C,127);                                                           
} else {                                                                    
C = Min(Abs(C),127) + 128;                                                
}
return C;                                                                   
}
function int DetermineMaxPitchMultiplier() {
if (Pawn.Physics == 3 || Pawn.Physics == 4) {                               
return 2;                                                                 
}
return 0;                                                                   
}
function ForceDeathUpdate() {
lastUpdateTime = Level.TimeSeconds - 10;                                    
}
function ClientSetBehindView(bool B) {
local bool bWasBehindView;
bWasBehindView = bBehindView;                                               
bBehindView = B;                                                            
if (bBehindView != bWasBehindView) {                                        
ViewTarget.POVChanged(self,True);                                         
}
}
function ClientSetFixedCamera(bool B) {
bFixedCamera = B;                                                           
}
event bool IsDead() {
return False;                                                               
}
function SetMouseAccel(float F) {
PlayerInput.UpdateAccel(F);                                                 
}
function SetMouseSmoothing(int Mode) {
PlayerInput.UpdateSmoothing(Mode);                                          
}
function SetSensitivity(float F) {
PlayerInput.UpdateSensitivity(F);                                           
}
simulated function FixFOV() {
FovAngle = default.DefaultFOV;                                              
DesiredFOV = default.DefaultFOV;                                            
DefaultFOV = default.DefaultFOV;                                            
}
function EndZoom() {
if (DesiredFOV != DefaultFOV) {                                             
myHUD.FadeZoom();                                                         
}
bZooming = False;                                                           
DesiredFOV = DefaultFOV;                                                    
}
function StopZoom() {
bZooming = False;                                                           
}
function StartZoom() {
StartZoomWithMax(0.89999998);                                               
}
function ToggleZoom() {
}
function StartZoomWithMax(float MaxZoomLevel) {
DesiredZoomLevel = MaxZoomLevel;                                            
myHUD.FadeZoom();                                                           
ZoomLevel = 0.00000000;                                                     
bZooming = True;                                                            
}
function ToggleZoomWithMax(float MaxZoomLevel) {
if (DefaultFOV != DesiredFOV) {                                             
EndZoom();                                                                
} else {                                                                    
StartZoomWithMax(MaxZoomLevel);                                           
}
}
function ClientSetInitialMusic(string NewSong,byte NewTransition) {
local string SongName;
if (Song != "") {                                                           
return;                                                                   
}
SongName = NewSong;                                                         
if (Player != None && Player.Console != None) {                             
SongName = Player.Console.SetInitialMusic(NewSong);                       
}
ClientSetMusic(SongName,NewTransition);                                     
}
function ClientSetMusic(string NewSong,byte NewTransition) {
local float FadeIn;
local float FadeOut;
switch (NewTransition) {                                                    
case 2 :                                                                  
FadeIn = 7.00000000;                                                    
FadeOut = 3.00000000;                                                   
break;                                                                  
case 3 :                                                                  
FadeIn = 3.00000000;                                                    
FadeOut = 3.00000000;                                                   
break;                                                                  
case 4 :                                                                  
FadeIn = 1.00000000;                                                    
FadeOut = 1.00000000;                                                   
break;                                                                  
case 5 :                                                                  
FadeIn = 5.00000000;                                                    
FadeOut = 5.00000000;                                                   
break;                                                                  
default:                                                                  
}
StopAllMusic(FadeOut);                                                      
if (NewSong != "") {                                                        
PlayMusic(NewSong,FadeIn);                                                
}
Song = NewSong;                                                             
Transition = NewTransition;                                                 
if (Player != None && Player.Console != None) {                             
Player.Console.SetMusic(NewSong);                                         
}
}
simulated event Destroyed() {
if (Pawn != None) {                                                         
TakeDamage(99999,None,Location,vect(0.000000, 0.000000, 0.000000),Class'DamageType');
}
if (myHUD != None) {                                                        
myHUD.Destroy();                                                          
}
Super.Destroyed();                                                          
}
simulated function ClientReliablePlaySound(Sound ASound,optional bool bVolumeControl) {
ClientPlaySound(ASound,bVolumeControl);                                     
}
simulated function ClientPlaySound(Sound ASound,optional bool bVolumeControl,optional float inAtten,optional byte Slot) {
local float atten;
atten = 1.00000000;                                                         
if (bVolumeControl) {                                                       
atten = FClamp(inAtten,0.00000000,2.00000000);                            
}
if (ViewTarget != None) {                                                   
ViewTarget.PlaySound(ASound,Slot,atten,,,,False);                         
}
}
function ViewFlash(float DeltaTime) {
local Vector goalFog;
local float goalscale;
local float delta;
local float Step;
local PhysicsVolume ViewVolume;
delta = FMin(0.10000000,DeltaTime);                                         
goalscale = 1.00000000;                                                     
goalFog = vect(0.000000, 0.000000, 0.000000);                               
if (Pawn != None) {                                                         
if (bBehindView) {                                                        
ViewVolume = Level.GetPhysicsVolume(CalcViewLocation);                  
} else {                                                                  
ViewVolume = Pawn.HeadVolume;                                           
}
goalscale += ViewVolume.ViewFlash.X;                                      
goalFog += ViewVolume.ViewFog;                                            
}
Step = 0.60000002 * delta * ScreenFlashScaling;                             
FlashScale.X = UpdateFlashComponent(FlashScale.X,Step,goalscale);           
FlashScale = FlashScale.X * vect(1.000000, 1.000000, 1.000000);             
FlashFog.X = UpdateFlashComponent(FlashFog.X,Step,goalFog.X);               
FlashFog.Y = UpdateFlashComponent(FlashFog.Y,Step,goalFog.Y);               
FlashFog.Z = UpdateFlashComponent(FlashFog.Z,Step,goalFog.Z);               
}
final function float UpdateFlashComponent(float current,float Step,float Goal) {
if (Goal > current) {                                                       
return FMin(current + Step,Goal);                                         
} else {                                                                    
return FMax(current - Step,Goal);                                         
}
}
function int GetFacingDirection() {
local Vector X;
local Vector Y;
local Vector Z;
local Vector dir;
GetAxes(Pawn.Rotation,X,Y,Z);                                               
dir = Normal(Pawn.Acceleration);                                            
if (Y Dot dir > 0) {                                                        
return 49152 + 16384 * X Dot dir;                                         
} else {                                                                    
return 16384 - 16384 * X Dot dir;                                         
}
}
function ClientGotoState(name newState,name NewLabel) {
GotoState(newState,NewLabel);                                               
}
event InitInputSystem() {
PlayerInput = new (self) Class'PlayerInput';                                
}
function SpawnDefaultHUD() {
myHUD = Spawn(Class'HUD',self);                                             
}
function ServerVerifyViewTarget() {
if (ViewTarget == self) {                                                   
return;                                                                   
}
if (ViewTarget == None) {                                                   
return;                                                                   
}
ClientSetViewTarget(ViewTarget);                                            
}
event ClientSetViewTarget(Actor A) {
local bool bNewViewTarget;
if (A == None) {                                                            
if (ViewTarget != self) {                                                 
SetLocation(CalcViewLocation);                                          
}
ServerVerifyViewTarget();                                                 
} else {                                                                    
bNewViewTarget = ViewTarget != A;                                         
SetViewTarget(A);                                                         
if (bNewViewTarget) {                                                     
A.POVChanged(self,False);                                               
}
}
}
function ClientSetClassicView() {
Level.bClassicView = True;                                                  
}
exec function DSM() {
DecreaseScreenShotMode();                                                   
}
exec function DecreaseScreenShotMode() {
if (Player.InteractionMaster.ScreenshotMode > 0) {                          
Player.InteractionMaster.ScreenshotMode--;                                
}
}
exec function ISM() {
IncreaseScreenShotMode();                                                   
}
exec function IncreaseScreenShotMode() {
if (Player.InteractionMaster.ScreenshotMode < 2) {                          
Player.InteractionMaster.ScreenshotMode++;                                
}
}
exec function TSM() {
ToggleScreenShotMode();                                                     
}
exec function ToggleScreenShotMode() {
if (Player.InteractionMaster.ScreenshotMode != 0) {                         
Player.InteractionMaster.ScreenshotMode = 0;                              
} else {                                                                    
Player.InteractionMaster.ScreenshotMode = 2;                              
}
}
simulated event StreamFinished(int StreamHandle,byte Reason) {
local int i;
if (Player != None) {                                                       
i = 0;                                                                    
while (i < Player.LocalInteractions.Length) {                             
if (Player.LocalInteractions[i] != None) {                              
Player.LocalInteractions[i].StreamFinished(StreamHandle,Reason);      
}
i++;                                                                    
}
}
}
function Actor GetPathTo(Actor Dest) {
local int i;
local Actor Best;
local Vector dir;
if (Dest == None) {                                                         
return Dest;                                                              
}
if (Pawn.Physics != 2
&& (RouteGoal != Dest
|| Level.TimeSeconds - LastRouteFind > 1 + FRand())) {
MoveTarget = FindPathToward(Dest,False);                                  
if (MoveTarget == None) {                                                 
return Dest;                                                            
}
}
if (RouteCache[0] == None) {                                                
return Dest;                                                              
}
if (RouteCache[1] == None) {                                                
return RouteCache[0];                                                     
}
Best = RouteCache[0];                                                       
dir = Normal(RouteCache[1].Location - RouteCache[0].Location);              
i = 0;                                                                      
while (i < 5) {                                                             
if (RouteCache[i] == None
|| VSize(Pawn.Location - RouteCache[i].Location) > 2000) {
goto jl019F;                                                            
}
if (Normal(RouteCache[i].Location - RouteCache[0].Location) Dot dir > 0.69999999
&& LineOfSightTo(RouteCache[i])) {
Best = RouteCache[i];                                                   
}
i++;                                                                      
}
return Best;                                                                
}
simulated function bool BeyondViewDistance(Vector OtherLocation,float CullDistance) {
local float dist;
if (ViewTarget == None) {                                                   
return True;                                                              
}
dist = VSize(OtherLocation - ViewTarget.Location);                          
if (CullDistance > 0 && CullDistance < dist * FOVBias) {                    
return True;                                                              
}
return Region.Zone.bDistanceFog
&& dist > Region.Zone.DistanceFogEnd; 
}
simulated event PostBeginPlay() {
Super.PostBeginPlay();                                                      
FixFOV();                                                                   
SetViewTarget(self);                                                        
bForcePrecache = SBRole != 1 && SBRole != 9;                                
}
native event int ClientHearSBSound(Actor Actor,Sound s,Vector SoundLocation,float Volume,float Pitch,float Radius,int AudioType,bool Attenuate);
native event ClientHearSound(Actor Actor,int Id,Sound s,Vector SoundLocation,Vector Parameters,bool Attenuate);
final native(524) function int FindStairRotation(float DeltaTime);
native function string PasteFromClipboard();
native function CopyToClipboard(string Text);
final native function SetViewTarget(Actor NewViewTarget);
private final native function ResetInput();
final native(544) function ResetKeyboard();
native function string ConsoleCommand(string Command,optional bool bWriteToLog);
event bool IsViewingCinematic() {
return bViewingMatineeCinematic;                                            
}
function SetViewingCinematic(bool aViewingFlag) {
bViewingMatineeCinematic = aViewingFlag;                                    
if (bViewingMatineeCinematic) {                                             
cl_OnSceneStarted();                                                      
} else {                                                                    
cl_OnSceneEnded();                                                        
}
}
event cl_OnSceneEnded();
event cl_OnSceneStarted();
event SV_PlayerTick(float DeltaTime);
event cl_OnPlayerTick(float delta);
state PlayerFlying {
function BeginState() {
Pawn.SetPhysics(4);                                                     
}
function PlayerMove(float DeltaTime) {
local Vector X;
local Vector Y;
local Vector Z;
GetAxes(Rotation,X,Y,Z);                                                
Pawn.Acceleration = aForward * X + aStrafe * Y;                         
if (VSize(Pawn.Acceleration) < 1.00000000) {                            
Pawn.Acceleration = vect(0.000000, 0.000000, 0.000000);               
}
if (bCheatFlying
&& Pawn.Acceleration == vect(0.000000, 0.000000, 0.000000)) {
Pawn.Velocity = vect(0.000000, 0.000000, 0.000000);                   
}
UpdateRotation(DeltaTime,2.00000000);                                   
}
}
state PlayerWalking {
function EndState() {
GroundPitch = 0;                                                        
if (Pawn != None && bDuck == 0) {                                       
Pawn.ShouldCrouch(False);                                             
}
}
function BeginState() {
bPressedJump = False;                                                   
GroundPitch = 0;                                                        
if (Pawn != None) {                                                     
if (Pawn.Mesh == None) {                                              
Pawn.SetMesh();                                                     
}
Pawn.ShouldCrouch(False);                                             
if (Pawn.Physics != 2 && Pawn.Physics != 13) {                        
Pawn.SetPhysics(1);                                                 
}
}
}
function bool NotifyPhysicsVolumeChange(PhysicsVolume NewVolume) {
if (NewVolume.bWaterVolume) {                                           
GotoState(Pawn.WaterMovementState);                                   
}
return False;                                                           
}
Begin:
}
*/