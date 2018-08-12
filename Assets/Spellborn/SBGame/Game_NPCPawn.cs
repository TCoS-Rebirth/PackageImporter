using System;
using System.Collections.Generic;
using Engine;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Game_NPCPawn : Game_TransientPawn
    {
        public NPC_Type NPCType;

        public int NPCFameLevel;

        public int NPCPePRank;

        public int NPCTypeId;

        public List<int> RelatedQuestsIds = new List<int>();

        public bool mDebugInfo;

        public Vector mDebugNetLocation;

        public Vector mNetDestination;

        public byte mMovementFlags;

        public Game_Pawn mNetFocus;

        public Vector mNetFocusLocation;

        public Rotator mDefaultRotation;

        public List<NetMovement> mNetPath = new List<NetMovement>();

        [NonSerialized, HideInInspector]
        public Game_Pawn ClientFocus;

        public bool Moving;

        private float mNoPathTime;

        private float mLastKnownSpeed;

        public int MovingTurnLimit;

        public bool bTouching;

        public float timerMain;

        public float bannerTimer;

        public bool playerInRange;

        public Conversation_Topic Topic;

        public Actor TopicEmitter;

        [NonSerialized, HideInInspector]
        public string mDebugStateStr = string.Empty;

        [NonSerialized, HideInInspector]
        public string mDebugInfoStr = string.Empty;

        [NonSerialized, HideInInspector]
        public string mDebugPathStr = string.Empty;

        public float LootTimeout;

        public float RotTimer;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Game_Pawn mScavenger;

        [NonSerialized, HideInInspector]
        public int mDebugging;

        public bool BreakMovement;

        public Game_NPCPawn()
        {
        }

        [Serializable] public struct NetMovement
        {
            public Vector Destination;

            public byte flags;
        }

        public enum ENPCMovementFlags
        {
            ENMF_Normal,

            ENMF_Walking,

            ENMF_Backwards,

            ENPCMovementFlags_RESERVED_3,

            ENMF_Strafing,

            ENPCMovementFlags_RESERVED_5,

            ENPCMovementFlags_RESERVED_6,

            ENPCMovementFlags_RESERVED_7,

            ENMF_Jumping,

            ENPCMovementFlags_RESERVED_9,

            ENPCMovementFlags_RESERVED_10,

            ENPCMovementFlags_RESERVED_11,

            ENPCMovementFlags_RESERVED_12,

            ENPCMovementFlags_RESERVED_13,

            ENPCMovementFlags_RESERVED_14,

            ENPCMovementFlags_RESERVED_15,

            ENMF_Crouching,

            ENPCMovementFlags_RESERVED_17,

            ENPCMovementFlags_RESERVED_18,

            ENPCMovementFlags_RESERVED_19,

            ENPCMovementFlags_RESERVED_20,

            ENPCMovementFlags_RESERVED_21,

            ENPCMovementFlags_RESERVED_22,

            ENPCMovementFlags_RESERVED_23,

            ENPCMovementFlags_RESERVED_24,

            ENPCMovementFlags_RESERVED_25,

            ENPCMovementFlags_RESERVED_26,

            ENPCMovementFlags_RESERVED_27,

            ENPCMovementFlags_RESERVED_28,

            ENPCMovementFlags_RESERVED_29,

            ENPCMovementFlags_RESERVED_30,

            ENPCMovementFlags_RESERVED_31,

            ENMF_Sitting,

            ENPCMovementFlags_RESERVED_33,

            ENPCMovementFlags_RESERVED_34,

            ENPCMovementFlags_RESERVED_35,

            ENPCMovementFlags_RESERVED_36,

            ENPCMovementFlags_RESERVED_37,

            ENPCMovementFlags_RESERVED_38,

            ENPCMovementFlags_RESERVED_39,

            ENPCMovementFlags_RESERVED_40,

            ENPCMovementFlags_RESERVED_41,

            ENPCMovementFlags_RESERVED_42,

            ENPCMovementFlags_RESERVED_43,

            ENPCMovementFlags_RESERVED_44,

            ENPCMovementFlags_RESERVED_45,

            ENPCMovementFlags_RESERVED_46,

            ENPCMovementFlags_RESERVED_47,

            ENPCMovementFlags_RESERVED_48,

            ENPCMovementFlags_RESERVED_49,

            ENPCMovementFlags_RESERVED_50,

            ENPCMovementFlags_RESERVED_51,

            ENPCMovementFlags_RESERVED_52,

            ENPCMovementFlags_RESERVED_53,

            ENPCMovementFlags_RESERVED_54,

            ENPCMovementFlags_RESERVED_55,

            ENPCMovementFlags_RESERVED_56,

            ENPCMovementFlags_RESERVED_57,

            ENPCMovementFlags_RESERVED_58,

            ENPCMovementFlags_RESERVED_59,

            ENPCMovementFlags_RESERVED_60,

            ENPCMovementFlags_RESERVED_61,

            ENPCMovementFlags_RESERVED_62,

            ENPCMovementFlags_RESERVED_63,

            ENMF_MovingTurn,

            ENPCMovementFlags_RESERVED_65,

            ENPCMovementFlags_RESERVED_66,

            ENPCMovementFlags_RESERVED_67,

            ENPCMovementFlags_RESERVED_68,

            ENPCMovementFlags_RESERVED_69,

            ENPCMovementFlags_RESERVED_70,

            ENPCMovementFlags_RESERVED_71,

            ENPCMovementFlags_RESERVED_72,

            ENPCMovementFlags_RESERVED_73,

            ENPCMovementFlags_RESERVED_74,

            ENPCMovementFlags_RESERVED_75,

            ENPCMovementFlags_RESERVED_76,

            ENPCMovementFlags_RESERVED_77,

            ENPCMovementFlags_RESERVED_78,

            ENPCMovementFlags_RESERVED_79,

            ENPCMovementFlags_RESERVED_80,

            ENPCMovementFlags_RESERVED_81,

            ENPCMovementFlags_RESERVED_82,

            ENPCMovementFlags_RESERVED_83,

            ENPCMovementFlags_RESERVED_84,

            ENPCMovementFlags_RESERVED_85,

            ENPCMovementFlags_RESERVED_86,

            ENPCMovementFlags_RESERVED_87,

            ENPCMovementFlags_RESERVED_88,

            ENPCMovementFlags_RESERVED_89,

            ENPCMovementFlags_RESERVED_90,

            ENPCMovementFlags_RESERVED_91,

            ENPCMovementFlags_RESERVED_92,

            ENPCMovementFlags_RESERVED_93,

            ENPCMovementFlags_RESERVED_94,

            ENPCMovementFlags_RESERVED_95,

            ENPCMovementFlags_RESERVED_96,

            ENPCMovementFlags_RESERVED_97,

            ENPCMovementFlags_RESERVED_98,

            ENPCMovementFlags_RESERVED_99,

            ENPCMovementFlags_RESERVED_100,

            ENPCMovementFlags_RESERVED_101,

            ENPCMovementFlags_RESERVED_102,

            ENPCMovementFlags_RESERVED_103,

            ENPCMovementFlags_RESERVED_104,

            ENPCMovementFlags_RESERVED_105,

            ENPCMovementFlags_RESERVED_106,

            ENPCMovementFlags_RESERVED_107,

            ENPCMovementFlags_RESERVED_108,

            ENPCMovementFlags_RESERVED_109,

            ENPCMovementFlags_RESERVED_110,

            ENPCMovementFlags_RESERVED_111,

            ENPCMovementFlags_RESERVED_112,

            ENPCMovementFlags_RESERVED_113,

            ENPCMovementFlags_RESERVED_114,

            ENPCMovementFlags_RESERVED_115,

            ENPCMovementFlags_RESERVED_116,

            ENPCMovementFlags_RESERVED_117,

            ENPCMovementFlags_RESERVED_118,

            ENPCMovementFlags_RESERVED_119,

            ENPCMovementFlags_RESERVED_120,

            ENPCMovementFlags_RESERVED_121,

            ENPCMovementFlags_RESERVED_122,

            ENPCMovementFlags_RESERVED_123,

            ENPCMovementFlags_RESERVED_124,

            ENPCMovementFlags_RESERVED_125,

            ENPCMovementFlags_RESERVED_126,

            ENPCMovementFlags_RESERVED_127,

            ENMF_Submerged,
        }
    }
}
/*
function Died(Controller Killer,class<DamageType> DamageType,Vector HitLocation) {
Super.Died(Killer,DamageType,HitLocation);                                  
}
function sv_StartLoot(array<Game_Pawn> aKillers,byte LootMode) {
local Loot_Manager lootManager;
local array<LootTable> Loot;
local export editinline NPC_Taxonomy Faction;
if (aKillers.Length < 1) {                                                  
return;                                                                   
}
if (NPCType != None) {                                                      
Loot = NPCType.Loot;                                                      
}
Faction = Character.GetFaction();                                           
if (Faction != None) {                                                      
Faction.AppendLoot(Loot);                                                 
}
if (Loot.Length == 0) {                                                     
return;                                                                   
}
RotTimer = LootTimeout;                                                     
lootManager = Class'Loot_Manager'.static.sv_GetInstance();                  
if (lootManager != None) {                                                  
lootManager.sv_CreateTransaction(Loot,aKillers,LootTimeout,LootMode);     
}
}
protected native function sv2rel_Chat_CallStub();
event sv2rel_Chat(int aLocalizedStringID,int aSubjectId,int aTargetId,Game_Pawn aTarget) {
local string Text;
local export editinline Content_Type Subject;
local Object Target;
local string Chat;
local Game_PlayerPawn Player;
if (aLocalizedStringID != 0) {                                              
Text = Class'SBDBSync'.GetDescription(aLocalizedStringID);                
}
if (aSubjectId != 0) {                                                      
Subject = Content_Type(Class'SBDBSync'.GetResourceObject(aSubjectId));    
}
if (aTargetId != 0) {                                                       
Target = Content_Type(Class'SBDBSync'.GetResourceObject(aTargetId));      
} else {                                                                    
Target = aTarget;                                                         
}
Chat = NPCType.ParseText(Text,self,Subject,Target);                         
Player = Game_PlayerPawn(Base_GameClient(Class'Actor'.static.GetGameEngine()).GPlayerController.Pawn);
Game_Desktop(Game_PlayerController(Player.Controller).Player.GUIDesktop).AddMessage(Character.cl_GetName(),Chat,Class'Game_Desktop'.0);
}
event cl_SetTopic(export editinline Conversation_Topic aTopic) {
local Vector EmitterLocation;
if (TopicEmitter != None) {                                                 
DetachFromBone(TopicEmitter);                                             
TopicEmitter.Destroy();                                                   
TopicEmitter = None;                                                      
}
if (aTopic != None && aTopic.EmitterClass != None) {                        
EmitterLocation = Location;                                               
TopicEmitter = Spawn(aTopic.EmitterClass,self,,EmitterLocation,Rotation); 
TopicEmitter.SetBase(self);                                               
}
Topic = aTopic;                                                             
}
function cl_Banner(Game_Pawn aPartner,export editinline Conversation_Topic aTopic) {
local bool timerMet;
timerMet = False;                                                           
if (timerMain > bannerTimer || bannerTimer == 0.00000000) {                 
timerMet = True;                                                          
bannerTimer = timerMain + aTopic.BannerTime;                              
}
if (aTopic.Emote != 0) {                                                    
Emotes.PlayLocalEmote(aTopic.Emote - 1);                                  
ClientFocus = aPartner;                                                   
}
if (timerMet && Len(aTopic.Chat.Text) != 0) {                               
Game_Desktop(Game_PlayerController(aPartner.Controller).Player.GUIDesktop).AddMessage(Character.cl_GetName(),aTopic.ParseText(aTopic.Chat.Text,self,aTopic,aPartner),Class'Game_Desktop'.0);
}
if (timerMet && aTopic.Speech != None) {                                    
PlaySound(aTopic.Speech);                                                 
}
}
function TakeDamage(int Damage,Pawn instigatedBy,Vector HitLocation,Vector Momentum,class<DamageType> DamageType) {
if (SBRole == 1) {                                                          
if (!Game_Controller(Controller).sv_OnDamage(Game_Pawn(instigatedBy),Damage)) {
Super.TakeDamage(Damage,instigatedBy,HitLocation,Momentum,DamageType);  
}
} else {                                                                    
Super.TakeDamage(Damage,instigatedBy,HitLocation,Momentum,DamageType);    
}
}
protected native function sv2clrel_Submerge_CallStub();
protected event sv2clrel_Submerge() {
local NetMovement submergeMove;
if (NetPathDone()) {                                                        
Submerge();                                                               
} else {                                                                    
submergeMove.Destination = mNetDestination;                               
submergeMove.flags = 128;                                                 
mNetPath[mNetPath.Length] = submergeMove;                                 
}
}
protected native function sv2clrel_Emerge_CallStub();
protected event sv2clrel_Emerge() {
local NetMovement submergeMove;
if (NetPathDone()) {                                                        
Emerge();                                                                 
} else {                                                                    
submergeMove.Destination = mNetDestination;                               
submergeMove.flags = 128;                                                 
mNetPath[mNetPath.Length] = submergeMove;                                 
}
}
protected native function sv2rel_SetFocus_CallStub();
event sv2rel_SetFocus(Game_Pawn aFocus) {
mNetFocus = aFocus;                                                         
}
protected native function sv2rel_SetClientFocus_CallStub();
event sv2rel_SetClientFocus(Game_Pawn aFocus) {
ClientFocus = aFocus;                                                       
}
protected final native event cl_ApplyMovementOptions(byte aFlags);
protected native function sv2rel_StopMovement_CallStub();
protected final native event sv2rel_StopMovement(Vector aLocation);
protected native function sv2rel_FocusLocation_CallStub();
protected final native event sv2rel_FocusLocation(Vector aLocation);
protected native function sv2rel_Focus_CallStub();
protected final native event sv2rel_Focus(Game_Pawn aFocus);
protected native function sv2rel_Move_CallStub();
protected final native event sv2rel_Move(byte aFlags,Vector aDestination);
protected final native function bool NetPathDone();
protected native function cl2sv_EnterShop_CallStub();
event cl2sv_EnterShop(Game_PlayerPawn aPlayerPawn,byte aOption) {
if (NPCType.Shop != None) {                                                 
NPCType.Shop.sv_EnterShop(aPlayerPawn,aOption);                           
}
}
function RadialMenuSelect(Pawn aPlayerPawn,byte aMainOption,byte aSubOption) {
local Object castFFS;
Super.RadialMenuSelect(aPlayerPawn,aMainOption,aSubOption);                 
if (aMainOption == Class'Game_RadialMenuOptions'.0) {                       
if (aSubOption == Class'Game_RadialMenuOptions'.10
&& Game_PlayerController(aPlayerPawn.Controller).ConversationControl.CanConverse(self)) {
Game_PlayerConversation(Game_Controller(aPlayerPawn.Controller).ConversationControl).cl2sv_Interact_CallStub(self);
} else {                                                                  
if (aSubOption == Class'Game_RadialMenuOptions'.15
&& NPCType.Travel) {
castFFS = NPCType;                                                    
Game_PlayerController(aPlayerPawn.Controller).GUI.ShowTravel(string(castFFS.Name));
} else {                                                                
if (aSubOption == Class'Game_RadialMenuOptions'.17
&& NPCType.Arena) {
Game_PlayerController(aPlayerPawn.Controller).GUI.ShowArenaWindow();
} else {                                                              
if (NPCType.Shop != None
&& NPCType.Shop.CanEnterShop(Game_PlayerPawn(aPlayerPawn),aSubOption)) {
Game_PlayerPawn(aPlayerPawn).Trading.cl_SetShop(NPCType.Shop,aSubOption);
cl2sv_EnterShop_CallStub(Game_PlayerPawn(aPlayerPawn),aSubOption);
}
}
}
}
}
Game_PlayerQuestLog(Game_PlayerPawn(aPlayerPawn).questLog).cl2sv_SwirlyOptionPawn_CallStub(self,aMainOption,aSubOption);
}
function Material RadialMenuImage(Pawn aPlayerPawn,byte aMainOption,byte aSubOption) {
return None;                                                                
}
event RadialMenuCollect(Pawn aPlayerPawn,byte aMainOption,out array<byte> aSubOptions) {
Super.RadialMenuCollect(aPlayerPawn,aMainOption,aSubOptions);               
if (aMainOption == Class'Game_RadialMenuOptions'.0) {                       
if (!IsDead()) {                                                          
if (Topic != None) {                                                    
aSubOptions[aSubOptions.Length] = Class'Game_RadialMenuOptions'.10;   
}
if (NPCType.Travel) {                                                   
aSubOptions[aSubOptions.Length] = Class'Game_RadialMenuOptions'.15;   
}
if (NPCType.Arena) {                                                    
aSubOptions[aSubOptions.Length] = Class'Game_RadialMenuOptions'.17;   
}
if (NPCType.Shop != None) {                                             
NPCType.Shop.RadialMenuCollect(aPlayerPawn,aMainOption,aSubOptions);  
}
}
}
Game_PlayerPawn(aPlayerPawn).questLog.RadialMenuCollect(NPCType,aMainOption,aSubOptions);
}
event string cl_GetSecondaryDisplayName() {
local export editinline NPC_Taxonomy tax;
local string Description;
if (Character != None && NPCType.ShowNameAboveHeads) {                      
tax = Character.GetFaction();                                             
if (tax != None) {                                                        
Description = tax.GetDescription();                                     
if (Len(Description) > 0) {                                             
return "[Sirenix.OdinInspector.FoldoutGroup(" $ Description $ "]";                                       
}
}
}
return "";                                                                  
}
event string cl_GetPrimaryDisplayName() {
if (Character != None && NPCType.ShowNameAboveHeads) {                      
return Character.cl_GetFullName();                                        
} else {                                                                    
return "";                                                                
}
}
event Destroyed() {
if (TopicEmitter != None) {                                                 
DetachFromBone(TopicEmitter);                                             
TopicEmitter.Destroy();                                                   
TopicEmitter = None;                                                      
}
Super.Destroyed();                                                          
}
event cl_OnTick(float DeltaTime) {
timerMain += DeltaTime;                                                     
Super.cl_OnTick(DeltaTime);                                                 
}
event cl_OnFrame(float DeltaTime) {
local Game_PlayerPawn playerPawn;
if (Class'Actor'.static.GetGameEngine() != None) {                          
playerPawn = Game_PlayerPawn(Base_GameClient(Class'Actor'.static.GetGameEngine()).GPlayerController.Pawn);
if (playerPawn != None
&& Game_PlayerController(playerPawn.Controller).ConversationControl.CanConverse(self)) {
if (!playerInRange) {                                                   
playerInRange = True;                                                 
Game_PlayerConversation(Game_PlayerController(Base_GameClient(Class'Actor'.static.GetGameEngine()).GPlayerController).ConversationControl).cl2sv_React_CallStub(self);
}
} else {                                                                  
if (playerInRange) {                                                    
playerInRange = False;                                                
ClientFocus = None;                                                   
}
}
}
Super.cl_OnFrame(DeltaTime);                                                
}
event cl_OnInit() {
NPCType.cl_OnInit(self);                                                    
Super.cl_OnInit();                                                          
}
event cl_OnBaseline() {
NPCType = NPC_Type(Class'SBDBSync'.GetResourceObject(NPCTypeId));           
if (NPCType == None) {                                                      
}
cl_ApplyMovementOptions(mMovementFlags);                                    
Super.cl_OnBaseline();                                                      
NPCType.cl_CreateQuestsTopics(self);                                        
}
protected native function sv2rel_SetDebugNetLocation_CallStub();
event sv2rel_SetDebugNetLocation(Vector aLocation) {
mDebugNetLocation = aLocation;                                              
}
protected native function sv2rel_UpdateDebugPathStr_CallStub();
event sv2rel_UpdateDebugPathStr(string aDebugInfoStr) {
mDebugPathStr = aDebugInfoStr;                                              
}
event EnableDebugging(bool Enable) {
if (Enable) {                                                               
mDebugging++;                                                             
} else {                                                                    
--mDebugging;                                                             
if (mDebugging < 0) {                                                     
mDebugging = 0;                                                         
}
}
}
state Dead {
event cl_Banner(Game_Pawn aPartner,export editinline Conversation_Topic aTopic) {
}
function BeginState() {
local Game_PlayerController lai;
Super.BeginState();                                                     
if (SBRole == 1) {                                                      
sv_KillCredit();                                                      
mNetFocus = None;                                                     
mNetDestination = Location;                                           
if (NPCType.TriggersKilledHook == True) {                             
foreach DynamicActors(Class'Game_PlayerController',lai) {           
lai.sv_FireHook(Class'Content_Type'.11,self,0);                   
}
}
Game_Controller(Controller).ConversationControl.EndAllConversations();
goto jl00C8;                                                          
}
mNetDestination = Location;                                             
mNetFocus = None;                                                       
ClientFocus = None;                                                     
if (TopicEmitter != None) {                                             
TopicEmitter.Destroy();                                               
TopicEmitter = None;                                                  
}
}
function sv_KillCredit() {
local Game_Pawn bestEnemy;
local Game_PlayerController PlayerController;
local array<Game_Pawn> Enemies;
local float fameValue;
local float pepValue;
RotTimer = NPCType.CorpseTimeout;                                       
bestEnemy = CombatStats.sv_GetKiller();                                 
if (bestEnemy != None) {                                                
PlayerController = Game_PlayerController(bestEnemy.Controller);       
if (PlayerController != None) {                                       
if (NPCType.IndividualKillCredit) {                                 
PlayerController.GroupingTeams.sv_GetCreditTeam(Enemies,Location);
if (Enemies.Length > 0) {                                         
CombatStats.sv_QuestCredit(Enemies);                            
CombatStats.sv_FamePepCredit(Enemies,NPCType.CreditMultiplier,CharacterStats.GetFameLevel(),CharacterStats.GetPePRank(),fameValue,pepValue);
CombatStats.sv_FamePepDistribution(Enemies,fameValue,pepValue); 
sv_StartLoot(Enemies,PlayerController.GroupingTeams.GetTeamLootMode());
goto jl013A;                                                    
}
goto jl013D;                                                      
}
}
goto jl0140;                                                          
}
}
}
*/