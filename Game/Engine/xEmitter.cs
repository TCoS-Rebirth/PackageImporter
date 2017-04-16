﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------



namespace Engine
{


    public class xEmitter : Actor
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclEmitter")]
        public byte mParticleType;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclEmitter")]
        public byte mSpawningType;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclEmitter")]
        public bool mRegen;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclEmitter")]
        public bool mRegenPause;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclEmitter")]
        [TCosReborn.Framework.Attributes.ArraySizeForExtractionAttribute(Size=2)]
        public float[] mRegenOnTime = new float[0];
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclEmitter")]
        [TCosReborn.Framework.Attributes.ArraySizeForExtractionAttribute(Size=2)]
        public float[] mRegenOffTime = new float[0];
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclEmitter")]
        public int mStartParticles;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclEmitter")]
        private int mMaxParticles;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclEmitter")]
        [TCosReborn.Framework.Attributes.ArraySizeForExtractionAttribute(Size=2)]
        public float[] mDelayRange = new float[0];
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclEmitter")]
        [TCosReborn.Framework.Attributes.ArraySizeForExtractionAttribute(Size=2)]
        public float[] mLifeRange = new float[0];
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclEmitter")]
        [TCosReborn.Framework.Attributes.ArraySizeForExtractionAttribute(Size=2)]
        public float[] mRegenRange = new float[0];
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclEmitter")]
        public float mRegenDist;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclEmitter")]
        public string mSourceActor = string.Empty;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclEmitter")]
        public string mChildName = string.Empty;
        
        public xEmitter mChildEmitter;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclEmitter")]
        public StaticMeshActor SourceStaticMesh;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclEmitter")]
        public bool bSuspendWhenNotVisible;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclVisuals")]
        public bool mDistanceAtten;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclMovement")]
        public Vector mDirDev;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclMovement")]
        public Vector mPosDev;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclMovement")]
        public Vector mSpawnVecA;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclMovement")]
        public Vector mSpawnVecB;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclMovement")]
        [TCosReborn.Framework.Attributes.ArraySizeForExtractionAttribute(Size=2)]
        public float[] mSpeedRange = new float[0];
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclMovement")]
        public bool mPosRelative;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclMovement")]
        [TCosReborn.Framework.Attributes.ArraySizeForExtractionAttribute(Size=2)]
        public float[] mMassRange = new float[0];
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclMovement")]
        public float mAirResistance;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclMovement")]
        public bool mCollision;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclMovement")]
        public float mOwnerVelocityFactor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclVisuals")]
        public bool mRandOrient;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclMovement")]
        [TCosReborn.Framework.Attributes.ArraySizeForExtractionAttribute(Size=2)]
        public float[] mSpinRange = new float[0];
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclVisuals")]
        [TCosReborn.Framework.Attributes.ArraySizeForExtractionAttribute(Size=2)]
        public float[] mSizeRange = new float[0];
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclVisuals")]
        public float mGrowthRate;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclVisuals")]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.ArraySizeForExtractionAttribute(Size=2)]
        public Color[] mColorRange = new Color[0];
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclVisuals")]
        public bool mAttenuate;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclVisuals")]
        public float mAttenKa;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclVisuals")]
        public float mAttenKb;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclVisuals")]
        public byte mAttenFunc;
        
        public int mpAttenFunc;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclVisuals")]
        public bool mRandTextures;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclVisuals")]
        public bool mTileAnimation;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclVisuals")]
        public int mNumTileColumns;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclVisuals")]
        public int mNumTileRows;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclVisuals")]
        public bool mUseMeshNodes;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclVisuals")]
        public bool mRandMeshes;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclVisuals")]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.ArraySizeForExtractionAttribute(Size=8)]
        public StaticMesh[] mMeshNodes = new StaticMesh[0];
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclVisuals")]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        public Texture mPosColorMapXY;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclVisuals")]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        public Texture mPosColorMapXZ;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclVisuals")]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        public Texture mLifeColorMap;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclSoftBody")]
        public float springK;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclSoftBody")]
        public float springD;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclSoftBody")]
        public float springMaxStretch;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclSoftBody")]
        public float springMaxCompress;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclMovement")]
        public float mColElasticity;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclMovement")]
        public float mAttraction;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="PclMovement")]
        public bool mColMakeSound;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="pclBeam")]
        public float mWaveFrequency;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="pclBeam")]
        public float mWaveAmplitude;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="pclBeam")]
        public float mWaveShift;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="pclBeam")]
        public float mBendStrength;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="pclBeam")]
        public bool mWaveLockEnd;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Force")]
        public bool bForceAffected;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int SystemHandle;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int Expire;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int mpParticles;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int mNumActivePcl;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int mpIterator;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int mbSpinningNodes;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public Vector mLastPos;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public Vector mLastVector;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public float mTime;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public float mT;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public float mRegenBias;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public float mRegenTimer;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public float mPauseTimer;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public Box mBounds;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public Plane mSphere;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public Vector mDir;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int mNumUpdates;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int mAtLeastOneFrame;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int mRenderableVerts;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public float mTexU;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public float mTexV;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public float mTotalTiles;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public float mInvTileCols;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int mpSprings;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int mNumSprings;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public float mWavePhaseA;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public float mWavePhaseB;
        
        public bool blockOnNet;
        
        public bool bCallPreSpawn;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
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
