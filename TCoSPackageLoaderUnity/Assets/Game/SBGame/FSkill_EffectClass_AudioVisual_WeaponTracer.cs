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

namespace SBGame
{
    
    
    public class FSkill_EffectClass_AudioVisual_WeaponTracer : FSkill_EffectClass_AudioVisual_Emitter
    {
        
        [FieldCategory(Category="Color")]
        [IgnoreFieldExtraction()]
        public Color ColorMultiplier;
        
        public FSkill_EffectClass_AudioVisual_WeaponTracer()
        {
        }
    }
}
/*
function Actor StartEmitterOnLocation(Actor aActor,Vector aLocation,float aRunningDuration,bool aAttachToActor) {
local Emitter Emitter;
local ParticleEmitter ParticleEmitter;
local RibbonEmitter RibbonEmitter;
local int i;
local Game_Pawn aPawn;
local name BoneName;
aPawn = Game_Pawn(aActor);                                                  
if (aPawn != None) {                                                        
Emitter = Emitter(Super.StartEmitterOnLocation(aPawn,aLocation,aRunningDuration,aAttachToActor));
if (Emitter != None) {                                                    
i = 0;                                                                  
while (i < Emitter.Emitters.Length) {                                   
ParticleEmitter = Emitter.Emitters[i];                                
if (SpawnerSetsDuration) {                                            
ParticleEmitter.LifetimeRange.Min = aRunningDuration;               
ParticleEmitter.LifetimeRange.Max = aRunningDuration;               
}
RibbonEmitter = RibbonEmitter(ParticleEmitter);                       
if (RibbonEmitter != None) {                                          
GetWeaponTracerBoneOffsets(aPawn,BoneName,RibbonEmitter.StartBoneOffset,RibbonEmitter.EndBoneOffset);
if (BoneName != 'None') {                                           
RibbonEmitter.ColorMultiplierRange.X.Min = RibbonEmitter.ColorMultiplierRange.X.Min * ColorMultiplier.R / 255.00000000;
RibbonEmitter.ColorMultiplierRange.X.Max = RibbonEmitter.ColorMultiplierRange.X.Max * ColorMultiplier.R / 255.00000000;
RibbonEmitter.ColorMultiplierRange.Y.Min = RibbonEmitter.ColorMultiplierRange.Y.Min * ColorMultiplier.G / 255.00000000;
RibbonEmitter.ColorMultiplierRange.Y.Max = RibbonEmitter.ColorMultiplierRange.Y.Max * ColorMultiplier.G / 255.00000000;
RibbonEmitter.ColorMultiplierRange.Z.Min = RibbonEmitter.ColorMultiplierRange.Z.Min * ColorMultiplier.B / 255.00000000;
RibbonEmitter.ColorMultiplierRange.Z.Max = RibbonEmitter.ColorMultiplierRange.Z.Max * ColorMultiplier.B / 255.00000000;
}
}
i++;                                                                  
}
}
return Emitter;                                                           
} else {                                                                    
return None;                                                              
}
}
*/
