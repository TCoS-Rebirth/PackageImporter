using System;
using System.Collections.Generic;
using Engine;
using SBBase;
using UnityEngine;

namespace SBGame
{
#pragma warning disable 414   

    [Serializable]
    public class Game_CharacterStats: Base_Component, IActorPacketStream
    {
        public const int EFF_Stats = 8;

        public const int EFF_Animation = 4;

        public const int EFF_Rotation = 2;

        public const int EFF_Movement = 1;

        [FieldConst()]
        public int mBaseBody;

        [FieldConst()]
        public int mBaseMind;

        [FieldConst()]
        public int mBaseFocus;

        [FieldConst()]
        public int mBaseMaxHealth;

        [FieldConst()]
        public float mBaseRuneAffinity;

        [FieldConst()]
        public float mBaseSpiritAffinity;

        [FieldConst()]
        public float mBaseSoulAffinity;

        public int mExtraBodyPoints;

        public int mExtraMindPoints;

        public int mExtraFocusPoints;

        public float mHealth;

        public ECharacterStatsCharacterState mState;

        public byte mFrozenFlags;

        public int mFreezeMovementCount;

        public int mFreezeRotationCount;

        public int mFreezeAnimationCount;

        public int mFreezeStatsCount;

        public int mBaseMovementSpeed = 160;

        public int mMovementSpeed = 160;

        public float mRearDamageIncrease;

        public float mFrontDamageIncrease;

        public float mConcentrationAttackSpeedBonus;

        public CharacterStatsRecord mRecord;

        public byte mCharacterClass;

        [FieldConst()]
        public int mStateRankShift;

        [FieldConst()]
        public int mRegenPointShift;

        [FieldConst()]
        public int mPhysiqueLevel;

        [FieldConst()]
        public int mMoraleLevel;

        [FieldConst()]
        public int mConcentrationLevel;

        [FieldConst()]
        public int mBodyDelta;

        [FieldConst()]
        public int mMindDelta;

        [FieldConst()]
        public int mFocusDelta;

        [FieldConst()]
        public int mAttributesDeltaInternal;

        [FieldConst()]
        public float mRuneAffinityDelta;

        [FieldConst()]
        public float mSpiritAffinityDelta;

        [FieldConst()]
        public float mSoulAffinityDelta;

        [FieldConst()]
        public int mMaxHealthDelta;

        [FieldConst()]
        public float mPhysiqueRegenerationDelta;

        [FieldConst()]
        public float mPhysiqueDegenerationDelta;

        [FieldConst()]
        public float mMoraleRegenerationDelta;

        [FieldConst()]
        public float mMoraleDegenerationDelta;

        [FieldConst()]
        public float mConcentrationRegenerationDelta;

        [FieldConst()]
        public float mConcentrationDegenerationDelta;

        [FieldConst()]
        public float mHealthRegenerationDelta;

        [FieldConst()]
        public float mMeleeResistanceDelta;

        [FieldConst()]
        public float mRangedResistanceDelta;

        [FieldConst()]
        public float mMagicResistanceDelta;

        [FieldConst()]
        public int mPePRankDelta;

        [FieldConst()]
        public float mAttackSpeedBonusDelta;

        [FieldConst()]
        public float mMovementSpeedBonusDelta;

        [FieldConst()]
        public float mDamageBonusDelta;

        [FieldConst()]
        [ArraySizeForExtraction(Size = 11)]
        public float[] mPhysiqueLevelBonus = new float[0];

        [FieldConst()]
        [ArraySizeForExtraction(Size = 11)]
        public float[] mMoraleLevelBonus = new float[0];

        [FieldConst()]
        [ArraySizeForExtraction(Size = 11)]
        public float[] mConcentrationLevelBonus = new float[0];

        [FieldConst()]
        [ArraySizeForExtraction(Size = 12)]
        public int[] mBodyDefaults = new int[0];

        [FieldConst()]
        [ArraySizeForExtraction(Size = 12)]
        public int[] mMindDefaults = new int[0];

