﻿using System;
using Engine;
using UnityEngine;

namespace SBAI
{
    [Serializable] public class AIState : UObject
    {
        public AIState mParent;

        public Game_AIController mOwner;

        public float mFrequencyTimeout;

        public float mFrequencyTimer;

        public bool mAborted;

        public bool mControlTargeting;

        public bool mControlMovement;

        [FieldConfig()]
        public float Heal;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int ExCleanIndex;

        public bool mQueued;

        public bool mNeedWeapon;

        public bool mNeedAggro;

        public AIState()
        {
        }

        public enum EStateSignal
        {
            SS_None,

            SS_StateSuccess,

            SS_StateFailure,

            SS_StateError,

            SS_StateAborted,

            SS_Timer,

            SS_EnemyDetected,

            SS_EnemiesLost,

            SS_AllyDetected,

            SS_AllyLost,

            SS_CombatEnter,

            SS_CombatExit,

            SS_LostAggro,

            SS_SkillFinished,

            SS_SkillReady,

            SS_SkillAimed,

            SS_Conversation,

            SS_EndConversation,

            SS_TargetChanged,

            SS_TargetMoved,

            SS_Target,

            SS_NoTarget,

            SS_Arrived,

            SS_Unreachable,

            SS_Blocked,

            SS_Immobilized,

            SS_OutOfHabitat,

            SS_OutOfChaseRange,

            SS_NoReachableEnemy,

            SS_NoUnreachableEnemy,

            SS_ReachableEnemy,

            SS_Emote,

            SS_Chat,

            SS_Trigger,

            SS_Untrigger,

            SS_NegativeEffect,

            SS_PositiveEffect,

            SS_OwnerNegativeEffect,

            SS_OwnerPositiveEffect,

            SS_OwnerAggression,

            SS__MachineSignals,

            SS_MetaControllerIdle,

            SS_MetaControllerAlert,

            SS_MetaControllerAggro,

            SS_MetaControllerReturn,

            SS_MetaControllerFlee,

            SS_MetaControllerFollow,

            SS_MetaControllerPatrol,

            SS_MetaControllerConversation,

            SS_Bored,

            SS_Hungry,

            SS_Sleepy,

            SS_Aggro,

            SS_Fear,

            SS_Desolate,
        }

        public enum EStateResult
        {
            SR_Available,

            SR_Scheduled,

            SR_Active,

            SR_Succeeded,

            SR_Failed,

            SR_Aborted,

            SR_Error,
        }
    }
}
/*
native function Initialize(Game_AIController aController,AIState aParent);
*/