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

        [NonSerialized] public int mBaseBody;
        [NonSerialized] public int mBaseMind;
        [NonSerialized] public int mBaseFocus;
        [NonSerialized] public int mBaseMaxHealth;
        [NonSerialized] public float mBaseRuneAffinity;
        [NonSerialized] public float mBaseSpiritAffinity;
        [NonSerialized] public float mBaseSoulAffinity;
        [NonSerialized] public int mExtraBodyPoints;
        [NonSerialized] public int mExtraMindPoints;
        [NonSerialized] public int mExtraFocusPoints;
        [NonSerialized] public float mHealth;
        [NonSerialized] public ECharacterStatsCharacterState mState;
        [NonSerialized] public byte mFrozenFlags; //EFF_X
        [NonSerialized] public int mFreezeMovementCount;
        [NonSerialized] public int mFreezeRotationCount;
        [NonSerialized] public int mFreezeAnimationCount;
        [NonSerialized] public int mFreezeStatsCount;
        [NonSerialized] public int mBaseMovementSpeed;
        [NonSerialized] public int mMovementSpeed;
        [NonSerialized] public float mRearDamageIncrease;
        [NonSerialized] public float mFrontDamageIncrease;
        [NonSerialized] public float mConcentrationAttackSpeedBonus;
        [NonSerialized] public CharacterStatsRecord mRecord;
        [NonSerialized] public Content_API.EContentClass mCharacterClass;

        [NonSerialized] public int mStateRankShift;
        [NonSerialized] public int mRegenPointShift;
        [NonSerialized] public int mPhysiqueLevel;
        [NonSerialized] public int mMoraleLevel;
        [NonSerialized] public int mConcentrationLevel;
        [NonSerialized] public int mBodyDelta;
        [NonSerialized] public int mMindDelta;
        [NonSerialized] public int mFocusDelta;
        [NonSerialized] public int mAttributesDeltaInternal;
        [NonSerialized] public float mRuneAffinityDelta;
        [NonSerialized] public float mSpiritAffinityDelta;
        [NonSerialized] public float mSoulAffinityDelta;
        [NonSerialized] public int mMaxHealthDelta;
        [NonSerialized] public float mPhysiqueRegenerationDelta;
        [NonSerialized] public float mPhysiqueDegenerationDelta;
        [NonSerialized] public float mMoraleRegenerationDelta;
        [NonSerialized] public float mMoraleDegenerationDelta;
        [NonSerialized] public float mConcentrationRegenerationDelta;
        [NonSerialized] public float mConcentrationDegenerationDelta;
        [NonSerialized] public float mHealthRegenerationDelta;
        [NonSerialized] public float mMeleeResistanceDelta;
        [NonSerialized] public float mRangedResistanceDelta;
        [NonSerialized] public float mMagicResistanceDelta;
        [NonSerialized] public int mPePRankDelta;
        [NonSerialized] public float mAttackSpeedBonusDelta;
        [NonSerialized] public float mMovementSpeedBonusDelta;
        [NonSerialized] public float mDamageBonusDelta;

        public float[] mPhysiqueLevelBonus = new float[11];
        public float[] mMoraleLevelBonus = new float[11];
        public float[] mConcentrationLevelBonus = new float[11];
        public int[] mBodyDefaults = new int[12];
        public int[] mMindDefaults = new int[12];
        public int[] mFocusDefaults = new int[12];
        public float[] mRuneAffinityDefaults = new float[12];
        public float[] mSpiritAffinityDefaults = new float[12];
        public float[] mSoulAffinityDefaults = new float[12];
        public int[] mMaxHealthDefaults = new int[12];
        public float[] mHealthRegenerationDefault = new float[5];
        public float[] mPhysiqueRegenerationDefault = new float[5];
        public float[] mMoraleRegenerationDefault = new float[5];
        public float[] mConcentrationRegenerationDefault = new float[5];
        public float[] mPhysiqueDegenerationDefault = new float[5];
        public float[] mMoraleDegenerationDefault = new float[5];
        public float[] mConcentrationDegenerationDefault = new float[5];

        [FieldConfig()]
        public float[] mMovementSpeedMultiplier = new float[5];
        [FieldConfig()]
        public float[] mDamageBonus = new float[5];
        [FieldConfig()]
        public int mMovementSpeedDefault;

        [NonSerialized] public float mRegenerationEpoch;
        [NonSerialized] public int mMaxHealthBonusPerFameLevel;
        [NonSerialized] public float mMeleeResistanceModifier;
        [NonSerialized] public float mRangedResistanceModifier;
        [NonSerialized] public float mMagicResistanceModifier;
        [NonSerialized] public float mRuneAffinityModifier;
        [NonSerialized] public float mSpiritAffinityModifier;
        [NonSerialized] public float mSoulAffinityModifier;

        [FieldConfig()]
        public float[] mHealthPepLvlBonus = new float[6];
        [FieldConfig()]
        public float[] mDamagePepLvlBonus = new float[6];

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

        public override void Initialize(Actor outer)
        {
            base.Initialize(outer);
            mMovementSpeed = mMovementSpeedDefault;
            mBaseMovementSpeed = mMovementSpeedDefault;
            mBaseMaxHealth = mMaxHealthDefaults[GetFameLevel()];
            mRecord.MaxHealth = mBaseMaxHealth;
            Debug.LogWarning("TODO Calculate stats correctly");
            //Outer.PauseAnim(IsAnimationFrozen());                                       
        }

        public void sv2clrel_FreezeAnimation(bool aFreeze)
        {
            if (aFreeze)
            {
                mFrozenFlags |= EFF_Animation;
            }
            else
            {
                mFrozenFlags = (byte)(mFrozenFlags & 255 - EFF_Animation);
            }
            //Outer.PauseAnim(aFreeze);                                                   
        }

        public void SetConcentration(float Value)
        {
            mConcentrationLevel = (int)Value;
            mRecord.Concentration = mConcentrationLevel;
        }

        public void SetMorale(float Value)
        {
            mMoraleLevel = (int)Value;
            mRecord.Morale = mMoraleLevel;
        }

        public void SetPhysique(float Value)
        {
            mPhysiqueLevel = (int)Value;
        }

        public Content_API.EContentClass GetCharacterClass()
        {
            return mCharacterClass;
        }

        public void SetCharacterClass(Content_API.EContentClass ClassId)
        {
            mCharacterClass = ClassId;
        }

        public byte GetArchetype()
        {
            throw new NotImplementedException();
        }

        public virtual int GetPePRank()
        {
            return mRecord.PePRank;
        }

        public virtual int GetFameLevel()
        {
            return mRecord.FameLevel;
        }

        public int GetPrevFameLevelPoints(int aCurrentLevel)
        {
            throw new NotImplementedException("Use the Levelprogression data");
        }

        public int GetNextFameLevelPoints(int currentLevel)
        {
            throw new NotImplementedException("Use the Levelprogression data");
        }

        public bool AreStatsFrozen()
        {
            return (mFrozenFlags & EFF_Stats) == EFF_Stats;
        }

        public bool IsMovementLimited()
        {
            throw new NotImplementedException();
        }

        public bool IsAnimationFrozen()
        {
            return (mFrozenFlags & EFF_Animation) == EFF_Animation;
        }

        public bool IsRotationFrozen()
        {
            return (mFrozenFlags & EFF_Rotation) == EFF_Rotation;
        }

        public bool IsMovementFrozen()
        {
            return (mFrozenFlags & EFF_Movement) == EFF_Movement;
        }

        public void FreezeStatsTimed(float aDuration)
        {
            throw new NotImplementedException();
        }

        public void FreezeStats(bool aFreeze)
        {
            mFrozenFlags |= EFF_Stats;
        }

        public void FreezeAnimationTimed(float aDuration)
        {
            throw new NotImplementedException();
        }

        public void FreezeAnimation(bool aFreeze)
        {
            if (aFreeze)
            {
                mFrozenFlags |= EFF_Animation;
            }
            else
            {
                mFrozenFlags = (byte)(mFrozenFlags & ~EFF_Animation);
            }
        }

        public void FreezeRotationTimed(float aDuration)
        {
            throw new NotImplementedException();
        }

        public void FreezeRotation(bool aFreeze)
        {
            if (aFreeze)
            {
                mFrozenFlags |= EFF_Rotation;
            }
            else
            {
                mFrozenFlags = (byte)(mFrozenFlags & ~EFF_Rotation);
            }
        }

        public void FreezeMovementTimed(float aDuration)
        {
            throw new NotImplementedException();
        }

        public void FreezeMovement(bool aFreeze)
        {
            if (aFreeze)
            {
                mFrozenFlags |= EFF_Movement;
            }
            else
            {
                mFrozenFlags = (byte)(mFrozenFlags & ~EFF_Movement);
            }
        }

        public void ResetAttributes()
        {
            throw new NotImplementedException();
        }

        public void SetAttributes(int Body, int Mind, int Focus)
        {
            throw new NotImplementedException();
        }

        public void UnsetStatsState(ECharacterStatsCharacterState aNewState)
        {
            mState = aNewState;
        }

        public void SetStatsState(ECharacterStatsCharacterState aNewState)
        {
            mState = aNewState;
        }

        public void ForceCalculationUpdate()
        {
            throw new NotImplementedException();
        }

        public void IncreaseMeleeResistanceDelta(float f)
        {
            mMeleeResistanceDelta += f;
        }

        public void IncreaseRangedResistanceDelta(float f)
        {
            mRangedResistanceDelta += f;
        }

        public void IncreaseMagicResistanceDelta(float f)
        {
            mMagicResistanceDelta += f;
        }

        public void IncreaseHealthRegenerationDelta(float aDelta)
        {
            mHealthRegenerationDelta += aDelta;
        }

        public void IncreaseConcentrationDegenerationDelta(float aDelta)
        {
            mConcentrationDegenerationDelta += aDelta;
        }

        public void IncreaseConcentrationRegenerationDelta(float aDelta)
        {
            mConcentrationRegenerationDelta += aDelta;
        }

        public void IncreaseMoraleDegenerationDelta(float aDelta)
        {
            mMoraleDegenerationDelta += aDelta;
        }

        public void IncreaseMoraleRegenerationDelta(float aDelta)
        {
            mMoraleRegenerationDelta += aDelta;
        }

        public void IncreasePhysiqueDegenerationDelta(float aDelta)
        {
            mPhysiqueDegenerationDelta += aDelta;
        }

        public void IncreasePhysiqueRegenerationDelta(float aDelta)
        {
            mPhysiqueRegenerationDelta += aDelta;
        }

        public void IncreaseDamageBonusDelta(float aDelta)
        {
            mDamageBonusDelta += aDelta;
        }

        public void IncreaseMovementSpeedBonusDelta(float aDelta)
        {
            mMovementSpeedBonusDelta += aDelta;
        }

        public void IncreaseAttackSpeedBonusDelta(float aDelta)
        {
            mAttackSpeedBonusDelta += aDelta;
        }

        public void IncreaseConcentration(float aDelta)
        {
            Debug.Log("correct?");
            mConcentrationLevel += (int)aDelta;
        }

        public void IncreaseMorale(float aDelta)
        {
            Debug.Log("correct?");
            mMoraleLevel += (int)aDelta;
        }

        public void IncreasePhysique(float aDelta)
        {
            Debug.Log("correct?");
            mPhysiqueLevel += (int)aDelta;
        }

        public void IncreasePePRankDelta(int aDelta)
        {
            mPePRankDelta += aDelta;
        }

        public void IncreaseMaxHealthDelta(int aDelta)
        {
            mMaxHealthDelta += aDelta;
        }

        public void IncreaseSoulAffinityDelta(float aDelta)
        {
            mSoulAffinityDelta += aDelta;
        }

        public void IncreaseSpiritAffinityDelta(float aDelta)
        {
            mSpiritAffinityDelta += aDelta;
        }

        public void IncreaseRuneAffinityDelta(float aDelta)
        {
            mRuneAffinityDelta += aDelta;
        }

        public void IncreaseFocusDelta(int aDelta)
        {
            mFocusDelta += aDelta;
        }

        public void IncreaseMindDelta(int aDelta)
        {
            mMindDelta += aDelta;
        }

        public void IncreaseBodyDelta(int aDelta)
        {
            mBodyDelta += aDelta;
        }

        public void IncreaseFrontDamageIncrease(float aDelta)
        {
            mFrontDamageIncrease += aDelta;
        }

        public void IncreaseRearDamageIncrease(float aDelta)
        {
            mRearDamageIncrease += aDelta;
        }

        public int GetAttributePoints(byte aAttribute)
        {
            throw new NotImplementedException();
        }

    }
}
/*
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
protected native function sv2clrel_FreezeAnimation_CallStub();
native function sv_Resurrect();
native function ResetAttributes();
*/