        [FieldConst()]
        [ArraySizeForExtraction(Size = 12)]
        public int[] mFocusDefaults = new int[0];

        [FieldConst()]
        [ArraySizeForExtraction(Size = 12)]
        public float[] mRuneAffinityDefaults = new float[0];

        [FieldConst()]
        [ArraySizeForExtraction(Size = 12)]
        public float[] mSpiritAffinityDefaults = new float[0];

        [FieldConst()]
        [ArraySizeForExtraction(Size = 12)]
        public float[] mSoulAffinityDefaults = new float[0];

        [FieldConst()]
        [ArraySizeForExtraction(Size = 12)]
        public int[] mMaxHealthDefaults = new int[0];

        [FieldConst()]
        [ArraySizeForExtraction(Size = 5)]
        public float[] mHealthRegenerationDefault = new float[0];

        [FieldConst()]
        [ArraySizeForExtraction(Size = 5)]
        public float[] mPhysiqueRegenerationDefault = new float[0];

        [FieldConst()]
        [ArraySizeForExtraction(Size = 5)]
        public float[] mMoraleRegenerationDefault = new float[0];

        [FieldConst()]
        [ArraySizeForExtraction(Size = 5)]
        public float[] mConcentrationRegenerationDefault = new float[0];

        [FieldConst()]
        [ArraySizeForExtraction(Size = 5)]
        public float[] mPhysiqueDegenerationDefault = new float[0];

        [FieldConst()]
        [ArraySizeForExtraction(Size = 5)]
        public float[] mMoraleDegenerationDefault = new float[0];

        [FieldConst()]
        [ArraySizeForExtraction(Size = 5)]
        public float[] mConcentrationDegenerationDefault = new float[0];

        [FieldConfig()]
        [ArraySizeForExtraction(Size = 5)]
        public float[] mMovementSpeedMultiplier = new float[0];

        [FieldConst()]
        [FieldConfig()]
        [ArraySizeForExtraction(Size = 5)]
        public float[] mDamageBonus = new float[0];

        [FieldConst()]
        [FieldConfig()]
        public int mMovementSpeedDefault;

        [FieldConst()]
        public float mRegenerationEpoch;

        [FieldConst()]
        public int mMaxHealthBonusPerFameLevel;

        [FieldConst()]
        public float mMeleeResistanceModifier;

        [FieldConst()]
        public float mRangedResistanceModifier;

        [FieldConst()]
        public float mMagicResistanceModifier;

        [FieldConst()]
        public float mRuneAffinityModifier;

        [FieldConst()]
        public float mSpiritAffinityModifier;

        [FieldConst()]
        public float mSoulAffinityModifier;

        [FieldConst()]
        [FieldConfig()]
        [ArraySizeForExtraction(Size = 6)]
        public float[] mHealthPepLvlBonus = new float[0];

        [FieldConst()]
        [FieldConfig()]
        [ArraySizeForExtraction(Size = 6)]
        public float[] mDamagePepLvlBonus = new float[0];

        private List<FreezeData> mMovementFreezeTimers = new List<FreezeData>();

        private List<FreezeData> mRotationFreezeTimers = new List<FreezeData>();

        private List<FreezeData> mAnimationFreezeTimers = new List<FreezeData>();

        private List<FreezeData> mStatsFreezeTimers = new List<FreezeData>();

        public virtual void WriteLoginStream(IPacketWriter writer) { throw new NotImplementedException(); }

        [Serializable]
        public struct FreezeData
        {
            public float Start;

            public float Duration;
        }

        [Serializable]
        public struct CharacterStatsRecord: IPacketWritable
        {
            public int Body;
            public int Mind;
            public int Focus;
            public float Physique;
            public float Morale;
            public float Concentration;
            public int FameLevel;
            public int PePRank;
            public float RuneAffinity;
            public float SpiritAffinity;
            public float SoulAffinity;
            public float MeleeResistance;
            public float RangedResistance;
            public float MagicResistance;
            public int MaxHealth;
            public float PhysiqueRegeneration;
            public float PhysiqueDegeneration;
            public float MoraleRegeneration;
            public float MoraleDegeneration;
            public float ConcentrationRegeneration;
            public float ConcentrationDegeneration;
            public float HealthRegeneration;
            public float AttackSpeedBonus;
            public float MovementSpeedBonus;
            public float DamageBonus;
            public float CopyHealth;

