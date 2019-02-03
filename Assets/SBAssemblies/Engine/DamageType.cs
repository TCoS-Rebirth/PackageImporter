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
    
    
    [System.Serializable] public class DamageType : Actor
    {
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public string DeathString = string.Empty;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public string FemaleSuicide = string.Empty;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public string MaleSuicide = string.Empty;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public float ViewFlash;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public Vector ViewFog;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        [TypeProxyDefinition(TypeName="Effects")]
        public System.Type DamageEffect;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public string DamageWeaponName = string.Empty;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public bool bArmorStops;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public bool bInstantHit;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public bool bFastInstantHit;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public bool bAlwaysGibs;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public bool bLocationalHit;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public bool bAlwaysSevers;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public bool bSpecial;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public bool bDetonatesGoop;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public bool bSkeletize;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public bool bCauseConvulsions;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public bool bSuperWeapon;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public bool bCausesBlood;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public bool bKUseOwnDeathVel;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public bool bKUseTearOffMomentum;
        
        public bool bDelayedDamage;
        
        public bool bNeverSevers;
        
        public bool bThrowRagdoll;
        
        public bool bRagdollBullet;
        
        public bool bLeaveBodyEffect;
        
        public bool bExtraMomentumZ;
        
        public bool bFlaming;
        
        public bool bRubbery;
        
        public bool bCausedByWorld;
        
        public bool bDirectDamage;
        
        public bool bBulletHit;
        
        public bool bVehicleHit;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public float GibModifier;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        [TypeProxyDefinition(TypeName="Effects")]
        public System.Type PawnDamageEffect;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        [TypeProxyDefinition(TypeName="Emitter")]
        public System.Type PawnDamageEmitter;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        [System.NonSerialized, UnityEngine.HideInInspector]
        public List<Sound> PawnDamageSounds = new List<Sound>();
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        [TypeProxyDefinition(TypeName="Effects")]
        public System.Type LowGoreDamageEffect;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        [TypeProxyDefinition(TypeName="Emitter")]
        public System.Type LowGoreDamageEmitter;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        [System.NonSerialized, UnityEngine.HideInInspector]
        public List<Sound> LowGoreDamageSounds = new List<Sound>();
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        [TypeProxyDefinition(TypeName="Effects")]
        public System.Type LowDetailEffect;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        [TypeProxyDefinition(TypeName="Emitter")]
        public System.Type LowDetailEmitter;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public float FlashScale;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public Vector FlashFog;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public int DamageDesc;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public int DamageThreshold;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public Vector DamageKick;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        [System.NonSerialized, UnityEngine.HideInInspector]
        public Material DamageOverlayMaterial;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        [System.NonSerialized, UnityEngine.HideInInspector]
        public Material DeathOverlayMaterial;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public float DamageOverlayTime;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public float DeathOverlayTime;
        
        [Sirenix.OdinInspector.FoldoutGroup("DamageType")]
        public float GibPerterbation;
        
        [Sirenix.OdinInspector.FoldoutGroup("Karma")]
        public float KDamageImpulse;
        
        [Sirenix.OdinInspector.FoldoutGroup("Karma")]
        public float KDeathVel;
        
        [Sirenix.OdinInspector.FoldoutGroup("Karma")]
        public float KDeathUpKick;
        
        public float VehicleDamageScaling;
        
        public float VehicleMomentumScaling;
        
        public DamageType()
        {
        }
    }
}
/*
static function string GetWeaponClass() {
return "";                                                                  
}
static function GetHitEffects(out class<xEmitter> HitEffects[4],int VictemHealth);
static function bool IsOfType(int Description) {
local int Result;
Result = Description & default.DamageDesc;                                  
return Result == Description;                                               
}
static function Sound GetPawnDamageSound() {
if (default.PawnDamageSounds.Length > 0) {                                  
return default.PawnDamageSounds[Rand(default.PawnDamageSounds.Length)];   
} else {                                                                    
return None;                                                              
}
}
static function class<Emitter> GetPawnDamageEmitter(Vector HitLocation,float Damage,Vector Momentum,Pawn Victim,bool bLowDetail) {
if (bLowDetail) {                                                           
if (default.LowDetailEmitter != None) {                                   
return default.LowDetailEmitter;                                        
} else {                                                                  
return None;                                                            
}
} else {                                                                    
if (default.PawnDamageEmitter != None) {                                  
return default.PawnDamageEmitter;                                       
} else {                                                                  
return None;                                                            
}
}
}
static function class<Effects> GetPawnDamageEffect(Vector HitLocation,float Damage,Vector Momentum,Pawn Victim,bool bLowDetail) {
if (bLowDetail) {                                                           
if (default.LowDetailEffect != None) {                                    
return default.LowDetailEffect;                                         
} else {                                                                  
return Victim.BloodEffect;                                              
}
} else {                                                                    
if (default.PawnDamageEffect != None) {                                   
return default.PawnDamageEffect;                                        
} else {                                                                  
return Victim.BloodEffect;                                              
}
}
}
static function ScoreKill(Controller Killer,Controller Killed) {
IncrementKills(Killer);                                                     
}
static function IncrementKills(Controller Killer);
*/