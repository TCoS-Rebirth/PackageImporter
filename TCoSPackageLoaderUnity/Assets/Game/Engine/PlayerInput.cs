﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Engine;
using SBAI;
using SBAIScripts;
using SBBase;
using SBGame;
using SBGamePlay;
using SBMiniGames;
using System;
using System.Collections;
using System.Collections.Generic;
using Framework.Attributes;

namespace Engine
{
    
    
    public class PlayerInput : UObject
    {
        
        public bool bInvertMouse;
        
        public bool bAdjustSampling;
        
        public byte MouseSmoothingMode;
        
        public float MouseSmoothingStrength;
        
        public float MouseSensitivity;
        
        public float MouseSamplingTime;
        
        public float MouseAccelThreshold;
        
        [ArraySizeForExtraction(Size=2)]
        public float[] SmoothedMouse = new float[0];
        
        [ArraySizeForExtraction(Size=2)]
        public float[] ZeroTime = new float[0];
        
        [ArraySizeForExtraction(Size=2)]
        public float[] SamplingTime = new float[0];
        
        [ArraySizeForExtraction(Size=2)]
        public float[] MaybeTime = new float[0];
        
        [ArraySizeForExtraction(Size=4)]
        public float[] OldSamples = new float[0];
        
        [ArraySizeForExtraction(Size=2)]
        public int[] MouseSamples = new int[0];
        
        private bool mInputFrozen;
        