            public void Write(IPacketWriter writer)
            {
                writer.WriteInt32(Body);
                writer.WriteInt32(Mind);
                writer.WriteInt32(Focus);
                writer.WriteFloat(Physique);
                writer.WriteFloat(Morale);
                writer.WriteFloat(Concentration);
                writer.WriteInt32(FameLevel);
                writer.WriteInt32(PePRank);
                writer.WriteFloat(RuneAffinity);
                writer.WriteFloat(SpiritAffinity);
                writer.WriteFloat(SoulAffinity);
                writer.WriteFloat(MeleeResistance);
                writer.WriteFloat(RangedResistance);
                writer.WriteFloat(MagicResistance);
                writer.WriteInt32(MaxHealth);
                writer.WriteFloat(PhysiqueRegeneration);
                writer.WriteFloat(PhysiqueDegeneration);
                writer.WriteFloat(MoraleRegeneration);
                writer.WriteFloat(MoraleDegeneration);
                writer.WriteFloat(ConcentrationRegeneration);
                writer.WriteFloat(ConcentrationDegeneration);
                writer.WriteFloat(HealthRegeneration);
                writer.WriteFloat(AttackSpeedBonus);
                writer.WriteFloat(MovementSpeedBonus);
                writer.WriteFloat(DamageBonus);
                writer.WriteFloat(CopyHealth);
            }
        }

        public enum ECharacterStatsCharacterState
        {
            CSCS_IDLE,
            CSCS_COMBATREADY,
            CSCS_INCOMBAT,
            ECharacterStatsCharacterState_RESERVED_3,
            CSCS_SITTING,
        }

        public void FreezeMovement(bool aFreeze) { throw new NotImplementedException(); }

        public void IncreaseMeleeResistanceDelta(float aDelta) { throw new NotImplementedException(); }
        public void IncreaseMagicResistanceDelta(float aDelta) { throw new NotImplementedException(); }
        public void IncreaseRangedResistanceDelta(float aDelta) { throw new NotImplementedException(); }

        public byte GetCharacterClass() { return mCharacterClass; }

