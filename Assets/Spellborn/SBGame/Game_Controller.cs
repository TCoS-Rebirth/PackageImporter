using System;
using System.Collections.Generic;
using Engine;
using SBBase;
using UnityEngine;

namespace SBGame
{
    [Serializable]
    public abstract class Game_Controller: Base_Controller
    {

        public Game_DebugUtils DebugUtils;
        public Game_Conversation ConversationControl;

        [NonSerialized, HideInInspector]
        public EControllerStates mCurrentState;

        [NonSerialized, HideInInspector]
        public List<Game_Hook> mContentHooks = new List<Game_Hook>();

        [NonSerialized, HideInInspector]
        public Vector mTargetDestination;

        [NonSerialized, HideInInspector]
        public Vector mTargetFocus;

        [NonSerialized, HideInInspector]
        public Rotator mTargetRotation;

        [NonSerialized, HideInInspector]
        public float mMaxDistanceToTarget;

        [NonSerialized, HideInInspector]
        public float mMaxTimeToMove;

        [NonSerialized, HideInInspector]
        public float mMoveSpeed;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool mReachedTarget;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float mStateTimer;

        [NonSerialized, HideInInspector]
        public DB_Character DBCharacter;

        [NonSerialized, HideInInspector]
        public DB_CharacterSheet DBCharacterSheet;

        [NonSerialized, HideInInspector]
        public List<int> DBCharacterSkills = new List<int>();

        [NonSerialized, HideInInspector]
        public List<DBSkillToken> DBSkillTokens = new List<DBSkillToken>();

        [NonSerialized, HideInInspector]
        public List<DB_SkillDeck> DBSkilldecks = new List<DB_SkillDeck>();

        [NonSerialized, HideInInspector]
        public List<DB_Item> DBItems = new List<DB_Item>();

        [NonSerialized, HideInInspector]
        public int DBPersistentVariables;

        UnrealScriptState<Game_Controller> ActiveState = new Auto_Controller_PawnAlive();

        [Serializable]
        public struct DBSkillToken: IPacketWritable
        {
            public int SkillID;
            public int TokenSlots;

            public void Write(IPacketWriter writer)
            {
                writer.WriteInt32(SkillID);
                writer.WriteByte((byte)TokenSlots);
            }
        }

        public enum EControllerStates
        {
            CPS_PAWN_NONE = 0,
            CPS_PAWN_ALIVE = 1,
            CPS_PAWN_DEAD = 2,
            CPS_AI_ALERT = 3,
            CPS_AI_AGGRO = 4,
            CPS_AI_FOLLOW = 5,
            CPS_AI_IDLE = 6,
            CPS_AI_REGROUP = 7,
            CPS_MOVE_PAWN = 8,
            CPS_ROTATE_PAWN = 9,
            CPS_PAWN_SITTING = 10,
            CPS_PAWN_FROZEN = 11,
        }

        public override void Initialize()
        {
            base.Initialize();
            if (DebugUtils != null) DebugUtils.Initialize(this);
            if (ConversationControl != null) ConversationControl.Initialize(this);
        }

        protected override void GotoState(string state)
        {
            if (state == "Auto" || state == "PawnAlive")
            {
                if (ActiveState != null) ActiveState.EndState(this);
                ActiveState = new Auto_Controller_PawnAlive();
            }
            else if (state == "PawnDead")
            {
                if (ActiveState != null) ActiveState.EndState(this);
                ActiveState = new Controller_PawnDead();
            }
            if (ActiveState != null) ActiveState.BeginState(this);
        }

        public virtual void SBGotoState(EControllerStates aState)
        {
            if (aState != mCurrentState)
            {
                switch (aState)
                {
                    case (EControllerStates)1:
                        mCurrentState = aState;
                        GotoState("PawnAlive");
                        break;
                    case (EControllerStates)2:
                        mCurrentState = aState;
                        GotoState("PawnDead");
                        break;
                    case (EControllerStates)10:
                        mCurrentState = aState;
                        GotoState("PawnSitting");
                        break;
                    case (EControllerStates)11:
                        mCurrentState = aState;
                        GotoState("PawnFrozen");
                        break;
                }
            }
        }

        public void sv_FireHook(Content_Type.EContentHook aHookType, object aObjParam, int aNumParam)
        {
            int hookI;
            Game_Hook prevHook;
            Game_PlayerPawn playerPawn;
            hookI = 0;
            while (hookI < mContentHooks.Count)
            {
                if (mContentHooks[hookI].HookType == aHookType)
                {
                    mContentHooks[hookI].Fire = true;
                }
                else
                {
                    mContentHooks[hookI].Fire = false;
                }
                hookI++;
            }
            playerPawn = (Game_PlayerPawn)Pawn;
            hookI = 0;
            while (hookI < mContentHooks.Count)
            {
                if (mContentHooks[hookI].Fire)
                {
                    mContentHooks[hookI].Fire = false;
                    prevHook = mContentHooks[hookI];
                    if (playerPawn != null)
                    {
                        mContentHooks[hookI].Owner.sv_OnHook(playerPawn, aHookType, aObjParam, aNumParam);
                    }
                    if (hookI >= mContentHooks.Count)
                    {
                        break;
                    }
                    if (mContentHooks[hookI] != prevHook)
                    {
                        hookI--;
                    }
                }
                hookI++;
            }
            hookI = 0;
            while (hookI < mContentHooks.Count)
            {
                if (mContentHooks[hookI].Fire)
                {
                }
                else hookI++;
            }
        }

