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
    
    
    [System.Serializable] public class xEmitter : Actor
    {
        
        [Sirenix.OdinInspector.FoldoutGroup("PclEmitter")]
        public byte mParticleType;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclEmitter")]
        public byte mSpawningType;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclEmitter")]
        public bool mRegen;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclEmitter")]
        public bool mRegenPause;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclEmitter")]
        [ArraySizeForExtraction(Size=2)]
        public float[] mRegenOnTime = new float[0];
        
        [Sirenix.OdinInspector.FoldoutGroup("PclEmitter")]
        [ArraySizeForExtraction(Size=2)]
        public float[] mRegenOffTime = new float[0];
        
        [Sirenix.OdinInspector.FoldoutGroup("PclEmitter")]
        public int mStartParticles;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclEmitter")]
        private int mMaxParticles;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclEmitter")]
        [ArraySizeForExtraction(Size=2)]
        public float[] mDelayRange = new float[0];
        
        [Sirenix.OdinInspector.FoldoutGroup("PclEmitter")]
        [ArraySizeForExtraction(Size=2)]
        public float[] mLifeRange = new float[0];
        
        [Sirenix.OdinInspector.FoldoutGroup("PclEmitter")]
        [ArraySizeForExtraction(Size=2)]
        public float[] mRegenRange = new float[0];
        
        [Sirenix.OdinInspector.FoldoutGroup("PclEmitter")]
        public float mRegenDist;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclEmitter")]
        public NameProperty mSourceActor;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclEmitter")]
        public NameProperty mChildName;
        
        public xEmitter mChildEmitter;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclEmitter")]
        public StaticMeshActor SourceStaticMesh;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclEmitter")]
        public bool bSuspendWhenNotVisible;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclVisuals")]
        public bool mDistanceAtten;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclMovement")]
        public Vector mDirDev;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclMovement")]
        public Vector mPosDev;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclMovement")]
        public Vector mSpawnVecA;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclMovement")]
        public Vector mSpawnVecB;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclMovement")]
        [ArraySizeForExtraction(Size=2)]
        public float[] mSpeedRange = new float[0];
        
        [Sirenix.OdinInspector.FoldoutGroup("PclMovement")]
        public bool mPosRelative;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclMovement")]
        [ArraySizeForExtraction(Size=2)]
        public float[] mMassRange = new float[0];
        
        [Sirenix.OdinInspector.FoldoutGroup("PclMovement")]
        public float mAirResistance;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclMovement")]
        public bool mCollision;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclMovement")]
        public float mOwnerVelocityFactor;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclVisuals")]
        public bool mRandOrient;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclMovement")]
        [ArraySizeForExtraction(Size=2)]
        public float[] mSpinRange = new float[0];
        
        [Sirenix.OdinInspector.FoldoutGroup("PclVisuals")]
        [ArraySizeForExtraction(Size=2)]
        public float[] mSizeRange = new float[0];
        
        [Sirenix.OdinInspector.FoldoutGroup("PclVisuals")]
        public float mGrowthRate;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclVisuals")]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [ArraySizeForExtraction(Size=2)]
        public Color[] mColorRange = new Color[0];
        
        [Sirenix.OdinInspector.FoldoutGroup("PclVisuals")]
        public bool mAttenuate;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclVisuals")]
        public float mAttenKa;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclVisuals")]
        public float mAttenKb;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclVisuals")]
        public byte mAttenFunc;
        
        public int mpAttenFunc;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclVisuals")]
        public bool mRandTextures;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclVisuals")]
        public bool mTileAnimation;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclVisuals")]
        public int mNumTileColumns;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclVisuals")]
        public int mNumTileRows;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclVisuals")]
        public bool mUseMeshNodes;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclVisuals")]
        public bool mRandMeshes;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclVisuals")]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [ArraySizeForExtraction(Size=8)]
        public StaticMesh[] mMeshNodes = new StaticMesh[0];
        
        [Sirenix.OdinInspector.FoldoutGroup("PclVisuals")]
        [System.NonSerialized, UnityEngine.HideInInspector]
        public string mPosColorMapXY;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclVisuals")]
        [System.NonSerialized, UnityEngine.HideInInspector]
        public string mPosColorMapXZ;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclVisuals")]
        [System.NonSerialized, UnityEngine.HideInInspector]
        public string mLifeColorMap;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclSoftBody")]
        public float springK;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclSoftBody")]
        public float springD;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclSoftBody")]
        public float springMaxStretch;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclSoftBody")]
        public float springMaxCompress;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclMovement")]
        public float mColElasticity;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclMovement")]
        public float mAttraction;
        
        [Sirenix.OdinInspector.FoldoutGroup("PclMovement")]
        public bool mColMakeSound;
        
        [Sirenix.OdinInspector.FoldoutGroup("pclBeam")]
        public float mWaveFrequency;
        
        [Sirenix.OdinInspector.FoldoutGroup("pclBeam")]
        public float mWaveAmplitude;
        
        [Sirenix.OdinInspector.FoldoutGroup("pclBeam")]
        public float mWaveShift;
        
        [Sirenix.OdinInspector.FoldoutGroup("pclBeam")]
        public float mBendStrength;
        
        [Sirenix.OdinInspector.FoldoutGroup("pclBeam")]
        public bool mWaveLockEnd;
        
        [Sirenix.OdinInspector.FoldoutGroup("Force")]
        public bool bForceAffected;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public int SystemHandle;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public int Expire;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public int mpParticles;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public int mNumActivePcl;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public int mpIterator;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public int mbSpinningNodes;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public Vector mLastPos;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public Vector mLastVector;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public float mTime;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public float mT;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public float mRegenBias;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public float mRegenTimer;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public float mPauseTimer;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public Box mBounds;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public Plane mSphere;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public Vector mDir;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public int mNumUpdates;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public int mAtLeastOneFrame;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public int mRenderableVerts;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public float mTexU;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public float mTexV;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public float mTotalTiles;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public float mInvTileCols;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public int mpSprings;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public int mNumSprings;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public float mWavePhaseA;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public float mWavePhaseB;
        
        public bool blockOnNet;
        
        public bool bCallPreSpawn;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public int mHeadIndex;
        
        public xEmitter()
        {
        }
        
        public enum EAttenFunc
        {
            
            ATF_LerpInOut ,
            
            ATF_ExpInOut ,
            
            ATF_SmoothStep ,
            
            ATF_Pulse ,
            
            ATF_Random ,
            
            ATF_None,
        }
        
        public enum ExSpawningTypes
        {
            
            ST_Sphere ,
            
            ST_Line ,
            
            ST_Disc ,
            
            ST_Cylinder ,
            
            ST_AimedSphere ,
            
            ST_StaticMesh ,
            
            ST_Explode ,
            
            ST_ExplodeRing ,
            
            ST_OwnerSkeleton ,
            
            ST_Test,
        }
        
        public enum ExParticleTypes
        {
            
            PT_Sprite ,
            
            PT_Stream ,
            
            PT_Line ,
            
            PT_Disc ,
            
            PT_Mesh ,
            
            PT_Branch ,
            
            PT_Beam,
        }
    }
}
/*
static function PrecacheContent(LevelInfo Level) {
if (default.mPosColorMapXY != None) {                                       
Level.AddPrecacheMaterial(default.mPosColorMapXY);                        
}
if (default.mPosColorMapXZ != None) {                                       
Level.AddPrecacheMaterial(default.mPosColorMapXZ);                        
}
if (default.mLifeColorMap != None) {                                        
Level.AddPrecacheMaterial(default.mLifeColorMap);                         
}
if (default.Skins.Length > 0) {                                             
Level.AddPrecacheMaterial(default.Skins[0]);                              
}
}
simulated function UpdatePrecacheMaterials() {
if (mPosColorMapXY != None) {                                               
Level.AddPrecacheMaterial(mPosColorMapXY);                                
}
if (mPosColorMapXZ != None) {                                               
Level.AddPrecacheMaterial(mPosColorMapXZ);                                
}
if (mLifeColorMap != None) {                                                
Level.AddPrecacheMaterial(mLifeColorMap);                                 
}
Super.UpdatePrecacheMaterials();                                            
}
event Trigger(Actor Other,Pawn EventInstigator) {
mRegenPause = !mRegenPause;                                                 
}
final simulated function float ClampToMaxParticles(float InPart) {
return FMin(InPart,mStartParticles);                                        
}
event PreSpawned() {
if (!Level.bStartup) {                                                      
bSuspendWhenNotVisible = False;                                           
if (Level.bDropDetail && mMaxParticles > 5
&& (mParticleType == 0 || mParticleType == 4
|| mParticleType == 2)) {
mMaxParticles = mMaxParticles * 0.64999998;                             
mRegenRange[0] *= 0.80000001;                                           
mRegenRange[1] *= 0.80000001;                                           
mStartParticles = 0.64999998 * mStartParticles;                         
}
}
}
event CollisionSound();
*/