        public PlayerInput()
        {
        }
    }
}
/*
function ChangeSnapView(bool B) {
Outer.bSnapToLevel = B;                                                     
}
function InvertMouse(optional string Invert) {
if (Invert != "") {                                                         
bInvertMouse = bool(Invert);                                              
} else {                                                                    
bInvertMouse = !bInvertMouse;                                             
}
SaveConfig();                                                               
default.bInvertMouse = bInvertMouse;                                        
}
function UpdateSmoothing(int Mode) {
MouseSmoothingMode = Mode;                                                  
default.MouseSmoothingMode = MouseSmoothingMode;                            
Class'PlayerInput'.static.StaticSaveConfig();                               
}
function UpdateAccel(float F) {
MouseAccelThreshold = FMax(0.00000000,F);                                   
default.MouseAccelThreshold = MouseAccelThreshold;                          
Class'PlayerInput'.static.StaticSaveConfig();                               
}
function UpdateSensitivity(float F) {
MouseSensitivity = FMax(0.00000000,F);                                      
default.MouseSensitivity = MouseSensitivity;                                
Class'PlayerInput'.static.StaticSaveConfig();                               
}
function float SmoothMouse(float aMouse,float DeltaTime,out byte SampleCount,int Index) {
local int i;
local int sum;
if (MouseSmoothingMode == 0) {                                              
return aMouse;                                                            
}
if (aMouse == 0) {                                                          
ZeroTime[Index] += DeltaTime;                                             
if (ZeroTime[Index] < MouseSamplingTime) {                                
SamplingTime[Index] += DeltaTime;                                       
MaybeTime[Index] += DeltaTime;                                          
aMouse = SmoothedMouse[Index];                                          
} else {                                                                  
if (bAdjustSampling && MouseSamples[Index] > 9) {                       
SamplingTime[Index] -= MaybeTime[Index];                              
MouseSamplingTime = 0.89999998 * MouseSamplingTime + 0.10000000 * SamplingTime[Index] / MouseSamples[Index];
}
SamplingTime[Index] = 0.00000000;                                       
SmoothedMouse[Index] = 0.00000000;                                      
MouseSamples[Index] = 0;                                                
}
} else {                                                                    
MaybeTime[Index] = 0.00000000;                                            
if (SmoothedMouse[Index] != 0) {                                          
MouseSamples[Index] += SampleCount;                                     
if (DeltaTime > MouseSamplingTime * (SampleCount + 1)) {                
SamplingTime[Index] += MouseSamplingTime * SampleCount;               
} else {                                                                
SamplingTime[Index] += DeltaTime;                                     
aMouse = aMouse * DeltaTime / MouseSamplingTime * SampleCount;        
}
} else {                                                                  
SamplingTime[Index] = 0.50000000 * MouseSamplingTime;                   
}
SmoothedMouse[Index] = aMouse / SampleCount;                              
ZeroTime[Index] = 0.00000000;                                             
}
SampleCount = 0;                                                            
if (MouseSmoothingMode > 1) {                                               
if (aMouse == 0) {                                                        
i = 0;                                                                  
while (i < 3) {                                                         
sum += (i + 1) * 0.10000000;                                          
aMouse += sum * OldSamples[i];                                        
OldSamples[i] = 0.00000000;                                           
i++;                                                                  
}
OldSamples[3] = 0.00000000;                                             
} else {                                                                  
aMouse = 0.40000001 * aMouse;                                           
OldSamples[3] = aMouse;                                                 
i = 0;                                                                  
while (i < 3) {                                                         
aMouse += (i + 1) * 0.10000000 * OldSamples[i];                       
OldSamples[i] = OldSamples[i + 1];                                    
i++;                                                                  
}
}
}
return aMouse;                                                              
}
function float AccelerateMouse(float aMouse) {
local float Accel;
if (Abs(aMouse) == 0) {                                                     
return 0.00000000;                                                        
}
Accel = MouseAccelThreshold * MouseSensitivity;                             
if (Abs(aMouse) < Accel) {                                                  
if (Abs(aMouse) < 0.10000000 * Accel) {                                   
aMouse *= 0.10000000;                                                   
} else {                                                                  
aMouse = aMouse * Abs(aMouse) / Accel;                                  
}
}
return aMouse;                                                              
}
event PlayerInput(float DeltaTime) {
local float FOVScale;
local float MouseScale;
if (mInputFrozen) {                                                         
return;                                                                   
}
FOVScale = Outer.DesiredFOV * 0.01111000;                                   
MouseScale = MouseSensitivity * FOVScale;                                   
Outer.aMouseX = SmoothMouse(Outer.aMouseX * MouseScale,DeltaTime,Outer.bXAxis,0);
Outer.aMouseY = SmoothMouse(Outer.aMouseY * MouseScale,DeltaTime,Outer.bYAxis,1);
Outer.aMouseX = AccelerateMouse(Outer.aMouseX);                             
Outer.aMouseY = AccelerateMouse(Outer.aMouseY);                             
Outer.aLookUp *= FOVScale;                                                  
Outer.aTurn *= FOVScale;                                                    
if (Outer.bStrafe != 0) {                                                   
Outer.aStrafe += Outer.aBaseX * 7.50000000 + Outer.aMouseX;               
} else {                                                                    
Outer.aTurn += Outer.aBaseX * FOVScale + Outer.aMouseX;                   
}
Outer.aBaseX = 0.00000000;                                                  
if (Outer.bStrafe == 0
&& (Outer.bAlwaysMouseLook || Outer.bLook != 0)) {
if (bInvertMouse) {                                                       
Outer.aLookUp -= Outer.aMouseY;                                         
} else {                                                                  
Outer.aLookUp += Outer.aMouseY;                                         
}
} else {                                                                    
Outer.aForward += Outer.aMouseY;                                          
}
if (Outer.bSnapLevel != 0) {                                                
Outer.bCenterView = True;                                                 
Outer.bKeyboardLook = False;                                              
} else {                                                                    
if (Outer.aLookUp != 0) {                                                 
Outer.bCenterView = False;                                              
Outer.bKeyboardLook = True;                                             
} else {                                                                  
if (Outer.bSnapToLevel && !Outer.bAlwaysMouseLook) {                    
Outer.bCenterView = True;                                             
Outer.bKeyboardLook = False;                                          
}
}
}
if (Outer.bFreeLook != 0) {                                                 
Outer.bKeyboardLook = True;                                               
Outer.aLookUp += 0.50000000 * Outer.aBaseY * FOVScale;                    
} else {                                                                    
Outer.aForward += Outer.aBaseY;                                           
}
Outer.aBaseY = 0.00000000;                                                  
Outer.HandleWalking();                                                      
}
event FreezeInput(bool InputFrozen) {
mInputFrozen = InputFrozen;                                                 
}
function bool InvertLook();
*/
