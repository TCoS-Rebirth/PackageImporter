﻿using System;
using System.Collections.Generic;
using Engine;
using SBBase;
using UnityEngine;

namespace SBGame
{
#pragma warning disable 414   

    [Serializable]
    public class Game_PlayerPawn: Game_PersistentPawn
    {
        public const float PVP_SETTINGS_UPDATE_TIME = 1F;
        public const float LEVEL_AREA_UPDATE_TIME = 1F;

        public Game_QuestLog questLog;

        [NonSerialized, HideInInspector]
        public DB_Guild mGuild;

        [NonSerialized, HideInInspector]
        public DB_Team mTeam;

        [NonSerialized, HideInInspector]
        public Vector mNetVelocity;

        [NonSerialized, HideInInspector]
        public Vector mNetLocation;

        [NonSerialized, HideInInspector]
        public EPhysics mNetPhysics;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private byte mCurrentFrameID;

        [NonSerialized, HideInInspector]
        public byte mMoveFrameID;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private float mMovementTime;

        float mUpdateInterval;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private float mCurrentMoveTimer;

        [NonSerialized, HideInInspector]
        public LevelAreaVolume mCurrentLevelArea;

        [NonSerialized, HideInInspector]
        public LevelAreaVolume mCurrentShard;

        [NonSerialized, HideInInspector]
        private int mCurrentShardID;

        [NonSerialized, HideInInspector]
        private int mCurrentMapSectionID;

        [NonSerialized, HideInInspector]
        public PvPSettings mPvPSettings;

        [NonSerialized, HideInInspector]
        public float mPvPTimer;

        public void SetMovementUpdateFrequency(int aFrequency)
        {
            if (aFrequency > 0 && aFrequency <= 16)
            {
                mUpdateInterval = 1f / aFrequency;
            }
            Debug.LogWarning("mUpdateInterval is currently unused");
        }

        public override void WriteLoginStream(IPacketWriter writer)
        {
            writer.WriteVector(Velocity);
            writer.WriteVector3(transform.position);
            writer.WriteByte((byte)Physics);
            writer.WriteByte(mMoveFrameID);
            writer.WriteByte((byte)GetState());
            writer.WriteInt32(bInvulnerable ? 1 : 0);
            writer.WriteFloat(GroundSpeedModifier);
            writer.WriteInt32(mDebugFilters);
            writer.WriteInt32(Visibility);
            CharacterStats.WriteLoginStream(writer);
            Effects.WriteLoginStream(writer);
        }

        public override void Initialize()
        {
            base.Initialize();
            if (questLog != null) questLog.Initialize(this);
        }

