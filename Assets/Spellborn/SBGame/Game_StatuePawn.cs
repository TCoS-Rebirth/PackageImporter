﻿using System;
using Engine;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Game_StatuePawn : Game_Pawn
    {
        public const int POLL_INTERVAL = 3600;

        public const int POSE_COUNT = 3;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int mhastransactionmanager_data;

        public StatueLocation Statue;

        [NonSerialized, HideInInspector]
        public float LastUpdate;

        public int Revision;

        public int Pose;

        public string StatueTag = string.Empty;

        public string PlayerName = string.Empty;

        public string StatueTitle = string.Empty;

        public string StatueDescription = string.Empty;

        public Game_StatuePawn()
        {
        }
    }
}
/*
event string cl_GetSecondaryDisplayName() {
return StatueDescription;                                                   
}
event string cl_GetPrimaryDisplayName() {
return PlayerName @ "-" @ StatueTitle;                                      
}
static function TempShowArray(array<byte> A) {
local string s;
local int i;
s = "[Sirenix.OdinInspector.FoldoutGroup(" $ string(A.Length) $ "]:";                                          
i = 0;                                                                      
while (i < A.Length) {                                                      
s = s @ string(A[i]);                                                     
++i;                                                                      
}
}
static function bool StaticUpdateStatue(name Tag,Game_Pawn aPlayer,string aStatueTitle,string aStatueDescription,int aPose) {
local export editinline Game_PlayerAppearance gpa;
local int CharacterID;
local string PlayerName;
local int awardedTimestamp;
if (aPlayer == None || Len(aStatueTitle) == 0
|| Len(aStatueDescription) == 0
|| aPose < 0
|| aPose >= 3) {
return False;                                                             
}
gpa = Game_PlayerAppearance(aPlayer.Appearance.GetBase());                  
if (aPlayer.GetCharacterID() == 0 || gpa == None) {                         
return False;                                                             
}
CharacterID = aPlayer.GetCharacterID();                                     
PlayerName = aPlayer.GetCharacterName();                                    
gpa.RepackLodDataAll();                                                     
TempShowArray(gpa.mLODData0);                                               
TempShowArray(gpa.mLODData1);                                               
TempShowArray(gpa.mLODData2);                                               
TempShowArray(gpa.mLODData3);                                               
awardedTimestamp = aPlayer.GetClock().GetCurrentTime();                     
Class'SBDBAsync'.UpdateStatueNewPlayerByTag(aPlayer,string(Tag),CharacterID,PlayerName,aStatueTitle,aStatueDescription,gpa.mLODData0,gpa.mLODData1,gpa.mLODData2,gpa.mLODData3,awardedTimestamp,aPose);
}
static event StaticCreateStatuePawns(Actor aActor) {
local StatueLocation sl;
local Game_StatuePawn SP;
foreach aActor.AllActors(Class'StatueLocation',sl) {                        
SP = aActor.Spawn(Class'Game_StatuePawn',aActor,,sl.Location,sl.Rotation);
if (SP != None) {                                                         
SP.sv_OnInit();                                                         
SP.sv_SetStatue(sl);                                                    
goto jl0083;                                                            
}
}
}
protected native function sv2rel_ReplicateState_CallStub();
private event sv2rel_ReplicateState(int aPose,string aPlayerName,string aStatueTitle,string aStatueDescription) {
Pose = aPose;                                                               
PlayerName = aPlayerName;                                                   
StatueTitle = aStatueTitle;                                                 
StatueDescription = aStatueDescription;                                     
cl_UpdateStatue();                                                          
cl_SetStatueAnimation();                                                    
}
private event sv_OnStatueDataReceived(int aCharacterId,string aPlayerName,string aTitle,string aDescription,array<byte> aLoddata0,array<byte> aLoddata1,array<byte> aLoddata2,array<byte> aLoddata3,byte aInformedPlayer,int aAwardedTimestamp,int aLastUpdatedTimestamp,int aPose) {
local export editinline Game_StatueAppearance statueAppearance;
PlayerName = aPlayerName;                                                   
StatueTitle = aTitle;                                                       
StatueDescription = aDescription;                                           
Pose = aPose;                                                               
statueAppearance = Game_StatueAppearance(Appearance.GetBase());             
statueAppearance.mLODData0 = aLoddata0;                                     
statueAppearance.mLODData1 = aLoddata1;                                     
statueAppearance.mLODData2 = aLoddata2;                                     
statueAppearance.mLODData3 = aLoddata3;                                     
statueAppearance.ConditionalUnpackLODData();                                
statueAppearance.RepackLodDataAll();                                        
sv2rel_ReplicateState_CallStub(Pose,PlayerName,StatueTitle,StatueDescription);
}
private native function sv_UpdateStatue();
protected function sv_OnConditionalUpdateDataReceived(bool success,array<DatabaseRow> rows,int auto_increment_id,int affected_rows,int TransactionUserData) {
local byte curEnabled;
local int curRevision;
curEnabled = int(rows[0].Fields[0]);                                        
curRevision = int(rows[0].Fields[1]);                                       
if (curRevision != Revision) {                                              
if (curEnabled != 0) {                                                    
Revision = curRevision;                                                 
sv_UpdateStatue();                                                      
} else {                                                                  
Pose = -1;                                                              
}
}
}
protected event sv_ConditionalUpdateStatue() {
local SBDBAsyncCallback callback;
LastUpdate = Level.TimeSeconds;                                             
if (Statue != None) {                                                       
callback.ObjectName = static.GetFName();                                  
callback.funcName = name("sv_OnConditionalUpdateDataReceived");           
Class'SBDBAsync'.GetStatueEnabledByTag(self,StatueTag,callback);          
goto jl007E;                                                              
}
}
protected function cl_UpdateStatue() {
local StatueLocation sl;
local export editinline Game_PlayerAppearance baseApp;
if (Statue == None
|| string(Statue.LocationTag) != StatueTag) {      
Statue = None;                                                            
foreach AllActors(Class'StatueLocation',sl) {                             
if (string(sl.LocationTag) == StatueTag) {                              
Statue = sl;                                                          
} else {                                                                
}
}
if (Statue != None) {                                                     
baseApp = Game_PlayerAppearance(Appearance.GetBase());                  
baseApp.SetScale(Statue.DrawScale);                                     
SetCollisionSize(CollisionRadius * Statue.DrawScale,CollisionHeight * Statue.DrawScale);
}
}
if (Pose != -1) {                                                           
Pose = Clamp(Pose,0,3 - 1);                                               
cl_SetStatueAnimation();                                                  
}
}
protected native function AdjustPosition();
function cl_SetStatueAnimation() {
local array<int> ActionFlags;
ClearAnims();                                                               
ActionFlags[0] = Class'SBAnimationFlags'.75;                                
QueueAnimation(ActionFlags,Pose + 1,1.00000000,0.00000000,0.00000000,False,Class'SBAnimatedPawn'.9);
PlayQueuedAnimations(True,True);                                            
}
event sv_SetStatue(StatueLocation aStatue) {
if (Statue == None && aStatue != None) {                                    
Statue = aStatue;                                                         
StatueTag = string(Statue.LocationTag);                                   
sv_ConditionalUpdateStatue();                                             
goto jl0042;                                                              
}
}
event cl_OnUpdate() {
Super.cl_OnUpdate();                                                        
}
event cl_OnBaseline() {
Super.cl_OnBaseline();                                                      
cl_UpdateStatue();                                                          
}
event cl_OnFrame(float delta) {
local bool newHidden;
newHidden = Game_PlayerAppearance(Appearance.GetBase()).GetLowestReceivedLOD() == 255
|| Pose == -1
|| Statue == None;
if (newHidden != bHidden) {                                                 
cl_SetStatueAnimation();                                                  
}
bHidden = newHidden;                                                        
Appearance.cl_OnFrame(delta);                                               
}
event cl_OnInit() {
Appearance.cl_OnInit();                                                     
Appearance.GetBase().SetStatue(True);                                       
Appearance.DressUp();                                                       
CreateShadow();                                                             
cl_UpdateStatue();                                                          
}
*/