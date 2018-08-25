﻿using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class AnimatedLevelElement : TriggeringLevelElement
    {
        [FoldoutGroup("Animations")]
        public List<AnimationParameters> Animations = new List<AnimationParameters>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public NameProperty mCurrentAnimName;

        public AnimatedLevelElement()
        {
        }

        [Serializable] public struct AnimationParameters
        {
            public byte MenuOption;

            public NameProperty animName;

            public byte PlayType;

            public float speed;
        }

        public enum AnimPlayType
        {
            APT_Normal,

            APT_Looped,

            APT_PauseAtEnd,
        }
    }
}
/*
function bool sv_OnRadialMenuOption(Game_Pawn anInstigator,int anOption) {
if (!Super.sv_OnRadialMenuOption(anInstigator,anOption)) {                  
return False;                                                             
}
sv2clrel_PlayOptionAnimation_CallStub(anOption);                            
return True;                                                                
}
function StopCurrentAnimation() {
StopAnimating();                                                            
}
function PlayOptionAnimation(byte aMenuOption) {
local int animParamIndex;
local int ChannelNumber;
local float speed;
animParamIndex = GetOptionAnimParametersIndex(aMenuOption);                 
if (animParamIndex >= 0) {                                                  
ChannelNumber = 0;                                                        
StopCurrentAnimation();                                                   
mCurrentAnimName = Animations[animParamIndex].animName;                   
if (mCurrentAnimName != 'None') {                                         
if (ChannelNumber > 0) {                                                
AnimBlendParams(ChannelNumber,1.00000000);                            
}
speed = Animations[animParamIndex].speed;                               
if (speed < 0.10000000) {                                               
speed = 1.00000000;                                                   
}
if (Animations[animParamIndex].PlayType == 1) {                         
LoopAnim(mCurrentAnimName,speed,,ChannelNumber);                      
} else {                                                                
PlayAnim(mCurrentAnimName,speed,,ChannelNumber);                      
}
}
goto jl00E0;                                                              
}
}
protected native function sv2clrel_PlayOptionAnimation_CallStub();
event sv2clrel_PlayOptionAnimation(byte aMenuOption) {
PlayOptionAnimation(aMenuOption);                                           
}
function int GetOptionAnimParametersIndex(byte aMenuOption) {
local int i;
i = 0;                                                                      
while (i < Animations.Length) {                                             
if (Animations[i].MenuOption == aMenuOption) {                            
return i;                                                               
}
++i;                                                                      
}
return -1;                                                                  
}
*/