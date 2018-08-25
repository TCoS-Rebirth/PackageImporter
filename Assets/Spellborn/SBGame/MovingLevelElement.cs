using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class MovingLevelElement : Game_Actor
    {
        [FoldoutGroup("MovingLevelElement")]
        [FieldConst()]
        public byte NumKeys;

        [FoldoutGroup("MovingLevelElement")]
        [FieldConst()]
        public bool bUseLocation;

        [FoldoutGroup("MovingLevelElement")]
        [FieldConst()]
        public bool bUseRotation;

        [FoldoutGroup("MovingLevelElement")]
        [FieldConst()]
        public bool bUseScale;

        [FoldoutGroup("MovingLevelElement")]
        public float Delay;

        public float WaitedTime;

        [FoldoutGroup("KeyFrame")]
        public byte KeyNum;

        [FoldoutGroup("KeyFrame")]
        public float KeyDuration;

        [FoldoutGroup("KeyFrame")]
        public NameProperty KeyTriggerEvent;

        [FoldoutGroup("KeyFrame")]
        public NameProperty KeyUntriggerEvent;

        [FoldoutGroup("MovingLevelElement")]
        [FieldConst()]
        public byte WorldRaytraceKey;

        [FoldoutGroup("MovingLevelElement")]
        [FieldConst()]
        public byte BrushRaytraceKey;

        [FoldoutGroup("MovingLevelElement")]
        public byte MLEType;

        [FoldoutGroup("MovingLevelElement")]
        public byte MLEMoveMode;

        [FoldoutGroup("MovingLevelElement")]
        public byte MLEEncroachMode;

        [FoldoutGroup("MovingLevelElement")]
        public byte MLEStoppingMode;

        public byte MLEState;

        [FoldoutGroup("MovingLevelElement")]
        [ArraySizeForExtraction(Size = 24)]
        public MLEKey[] Keys = new MLEKey[0];

        public float KeyTime;

        public float MoveSpeed;

        public Vector BasePos;

        public Vector OldPos;

        public Rotator BaseRot;

        public Rotator OldRot;

        public MovingLevelElement()
        {
        }

        [Serializable] public struct MLEKey
        {
            public Vector Location;

            public Rotator Rotation;

            public Vector Scale;

            public float Duration;

            public NameProperty TriggerEvent;

            public NameProperty UntriggerEvent;
        }

        public enum EMLESoundType
        {
            MLEST_StartSound,

            MLEST_MovingSound,

            MLEST_StopSound,
        }

        public enum EMLEState
        {
            MLES_StateStopped,

            MLES_StateStopping,

            MLES_StateMoving,

            MLES_StateWaiting,
        }

        public enum EMLEStoppingMode
        {
            MLESM_FinishKey,

            MLESM_FinishAnimation,

            MLESM_Freeze,
        }

        public enum EMLEEncroachMode
        {
            MLEEM_EncroachCrush,

            MLEEM_EncroachIgnore,
        }

        public enum EMLEMoveMode
        {
            MLEMM_Loop,

            MLEMM_Bounce,
        }

        public enum EMLEType
        {
            MLET_TypeTriggerConstant,

            MLET_TypeTriggerToggle,
        }
    }
}
/*
event cl_OnUpdate() {
Super.cl_OnUpdate();                                                        
}
event cl_OnBaseline() {
Super.cl_OnBaseline();                                                      
}
native function Rotator CalculateCurrentRotation();
native function Vector CalculateCurrentLocation();
native function Update(Vector vec,Rotator Rot);
native function ResetState();
native function UpdateRelevants();
native event cl_OnTick(float delta);
state() Stopped {
event UnTrigger(Actor Other,Pawn EventInstigator) {
switch (MLEType) {                                                      
case 0 :                                                              
ResetState();                                                       
break;                                                              
case 1 :                                                              
MLEStoppingMode = 0;                                                
MoveSpeed = -1.00000000;                                            
if (Delay > 0) {                                                    
GotoState('Waiting');                                             
} else {                                                            
GotoState('Stopping');                                            
}
break;                                                              
default:                                                              
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
Instigator = EventInstigator;                                           
switch (MLEType) {                                                      
case 0 :                                                              
if (Delay > 0) {                                                    
GotoState('Waiting');                                             
} else {                                                            
GotoState('Moving');                                              
}
break;                                                              
case 1 :                                                              
MLEStoppingMode = 0;                                                
MoveSpeed = 1.00000000;                                             
if (Delay > 0) {                                                    
GotoState('Waiting');                                             
} else {                                                            
GotoState('Stopping');                                            
}
break;                                                              
default:                                                              
}
}
function BeginState() {
Instigator = None;                                                      
MLEState = 0;                                                           
UpdateRelevants();                                                      
}
function Reset() {
Reset();                                                                
}
function bool SelfTriggered() {
return False;                                                           
}
}
state() Moving {
event UnTrigger(Actor Other,Pawn EventInstigator) {
switch (MLEStoppingMode) {                                              
case 0 :                                                              
case 1 :                                                              
GotoState('Stopping');                                              
break;                                                              
case 2 :                                                              
GotoState('Stopped');                                               
break;                                                              
default:                                                              
break;                                                              
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
}
function BeginState() {
MLEState = 2;                                                           
UpdateRelevants();                                                      
}
function Reset() {
Reset();                                                                
}
function bool SelfTriggered() {
return False;                                                           
}
}
state() Stopping {
event UnTrigger(Actor Other,Pawn EventInstigator) {
}
event Trigger(Actor Other,Pawn EventInstigator) {
}
function BeginState() {
MLEState = 1;                                                           
UpdateRelevants();                                                      
}
function Reset() {
Reset();                                                                
}
function bool SelfTriggered() {
return False;                                                           
}
}
state() Waiting {
event UnTrigger(Actor Other,Pawn EventInstigator) {
}
event Trigger(Actor Other,Pawn EventInstigator) {
}
function BeginState() {
MLEState = 3;                                                           
UpdateRelevants();                                                      
}
function Reset() {
Reset();                                                                
}
function bool SelfTriggered() {
return False;                                                           
}
}
*/