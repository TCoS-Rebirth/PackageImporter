using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_PowerSystem : UObject
    {
        [FoldoutGroup("targeting")]
        [FieldConfig()]
        public float NumPartyMembersInFight;

        [FoldoutGroup("targeting")]
        [FieldConfig()]
        public float NumPetsInFight;

        [FoldoutGroup("targeting")]
        [FieldConfig()]
        public float NumBloodLinksInFight;

        [FoldoutGroup("targeting")]
        [FieldConfig()]
        public float CollateralDamagePercentage;

        [FoldoutGroup("targeting")]
        [FieldConfig()]
        public float HitChance;

        [FoldoutGroup("targeting")]
        [FieldConfig()]
        public float RearHitChance;

        [FoldoutGroup("targeting")]
        [FieldConfig()]
        public float NonCombatReadyDamageIncrease;

        [FoldoutGroup("Stats")]
        [FieldConfig()]
        public Game_CharacterStats.CharacterStatsRecord TriggerPawnCharacterStats;

        [FoldoutGroup("Stats")]
        [FieldConfig()]
        public Game_CharacterStats.CharacterStatsRecord TargetPawnCharacterStats;

        [FoldoutGroup("Direct")]
        [FieldConfig()]
        public float HealPower;

        [FoldoutGroup("Direct")]
        [FieldConfig()]
        public float StatePhysiquePower;

        [FoldoutGroup("Direct")]
        [FieldConfig()]
        public float StateMoralePower;

        [FoldoutGroup("Direct")]
        [FieldConfig()]
        public float StateConcentrationPower;

        [FoldoutGroup("Direct")]
        [FieldConfig()]
        public float FrontDamageIncrease;

        [FoldoutGroup("Direct")]
        [FieldConfig()]
        public float RearDamageIncrease;

        [FoldoutGroup("Condition")]
        [FieldConfig()]
        public ConditionFireChance FireChance_OnHitBy;

        [FoldoutGroup("Condition")]
        [FieldConfig()]
        public ConditionFireChance FireChance_OnHitWith;

        [FoldoutGroup("Condition")]
        [FieldConfig()]
        public ConditionFireChance FireChance_OnMissWith;

        [FoldoutGroup("Condition")]
        [FieldConfig()]
        public ConditionFireChance FireChance_OnSheatheWeapon;

        [FoldoutGroup("Condition")]
        [FieldConfig()]
        public ConditionFireChance FireChance_OnDrawWeapon;

        [FoldoutGroup("Condition")]
        [FieldConfig()]
        public ConditionFireChance FireChance_OnMove;

        [FoldoutGroup("Condition")]
        [FieldConfig()]
        public ConditionFireChance FireChance_OnDeath;

        [FoldoutGroup("Condition")]
        [FieldConfig()]
        public ConditionFireChance FireChance_OnUnshift;

        [FoldoutGroup("Condition")]
        [FieldConfig()]
        public float FireChance_Melee;

        [FoldoutGroup("Condition")]
        [FieldConfig()]
        public float FireChance_Ranged;

        [FoldoutGroup("Condition")]
        [FieldConfig()]
        public float FireChance_Magic;

        [FoldoutGroup("Condition")]
        [FieldConfig()]
        public float FireChance_Rune;

        [FoldoutGroup("Condition")]
        [FieldConfig()]
        public float FireChance_Soul;

        [FoldoutGroup("Condition")]
        [FieldConfig()]
        public float FireChance_Spirit;

        [FoldoutGroup("Condition")]
        [FieldConfig()]
        public float FireChance_SpecificEffectType;

        [FoldoutGroup("DuffAffinity")]
        [FieldConfig()]
        public float SoulAffinityPowerPerSecond;

        [FoldoutGroup("DuffAffinity")]
        [FieldConfig()]
        public float RuneAffinityPowerPerSecond;

        [FoldoutGroup("DuffAffinity")]
        [FieldConfig()]
        public float SpiritAffinityPowerPerSecond;

        [FoldoutGroup("DuffAlter")]
        [FieldConfig()]
        public float AlterEffectAbsolutePowerPerUse;

        [FoldoutGroup("DuffAlter")]
        [FieldConfig()]
        public float AlterEffectRelativePowerPerUse;

        [FoldoutGroup("DuffAlter")]
        [FieldConfig()]
        public float OutgoingAllEffectsPerSecond;

        [FoldoutGroup("DuffAlter")]
        [FieldConfig()]
        public float OutgoingSpecificEffectsPerSecond;

        [FoldoutGroup("DuffAlter")]
        [FieldConfig()]
        public float IncomingAllEffectsPerSecond;

        [FoldoutGroup("DuffAlter")]
        [FieldConfig()]
        public float IncomingSpecificEffectsPerSecond;

        [FoldoutGroup("DuffAttribute")]
        [FieldConfig()]
        public float BodyPowerPerSecond;

        [FoldoutGroup("DuffAttribute")]
        [FieldConfig()]
        public float MindPowerPerSecond;

        [FoldoutGroup("DuffAttribute")]
        [FieldConfig()]
        public float FocusPowerPerSecond;

        [FoldoutGroup("DuffDegeneration")]
        [FieldConfig()]
        public float PhysiqueDegenerationPowerPerSecond;

        [FoldoutGroup("DuffDegeneration")]
        [FieldConfig()]
        public float MoraleDegenerationPowerPerSecond;

        [FoldoutGroup("DuffDegeneration")]
        [FieldConfig()]
        public float ConcentrationDegenerationPowerPerSecond;

        [FoldoutGroup("DuffRegeneration")]
        [FieldConfig()]
        public float PhysiqueRegenerationPowerPerSecond;

        [FoldoutGroup("DuffRegeneration")]
        [FieldConfig()]
        public float MoraleRegenerationPowerPerSecond;

        [FoldoutGroup("DuffRegeneration")]
        [FieldConfig()]
        public float ConcentrationRegenerationPowerPerSecond;

        [FoldoutGroup("DuffRegeneration")]
        [FieldConfig()]
        public float HealthRegenerationPowerPerSecond;

        [FoldoutGroup("DuffDirectionalDmg")]
        [FieldConfig()]
        public float DirectionalDamageRearPowerPerSecond;

        [FoldoutGroup("DuffDirectionalDmg")]
        [FieldConfig()]
        public float DirectionalDamageFrontPowerPerSecond;

        [FoldoutGroup("DuffDisableSkillUse")]
        [FieldConfig()]
        public float DisableAllSkillUsePowerPerSecond;

        [FoldoutGroup("DuffDisableSkillUse")]
        [FieldConfig()]
        public float DisableMagicSkillUsePowerPerSecond;

        [FoldoutGroup("DuffDisableSkillUse")]
        [FieldConfig()]
        public float DisableMeleeSkillUsePowerPerSecond;

        [FoldoutGroup("DuffDisableSkillUse")]
        [FieldConfig()]
        public float DisableRangedSkillUsePowerPerSecond;

        [FoldoutGroup("DuffDisableSkillUse")]
        [FieldConfig()]
        public float DisableNoneMagicSkillUsePowerPerSecond;

        [FoldoutGroup("DuffDisableSkillUse")]
        [FieldConfig()]
        public float DisableSoulMagicSkillUsePowerPerSecond;

        [FoldoutGroup("DuffDisableSkillUse")]
        [FieldConfig()]
        public float DisableRuneMagicSkillUsePowerPerSecond;

        [FoldoutGroup("DuffDisableSkillUse")]
        [FieldConfig()]
        public float DisableSpiritMagicSkillUsePowerPerSecond;

        [FoldoutGroup("DuffImmune")]
        [FieldConfig()]
        public float ImmuneForAllPowerPerSecond;

        [FoldoutGroup("DuffImmune")]
        [FieldConfig()]
        public float ImmuneForMagicPowerPerSecond;

        [FoldoutGroup("DuffImmune")]
        [FieldConfig()]
        public float ImmuneForMeleePowerPerSecond;

        [FoldoutGroup("DuffImmune")]
        [FieldConfig()]
        public float ImmuneForRangedPowerPerSecond;

        [FoldoutGroup("DuffImmune")]
        [FieldConfig()]
        public float ImmuneForNoneMagicPowerPerSecond;

        [FoldoutGroup("DuffImmune")]
        [FieldConfig()]
        public float ImmuneForSoulMagicPowerPerSecond;

        [FoldoutGroup("DuffImmune")]
        [FieldConfig()]
        public float ImmuneForRuneMagicPowerPerSecond;

        [FoldoutGroup("DuffImmune")]
        [FieldConfig()]
        public float ImmuneForSpiritMagicPowerPerSecond;

        [FoldoutGroup("DuffImmune")]
        [FieldConfig()]
        public float ImmuneForSpecificEffectPowerPerSecond;

        [FoldoutGroup("DuffMaxHealth")]
        [FieldConfig()]
        public float MaxHealthPowerPerSecond;

        [FoldoutGroup("DuffPePRank")]
        [FieldConfig()]
        public float PePRankPowerPerSecond;

        [FoldoutGroup("DuffResistance")]
        [FieldConfig()]
        public float AttackTypeMeleeResistancePowerPerSecond;

        [FoldoutGroup("DuffResistance")]
        [FieldConfig()]
        public float AttackTypeRangedResistancePowerPerSecond;

        [FoldoutGroup("DuffResistance")]
        [FieldConfig()]
        public float AttackTypeMagicResistancePowerPerSecond;

        [FoldoutGroup("DuffResistance")]
        [FieldConfig()]
        public float AttackTypeAllResistancePowerPerSecond;

        public FSkill_PowerSystem()
        {
        }

        [Serializable] public struct ConditionFireChance
        {
            public float MaxFiresPerSecond;

            public float MaxFires;

            public float FireChance_While_Avoiding;

            public float FireChance_While_Seeking;
        }
    }
}