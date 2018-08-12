using System;
using System.Collections.Generic;
using Engine;
using SBBase;

namespace SBGame
{
#pragma warning disable 414   

    [Serializable] public class Game_Skills : Base_Component
    {
        public const int MAX_TOKEN_SLOTS = 3;

        public const int MAX_STACK_COUNT = 10;

        public const float MAX_AIMING_DESYNC = 1F;

        public const int COMBO_FINISHING_MOVE_MINIMUM = 2;

        public const float COMBO_TIMEFRAME = 10F;

        public const float COMBO_VERSUS_TIMEFRAME = 5F;

        public const int COMBO_MAX_STRING_LENGTH = 9;

        public int mTiers;

        public int mTierSlots;

        public float mTierTimeout;

        public float mTierTimeoutStartTime;

        public int mCurrentTier;

        public int mLastSkillIndex;

        public List<FSkill_Type> CharacterSkills = new List<FSkill_Type>();

        public List<FSkill_Type> SkilldeckSkills = new List<FSkill_Type>();

        private string DebugSkillIndentStr = string.Empty;

        private bool DebugSkillEnabled;

        public RunningSkillData LastSkill;

        private int NextNotifyIndex;

        private List<RunningSkillData> ActiveSkills = new List<RunningSkillData>();

        private List<FSkill_Event> RunningEvents = new List<FSkill_Event>();

        private int TargetFlags;

        private Vector TargetLocation;

        private int SessionID;

        private FSkill_Event.AimingInfo TargetAimingInfo;

        [ArraySizeForExtraction(Size = 9)]
        private ComboStringData[] mComboString = new ComboStringData[0];

        private int mComboStringLength;

        private ComboStringData mPreviousLastComboEntry;

        private List<Game_Pawn> mComboTargets = new List<Game_Pawn>();

        private List<SpecialDuffEffect> SpecialDuffEffects = new List<SpecialDuffEffect>();

        public FSkill_Event_Duff SpecialDuffEffectsEvent;

        private List<FSkill_Event_Duff> SpecialDuffEvents = new List<FSkill_Event_Duff>();

        [ArraySizeForExtraction(Size = 90)]
        private DuffStackData[] AppliedStackDuffs = new DuffStackData[0];

        private List<DuffStackData> AppliedNoStackDuffs = new List<DuffStackData>();

        private UObject SkillEffectsPackage;

        private bool DirtyDuffData;

        public List<int> TeamDuffList = new List<int>();

        public List<ClientDuffStackData> ClientDuffList = new List<ClientDuffStackData>();

        public float mLastDuffUpdateTime;

        private List<ImmuneData> ImmuneEffects = new List<ImmuneData>();

        private List<DisableSkillUseData> DisableSkillUseEffects = new List<DisableSkillUseData>();

        private List<AlterEffectData> AlterEffectEffects = new List<AlterEffectData>();

        private List<ShareData> ShareEffects = new List<ShareData>();

        private List<ReturnReflectData> ReturnReflectEffects = new List<ReturnReflectData>();

        private List<Game_Pawn> Bloodlinks = new List<Game_Pawn>();

        private bool DirtyShareApplicantData;

        private List<ShareApplicantData> ShareApplicantEffects = new List<ShareApplicantData>();

        //public delegate<OnRollToFirstTier> @__OnRollToFirstTier__Delegate;

        //public delegate<OnRollToNextTier> @__OnRollToNextTier__Delegate;

        //public delegate<OnSkilldeckChanged> @__OnSkilldeckChanged__Delegate;

        //public delegate<OnCharacterSkillsChanged> @__OnCharacterSkillsChanged__Delegate;

        //public delegate<OnComboStringChanged> @__OnComboStringChanged__Delegate;

        //public delegate<OnSkillLog> @__OnSkillLog__Delegate;

        //public delegate<OnSkillReceivedTokenSlot> @__OnSkillReceivedTokenSlot__Delegate;

        //public delegate<RemoveDuffFilter> @__RemoveDuffFilter__Delegate;

        private int mSkillSessionTable;

        private int mSkillTokenMap;

        private bool mHasTokenMapBeenModified;

        public Game_Skills()
        {
        }

        [Serializable] public struct ReturnReflectData
        {
            public int Id;

            public FSkill_EffectClass_DuffReturnReflect effect;

            public float EarliestEffectTime;

            public int NumUses;

            public FSkill_Event Event;
        }

        [Serializable] public struct ShareApplicantData
        {
            public Game_Pawn Target;

            public FSkill_EffectClass_DuffShare effect;
        }

        [Serializable] public struct ShareData
        {
            public int Id;

            public FSkill_EffectClass_DuffShare effect;

            public Game_Pawn Target;

            public float EarliestEffectTime;

            public int NumUses;

            public FSkill_Event Event;
        }

        [Serializable] public struct AlterEffectData
        {
            public int Id;

            public FSkill_EffectClass_DuffAlterEffectInOutput effect;

            public float Value;

            public float EarliestEffectTime;

            public int NumUses;
        }

        [Serializable] public struct DisableSkillUseData
        {
            public int Id;

            public FSkill_EffectClass_DuffDisableSkillUse effect;
        }

        [Serializable] public struct ImmuneData
        {
            public int Id;

            public FSkill_EffectClass_DuffImmunity effect;
        }

        [Serializable] public struct ClientDuffStackData
        {
            public FSkill_Event_Duff OriginalDuff;

            public int ActualStackCount;

            public float ApplyTime;

            public float Duration;
        }

        [Serializable] public struct TransferDuffStackData
        {
            public int OriginalDuffID;

            public int ActualStackCount;

            public float ApplyTime;

            public float Duration;
        }

        [Serializable] public struct DuffStackData
        {
            public float ApplyTime;

            public FSkill_Event_Duff OriginalDuff;

            public FSkill_Event_Duff[] Duffs;

            public int ActualStackCount;
        }

        [Serializable] public struct SpecialDuffEffect
        {
            public FSkill_EffectClass_Duff Duff;

            public float UndoTime;

            public List<FSkill_EffectClass_Duff.DuffRestoreData> UndoData;

            public int Identifier;
        }

        [Serializable] public struct ComboStringData
        {
            public FSkill_Type Skill;

            public float ApplyTime;
        }

        [Serializable] public struct RunningSkillData
        {
            public float StartTime;

            public float Duration;

            public float EndTime;

            public float SkillSpeed;

            public FSkill_Type Skill;

            public bool LockedMovement;

            public bool LockedRotation;

            public bool ComboRelevant;

            public Game_Pawn SpecificTarget;
        }

        public enum ESkillStartFailure
        {
            SSF_ALLOWED,

            SSF_INVALID_SKILL,

            SSF_FINISHERS_NOT_ALLOWED,

            SSF_OPENERS_NOT_ALLOWED,

            SSF_COOLING_DOWN,

            SSF_DEBUFF_DISABLED,

            SSF_INVALID_PAWN,

            SSF_STILL_EXECUTING_SKILL,

            SSF_FROZEN,

            SSF_DEAD,

            SSF_OUTOFRANGE,
        }
    }
}
/*
native function int GetSkilldeckColumnCount();
native function int GetSkilldeckRowCount();
final native function int GetBodySlotCount();
final native function int GetCurrentSkillTier();
final native function int GetMaxSkillCount();
final function int GetActiveSkillCount() {
return ActiveSkills.Length;                                                 
}
private final native function UpdateTokenSlots(export editinline FSkill_Type aSkill,int aExtraSlots);
final native function Game_Item GetTokenForSkill(export editinline FSkill_Type aSkill,int aSlot);
final native function int GetTokenCountForSkill(export editinline FSkill_Type aSkill);
final native function GetTokensForSkill(export editinline FSkill_Type aSkill,out array<Game_Item> outTokens);
final native function int GetTokenSlots(export editinline FSkill_Type aSkill);
final native function int GetMaxTotalSkillTokenCount();
final native function int GetTotalSkillTokenCount();
protected native function sv2cl_OnSkillReceivedTokenSlot_CallStub();
protected final event sv2cl_OnSkillReceivedTokenSlot(int aSkillID,int aNewSlotCount) {
local export editinline FSkill_Type Skill;
Skill = FSkill_Type(Class'SBDBSync'.GetResourceObject(aSkillID));           
if (Skill != None) {                                                        
UpdateTokenSlots(Skill,1);                                                
OnSkillReceivedTokenSlot(Skill,aNewSlotCount);                            
goto jl004D;                                                              
}
}
final native function bool sv_AddTokenSlot(export editinline FSkill_Type aSkill);
protected native function cl2sv_AddTokenSlot_CallStub();
final event cl2sv_AddTokenSlot(int aSkillID) {
local export editinline FSkill_Type skillResource;
skillResource = FSkill_Type(Class'SBDBSync'.GetResourceObject(aSkillID));   
if (skillResource != None) {                                                
sv_AddTokenSlot(skillResource);                                           
}
}
final native function float sv_GetTokenEffect(export editinline FSkill_Type aSkill,byte aEffect,float aInputValue);
final native function sv_IncreaseTokenEffect(export editinline FSkill_Type aSkill,byte aEffect,byte aMode,float aValue);
final function sv_RemoveSpecialDuffEvent(export editinline FSkill_Event_Duff aDuff) {
local int i;
local int C;
if (aDuff != None) {                                                        
i = 0;                                                                    
while (i < SpecialDuffEvents.Length) {                                    
if (SpecialDuffEvents[i].OriginalEvent == aDuff) {                      
SpecialDuffEvents[i].OriginalEvent.AbortEvent();                      
C = SpecialDuffEvents.Length;                                         
SpecialDuffEvents[i] = SpecialDuffEvents[C - 1];                      
SpecialDuffEvents.Length = C - 1;                                     
return;                                                               
}
++i;                                                                    
}
}
}
final function sv_AddSpecialDuffEvent(export editinline FSkill_Event_Duff aDuff) {
local int C;
local export editinline FSkill_Event outEvent;
local AimingInfo AimingInfo;
AimingInfo.CameraLocation = Outer.Location;                                 
AimingInfo.CameraRotation = Outer.Rotation;                                 
AimingInfo.PreferredTarget = None;                                          
outEvent = RunEvent(aDuff,Class'FSkill_Event'.65536 | Class'FSkill_Event'.4,None,Outer,Outer,Outer,Outer.Location,AimingInfo,Outer.CharacterStats.mRecord,-1,Outer.Level.TimeSeconds,Class'FSkill_Enums'.8);
C = SpecialDuffEvents.Length;                                               
SpecialDuffEvents.Length = C + 1;                                           
SpecialDuffEvents[C] = FSkill_Event_Duff(outEvent);                         
}
final native function int sv_RemoveSpecialDuffEffect(int UniqueIdentifier);
final native function sv_AddSpecialDuffEffect(export editinline FSkill_EffectClass_Duff aDuff,float aDuration,optional int UniqueIdentifier);
protected native function sv2cl_UpdateComboState_CallStub();
final event sv2cl_UpdateComboState(array<int> aComboString) {
local int i;
local export editinline FSkill_Type Skill;
mComboStringLength = 0;                                                     
i = 0;                                                                      
while (i < aComboString.Length) {                                           
Skill = FSkill_Type(Class'SBDBSync'.GetResourceObject(aComboString[i]));  
if (mComboStringLength < 9 && Skill != None) {                            
mComboString[mComboStringLength].Skill = Skill;                         
mComboStringLength++;                                                   
}
++i;                                                                      
}
OnComboStringChanged(mComboStringLength);                                   
}
final native function sv_ResetComboState(optional bool aReplicate);
final native function sv_PostUpdateComboState(export editinline FSkill_Type aSkill,const out array<Game_Pawn> outTargets);
final native function bool sv_PreUpdateComboState(export editinline FSkill_Type aSkill,float aTime);
final native function bool AllowFinishingMove();
final native function bool sv_GetLastComboSkill(out ComboStringData outData,float TimeFrame);
final native function IncreaseSessionTargetCount(int aSessionID,int aValue);
final native function int GetSessionTargetCount(int aSessionID);
final native function DecreaseSessionRefCount(int aSessionID);
final native function IncreaseSessionRefCount(int aSessionID);
final native function int RegisterSession();
final native function bool IsSkillDisabled(export editinline FSkill_Type aSkill);
protected native function sv2cl_UninstallDisableSkillUseEffect_CallStub();
private final event sv2cl_UninstallDisableSkillUseEffect(int Id) {
UninstallDisableSkillUseEffect(Id);                                         
}
final native function UninstallDisableSkillUseEffect(int Id);
protected native function sv2cl_InstallDisableSkillUseEffect_CallStub();
private final event sv2cl_InstallDisableSkillUseEffect(int aDuffID,int aId) {
local int C;
local DisableSkillUseData dsud;
dsud.Id = aId;                                                              
dsud.effect = FSkill_EffectClass_DuffDisableSkillUse(Class'SBDBSync'.GetResourceObject(aDuffID));
C = DisableSkillUseEffects.Length;                                          
DisableSkillUseEffects.Length = C + 1;                                      
DisableSkillUseEffects[C] = dsud;                                           
}
private final native function sv_UninstallDuffCompletely(out DuffStackData aDuffData);
final native function sv_FireCondition(Game_Pawn aOriginPawn,byte aCondition,optional byte aAttackType,optional byte aMagicType,optional byte aEffectType);
final native function sv_TriggerFireCondition(array<Game_Pawn> aConditionTriggerPawn,Game_Pawn aOriginPawn,byte aCondition,optional byte aAttackType,optional byte aMagicType,optional byte aEffectType);
protected native function ProcessOldEvent(export editinline FSkill_Event aEvent);
protected final event cl_StartSkillTracers(export editinline FSkill_Type aSkillType,export editinline Item_Type aTokenItem,int VarNr) {
local export editinline FSkill_EffectClass_AudioVisual tracerEffect;
local int i;
local float skillDuration;
local export editinline IC_TokenItem itemTokenComponent;
if (aSkillType.WeaponTracer && cl_IsMeleeWeaponEquipped()) {                
skillDuration = aSkillType.GetSkillDuration(Outer,VarNr);                 
if (aTokenItem != None) {                                                 
itemTokenComponent = aTokenItem.GetItemTokenComponent();                
i = 0;                                                                  
while (i < itemTokenComponent.WeaponTracers.Length) {                   
cl_StartTracerEffect(itemTokenComponent.WeaponTracers[i],skillDuration);
i++;                                                                  
}
} else {                                                                  
tracerEffect = FSkill_EffectClass_AudioVisual_Emitter(static.DynamicLoadObject("EffectsPlayerAVGP.Tracers.DoNotRemove.DefaultTracer",Class'FSkill_EffectClass_AudioVisual_Emitter',True));
cl_StartTracerEffect(tracerEffect,skillDuration);                       
}
}
}
private final function bool cl_IsMeleeWeaponEquipped() {
local int mainWeaponIndex;
local export editinline Game_EquippedAppearance equippedAppearance;
local Appearance_Base weaponAppearance;
equippedAppearance = Game_EquippedAppearance(Outer.Appearance.GetCurrent());
if (equippedAppearance != None) {                                           
mainWeaponIndex = equippedAppearance.GetValue(16);                        
if (mainWeaponIndex >= 0) {                                               
weaponAppearance = Appearance_Base(equippedAppearance.GetAppearanceResource(16,mainWeaponIndex));
if (weaponAppearance != None) {                                         
return True;                                                          
}
}
}
return False;                                                               
}
private final function cl_StartTracerEffect(export editinline FSkill_EffectClass_AudioVisual tracerEffect,float Duration) {
Outer.Effects.cl_Start(tracerEffect,Class'Game_Effects'.-1073741824,Class'Game_Effects'.-1073741824.00000000,Class'Game_Effects'.-1073741824.00000000,Duration);
}
protected function cl_AddActiveSkill(int aSkillID,float aStartTime,float aDuration,float aSkillSpeed,bool aFreezeMovement,bool aFreezeRotation,int aTokenItemID,int AnimVarNr,Vector aLocation,Rotator aRotation) {
LastSkill.Skill = FSkill_Type(Class'SBDBSync'.GetResourceObject(aSkillID)); 
LastSkill.StartTime = aStartTime;                                           
LastSkill.Duration = aDuration;                                             
LastSkill.SkillSpeed = aSkillSpeed;                                         
LastSkill.LockedMovement = aFreezeMovement;                                 
LastSkill.LockedRotation = aFreezeRotation;                                 
LastSkill.SpecificTarget = None;                                            
ActiveSkills.Length = ActiveSkills.Length + 1;                              
ActiveSkills[ActiveSkills.Length - 1] = LastSkill;                          
}
protected native function sv2rel_AddActiveSkill_CallStub();
private final event sv2rel_AddActiveSkill(int aSkillID,float aStartTime,float aDuration,float aSkillSpeed,bool aFreezeMovement,bool aFreezeRotation,int aTokenItemID,int AnimVarNr,Vector aLocation,Rotator aRotation) {
cl_AddActiveSkill(aSkillID,aStartTime,aDuration,aSkillSpeed,aFreezeMovement,aFreezeRotation,aTokenItemID,AnimVarNr,aLocation,aRotation);
}
protected native function sv2cl_AddActiveSkill_CallStub();
private final event sv2cl_AddActiveSkill(int aSkillID,float aStartTime,float aDuration,float aSkillSpeed,bool aFreezeMovement,bool aFreezeRotation,int aTokenItemID,int AnimVarNr) {
mTierTimeoutStartTime = -1.00000000;                                        
cl_AddActiveSkill(aSkillID,aStartTime,aDuration,aSkillSpeed,aFreezeMovement,aFreezeRotation,aTokenItemID,AnimVarNr,Outer.Location,Outer.Rotation);
}
protected native function sv2cl_ClearLastSkill_CallStub();
private final event sv2cl_ClearLastSkill() {
local export editinline FSkill_Type oldSkill;
oldSkill = LastSkill.Skill;                                                 
LastSkill.StartTime = 0.00000000;                                           
LastSkill.Duration = 0.00000000;                                            
LastSkill.Skill = None;                                                     
LastSkill.SpecificTarget = None;                                            
if (oldSkill.SkillRollsCombatBar) {                                         
AdvanceToNextTier();                                                      
}
}
protected native function sv2cl_UpdateShareDuffs_CallStub();
private event sv2cl_UpdateShareDuffs(const array<int> transferShareDuffs) {
local int i;
mLastDuffUpdateTime = Outer.Level.TimeSeconds;                              
ShareApplicantEffects.Length = transferShareDuffs.Length;                   
i = 0;                                                                      
while (i < transferShareDuffs.Length) {                                     
ShareApplicantEffects[i].effect = FSkill_EffectClass_DuffShare(Class'SBDBSync'.GetResourceObject(transferShareDuffs[i]));
++i;                                                                      
}
}
protected native function sv2clrel_UpdateDuffs_CallStub();
private event sv2clrel_UpdateDuffs(array<TransferDuffStackData> aTransferDuffs) {
local int i;
ClientDuffList.Length = aTransferDuffs.Length;                              
mLastDuffUpdateTime = Outer.Level.TimeSeconds;                              
i = 0;                                                                      
while (i < aTransferDuffs.Length) {                                         
ClientDuffList[i].ActualStackCount = aTransferDuffs[i].ActualStackCount;  
ClientDuffList[i].OriginalDuff = FSkill_Event_Duff(Class'SBDBSync'.GetResourceObject(aTransferDuffs[i].OriginalDuffID));
ClientDuffList[i].ApplyTime = aTransferDuffs[i].ApplyTime;                
ClientDuffList[i].Duration = aTransferDuffs[i].Duration;                  
++i;                                                                      
}
}
private final native function CheckSkills(float Now);
protected final native function StartSkillAnimation(export editinline FSkill_Type aType,int aVarNr,float aSkillSpeed);
protected native function cl2sv_ExecuteL_CallStub();
private final native event cl2sv_ExecuteL(int aSkillID,Vector aTargetLocation,float aTime);
protected native function cl2sv_ExecuteT_CallStub();
private final native event cl2sv_ExecuteT(int aSkillID,Game_Pawn aSpecificTarget,float aTime);
protected native function cl2sv_Execute_CallStub();
private final native event cl2sv_Execute(int aSkillID,float aTime);
protected native function cl2sv_ExecuteIndexL_CallStub();
private final native event cl2sv_ExecuteIndexL(int aSkillIndex,Vector aTargetLocation,Vector aCameraLocation,Rotator aCameraRotation,Game_Pawn aPreferredTarget,float aTime);
protected native function cl2sv_ExecuteIndex_CallStub();
private final native event cl2sv_ExecuteIndex(int aSkillIndex,Vector aCameraLocation,Rotator aCameraRotation,Game_Pawn aPreferredTarget,float aTime);
protected native function AdvanceToNextTier();
protected native function RollbackToFirstTier();
protected native function sv2clrel_RunEventL_CallStub();
final event sv2clrel_RunEventL(int aSkillID,int aEventID,int aFlags,Game_Pawn aSkillPawn,Game_Pawn aTriggerPawn,Game_Pawn aTargetPawn,Vector aTargetLocation,float aTime) {
local export editinline FSkill_Type Skill;
local export editinline FSkill_Event aEvent;
local AimingInfo dummyAimingInfo;
Skill = FSkill_Type(Class'SBDBSync'.GetResourceObject(aSkillID));           
aEvent = FSkill_Event(Class'SBDBSync'.GetResourceObject(aEventID));         
if (Skill != None) {                                                        
if (aEvent != None) {                                                     
RunEvent(aEvent,aFlags,Skill,aSkillPawn,aTriggerPawn,aTargetPawn,aTargetLocation,dummyAimingInfo,aSkillPawn.CharacterStats.mRecord,-1,aTime,Class'FSkill_Enums'.8);
goto jl00B1;                                                            
}
goto jl00B4;                                                              
}
}
protected native function sv2clrel_RunEvent_CallStub();
final event sv2clrel_RunEvent(int aSkillID,int aEventID,int aFlags,Game_Pawn aSkillPawn,Game_Pawn aTriggerPawn,Game_Pawn aTargetPawn,float aTime) {
local export editinline FSkill_Type Skill;
local export editinline FSkill_Event aEvent;
local Vector cleanVector;
local AimingInfo dummyAimingInfo;
Skill = FSkill_Type(Class'SBDBSync'.GetResourceObject(aSkillID));           
aEvent = FSkill_Event(Class'SBDBSync'.GetResourceObject(aEventID));         
if (Skill != None) {                                                        
if (aEvent != None) {                                                     
RunEvent(aEvent,aFlags,Skill,aSkillPawn,aTriggerPawn,aTargetPawn,cleanVector,dummyAimingInfo,aSkillPawn.CharacterStats.mRecord,-1,aTime,Class'FSkill_Enums'.8);
goto jl00B1;                                                            
}
goto jl00B4;                                                              
}
}
final native function FSkill_Event RunEvent(export editinline FSkill_Event aEvent,int aFlags,export editinline FSkill_Type aSkill,Game_Pawn aSkillPawn,Game_Pawn aTriggerPawn,Game_Pawn aTargetPawn,Vector aTargetLocation,AimingInfo aAimingInfo,const out CharacterStatsRecord aState,int aSessionID,float aTime,byte aOriginCondition);
native function sv_RemoveDuffs(Object aParameter,optional bool aQueueAbort);
delegate bool RemoveDuffFilter(Object aParameter,export editinline FSkill_Event_Duff aDuffEvent);
final native function sv_DirectSkillEffects(export editinline FSkill_Type Skill,Game_Pawn aTarget);
final native function cl_OnEffectNotify(name NotifyName);
final native function ExecuteL(export editinline FSkill_Type aType,Vector aLocation,float aTime);
final native function ExecuteT(export editinline FSkill_Type aType,Game_Pawn aTarget,float aTime);
final native function Execute(export editinline FSkill_Type aType,float aTime);
final native function ExecuteIndexL(int aSkillIndex,Vector aLocation,AimingInfo aAimingInfo);
native function ExecuteIndex(int aSkillIndex,AimingInfo aAimingInfo);
final native event byte CanActivateSpecificSkill(export editinline FSkill_Type aSkillType,optional bool ReportIssuesToClient);
final native event byte CanActivateSkill();
final native function bool IsAttacking(export out editinline FSkill_Type outAttackingSkill,out float outRelativeTimeSpent);
final function bool HasSkill(export editinline FSkill_Type aSkill) {
local int i;
local int j;
local Game_Controller gc;
gc = Game_Controller(Outer.Controller);                                     
j = aSkill.GetResourceId();                                                 
i = 0;                                                                      
while (i < gc.DBCharacterSkills.Length) {                                   
if (gc.DBCharacterSkills[i] == j) {                                       
return True;                                                            
}
++i;                                                                      
}
return False;                                                               
}
final native function ResetAttacking();
native function float GetRelativeTierTimeout();
final native function FSkill_Type GetActiveTierSlotSkill(int aSlot);
final native function sv_LearnSkill(export editinline FSkill_Type aSkill);
protected native function sv2cl_LearnSkill_CallStub();
protected event sv2cl_LearnSkill(int aSkillID) {
local export editinline FSkill_Type learnedSkill;
learnedSkill = FSkill_Type(Class'SBDBSync'.GetResourceObject(aSkillID));    
CharacterSkills[CharacterSkills.Length] = learnedSkill;                     
OnCharacterSkillsChanged();                                                 
}
protected native function cl2sv_LearnSkill_CallStub();
native event cl2sv_LearnSkill(int ResourceId);
final native function bool cl_CharacterHasSkill(export editinline FSkill_Type aSkill);
final native function bool sv_CharacterHasSkill(export editinline FSkill_Type aSkill);
final native function int GetSkilldeckIndex(int aSkilldeckID);
native event cl_OnShutdown();
native function cl_OnFrame(float aDeltaTime);
delegate OnSkillReceivedTokenSlot(export editinline FSkill_Type aSkill,int aNewSlotCount);
protected native function cl2sv_EnableSkillLog_CallStub();
event cl2sv_EnableSkillLog(bool Enable) {
DebugSkillEnabled = Enable;                                                 
}
protected native function sv2cl_OnSkillLog_CallStub();
event sv2cl_OnSkillLog(int loglevel,string aString) {
cl_ParseSkillLogString(aString);                                            
OnSkillLog(loglevel,aString);                                               
}
native function cl_ParseSkillLogString(out string aString);
native function sv_OnSkillLogIndent(int diff);
native function sv_OnSkillLog(int loglevel,string aString);
delegate OnSkillLog(int loglevel,string aString);
delegate OnComboStringChanged(int aStringLength);
delegate OnCharacterSkillsChanged();
delegate OnSkilldeckChanged();
delegate OnRollToNextTier();
delegate OnRollToFirstTier();
*/