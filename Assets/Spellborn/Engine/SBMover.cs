﻿using System;
using UnityEngine;

namespace Engine
{
    [Serializable] public class SBMover : Mover
    {
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Vector mNetInterpolate;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public byte ClientStop;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public byte StoppedPosition;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public byte mNetState;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public byte mNetStateLabel;

        public SBMover()
        {
        }

        public enum SBMoverLabel
        {
            SBML_None,

            SBML_Open,

            SBML_Close,

            SBML_Running,

            SBML_Stopping,

            SBML_Begin,
        }

        public enum SBMoverState
        {
            SBMS_None,

            SBMS_OpenTimedMover,

            SBMS_WasOpenTimedMover,

            SBMS_StandOpenTimed,

            SBMS_BumpOpenTimed,

            SBMS_TriggerOpenTimed,

            SBMS_LoopMove,

            SBMS_TriggerToggle,

            SBMS_TriggerControl,

            SBMS_WasTriggerControl,

            SBMS_TriggerPound,

            SBMS_WasTriggerPound,

            SBMS_TriggerAdvance,

            SBMS_WasTriggerAdvance,

            SBMS_BumpButton,

            SBMS_WasBumpButton,

            SBMS_ConstantLoop,

            SBMS_LeadInOutLooper,

            SBMS_LeadInOutLooping,

            SBMS_RotatingMover,
        }
    }
}
/*
function SetStoppedPosition(byte NewPos) {
StoppedPosition = NewPos;                                                   
}
function InterpolateTo(byte NewKeyNum,float Seconds) {
Super.InterpolateTo(NewKeyNum,Seconds);                                     
if (IsServer()) {                                                           
mNetOldPos = OldPos;                                                      
mNetOldRotYaw = OldRot.Yaw;                                               
mNetOldRotPitch = OldRot.Pitch;                                           
mNetOldRotRoll = OldRot.Roll;                                             
mNetInterpolate.X = 100.00000000 * PhysAlpha;                             
mNetInterpolate.Y = 100.00000000 * FMax(0.00100000,PhysRate);             
mNetInterpolate.Z = 256.00000000 * PrevKeyNum + KeyNum;                   
}
}
function UpdateState() {
ResolveStateChange(mNetState,mNetStateLabel);                               
UpdateInterpolation();                                                      
}
function SBGotoState(optional name aNewState,optional name aLabel) {
if (IsServer()) {                                                           
ResolveState(aNewState,aLabel);                                           
}
Super.SBGotoState(aNewState,aLabel);                                        
}
function ResolveState(optional name aNewState,optional name aLabel) {
switch (aNewState) {                                                        
case 'OpenTimedMover' :                                                   
mNetState = 1;                                                          
break;                                                                  
case 'WasOpenTimedMover' :                                                
mNetState = 2;                                                          
break;                                                                  
case 'StandOpenTimed' :                                                   
mNetState = 3;                                                          
break;                                                                  
case 'BumpOpenTimed' :                                                    
mNetState = 4;                                                          
break;                                                                  
case 'TriggerOpenTimed' :                                                 
mNetState = 5;                                                          
break;                                                                  
case 'LoopMove' :                                                         
mNetState = 6;                                                          
break;                                                                  
case 'TriggerToggle' :                                                    
mNetState = 7;                                                          
break;                                                                  
case 'TriggerControl' :                                                   
mNetState = 8;                                                          
break;                                                                  
case 'WasTriggerControl' :                                                
mNetState = 9;                                                          
break;                                                                  
case 'TriggerPound' :                                                     
mNetState = 10;                                                         
break;                                                                  
case 'WasTriggerPound' :                                                  
mNetState = 11;                                                         
break;                                                                  
case 'TriggerAdvance' :                                                   
mNetState = 12;                                                         
break;                                                                  
case 'WasTriggerAdvance' :                                                
mNetState = 13;                                                         
break;                                                                  
case 'BumpButton' :                                                       
mNetState = 14;                                                         
break;                                                                  
case 'WasBumpButton' :                                                    
mNetState = 15;                                                         
break;                                                                  
case 'ConstantLoop' :                                                     
mNetState = 16;                                                         
break;                                                                  
case 'LeadInOutLooper' :                                                  
mNetState = 17;                                                         
break;                                                                  
case 'LeadInOutLooping' :                                                 
mNetState = 18;                                                         
break;                                                                  
case 'RotatingMover' :                                                    
mNetState = 19;                                                         
break;                                                                  
default:                                                                  
mNetState = 0;                                                          
break;                                                                  
}
switch (aLabel) {                                                           
case 'Open' :                                                             
mNetStateLabel = 1;                                                     
break;                                                                  
case 'Close' :                                                            
mNetStateLabel = 2;                                                     
break;                                                                  
case 'Running' :                                                          
mNetStateLabel = 3;                                                     
break;                                                                  
case 'Stopping' :                                                         
mNetStateLabel = 4;                                                     
break;                                                                  
case 'Begin' :                                                            
mNetStateLabel = 5;                                                     
break;                                                                  
default:                                                                  
mNetStateLabel = 0;                                                     
break;                                                                  
}
}
function ResolveStateChange(byte aStateName,byte aStateLabel) {
local name stateName;
local name stateLabel;
switch (aStateName) {                                                       
case 1 :                                                                  
stateName = 'OpenTimedMover';                                           
break;                                                                  
case 2 :                                                                  
stateName = 'WasOpenTimedMover';                                        
break;                                                                  
case 3 :                                                                  
stateName = 'StandOpenTimed';                                           
break;                                                                  
case 4 :                                                                  
stateName = 'BumpOpenTimed';                                            
break;                                                                  
case 5 :                                                                  
stateName = 'TriggerOpenTimed';                                         
break;                                                                  
case 6 :                                                                  
stateName = 'LoopMove';                                                 
break;                                                                  
case 7 :                                                                  
stateName = 'TriggerToggle';                                            
break;                                                                  
case 8 :                                                                  
stateName = 'TriggerControl';                                           
break;                                                                  
case 9 :                                                                  
stateName = 'WasTriggerControl';                                        
break;                                                                  
case 10 :                                                                 
stateName = 'TriggerPound';                                             
break;                                                                  
case 11 :                                                                 
stateName = 'WasTriggerPound';                                          
break;                                                                  
case 12 :                                                                 
stateName = 'TriggerAdvance';                                           
break;                                                                  
case 13 :                                                                 
stateName = 'WasTriggerAdvance';                                        
break;                                                                  
case 14 :                                                                 
stateName = 'BumpButton';                                               
break;                                                                  
case 15 :                                                                 
stateName = 'WasBumpButton';                                            
break;                                                                  
case 16 :                                                                 
stateName = 'ConstantLoop';                                             
break;                                                                  
case 17 :                                                                 
stateName = 'LeadInOutLooper';                                          
break;                                                                  
case 18 :                                                                 
stateName = 'LeadInOutLooping';                                         
break;                                                                  
case 19 :                                                                 
stateName = 'RotatingMover';                                            
break;                                                                  
default:                                                                  
stateName = 'None';                                                     
break;                                                                  
}
switch (aStateLabel) {                                                      
case 1 :                                                                  
stateLabel = 'Open';                                                    
break;                                                                  
case 2 :                                                                  
stateLabel = 'Close';                                                   
break;                                                                  
case 3 :                                                                  
stateLabel = 'Running';                                                 
break;                                                                  
case 4 :                                                                  
stateLabel = 'Stopping';                                                
break;                                                                  
case 5 :                                                                  
stateLabel = 'Begin';                                                   
break;                                                                  
default:                                                                  
stateLabel = 'None';                                                    
break;                                                                  
}
GotoState(stateName,stateLabel);                                            
}
event cl_OnBaseline() {
Super.cl_OnBaseline();                                                      
UpdateState();                                                              
}
final native function TriggerSound(byte aSoundType);
final native function UpdateInterpolation();
*/