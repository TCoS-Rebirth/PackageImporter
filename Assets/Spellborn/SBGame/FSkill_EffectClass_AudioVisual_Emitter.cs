﻿using System;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_AudioVisual_Emitter : FSkill_EffectClass_AudioVisual
    {
        [FoldoutGroup("Emitter")]
        [FieldConst()]
        public string EmitterName = string.Empty;

        [FoldoutGroup("Emitter")]
        [FieldConst()]
        public float Duration;

        [FoldoutGroup("Binding")]
        [FieldConst()]
        public string BoundToBone = string.Empty;

        [FoldoutGroup("Binding")]
        [FieldConst()]
        public bool ScaleWithBase;

        [FoldoutGroup("Binding")]
        [FieldConst()]
        public float ExtraScale;

        [FoldoutGroup("Location")]
        [FieldConst()]
        public Vector Location;

        [FoldoutGroup("Location")]
        [FieldConst()]
        public float speed;

        [FoldoutGroup("Location")]
        [FieldConst()]
        public Rotator Rotation;

        [FoldoutGroup("Emitter")]
        [FieldConst()]
        public bool SpawnerSetsDuration;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        [TypeProxyDefinition(TypeName = "Emitter")]
        public Type EmitterClass;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool ReportedMissingEmitter;

        public FSkill_EffectClass_AudioVisual_Emitter()
        {
        }
    }
}
/*
function GetWeaponTracerBoneOffsets(Game_Pawn aPawn,out name OutBoneName,out Vector outStartBoneOffset,out Vector outEndBoneOffset) {
local Appearance_MainWeapon weaponAppearance;
local export editinline Game_EquippedAppearance equippedAppearance;
local int mainWeaponIndex;
weaponAppearance = None;                                                    
equippedAppearance = Game_EquippedAppearance(aPawn.Appearance.GetCurrent());
if (equippedAppearance != None) {                                           
mainWeaponIndex = equippedAppearance.GetValue(16);                        
if (mainWeaponIndex >= 0) {                                               
weaponAppearance = Appearance_MainWeapon(equippedAppearance.GetAppearanceResource(16,mainWeaponIndex));
}
}
if (weaponAppearance != None) {                                             
OutBoneName = 'Weapon1';                                                  
weaponAppearance.GetWeaponTracerBoneOffsets(outStartBoneOffset,outEndBoneOffset);
} else {                                                                    
OutBoneName = 'None';                                                     
}
}
protected final event LoadEmitter() {
if (EmitterClass == None || IsEditor()) {                                   
if (ReportedMissingEmitter && !IsEditor()) {                              
return;                                                                 
}
if (InStr(EmitterName,".") != -1) {                                       
EmitterClass = Class<Emitter>(static.DynamicLoadObject(EmitterName,Class'Class'));
}
if (EmitterClass == None) {                                               
EmitterClass = Class<Emitter>(static.DynamicLoadObject("SBParticles." $ EmitterName,Class'Class'));
if (EmitterClass == None) {                                             
ReportedMissingEmitter = True;                                        
return;                                                               
}
}
}
}
protected final event Actor StartEmitterOnBone(Game_Pawn aPawn,float aRunningDuration,name aBone,optional Vector aOffset) {
local Actor Emitter;
Emitter = StartEmitterOnLocation(aPawn,aPawn.Location,aRunningDuration,False);
if (Emitter != None) {                                                      
aPawn.AttachToBone(Emitter,aBone);                                        
Emitter.SetRelativeRotation(Rotation);                                    
Emitter.SetRelativeLocation(Location + aOffset);                          
}
return Emitter;                                                             
}
protected final event Actor StartEmitterOnWeaponTip(Game_Pawn aPawn,float aRunningDuration) {
local name BoneName;
local Vector StartBoneOffset;
local Vector EndBoneOffset;
GetWeaponTracerBoneOffsets(aPawn,BoneName,StartBoneOffset,EndBoneOffset);   
if (BoneName != 'None') {                                                   
return StartEmitterOnBone(aPawn,aRunningDuration,BoneName,EndBoneOffset); 
} else {                                                                    
return None;                                                              
}
}
protected final event Actor StartEmitterOnCharacterTop(Game_Pawn aPawn,float aRunningDuration,bool aAttachToActor) {
local Vector EmitterLocation;
EmitterLocation = aPawn.Location;                                           
EmitterLocation.Z += aPawn.CollisionHeight;                                 
return StartEmitterOnLocation(aPawn,EmitterLocation,aRunningDuration,aAttachToActor);
}
protected final event Actor StartEmitterOnCharacterBase(Game_Pawn aPawn,float aRunningDuration,bool aAttachToActor) {
local Vector EmitterLocation;
EmitterLocation = aPawn.Location;                                           
EmitterLocation.Z -= aPawn.CollisionHeight;                                 
return StartEmitterOnLocation(aPawn,EmitterLocation,aRunningDuration,aAttachToActor);
}
protected final event Actor StartEmitterOnHitLocation(Game_Pawn aPawn,float aRunningDuration,Vector aHitVector) {
local float hitDistance;
local Vector EmitterLocation;
hitDistance = FMax(0.00000000,FMin(VSize(aHitVector),aPawn.SkillRadius));   
EmitterLocation = aPawn.Location - Normal(aHitVector) * hitDistance;        
return StartEmitterOnLocation(aPawn,EmitterLocation,aRunningDuration,True); 
}
event Actor StartEmitterOnLocation(Actor aActor,Vector aLocation,float aRunningDuration,bool aAttachToActor) {
local Emitter Emitter;
LoadEmitter();                                                              
Emitter = aActor.Spawn(EmitterClass,aActor,,aLocation + VSize(Location) * Normal(static.QuatRotateVector(static.QuatInvert(static.QuatFromRotator(aActor.Rotation)),Normal(Location))),aActor.Rotation + Rotation);
if (Emitter == None) {                                                      
return None;                                                              
}
Emitter.AddEffectScaleFromBase = ScaleWithBase;                             
Emitter.LocalDrawScale *= ExtraScale;                                       
Emitter.SetPhysics(6);                                                      
Emitter.Acceleration = speed * vector(aActor.Rotation);                     
if (SpawnerSetsDuration) {                                                  
Emitter.LifeSpan = aRunningDuration;                                      
} else {                                                                    
if (Duration <= 0.00000000) {                                             
Emitter.LifeSpan = 0.00000000;                                          
} else {                                                                  
Emitter.LifeSpan = Duration;                                            
}
}
if (aAttachToActor && Emitter != None) {                                    
Emitter.SetBase(aActor);                                                  
}
return Emitter;                                                             
}
final event StopEmitter(Actor aActor,Actor aEmitter) {
local Game_Pawn aPawn;
aPawn = Game_Pawn(aActor);                                                  
if (aPawn != None) {                                                        
if (Len(BoundToBone) > 0) {                                               
if (aPawn != None) {                                                    
aPawn.DetachFromBone(aEmitter);                                       
}
}
}
aEmitter.Destroy();                                                         
}
final event Actor StartEmitter(Actor aActor,optional float aRunningDuration,optional Vector aHitVector) {
local Game_Pawn aPawn;
aPawn = Game_Pawn(aActor);                                                  
if (aPawn != None) {                                                        
if (Len(BoundToBone) == 0) {                                              
return StartEmitterOnCharacterBase(aPawn,aRunningDuration,False);       
} else {                                                                  
if (BoundToBone == "CharacterBase") {                                   
return StartEmitterOnCharacterBase(aPawn,aRunningDuration,True);      
} else {                                                                
if (BoundToBone == "CharacterTop") {                                  
return StartEmitterOnCharacterTop(aPawn,aRunningDuration,True);     
} else {                                                              
if (BoundToBone == "Hit") {                                         
return StartEmitterOnHitLocation(aPawn,aRunningDuration,aHitVector);
} else {                                                            
if (BoundToBone == "WeaponTip") {                                 
return StartEmitterOnWeaponTip(aPawn,aRunningDuration);         
} else {                                                          
return StartEmitterOnBone(aPawn,aRunningDuration,name(BoundToBone));
}
}
}
}
}
} else {                                                                    
if (aActor != None) {                                                     
return StartEmitterOnLocation(aActor,aActor.Location,aRunningDuration,True);
} else {                                                                  
return None;                                                            
}
}
}
*/