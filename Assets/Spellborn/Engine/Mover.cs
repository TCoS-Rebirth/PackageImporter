﻿using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class Mover : Actor
    {
        public const int MOVER_PERSISTENT_SOUND_MASK = 240;

        public const int MOVER_TRIGGERED_SOUND_MASK = 15;

        public const int MOVER_SOUND_LOOPING = 32;

        public const int MOVER_SOUND_AMBIENT = 16;

        public const int MOVER_SOUND_CLOSED = 8;

        public const int MOVER_SOUND_CLOSING = 4;

        public const int MOVER_SOUND_OPENED = 2;

        public const int MOVER_SOUND_OPENING = 1;

        public const float MOVER_MAXIMUM_MOVE_TIME_INV = 0.001F;

        public const int MOVER_MAXIMUM_MOVE_TIME = 10000;

        [FoldoutGroup("Mover")]
        public byte KeyNum;

        [FoldoutGroup("Mover")]
        [FieldConst()]
        public byte NumKeys;

        public Mover Leader;

        public Mover Follower;

        [FoldoutGroup("ReturnGroup")]
        public NameProperty ReturnGroup;

        [FoldoutGroup("Mover")]
        public float DelayTime;

        [FoldoutGroup("MoverEvents")]
        public NameProperty OpeningEvent;

        [FoldoutGroup("MoverEvents")]
        public NameProperty OpenedEvent;

        [FoldoutGroup("MoverEvents")]
        public NameProperty ClosingEvent;

        [FoldoutGroup("MoverEvents")]
        public NameProperty ClosedEvent;

        [FoldoutGroup("MoverEvents")]
        public NameProperty LoopEvent;

        [ArraySizeForExtraction(Size = 24)]
        public Vector[] KeyPos = new Vector[0];

        [ArraySizeForExtraction(Size = 24)]
        public Rotator[] KeyRot = new Rotator[0];

        public Vector BasePos;

        public Rotator BaseRot;

        public NavigationPoint myMarker;

        public Mover()
        {
        }

        public enum EBumpType
        {
            BT_PlayerBump,

            BT_PawnBump,

            BT_AnyBump,
        }

        public enum EMoverGlideType
        {
            MV_MoveByTime,

            MV_GlideByTime,
        }

        public enum EMoverEncroachType
        {
            ME_StopWhenEncroach,

            ME_ReturnWhenEncroach,

            ME_CrushWhenEncroach,

            ME_IgnoreWhenEncroach,
        }
    }
}
/*
function UpdatePrecacheStaticMeshes() {
if (DrawType == 8 && StaticMesh != None) {                                  
Level.AddPrecacheStaticMesh(StaticMesh);                                  
}
}
function BaseFinished();
function BaseStarted();
function MoverLooped() {
TriggerEvent(LoopEvent,self,Instigator);                                    
if (LoopSound != None) {                                                    
StartSound(32);                                                           
}
}
function SetStoppedPosition(byte NewPos);
function EnableTrigger();
function DisableTrigger();
function TakeDamage(int Damage,Pawn instigatedBy,Vector HitLocation,Vector Momentum,class<DamageType> DamageType) {
if (bDamageTriggered && Damage >= DamageThreshold) {                        
self.Trigger(self,instigatedBy);                                          
}
}
function Bump(Actor Other) {
local Pawn P;
P = Pawn(Other);                                                            
if (bUseTriggered && P != None && !P.IsHumanControlled()
&& P.IsPlayerPawn()
&& !bDelaying
&& !bOpening) {
Trigger(P,P);                                                             
P.Controller.WaitForMover(self);                                          
}
if (BumpType != 2 && P == None) {                                           
return;                                                                   
}
if (BumpType == 0 && !P.IsPlayerPawn()) {                                   
return;                                                                   
}
if (BumpType == 1 && P.bAmbientCreature) {                                  
return;                                                                   
}
TriggerEvent(BumpEvent,self,P);                                             
if (P != None && P.IsPlayerPawn()) {                                        
TriggerEvent(PlayerBumpEvent,self,P);                                     
}
}
function bool EncroachingOn(Actor Other) {
local Pawn P;
if (Other == None) {                                                        
return False;                                                             
}
if (Pawn(Other) != None && Pawn(Other).Controller == None
|| Other.IsA('Decoration')) {
Other.TakeDamage(10000,None,Other.Location,vect(0.000000, 0.000000, 0.000000),Class'Crushed');
return False;                                                             
}
if (Other.IsA('Pickup')) {                                                  
if (!Other.bAlwaysRelevant && Other.Owner == None) {                      
Other.Destroy();                                                        
}
return False;                                                             
}
if (Other.IsA('Fragment') || Other.IsA('Gib')
|| Other.IsA('Projectile')) {
Other.Destroy();                                                          
return False;                                                             
}
if (EncroachDamage != 0) {                                                  
Other.TakeDamage(EncroachDamage,Instigator,Other.Location,vect(0.000000, 0.000000, 0.000000),Class'Crushed');
}
P = Pawn(Other);                                                            
if (P != None && P.Controller != None
&& P.IsPlayerPawn()) {          
if (PlayerBumpEvent != 'None') {                                          
Bump(Other);                                                            
}
if (P != None && P.Controller != None
&& P.Base != self
&& P.Controller.PendingMover == self) {
P.Controller.UnderLift(self);                                           
}
}
if (Leader == None) {                                                       
Leader = self;                                                            
}
if (MoverEncroachType == 0) {                                               
Leader.MakeGroupStop();                                                   
return True;                                                              
} else {                                                                    
if (MoverEncroachType == 1) {                                             
Leader.MakeGroupReturn();                                               
if (Other.IsA('Pawn')) {                                                
Pawn(Other).PlayMoverHitSound();                                      
}
return True;                                                            
} else {                                                                  
if (MoverEncroachType == 2) {                                           
Other.KilledBy(Instigator);                                           
return False;                                                         
} else {                                                                
if (MoverEncroachType == 3) {                                         
return False;                                                       
}
}
}
}
}
function MakeGroupReturn() {
bInterpolating = False;                                                     
StopSound(16);                                                              
if (bIsLeader || Leader == self) {                                          
if (KeyNum < PrevKeyNum) {                                                
SBGotoState('Open');                                                    
} else {                                                                  
SBGotoState('Close');                                                   
}
}
if (Follower != None) {                                                     
Follower.MakeGroupReturn();                                               
}
}
function MakeGroupStop() {
bInterpolating = False;                                                     
StopSound(16);                                                              
SBGotoState('None');                                                        
if (Follower != None) {                                                     
Follower.MakeGroupStop();                                                 
}
}
function Reset() {
SetResetStatus(True);                                                       
DoClose();                                                                  
SetResetStatus(False);                                                      
EnableTrigger();                                                            
SBGotoState(Backup_InitialState,'None');                                    
}
function SetResetStatus(bool bNewStatus) {
bHidden = BACKUP_bHidden;                                                   
bResetting = bNewStatus;                                                    
if (Follower != None) {                                                     
Follower.SetResetStatus(bNewStatus);                                      
}
}
function PostBeginPlay() {
local Mover M;
Backup_InitialState = InitialState;                                         
BACKUP_bHidden = bHidden;                                                   
if (!bSlave) {                                                              
foreach DynamicActors(Class'Mover',M,Tag) {                               
if (M.bSlave) {                                                         
M.SBGotoState('None');                                                
M.SetBase(self);                                                      
}
}
}
if (bIsLeader) {                                                            
Leader = self;                                                            
foreach DynamicActors(Class'Mover',M) {                                   
if (M != self && M.ReturnGroup == ReturnGroup) {                        
M.Leader = self;                                                      
M.Follower = Follower;                                                
Follower = M;                                                         
}
}
goto jl0132;                                                              
}
if (Leader == None) {                                                       
foreach DynamicActors(Class'Mover',M) {                                   
if (M != self && M.ReturnGroup == ReturnGroup) {                        
return;                                                               
}
}
Leader = self;                                                            
}
}
function BeginPlay() {
local AntiPortalActor AntiPortalA;
if (AntiPortalTag != 'None') {                                              
foreach AllActors(Class'AntiPortalActor',AntiPortalA,AntiPortalTag) {     
AntiPortals.Length = AntiPortals.Length + 1;                            
AntiPortals[AntiPortals.Length - 1] = AntiPortalA;                      
}
}
Super.BeginPlay();                                                          
KeyNum = Clamp(KeyNum,0,24 - 1);                                            
PhysAlpha = 0.00000000;                                                     
StartKeyNum = KeyNum;                                                       
Move(BasePos + KeyPos[KeyNum] - Location);                                  
SetRotation(BaseRot + KeyRot[KeyNum]);                                      
if (ReturnGroup == 'None') {                                                
ReturnGroup = Tag;                                                        
}
Leader = None;                                                              
Follower = None;                                                            
}
function DoClose() {
bOpening = False;                                                           
bDelaying = False;                                                          
InterpolateTo(Max(0,KeyNum - 1),MoveTime);                                  
MakeNoise(1.00000000);                                                      
UntriggerEvent(Event,self,Instigator);                                      
StartSound(4);                                                              
StartSound(16);                                                             
TriggerEvent(ClosingEvent,self,Instigator);                                 
if (Follower != None) {                                                     
Follower.DoClose();                                                       
}
}
function DoOpen() {
bOpening = True;                                                            
bDelaying = False;                                                          
InterpolateTo(1,MoveTime);                                                  
MakeNoise(1.00000000);                                                      
StartSound(1);                                                              
StartSound(16);                                                             
TriggerEvent(OpeningEvent,self,Instigator);                                 
if (Follower != None) {                                                     
Follower.DoOpen();                                                        
}
}
function FinishedOpening() {
StartSound(2);                                                              
TriggerEvent(Event,self,Instigator);                                        
TriggerEvent(OpenedEvent,self,Instigator);                                  
if (myMarker != None) {                                                     
myMarker.MoverOpened();                                                   
}
FinishNotify();                                                             
}
function FinishedClosing() {
local Mover M;
StartSound(8);                                                              
TriggerEvent(ClosedEvent,self,Instigator);                                  
if (SavedTrigger != None) {                                                 
SavedTrigger.EndEvent();                                                  
}
SavedTrigger = None;                                                        
Instigator = None;                                                          
if (myMarker != None) {                                                     
myMarker.MoverClosed();                                                   
}
bClosed = True;                                                             
FinishNotify();                                                             
M = Leader;                                                                 
while (M != None) {                                                         
if (!M.bClosed) {                                                         
return;                                                                 
}
M = M.Follower;                                                           
}
UntriggerEvent(OpeningEvent,self,Instigator);                               
}
function FinishNotify() {
local Controller C;
C = Level.ControllerList;                                                   
while (C != None) {                                                         
if (C.Pawn != None && C.PendingMover == self) {                           
C.MoverFinished();                                                      
}
C = C.nextController;                                                     
}
}
event KeyFrameReached() {
local byte OldKeyNum;
local Mover M;
OldKeyNum = PrevKeyNum;                                                     
PrevKeyNum = KeyNum;                                                        
PhysAlpha = 0.00000000;                                                     
if (KeyNum > 0 && KeyNum < OldKeyNum) {                                     
InterpolateTo(KeyNum - 1,MoveTime);                                       
} else {                                                                    
if (KeyNum < NumKeys - 1 && KeyNum > OldKeyNum) {                         
InterpolateTo(KeyNum + 1,MoveTime);                                     
} else {                                                                  
StopSound(16);                                                          
if (bJumpLift && KeyNum == 1) {                                         
FinishNotify();                                                       
}
if (IsServer()) {                                                       
foreach BasedActors(Class'Mover',M) {                                 
M.BaseFinished();                                                   
}
}
}
}
}
final function SetKeyframe(byte NewKeyNum,Vector NewLocation,Rotator NewRotation) {
KeyNum = Clamp(NewKeyNum,0,24 - 1);                                         
KeyPos[KeyNum] = NewLocation;                                               
KeyRot[KeyNum] = NewRotation;                                               
}
function InterpolateTo(byte NewKeyNum,float Seconds) {
local Mover M;
foreach BasedActors(Class'Mover',M) {                                       
M.BaseStarted();                                                          
}
NewKeyNum = Clamp(NewKeyNum,0,24 - 1);                                      
if (NewKeyNum == PrevKeyNum && KeyNum != PrevKeyNum) {                      
PhysAlpha = 1.00000000 - PhysAlpha;                                       
OldPos = BasePos + KeyPos[KeyNum];                                        
OldRot = BaseRot + KeyRot[KeyNum];                                        
} else {                                                                    
OldPos = Location;                                                        
OldRot = Rotation;                                                        
PhysAlpha = 0.00000000;                                                   
}
if (bResetting) {                                                           
Seconds = 0.00500000;                                                     
}
SetPhysics(8);                                                              
bInterpolating = True;                                                      
PrevKeyNum = KeyNum;                                                        
KeyNum = NewKeyNum;                                                         
PhysRate = 1.00000000 / FMax(Seconds,0.00500000);                           
if (PhysRate < 0.00100000) {                                                
PhysRate = 0.00100000;                                                    
}
}
function StartInterpolation() {
SBGotoState('None');                                                        
bInterpolating = True;                                                      
SetPhysics(0);                                                              
}
function Actor SpecialHandling(Pawn Other) {
local Actor A;
if (myMarker != None) {                                                     
A = myMarker.SpecialHandling(Other);                                      
if (A == None) {                                                          
return myMarker;                                                        
}
return A;                                                                 
}
return self;                                                                
}
function bool SelfTriggered() {
return True;                                                                
}
function SBGotoState(optional name aNewState,optional name aLabel) {
GotoState(aNewState,aLabel);                                                
}
native function StopSound(byte aSoundType);
native function StartSound(byte aSoundType);
state() RotatingMover {
function BaseFinished() {
local Actor OldBase;
OldBase = Base;                                                         
SetPhysics(0);                                                          
SetBase(OldBase);                                                       
if (bToggleDirection) {                                                 
RotationRate.Yaw *= -1;                                               
RotationRate.Pitch *= -1;                                             
RotationRate.Roll *= -1;                                              
}
}
function BaseStarted() {
local Actor OldBase;
bFixedRotationDir = True;                                               
OldBase = Base;                                                         
SetPhysics(5);                                                          
SetBase(OldBase);                                                       
}
}
state LeadInOutLooping {
event KeyFrameReached() {
if (bOscillatingLoop) {                                                 
if (KeyNum == 1 || KeyNum == NumKeys - 1) {                           
StepDirection *= -1;                                                
MoverLooped();                                                      
}
KeyNum += StepDirection;                                              
InterpolateTo(KeyNum,MoveTime);                                       
} else {                                                                
KeyNum++;                                                             
if (KeyNum == NumKeys) {                                              
KeyNum = 1;                                                         
MoverLooped();                                                      
}
InterpolateTo(KeyNum,MoveTime);                                       
}
}
function Trigger(Actor Other,Pawn EventInstigator) {
InterpolateTo(0,MoveTime);                                              
SBGotoState('LeadInOutLooper');                                         
}
}
state() LeadInOutLooper {
function BeginState() {
bOpening = False;                                                       
bDelaying = False;                                                      
}
event KeyFrameReached() {
if (KeyNum != 0) {                                                      
InterpolateTo(2,MoveTime);                                            
SBGotoState('LeadInOutLooping');                                      
}
}
function Trigger(Actor Other,Pawn EventInstigator) {
if (NumKeys < 3) {                                                      
Log("LeadInOutLooper detected with <3 movement keys");                
return;                                                               
}
InterpolateTo(1,MoveTime);                                              
}
}
state() ConstantLoop {
function BeginState() {
bOpening = False;                                                       
bDelaying = False;                                                      
}
event KeyFrameReached() {
if (bOscillatingLoop) {                                                 
if (KeyNum == 0 || KeyNum == NumKeys - 1) {                           
StepDirection *= -1;                                                
MoverLooped();                                                      
}
KeyNum += StepDirection;                                              
InterpolateTo(KeyNum,MoveTime);                                       
} else {                                                                
InterpolateTo((KeyNum + 1) % NumKeys,MoveTime);                       
if (KeyNum == 0) {                                                    
MoverLooped();                                                      
}
}
}
Begin:
InterpolateTo(1,MoveTime);                                                  
Running:
FinishInterpolation();                                                      
SBGotoState('ConstantLoop','Running');                                      
}
state WasBumpButton {
function Reset() {
Reset();                                                                
SetResetStatus(True);                                                   
SBGotoState('BumpButton','Close');                                      
}
}
state() BumpButton {
function EndEvent() {
bSlave = False;                                                         
Instigator = None;                                                      
SBGotoState('BumpButton','Close');                                      
}
function BeginEvent() {
bSlave = True;                                                          
}
function Bump(Actor Other) {
if (BumpType != 2 && Pawn(Other) == None) {                             
return;                                                               
}
if (BumpType == 0 && !Pawn(Other).IsPlayerPawn()) {                     
return;                                                               
}
if (BumpType == 1 && Other.Mass < 10) {                                 
return;                                                               
}
Global.Bump(Other);                                                     
SavedTrigger = Other;                                                   
Instigator = Pawn(Other);                                               
Instigator.Controller.WaitForMover(self);                               
SBGotoState('BumpButton','Open');                                       
}
Open:
if (bTriggerOnceOnly) {                                                     
Disable('Trigger');                                                       
}
bClosed = False;                                                            
Disable('Bump');                                                            
if (DelayTime > 0) {                                                        
bDelaying = True;                                                         
Sleep(DelayTime);                                                         
}
DoOpen();                                                                   
FinishInterpolation();                                                      
FinishedOpening();                                                          
if (bTriggerOnceOnly) {                                                     
SBGotoState('WasBumpButton');                                             
}
if (bSlave) {                                                               
}
Close:
DoClose();                                                                  
FinishInterpolation();                                                      
FinishedClosing();                                                          
SetResetStatus(False);                                                      
Enable('Bump');                                                             
}
state WasTriggerAdvance {
function Reset() {
Reset();                                                                
SetResetStatus(True);                                                   
SBGotoState('TriggerAdvance','Close');                                  
}
function bool SelfTriggered() {
return False;                                                           
}
}
state() TriggerAdvance {
function EndState() {
StopSound(16);                                                          
}
function BeginState() {
numTriggerEvents = 0;                                                   
}
function UnTrigger(Actor Other,Pawn EventInstigator) {
numTriggerEvents--;                                                     
if (numTriggerEvents <= 0) {                                            
StopSound(16);                                                        
numTriggerEvents = 0;                                                 
SavedTrigger = Other;                                                 
Instigator = EventInstigator;                                         
if (SavedTrigger != None) {                                           
SavedTrigger.BeginEvent();                                          
}
SetStoppedPosition(1);                                                
SetPhysics(0);                                                        
}
}
function Trigger(Actor Other,Pawn EventInstigator) {
numTriggerEvents++;                                                     
SavedTrigger = Other;                                                   
Instigator = EventInstigator;                                           
if (SavedTrigger != None) {                                             
SavedTrigger.BeginEvent();                                            
}
SetStoppedPosition(0);                                                  
SetPhysics(8);                                                          
StartSound(16);                                                         
if (!bOpening) {                                                        
SBGotoState('TriggerAdvance','Open');                                 
}
}
function Reset() {
Reset();                                                                
SetResetStatus(True);                                                   
numTriggerEvents = 0;                                                   
SBGotoState('TriggerAdvance','Close');                                  
}
function bool SelfTriggered() {
return False;                                                           
}
Open:
if (Physics == 0) {                                                         
SBGotoState('TriggerAdvance','None');                                     
}
bClosed = False;                                                            
if (DelayTime > 0) {                                                        
bDelaying = True;                                                         
Sleep(DelayTime);                                                         
}
if (Physics == 0) {                                                         
SBGotoState('TriggerAdvance','None');                                     
}
SetStoppedPosition(0);                                                      
DoOpen();                                                                   
FinishInterpolation();                                                      
FinishedOpening();                                                          
if (SavedTrigger != None) {                                                 
SavedTrigger.EndEvent();                                                  
}
SBGotoState('WasTriggerAdvance');                                           
Close:
SetStoppedPosition(0);                                                      
SetPhysics(8);                                                              
DoClose();                                                                  
FinishInterpolation();                                                      
FinishedClosing();                                                          
SetResetStatus(False);                                                      
}
state WasTriggerPound {
function Reset() {
Reset();                                                                
SetResetStatus(True);                                                   
SBGotoState('TriggerPound','Open');                                     
}
}
state() TriggerPound {
function BeginState() {
numTriggerEvents = 0;                                                   
}
function UnTrigger(Actor Other,Pawn EventInstigator) {
numTriggerEvents--;                                                     
if (numTriggerEvents <= 0) {                                            
numTriggerEvents = 0;                                                 
SavedTrigger = None;                                                  
Instigator = None;                                                    
SBGotoState('TriggerPound','Close');                                  
}
}
function Trigger(Actor Other,Pawn EventInstigator) {
numTriggerEvents++;                                                     
SavedTrigger = Other;                                                   
Instigator = EventInstigator;                                           
SBGotoState('TriggerPound','Open');                                     
}
function Reset() {
Reset();                                                                
if (numTriggerEvents > 0) {                                             
SetResetStatus(True);                                                 
numTriggerEvents = 0;                                                 
UnTrigger(None,None);                                                 
}
}
function bool SelfTriggered() {
return False;                                                           
}
Open:
if (bTriggerOnceOnly) {                                                     
Disable('Trigger');                                                       
}
bClosed = False;                                                            
if (DelayTime > 0) {                                                        
bDelaying = True;                                                         
Sleep(DelayTime);                                                         
}
DoOpen();                                                                   
FinishInterpolation();                                                      
Sleep(OtherTime);                                                           
Close:
DoClose();                                                                  
FinishInterpolation();                                                      
Sleep(StayOpenTime);                                                        
SetResetStatus(False);                                                      
if (bTriggerOnceOnly) {                                                     
SBGotoState('WasTriggerPound');                                           
}
if (SavedTrigger != None) {                                                 
goto ('Open');                                                            
}
}
state WasTriggerControl {
function Reset() {
Reset();                                                                
SetResetStatus(True);                                                   
SBGotoState('TriggerControl','Close');                                  
}
function bool SelfTriggered() {
return False;                                                           
}
}
state() TriggerControl {
function BeginState() {
numTriggerEvents = 0;                                                   
}
function UnTrigger(Actor Other,Pawn EventInstigator) {
numTriggerEvents--;                                                     
if (numTriggerEvents <= 0) {                                            
numTriggerEvents = 0;                                                 
SavedTrigger = Other;                                                 
Instigator = EventInstigator;                                         
if (SavedTrigger != None) {                                           
SavedTrigger.BeginEvent();                                          
}
SBGotoState('TriggerControl','Close');                                
}
}
function Trigger(Actor Other,Pawn EventInstigator) {
numTriggerEvents++;                                                     
SavedTrigger = Other;                                                   
Instigator = EventInstigator;                                           
if (SavedTrigger != None) {                                             
SavedTrigger.BeginEvent();                                            
}
if (!bOpening) {                                                        
SBGotoState('TriggerControl','Open');                                 
}
}
function Reset() {
Reset();                                                                
if (numTriggerEvents > 0) {                                             
SetResetStatus(True);                                                 
numTriggerEvents = 0;                                                 
UnTrigger(None,None);                                                 
}
}
function bool SelfTriggered() {
return False;                                                           
}
Open:
bClosed = False;                                                            
if (DelayTime > 0) {                                                        
bDelaying = True;                                                         
Sleep(DelayTime);                                                         
}
if (!bOpening) {                                                            
DoOpen();                                                                 
}
FinishInterpolation();                                                      
FinishedOpening();                                                          
if (SavedTrigger != None) {                                                 
SavedTrigger.EndEvent();                                                  
}
if (bTriggerOnceOnly) {                                                     
SBGotoState('WasTriggerControl');                                         
}
Close:
if (bOpening) {                                                             
DoClose();                                                                
}
FinishInterpolation();                                                      
FinishedClosing();                                                          
SetResetStatus(False);                                                      
}
state() TriggerToggle {
function Trigger(Actor Other,Pawn EventInstigator) {
SavedTrigger = Other;                                                   
Instigator = EventInstigator;                                           
if (SavedTrigger != None) {                                             
SavedTrigger.BeginEvent();                                            
}
if (KeyNum == 0 || KeyNum < PrevKeyNum) {                               
SBGotoState('TriggerToggle','Open');                                  
} else {                                                                
SBGotoState('TriggerToggle','Close');                                 
}
}
function Reset() {
Reset();                                                                
if (bOpening || bDelaying) {                                            
SetResetStatus(True);                                                 
SBGotoState('TriggerToggle','Close');                                 
}
}
function bool SelfTriggered() {
return False;                                                           
}
Open:
bClosed = False;                                                            
if (DelayTime > 0) {                                                        
bDelaying = True;                                                         
Sleep(DelayTime);                                                         
}
DoOpen();                                                                   
FinishInterpolation();                                                      
FinishedOpening();                                                          
if (SavedTrigger != None) {                                                 
SavedTrigger.EndEvent();                                                  
}
Close:
DoClose();                                                                  
FinishInterpolation();                                                      
FinishedClosing();                                                          
SetResetStatus(False);                                                      
}
state() LoopMove {
function BeginState() {
bOpening = False;                                                       
bDelaying = False;                                                      
}
event KeyFrameReached() {
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
Disable('UnTrigger');                                                   
Enable('Trigger');                                                      
SavedTrigger = Other;                                                   
Instigator = EventInstigator;                                           
SBGotoState('LoopMove','Stopping');                                     
}
event Trigger(Actor Other,Pawn EventInstigator) {
Disable('Trigger');                                                     
Enable('UnTrigger');                                                    
SavedTrigger = Other;                                                   
Instigator = EventInstigator;                                           
if (SavedTrigger != None) {                                             
SavedTrigger.BeginEvent();                                            
}
bOpening = True;                                                        
StartSound(1);                                                          
StartSound(16);                                                         
SBGotoState('LoopMove','Running');                                      
}
function bool SelfTriggered() {
return False;                                                           
}
Running:
FinishInterpolation();                                                      
InterpolateTo((KeyNum + 1) % NumKeys,MoveTime);                             
SBGotoState('LoopMove','Running');                                          
Stopping:
FinishInterpolation();                                                      
FinishedOpening();                                                          
UntriggerEvent(Event,self,Instigator);                                      
bOpening = False;                                                           
}
state() TriggerOpenTimed extends OpenTimedMover {
function EnableTrigger() {
Enable('Trigger');                                                      
}
function DisableTrigger() {
Disable('Trigger');                                                     
}
function Trigger(Actor Other,Pawn EventInstigator) {
SavedTrigger = Other;                                                   
Instigator = EventInstigator;                                           
if (SavedTrigger != None) {                                             
SavedTrigger.BeginEvent();                                            
}
SBGotoState('TriggerOpenTimed','Open');                                 
}
function bool SelfTriggered() {
return False;                                                           
}
}
state() BumpOpenTimed extends OpenTimedMover {
function EnableTrigger() {
Enable('Bump');                                                         
}
function DisableTrigger() {
Disable('Bump');                                                        
}
function Bump(Actor Other) {
if (BumpType != 2 && Pawn(Other) == None) {                             
return;                                                               
}
if (BumpType == 0 && !Pawn(Other).IsPlayerPawn()) {                     
return;                                                               
}
if (BumpType == 1 && Other.Mass < 10) {                                 
return;                                                               
}
Global.Bump(Other);                                                     
SavedTrigger = None;                                                    
Instigator = Pawn(Other);                                               
Instigator.Controller.WaitForMover(self);                               
SBGotoState('BumpOpenTimed','Open');                                    
}
}
state() StandOpenTimed extends OpenTimedMover {
function EnableTrigger() {
Enable('Attach');                                                       
}
function DisableTrigger() {
Disable('Attach');                                                      
}
function Attach(Actor Other) {
if (!CanTrigger(Other)) {                                               
return;                                                               
}
SavedTrigger = None;                                                    
SBGotoState('StandOpenTimed','Open');                                   
}
function bool CanTrigger(Actor Other) {
local Pawn P;
P = Pawn(Other);                                                        
if (BumpType != 2 && P == None) {                                       
return False;                                                         
}
if (BumpType == 0 && !P.IsPlayerPawn()) {                               
return False;                                                         
}
if (BumpType == 1 && Other.Mass < 10) {                                 
return False;                                                         
}
TriggerEvent(BumpEvent,self,P);                                         
return True;                                                            
}
function bool ShouldReTrigger() {
local int i;
i = 0;                                                                  
while (i < Attached.Length) {                                           
if (CanTrigger(Attached[i])) {                                        
return True;                                                        
}
i++;                                                                  
}
return False;                                                           
}
}
state WasOpenTimedMover {
function Reset() {
SetResetStatus(True);                                                   
SBGotoState(Backup_InitialState,'Close');                               
}
}
state OpenTimedMover {
function BeginState() {
EnableTrigger();                                                        
}
function Reset() {
SetResetStatus(True);                                                   
SBGotoState(Backup_InitialState,'Close');                               
}
function bool ShouldReTrigger() {
return False;                                                           
}
Open:
if (bTriggerOnceOnly) {                                                     
Disable('Trigger');                                                       
}
bClosed = False;                                                            
DisableTrigger();                                                           
if (DelayTime > 0) {                                                        
bDelaying = True;                                                         
Sleep(DelayTime);                                                         
}
DoOpen();                                                                   
FinishInterpolation();                                                      
FinishedOpening();                                                          
Sleep(StayOpenTime);                                                        
if (bTriggerOnceOnly) {                                                     
SBGotoState('WasOpenTimedMover','None');                                  
}
Close:
DoClose();                                                                  
FinishInterpolation();                                                      
FinishedClosing();                                                          
EnableTrigger();                                                            
if (bResetting) {                                                           
SetResetStatus(False);                                                    
SBGotoState(Backup_InitialState,'None');                                  
}
Sleep(StayOpenTime);                                                        
if (ShouldReTrigger()) {                                                    
SavedTrigger = None;                                                      
SBGotoState('StandOpenTimed','Open');                                     
}
}
*/