        public virtual void SetCharacterClass(byte ClassId)
        {
            throw new NotImplementedException();
        }
    }
}
/*
native function SetConcentration(float Value);
native function SetMorale(float Value);
native function SetPhysique(float Value);
final native function byte GetArchetype();
final native function int GetPePRank();
final native function int GetFameLevel();
native event int GetPrevFameLevelPoints(int aCurrentLevel);
native event int GetNextFameLevelPoints(int currentLevel);
protected native function sv2clrel_UpdateStateRankShift_CallStub();
protected native event sv2clrel_UpdateStateRankShift(int aStateRankShift);
protected native function sv2clrel_UpdateMovementSpeed_CallStub();
protected native event sv2clrel_UpdateMovementSpeed(int aMovementSpeed);
protected native function sv2clrel_UpdateFrozenFlags_CallStub();
protected native event sv2clrel_UpdateFrozenFlags(byte aFrozenFlags);
protected native function sv2clrel_UpdateMaxHealth_CallStub();
protected native event sv2clrel_UpdateMaxHealth(int aMaxHealth);
protected native function sv2clrel_UpdateHealth_CallStub();
protected native event sv2clrel_UpdateHealth(float aHealth);
protected native function sv2clrel_UpdateConcentration_CallStub();
protected native event sv2clrel_UpdateConcentration(float aConcentration);
protected native function sv2clrel_UpdateMorale_CallStub();
protected native event sv2clrel_UpdateMorale(float aMorale);
protected native function sv2clrel_UpdatePhysique_CallStub();
protected native event sv2clrel_UpdatePhysique(float aPhysique);
protected native function sv2clrel_UpdateStateVariables_CallStub();
protected native event sv2clrel_UpdateStateVariables(float aPhysique,float aMorale,float aConcentration);
protected native function sv2cl_UpdateMagicResistance_CallStub();
protected native event sv2cl_UpdateMagicResistance(float aMagicResistance);
protected native function sv2cl_UpdateRangedResistance_CallStub();
protected native event sv2cl_UpdateRangedResistance(float aRangedResistance);
protected native function sv2cl_UpdateMeleeResistance_CallStub();
protected native event sv2cl_UpdateMeleeResistance(float aMeleeResistance);
protected native function sv2cl_UpdateFocusDelta_CallStub();
protected native event sv2cl_UpdateFocusDelta(int aFocusDelta);
protected native function sv2cl_UpdateMindDelta_CallStub();
protected native event sv2cl_UpdateMindDelta(int aMindDelta);
protected native function sv2cl_UpdateBodyDelta_CallStub();
protected native event sv2cl_UpdateBodyDelta(int aBodyDelta);
static function float sv_GetMoraleLevelBonus(int MoraleLevel) {
return Class'Game_CharacterStats'.default.mMoraleLevelBonus[MoraleLevel + 5];
}
native function sv_ResetFreezeStats();
native function sv_ResetFreezeAnimation();
native function sv_ResetFreezeRotation();
native function sv_ResetFreezeMovement();
final native function bool AreStatsFrozen();
final native function bool IsMovementLimited();
final native function bool IsAnimationFrozen();
final native function bool IsRotationFrozen();
final native function bool IsMovementFrozen();
native function FreezeStatsTimed(float aDuration);
native function FreezeStats(bool aFreeze);
native function FreezeAnimationTimed(float aDuration);
protected native function sv2clrel_FreezeAnimation_CallStub();
protected event sv2clrel_FreezeAnimation(bool aFreeze) {
if (aFreeze) {                                                              
mFrozenFlags = mFrozenFlags | 4;                                          
} else {                                                                    
mFrozenFlags = mFrozenFlags & 255 - 4;                                    
}
Outer.PauseAnim(aFreeze);                                                   
}
native function FreezeAnimation(bool aFreeze);
native function FreezeRotationTimed(float aDuration);
native function FreezeRotation(bool aFreeze);
native function FreezeMovementTimed(float aDuration);
native function sv_Resurrect();
native function ResetAttributes();
native function SetAttributes(int Body,int Mind,int Focus);
native function UnsetStatsState(byte aNewState);
native function SetStatsState(byte aNewState);
native function ForceCalculationUpdate();
native function IncreaseHealthRegenerationDelta(float aDelta);
native function IncreaseConcentrationDegenerationDelta(float aDelta);
native function IncreaseConcentrationRegenerationDelta(float aDelta);
native function IncreaseMoraleDegenerationDelta(float aDelta);
native function IncreaseMoraleRegenerationDelta(float aDelta);
native function IncreasePhysiqueDegenerationDelta(float aDelta);
native function IncreasePhysiqueRegenerationDelta(float aDelta);
native function IncreaseDamageBonusDelta(float aDelta);
native function IncreaseMovementSpeedBonusDelta(float aDelta);
native function IncreaseAttackSpeedBonusDelta(float aDelta);
native function IncreaseConcentration(float aDelta);
native function IncreaseMorale(float aDelta);
native function IncreasePhysique(float aDelta);
native function IncreasePePRankDelta(int aDelta);
native function IncreaseMaxHealthDelta(int aDelta);
native function IncreaseSoulAffinityDelta(float aDelta);
native function IncreaseSpiritAffinityDelta(float aDelta);
native function IncreaseRuneAffinityDelta(float aDelta);
native function IncreaseFocusDelta(int aDelta);
native function IncreaseMindDelta(int aDelta);
native function IncreaseBodyDelta(int aDelta);
native function IncreaseFrontDamageIncrease(float aDelta);
native function IncreaseRearDamageIncrease(float aDelta);
native function int GetAttributePoints(byte aAttribute);
event cl_OnInit() {
Super.cl_OnInit();                                                          
Outer.PauseAnim(IsAnimationFrozen());                                       
}
*/
