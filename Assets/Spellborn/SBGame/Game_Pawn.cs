﻿using System;
using System.Collections.Generic;
using Engine;
using SBBase;
using UnityEngine;

namespace SBGame
{
    [Serializable]
    public class Game_Pawn: Base_Pawn
    {

        public Game_ShiftableAppearance Appearance;
        public Game_Appearance BaseAppearance;
        public Game_BodySlots BodySlots;
        public Game_Character Character;
        public Game_CharacterStats CharacterStats;
        public Game_ItemManager itemManager;
        public Game_CombatState combatState;
        public Game_CombatStats CombatStats;
        public Game_Effects Effects;
        public Game_Emotes Emotes;
        public Game_Looting Looting;
        public Game_Skills Skills;
        public Game_Trading Trading;
        public Game_MiniGameProxy MiniGameProxy;

        public EPawnStates mCurrentState;
        public EPawnStates mNetState;

        [NonSerialized, HideInInspector]
        public bool bInvulnerable;

        [NonSerialized, HideInInspector]
        public float ForwardSpeedModifier;

        [NonSerialized, HideInInspector]
        public float SideSpeedModifier;

        [NonSerialized, HideInInspector]
        public float BackwardSpeedModifier;

        [NonSerialized, HideInInspector]
        public float GroundSpeedModifier = 1f;

        [NonSerialized, HideInInspector]
        public float mInteractionRange;

        [NonSerialized, HideInInspector]
        public bool mIsInteracting;

        [NonSerialized, HideInInspector]
        public int mDebugFilters;

        [NonSerialized, HideInInspector]
        public Vector mDesiredLocation;

        [NonSerialized, HideInInspector]
        public Actor mTargetActor;

        [NonSerialized, HideInInspector]
        public List<NameProperty> InteractionTags = new List<NameProperty>();

        [NonSerialized, HideInInspector]
        public float SkillRadius;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Game_PetPawn Pet;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool HasPet;

        protected UnrealScriptState<Game_Pawn> ActiveState = new Auto_Pawn_PawnAlive();

        #region enums
        public enum EPetAttackState
        {
            PAS_Aggressive = 0,

            PAS_Defensive = 1,

            PAS_Assist = 2,

            PAS_Passive = 3,

            PAS_MAX = 4,
        }

        public enum EPetMoveState
        {
            PMS_Stay = 0,

            PMS_FollowOwner = 1,

            PMS_MAX = 2,
        }

        public enum ELateralMove
        {
            ELM_None = 0,

            ELM_Left = 1,

            ELM_Right = 2,
        }

        public enum EParallelMove
        {
            EPM_None = 0,

            EPM_Forwards = 1,

            EPM_Backwards = 2,
        }

        public enum EDebugDrawFilters
        {
            EDD_Position = 0,

            EDD_Location = 1,

            EDD_Cell = 2,

            EDD_Move = 3,

            EDD_Path = 4,

            EDD_Target = 5,

            EDD_Tactical = 6,

            EDD_Relevant = 7,

            EDD_History = 8,

            EDD_Skill = 9,

            EDD_Threat = 10,

            EDD_Astar = 11,

            EDD_Max = 12,
        }

        public enum EPawnEffectType
        {
            EPET_LevelUp = 0,

            EPET_RankUp = 1,

            EPET_QuestCompleted = 2,

            EPET_FadeIn = 3,

            EPET_FadeOut = 4,

            EPET_Visible = 5,

            EPET_Invisible = 6,

            EPET_PetSpawn = 7,

            EPET_PetDestroy = 8,

            EPET_ShapeShift = 9,

            EPET_ShapeUnshift = 10,

            EPET_ArenaTeam0 = 11,

            EPET_ArenaTeam1 = 12,

            EPET_SimpleCameraShake = 13,
        }

        public enum EPawnStates
        {
            PS_NONE = 0,

            PS_ALIVE = 1,

            PS_DEAD = 2,
        }
        #endregion

        protected override void GotoState(string state)
        {
            if (state == "Alive" || state == "Auto")
            {
                ActiveState = new Auto_Pawn_PawnAlive();
            }
            else if (state == "Dead")
            {
                ActiveState = new Pawn_PawnDead();
            }
            if (ActiveState != null) ActiveState.BeginState(this);
        }

        public EPawnStates GetState()
        {
            return mCurrentState;
        }

        public virtual void SBGotoState(EPawnStates aState)
        {
            if (aState != mCurrentState)
            {
                switch (aState)
                {
                    case (EPawnStates)1:
                        GotoState("Alive");
                        break;
                    case (EPawnStates)2:
                        GotoState("Dead");
                        break;
                }
            }
        }

        public override void Initialize()
        {
            base.Initialize();
            SetInitialState();
            if (Appearance != null) Appearance.Initialize(this);
            if (CharacterStats != null) CharacterStats.Initialize(this);
            if (Character != null) Character.Initialize(this);
            if (combatState != null) combatState.Initialize(this);
            if (Skills != null) Skills.Initialize(this);
            if (Effects != null) Effects.Initialize(this);
            if (MiniGameProxy != null) MiniGameProxy.Initialize(this);
            if (itemManager != null) itemManager.Initialize(this);
            if (BodySlots != null) BodySlots.Initialize(this);
            if (CombatStats != null) CombatStats.Initialize(this);
            if (Emotes != null) Emotes.Initialize(this);
            if (Looting != null) Looting.Initialize(this);
            if (Trading != null) Trading.Initialize(this);
            var gpa = BaseAppearance as Game_PlayerAppearance;
            if (gpa != null)
            {
                var pc = (Game_PlayerController)Controller;
                gpa.SetBaseAppearance(pc.DBCharacter.AppearancePart1, pc.DBCharacter.AppearancePart2);
                gpa.RepackLodDataAll();
            }
            if (Appearance != null) Appearance.DressUp();
        }

        public bool IsPlayerPawn()
        {
            return this is Game_PlayerPawn;
        }

        public void sv2clrel_UpdateNetState_CallStub(EPawnStates netState/*added*/) { throw new NotImplementedException(); }

        public void StopMoving()
        {
            Velocity = new Vector(0, 0, 0);
        }

        public void sv_DestroyPet(bool IsUserControlledAction)
        {
            if (HasPet)
            {
                HasPet = false;
                ((Game_NPCController)Pet.Controller).sv_Despawn();
                sv2clrel_RemovePet_CallStub();
                if (BodySlots != null && CharacterStats != null && CharacterStats.GetCharacterClass() == (Content_API.EContentClass)12)
                {
                    BodySlots.sv_SetMode((Game_BodySlots.EBodySlotMode)1);
                }
            }
        }

        void sv2clrel_RemovePet_CallStub() { throw new NotImplementedException(); }

        public virtual int GetCharacterID()
        {
            return 0;
        }

        public void sv2rel_CombatMessageDeath_CallStub(Game_Pawn aKiller, Game_Pawn aTarget /*added*/) { throw new NotImplementedException(); }
        //public void sv2rel_CombatMessageDeath(Game_Pawn aKiller, Game_Pawn aTarget)
        //{
        //    if (aKiller != null && aKiller.IsLocalPlayer())
        //    {
        //        cl_CombatLogMessage(/*Class'StringReferences'.default.EffectYouText.Text*/, /*Class'StringReferences'.default.CombatSlainText.Text*/, 0, 0, aKiller, aTarget);
        //    }
        //    else
        //    {
        //        cl_CombatLogMessage(/*Class'StringReferences'.default.EffectSourceText.Text*/, /*Class'StringReferences'.default.CombatSlainSourceText.Text*/, 0, 0, aKiller, aTarget);
        //    }
        //}

