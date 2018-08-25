using System;
using Engine;
using SBBase;
using UnityEngine;
using Color = Engine.Color;

namespace SBGame
{
    [Serializable] public class Game_Camera : Base_Component
    {
        public const float HEAD_RADIUS = 1F;

        [FieldConfig()]
        public int MaxZoomOut;

        [FieldConfig()]
        public float CameraDisplacement;

        [FieldConfig()]
        public int CameraRotationSpeed;

        [FieldConfig()]
        public float CameraDisplacementSpeed;

        public float BlurScreenAmount;

        public float SunlightsBrightness;

        public float AmbientAmount;

        public byte AmbientBrightness;

        public byte AmbientHue;

        public byte AmbientSaturation;

        public float FogDensity;

        public float FogColorAmount;

        [NonSerialized, HideInInspector]
        public Color FogColor;

        private float mDesiredCameraDist;

        private bool mAutoRotateCamera;

        private float mRotateSpeedFactor;

        public Vector ShakeOffsetRate;

        public Vector ShakeOffsetTime;

        public Vector ShakeOffsetMax;

        public Vector ShakeRotRate;

        public Vector ShakeRotMax;

        public Vector ShakeRotTime;

        private Vector mShakeMin;

        private Vector mShakeMax;

        private Vector mCurrentShake;

        private float mTransitionDuration;

        private float mTransitionStart;

        private float mShakeStart;

        private float mShakeDuration;

        private bool mFreeCamLock;

        private Vector mPreviousDisplacement;

        public Game_Camera()
        {
        }
    }
}
/*
private function CheckShake(out float MaxOffset,out float Offset,out float Rate,out float Time,float dt) {
if (Abs(Offset) < Abs(MaxOffset)) {                                         
return;                                                                   
}
Offset = MaxOffset;                                                         
if (Time > 1) {                                                             
if (Time * Abs(MaxOffset / Rate) <= 1) {                                  
MaxOffset = MaxOffset * (1 / Time - 1);                                 
} else {                                                                  
MaxOffset *= -1;                                                        
}
Time -= dt;                                                               
Rate *= -1;                                                               
} else {                                                                    
MaxOffset = 0.00000000;                                                   
Offset = 0.00000000;                                                      
Rate = 0.00000000;                                                        
}
}
private function UpdateShakeRotComponent(out float Max,out int current,out float Rate,out float Time,float dt) {
local float fCurrent;
current = (current & 65535) + Rate * dt & 65535;                            
if (current > 32768) {                                                      
current -= 65536;                                                         
}
fCurrent = current;                                                         
CheckShake(Max,fCurrent,Rate,Time,dt);                                      
current = fCurrent;                                                         
}
private function ViewShake(float DeltaTime) {
if (ShakeOffsetRate != vect(0.000000, 0.000000, 0.000000)) {                
Outer.ShakeOffset.X += DeltaTime * ShakeOffsetRate.X;                     
CheckShake(ShakeOffsetMax.X,Outer.ShakeOffset.X,ShakeOffsetRate.X,ShakeOffsetTime.X,DeltaTime);
Outer.ShakeOffset.Y += DeltaTime * ShakeOffsetRate.Y;                     
CheckShake(ShakeOffsetMax.Y,Outer.ShakeOffset.Y,ShakeOffsetRate.Y,ShakeOffsetTime.Y,DeltaTime);
Outer.ShakeOffset.Z += DeltaTime * ShakeOffsetRate.Z;                     
CheckShake(ShakeOffsetMax.Z,Outer.ShakeOffset.Z,ShakeOffsetRate.Z,ShakeOffsetTime.Z,DeltaTime);
}
if (ShakeRotRate != vect(0.000000, 0.000000, 0.000000)) {                   
UpdateShakeRotComponent(ShakeRotMax.X,Outer.ShakeRot.Pitch,ShakeRotRate.X,ShakeRotTime.X,DeltaTime);
UpdateShakeRotComponent(ShakeRotMax.Y,Outer.ShakeRot.Yaw,ShakeRotRate.Y,ShakeRotTime.Y,DeltaTime);
UpdateShakeRotComponent(ShakeRotMax.Z,Outer.ShakeRot.Roll,ShakeRotRate.Z,ShakeRotTime.Z,DeltaTime);
}
}
private event ShakeViewEvent(Vector shRotMag,Vector shRotRate,float shRotTime,Vector shOffsetMag,Vector shOffsetRate,float shOffsetTime) {
ShakeView(shRotMag,shRotRate,shRotTime,shOffsetMag,shOffsetRate,shOffsetTime);
}
private event SetAmbientShake(float FalloffStartTime,float FalloffTime,Vector OffsetMag,float OffsetFreq,Rotator RotMag,float RotFreq) {
Outer.bEnableAmbientShake = True;                                           
Outer.AmbientShakeFalloffStartTime = FalloffStartTime;                      
Outer.AmbientShakeFalloffTime = FalloffTime;                                
Outer.AmbientShakeOffsetMag = OffsetMag;                                    
Outer.AmbientShakeOffsetFreq = OffsetFreq;                                  
Outer.AmbientShakeRotMag = RotMag;                                          
Outer.AmbientShakeRotFreq = RotFreq;                                        
}
private function ShakeView(Vector shRotMag,Vector shRotRate,float shRotTime,Vector shOffsetMag,Vector shOffsetRate,float shOffsetTime) {
if (VSize(shRotMag) > VSize(ShakeRotMax)) {                                 
ShakeRotMax = shRotMag;                                                   
ShakeRotRate = shRotRate;                                                 
ShakeRotTime = shRotTime * vect(1.000000, 1.000000, 1.000000);            
}
if (VSize(shOffsetMag) > VSize(ShakeOffsetMax)) {                           
ShakeOffsetMax = shOffsetMag;                                             
ShakeOffsetRate = shOffsetRate;                                           
ShakeOffsetTime = shOffsetTime * vect(1.000000, 1.000000, 1.000000);      
}
}
private function ClientDamageShake(int Damage) {
ShakeView(vect(0.000000, 0.000000, 0.000000),vect(0.000000, 0.000000, 0.000000),0.00000000,Damage * vect(-0.600000, 0.000000, 0.000000),vect(100.000000, 100.000000, 100.000000),0.20000000);
}
protected function DamageShake(int Damage) {
ClientDamageShake(Damage);                                                  
}
protected function cl_MoveTomDesiredCameraDist(float DeltaSeconds) {
if (Outer.CameraDist < mDesiredCameraDist) {                                
Outer.CameraDist += DeltaSeconds * CameraDisplacementSpeed;               
if (Outer.CameraDist > mDesiredCameraDist) {                              
Outer.CameraDist = mDesiredCameraDist;                                  
}
} else {                                                                    
if (Outer.CameraDist > mDesiredCameraDist) {                              
Outer.CameraDist -= DeltaSeconds * CameraDisplacementSpeed;             
if (Outer.CameraDist < mDesiredCameraDist) {                            
Outer.CameraDist = mDesiredCameraDist;                                
}
}
}
if (Outer.CameraDist >= 1.00000000) {                                       
Outer.BehindView(True);                                                   
} else {                                                                    
if (mDesiredCameraDist < 1.00000000) {                                    
Outer.BehindView(False);                                                
}
}
}
protected function cl_RotateCameraBack(float DeltaSeconds) {
if (mAutoRotateCamera) {                                                    
Outer.CameraDeltaYaw += CameraRotationSpeed * DeltaSeconds * mRotateSpeedFactor;
return;                                                                   
}
if (Outer.CameraDeltaYaw >= 32768) {                                        
Outer.CameraDeltaYaw -= 65536;                                            
} else {                                                                    
if (Outer.CameraDeltaYaw <= -32768) {                                     
Outer.CameraDeltaYaw += 65536;                                          
}
}
if (!Outer.bFreeCam) {                                                      
if (Outer.CameraDeltaYaw >= 0) {                                          
Outer.CameraDeltaYaw -= CameraRotationSpeed * DeltaSeconds;             
if (Outer.CameraDeltaYaw < 0) {                                         
Outer.CameraDeltaYaw = 0.00000000;                                    
}
} else {                                                                  
if (Outer.CameraDeltaYaw <= 0) {                                        
Outer.CameraDeltaYaw += CameraRotationSpeed * DeltaSeconds;           
if (Outer.CameraDeltaYaw > 0) {                                       
Outer.CameraDeltaYaw = 0.00000000;                                  
}
}
}
}
}
function StopViewShaking() {
ShakeRotMax = vect(0.000000, 0.000000, 0.000000);                           
ShakeRotRate = vect(0.000000, 0.000000, 0.000000);                          
ShakeRotTime = vect(0.000000, 0.000000, 0.000000);                          
ShakeOffsetMax = vect(0.000000, 0.000000, 0.000000);                        
ShakeOffsetRate = vect(0.000000, 0.000000, 0.000000);                       
ShakeOffsetTime = vect(0.000000, 0.000000, 0.000000);                       
}
function ShakeCamera(out Actor ViewActor,out Vector CameraLocation,out Rotator CameraRotation) {
local float transitionDelta;
local Vector tempVector;
ViewActor = Outer.ViewTarget;                                               
CameraLocation = Outer.ViewTarget.Location;                                 
if (Outer.bBehindView) {                                                    
Outer.CalcBehindView(CameraLocation,CameraRotation,Outer.CameraDist * Outer.Pawn.default.CollisionRadius);
} else {                                                                    
Outer.CalcFirstPersonView(CameraLocation,CameraRotation);                 
}
if (mShakeStart < 0.00000000) {                                             
mShakeStart = Outer.Level.TimeSeconds;                                    
mTransitionStart = Outer.Level.TimeSeconds;                               
transitionDelta = 0.00000000;                                             
mPreviousDisplacement = vect(0.000000, 0.000000, 0.000000);               
}
if (Outer.Level.TimeSeconds - mShakeStart > mShakeDuration) {               
Outer.Pawn.bSpecialCalcView = False;                                      
mShakeStart = -1.00000000;                                                
} else {                                                                    
transitionDelta = Outer.Level.TimeSeconds - mTransitionStart;             
if (transitionDelta > mTransitionDuration) {                              
transitionDelta = 0.00000000;                                           
mTransitionStart = Outer.Level.TimeSeconds;                             
if (mCurrentShake == mShakeMax) {                                       
mCurrentShake = mShakeMin;                                            
} else {                                                                
mCurrentShake = mShakeMax;                                            
}
}
tempVector = VSize(mCurrentShake) * vector((rotator(mCurrentShake) + CameraRotation));
CameraLocation = static.LerpVector(CameraLocation - mPreviousDisplacement,CameraLocation - mPreviousDisplacement + tempVector,transitionDelta / mTransitionDuration);
mPreviousDisplacement = tempVector;                                       
}
}
function SetCameraShake(Vector minVector,Vector maxVector,float Duration,float TransitionTime) {
mShakeStart = -1.00000000;                                                  
mShakeDuration = Duration;                                                  
mTransitionDuration = TransitionTime;                                       
mShakeMin = minVector;                                                      
mShakeMax = maxVector;                                                      
Outer.Pawn.bSpecialCalcView = True;                                         
}
exec function ZoomOut() {
if (mDesiredCameraDist < MaxZoomOut) {                                      
mDesiredCameraDist += CameraDisplacement;                                 
}
if (mDesiredCameraDist > 350) {                                             
mDesiredCameraDist = 350.00000000;                                        
}
if (mDesiredCameraDist < 1.00000000) {                                      
mDesiredCameraDist = 1.00000000;                                          
}
}
exec function ZoomIn() {
if (mDesiredCameraDist >= CameraDisplacement) {                             
mDesiredCameraDist -= CameraDisplacement;                                 
}
if (mDesiredCameraDist < 1.00000000) {                                      
mDesiredCameraDist = 0.00000000;                                          
}
}
protected native function sv2cl_SetFreeCam_CallStub();
event sv2cl_SetFreeCam(bool free) {
SetFreeCam(free);                                                           
}
function bool IsFreeCamLocked() {
return mFreeCamLock;                                                        
}
function LockFreeCam(bool aLock) {
mFreeCamLock = aLock;                                                       
}
function bool UsingFreeCam() {
return Outer.bFreeCam;                                                      
}
function SetFreeCam(bool free) {
if (!mFreeCamLock) {                                                        
Outer.bFreeCam = free;                                                    
}
}
function cl_Tick(float DeltaSeconds) {
cl_RotateCameraBack(DeltaSeconds);                                          
cl_MoveTomDesiredCameraDist(DeltaSeconds);                                  
ViewShake(DeltaSeconds);                                                    
}
event cl_OnInit() {
Super.cl_OnInit();                                                          
mEnvironmentEffect = new Class'Game_CameraEnvironmentEffect';               
mEnvironmentEffect.SetController(Outer);                                    
Outer.Level.GetEnvironmentManager().AddEffect(mEnvironmentEffect);          
}
*/