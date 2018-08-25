﻿using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class InteractiveLevelElement : Game_Actor
    {
        [FoldoutGroup("Interactions")]
        public List<MenuInteraction> Actions = new List<MenuInteraction>();

        [FoldoutGroup("Requirements")]
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();

        [FoldoutGroup("Requirements")]
        public bool UsableInCombat;

        [FoldoutGroup("InteractionPosition")]
        public Vector ActionPositionOffset;

        [FoldoutGroup("InteractionPosition")]
        public Rotator ActionOrientationOffset;

        [FoldoutGroup("InteractionPosition")]
        public float RequiredProximity;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Vector AbsPosition;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Rotator AbsRotation;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<TaggedEffect> TaggedEffects = new List<TaggedEffect>();

        [FoldoutGroup("Appearance")]
        public List<FSkill_EffectClass_AudioVisual> ActivatedEffects = new List<FSkill_EffectClass_AudioVisual>();

        [FoldoutGroup("Appearance")]
        public List<FSkill_EffectClass_AudioVisual> DeactivatedEffects = new List<FSkill_EffectClass_AudioVisual>();

        public List<int> ActivationEffects = new List<int>();

        [FoldoutGroup("Description")]
        public LocalizedString Description;

        public bool IsActivated;

        public bool mNetIsActivated;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool mRespawnTimerActive;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float mCurrentRespawnTime;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public byte mCurrentOption;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Game_PlayerController mTargetController;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int mListenerIndex;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float mInteractionTime;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int mCurrentOptionIndex;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int mCurrentSubAction;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool mReverse;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool mCurrentSubActionStarted;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool mIsUnderCursor;

        public InteractiveLevelElement()
        {
        }

        [Serializable] public struct TaggedEffect
        {
            public FSkill_EffectClass_AudioVisual effect;

            public int Handle;

            public NameProperty Tag;
        }

        [Serializable] public struct MenuInteraction
        {
            public byte MenuOption;

            public NameProperty InteractionTag;

            public List<Interaction_Component> StackedActions;

            public List<Content_Requirement> Requirements;
        }

        [Serializable] public struct IntegralRange
        {
            public int Min;

            public int Max;
        }
    }
}
/*
function cl_StopTaggedEffects(name aTag) {
local int ti;
ti = TaggedEffects.Length - 1;                                              
while (ti >= 0) {                                                           
if (TaggedEffects[ti].Tag == aTag) {                                      
Effects.cl_Stop(TaggedEffects[ti].Handle);                              
TaggedEffects.Remove(ti,1);                                             
}
ti--;                                                                     
}
}
function cl_StartTaggedEffect(name aTag,export editinline FSkill_EffectClass_AudioVisual aEffect) {
local TaggedEffect NewEffect;
local int H;
if (aEffect != None) {                                                      
if (aEffect.RunningDuration != 0) {                                       
H = Effects.cl_Start(aEffect,Class'Game_Effects'.-1073741824,Class'Game_Effects'.-1073741824.00000000,Class'Game_Effects'.-1073741824.00000000,Class'Game_Effects'.-1073741824.00000000);
} else {                                                                  
H = Effects.cl_Start(aEffect,Class'Game_Effects'.-1073741824,Class'Game_Effects'.-1073741824.00000000,Class'Game_Effects'.-1073741824.00000000,Class'FSkill_EffectClass_AudioVisual'.-1.00000000);
}
if (H != 0) {                                                             
NewEffect.Tag = aTag;                                                   
NewEffect.effect = aEffect;                                             
NewEffect.Handle = H;                                                   
TaggedEffects[TaggedEffects.Length] = NewEffect;                        
}
}
}
protected native function sv2clrel_CancelClientSubAction_CallStub();
event sv2clrel_CancelClientSubAction(int aOptionIndex,int aSubActionIndex) {
mCurrentOptionIndex = aOptionIndex;                                         
mCurrentSubAction = aSubActionIndex;                                        
if (IsCurrentSubActionValid()) {                                            
Actions[aOptionIndex].StackedActions[aSubActionIndex].ClOnCancel(self,mTargetPawn);
}
}
function sv_CancelClientSubAction() {
sv2clrel_CancelClientSubAction_CallStub(mCurrentOptionIndex,mCurrentSubAction);
}
protected native function sv2clrel_EndClientSubAction_CallStub();
event sv2clrel_EndClientSubAction(int aOptionIndex,int aSubActionIndex,bool aReverse) {
mCurrentOptionIndex = aOptionIndex;                                         
mCurrentSubAction = aSubActionIndex;                                        
if (IsCurrentSubActionValid()) {                                            
Actions[aOptionIndex].StackedActions[aSubActionIndex].ClOnEnd(self,mTargetPawn,aReverse);
}
}
function sv_EndClientSubAction() {
sv2clrel_EndClientSubAction_CallStub(mCurrentOptionIndex,mCurrentSubAction,mReverse);
}
protected native function sv2clrel_StartClientSubAction_CallStub();
event sv2clrel_StartClientSubAction(int aOptionIndex,int aSubActionIndex,bool aReverse,Game_Pawn aTargetPawn) {
mCurrentOptionIndex = aOptionIndex;                                         
mCurrentSubAction = aSubActionIndex;                                        
mTargetPawn = aTargetPawn;                                                  
if (IsCurrentSubActionValid()) {                                            
Actions[aOptionIndex].StackedActions[aSubActionIndex].ClOnStart(self,mTargetPawn,aReverse);
}
}
function sv_StartClientSubAction() {
sv2clrel_StartClientSubAction_CallStub(mCurrentOptionIndex,mCurrentSubAction,mReverse,mTargetPawn);
}
function byte GetActiveMenuOption(Game_Pawn aPawn) {
if (mCurrentOptionIndex >= 0) {                                             
return Actions[mCurrentOptionIndex].MenuOption;                           
} else {                                                                    
return 0;                                                                 
}
}
native function bool IsCurrentSubActionValid();
native function bool IsCurrentActionValid();
function sv_CancelSubAction() {
local Interaction_Component SubAction;
if (IsCurrentSubActionValid()) {                                            
SubAction = Actions[mCurrentOptionIndex].StackedActions[mCurrentSubAction];
SubAction.SvOnCancel(self,mTargetPawn);                                   
}
}
event sv_StopOptionActions() {
sv_CancelOptionActions();                                                   
}
event sv_CancelOptionActions() {
if (IsActivated) {                                                          
sv_CancelSubAction();                                                     
}
mCurrentOptionIndex = -1;                                                   
mCurrentSubAction = -1;                                                     
mReverse = False;                                                           
UntriggerEvent(Event,self,mTargetPawn);                                     
sv_SetActivated(False);                                                     
}
function sv_StartOptionActions() {
sv_SetActivated(True);                                                      
TriggerEvent(Event,self,mTargetPawn);                                       
if (mTargetPawn != None) {                                                  
mReverse = False;                                                         
mCurrentSubAction = 0;                                                    
}
}
event bool InRange(Actor aActor) {
return VSize(aActor.Location - AbsPosition) < RequiredProximity;            
}
event string cl_GetToolTip() {
if (IsEnabled) {                                                            
if (Description.Text != "") {                                             
return Description.Text;                                                
} else {                                                                  
return Class'StringReferences'.default.Interactive_Object.Text;         
}
}
}
function bool sv_OnRadialMenuOption(Game_Pawn anInstigator,int anOption) {
local int i;
if (!IsEnabled || IsActivated) {                                            
return False;                                                             
}
if (InRange(anInstigator)) {                                                
mCurrentOptionIndex = -1;                                                 
i = 0;                                                                    
while (i < Actions.Length) {                                              
if (Actions[i].MenuOption == anOption
&& sv_IsEligible(anInstigator,i)) {
mCurrentOptionIndex = i;                                              
goto jl0095;                                                          
}
++i;                                                                    
}
if (IsCurrentActionValid()) {                                             
if (!sv_IsEligible(anInstigator,mCurrentOptionIndex)) {                 
return False;                                                         
}
mTargetPawn = anInstigator;                                             
mCurrentOption = anOption;                                              
sv_StartOptionActions();                                                
return True;                                                            
goto jl00D8;                                                            
}
}
return False;                                                               
}
protected native function cl2sv_OnRadialMenuOption_CallStub();
event cl2sv_OnRadialMenuOption(Game_Pawn anInstigator,int anOption) {
sv_OnRadialMenuOption(anInstigator,anOption);                               
}
event RadialMenuSelect(Pawn aPlayerPawn,byte aMainOption,byte aSubOption) {
Super.RadialMenuSelect(aPlayerPawn,aMainOption,aSubOption);                 
if (IsEnabled) {                                                            
if (aMainOption == Class'Game_RadialMenuOptions'.0) {                     
mTargetPawn = Game_Pawn(aPlayerPawn);                                   
cl2sv_OnRadialMenuOption_CallStub(Game_Pawn(aPlayerPawn),aSubOption);   
}
}
}
event RadialMenuCollect(Pawn aPlayerPawn,byte aMainOption,out array<byte> aSubOptions) {
local Game_Pawn gamePawn;
local int i;
Super.RadialMenuCollect(aPlayerPawn,aMainOption,aSubOptions);               
if (aMainOption == Class'Game_RadialMenuOptions'.0) {                       
gamePawn = Game_Pawn(aPlayerPawn);                                        
if (IsEnabled && gamePawn != None && !IsActivated) {                      
i = 0;                                                                  
while (i < Actions.Length) {                                            
if (cl_IsEligible(Game_Pawn(aPlayerPawn),i)) {                        
aSubOptions[aSubOptions.Length] = Actions[i].MenuOption;            
}
++i;                                                                  
}
} else {                                                                  
aSubOptions.Length = 0;                                                 
}
}
}
function Material RadialMenuImage(Pawn aPlayerPawn,byte aMainOption,byte aSubOption) {
return None;                                                                
}
protected final native function bool cl_IsEligible(Game_Pawn aPlayer,int aAction);
final native function bool sv_IsEligible(Game_Pawn aPlayer,int aOption);
event cl_NotifyUnderCursor(bool aSetting) {
Super.cl_NotifyUnderCursor(aSetting);                                       
if (IsEnabled && mIsUnderCursor != aSetting) {                              
mIsUnderCursor = aSetting;                                                
if (aSetting) {                                                           
Effects.cl_SetInteractionEffect(Class'Game_Effects'.1);                 
} else {                                                                  
Effects.cl_SetInteractionEffect(Class'Game_Effects'.0);                 
}
}
}
function cl_SetActivated(bool Activated) {
local int i;
local int H;
IsActivated = Activated;                                                    
i = 0;                                                                      
while (i < ActivationEffects.Length) {                                      
if (ActivationEffects[i] != 0) {                                          
Effects.cl_Stop(ActivationEffects[i]);                                  
}
i++;                                                                      
}
ActivationEffects.Length = 0;                                               
if (IsActivated) {                                                          
i = 0;                                                                    
while (i < ActivatedEffects.Length) {                                     
if (ActivatedEffects[i] != None) {                                      
H = Effects.cl_Start(ActivatedEffects[i],Class'Game_Effects'.-1073741824,Class'Game_Effects'.-1073741824.00000000,Class'Game_Effects'.-1073741824.00000000,Class'FSkill_EffectClass_AudioVisual'.-1.00000000);
ActivationEffects[i] = H;                                             
}
i++;                                                                    
}
} else {                                                                    
i = 0;                                                                    
while (i < DeactivatedEffects.Length) {                                   
if (DeactivatedEffects[i] != None) {                                    
H = Effects.cl_Start(DeactivatedEffects[i],Class'Game_Effects'.-1073741824,Class'Game_Effects'.-1073741824.00000000,Class'Game_Effects'.-1073741824.00000000,Class'FSkill_EffectClass_AudioVisual'.-1.00000000);
ActivationEffects[i] = H;                                             
}
i++;                                                                    
}
}
}
protected native function sv2clrel_UpdateNetIsActivated_CallStub();
event sv2clrel_UpdateNetIsActivated(bool aNetIsActivated) {
mNetIsActivated = aNetIsActivated;                                          
if (mNetIsActivated != IsActivated) {                                       
cl_SetActivated(mNetIsActivated);                                         
}
}
function sv_SetActivated(bool Active) {
mNetIsActivated = Active;                                                   
IsActivated = Active;                                                       
sv2clrel_UpdateNetIsActivated_CallStub(mNetIsActivated);                    
}
native function Initialize();
function PostBeginPlay() {
Super.PostBeginPlay();                                                      
Initialize();                                                               
}
*/