        #region func
        public void cl_PlayPawnEffect(EPawnEffectType aPET)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
/*
protected native function sv2cl_Unshifted_CallStub();
event sv2cl_Unshifted() {
ShiftStateChanged.Trigger();                                                
}
protected native function sv2cl_Shifted_CallStub();
event sv2cl_Shifted() {
ShiftStateChanged.Trigger();                                                
}
protected native function sv2cl_Shifting_CallStub();
event sv2cl_Shifting() {
if (IsInShop()) {                                                           
Game_PlayerController(Controller).GUI.HideShop();                         
}
}
protected native function cl2sv_Unshift_CallStub();
event cl2sv_Unshift() {
Unshift();                                                                  
}
native function NPC_Type GetShiftedNPCType();
native function bool Unshift();
native function bool Shift(export editinline NPC_Type aType);
native function bool IsShifted();
event bool IsInShop() {
if (Trading != None) {                                                      
return Trading.IsShopping();                                              
}
return False;                                                               
}
native function bool sv_IsVisibleInRelevance();
native function sv_SetVisibleInRelevance(bool aVisible);
event bool IsInvisible() {
return mInvisible;                                                          
}
function cl_SetInvisble(bool aInvisibleFlag,bool aUseFade) {
mInvisible = aInvisibleFlag;                                                
if (aInvisibleFlag) {                                                       
if (aUseFade) {                                                           
cl_PlayPawnEffect(4);                                                   
} else {                                                                  
cl_PlayPawnEffect(6);                                                   
}
} else {                                                                    
if (aUseFade) {                                                           
cl_PlayPawnEffect(3);                                                   
} else {                                                                  
cl_PlayPawnEffect(5);                                                   
}
}
}
protected native function sv2clrel_SetInvisible_CallStub();
event sv2clrel_SetInvisible(bool aInvisibleFlag) {
if (mInvisible != aInvisibleFlag) {                                         
cl_SetInvisble(aInvisibleFlag,mUseFadeInFadeOut);                         
}
}
function sv_SetInvisible(bool aInvisibleFlag) {
if (aInvisibleFlag != mInvisible) {                                         
mInvisible = aInvisibleFlag;                                              
sv2clrel_SetInvisible_CallStub(aInvisibleFlag);                           
}
}
final event Game_PetPawn GetPet() {
return Pet;                                                                 
}
native function class<Game_NPCController> sv_GetPetControllerClass();
event sv2clrel_RemovePet() {
cl_SetPet(None);                                                            
}
function cl_SetPet(Game_PetPawn aPET) {
if (HasPet && aPET == None) {                                               
Pet.cl_PlayPawnEffect(8);                                                 
HasPet = False;                                                           
}
Pet = aPET;                                                                 
if (!HasPet && Pet != None) {                                               
Pet.PetOwner = self;                                                      
Pet.cl_PlayPawnEffect(7);                                                 
PetSummoned.Trigger();                                                    
HasPet = True;                                                            
}
}
final event sv_SpawnPet(export editinline NPC_Type aType,byte aDefaultMoveState,byte aDefaultAttackState,bool IsUserControlledAction) {
local Game_NPCController PC;
local Vector SpawnLocation;
local Vector Extent;
sv_DestroyPet(True);                                                        
if (IsGrounded()) {                                                         
Extent.X = aType.GetCollisionRadius();                                    
Extent.Y = Extent.X;                                                      
Extent.Z = aType.GetCollisionHeight();                                    
SpawnLocation = Class'Content_API'.NearestValidLocation(self,Location,Extent,True);
if (SpawnLocation == vect(0.000000, 0.000000, 0.000000)
|| VSize(SpawnLocation - Location) > 500.00000000) {
sv2cl_AddScrollingCombatMessage_CallStub(Class'StringReferences'.default.Pet_Spawn_Failed.Id,Class'FSkill_Enums'.16);
return;                                                                 
}
SpawnLocation.Z += 0.50000000;                                            
PC = Spawn(sv_GetPetControllerClass(),Controller,'None',SpawnLocation,Rotation);
PC.sv_SetPetOwner(self);                                                  
PC.NPCType = aType;                                                       
PC.sv_OnSpawn(CharacterStats.mRecord.FameLevel,aType.PePRank,Character.GetFaction());
if (PC.Pawn != None) {                                                    
Pet = Game_PetPawn(PC.Pawn);                                            
Pet.PetOwner = self;                                                    
Pet.sv2clrel_SetPetOwner_CallStub(self);                                
PC.sv_InitInternal();                                                   
PC.sv_SetPetMoveState(aDefaultMoveState);                               
PC.sv_SetPetAttackState(aDefaultAttackState);                           
if (Pet != None) {                                                      
HasPet = True;                                                        
if (IsUserControlledAction) {                                         
if (ClassIsChildOf(Class,Class'Game_PlayerPawn')) {                 
if (BodySlots.GetMode() == 1) {                                   
BodySlots.sv_SetMode(2);                                        
}
goto jl0246;                                                      
}
goto jl0249;                                                        
}
goto jl024C;                                                          
}
} else {                                                                  
PC.Destroy();                                                           
}
}
if (Pet == None) {                                                          
sv2cl_AddScrollingCombatMessage_CallStub(Class'StringReferences'.default.Pet_Spawn_Failed.Id,Class'FSkill_Enums'.16);
}
}
native function DebugText(byte aFilter,Vector aLocation,string aText,Color aColor);
native function DebugDisc(byte aFilter,Vector aCenter,float aSize,Color aColor);
native function DebugCircle(byte aFilter,Vector aCenter,float aSize,Color aColor,optional int aWidth);
native function DebugBox(byte aFilter,Vector aLocation,Vector aSize,Color aColor);
native function DebugRectangle(byte aFilter,Vector aLocation,Vector aSize,Color aColor,optional int aWidth);
native function DebugLine(byte aFilter,Vector aFrom,Vector aTo,Color aColor,optional int aWidth);
function AddDebugDrawFilter(string aFilter) {
local int di;
local name enumname;
local int Flag;
if (aFilter == "none" || aFilter == "off") {                                
mDebugFilters = 0;                                                        
} else {                                                                    
if (aFilter == "default" || aFilter == "") {                              
mDebugFilters = Class.default.mDebugFilters;                            
} else {                                                                  
di = 0;                                                                 
while (di < 32) {                                                       
enumname = static.GetEnum(Enum'EDebugDrawFilters',di);                
if (enumname == 'None') {                                             
} else {                                                              
if (Caps(string(enumname)) == Caps("EDD_" $ aFilter)) {             
Flag = 1 << di;                                                   
if ((mDebugFilters & Flag) == 0) {                                
mDebugFilters = mDebugFilters | Flag;                           
} else {                                                          
mDebugFilters = mDebugFilters & ~Flag;                          
}
return;                                                           
}
}
di++;                                                                 
}
}
}
}
protected native function sv2cl_CombatMessageOutputEvade_CallStub();
event sv2cl_CombatMessageOutputEvade(int aSkillResourceID,int aEffectResourceID,Game_Pawn aTarget) {
local export editinline FSkill_Type Skill;
local export editinline FSkill_EffectClass effect;
Skill = FSkill_Type(Class'SBDBSync'.GetResourceObject(aSkillResourceID));   
effect = FSkill_EffectClass(Class'SBDBSync'.GetResourceObject(aEffectResourceID));
effect.cl_CombatLogMessage(Class'StringReferences'.default.EffectTargetText.Text,Class'StringReferences'.default.CombatOutputEvadeText.Text,Skill,None,self,aTarget,0,0,0);
if (aTarget != None) {                                                      
aTarget.cl_AddScrollingCombatMessage(Class'StringReferences'.default.CombatEvadeText.Text,Class'FSkill_Enums'.14);
}
}
protected native function sv2cl_CombatMessageOutputImmune_CallStub();
event sv2cl_CombatMessageOutputImmune(int aSkillResourceID,int aEffectResourceID,Game_Pawn aTarget) {
local export editinline FSkill_Type Skill;
local export editinline FSkill_EffectClass effect;
Skill = FSkill_Type(Class'SBDBSync'.GetResourceObject(aSkillResourceID));   
effect = FSkill_EffectClass(Class'SBDBSync'.GetResourceObject(aEffectResourceID));
effect.cl_CombatLogMessage(Class'StringReferences'.default.EffectTargetText.Text,Class'StringReferences'.default.CombatOutputImmuneText.Text,Skill,None,self,aTarget,0,0,0);
if (aTarget != None) {                                                      
aTarget.cl_AddScrollingCombatMessage(Class'StringReferences'.default.CombatImmuneText.Text,Class'FSkill_Enums'.14);
}
}
event cl_CombatMessageUnableToExecute(int aSkillResourceID) {
cl_CombatLogMessage(Class'StringReferences'.default.EffectSourceText.Text,Class'StringReferences'.default.CombatUnableToExecuteText.Text,aSkillResourceID,0,self,None);
}
protected native function sv2cl_CombatMessageInputDuffUnApply_CallStub();
event sv2cl_CombatMessageInputDuffUnApply(int aDuffResourceID) {
cl_CombatLogMessage(Class'StringReferences'.default.EffectTargetText.Text,Class'StringReferences'.default.CombatInputDuffUnApplyText.Text,0,aDuffResourceID,None,self);
}
protected native function sv2cl_CombatMessageInputDuffApply_CallStub();
event sv2cl_CombatMessageInputDuffApply(int aDuffResourceID,Game_Pawn aSource) {
local export editinline FSkill_Event_Duff duffEvent;
duffEvent = FSkill_Event_Duff(Class'SBDBSync'.GetResourceObject(aDuffResourceID));
cl_CombatLogMessage(Class'StringReferences'.default.EffectSourceText.Text,Class'StringReferences'.default.CombatInputDuffApplyText.Text,0,aDuffResourceID,aSource,None);
self.cl_AddScrollingCombatMessage(duffEvent.GetName(),Class'FSkill_Enums'.11);
}
protected native function sv2cl_CombatMessageOutputDuffApply_CallStub();
event sv2cl_CombatMessageOutputDuffApply(int aDuffResourceID,Game_Pawn aTarget) {
local export editinline FSkill_Event_Duff duffEvent;
duffEvent = FSkill_Event_Duff(Class'SBDBSync'.GetResourceObject(aDuffResourceID));
cl_CombatLogMessage(Class'StringReferences'.default.EffectSourceText.Text,Class'StringReferences'.default.CombatOutputduffApplySourceText.Text,0,aDuffResourceID,self,aTarget);
aTarget.cl_AddScrollingCombatMessage(duffEvent.GetName(),Class'FSkill_Enums'.12);
}
protected native function sv2cl_CombatMessageOutputDrainNonDamage_CallStub();
private event sv2cl_CombatMessageOutputDrainNonDamage(int aDuffOrSkillResourceID,Game_Pawn aTarget,int aAmount,int aGainedAmount,int aEffectResourceID) {
cl_CombatMessage(aDuffOrSkillResourceID,aDuffOrSkillResourceID,aEffectResourceID,self,aTarget,aAmount,0,aGainedAmount);
}
protected native function sv2cl_CombatMessageInputDrainNonDamage_CallStub();
private event sv2cl_CombatMessageInputDrainNonDamage(int aDuffOrSkillResourceID,Game_Pawn aSource,int aAmount,int aGainedAmount,int aEffectResourceID) {
cl_CombatMessage(aDuffOrSkillResourceID,aDuffOrSkillResourceID,aEffectResourceID,aSource,self,aAmount,0,aGainedAmount);
}
protected native function sv2cl_CombatMessageOutputDrainDamage_CallStub();
private event sv2cl_CombatMessageOutputDrainDamage(int aDuffOrSkillResourceID,Game_Pawn aTarget,int aAmount,int aResistedAmount,int aGainedAmount,int aEffectResourceID) {
cl_CombatMessage(aDuffOrSkillResourceID,aDuffOrSkillResourceID,aEffectResourceID,self,aTarget,aAmount,aResistedAmount,aGainedAmount);
}
protected native function sv2cl_CombatMessageInputDrainDamage_CallStub();
private event sv2cl_CombatMessageInputDrainDamage(int aDuffOrSkillResourceID,Game_Pawn aSource,int aAmount,int aResistedAmount,int aGainedAmount,int aEffectResourceID) {
cl_CombatMessage(aDuffOrSkillResourceID,aDuffOrSkillResourceID,aEffectResourceID,aSource,self,aAmount,aResistedAmount,aGainedAmount);
}
native event cl_CombatMessageTeleport(int aSkillResourceID,int aDuffResourceID,Game_Pawn aSource,Game_Pawn aTarget,int aAmount,int aAmount2,int aAmount3);
protected native function sv2cl_CombatMessageInputTeleport_CallStub();
event sv2cl_CombatMessageInputTeleport(Game_Pawn aSource) {
cl_CombatMessageTeleport(0,0,aSource,self,0,0,0);                           
}
native event cl_CombatMessageHeal(int aSkillResourceID,int aDuffResourceID,Game_Pawn aSource,Game_Pawn aTarget,int aAmount,int aAmount2,int aAmount3);
protected native function sv2cl_CombatMessageOutputHeal_CallStub();
private event sv2cl_CombatMessageOutputHeal(int aSkillResourceID,Game_Pawn aTarget,int aAmount) {
cl_CombatMessageHeal(aSkillResourceID,0,self,aTarget,aAmount,0,0);          
}
protected native function sv2cl_CombatMessageInputHeal_CallStub();
private event sv2cl_CombatMessageInputHeal(int aSkillResourceID,Game_Pawn aSource,int aAmount) {
cl_CombatMessageHeal(aSkillResourceID,0,aSource,self,aAmount,0,0);          
}
protected native function sv2cl_CombatMessageInputHealOverTime_CallStub();
private event sv2cl_CombatMessageInputHealOverTime(int aDuffResourceID,int aAmount) {
cl_CombatMessageHeal(0,aDuffResourceID,self,self,aAmount,0,0);              
}
protected native function sv2cl_CombatMessageOutputState_CallStub();
private event sv2cl_CombatMessageOutputState(int aSkillResourceID,Game_Pawn aTarget,int aAmount,int aEffectResourceID) {
cl_CombatMessage(aSkillResourceID,0,aEffectResourceID,self,aTarget,aAmount,0,0);
}
protected native function sv2cl_CombatMessageInputState_CallStub();
private event sv2cl_CombatMessageInputState(int aSkillResourceID,Game_Pawn aSource,int aAmount,int aEffectResourceID) {
cl_CombatMessage(aSkillResourceID,0,aEffectResourceID,aSource,self,aAmount,0,0);
}
protected native function sv2cl_CombatMessageInputStateOverTime_CallStub();
private event sv2cl_CombatMessageInputStateOverTime(int aDuffResourceID,int aAmount,int aEffectResourceID) {
cl_CombatMessage(0,aDuffResourceID,aEffectResourceID,self,self,aAmount,0,0);
}
native event cl_CombatMessageDamage(int aSkillResourceID,int aDuffResourceID,Game_Pawn aSource,Game_Pawn aTarget,int aAmount,int aAmount2,int aAmount3);
protected native function sv2cl_CombatMessageOutputDamage_CallStub();
private event sv2cl_CombatMessageOutputDamage(int aSkillResourceID,Game_Pawn aTarget,int aAmount,int aResistedAmount) {
cl_CombatMessageDamage(aSkillResourceID,0,self,aTarget,aAmount,aResistedAmount,0);
}
protected native function sv2cl_CombatMessageInputDamage_CallStub();
private event sv2cl_CombatMessageInputDamage(int aSkillResourceID,Game_Pawn aSource,int aAmount,int aResistedAmount) {
cl_CombatMessageDamage(aSkillResourceID,0,aSource,self,aAmount,aResistedAmount,0);
}
protected native function sv2cl_CombatMessageInputDamageOverTime_CallStub();
private event sv2cl_CombatMessageInputDamageOverTime(int aSkillResourceID,int aDuffResourceID,int aAmount,int aResistedAmount) {
cl_CombatMessageDamage(aSkillResourceID,aDuffResourceID,self,self,aAmount,aResistedAmount,0);
}
protected native function sv2cl_CombatMessageInputShareNonDamage_CallStub();
private event sv2cl_CombatMessageInputShareNonDamage(int aSkillResourceID,int aDuffResourceID,int aEffectResourceID,Game_Pawn aSource,int aAmount,int aResistedAmount,int aRedirectedEffectType) {
cl_CombatMessage(aSkillResourceID,aDuffResourceID,aEffectResourceID,aSource,self,aAmount,aResistedAmount,aRedirectedEffectType);
}
protected native function sv2cl_CombatMessageOutputShareNonDamage_CallStub();
private event sv2cl_CombatMessageOutputShareNonDamage(int aSkillResourceID,int aDuffResourceID,int aEffectResourceID,Game_Pawn aTarget,int aAmount,int aResistedAmount,int aRedirectedEffectType) {
cl_CombatMessage(aSkillResourceID,aDuffResourceID,aEffectResourceID,self,aTarget,aAmount,aResistedAmount,aRedirectedEffectType);
}
protected native function sv2cl_CombatMessageInputShareDamage_CallStub();
private event sv2cl_CombatMessageInputShareDamage(int aSkillResourceID,int aDuffResourceID,int aEffectResourceID,Game_Pawn aSource,int aAmount,int aResistedAmount) {
cl_CombatMessage(aSkillResourceID,aDuffResourceID,aEffectResourceID,aSource,self,aAmount,aResistedAmount,0);
}
protected native function sv2cl_CombatMessageOutputShareDamage_CallStub();
private event sv2cl_CombatMessageOutputShareDamage(int aSkillResourceID,int aDuffResourceID,int aEffectResourceID,Game_Pawn aTarget,int aAmount,int aResistedAmount) {
cl_CombatMessage(aSkillResourceID,aDuffResourceID,aEffectResourceID,self,aTarget,aAmount,aResistedAmount,0);
}
protected native function sv2cl_CombatMessageInputReturnReflectNonDamage_CallStub();
private event sv2cl_CombatMessageInputReturnReflectNonDamage(int aSkillResourceID,int aDuffResourceID,int aEffectResourceID,Game_Pawn aSource,int aAmount,int aResistedAmount,int aRedirectedEffectType) {
cl_CombatMessage(aSkillResourceID,aDuffResourceID,aEffectResourceID,aSource,self,aAmount,aResistedAmount,aRedirectedEffectType);
}
protected native function sv2cl_CombatMessageOutputReturnReflectNonDamage_CallStub();
private event sv2cl_CombatMessageOutputReturnReflectNonDamage(int aSkillResourceID,int aDuffResourceID,int aEffectResourceID,Game_Pawn aTarget,int aAmount,int aResistedAmount,int aRedirectedEffectType) {
cl_CombatMessage(aSkillResourceID,aDuffResourceID,aEffectResourceID,self,aTarget,aAmount,aResistedAmount,aRedirectedEffectType);
}
protected native function sv2cl_CombatMessageInputReturnReflectDamage_CallStub();
private event sv2cl_CombatMessageInputReturnReflectDamage(int aSkillResourceID,int aDuffResourceID,int aEffectResourceID,Game_Pawn aSource,int aAmount,int aResistedAmount) {
cl_CombatMessage(aSkillResourceID,aDuffResourceID,aEffectResourceID,aSource,self,aAmount,aResistedAmount,0);
}
protected native function sv2cl_CombatMessageOutputReturnReflectDamage_CallStub();
private event sv2cl_CombatMessageOutputReturnReflectDamage(int aSkillResourceID,int aDuffResourceID,int aEffectResourceID,Game_Pawn aTarget,int aAmount,int aResistedAmount) {
cl_CombatMessage(aSkillResourceID,aDuffResourceID,aEffectResourceID,self,aTarget,aAmount,aResistedAmount,0);
}
protected native function sv2cl_CombatMessageDeath_CallStub();
event sv2cl_CombatMessageDeath(Game_Pawn aKiller) {
cl_CombatLogMessage(Class'StringReferences'.default.EffectYouText.Text,Class'StringReferences'.default.CombatDeathText.Text,0,0,aKiller,self);
}
event cl_AddScrollingCombatValueOnOtherPlayer(byte aType,int aValue) {
switch (aType) {                                                            
case 3 :                                                                  
if (aValue > 0) {                                                       
cl_AddScrollingCombatValue(aValue,Class'FSkill_Enums'.10,False);      
} else {                                                                
cl_AddScrollingCombatValue(-aValue,Class'FSkill_Enums'.2,False);      
}
break;                                                                  
case 0 :                                                                  
cl_AddScrollingCombatValue(aValue,Class'FSkill_Enums'.4,True);          
break;                                                                  
case 1 :                                                                  
cl_AddScrollingCombatValue(aValue,Class'FSkill_Enums'.6,True);          
break;                                                                  
case 2 :                                                                  
cl_AddScrollingCombatValue(aValue,Class'FSkill_Enums'.8,True);          
break;                                                                  
default:                                                                  
}
}
event cl_AddScrollingCombatValueOnLocalPlayer(byte aType,int aValue) {
switch (aType) {                                                            
case 3 :                                                                  
if (aValue > 0) {                                                       
cl_AddScrollingCombatValue(aValue,Class'FSkill_Enums'.9,False);       
} else {                                                                
cl_AddScrollingCombatValue(-aValue,Class'FSkill_Enums'.1,False);      
}
break;                                                                  
case 0 :                                                                  
cl_AddScrollingCombatValue(aValue,Class'FSkill_Enums'.3,True);          
break;                                                                  
case 1 :                                                                  
cl_AddScrollingCombatValue(aValue,Class'FSkill_Enums'.5,True);          
break;                                                                  
case 2 :                                                                  
cl_AddScrollingCombatValue(aValue,Class'FSkill_Enums'.7,True);          
break;                                                                  
default:                                                                  
}
}
event cl_AddScrollingCombatTypeValue(byte aType,int aValue) {
if (IsLocalPlayer()) {                                                      
cl_AddScrollingCombatValueOnLocalPlayer(aType,aValue);                    
} else {                                                                    
cl_AddScrollingCombatValueOnOtherPlayer(aType,aValue);                    
}
}
protected native function sv2clrel_CombatLogMessage_CallStub();
event sv2clrel_CombatLogMessage(Game_Pawn executingPawn,Game_Pawn receivingPawn,byte anEvent,float Value) {
local string Message;
Message = executingPawn.Character.cl_GetName();                             
switch (anEvent) {                                                          
case Class'FSkill_Enums'.0 :                                              
Message = Message @ "did" @ string(Value)
@ "damage";         
Message = Message @ "to"
@ receivingPawn.Character.cl_GetName();
break;                                                                  
default:                                                                  
}
SendDesktopMessage("",Message,Class'Game_Desktop'.6);                       
switch (anEvent) {                                                          
case Class'FSkill_Enums'.0 :                                              
receivingPawn.cl_AddScrollingCombatDamage(Value);                       
break;                                                                  
case Class'FSkill_Enums'.1 :                                              
receivingPawn.cl_AddScrollingCombatDamage(-Value);                      
break;                                                                  
case Class'FSkill_Enums'.1 :                                              
receivingPawn.cl_AddScrollingCombatMessage("Heal");                     
break;                                                                  
case Class'FSkill_Enums'.2 :                                              
receivingPawn.cl_AddScrollingCombatMessage("Physique Drain");           
break;                                                                  
case Class'FSkill_Enums'.3 :                                              
receivingPawn.cl_AddScrollingCombatMessage("Morale Drain");             
break;                                                                  
case Class'FSkill_Enums'.4 :                                              
receivingPawn.cl_AddScrollingCombatMessage("Concentration Drain");      
break;                                                                  
default:                                                                  
}
}
native function cl_CombatLogMessage(string aPrefixFormatString,string aMessageFormatString,int aSkillResourceID,int aDuffResourceID,Game_Pawn aSource,Game_Pawn aTarget);
event cl_CombatMessage(int aSkillResourceID,int aDuffResourceID,int aEffectResourceID,Game_Pawn aSource,Game_Pawn aTarget,int aAmount,int aAmount2,int aAmount3) {
local export editinline FSkill_Type Skill;
local export editinline FSkill_Event_Duff Duff;
local export editinline FSkill_EffectClass effect;
Skill = FSkill_Type(Class'SBDBSync'.GetResourceObject(aSkillResourceID));   
Duff = FSkill_Event_Duff(Class'SBDBSync'.GetResourceObject(aDuffResourceID));
effect = FSkill_EffectClass(Class'SBDBSync'.GetResourceObject(aEffectResourceID));
effect.cl_CombatMessage(Skill,Duff,aSource,aTarget,aAmount,aAmount2,aAmount3);
}
protected native function sv2cl_SendGameConsoleMessageID_CallStub();
event sv2cl_SendGameConsoleMessageID(int localizedMessageID,int aChannel) {
local LocalizedString aString;
aString.Id = localizedMessageID;                                            
SendDesktopMessage(Character.cl_GetFullName(),aString.Text,aChannel);       
}
protected native function sv2cl_SendGameConsoleMessage_CallStub();
event sv2cl_SendGameConsoleMessage(string Text,int aChannel) {
SendDesktopMessage(Character.cl_GetFullName(),Text,aChannel);               
}
private function cl_RunNoSkillEvent(export editinline FSkill_Event_FX aEvent) {
local AimingInfo dummyAimingInfo;
if (aEvent != None) {                                                       
Skills.RunEvent(aEvent,Class'FSkill_Event'.65536 | Class'FSkill_Event'.4,None,self,self,None,vect(0.000000, 0.000000, 0.000000),dummyAimingInfo,CharacterStats.mRecord,-1,GetServerTime(),Class'FSkill_Enums'.8);
goto jl0077;                                                              
}
}
protected native function sv2clrel_PlayPawnEffectDirect_CallStub();
event sv2clrel_PlayPawnEffectDirect(int aEmitterID) {
local export editinline FSkill_Event_FX fxEvent;
fxEvent = new Class'FSkill_Event_FX';                                       
fxEvent.FX.Emitter = FSkill_EffectClass_AudioVisual_Emitter(Class'SBDBSync'.GetResourceObject(aEmitterID));
if (fxEvent.FX.Emitter != None) {                                           
cl_RunNoSkillEvent(fxEvent);                                              
goto jl0063;                                                              
}
}
private function cl_LoadEffects(export out editinline FSkill_EffectClass_AudioVisual_Emitter outEmitter,string fxName,export out editinline FSkill_EffectClass_AudioVisual_Sound outSound,string sndName,export out editinline FSkill_EffectClass_AudioVisual_CameraShake outShake,string csName,string Tag) {
if (Len(fxName) > 0) {                                                      
outEmitter = FSkill_EffectClass_AudioVisual_Emitter(static.DynamicLoadObject(fxName,Class'FSkill_EffectClass_AudioVisual_Emitter',True));
} else {                                                                    
outEmitter = None;                                                        
}
if (Len(sndName) > 0) {                                                     
outSound = FSkill_EffectClass_AudioVisual_Sound(static.DynamicLoadObject(sndName,Class'FSkill_EffectClass_AudioVisual_Sound',True));
} else {                                                                    
outSound = None;                                                          
}
if (Len(csName) > 0) {                                                      
outShake = FSkill_EffectClass_AudioVisual_CameraShake(static.DynamicLoadObject(csName,Class'FSkill_EffectClass_AudioVisual_CameraShake',True));
} else {                                                                    
outShake = None;                                                          
}
}
protected native function sv2clrel_PlayPawnEffect_CallStub();
event sv2clrel_PlayPawnEffect(byte aPET) {
cl_PlayPawnEffect(aPET);                                                    
}
event EdAddRangeLocation(export editinline FSkill_EffectClass_Range aRange,Vector aLocation) {
local int C;
C = mSelectedRanges.Length;                                                 
mSelectedRanges.Length = C + 1;                                             
mSelectedRanges[C].Range = aRange;                                          
mSelectedRanges[C].Location = aLocation;                                    
mSelectedRanges[C].RemoveTime = Level.TimeSeconds + 1.50000000;             
}
event EdAddRange(export editinline FSkill_EffectClass_Range aRange) {
local int C;
C = mSelectedRanges.Length;                                                 
mSelectedRanges.Length = C + 1;                                             
mSelectedRanges[C].Range = aRange;                                          
mSelectedRanges[C].Location = Location;                                     
mSelectedRanges[C].RemoveTime = Level.TimeSeconds + 1.50000000;             
}
function bool sv_IsResting() {
local Game_PlayerController gpController;
gpController = Game_PlayerController(Controller);                           
if (gpController != None) {                                                 
return gpController.IsSitting();                                          
}
return False;                                                               
}
protected native function cl2sv_Rest_CallStub();
event cl2sv_Rest(bool ignoreVelocity) {
local Game_PlayerController gpController;
if (Physics != 1 && Physics != 19 && Physics != 20
|| !ignoreVelocity && VSize(Velocity) > 2.00000000) {
return;                                                                   
}
if (CharacterStats != None
&& CharacterStats.IsMovementFrozen()) {    
return;                                                                   
}
gpController = Game_PlayerController(Controller);                           
if (gpController != None && combatState != None
&& CombatStats != None
&& !CombatStats.InCombat()
&& !combatState.CombatReady()
&& !combatState.IsDrawing()
&& !combatState.IsSheathing()) {
if (gpController.IsSitting()) {                                           
sv_Sit(False,False);                                                    
} else {                                                                  
sv_Sit(True,False);                                                     
}
goto jl012C;                                                              
}
}
function cl_Banner(Game_Pawn aPartner,export editinline Conversation_Topic aTopic) {
}
protected native function cl2sv_Interact_CallStub();
event cl2sv_Interact(Game_Actor aActor,byte aOption) {
}
function sv_Sit(bool bSitDown,optional bool bOnChair) {
local Game_Controller cont;
cont = Game_Controller(Controller);                                         
if (cont != None) {                                                         
if (bSitDown && SitDown(bOnChair)) {                                      
cont.SBGotoState(10);                                                   
} else {                                                                  
if (Physics == 19 || Physics == 20) {                                   
cont.SBGotoState(1);                                                  
} else {                                                                
return;                                                               
}
}
}
}
protected native function sv2cl_SetRotateToOrientation_CallStub();
event sv2cl_SetRotateToOrientation(Rotator aTargetOrientation) {
Game_PlayerController(Controller).mTargetRotation = aTargetOrientation;     
}
function sv_RotateToOrientation(Rotator aTargetOrientation) {
sv2cl_SetRotateToOrientation_CallStub(aTargetOrientation);                  
Game_PlayerController(Controller).SBGotoState(9);                           
}
protected native function sv2cl_SetTargetDestination_CallStub();
private final event sv2cl_SetTargetDestination(Vector aTargetDestination,float aMaxDistanceToTarget,float aTimeToMove) {
local Game_PlayerController gpController;
gpController = Game_PlayerController(Controller);                           
if (gpController != None) {                                                 
gpController.mTargetDestination = aTargetDestination;                     
gpController.mMaxDistanceToTarget = aMaxDistanceToTarget;                 
gpController.mMaxTimeToMove = aTimeToMove;                                
}
}
final event sv_MoveTo(Vector aPosition,Actor aTargetActor,optional float aMaxDistanceToTarget,optional float aTimeToMove) {
local Game_PlayerController gpController;
gpController = Game_PlayerController(Controller);                           
if (gpController != None) {                                                 
mDesiredLocation = aPosition;                                             
mTargetActor = aTargetActor;                                              
gpController.mTargetDestination = aPosition;                              
gpController.mMaxDistanceToTarget = aMaxDistanceToTarget;                 
if (aTimeToMove < 0.10000000) {                                           
aTimeToMove = -1.00000000;                                              
}
gpController.mMaxTimeToMove = aTimeToMove;                                
sv2cl_SetTargetDestination_CallStub(aPosition,aMaxDistanceToTarget,aTimeToMove);
gpController.SBGotoState(8);                                              
}
}
event bool IsRotationFrozen() {
return CharacterStats.IsRotationFrozen();                                   
}
event RemoveInteractionTag(name aInteractionTagName) {
local int i;
i = GetInteractionTagIndex(aInteractionTagName);                            
if (i != -1) {                                                              
InteractionTags.Remove(i,1);                                              
}
}
event AddInterationTag(name aInteractionTagName) {
local int i;
i = GetInteractionTagIndex(aInteractionTagName);                            
if (i != -1) {                                                              
i = InteractionTags.Length;                                               
InteractionTags.Length = i + 1;                                           
InteractionTags[i] = aInteractionTagName;                                 
}
}
function int GetInteractionTagIndex(name aInteractionTagName) {
local int i;
i = 0;                                                                      
while (i < InteractionTags.Length) {                                        
if (InteractionTags[i] == aInteractionTagName) {                          
return i;                                                               
}
++i;                                                                      
}
return -1;                                                                  
}
event OnSheatheWeapon(byte WeaponFlag) {
combatState.OnDoneSheathing(WeaponFlag != Class'SBAnimationFlags'.4);       
}
event OnDrawWeapon(byte WeaponFlag) {
combatState.OnDoneDrawing(WeaponFlag != Class'SBAnimationFlags'.4);         
}
function bool SpecialCalcView(out Actor ViewActor,out Vector CameraLocation,out Rotator CameraRotation) {
Game_PlayerController(Controller).Camera.ShakeCamera(ViewActor,CameraLocation,CameraRotation);
return True;                                                                
}
event float PlayDamageSound(float aDamage,float aRadius) {
return Class'StaticPawnSounds'.PlayDamageSound(self,aDamage,aRadius);       
}
protected native function sv2clrel_StaticPlaySound_CallStub();
event sv2clrel_StaticPlaySound(byte ASound,float aRadius) {
StaticPlaySound(ASound,aRadius);                                            
}
event float StaticPlaySoundEx(byte ASound,float aRadius,float aVolume,float aPitch) {
return Class'StaticPawnSounds'.PlaySoundEx(self,ASound,aRadius,aVolume,aPitch);
}
event float StaticPlaySound(byte ASound,float aRadius) {
return Class'StaticPawnSounds'.PlaySound(self,ASound,aRadius);              
}
event StaticStopSound(byte ASound) {
Class'StaticPawnSounds'.StopSound(self,ASound);                             
}
final native function bool IsInTeam(Game_Pawn aPawn);
final native function bool IsHostile(Game_Pawn aPawn);
event bool IsInCombat() {
if (combatState != None) {                                                  
return combatState.CombatReady();                                         
}
return False;                                                               
}
event byte GetEquippedWeaponFlag() {
local export editinline Game_EquippedAppearance equippedAppearance;
equippedAppearance = Game_EquippedAppearance(Appearance.GetCurrent());      
if (IsEditor() && equippedAppearance != None) {                             
switch (equippedAppearance.GetValue(16)) {                                
case 0 :                                                                
return 1;                                                             
case 1 :                                                                
return 3;                                                             
case 2 :                                                                
return 3;                                                             
case 3 :                                                                
return 4;                                                             
case 4 :                                                                
return 2;                                                             
default:                                                                
break;                                                                
}
switch (equippedAppearance.GetValue(17)) {                                
case 0 :                                                                
return 1;                                                             
case 1 :                                                                
return 3;                                                             
case 2 :                                                                
return 3;                                                             
case 3 :                                                                
return 4;                                                             
case 4 :                                                                
return 2;                                                             
default:                                                                
return 0;                                                             
}
if (combatState != None
&& (combatState.CombatReady()
|| combatState.IsExecutingBodySlotSkill())) {
return combatState.GetWeaponFlag();                                     
} else {                                                                  
return Class'SBAnimationFlags'.0;                                       
}
}
}
final native event bool IsDead();
event sv2clrel_UpdateNetState(byte aState) {
if (aState != mNetState) {                                                  
mNetState = aState;                                                       
if (mNetState != mCurrentState) {                                         
SBGotoState(mNetState);                                                 
}
}
}
event FellOutOfWorld(byte KillType) {
if (SBRole == 1 && mCurrentState != 2) {                                    
if (Controller == None) {                                                 
} else {                                                                  
TakeDamage(10 * CharacterStats.mRecord.MaxHealth,None,Location,vect(0.000000, 0.000000, 0.000000),Class'fell');
}
}
}
native function bool InteractionRange(Actor aTarget);
event string GetActiveText(Game_ActiveTextItem aItem) {
local byte PawnClass;
if (aItem == None || aItem.Tag == ""
|| aItem.Tag == "N") {           
if (SBRole == 4) {                                                        
return Character.cl_GetBaseName();                                      
} else {                                                                  
return Character.cl_GetName();                                          
}
} else {                                                                    
if (aItem.Tag == "F") {                                                   
if (SBRole == 4) {                                                      
return Character.cl_GetBaseFullName();                                
} else {                                                                
return Character.cl_GetFullName();                                    
}
} else {                                                                  
if (aItem.Tag == "G") {                                                 
if (aItem.FreeOptions.Length == 0) {                                  
return Class'StringReferences'.GetActiveTextString(Class'Game_ActiveTextItem'.1,Appearance.IsFeminine());
} else {                                                              
return aItem.FreeOptions[Appearance.IsFeminine()];                  
}
} else {                                                                
if (aItem.Tag == "GG") {                                              
return Class'StringReferences'.GetActiveTextString(Class'Game_ActiveTextItem'.2,Appearance.IsFeminine());
} else {                                                              
if (aItem.Tag == "GO") {                                            
return Class'StringReferences'.GetActiveTextString(Class'Game_ActiveTextItem'.3,Appearance.IsFeminine());
} else {                                                            
if (aItem.Tag == "GS") {                                          
return Class'StringReferences'.GetActiveTextString(Class'Game_ActiveTextItem'.4,Appearance.IsFeminine());
} else {                                                          
if (aItem.Tag == "GP") {                                        
return Class'StringReferences'.GetActiveTextString(Class'Game_ActiveTextItem'.5,Appearance.IsFeminine());
} else {                                                        
if (aItem.Tag == "R") {                                       
return Class'StringReferences'.GetRaceName(Appearance.GetBase().GetRace(),Appearance.IsFeminine());
} else {                                                      
if (aItem.Tag == "C") {                                     
if (Game_PlayerStats(CharacterStats) != None) {           
PawnClass = CharacterStats.GetCharacterClass();         
if (PawnClass == 0) {                                   
PawnClass = CharacterStats.GetArchetype();            
}
}
return Class'StringReferences'.GetClassName(PawnClass,Appearance.IsFeminine());
} else {                                                    
if (aItem.Tag == "CA") {                                  
if (Game_PlayerStats(CharacterStats) != None) {         
PawnClass = CharacterStats.GetArchetype();            
}
return Class'StringReferences'.GetClassName(PawnClass,Appearance.IsFeminine());
} else {                                                  
if (aItem.Tag == "H") {                                 
if (Character.GetFaction() != None) {                 
return Character.GetFaction().GetActiveText(aItem.SubItem);
} else {                                              
return Class'StringReferences'.GetActiveTextString(Class'Game_ActiveTextItem'.6,0);
}
} else {                                                
return "??";                                          
}
}
}
}
}
}
}
}
}
}
}
}
event bool sv_OnAttack(Game_Pawn aPawn,export editinline FSkill_EffectClass aEffect,bool WasNegativeEffect,float aValue) {
local Game_Controller gc;
local bool Result;
if (IsDead()) {                                                             
Result = False;                                                           
} else {                                                                    
if (WasNegativeEffect && aPawn != None
&& aPawn.CombatStats != None
&& aEffect != None) {
aPawn.CombatStats.sv_SetLastAttackedPawn(self);                         
}
if (IsAttackable(aPawn)) {                                                
if (!Game_Controller(Controller).sv_OnAttack(aPawn,aEffect,WasNegativeEffect,aValue)) {
Result = False;                                                       
} else {                                                                
Result = True;                                                        
}
} else {                                                                  
Result = True;                                                          
}
if (!Result && Pet != None) {                                             
gc = Game_Controller(Pet.Controller);                                   
gc.sv_OnOwnerAttack(WasNegativeEffect);                                 
}
}
return Result;                                                              
}
event string cl_GetSecondaryDisplayName() {
return "";                                                                  
}
event string cl_GetPrimaryDisplayName() {
return "";                                                                  
}
event SendDesktopMessage(string aSenderName,string aMessage,int aChannel) {
local Game_PlayerController PlayerController;
local Game_Desktop desktop;
PlayerController = Game_PlayerController(Controller);                       
if (PlayerController != None
&& PlayerController.Player != None) {    
desktop = Game_Desktop(PlayerController.Player.GUIDesktop);               
if (desktop != None) {                                                    
desktop.AddMessage(aSenderName,aMessage,aChannel);                      
}
}
}
function cl_AddScrollingCombatDamage(int aDamage) {
}
function cl_AddScrollingCombatValue(int aValue,byte aType,bool aShowPositiveSign) {
if (aShowPositiveSign && aValue >= 0) {                                     
cl_AddScrollingCombatMessage("+" $ string(aValue),aType);                 
} else {                                                                    
cl_AddScrollingCombatMessage(string(aValue),aType);                       
}
}
protected native function sv2cl_AddScrollingCombatDamage_CallStub();
event sv2cl_AddScrollingCombatDamage(int aDamage) {
cl_AddScrollingCombatDamage(aDamage);                                       
}
function cl_AddScrollingCombatMessage(string aText,optional byte aType,optional float aExtraScale) {
HUD.cl_AddScrollingCombatMessage(aText,aType,aExtraScale);                  
}
protected native function sv2rel_AddScrollingCombatMessage_CallStub();
event sv2rel_AddScrollingCombatMessage(int aTextId,optional byte aType) {
cl_AddScrollingCombatMessage(Class'SBDBSync'.GetDescription(aTextId),aType);
}
protected native function sv2cl_AddRelayScrollingCombatMessage_CallStub();
event sv2cl_AddRelayScrollingCombatMessage(Game_Pawn aTarget,int aTextId,optional byte aType) {
aTarget.cl_AddScrollingCombatMessage(Class'SBDBSync'.GetDescription(aTextId),aType);
}
protected native function sv2cl_AddScrollingCombatMessage_CallStub();
event sv2cl_AddScrollingCombatMessage(int aTextId,optional byte aType,optional string aPostfix) {
cl_AddScrollingCombatMessage(Class'SBDBSync'.GetDescription(aTextId)
$ aPostfix,aType);
}
function int GetScavengeMode() {
return 0;                                                                   
}
function Game_Pawn GetRoundRobinMember() {
return self;                                                                
}
function int GetLootMode() {
return 0;                                                                   
}
native function Game_Team GetTeam();
function int GetTeamID() {
if (!IsPlayerPawn()) {                                                      
return 0;                                                                 
} else {                                                                    
return Game_PlayerController(Controller).GroupingTeams.GetTeamID();       
}
}
event TakeEffectDamage(float Damage,Game_Pawn instigatedBy,Vector HitLocation,Vector Momentum,class<DamageType> DamageType) {
if (sv_IsResting()) {                                                       
sv_Sit(False,False);                                                      
}
TakeDamage(Damage,instigatedBy,HitLocation,Momentum,DamageType);            
}
protected native function cl2sv_TakeDamage_CallStub();
event cl2sv_TakeDamage(int Damage,Game_Pawn instigatedBy,Vector HitLocation,Vector Momentum) {
TakeDamage(Damage,instigatedBy,HitLocation,Momentum,Class'DamageType');     
}
function TakeDamage(int Damage,Pawn instigatedBy,Vector HitLocation,Vector Momentum,class<DamageType> DamageType) {
if (!IsInvulnerable()) {                                                    
if (IsServer()) {                                                         
Super.TakeDamage(Damage,instigatedBy,HitLocation,Momentum,DamageType);  
} else {                                                                  
cl2sv_TakeDamage_CallStub(Damage,Game_Pawn(instigatedBy),HitLocation,Momentum);
}
}
}
event Landed(Vector HitNormal) {
local float damageFactor;
bJumpedFromLadder = False;                                                  
Super.Landed(HitNormal);                                                    
if (IsServer()) {                                                           
if (-Velocity.Z > mMaxDamageFallSpeed) {                                  
damageFactor = 10.00000000;                                             
TakeDamage(damageFactor * CharacterStats.mRecord.MaxHealth,None,Location,vect(0.000000, 0.000000, 0.000000),Class'fell');
sv2cl_AddScrollingCombatMessage_CallStub(Class'StringReferences'.default.Cratered.Id);
} else {                                                                  
if (-Velocity.Z > mMinDamageFallSpeed) {                                
damageFactor = (-Velocity.Z - mMinDamageFallSpeed) / (mMaxDamageFallSpeed - mMinDamageFallSpeed);
TakeDamage(damageFactor * CharacterStats.mRecord.MaxHealth,None,Location,vect(0.000000, 0.000000, 0.000000),Class'fell');
sv2cl_AddScrollingCombatDamage_CallStub(damageFactor * CharacterStats.mRecord.MaxHealth);
}
}
}
LastHitBy = None;                                                           
}
native function bool IsAttackable(Game_Pawn aOpponent);
event bool IsInvulnerable() {
return bInvulnerable || bCheatInvulnerable;                                 
}
protected native function sv2rel_SetInvulnerable_CallStub();
event sv2rel_SetInvulnerable(bool aInvulnerable) {
bInvulnerable = aInvulnerable;                                              
}
event SetInvulnerable(bool aInvulnerable) {
bInvulnerable = aInvulnerable;                                              
sv2rel_SetInvulnerable_CallStub(aInvulnerable);                             
}
native function SetHealth(float aHealth);
native function IncreaseHealth(float aDelta);
native function float GetHealth();
event string GetCharacterName() {
if (IsClient()) {                                                           
return Character.cl_GetName();                                            
} else {                                                                    
return Character.sv_GetName();                                            
}
}
native function Vector GetHistoryLocation(float aServerTime);
native function UpdateMovementVariables();
native function PredictMovement(float aDeltaTime);
final native function float GetServerTime();
function DestroyShadow() {
if (mPawnShadow != None) {                                                  
mPawnShadow.DetachProjector(True);                                        
mPawnShadow.Destroy();                                                    
mPawnShadow = None;                                                       
}
}
function CreateShadow() {
if (bActorShadows && IsClient() && !IsServer()) {                           
mPawnShadow = Spawn(Class'ShadowProjector',self,'None',Location);         
mPawnShadow.ShadowActor = self;                                           
mPawnShadow.bBlobShadow = True;                                           
mPawnShadow.LightDirection = -GetMainLightDirection();                    
mPawnShadow.LightDistance = CollisionHeight * 8.00000000;                 
mPawnShadow.MaxTraceDistance = CollisionHeight * 8.50000000;              
mPawnShadow.RootMotion = True;                                            
mPawnShadow.InitShadow();                                                 
}
}
native function Vector GetMainLightDirection();
function RadialMenuSelect(Pawn aPlayerPawn,byte aMainOption,byte aSubOption) {
local Game_PlayerPawn Player;
local Game_PlayerPawn Opponent;
Super.RadialMenuSelect(aPlayerPawn,aMainOption,aSubOption);                 
if (aMainOption == Class'Game_RadialMenuOptions'.0) {                       
if (aSubOption == Class'Game_RadialMenuOptions'.7
&& Game_PlayerPawn(self) != None
&& aPlayerPawn.IsA('Game_Pawn')) {
Game_Pawn(aPlayerPawn).Trading.cl_RequestTrade(Game_PlayerController(aPlayerPawn.Controller).Input.cl_GetTargetPawn());
}
if (aSubOption == Class'Game_RadialMenuOptions'.18
&& Game_PlayerPawn(self) != None) {
Player = Game_PlayerPawn(aPlayerPawn);                                  
Opponent = Game_PlayerPawn(Game_PlayerController(Player.Controller).Input.cl_GetTargetPawn());
Player.MiniGameProxy.cl_StartMiniGame(Opponent);                        
}
}
}
function Material RadialMenuImage(Pawn aPlayerPawn,byte aMainOption,byte aSubOption) {
return None;                                                                
}
event RadialMenuCollect(Pawn aPlayerPawn,byte aMainOption,out array<byte> aSubOptions) {
Super.RadialMenuCollect(aPlayerPawn,aMainOption,aSubOptions);               
}
function SBClock GetClock() {
if (Game_GameInfo(GetGameInfo()) != None) {                                 
return Game_GameInfo(GetGameInfo()).mClock;                               
}
return None;                                                                
}
protected native function sv2clrel_UpdateGroundSpeedModifier_CallStub();
event sv2clrel_UpdateGroundSpeedModifier(float aModifier) {
GroundSpeedModifier = aModifier;                                            
}
function sv_SetGroundSpeedModifier(float aModifier) {
GroundSpeedModifier = aModifier;                                            
sv2clrel_UpdateGroundSpeedModifier_CallStub(GroundSpeedModifier);           
}
event cl_NotifySelected(bool aIsSelected) {
if (mIsSelected != aIsSelected) {                                           
mIsSelected = aIsSelected;                                                
cl_UpdateInteractionEffect();                                             
}
}
event cl_NotifyUnderCursor(bool aIsUnderCursor) {
Super.cl_NotifyUnderCursor(aIsUnderCursor);                                 
if (mIsUnderCursor != aIsUnderCursor) {                                     
mIsUnderCursor = aIsUnderCursor;                                          
cl_UpdateInteractionEffect();                                             
}
}
function cl_UpdateInteractionEffect() {
if (Effects == None) {                                                      
return;                                                                   
}
if (mIsSelected) {                                                          
Effects.cl_SetInteractionEffect(Class'Game_Effects'.2);                   
} else {                                                                    
if (mIsUnderCursor) {                                                     
Effects.cl_SetInteractionEffect(Class'Game_Effects'.1);                 
} else {                                                                  
Effects.cl_SetInteractionEffect(Class'Game_Effects'.0);                 
}
}
}
protected final native function bool TeleportTo(Vector aNewLocation,Rotator aNewRotation);
final native function Submerge();
protected native function sv2clrel_Submerge_CallStub();
protected event sv2clrel_Submerge() {
Submerge();                                                                 
}
final native function Emerge();
protected native function sv2clrel_Emerge_CallStub();
protected event sv2clrel_Emerge() {
Emerge();                                                                   
}
event bool sv_TeleportTo(Vector aNewLocation,Rotator aNewRotation) {
if (TeleportTo(aNewLocation,aNewRotation)) {                                
sv2clrel_TeleportTo_CallStub(aNewLocation,aNewRotation);                  
return True;                                                              
}
return False;                                                               
}
protected native function sv2clrel_TeleportTo_CallStub();
event sv2clrel_TeleportTo(Vector NewLocation,Rotator NewRotation) {
TeleportTo(NewLocation,NewRotation);                                        
}
function bool IsMuted(optional byte aRange) {
local Game_PlayerController gc;
gc = Game_PlayerController(Controller);                                     
if (gc != None) {                                                           
if (gc.DBMutedScope == Class'Game_PlayerController'."all") {              
return True;                                                            
}
if (aRange == 1) {                                                        
return gc.DBMutedScope == Class'Game_PlayerController'."global";        
}
return gc.DBMutedScope != "";                                             
} else {                                                                    
return False;                                                             
}
}
protected native function sv2cl_UpdateMuted_CallStub();
event sv2cl_UpdateMuted(bool aMuted,string aMutedScope) {
local Game_PlayerController gc;
gc = Game_PlayerController(Controller);                                     
if (gc != None) {                                                           
gc.DBMuted = aMuted;                                                      
gc.DBMutedScope = aMutedScope;                                            
}
}
final native function Mute(int aAccountID,bool aState,optional int aMinutes,optional string aScope);
function sv_Mute(bool aState,optional int aMinutes,optional string aScope) {
local Game_PlayerController gc;
gc = Game_PlayerController(Controller);                                     
if (gc != None) {                                                           
gc.DBMuted = aState;                                                      
gc.DBMutedScope = aScope;                                                 
Mute(Base_Controller(Controller).AccountID,gc.DBMuted,aMinutes,aScope);   
sv2cl_UpdateMuted_CallStub(gc.DBMuted,gc.DBMutedScope);                   
}
}
event Destroyed() {
RemoveAllAttachments();                                                     
DestroyShadow();                                                            
Super.Destroyed();                                                          
}
event cl_OnShutdown() {
if (Effects != None) {                                                      
Effects.cl_OnShutdown();                                                  
}
if (MiniGameProxy != None) {                                                
MiniGameProxy.cl_OnShutdown();                                            
}
if (combatState != None) {                                                  
combatState.cl_OnShutdown();                                              
}
if (Appearance != None) {                                                   
Appearance.cl_OnShutdown();                                               
}
if (Skills != None) {                                                       
Skills.cl_OnShutdown();                                                   
}
if (CharacterStats != None) {                                               
CharacterStats.cl_OnShutdown();                                           
}
if (Character != None) {                                                    
Character.cl_OnShutdown();                                                
}
if (IsLocalPlayer()) {                                                      
if (BodySlots != None) {                                                  
BodySlots.cl_OnShutdown();                                              
}
if (CombatStats != None) {                                                
CombatStats.cl_OnShutdown();                                            
}
if (Emotes != None) {                                                     
Emotes.cl_OnShutdown();                                                 
}
if (Looting != None) {                                                    
Looting.cl_OnShutdown();                                                
}
if (Trading != None) {                                                    
Trading.cl_OnShutdown();                                                
}
}
ShiftStateChanged.Delete();                                                 
CombatStateChanged.Delete();                                                
PetSummoned.Delete();                                                       
Super.cl_OnShutdown();                                                      
}
function bool CanGrabLadder() {
local byte WeaponFlag;
WeaponFlag = GetEquippedWeaponFlag();                                       
if (WeaponFlag != 0 && WeaponFlag != 1) {                                   
SendDesktopMessage("",Class'StringReferences'.default.Cannot_climb_while_armed.Text,Class'Game_Desktop'.7);
return False;                                                             
}
if (bJumpedFromLadder) {                                                    
return False;                                                             
}
return Super.CanGrabLadder();                                               
}
event bool DoJump() {
if (CanJump()) {                                                            
bJumpedFromLadder = Physics == 11;                                        
return Super.DoJump();                                                    
}
return False;                                                               
}
event bool CanJump() {
return (Physics == 1 || Physics == 11)
&& !CharacterStats.IsMovementLimited()
&& JumpZ > 0;
}
event cl_OnFrame(float DeltaTime) {
Skills.cl_OnFrame(DeltaTime);                                               
Appearance.cl_OnFrame(DeltaTime);                                           
if (Emotes != None) {                                                       
Emotes.cl_OnFrame(DeltaTime);                                             
}
if (CombatStats != None) {                                                  
combatState.cl_OnFrame(DeltaTime);                                        
}
if (Looting != None) {                                                      
Looting.cl_OnFrame(DeltaTime);                                            
}
Super.cl_OnFrame(DeltaTime);                                                
if (mCurrentState != mNetState && mNetState != 0) {                         
SBGotoState(mNetState);                                                   
}
if (MiniGameProxy != None) {                                                
MiniGameProxy.cl_OnFrame(DeltaTime);                                      
}
if (mPrevCombatReady != combatState.CombatReady()
|| mPrevInCombat != CombatStats.InCombat()) {
mPrevCombatReady = combatState.CombatReady();                             
mPrevInCombat = CombatStats.InCombat();                                   
CombatStateChanged.Trigger();                                             
}
mTeleported = False;                                                        
}
event cl_OnUpdate() {
Super.cl_OnUpdate();                                                        
if (!IsLocalPlayer()) {                                                     
UpdateMovementVariables();                                                
}
}
protected native function sv2cl_RequestIdentification_CallStub();
event sv2cl_RequestIdentification(int worldID,int universeID,int CharacterID,int AccountID) {
mCharacterIdentityForBugReport.TransferAccountID = AccountID;               
mCharacterIdentityForBugReport.TransferCharacterID = CharacterID;           
mCharacterIdentityForBugReport.TransferUniverseID = universeID;             
mCharacterIdentityForBugReport.TransferWorldID = worldID;                   
}
function cl_RequestIdentification() {
cl2sv_RequestIdentification_CallStub();                                     
}
protected native function cl2sv_RequestIdentification_CallStub();
event cl2sv_RequestIdentification() {
sv2cl_RequestIdentification_CallStub(Base_Controller(Controller).AccountID,Base_Controller(Controller).CharacterID,GetUniverseID(),GetWorldID());
}
event cl_OnBaseline() {
Super.cl_OnBaseline();                                                      
if (Effects != None) {                                                      
Effects.cl_OnBaseline();                                                  
}
if (mNetState != 0) {                                                       
SBGotoState(mNetState);                                                   
}
if (Physics == 21) {                                                        
bHidden = True;                                                           
}
if (mInvisible) {                                                           
cl_PlayPawnEffect(6);                                                     
} else {                                                                    
cl_PlayPawnEffect(3);                                                     
}
}
*/