        public void sv_SetPersistentVariable(int ContextID, int VariableID, int Value)
        {
            if (DBCharacter != null && DBCharacter.Id > 0)
            {
                if (sv_GetPersistentVariable(ContextID, VariableID) == Value)
                {
                    return;
                }
                sv_SetPersistentVariableNative(ContextID, VariableID, Value);
                SBDBAsync.SetPersistentPlayerVariable(Pawn, DBCharacter.Id, ContextID, VariableID, Value);
            }
        }

        int sv_GetPersistentVariable(int ContextID, int VariableID)
        {
            throw new NotImplementedException();
        }

        void sv_SetPersistentVariableNative(int ContextID, int VariableID, int Value)
        {
            throw new NotImplementedException();
        }

    }
}
/*
protected native function cl2sv_SetPersistentVariable_CallStub();
private native event cl2sv_SetPersistentVariable(int VariableID,int Value);
protected native function sv2cl_SetPersistentVariable_CallStub();
private native event sv2cl_SetPersistentVariable(int ContextID,int VariableID,int Value);
function sv_PetCallBack();
function sv_PetAttack(Game_Pawn Target);
function byte sv_GetPetAttackState();
function byte sv_GetPetMoveState();
function sv_SetPetAttackState(byte aAttackState);
function sv_SetPetMoveState(byte aMoveState);
function sv_SetPetOwner(Game_Pawn aPetOwner);
function bool ShouldLoot(Actor aLootOwner) {
return True;                                                                
}
function GetLootTables(Actor aOwner,out array<LootTable> aResultTables) {
}
final native event RotateToFace(float aDeltaTime);
native function Rotator GetFocusOrientation();
native function bool FacingTarget();
protected native function cl2sv_ForwardCancelState_CallStub();
event cl2sv_ForwardCancelState() {
SBGotoState(1);                                                             
}
event bool IsBeingRotated() {
return mCurrentState == 9;                                                  
}
event bool IsBeingMoved() {
return mCurrentState == 8;                                                  
}
event bool IsSitting() {
return mCurrentState == 10;                                                 
}
native function bool IsDespawned();
native function bool IsDead();
event bool IsIdle() {
return mCurrentState == 1;                                                  
}
final native function bool CanSeePawn(Game_Pawn aOther);
final native function sv_RemoveHooks(export editinline Content_Type aOwner);
event bool sv_OnAttack(Game_Pawn aPawn,export editinline FSkill_EffectClass aEffect,bool WasNegativeEffect,float aValue) {
return False;                                                               
}
event sv_OnOwnerAttack(bool WasNegativeEffect);
event sv_OnOwnerAggression();
event sv_OnSkillTarget(Game_Pawn aInstigator,export editinline FSkill_Type aType);
event bool sv_OnDamage(Game_Pawn aEnemy,int aDamage) {
return False;                                                               
}
event cl_OnShutdown() {
if (DebugUtils != None) {                                                   
DebugUtils.cl_OnShutdown();                                               
}
if (TextParser != None) {                                                   
TextParser.cl_OnShutdown();                                               
}
if (ConversationControl != None) {                                          
ConversationControl.cl_OnShutdown();                                      
}
Super.cl_OnShutdown();                                                      
}
event cl_OnTick(float DeltaTime) {
Super.cl_OnTick(DeltaTime);                                                 
if (DebugUtils != None) {                                                   
DebugUtils.cl_OnTick(DeltaTime);                                          
}
}
event sv_OnShutdown() {
if (DebugUtils != None) {                                                   
DebugUtils.sv_OnShutdown();                                               
}
if (TextParser != None) {                                                   
TextParser.sv_OnShutdown();                                               
}
if (ConversationControl != None) {                                          
ConversationControl.sv_OnShutdown();                                      
}
Super.sv_OnShutdown();                                                      
}
state PawnFrozen {
event cl_OnPlayerTick(float DeltaTime) {
}
function EndState() {
local Game_Pawn gp;
gp = Game_Pawn(Pawn);                                                   
if (gp != None) {                                                       
gp.CharacterStats.FreezeMovement(False);                              
gp.CharacterStats.FreezeRotation(False);                              
}
}
function BeginState() {
local Game_Pawn gp;
gp = Game_Pawn(Pawn);                                                   
if (gp != None) {                                                       
gp.CharacterStats.FreezeMovement(True);                               
gp.CharacterStats.FreezeRotation(True);                               
}
}
}
state PawnSitting {
function EndState() {
local Game_Pawn gp;
gp = Game_Pawn(Pawn);                                                   
if (gp != None) {                                                       
if (gp.CharacterStats != None) {                                      
gp.CharacterStats.UnsetStatsState(4);                               
if (IsServer()) {                                                   
if (gp.Physics == 19) {                                           
gp.CharacterStats.FreezeMovementTimed(2.00000000);              
} else {                                                          
gp.CharacterStats.FreezeMovementTimed(1.00000000);              
}
}
}
gp.StandUp();                                                         
}
}
function BeginState() {
local Game_Pawn gp;
mStateTimer = 0.00000000;                                               
Pawn.Velocity = vect(0.000000, 0.000000, 0.000000);                     
Pawn.Acceleration = Pawn.Velocity;                                      
gp = Game_Pawn(Pawn);                                                   
if (gp != None) {                                                       
if (gp.CharacterStats != None) {                                      
gp.CharacterStats.SetStatsState(4);                                 
}
if (IsServer()) {                                                     
if (gp.Physics == 19) {                                             
gp.CharacterStats.FreezeMovementTimed(2.00000000);                
} else {                                                            
gp.CharacterStats.FreezeMovementTimed(1.00000000);                
}
}
}
}
}
state PawnDead {
function BeginState() {
SBGotoState(2);                                                         
Game_Pawn(Pawn).StopMoving();                                           
}
}
state PawnAlive {
function BeginState() {
SBGotoState(1);                                                         
}
}
*/
