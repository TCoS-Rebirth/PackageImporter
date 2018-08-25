﻿using System;
using System.Collections.Generic;
using Engine;
using SBGame;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBAI
{
    [Serializable] public class AI_Script : Annotation_Script
    {
        [FoldoutGroup("AI_Script")]
        public AI_Script NextScript;

        [FoldoutGroup("AI_Script")]
        public bool TriggerNextScript;

        [FoldoutGroup("Debugging")]
        public bool LogDebug;

        public bool acceptsTicks;

        public List<AppliedEffect> AppliedEffects = new List<AppliedEffect>();

        public bool mWantsScriptFrame;

        public float mScriptFrameTime;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float mFrameTimer;

        public AI_Script()
        {
        }

        [Serializable] public struct AppliedEffect
        {
            public Game_Pawn Pawn;

            public int EffectHandle;
        }

        [Serializable] public struct CountEvent
        {
            public string EnterEvent;

            public string EnterUnEvent;

            public string ExitEvent;

            public string ExitUnEvent;

            public Range CountRange;
        }
    }
}
/*
function float GetDayNightTime() {
local Game_GameInfo GameInfo;
GameInfo = Game_GameInfo(GetGameInfo());                                    
ScriptAssert(GameInfo != None && GameInfo.mClock != None,"GetDayNightTime; no clock can be found");
if (GameInfo != None && GameInfo.mClock != None) {                          
return GameInfo.mClock.GetRelativeTimeOfDay();                            
} else {                                                                    
return 0.00000000;                                                        
}
}
function int GetPersistentVariable(Game_Pawn aPawn,export editinline Content_Type aContext,int aValueId) {
local int ContextID;
if (aContext != None) {                                                     
ContextID = aContext.GetResourceId();                                     
}
return Game_Controller(aPawn.Controller).sv_GetPersistentVariable(ContextID,aValueId);
}
function SetPersistentVariable(Game_Pawn aPawn,export editinline Content_Type aContext,int aValueId,int aValue) {
local int ContextID;
ScriptAssert(aPawn != None,"SetPersistentVariable; aPawn is none");         
if (aContext != None) {                                                     
ContextID = aContext.GetResourceId();                                     
}
Game_Controller(aPawn.Controller).sv_SetPersistentVariable(ContextID,aValueId,aValue);
}
function int RandomInt(int aMinValue,int aMaxValue) {
ScriptAssert(aMaxValue >= aMinValue,"RandomInt; maxValue should be bigger than minValue");
return Rand(aMaxValue - aMinValue) + aMinValue;                             
}
function float RandomFloat(float aMinValue,float aMaxValue) {
ScriptAssert(aMaxValue >= aMinValue,"RandomFloat; maxValue should be bigger than minValue");
return FRand() * (aMaxValue - aMinValue) + aMinValue;                       
}
function bool RandomBool() {
if (FRand() > 0.50000000) {                                                 
return True;                                                              
}
return False;                                                               
}
function Despawn(Game_AIController aController) {
ScriptAssert(aController != None,"Despawn; Game_AIController is none");     
aController.sv_Despawn();                                                   
}
function NPC_SkillDeck SetSkilldeck(Game_Pawn aPawn,export editinline NPC_SkillDeck aSkilldeck) {
local export editinline NPC_SkillDeck CurrentSkillDeck;
local export editinline Game_NPCSkills Skills;
ScriptAssert(aPawn != None,"AI_Script - SetSkilldeck: aPawn is none");      
ScriptAssert(aPawn.IsA('Game_NPCPawn'),"AI_Script - SetSkilldeck: aPawn is not a Game_NPCPawn");
ScriptAssert(aSkilldeck != None,"AI_Script - SetSkilldeck: aSkilldeck is none");
Skills = Game_NPCSkills(aPawn.Skills);                                      
ScriptAssert(Skills != None,"AI_Script - SetSkilldeck: pawn doesn't have NPC skills component");
if (aPawn.IsA('Game_NPCPawn') && Skills != None) {                          
CurrentSkillDeck = Skills.CurrentNPCSkillDeck;                            
Skills.sv_SetSkilldeck(aSkilldeck,None);                                  
}
return CurrentSkillDeck;                                                    
}
function SetFreeze(Game_Pawn aPawn,bool aOnOff,bool Movement,bool Rotation,bool Animation,optional bool Stats) {
if (Movement) {                                                             
aPawn.CharacterStats.FreezeMovement(aOnOff);                              
}
if (Rotation) {                                                             
aPawn.CharacterStats.FreezeRotation(aOnOff);                              
}
if (Animation) {                                                            
aPawn.CharacterStats.FreezeAnimation(aOnOff);                             
}
if (Stats) {                                                                
aPawn.CharacterStats.FreezeStats(aOnOff);                                 
}
}
function bool RemoveEachDuff(Object aParameter,export editinline FSkill_Event_Duff aDuffEvent) {
return True;                                                                
}
function RemoveAllDuffs(Game_Pawn aPawn) {
ScriptAssert(aPawn != None,"RemoveAllDuffs; aPawn is none");                
aPawn.Skills.__RemoveDuffFilter__Delegate = RemoveEachDuff;                 
aPawn.Skills.sv_RemoveDuffs(None);                                          
}
function bool RemoveSkillDuff(Object aParameter,export editinline FSkill_Event_Duff aDuffEvent) {
ScriptAssert(aDuffEvent != None,"Duff event is none");                      
ScriptAssert(aDuffEvent.Outer.IsA('FSkill_Type'),"Duff event's outer is not a skill");
if (aDuffEvent != None) {                                                   
if (aDuffEvent.Outer == aParameter) {                                     
return True;                                                            
}
}
return False;                                                               
}
function RemoveSkillDuffs(Game_Pawn aPawn,export editinline FSkill_Type aSkill) {
ScriptAssert(aPawn != None,"RemoveSkillDuffs; aPawn is none");              
ScriptAssert(aSkill != None,"RemoveSkillDuffs; aSkill is none");            
aPawn.Skills.__RemoveDuffFilter__Delegate = RemoveSkillDuff;                
aPawn.Skills.sv_RemoveDuffs(aSkill);                                        
}
function AllPlayerClientTrigger(Game_Pawn aInstigator,string aEventTag) {
local Game_PlayerPawn Player;
ScriptAssert(aEventTag != "None" && aEventTag != "","AllPlayerClientTrigger; no aEventTag found!");
foreach AllActors(Class'Game_PlayerPawn',Player) {                          
ClientSideTrigger(aInstigator,aEventTag,Player);                          
}
}
function ClientSideTrigger(Game_Pawn aInstigator,string aEventTag,Game_PlayerPawn aClient) {
ScriptAssert(aClient != None,"ClientSideTrigger; aClient is none");         
ScriptAssert(aEventTag != "None" && aEventTag != "","ClientSideTrigger; no aEventTag found!");
aClient.sv_ClientSideTrigger(aEventTag,aInstigator);                        
}
function RemoveAudioVisualEffects(Game_Pawn aPawn) {
local int i;
i = 0;                                                                      
while (i < AppliedEffects.Length) {                                         
if (aPawn != None) {                                                      
if (AppliedEffects[i].Pawn == aPawn) {                                  
RemoveAudioVisualEffect(AppliedEffects[i].Pawn,AppliedEffects[i].EffectHandle);
AppliedEffects.Remove(i,1);                                           
i--;                                                                  
}
} else {                                                                  
if (AppliedEffects[i].Pawn != None) {                                   
RemoveAudioVisualEffect(AppliedEffects[i].Pawn,AppliedEffects[i].EffectHandle);
}
AppliedEffects.Remove(i,1);                                             
i--;                                                                    
}
i++;                                                                      
}
}
function bool RemoveAudioVisualEffect(Game_Pawn aPawn,int aServerSideEffectHandle) {
return aPawn.Effects.sv_StopReplicated(aServerSideEffectHandle);            
}
function int ApplyAudioVisualEffect(Game_Pawn aPawn,export editinline FSkill_EffectClass_AudioVisual aEffect) {
local AppliedEffect lEffect;
ScriptAssert(aPawn != None,"ApplyAudioVisualEffect; aPawn is none");        
ScriptAssert(aEffect != None,"ApplyAudioVisualEffect; aEffect is none");    
lEffect.Pawn = aPawn;                                                       
lEffect.EffectHandle = aPawn.Effects.sv_StartReplicated(aEffect);           
AppliedEffects[AppliedEffects.Length] = lEffect;                            
return lEffect.EffectHandle;                                                
}
function bool ApplyOneShotAudioVisualEffect(Game_Pawn aPawn,export editinline FSkill_EffectClass_AudioVisual aEffect) {
local AppliedEffect lEffect;
ScriptAssert(aPawn != None,"ApplyOneShotAudioVisualEffect; aPawn is none"); 
ScriptAssert(aEffect != None,"ApplyOneShotAudioVisualEffect; aEffect is none");
lEffect.Pawn = aPawn;                                                       
lEffect.EffectHandle = aPawn.Effects.sv_StartReplicatedOneShot(aEffect);    
return lEffect.EffectHandle > 0;                                            
}
function RemoveSkillEffectsFromPlayers(export editinline FSkill_Type aSkill) {
local Game_PlayerPawn lPlayer;
ScriptAssert(aSkill != None,"RemoveSkillEffectsFromPlayers: aSkill == none");
foreach AllActors(Class'Game_PlayerPawn',lPlayer) {                         
RemoveSkillDuffs(lPlayer,aSkill);                                         
}
}
function ApplySkillEffectsToPlayers(export editinline FSkill_Type aSkill,Game_Pawn aExecutor) {
local Game_PlayerPawn lPlayer;
ScriptAssert(aSkill != None,"ApplySkillEffectsToPlayers: aSkill == none");  
ScriptAssert(aExecutor != None,"ApplySkillEffectsToPlayers: aExecutor == none");
foreach AllActors(Class'Game_PlayerPawn',lPlayer) {                         
ApplySkillEffects(aSkill,aExecutor,lPlayer);                              
}
}
function bool ApplySkillEffects(export editinline FSkill_Type aSkill,Game_Pawn aExecutor,Game_Pawn aTarget) {
ScriptAssert(aSkill != None,"ApplySkillEffects; aSkill is none");           
ScriptAssert(aExecutor.Skills != None,"ApplySkillEffects; Executing pawn has no skill component");
aExecutor.Skills.sv_DirectSkillEffects(aSkill,aTarget);                     
return True;                                                                
}
function SitStand(Game_AIController aController,bool aSit,Actor aStool) {
local Game_Pawn pwn;
ScriptAssert(aController != None,"Sit; Game_AIController is none");         
pwn = Game_Pawn(aController.Pawn);                                          
if (aStool != None) {                                                       
pwn.SetLocation(aStool.Location);                                         
pwn.SetRotation(aStool.Rotation);                                         
}
pwn.sv_Sit(aSit,aStool != None);                                            
}
function string CharName(Actor aActor) {
local Game_Pawn gp;
local Game_Controller cont;
if (aActor == None) {                                                       
return "None";                                                            
}
cont = Game_Controller(aActor);                                             
if (cont != None) {                                                         
aActor = cont.Pawn;                                                       
}
gp = Game_Pawn(aActor);                                                     
if (gp != None && gp.Character != None) {                                   
return "'" $ gp.Character.sv_GetName()
$ "'";                     
} else {                                                                    
return string(aActor.Name);                                               
}
}
native function ScriptAssert(bool aCheck,string aMessage);
native function Failure(string aWarning);
native function Warning(string aWarning);
native function Debug(string aWarning);
native function string ScriptName();
function FrameOff() {
mScriptFrameTime = -1.00000000;                                             
mFrameTimer = 0.00000000;                                                   
}
function FrameOn(optional float aFrameTime) {
if (aFrameTime < 0.00000000) {                                              
Warning("FrameTick; called with negative time"
@ string(aFrameTime)
@ " this will turn the tick off. Call FrameOff() instead.");
}
mScriptFrameTime = aFrameTime;                                              
mFrameTimer = 0.00000000;                                                   
}
function GetTeam(Game_Pawn aMember,out array<Game_Pawn> oTeam) {
local Game_PlayerController PlayerController;
PlayerController = Game_PlayerController(aMember.Controller);               
if (aMember != None && PlayerController != None) {                          
PlayerController.GroupingTeams.sv_GetTeamMembersOrSolo(oTeam);            
} else {                                                                    
oTeam.Length = 0;                                                         
}
}
function Game_Pawn GetNPC(export editinline NPC_Type aType) {
local Game_NPCPawn someNPC;
foreach AllActors(Class'Game_NPCPawn',someNPC) {                            
if (someNPC.NPCType == aType && !someNPC.IsDead()) {                      
return someNPC;                                                         
}
}
return None;                                                                
}
function Actor GetActor(name aName) {
local Actor someActor;
foreach AllActors(Class'Actor',someActor) {                                 
if (someActor.Name == aName) {                                            
return someActor;                                                       
}
}
return None;                                                                
}
function bool GetInvulnerable(Game_AIController aGame_AIController) {
local Game_Pawn pwn;
ScriptAssert(aGame_AIController != None,"SetInvulnerable; aGame_AIController is none");
pwn = Game_Pawn(aGame_AIController.Pawn);                                   
if (pwn != None) {                                                          
return pwn.IsInvulnerable();                                              
} else {                                                                    
return False;                                                             
}
}
function SetInvulnerable(Game_AIController aGame_AIController,bool aInvulnerable) {
local Game_Pawn pwn;
ScriptAssert(aGame_AIController != None,"SetInvulnerable; aGame_AIController is none");
pwn = Game_Pawn(aGame_AIController.Pawn);                                   
if (pwn != None) {                                                          
pwn.SetInvulnerable(aInvulnerable);                                       
}
}
function ReceiveDamage(Game_AIController aGame_AIController,Game_Pawn aInstigator,float aDamage) {
local Game_Pawn Target;
ScriptAssert(aGame_AIController != None,"TakeDamage; aGame_AIController is none");
if (aInstigator != None) {                                                  
Target = Game_Pawn(aGame_AIController.Pawn);                              
Target.TakeEffectDamage(aDamage,aInstigator,Target.Location,vect(0.000000, 0.000000, 0.000000),Class'DamageType');
} else {                                                                    
aGame_AIController.Pawn.IncreaseHealth(-aDamage);                         
}
}
function DealDamage(Game_AIController aGame_AIController,Game_Pawn aTarget,float aDamage) {
ScriptAssert(aTarget != None,"DealDamage; aTarget is none");                
if (aGame_AIController != None) {                                           
aTarget.TakeEffectDamage(aDamage,Game_Pawn(aGame_AIController.Pawn),aTarget.Location,vect(0.000000, 0.000000, 0.000000),Class'DamageType');
} else {                                                                    
aTarget.IncreaseHealth(-aDamage);                                         
}
}
protected function float GetMaxHealth(Game_AIController aGame_AIController) {
local Game_Pawn pwn;
ScriptAssert(aGame_AIController != None,"GetMaxHealth; aGame_AIController is none");
pwn = Game_Pawn(aGame_AIController.Pawn);                                   
ScriptAssert(pwn != None,"GetMaxHealth; aGame_AIController pawn is none");  
if (pwn != None) {                                                          
return pwn.CharacterStats.mRecord.MaxHealth;                              
} else {                                                                    
return 0.00000000;                                                        
}
}
function float GetHealth(Game_AIController aGame_AIController) {
local Game_Pawn lPawn;
ScriptAssert(aGame_AIController != None,"GetHealth; aGame_AIController is none");
lPawn = Game_Pawn(aGame_AIController.Pawn);                                 
ScriptAssert(lPawn != None,"GetHealth; aGame_AIController pawn is none");   
return lPawn.GetHealth();                                                   
}
function float GetSpeed(Game_AIController aGame_AIController) {
ScriptAssert(aGame_AIController != None,"GetSpeed; aGame_AIController is none");
return Game_Pawn(aGame_AIController.Pawn).CharacterStats.mBaseMovementSpeed;
}
function ResetSpeed(Game_AIController aGame_AIController) {
ScriptAssert(aGame_AIController != None,"ResetSpeed; aGame_AIController is none");
ScriptAssert(Game_NPCPawn(aGame_AIController.Pawn) != None,"ResetSpeed; aGame_AIController is not an NPC");
aGame_AIController.Pawn.GroundSpeed = Game_NPCPawn(aGame_AIController.Pawn).NPCType.GroundSpeed;
aGame_AIController.Pawn.AirSpeed = Game_NPCPawn(aGame_AIController.Pawn).NPCType.AirSpeed;
Game_Pawn(aGame_AIController.Pawn).CharacterStats.mBaseMovementSpeed = Game_Pawn(aGame_AIController.Pawn).CharacterStats.mMovementSpeedDefault;
}
function SetSpeed(Game_AIController aGame_AIController,float newSpeed) {
ScriptAssert(aGame_AIController != None,"SetSpeed; aGame_AIController is none");
ScriptAssert(newSpeed >= 0.00000000,"SetSpeed; newSpeed is negative");      
aGame_AIController.Pawn.GroundSpeed = newSpeed;                             
aGame_AIController.Pawn.AirSpeed = newSpeed;                                
Game_Pawn(aGame_AIController.Pawn).CharacterStats.mBaseMovementSpeed = newSpeed;
}
function Vector GetHomeLocation(Game_AIController aGame_AIController) {
ScriptAssert(aGame_AIController != None,"AIScript.SetHomeLocation; aGame_AIController != none");
return aGame_AIController.GetHomeLocation();                                
}
function SetHomeLocation(Game_AIController aGame_AIController,Vector aHomeLocation) {
ScriptAssert(aGame_AIController != None,"AIScript.SetHomeLocation; aGame_AIController != none");
if (!aGame_AIController.SetHomeLocation(aHomeLocation)) {                   
Warning("Failed to set homelocation" @ string(aHomeLocation)
@ "for"
@ CharName(aGame_AIController));
}
}
function float Distance(Game_AIController aGame_AIController,Actor anActor) {
ScriptAssert(aGame_AIController != None,"AIScript.Distance; aGame_AIController != none");
ScriptAssert(anActor != None,"AIScript.Distance; anActor != none");         
return VSize(aGame_AIController.Pawn.Location - anActor.Location);          
}
function Vector GetLocation(Game_AIController aGame_AIController) {
ScriptAssert(aGame_AIController != None,"AIScript.GetLocation; aGame_AIController != none");
return aGame_AIController.Pawn.Location;                                    
}
function bool ChangeToNextScript(Game_AIController aGame_AIController,optional Pawn aInstigator) {
if (NextScript != None) {                                                   
SwitchScript(aGame_AIController,self,NextScript);                         
if (TriggerNextScript) {                                                  
if (aInstigator == None) {                                              
aInstigator = aGame_AIController.Pawn;                                
}
NextScript.Trigger(self,aInstigator);                                   
}
return True;                                                              
}
return False;                                                               
}
function SwitchScript(Game_AIController aGame_AIController,AI_Script oldScript,AI_Script NewScript) {
ScriptAssert(aGame_AIController != None,"AIScript.SwitchScript; aGame_AIController != none");
ScriptAssert(oldScript != None,"AIScript.SwitchScript; oldScript is none"); 
ScriptAssert(NewScript != None,"AIScript.SwitchScript; newScript is none"); 
ScriptAssert(aGame_AIController.HasMetaController(oldScript),"AIScript.SwitchScript; oldScript is not running for that controller");
ScriptAssert(!aGame_AIController.HasMetaController(NewScript),"AIScript.SwitchScript; newScript is already running for that controller");
if (aGame_AIController != None) {                                           
if (oldScript != None
&& aGame_AIController.HasMetaController(oldScript)) {
aGame_AIController.MetaControllerMessage(5,oldScript);                  
oldScript.OnEnd(aGame_AIController);                                    
aGame_AIController.RemoveMetaController(oldScript);                     
}
if (NewScript != None
&& !aGame_AIController.HasMetaController(NewScript)) {
aGame_AIController.AddMetaController(NewScript);                        
NewScript.OnBegin(aGame_AIController);                                  
aGame_AIController.MetaControllerMessage(4,NewScript);                  
}
}
}
function StopScript(Game_AIController aGame_AIController,AI_Script oldScript) {
ScriptAssert(aGame_AIController != None,"AIScript.StopScript; aGame_AIController is none");
ScriptAssert(oldScript != None,"AIScript.StopScript; oldScript is none");   
ScriptAssert(aGame_AIController.HasMetaController(oldScript),"AIScript.StopScript; oldScript is not running for that controller");
if (aGame_AIController != None && oldScript != None
&& aGame_AIController.HasMetaController(oldScript)) {
aGame_AIController.MetaControllerMessage(5,oldScript);                    
oldScript.OnEnd(aGame_AIController);                                      
aGame_AIController.RemoveMetaController(oldScript);                       
}
}
function StartScript(Game_AIController aGame_AIController,AI_Script NewScript) {
ScriptAssert(aGame_AIController != None,"AIScript.StartScript; aGame_AIController is none");
ScriptAssert(NewScript != None,"AIScript.StartScript; newScript is none");  
ScriptAssert(!aGame_AIController.HasMetaController(NewScript),"AIScript.StartScript; newScript is already running for that controller");
if (aGame_AIController != None && NewScript != None
&& !aGame_AIController.HasMetaController(NewScript)) {
aGame_AIController.AddMetaController(NewScript);                          
NewScript.OnBegin(aGame_AIController);                                    
aGame_AIController.MetaControllerMessage(4,NewScript);                    
}
}
function StopTimer(Game_AIController aGame_AIController,name aTimer) {
ScriptAssert(aGame_AIController != None,"StopTimer; aGame_AIController is none");
aGame_AIController.RemoveTimer(aTimer);                                     
}
function StartTimer(Game_AIController aGame_AIController,name aTimer,float aTime) {
ScriptAssert(aGame_AIController != None,"StartTimer; aGame_AIController is none");
aGame_AIController.SetTimerTimeout(self,aTimer,aTime);                      
}
function PerformEmote(Game_AIController aGame_AIController,byte aEmote) {
local Game_Pawn aPawn;
aPawn = Game_Pawn(aGame_AIController.Pawn);                                 
ScriptAssert(aPawn != None,"AI_Script Emote: aPawn is none");               
if (aEmote > 0) {                                                           
aPawn.Emotes.sv_PlayContentEmote(aEmote);                                 
}
}
function LocalizedChat(Game_AIController aGame_AIController,LocalizedString aText,optional Object aTopic,optional Object aTarget) {
local Game_NPCPawn npcPawn;
local Game_Pawn pawnTarget;
local int topicId;
local int targetId;
ScriptAssert(aGame_AIController != None,"LocalizedChat; aGame_AIController is none");
npcPawn = Game_NPCPawn(aGame_AIController.Pawn);                            
ScriptAssert(aGame_AIController != None,"LocalizedChat; aGame_AIController has no NPC Pawn");
if (aTopic.IsA('Content_Type')) {                                           
topicId = Content_Type(aTopic).GetResourceId();                           
}
if (aTarget.IsA('Content_Type')) {                                          
targetId = Content_Type(aTarget).GetResourceId();                         
pawnTarget = None;                                                        
} else {                                                                    
pawnTarget = Game_Pawn(aTarget);                                          
targetId = 0;                                                             
}
npcPawn.sv2rel_Chat_CallStub(aText.Id,topicId,targetId,pawnTarget);         
}
function SetHealth(Game_AIController aGame_AIController,float aNewHealth,optional bool aIsRelative) {
local Game_Pawn lPawn;
ScriptAssert(aGame_AIController != None,"SetHealth; aGame_AIController is none");
lPawn = Game_Pawn(aGame_AIController.Pawn);                                 
ScriptAssert(lPawn != None,"SetHealth; aGame_AIController Pawn is none");   
if (aIsRelative) {                                                          
lPawn.SetHealth(lPawn.GetHealth() + aNewHealth);                          
} else {                                                                    
lPawn.SetHealth(aNewHealth);                                              
}
}
protected function sv_DBQuestProgressSet(bool success,array<DatabaseRow> rows,int auto_increment_id,int affected_rows,int UserData) {
if (!success) {                                                             
Error("DB Quest progress for character"
@ string(UserData)
@ "failed");
}
}
function SetDBQuestProgress(int aCharacterId,export editinline Quest_Type aQuest,int aObjective,int aProgress) {
local SBDBAsyncCallback callback;
ScriptAssert(aCharacterId != 0,"SetQuestProgress; aCharacterId is invalid");
ScriptAssert(aQuest != None,"SetQuestProgress; Quest_Type is none");        
callback.ObjectName = static.GetFName();                                    
callback.funcName = name("sv_DBQuestProgressSet");                          
callback.UserData = aCharacterId;                                           
Class'SBDBAsync'.SetQuestObjective(None,aCharacterId,aQuest.Targets[aObjective].GetResourceId(),aProgress,callback);
}
function SetQuestProgress(Game_Pawn aPawn,export editinline Quest_Type aQuest,int aObjective,int aProgress,optional Game_Pawn aTargetPawn) {
local Game_PlayerPawn playerPawn;
ScriptAssert(aPawn != None,"SetQuestProgress; aPawn is none");              
ScriptAssert(aQuest != None,"SetQuestProgress; Quest_Type is none");        
playerPawn = Game_PlayerPawn(aPawn);                                        
if (playerPawn != None) {                                                   
if (aObjective < aQuest.Targets.Length) {                                 
playerPawn.questLog.sv_SetTargetProgress(aQuest.Targets[aObjective],aProgress,aTargetPawn);
}
}
}
function FireScriptHook(Game_Controller aDestination,name aTag,optional int aNumParam) {
local name StoreTag;
ScriptAssert(aDestination != None,"FireScriptHook; aDestination is none");  
StoreTag = Tag;                                                             
Tag = aTag;                                                                 
aDestination.sv_FireHook(Class'Content_Type'.13,self,aNumParam);            
Tag = StoreTag;                                                             
}
function FireHook(Game_Controller aDestination,byte aHook,Object aObjParam,int aNumParam) {
ScriptAssert(aDestination != None,"FireHook; aDestination is none");        
aDestination.sv_FireHook(aHook,aObjParam,aNumParam);                        
}
function PlayControllerSound(Game_AIController aGame_AIController,string SoundName) {
local Sound ASound;
ScriptAssert(aGame_AIController != None,"PlayGame_AIControllerSound; aGame_AIController is none");
ASound = Sound(static.DynamicLoadObject(SoundName,Class'Sound',True));      
ScriptAssert(ASound != None,"PlayGame_AIControllerSound; provided soundName cannot be found");
if (ASound != None) {                                                       
aGame_AIController.Pawn.PlaySound(ASound);                                
}
}
event OnDetach(Game_AIController aController,AIPoint aPoint) {
Debug("Detached" @ CharName(aController)
@ "from"
@ string(aPoint));
aController.MetaControllerMessage(5,self);                                  
OnEnd(aController);                                                         
Super.OnDetach(aController,aPoint);                                         
}
event OnAttach(Game_AIController aController,AIPoint aPoint) {
Super.OnAttach(aController,aPoint);                                         
OnBegin(aController);                                                       
aController.MetaControllerMessage(4,self);                                  
Debug("Attached" @ CharName(aController)
@ "to"
@ string(aPoint));
}
function PlayControllerAnimation(Game_AIController aGame_AIController,byte variation,byte flag1,optional byte flag2,optional byte flag3,optional bool isLooping) {
ScriptAssert(aGame_AIController != None,"PlayGame_AIControllerAnimation; aGame_AIController is none");
ScriptAssert(aGame_AIController.Pawn != None,"PlayGame_AIControllerAnimation; aGame_AIController has a none pawn");
if (aGame_AIController.Pawn != None) {                                      
Base_Pawn(aGame_AIController.Pawn).sv_ForwardAnimation(flag1,flag2,flag3,variation,isLooping);
}
}
function AdjustHormone(Game_AIController aGame_AIController,name Hormone,float aRate) {
if (aRate < -1.00000000) {                                                  
aRate = -1.00000000;                                                      
}
if (aRate > 1.00000000) {                                                   
aRate = 1.00000000;                                                       
}
aGame_AIController.mHypothalamus.AdjustHormone(Hormone,aRate);              
}
function Flee(Game_AIController aGame_AIController) {
ScriptAssert(aGame_AIController != None,"Flee; aGame_AIController is none");
aGame_AIController.StateSignal(45);                                         
}
function Patrol(Game_AIController aGame_AIController,AIPoint aFrom) {
ScriptAssert(aGame_AIController != None,"Patrol; aGame_AIController is none");
ScriptAssert(!IsAIPaused(aGame_AIController)
&& !IsAIOff(aGame_AIController),"Patrol; NPC's standard AI is not running");
ScriptAssert(aFrom != None,"Patrol; aFrom is none");                        
aGame_AIController.SetControlPoint(aFrom);                                  
aGame_AIController.StateSignal(47);                                         
}
function Aggro(Game_AIController aGame_AIController) {
ScriptAssert(aGame_AIController != None,"Aggro; aGame_AIController is none");
ScriptAssert(!IsAIPaused(aGame_AIController)
&& !IsAIOff(aGame_AIController),"Aggro; NPC's standard AI is not running");
aGame_AIController.StateSignal(43);                                         
}
function ReturnHome(Game_AIController aGame_AIController,optional Vector aReturnLocation) {
ScriptAssert(aGame_AIController != None,"ReturnHome; aGame_AIController is none");
ScriptAssert(!IsAIPaused(aGame_AIController)
&& !IsAIOff(aGame_AIController),"ReturnHome; NPC's standard AI is not running");
if (aReturnLocation != vect(0.000000, 0.000000, 0.000000)) {                
aGame_AIController.SetHomeLocation(aReturnLocation);                      
}
aGame_AIController.StateSignal(44);                                         
}
function Idle(Game_AIController aGame_AIController) {
ScriptAssert(aGame_AIController != None,"Idle; aGame_AIController is none");
ScriptAssert(!IsAIPaused(aGame_AIController)
&& !IsAIOff(aGame_AIController),"Idle; NPC's standard AI is not running");
aGame_AIController.StateSignal(41);                                         
}
function Follow(Game_AIController aGame_AIController,optional float aDistance) {
ScriptAssert(aGame_AIController != None,"Follow; aGame_AIController is none");
ScriptAssert(!IsAIPaused(aGame_AIController)
&& !IsAIOff(aGame_AIController),"Follow; NPC's standard AI is not running");
if (aDistance > 0.00000000) {                                               
aGame_AIController.FollowRange = aDistance;                               
}
aGame_AIController.StateSignal(46);                                         
}
function EndConversation(Game_AIController aSpeaker,optional Game_Pawn aPartner) {
ScriptAssert(aSpeaker != None,"EndConversation; aSpeaker is none");         
ScriptAssert(IsAIPaused(aSpeaker) || IsAIOff(aSpeaker),"EndConversation; NPC's standard AI is still running");
if (aPartner != None) {                                                     
aSpeaker.ConversationControl.EndConversation(aPartner);                   
} else {                                                                    
aSpeaker.ConversationControl.EndAllConversations();                       
}
}
function bool StartConversation(Game_AIController aSpeaker,Game_Pawn aPartner,export editinline Conversation_Topic aTopic) {
local export editinline Conversation_Topic convTopic;
local export editinline Conversation_Node convState;
local Game_Controller partnerController;
ScriptAssert(IsAIPaused(aSpeaker) || IsAIOff(aSpeaker),"StartConversation; NPC's standard AI is still running");
ScriptAssert(aSpeaker != None,"StartConversation; aSpeaker is none");       
ScriptAssert(aPartner != None,"StartConversation; aPartner is none");       
if (aPartner == None) {                                                     
return False;                                                             
}
partnerController = Game_Controller(aPartner.Controller);                   
ScriptAssert(partnerController != None,"StartConversation; Partner doesn't have a controller");
if (!aSpeaker.ConversationControl.CanConverse(aPartner)) {                  
Warning("StartConversation; AI script: speaker can't converse");          
return False;                                                             
}
if (!partnerController.ConversationControl.CanConverse(Game_Pawn(aSpeaker.Pawn))) {
Warning("StartConversation; AI script: partner can't converse");          
return False;                                                             
}
aSpeaker.StateSignal(48);                                                   
convTopic = aTopic;                                                         
ScriptAssert(convTopic != None,"StartConversation; no conversation"
@ string(aTopic)
@ "found in Speaker NPC Type");
convState = convTopic.CheckConversation(Game_Pawn(aSpeaker.Pawn),aPartner); 
if (convState == None) {                                                    
Warning("StartConversation; AI script: nothing to talk about");           
return False;                                                             
}
aSpeaker.ConversationControl.Converse(aPartner,convTopic,convState);        
return True;                                                                
}
function bool HasWeaponDrawn(Game_AIController aGame_AIController) {
local export editinline Game_NPCCombatState combatState;
ScriptAssert(aGame_AIController != None,"HasWeaponDrawn; Game_AIController is none");
combatState = Game_NPCCombatState(Game_Pawn(aGame_AIController.Pawn).combatState);
ScriptAssert(combatState != None,"HasWeaponDrawn; NPC has no NPC combat state");
return combatState.CombatReady();                                           
}
function bool sheathWeapon(Game_AIController aGame_AIController) {
local export editinline Game_NPCCombatState combatState;
ScriptAssert(aGame_AIController != None,"SheathWeapon; Game_AIController is none");
ScriptAssert(IsAIPaused(aGame_AIController) || IsAIOff(aGame_AIController),"SheathWeapon; NPC's standard AI is still running");
combatState = Game_NPCCombatState(Game_Pawn(aGame_AIController.Pawn).combatState);
ScriptAssert(combatState != None,"SheathWeapon; NPC has no NPC combat state");
if (!combatState.CombatReady()) {                                           
return True;                                                              
} else {                                                                    
return combatState.EnsureIdle();                                          
}
}
function bool DrawWeapon(Game_AIController aGame_AIController,optional byte aPreferedMode) {
local export editinline Game_NPCCombatState combatState;
ScriptAssert(aGame_AIController != None,"DrawWeapon; Game_AIController is none");
ScriptAssert(IsAIPaused(aGame_AIController) || IsAIOff(aGame_AIController),"DrawWeapon; NPC's standard AI is still running");
combatState = Game_NPCCombatState(Game_Pawn(aGame_AIController.Pawn).combatState);
ScriptAssert(combatState != None,"DrawWeapon; NPC has no NPC combat state");
if (combatState.CombatReady()) {                                            
combatState.sv_SwitchToMode(aPreferedMode);                               
return True;                                                              
} else {                                                                    
return combatState.EnsureCombat(aPreferedMode);                           
}
}
function bool CanPerformSkill(Game_AIController aGame_AIController,export editinline FSkill_Type aSkill) {
local Game_Pawn pwn;
ScriptAssert(aGame_AIController != None,"CanPerformSkill; Game_AIController is none");
ScriptAssert(aSkill != None,"CanPerformSkill; aSkill is none");             
pwn = Game_Pawn(aGame_AIController.Pawn);                                   
if (!pwn.combatState.CombatReady()) {                                       
return False;                                                             
} else {                                                                    
if (!pwn.combatState.sv_CanSwitchToWeapon(aSkill.RequiredWeapon)) {       
return False;                                                           
} else {                                                                  
if (pwn.Skills.CanActivateSpecificSkill(aSkill) != 0) {                 
return False;                                                         
} else {                                                                
return True;                                                          
}
}
}
}
function PerformSkill(Game_AIController aGame_AIController,export editinline FSkill_Type aSkill,Vector aTarget) {
local Game_Pawn pwn;
ScriptAssert(aGame_AIController != None,"PerfomSkill; Game_AIController is none");
ScriptAssert(aSkill != None,"PerfomSkill; aSkill is none");                 
ScriptAssert(IsAIPaused(aGame_AIController) || IsAIOff(aGame_AIController),"PerformSkill; NPC's standard AI is still running");
pwn = Game_Pawn(aGame_AIController.Pawn);                                   
if (pwn.Skills.CanActivateSpecificSkill(aSkill) == 0) {                     
if (aTarget != vect(0.000000, 0.000000, 0.000000)) {                      
pwn.Skills.ExecuteL(aSkill,aTarget,aGame_AIController.Level.TimeSeconds);
} else {                                                                  
pwn.Skills.Execute(aSkill,aGame_AIController.Level.TimeSeconds);        
}
}
}
function LookAt(Game_AIController aGame_AIController,Vector Target) {
ScriptAssert(aGame_AIController != None,"LookAt; aGame_AIController is none");
ScriptAssert(IsAIPaused(aGame_AIController) || IsAIOff(aGame_AIController),"LookAt; NPC's standard AI is still running");
aGame_AIController.mTargeting.SetLocation(Target);                          
}
function bool IsDetecting(Game_AIController aGame_AIController) {
ScriptAssert(aGame_AIController != None,"IsDetecting; aGame_AIController is none");
return aGame_AIController.mTargeting.IsDetecting();                         
}
function SetDetection(Game_AIController aGame_AIController,bool aOnOff) {
ScriptAssert(aGame_AIController != None,"SetDetection; aGame_AIController is none");
aGame_AIController.mTargeting.SetDetection(aOnOff);                         
}
function SetTarget(Game_AIController aGame_AIController,Actor aTarget) {
ScriptAssert(aGame_AIController != None,"SetTarget; aGame_AIController is none");
ScriptAssert(aTarget != None,"SetTarget; aTarget is none");                 
ScriptAssert(IsAIPaused(aGame_AIController) || IsAIOff(aGame_AIController),"SetTarget; NPC's standard AI is still running");
if (aTarget != None) {                                                      
aGame_AIController.mTargeting.SetActor(aTarget);                          
} else {                                                                    
aGame_AIController.mTargeting.SetDisabled();                              
}
}
function bool IsMoving(Game_AIController aGame_AIController) {
ScriptAssert(aGame_AIController != None,"IsMoving; aGame_AIController is none");
return aGame_AIController.mMovement.MoveMode != 0;                          
}
function StopMovement(Game_AIController aGame_AIController) {
ScriptAssert(aGame_AIController != None,"StopMovement; aGame_AIController is none");
ScriptAssert(IsAIPaused(aGame_AIController) || IsAIOff(aGame_AIController),"StopMovement; NPC's standard AI is still running");
aGame_AIController.mMovement.NoMovement();                                  
}
function bool Teleport(Game_AIController aGame_AIController,Vector aLocation,float aRadius) {
local Vector loc;
local Game_Pawn pwn;
local Vector OldLocation;
ScriptAssert(aGame_AIController != None,"Teleport; aGame_AIController is none");
ScriptAssert(IsAIPaused(aGame_AIController) || IsAIOff(aGame_AIController),"Teleport; NPC's standard AI is still running");
pwn = Game_Pawn(aGame_AIController.Pawn);                                   
if (pwn != None) {                                                          
OldLocation = pwn.Location;                                               
pwn.SetLocation(aLocation);                                               
loc = Class'Content_API'.RandomRadiusLocation(pwn,aRadius,aRadius,True,pwn.GetCollisionExtent(),pwn.IsGrounded());
if (loc != vect(0.000000, 0.000000, 0.000000)) {                          
return pwn.sv_TeleportTo(loc,pwn.DesiredRotation);                      
} else {                                                                  
pwn.SetLocation(OldLocation);                                           
return False;                                                           
}
} else {                                                                    
return False;                                                             
}
}
function SetControllerLocation(Game_AIController aGame_AIController,Vector NewLocation) {
local Game_Pawn pwn;
ScriptAssert(aGame_AIController != None,"SetLocation; aGame_AIController is none");
ScriptAssert(IsAIPaused(aGame_AIController) || IsAIOff(aGame_AIController),"SetControllerLocation; NPC's standard AI is still running");
pwn = Game_Pawn(aGame_AIController.Pawn);                                   
if (pwn != None) {                                                          
aGame_AIController.SetLocation(NewLocation);                              
pwn.sv_TeleportTo(NewLocation,aGame_AIController.Pawn.DesiredRotation);   
}
}
native function bool SetTouching(Game_AIController aGame_AIController,bool aTouch);
function MoveTo(Game_AIController aGame_AIController,Vector aLocation,optional float aRange) {
ScriptAssert(aGame_AIController != None,"MoveTo; aGame_AIController is none");
ScriptAssert(IsAIPaused(aGame_AIController) || IsAIOff(aGame_AIController),"MoveTo; NPC's standard AI is still running");
if (aGame_AIController != None) {                                           
if (aRange <= 0.00000000) {                                               
aGame_AIController.mMovement.MoveTo(aLocation);                         
} else {                                                                  
aGame_AIController.mMovement.Approach(aLocation,aRange);                
}
}
}
function bool InAIState(Game_AIController aController,name StateClass) {
ScriptAssert(aController != None,"InAIState; Game_AIController is none");   
if (aController.mStateMachine != None) {                                    
if (aController.mStateMachine.mCurrentState.IsA(StateClass)) {            
return True;                                                            
}
}
return False;                                                               
}
function bool IsAIOff(Game_AIController aController) {
ScriptAssert(aController != None,"IsAIOff; Game_AIController is none");     
return aController.mAbortedMachine == None
&& aController.mStateMachine == None;
}
function bool IsAIPaused(Game_AIController aController) {
ScriptAssert(aController != None,"IsAIPaused; Game_AIController is none");  
if (aController != None) {                                                  
return aController.IsAIPaused();                                          
} else {                                                                    
return False;                                                             
}
}
function bool HasPausedAI(Game_AIController aController) {
ScriptAssert(aController != None,"HasPausedAI; Game_AIController is none"); 
if (aController != None) {                                                  
return aController.IsAIPausedBy(self);                                    
} else {                                                                    
return False;                                                             
}
}
function ContinueAI(Game_AIController aController) {
ScriptAssert(aController != None,"ContinueAI; Game_AIController is none");  
Debug("continued AI for" @ string(aController));                            
if (aController != None) {                                                  
aController.ContinueAI(self);                                             
}
}
function PauseAI(Game_AIController aController) {
ScriptAssert(aController != None,"PauseAI; Game_AIController is none");     
Debug("pause AI for" @ string(aController));                                
if (aController != None) {                                                  
aController.PauseAI(self);                                                
}
}
function AIStateMachine SwapStateMachine(Game_AIController aController,AIStateMachine aNewMachine) {
ScriptAssert(aController != None,"SwapStateMachine; Game_AIController is none");
return aController.SetStateMachine(aNewMachine);                            
}
protected native function AI_Script SpawnScript(class<AI_Script> SpawnClass);
protected event AutoFix() {
}
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local ActorRelation newRelation;
if (NextScript != None) {                                                   
newRelation.mActor = NextScript;                                          
newRelation.mDescription = "NextScript:" @ string(NextScript.Name);       
newRelation.mColour = static.RGB(255,255,50);                             
oRelations[oRelations.Length] = newRelation;                              
}
}
protected event sv_OnScriptFrame(float DeltaTime) {
}
*/