        public override int GetCharacterID()
        {
            return (Controller as Game_PlayerController).DBCharacter.Id;
        }

    }
}
/*
event PlayerStart sv_GetResurrectPlayerStart() {
local string spawnPointTag;
local PhysicsVolume pv;
if (mCurrentLevelArea != None
&& Len(mCurrentLevelArea.RespawnPoint) != 0) {
spawnPointTag = mCurrentLevelArea.RespawnPoint;                           
} else {                                                                    
foreach TouchingActors(Class'PhysicsVolume',pv) {                         
if (Len(pv.RespawnPoint) != 0) {                                        
spawnPointTag = pv.RespawnPoint;                                      
} else {                                                                
}
}
if (Len(spawnPointTag) == 0 && Region.Zone != None
&& Len(Region.Zone.RespawnPoint) != 0) {
spawnPointTag = Region.Zone.RespawnPoint;                               
}
}
return Game_GameInfo(GetGameInfo()).sv_GetPlayerStart(spawnPointTag);       
}
function sv_Resurrect() {
local PlayerStart spawnPoint;
if (IsDead()) {                                                             
spawnPoint = sv_GetResurrectPlayerStart();                                
sv_TeleportTo(spawnPoint.Location,spawnPoint.Rotation);                   
CharacterStats.sv_Resurrect();                                            
TriggerEvent(spawnPoint.Event,spawnPoint,self);                           
Class'Actor'.static.GetGameEngine().GGameInfo.PlayerRespawned(Controller);
}
}
protected native function cl2sv_Resurrect_CallStub();
event cl2sv_Resurrect() {
sv_Resurrect();                                                             
}
protected native function sv2cl_FreeToPlayLevelCapped_CallStub();
event sv2cl_FreeToPlayLevelCapped() {
local export editinline Help_Article Article;
Article = Help_Article(Class'SBDBSync'.GetResourceObject(156527));          
Game_PlayerStats(CharacterStats).mFreeToPlayLimitReached = True;            
Game_Desktop(Game_PlayerController(Controller).Player.GUIDesktop).UpdateStdWindow(1,0,None,"");
Game_Desktop(Game_PlayerController(Controller).Player.GUIDesktop).ShowMessageBox(Article.Title.Text,Article.Body.Text);
}
protected native function sv2cl_FreeToPlayPortalForbidden_CallStub();
event sv2cl_FreeToPlayPortalForbidden() {
local export editinline Help_Article Article;
Article = Help_Article(Class'SBDBSync'.GetResourceObject(156527));          
Game_Desktop(Game_PlayerController(Controller).Player.GUIDesktop).ShowMessageBox(Article.Title.Text,Article.Body.Text);
}
final native function bool sv_IsFreeToPlayCapped();
final native function bool sv_IsPayingPlayer();
exec function ShakeCombat() {
Game_PlayerCombatStats(CombatStats).cl2sv_ShakeCombat_CallStub();           
}
function cl_SetPet(Game_PetPawn aPET) {
Super.cl_SetPet(aPET);                                                      
if (aPET == None) {                                                         
Game_Desktop(Game_PlayerController(Controller).Player.GUIDesktop).ShowStdWindow(77,2);
cl_AddScrollingCombatMessage(Class'StringReferences'.default.Pet_Lost.Text,17);
} else {                                                                    
if (!LostPet) {                                                           
Game_Desktop(Game_PlayerController(Controller).Player.GUIDesktop).ShowStdWindow(77,1);
} else {                                                                  
LostPet = False;                                                        
PetRelevancyFound.Trigger();                                            
}
}
}
protected native function sv2cl_ClientSideTrigger_CallStub();
protected event sv2cl_ClientSideTrigger(string EventTrigger,Game_Pawn aInstigator) {
TriggerEvent(name(EventTrigger),self,aInstigator);                          
}
function sv_ClientSideTrigger(string EventTrigger,Game_Pawn aInstigator) {
sv2cl_ClientSideTrigger_CallStub(EventTrigger,aInstigator);                 
}
protected native function sv2rel_SendMessage_CallStub();
event sv2rel_SendMessage(string aSender,string aMessage,int aChannel) {
Game_PlayerController(Base_GameClient(Class'Actor'.static.GetGameEngine()).GPlayerController).Chat.cl_OnMessage(aSender,aMessage,aChannel);
}
protected native function cl2sv_UpdateLevelUpAttributes_CallStub();
event cl2sv_UpdateLevelUpAttributes(int aBody,int aMind,int aFocus) {
if (aBody + aMind + aFocus <= Game_PlayerStats(CharacterStats).mAvailableAttributePoints) {
CharacterStats.SetAttributes(aBody,aMind,aFocus);                         
goto jl004E;                                                              
}
}
native function UpdateTouching();
protected native function sv2cl_SetPvPTimer_CallStub();
event sv2cl_SetPvPTimer(int aTimer) {
mPvPTimer = aTimer;                                                         
if (aTimer <= 0) {                                                          
SendDesktopMessage("",Class'StringReferences'.default.PvP_Enabled.Text,Class'Game_Desktop'.7);
} else {                                                                    
SendDesktopMessage("",Class'StringReferences'.default.Enabling_PvP_in_.Text
@ string(aTimer)
@ Class'StringReferences'.default._Seconds.Text,Class'Game_Desktop'.7);
}
}
native function ResetPvPTimer();
function DB_Guild GetGuild() {
return mGuild;                                                              
}
final native function UpdateLevelInfo();
function RadialMenuSelect(Pawn aPlayerPawn,byte aMainOption,byte aSubOption) {
local Game_PlayerController PlayerController;
local Game_PlayerPawn targetPawn;
Super.RadialMenuSelect(aPlayerPawn,aMainOption,aSubOption);                 
if (aMainOption == Class'Game_RadialMenuOptions'.0) {                       
PlayerController = Game_PlayerController(aPlayerPawn.Controller);         
targetPawn = Game_PlayerPawn(PlayerController.Input.cl_GetTargetPawn());  
switch (aSubOption) {                                                     
case Class'Game_RadialMenuOptions'.19 :                                 
PlayerController.Chat.EnterChatMessage("/w");                         
PlayerController.Chat.EnterChatMessage(targetPawn.Character.cl_GetBaseName());
return;                                                               
case Class'Game_RadialMenuOptions'.12 :                                 
PlayerController.GroupingTeams.TeamInvite(targetPawn.Character.cl_GetBaseName());
return;                                                               
case Class'Game_RadialMenuOptions'.14 :                                 
PlayerController.GroupingGuilds.GuildInvite(targetPawn.Character.cl_GetBaseName());
return;                                                               
case Class'Game_RadialMenuOptions'.13 :                                 
PlayerController.GroupingFriends.AddFriendMember(targetPawn.Character.cl_GetBaseName());
return;                                                               
default:                                                                
}
}
}
function Material RadialMenuImage(Pawn aPlayerPawn,byte aMainOption,byte aSubOption) {
return None;                                                                
}
event RadialMenuCollect(Pawn aPlayerPawn,byte mainOption,out array<byte> subOptions) {
local Game_PlayerController PlayerController;
Super.RadialMenuCollect(aPlayerPawn,mainOption,subOptions);                 
if (mainOption == Class'Game_RadialMenuOptions'.0) {                        
subOptions[subOptions.Length] = Class'Game_RadialMenuOptions'.7;          
subOptions[subOptions.Length] = Class'Game_RadialMenuOptions'.19;         
PlayerController = Game_PlayerController(aPlayerPawn.Controller);         
if (PlayerController != None) {                                           
if (PlayerController.GroupingTeams.IsTeamLeader()
&& !PlayerController.GroupingTeams.InTeamWith(self)) {
subOptions[subOptions.Length] = Class'Game_RadialMenuOptions'.12;     
}
if (!PlayerController.GroupingFriends.IsFriendWith(self)) {             
subOptions[subOptions.Length] = Class'Game_RadialMenuOptions'.13;     
}
}
}
}
event string cl_GetSecondaryDisplayName() {
local string guildName;
if (Character != None) {                                                    
guildName = Character.GetGuildName();                                     
if (Len(guildName) > 0) {                                                 
return "<" $ guildName $ ">";                                           
}
}
return "";                                                                  
}
event string cl_GetPrimaryDisplayName() {
if (Character != None) {                                                    
return "-" $ Character.cl_GetFullName()
$ "-";                    
} else {                                                                    
return "";                                                                
}
}
protected native function sv2cl_SitDown_CallStub();
event sv2cl_SitDown(bool aOnChairFlag) {
if (aOnChairFlag) {                                                         
mNetPhysics = 20;                                                         
} else {                                                                    
mNetPhysics = 19;                                                         
}
}
event bool SitDown(optional bool aOnChairFlag) {
if (Super.SitDown(aOnChairFlag)) {                                          
sv2cl_SitDown_CallStub(aOnChairFlag);                                     
return True;                                                              
}
return False;                                                               
}
protected native function sv2cl_ForceMovement_CallStub();
private final native event sv2cl_ForceMovement(Vector aLocation,Vector aVelocity,byte aPhysics);
protected native function cl2sv_UpdateMovement_CallStub();
private final native event cl2sv_UpdateMovement(Vector aLocation,Vector aVelocity,byte aFrameID);
protected native function cl2sv_UpdateMovementWithPhysics_CallStub();
private final native event cl2sv_UpdateMovementWithPhysics(Vector aLocation,Vector aVelocity,byte aPhysics,byte aFrameID);
protected native function cl2sv_UpdateRotation_CallStub();
private final native event cl2sv_UpdateRotation(int aYaw);
private final native function cl_UpdateToServer();
event cl_OnShutdown() {
if (questLog != None) {                                                     
questLog.cl_OnShutdown();                                                 
}
Super.cl_OnShutdown();                                                      
}
event cl_OnUpdate() {
if (mNetPhysics != Physics) {                                               
if (!IsLocalPlayer()) {                                                   
if (mNetPhysics == 18) {                                                
if (mMayJump) {                                                       
mMayJump = !DoJump();                                               
}
} else {                                                                
if (Physics != 18 && Physics != 2) {                                  
SetPhysics(mNetPhysics);                                            
}
}
}
}
Super.cl_OnUpdate();                                                        
}
event cl_OnTick(float DeltaTime) {
if (!IsLocalPlayer()) {                                                     
PredictMovement(DeltaTime);                                               
} else {                                                                    
cl_UpdateToServer();                                                      
}
Super.cl_OnTick(DeltaTime);                                                 
}
event cl_OnFrame(float aDeltaTime) {
Super.cl_OnFrame(aDeltaTime);                                               
UpdateLevelInfo();                                                          
if (IsLocalPlayer()) {                                                      
UpdateAreaAudio(aDeltaTime);                                              
if (HasPet && Pet == None && !LostPet) {                                  
LostPet = True;                                                         
PetRelevancyLost.Trigger();                                             
}
}
}
private final native function UpdateTouchList();
event cl_OnBaseline() {
SetPhysics(mNetPhysics);                                                    
Velocity = mNetVelocity;                                                    
Super.cl_OnBaseline();                                                      
if (IsLocalPlayer()) {                                                      
Game_PlayerConversation(Game_Controller(Controller).ConversationControl).cl_RefreshTopics();
}
UpdateTouchList();                                                          
UpdateLevelInfo();                                                          
}
event bool ShouldTickPhysics() {
return IsLocalPlayer() || IsRemotePlayer();                                 
}
auto state Alive {
function BeginState() {
Super.BeginState();                                                     
ResetPvPTimer();                                                        
}
}
*/
