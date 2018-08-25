﻿using System;
using Engine;

namespace SBGame
{
    [Serializable] public class FSkill_Enums : UObject
    {
        public FSkill_Enums()
        {
        }

        public enum ESkillReticuleSet
        {
            ESRS_NoReticule,

            ESRS_Melee_ShortRangeFront,

            ESRS_Melee_AOE_Base,

            ESRS_Melee_Backstab,

            ESRS_Magic_ShortRangeFront,

            ESRS_Magic_Cone,

            ESRS_Magic_AOE_Base,

            ESRS_Magic_PaintLocation,

            ESRS_Ranged_PaintLocation,

            ESRS_Melee_Self,

            ESRS_Magic_Self,
        }

        public enum EScrollingCombatTextType
        {
            ESCT_None,

            ESCT_InputDamage,

            ESCT_OutputDamage,

            ESCT_InputPhysique,

            ESCT_OutputPhysique,

            ESCT_InputMorale,

            ESCT_OutputMorale,

            ESCT_InputConcentration,

            ESCT_OutputConcentration,

            ESCT_InputHeal,

            ESCT_OutputHeal,

            ESCT_InputDuffApply,

            ESCT_OutputDuffApply,

            ESCT_OutputMiss,

            ESCT_OutputImmune,

            ESCT_OutputEvade,

            ESCT_PetError,

            ESCT_PetStandard,
        }

        public enum ETargetingBase
        {
            ETB_TriggerPawn,

            ETB_SkillPawn,
        }

        public enum ECondEvTarget
        {
            ECET_DuffPawn,

            ECET_ConditionTriggerPawn,

            ECET_OriginPawn,

            ECET_TargetPawns,
        }

        public enum ESkillEffectCategory
        {
            ESEC_Player,

            ESEC_NPC,

            ESEC_Event,

            ESEC_Item,

            ESEC_PlayerAV,

            ESEC_NPCAV,

            ESEC_EventAV,

            ESEC_ItemAV,

            ESEC_NPCTypeAV,

            ESEC_Misc,

            ESEC_Test,

            ESEC_TestAV,
        }

        public enum ESkillCategory
        {
            ESC_Player,

            ESC_NPC,

            ESC_Event,

            ESC_Item,

            ESC_Test,

            ESC_Combo,
        }

        public enum ESkillTokenEffect
        {
            SSE_None,

            SSE_Target_MaxTargets,

            SSE_Target_PaintLocationMinDistance,

            SSE_Target_PaintLocationMaxDistance,

            SSE_Target_MaxRadius,

            SSE_Damage_RearFactor,

            SSE_Damage_AbsoluteMinimum,

            SSE_Damage_AbsoluteMaximum,

            SSE_Damage_ConstantMinimum,

            SSE_Damage_ConstantMaximum,

            SSE_Damage_CharStatMinimumMultiplier,

            SSE_Damage_CharStatMaximumMultiplier,

            SSE_Damage_TargetCountMinimumMultiplier,

            SSE_Damage_TargetCountMaximumMultiplier,

            SSE_Health_AbsoluteMinimum,

            SSE_Health_AbsoluteMaximum,

            SSE_Health_ConstantMinimum,

            SSE_Health_ConstantMaximum,

            SSE_Health_CharStatMinimumMultiplier,

            SSE_Health_CharStatMaximumMultiplier,

            SSE_Health_TargetCountMinimumMultiplier,

            SSE_Health_TargetCountMaximumMultiplier,

            SSE_StatePhysique_AbsoluteMinimum,

            SSE_StatePhysique_AbsoluteMaximum,

            SSE_StatePhysique_ConstantMinimum,

            SSE_StatePhysique_ConstantMaximum,

            SSE_StatePhysique_CharStatMinimumMultiplier,

            SSE_StatePhysique_CharStatMaximumMultiplier,

            SSE_StatePhysique_TargetCountMinimumMultiplier,

            SSE_StatePhysique_TargetCountMaximumMultiplier,

            SSE_StateMorale_AbsoluteMinimum,

            SSE_StateMorale_AbsoluteMaximum,

            SSE_StateMorale_ConstantMinimum,

            SSE_StateMorale_ConstantMaximum,

            SSE_StateMorale_CharStatMinimumMultiplier,

            SSE_StateMorale_CharStatMaximumMultiplier,

            SSE_StateMorale_TargetCountMinimumMultiplier,

            SSE_StateMorale_TargetCountMaximumMultiplier,

            SSE_StateConcentration_AbsoluteMinimum,

            SSE_StateConcentration_AbsoluteMaximum,

            SSE_StateConcentration_ConstantMinimum,

            SSE_StateConcentration_ConstantMaximum,

            SSE_StateConcentration_CharStatMinimumMultiplier,

            SSE_StateConcentration_CharStatMaximumMultiplier,

            SSE_StateConcentration_TargetCountMinimumMultiplier,

            SSE_StateConcentration_TargetCountMaximumMultiplier,

            SSE_AttributeBody_AbsoluteMinimum,

            SSE_AttributeBody_AbsoluteMaximum,

            SSE_AttributeBody_ConstantMinimum,

            SSE_AttributeBody_ConstantMaximum,

            SSE_AttributeBody_CharStatMinimumMultiplier,

            SSE_AttributeBody_CharStatMaximumMultiplier,

            SSE_AttributeBody_TargetCountMinimumMultiplier,

            SSE_AttributeBody_TargetCountMaximumMultiplier,

            SSE_AttributeMind_AbsoluteMinimum,

            SSE_AttributeMind_AbsoluteMaximum,

            SSE_AttributeMind_ConstantMinimum,

            SSE_AttributeMind_ConstantMaximum,

            SSE_AttributeMind_CharStatMinimumMultiplier,

            SSE_AttributeMind_CharStatMaximumMultiplier,

            SSE_AttributeMind_TargetCountMinimumMultiplier,

            SSE_AttributeMind_TargetCountMaximumMultiplier,

            SSE_AttributeFocus_AbsoluteMinimum,

            SSE_AttributeFocus_AbsoluteMaximum,

            SSE_AttributeFocus_ConstantMinimum,

            SSE_AttributeFocus_ConstantMaximum,

            SSE_AttributeFocus_CharStatMinimumMultiplier,

            SSE_AttributeFocus_CharStatMaximumMultiplier,

            SSE_AttributeFocus_TargetCountMinimumMultiplier,

            SSE_AttributeFocus_TargetCountMaximumMultiplier,

            SSE_ResistanceMelee_AbsoluteMinimum,

            SSE_ResistanceMelee_AbsoluteMaximum,

            SSE_ResistanceMelee_ConstantMinimum,

            SSE_ResistanceMelee_ConstantMaximum,

            SSE_ResistanceMelee_CharStatMinimumMultiplier,

            SSE_ResistanceMelee_CharStatMaximumMultiplier,

            SSE_ResistanceMelee_TargetCountMinimumMultiplier,

            SSE_ResistanceMelee_TargetCountMaximumMultiplier,

            SSE_ResistanceRanged_AbsoluteMinimum,

            SSE_ResistanceRanged_AbsoluteMaximum,

            SSE_ResistanceRanged_ConstantMinimum,

            SSE_ResistanceRanged_ConstantMaximum,

            SSE_ResistanceRanged_CharStatMinimumMultiplier,

            SSE_ResistanceRanged_CharStatMaximumMultiplier,

            SSE_ResistanceRanged_TargetCountMinimumMultiplier,

            SSE_ResistanceRanged_TargetCountMaximumMultiplier,

            SSE_ResistanceMagic_AbsoluteMinimum,

            SSE_ResistanceMagic_AbsoluteMaximum,

            SSE_ResistanceMagic_ConstantMinimum,

            SSE_ResistanceMagic_ConstantMaximum,

            SSE_ResistanceMagic_CharStatMinimumMultiplier,

            SSE_ResistanceMagic_CharStatMaximumMultiplier,

            SSE_ResistanceMagic_TargetCountMinimumMultiplier,

            SSE_ResistanceMagic_TargetCountMaximumMultiplier,

            SSE_AffinitySoul_AbsoluteMinimum,

            SSE_AffinitySoul_AbsoluteMaximum,

            SSE_AffinitySoul_ConstantMinimum,

            SSE_AffinitySoul_ConstantMaximum,

            SSE_AffinitySoul_CharStatMinimumMultiplier,

            SSE_AffinitySoul_CharStatMaximumMultiplier,

            SSE_AffinitySoul_TargetCountMinimumMultiplier,

            SSE_AffinitySoul_TargetCountMaximumMultiplier,

            SSE_AffinityRune_AbsoluteMinimum,

            SSE_AffinityRune_AbsoluteMaximum,

            SSE_AffinityRune_ConstantMinimum,

            SSE_AffinityRune_ConstantMaximum,

            SSE_AffinityRune_CharStatMinimumMultiplier,

            SSE_AffinityRune_CharStatMaximumMultiplier,

            SSE_AffinityRune_TargetCountMinimumMultiplier,

            SSE_AffinityRune_TargetCountMaximumMultiplier,

            SSE_AffinitySpirit_AbsoluteMinimum,

            SSE_AffinitySpirit_AbsoluteMaximum,

            SSE_AffinitySpirit_ConstantMinimum,

            SSE_AffinitySpirit_ConstantMaximum,

            SSE_AffinitySpirit_CharStatMinimumMultiplier,

            SSE_AffinitySpirit_CharStatMaximumMultiplier,

            SSE_AffinitySpirit_TargetCountMinimumMultiplier,

            SSE_AffinitySpirit_TargetCountMaximumMultiplier,

            SSE_EventDuff_Duration,

            SSE_ReturnReflect_Multiplier,

            SSE_Misc_Cooldown,

            SSE_Chain_MaxJumps,

            SSE_EnhanceHealingInputAlteringEffects,

            SSE_EnhanceHealingOutputAlteringEffects,

            SSE_EnhanceDamageInputAlteringEffects,

            SSE_EnhanceDamageOutputAlteringEffects,

            SSE_EnhancePhysiqueInputAlteringEffects,

            SSE_EnhancePhysiqueOutputAlteringEffects,

            SSE_EnhanceMoraleInputAlteringEffects,

            SSE_EnhanceMoraleOutputAlteringEffects,

            SSE_EnhanceConcentrationInputAlteringEffects,

            SSE_EnhanceConcentrationOutputAlteringEffects,

            SSE_EnhanceAllStateInputAlteringEffects,

            SSE_EnhanceAllStateOutputAlteringEffects,
        }

        public enum EEmitterOverwrite
        {
            EEO_Auto,

            EEO_SkillPawn,

            EEO_PaintLocation,
        }

        public enum EDirectionDamageMode
        {
            EDDM_Front,

            EDDM_Rear,
        }

        public enum EComboType
        {
            ECMT_None,

            ECMT_Normal,

            ECMT_Finisher,

            ECMT_RogueOpener1,

            ECMT_RogueOpener2,

            ECMT_RogueOpener3,

            ECMT_RogueOpener4,

            ECMT_RogueOpener5,

            ECMT_RogueOpener6,

            ECMT_RogueOpener7,

            ECMT_RogueOpener8,

            ECMT_RogueOpener9,

            ECMT_RogueOpener10,

            ECMT_CasterOpener1,

            ECMT_CasterOpener2,

            ECMT_CasterOpener3,

            ECMT_CasterOpener4,

            ECMT_CasterOpener5,

            ECMT_CasterOpener6,

            ECMT_CasterOpener7,

            ECMT_CasterOpener8,

            ECMT_CasterOpener9,

            ECMT_CasterOpener10,

            ECMT_WarriorOpener1,

            ECMT_WarriorOpener2,

            ECMT_WarriorOpener3,

            ECMT_WarriorOpener4,

            ECMT_WarriorOpener5,

            ECMT_WarriorOpener6,

            ECMT_WarriorOpener7,

            ECMT_WarriorOpener8,

            ECMT_WarriorOpener9,

            ECMT_WarriorOpener10,
        }

        public enum ECharacterStateHealthType
        {
            ECSTH_Physique,

            ECSTH_Morale,

            ECSTH_Concentration,

            ECSTH_Health,
        }

        public enum ECharacterStateType
        {
            ECST_Physique,

            ECST_Morale,

            ECST_Concentration,
        }

        public enum ECharacterAttributeType
        {
            ECAT_Body,

            ECAT_Mind,

            ECAT_Focus,
        }

        public enum EMagicType
        {
            EMT_Soul,

            EMT_Rune,

            EMT_Spirit,

            EMT_None,
        }

        public enum EAttackType
        {
            EAT_Melee,

            EAT_Ranged,

            EAT_Magic,
        }

        public enum ESkillTarget
        {
            FST_None,

            FST_Self,

            FST_Ally,

            FST_Enemy,

            FST_Location,
        }

        public enum ESkillClassification
        {
            ESC_None,

            ESC_Heal,

            ESC_Damage,

            ESC_AttackSpeedBuff,

            ESC_AttackSpeedDebuff,

            ESC_DamageProtection,

            ESC_SoulProtection,

            ESC_SpiritProtection,

            ESC_RuneProtection,

            ESC_MeleeProtection,

            ESC_RangedProtection,

            ESC_MagicProtection,

            ESC_PhysiqueBuff,

            ESC_PhysiqueDebuff,

            ESC_ConcentrationBuff,

            ESC_ConcentrationDebuff,

            ESC_MoraleBuff,

            ESC_MoraleDebuff,

            ESC_KnockDown,

            ESC_Summon,
        }

        public enum EWeaponCategory
        {
            EWC_None,

            EWC_Melee,

            EWC_Ranged,

            EWC_Unarmed,

            EWC_MeleeOrUnarmed,
        }

        public enum ERotationMode
        {
            ERM_Unchanged,

            ERM_Facing,

            ERM_FacingOpposite,

            ERM_Random,
        }

        public enum ETeleportMode
        {
            ETM_Free,

            ETM_SkillUserToTargetFront,

            ETM_SkillUserToTargetBehind,

            ETM_TargetToSkillUserFront,

            ETM_TargetToSkillUserBehind,

            ETM_SkillUserToTargetLocation,
        }

        public enum EShareType
        {
            ESHT_ShareDivide,

            ESHT_ShareReturn,
        }

        public enum EShareMode
        {
            ESHM_ApplicantToTarget,

            ESHM_TargetToApplicant,

            ESHM_Both,
        }

        public enum EReturnReflectMode
        {
            ERRM_Return,

            ERRM_Reflect,
        }

        public enum EValueMode
        {
            EVM_Absolute,

            EVM_Relative,
        }

        public enum EAlterEffectMode
        {
            EAM_Input,

            EAM_Output,
        }

        public enum EDuffMagicType
        {
            EDMT_Soul,

            EDMT_Rune,

            EDMT_Spirit,

            EDMT_None,

            EDMT_All,
        }

        public enum EDuffAttackType
        {
            EDAT_Melee,

            EDAT_Ranged,

            EDAT_Magic,

            EDAT_All,
        }

        public enum EEffectType
        {
            EET_Damage,

            EET_Heal,

            EET_Physique,

            EET_Morale,

            EET_Concentration,

            EET_D1,

            EET_Body,

            EET_Mind,

            EET_Focus,

            EET_D2,

            EET_PhysiqueRegen,

            EET_MoraleRegen,

            EET_ConcentrationRegen,

            EET_HealthRegen,

            EET_D3,

            EET_PhysiqueDegen,

            EET_MoraleDegen,

            EET_ConcentrationDegen,

            EET_D4,

            EET_PePRank,

            EET_D5,

            EET_D6,

            EET_MaxHealth,

            EET_AttackSpeed,

            EET_MeleeResistance,

            EET_RangedResistance,

            EET_MagicResistance,

            EET_SoulAffinity,

            EET_RuneAffinity,

            EET_SpiritAffinity,

            EET_MovementSpeed,

            EET_All,

            EET_None,
        }

        public enum ETargetSortingMethod
        {
            ETSM_Aimed,

            ETSM_Vicinity,

            ETSM_Random,
        }

        public enum ETargetMode
        {
            ETM_Never,

            ETM_Auto,

            ETM_RangeCheck,
        }

        public enum EDuffPriority
        {
            EDP_Lowest,

            EDP_Low,

            EDP_Normal,

            EDP_High,

            EDP_Highest,
        }

        public enum EStackType
        {
            EST_Disabled,

            EST_ExposeMelee,

            EST_ExposeMagic,

            EST_ExposeRanged,

            EST_InfusedMelee,

            EST_InfusedMagic,

            EST_InfusedRanged,

            EST_ResistantMelee,

            EST_ResistantMagic,

            EST_ResistantRanged,

            EST_Immune,

            EST_ReturnMelee,

            EST_ReturnMagic,

            EST_ReturnRanged,

            EST_ReflectMelee,

            EST_Burning,

            EST_Haunted,

            EST_Doom,

            EST_Scared,

            EST_Distracted,

            EST_Crippled,

            EST_Dazed,

            EST_Hamstring,

            EST_Paralysed,

            EST_Evasive,

            EST_SteadFast,

            EST_Nightmare,

            EST_LifeTap,

            EST_Fury,

            EST_Wound,

            EST_Shock,

            EST_Backfire,

            EST_Acid,

            EST_Corrupted,

            EST_Cursed,

            EST_Decay,

            EST_BloodLink,

            EST_Formation,

            EST_ReflectMagic,

            EST_ReflectRanged,

            EST_EnhancedBody,

            EST_EnhancedMind,

            EST_EnhancedFocus,

            EST_DiminishedBody,

            EST_DiminishedMind,

            EST_DiminishedFocus,

            EST_EnhancedRune,

            EST_EnhancedSpirit,

            EST_EnhancedSoul,

            EST_DiminishedRune,

            EST_DiminishedSpirit,

            EST_DiminishedSoul,

            EST_Flame,

            EST_BloodFury,

            EST_Poison,

            EST_CorrodedResistance,

            EST_TaintedAffinities,

            EST_DecayedAttributes,

            EST_WarriorOpener1,

            EST_WarriorOpener2,

            EST_WarriorOpener3,

            EST_CasterOpener1,

            EST_CasterOpener2,

            EST_CasterOpener3,

            EST_RogueOpener1,

            EST_RogueOpener2,

            EST_RogueOpener3,

            EST_Dispirited,

            EST_Judge,

            EST_Wrath,

            EST_Disconcerted,

            EST_Chosen,

            EST_Venom,

            EST_Incubate,

            EST_Infest,

            EST_TempestTouch,

            EST_BS_Selfbuff,

            EST_BS_Squires_grasp,

            EST_BS_Squires_aura,

            EST_BS_Man_Outlook,

            EST_BS_Man_Shield,

            EST_BS_Knight_Bandage,

            EST_BS_Knight_Pugnac,

            EST_BS_Knight_Rage,

            EST_BS_Knight_Boost,

            EST_BS_Knight_Supp,

            EST_BS_Comm_Mind,

            EST_Consumable_1,

            EST_Consumable_2,

            EST_Consumable_3,

            EST_None,
        }

        public enum EDuffCondition
        {
            EDC_OnHitBy,

            EDC_OnHitWith,

            EDC_OnMissWith,

            EDC_OnSheatheWeapon,

            EDC_OnDrawWeapon,

            EDC_OnMove,

            EDC_OnDeath,

            EDC_OnUnshift,

            EDC_NoCondition,
        }

        public enum EVSSource
        {
            EVSS_TriggerPawn,

            EVSS_TargetPawn,

            EVSS_TriggerMinusTarget,

            EVSS_TargetMinusTrigger,
        }

        public enum EVSCharacterStatistic
        {
            EVSCS_Body,

            EVSCS_Mind,

            EVSCS_Focus,

            EVSCS_Physique,

            EVSCS_Morale,

            EVSCS_Concentration,

            EVSCS_FameLevel,

            EVSCS_PePRank,

            EVSCS_RuneAffinity,

            EVSCS_SpiritAffinity,

            EVSCS_SoulAffinity,

            EVSCS_MeleeResistance,

            EVSCS_RangedResistance,

            EVSCS_MagicResistance,

            EVSCS_MaxHealth,

            EVSCS_PhysiqueRegen,

            EVSCS_PhysiqueDegen,

            EVSCS_MoraleRegen,

            EVSCS_MoraleDegen,

            EVSCS_ConcentrationRegen,

            EVSCS_ConcentrationDegen,

            EVSCS_HealthRegen,

            EVSCS_AttackSpeed,

            EVSCS_MovementSpeed,

            EVSCS_AffinitySum,

            EVSCS_StateSum,

            EVSCS_AttributeSum,

            EVSCS_ResistanceSum,

            EVSCS_Health,
        }
    }
}