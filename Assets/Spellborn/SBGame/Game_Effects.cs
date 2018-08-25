﻿using System;
using System.Collections.Generic;
using Engine;
using SBBase;

namespace SBGame
{
#pragma warning disable 414     

    [Serializable] public class Game_Effects : Base_Component, IActorPacketStream
    {
        public const int MAX_NUM_REPLICATED_EFFECTS = 5;
        public const int USE_VALUE_FROM_START = -1073741824;
        public const int USE_VALUE_FROM_EFFECT_CLASS = -1073741824;

        [NonSerialized] public bool PulsatingSelection;
        [NonSerialized] public List<int> mReplicatedEffects = new List<int>();
        private List<mTaggedEffect> mTaggedEffects = new List<mTaggedEffect>();
        private int mCurrentInteractionEffectHandle;
        private FSkill_EffectClass_AudioVisual mSelectionGlowEffectClass;
        private FSkill_EffectClass_AudioVisual mSelectionPulsatingGlowEffectClass;
        private byte mCurrentInteractionEffect;
        private byte mWantedInteractionEffect;
        private int mCurrentTargetInteractionEffectHandle;
        private FSkill_EffectClass_AudioVisual mTargetGlowEffectClass;
        private byte mCurrentTargetInteractionEffect;
        private byte mWantedTargetInteractionEffect;

        public void WriteLoginStream(IPacketWriter writer)
        {
            writer.WriteInt32(mReplicatedEffects.Count);
            for (int i = 0; i < mReplicatedEffects.Count; i++)
            {
                writer.WriteInt32(mReplicatedEffects[i]);
            }
        }

        [Serializable] public struct mTaggedEffect
        {
            public int ServerSideEffectHandle;

            public NameProperty Tag;
        }

        public enum ETargetInteractionEffect
        {
            TIE_None,
            TIE_Selected,
        }

        public enum EInteractionEffect
        {
            IE_None,
            IE_Hover,
            IE_Selected,
        }
    }
}
/*
private final native function bool cl_StopReplicated(int aServerSideEffectHandle,optional float anOutroDuration);
protected native function sv2clrel_StopReplicated_CallStub();
private final event sv2clrel_StopReplicated(int ServerSideHandle) {
cl_StopReplicated(ServerSideHandle);                                        
}
protected native function sv2clrel_StartReplicated_CallStub();
private final event sv2clrel_StartReplicated(int effectResourceID,int ServerSideHandle) {
local export editinline FSkill_EffectClass_AudioVisual effectResource;
effectResource = FSkill_EffectClass_AudioVisual(Class'SBDBSync'.GetResourceObject(effectResourceID));
cl_Start(effectResource,-1073741824,-1073741824.00000000,-1073741824.00000000,-1073741824.00000000,-1073741824.00000000,1.00000000,ServerSideHandle,0);
}
private final native function int sv_GetNewEffectHandle();
function cl_SetTargetInteractionEffect(byte aTargetInteractionEffect) {
mWantedTargetInteractionEffect = aTargetInteractionEffect;                  
}
function cl_SetInteractionEffect(byte aInteractionEffect) {
mWantedInteractionEffect = aInteractionEffect;                              
}
final event bool sv_StopReplicated(int aServerSideEffectHandle) {
local int i;
if (aServerSideEffectHandle != 0) {                                         
i = 0;                                                                    
while (i < mReplicatedEffects.Length / 2) {                               
if (mReplicatedEffects[2 * i + 1] == aServerSideEffectHandle) {         
mReplicatedEffects[2 * i] = mReplicatedEffects[mReplicatedEffects.Length - 2];
mReplicatedEffects[2 * i + 1] = mReplicatedEffects[mReplicatedEffects.Length - 1];
mReplicatedEffects.Length = mReplicatedEffects.Length - 2;            
sv2clrel_StopReplicated_CallStub(aServerSideEffectHandle);            
return True;                                                          
}
i++;                                                                    
}
return False;                                                             
goto jl00B1;                                                              
}
}
final event int sv_StartReplicated(export editinline FSkill_EffectClass_AudioVisual anEffect) {
local int Handle;
if (mReplicatedEffects.Length != 2 * 5) {                                   
if (anEffect != None) {                                                   
Handle = sv_GetNewEffectHandle();                                       
mReplicatedEffects.Length = mReplicatedEffects.Length + 2;              
mReplicatedEffects[mReplicatedEffects.Length - 2] = anEffect.ResourceId;
mReplicatedEffects[mReplicatedEffects.Length - 1] = Handle;             
sv2clrel_StartReplicated_CallStub(anEffect.ResourceId,Handle);          
return Handle;                                                          
} else {                                                                  
return 0;                                                               
}
} else {                                                                    
return 0;                                                                 
}
}
final event int sv_StartReplicatedOneShot(export editinline FSkill_EffectClass_AudioVisual anEffect) {
local int Handle;
if (anEffect != None) {                                                     
Handle = sv_GetNewEffectHandle();                                         
sv2clrel_StartReplicated_CallStub(anEffect.ResourceId,Handle);            
return Handle;                                                            
} else {                                                                    
return 0;                                                                 
}
}
final function int sv_StopTagged(name aTag) {
local int Count;
local int i;
Count = 0;                                                                  
i = 0;                                                                      
while (i < mTaggedEffects.Length) {                                         
if (mTaggedEffects[i].Tag == aTag) {                                      
if (sv_StopReplicated(mTaggedEffects[i].ServerSideEffectHandle)) {      
Count++;                                                              
}
mTaggedEffects.Remove(i,1);                                             
i--;                                                                    
}
i++;                                                                      
}
return Count;                                                               
}
final function bool sv_StartTagged(export editinline FSkill_EffectClass_AudioVisual anEffect,name aTag) {
local int Handle;
if (aTag != 'None') {                                                       
Handle = sv_StartReplicated(anEffect);                                    
if (Handle > 0) {                                                         
mTaggedEffects.Insert(mTaggedEffects.Length,1);                         
mTaggedEffects[mTaggedEffects.Length - 1].ServerSideEffectHandle = Handle;
mTaggedEffects[mTaggedEffects.Length - 1].Tag = aTag;                   
return True;                                                            
}
}
return False;                                                               
}
final native function cl_StopAll();
final native function bool cl_Stop(int aClientSideEffectHandle,optional float anOutroDuration);
final native function int cl_Start(export editinline FSkill_EffectClass_AudioVisual anEffect,optional int aPriority,optional float aDelay,optional float anIntroDuration,optional float aDuration,optional float anOutroDuration,optional float aProceduralAmplitude,optional int aServerSideHandle,optional int aUserdata);
native function cl_OnTick(float aDeltaTime);
event cl_OnBaseline() {
local export editinline FSkill_EffectClass_AudioVisual effectResource;
local int ResourceId;
local int ServerSideHandle;
local int i;
i = 0;                                                                      
while (i < mReplicatedEffects.Length / 2) {                                 
ResourceId = mReplicatedEffects[i * 2];                                   
ServerSideHandle = mReplicatedEffects[i * 2 + 1];                         
effectResource = FSkill_EffectClass_AudioVisual(Class'SBDBSync'.GetResourceObject(ResourceId));
cl_Start(effectResource,-1073741824,0.00000000,0.00000000,-1073741824.00000000,-1073741824.00000000,1.00000000,ServerSideHandle,0);
i++;                                                                      
}
}
*/