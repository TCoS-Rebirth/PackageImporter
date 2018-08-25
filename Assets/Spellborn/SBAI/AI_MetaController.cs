﻿using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBAI
{
    [Serializable] public class AI_MetaController : NPC_AI
    {
        [FoldoutGroup("AI_MetaController")]
        public int Priority;

        [FoldoutGroup("AI_MetaController")]
        public bool mRequiresClone;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public AI_MetaController Parent;

        public ControllerMessageFilter mControllerMessageFilter;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int mControllerMessageMask1;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int mControllerMessageMask2;

        public AI_MetaController()
        {
        }

        [Serializable] public struct ControllerMessageFilter
        {
            public bool OnSpawn;

            public bool OnBegin;

            public bool OnDespawn;

            public bool OnEnd;

            public bool OnBeginScript;

            public bool OnEndScript;

            public bool OnDamage;

            public bool OnBuff;

            public bool OnDebuff;

            public bool OnStateBegin;

            public bool OnStateChange;

            public bool OnStateComplete;

            public bool OnStateSignal;

            public bool OnDeath;

            public bool OnTick;

            public bool OnInteraction;

            public bool OnTimerEnded;

            public bool OnTrigger;

            public bool OnDetectEnemy;

            public bool OnEnemyLost;

            public bool OnDetectAlly;

            public bool OnAllyLost;

            public bool OnHomeLocation;

            public bool OnCheckChaseRange;

            public bool OnCheckHabitat;

            public bool OnEndConversation;

            public bool OnCheckEnemy;

            public bool OnCheckFriendly;

            public bool OnCheckAlly;

            public bool OnAggro;

            public bool OnKill;

            public bool OnArrived;

            public bool OnUnreachable;

            public bool OnPause;

            public bool OnContinue;

            public bool OnWeaponSwapped;

            public bool OnSkillFinished;

            public bool OnAnimationDone;

            public bool OnPhysicsChange;

            public bool OnCheckInvisibility;
        }

        public enum ControllerMessages
        {
            CM_OnSpawn,

            CM_OnBegin,

            CM_OnDespawn,

            CM_OnEnd,

            CM_OnBeginScript,

            CM_OnEndScript,

            CM_OnDamage,

            CM_OnBuff,

            CM_OnDebuff,

            CM_OnStateBegin,

            CM_OnStateChange,

            CM_OnStateEnded,

            CM_OnStateSignal,

            CM_OnDeath,

            CM_OnTick,

            CM_OnInteraction,

            CM_OnTimerEnded,

            CM_OnTrigger,

            CM_OnDetectEnemy,

            CM_OnEnemyLost,

            CM_OnDetectAlly,

            CM_OnAllyLost,

            CM_OnHomeLocation,

            CM_OnCheckChaseRange,

            CM_OnCheckHabitat,

            CM_OnEndConversation,

            CM_CheckEnemy,

            CM_CheckFriendly,

            CM_CheckAlly,

            CM_OnAggro,

            CM_OnKill,

            CM_OnArrived,

            CM_OnUnreachable,

            CM_OnPause,

            CM_OnContinue,

            CM_OnWeaponSwapped,

            CM_OnSkillFinished,

            CM_OnAnimationDone,

            CM_OnPhysicsChange,

            CM_OnCheckInvisibility,
        }
    }
}
/*
event bool OnCheckInvisibility(Game_AIController aController,Game_Pawn aPawn) {
return False;                                                               
}
event bool OnPhysicsChange(Game_AIController aController,byte aNewPhysics) {
return False;                                                               
}
event bool OnAnimationDone(Game_AIController aController,name aAnimation) {
return False;                                                               
}
event bool OnSkillFinished(Game_AIController aController,export editinline FSkill_Type aSkill) {
return False;                                                               
}
event bool OnWeaponSwapped(Game_AIController aController,byte aMode) {
return False;                                                               
}
event bool OnContinue(Game_AIController aController) {
return False;                                                               
}
event bool OnPause(Game_AIController aController) {
return False;                                                               
}
event bool OnUnreachable(Game_AIController aController,SBPoint aControlPoint,Vector aDestination) {
return False;                                                               
}
event bool OnArrived(Game_AIController aController,SBPoint aControlPoint,SBPoint aDestinationPoint,Vector aDestination) {
return False;                                                               
}
event bool OnKill(Game_AIController aController,Actor aVictim) {
return False;                                                               
}
event bool OnCheckAlly(Game_AIController aController,Game_Pawn potentialAlly) {
return False;                                                               
}
event bool OnCheckFriendly(Game_AIController aController,Game_Pawn potentialFriend) {
return False;                                                               
}
event bool OnCheckEnemy(Game_AIController aController,Game_Pawn potentialEnemy) {
return False;                                                               
}
event bool OnTick(Game_AIController aController,float aDeltaTime) {
return False;                                                               
}
event bool OnDeath(Game_AIController aController,Actor aDeceasedActor) {
return False;                                                               
}
event bool OnTimerEnded(Game_AIController aController,Actor aInstigator,name aTag) {
return False;                                                               
}
event bool OnEndConversation(Game_AIController aController,Actor partner) {
return False;                                                               
}
event bool OnCheckHabitat(Game_AIController aController,Vector aLocation,NPC_Habitat aHabitat) {
return False;                                                               
}
event bool OnCheckChaseRange(Game_AIController aController,Vector aLocation,float aRange) {
return False;                                                               
}
event bool OnHomeLocation(Game_AIController aController,Vector aLocation) {
return False;                                                               
}
event bool OnStateSignal(Game_AIController aController,AIState aState,byte aSignal) {
return False;                                                               
}
event bool OnStateChange(Game_AIController aController,AIState aState) {
return False;                                                               
}
event bool OnStateBegin(Game_AIController aController,AIState aState) {
return False;                                                               
}
event bool OnStateComplete(Game_AIController aController,AIState aState,byte aResult) {
return False;                                                               
}
event bool OnAllyLost(Game_AIController anObserver,Game_Pawn anAlly) {
return False;                                                               
}
event bool OnDetectAlly(Game_AIController anObserver,Game_Pawn anAlly) {
return False;                                                               
}
event bool OnEnemyLost(Game_AIController anObserver,Game_Pawn anEnemy) {
return False;                                                               
}
event bool OnDetectEnemy(Game_AIController anObserver,Game_Pawn anEnemy) {
return False;                                                               
}
event bool OnTrigger(Game_AIController receiver,Actor anActor,Pawn Instigator) {
return False;                                                               
}
event bool OnDebuff(Game_AIController Victim,Game_Pawn Instigator,export editinline FSkill_EffectClass effect,float aValue) {
return False;                                                               
}
event bool OnBuff(Game_AIController Victim,Game_Pawn Instigator,export editinline FSkill_EffectClass effect,float aValue) {
return False;                                                               
}
event bool OnDamage(Game_AIController Victim,Actor cause,float Damage) {
return False;                                                               
}
event OnEndScript(Game_AIController aController,AI_Script aScriptInstance) {
}
event OnBeginScript(Game_AIController aController,AI_Script aScriptInstance) {
}
event OnEnd(Game_AIController aController) {
}
event OnDespawn(Game_AIController aController) {
}
event OnBegin(Game_AIController aController) {
}
event bool OnSpawn(Game_AIController aSpawn,export editinline NPC_Type aType,Vector aLocation) {
return False;                                                               
}
function NPC_Taxonomy GetFaction() {
return None;                                                                
}
*/