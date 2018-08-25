

using Engine;
using SBAI;
using SBAIScripts;
using SBBase;
using SBGame;
using SBGamePlay;
using SBMiniGames;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SBMiniGames
{
    
    
    [System.Serializable] public class MGame_MiniGameProxy : Game_MiniGameProxy
    {
        
        public const bool QUICKSTART = false;
        
        public const int MINIGAME_INVITATION_TIMEOUT = 30;
        
        public const int MINIGAME_IGNORED_ME = 3;
        
        public const int MINIGAME_BUSY = 2;
        
        public const int MINIGAME_DECLINE = 1;
        
        public const int MINIGAME_ACCEPT = 0;
        
        public const int MINIGAME_STATUS_DIED = 4;
        
        public const int MINIGAME_STATUS_TIMEOUT = 3;
        
        public const int MINIGAME_STATUS_DRAW = 2;
        
        public const int MINIGAME_STATUS_WIN = 1;
        
        public const int MINIGAME_STATUS_UNDECIDED = 0;
        
        public const int MINIGAME_COUNT = 2;
        
        public const int MINIGAME_DRAUGHTS = 1;
        
        public const int MINIGAME_CHESS = 0;
        
        public MGame_MiniGameManager mMiniGameManager;
        
        public int mGroupID;
        
        public int mMiniGameID;
        
        public bool mSettingsAccepted;
        
        public bool mOfferDrawAccepted;
        
        public MGame_MiniGame mMiniGame;
        
        private bool mInviting;
        
        public Game_Pawn mInvitingPlayer;
        
        public float mInvitationTimeLeft;
        
        private float mThinkTime;
        
        private int mPreviousThinkTime;
        
        public bool mGameStarted;
        
        //public delegate<OnPlayerAvailable> @__OnPlayerAvailable__Delegate;
        
        //public delegate<OnPlayerInvitation> @__OnPlayerInvitation__Delegate;
        
        //public delegate<OnAcceptInvitation> @__OnAcceptInvitation__Delegate;
        
        //public delegate<OnCancelInvitation> @__OnCancelInvitation__Delegate;
        
        //public delegate<OnTimeoutInvitation> @__OnTimeoutInvitation__Delegate;
        
        //public delegate<OnUpdateSetting> @__OnUpdateSetting__Delegate;
        
        //public delegate<OnCancelSettings> @__OnCancelSettings__Delegate;
        
        //public delegate<OnAcceptSettings> @__OnAcceptSettings__Delegate;
        
        //public delegate<OnLeaveGame> @__OnLeaveGame__Delegate;
        
        //public delegate<OnStartMiniGame> @__OnStartMiniGame__Delegate;
        
        //public delegate<OnQuickstart> @__OnQuickstart__Delegate;
        
        //public delegate<OnGameEnd> @__OnGameEnd__Delegate;
        
        //public delegate<OnMakeMove> @__OnMakeMove__Delegate;
        
        //public delegate<OnSwitchTurn> @__OnSwitchTurn__Delegate;
        
        //public delegate<OnResign> @__OnResign__Delegate;
        
        //public delegate<OnOfferDraw> @__OnOfferDraw__Delegate;
        
        //public delegate<OnOfferDrawAccepted> @__OnOfferDrawAccepted__Delegate;
        
        public MGame_MiniGameProxy()
        {
        }
    }
}
/*
protected native function sv2cl_DebugMinigame_CallStub();
event sv2cl_DebugMinigame() {
mMiniGame.Debug();                                                          
}
protected native function cl2sv_DebugMinigame_CallStub();
event cl2sv_DebugMinigame() {
mMiniGameManager.sv_Debug(Outer);                                           
}
protected native function sv2cl_MakePromotion_CallStub();
event sv2cl_MakePromotion(int X,int Y,int piece) {
MGame_Chess(mMiniGame).MakePromotion(X,Y,piece,False);                      
}
protected native function sv2cl_GameEnd_CallStub();
event sv2cl_GameEnd(int aStatus,Game_Pawn aPlayer) {
mGameStarted = False;                                                       
OnGameEnd(aStatus,aPlayer);                                                 
}
protected native function sv2cl_OfferDrawAccepted_CallStub();
event sv2cl_OfferDrawAccepted(Game_Pawn aPlayer,bool aAccepted) {
OnOfferDrawAccepted(aPlayer,aAccepted);                                     
}
protected native function sv2cl_OfferDraw_CallStub();
event sv2cl_OfferDraw(Game_Pawn aPlayer) {
OnOfferDraw(aPlayer);                                                       
}
protected native function sv2cl_Resign_CallStub();
event sv2cl_Resign(Game_Pawn aPlayer) {
OnResign(aPlayer);                                                          
}
protected native function sv2cl_SwitchTurn_CallStub();
event sv2cl_SwitchTurn(int aPlayerID,float aThinkTimeLeft) {
mMiniGame.SetThinkTime(mMiniGame.GetCurrentPlayer(),aThinkTimeLeft);        
mMiniGame.SetPlayerTurnID(aPlayerID);                                       
OnSwitchTurn(aPlayerID);                                                    
}
protected native function sv2cl_MakeMove_CallStub();
event sv2cl_MakeMove(int originX,int originY,int destinationX,int destinationY) {
OnMakeMove(originX,originY,destinationX,destinationY);                      
}
protected native function sv2cl_StartMiniGame_CallStub();
event sv2cl_StartMiniGame() {
mGameStarted = True;                                                        
OnStartMiniGame();                                                          
mMiniGame.Start();                                                          
}
protected native function sv2cl_AcceptSettings_CallStub();
event sv2cl_AcceptSettings() {
OnAcceptSettings();                                                         
}
protected native function sv2cl_LeaveGame_CallStub();
event sv2cl_LeaveGame(Game_Pawn Opponent) {
mMiniGame.Stop();                                                           
mMiniGame.RemovePlayer(Opponent);                                           
OnLeaveGame(Opponent);                                                      
}
protected native function sv2cl_CancelSettings_CallStub();
event sv2cl_CancelSettings(Game_Pawn Player) {
OnCancelSettings(Player);                                                   
}
protected native function sv2cl_UpdateSetting_CallStub();
event sv2cl_UpdateSetting(int SettingID,int Value) {
mMiniGame.Config.SetConfig(SettingID,Value);                                
OnUpdateSetting(SettingID,Value);                                           
}
protected native function sv2cl_CancelInvitation_CallStub();
event sv2cl_CancelInvitation() {
OnCancelInvitation();                                                       
}
protected native function sv2cl_AcceptInvitation_CallStub();
event sv2cl_AcceptInvitation(Game_Pawn Opponent,int Accept) {
mInviting = False;                                                          
if (Accept == 0) {                                                          
cl_LoadMiniGame();                                                        
mMiniGame.AddPlayer(Outer);                                               
mMiniGame.AddPlayer(Opponent);                                            
}
OnAcceptInvitation(Opponent,Accept);                                        
}
protected native function sv2cl_InvitePlayer_CallStub();
event sv2cl_InvitePlayer(Game_Pawn Player,int GameID) {
OnPlayerInvitation(Player,GameID);                                          
}
protected native function sv2cl_Quickstart_CallStub();
event sv2cl_Quickstart(Game_Pawn Player,int GameID) {
mInviting = False;                                                          
mMiniGameID = GameID;                                                       
cl_LoadMiniGame();                                                          
mMiniGame.AddPlayer(Player);                                                
mMiniGame.AddPlayer(Outer);                                                 
OnQuickstart(Player,GameID);                                                
}
protected native function sv2cl_PlayerAvailable_CallStub();
event sv2cl_PlayerAvailable(Game_Pawn Opponent,bool Available) {
OnPlayerAvailable(Opponent,Available);                                      
}
function sv_PlayerDied() {
mMiniGameManager.sv_PlayerDied(Outer);                                      
}
function sv_IsPlayerAvailable(Game_Pawn Opponent) {
local bool Available;
Available = mMiniGameManager.sv_IsPlayerAvailable(Opponent);                
sv2cl_PlayerAvailable_CallStub(Opponent,Available);                         
}
protected native function cl2sv_MakePromotion_CallStub();
event cl2sv_MakePromotion(int X,int Y,int piece) {
mMiniGameManager.sv_MakePromotion(Outer,X,Y,piece);                         
}
protected native function cl2sv_AcceptDraw_CallStub();
event cl2sv_AcceptDraw(bool Accepted) {
mMiniGameManager.sv_AcceptDraw(Outer,Accepted);                             
}
protected native function cl2sv_OfferDraw_CallStub();
event cl2sv_OfferDraw() {
mMiniGameManager.sv_OfferDraw(Outer);                                       
}
protected native function cl2sv_Resign_CallStub();
event cl2sv_Resign() {
mMiniGameManager.sv_Resign(Outer);                                          
}
protected native function cl2sv_SwitchTurn_CallStub();
event cl2sv_SwitchTurn() {
mMiniGameManager.sv_SwitchTurn(Outer);                                      
}
protected native function cl2sv_MakeMove_CallStub();
event cl2sv_MakeMove(int originX,int originY,int destinationX,int destinationY) {
mMiniGameManager.sv_MakeMove(Outer,originX,originY,destinationX,destinationY);
}
protected native function cl2sv_AcceptSettings_CallStub();
event cl2sv_AcceptSettings() {
mMiniGameManager.sv_AcceptSettings(Outer);                                  
}
protected native function cl2sv_LeaveGame_CallStub();
event cl2sv_LeaveGame() {
mMiniGameManager.sv_LeaveGame(Outer);                                       
}
protected native function cl2sv_CancelSettings_CallStub();
event cl2sv_CancelSettings() {
mMiniGameManager.sv_CancelSettings(Outer);                                  
}
protected native function cl2sv_UpdateSetting_CallStub();
event cl2sv_UpdateSetting(int SettingID,int Value) {
local MGame_MiniGame MiniGame;
MiniGame = mMiniGameManager.GetGroup(mGroupID);                             
MiniGame.Config.SetConfig(SettingID,Value);                                 
mMiniGameManager.sv_UpdateSetting(Outer,SettingID,Value);                   
}
protected native function cl2sv_CancelInvitation_CallStub();
event cl2sv_CancelInvitation(Game_Pawn Opponent) {
MGame_MiniGameProxy(Opponent.MiniGameProxy).sv2cl_CancelInvitation_CallStub();
}
protected native function cl2sv_AcceptInvitation_CallStub();
event cl2sv_AcceptInvitation(Game_Pawn Opponent,int Accept) {
if (Accept == 0) {                                                          
mGroupID = MGame_MiniGameProxy(Opponent.MiniGameProxy).mGroupID;          
if (mGroupID == -1) {                                                     
mGroupID = mMiniGameManager.sv_GrabID();                                
sv_LoadMiniGame();                                                      
mMiniGameManager.sv_AddToGroup(mGroupID,Opponent);                      
}
mMiniGameManager.sv_AddToGroup(mGroupID,Outer);                           
}
MGame_MiniGameProxy(Opponent.MiniGameProxy).sv2cl_AcceptInvitation_CallStub(Outer,Accept);
}
protected native function cl2sv_InvitePlayer_CallStub();
event cl2sv_InvitePlayer(Game_Pawn Opponent,int GameID) {
mMiniGameID = GameID;                                                       
MGame_MiniGameProxy(Opponent.MiniGameProxy).mMiniGameID = GameID;           
MGame_MiniGameProxy(Opponent.MiniGameProxy).sv2cl_InvitePlayer_CallStub(Game_PlayerPawn(Outer),GameID);
}
protected native function cl2sv_IsPlayerAvailable_CallStub();
event cl2sv_IsPlayerAvailable(Game_Pawn Opponent) {
sv_IsPlayerAvailable(Opponent);                                             
}
event cl_MakePromotion(int X,int Y,int piece) {
cl2sv_MakePromotion_CallStub(X,Y,piece);                                    
}
event cl_AcceptDraw(bool Accepted) {
cl2sv_AcceptDraw_CallStub(Accepted);                                        
}
event cl_OfferDraw() {
cl2sv_OfferDraw_CallStub();                                                 
}
event cl_Resign() {
cl2sv_Resign_CallStub();                                                    
}
event cl_SwitchTurn() {
cl2sv_SwitchTurn_CallStub();                                                
}
event cl_MakeMove(int originX,int originY,int destinationX,int destinationY) {
cl2sv_MakeMove_CallStub(originX,originY,destinationX,destinationY);         
}
event cl_AcceptSettings() {
cl2sv_AcceptSettings_CallStub();                                            
}
event cl_LeaveGame() {
if (mMiniGame != None) {                                                    
mMiniGame = None;                                                         
cl2sv_LeaveGame_CallStub();                                               
}
}
event cl_CancelSettings() {
if (mMiniGame != None) {                                                    
mMiniGame = None;                                                         
}
cl2sv_CancelSettings_CallStub();                                            
}
event cl_UpdateSetting(int SettingID,int Value) {
mMiniGame.Config.SetConfig(SettingID,Value);                                
cl2sv_UpdateSetting_CallStub(SettingID,Value);                              
}
event cl_CancelInvitation() {
cl2sv_CancelInvitation_CallStub(mInvitingPlayer);                           
mInviting = False;                                                          
mInvitingPlayer = None;                                                     
}
event cl_AcceptInvitation(Game_Pawn Opponent,int GameID,int Accept) {
mMiniGameID = GameID;                                                       
cl_LoadMiniGame();                                                          
mMiniGame.AddPlayer(Opponent);                                              
mMiniGame.AddPlayer(Outer);                                                 
cl2sv_AcceptInvitation_CallStub(Opponent,Accept);                           
}
event cl_InvitePlayer(Game_Pawn Opponent,int GameID) {
mMiniGameID = GameID;                                                       
mInviting = True;                                                           
mInvitationTimeLeft = 30.00000000;                                          
mInvitingPlayer = Opponent;                                                 
cl2sv_InvitePlayer_CallStub(Opponent,GameID);                               
}
event cl_StartMiniGame(Game_PlayerPawn Opponent) {
cl2sv_IsPlayerAvailable_CallStub(Opponent);                                 
}
event cl_OnFrame(float DeltaTime) {
if (mInviting) {                                                            
mInvitationTimeLeft -= DeltaTime;                                         
if (mInvitationTimeLeft <= 0) {                                           
OnTimeoutInvitation();                                                  
cl_CancelInvitation();                                                  
}
}
if (mGameStarted) {                                                         
mMiniGame.OnFrame(DeltaTime);                                             
}
}
event cl_OnInit() {
Super.cl_OnInit();                                                          
Initialize();                                                               
}
event cl_LoadMiniGame() {
if (mMiniGame == None) {                                                    
mMiniGame = LoadMiniGame(mMiniGameID);                                    
mMiniGame.Initialize();                                                   
}
}
event sv_LoadMiniGame() {
local MGame_MiniGame MiniGame;
MiniGame = mMiniGameManager.GetGroup(mGroupID);                             
if (MiniGame == None) {                                                     
MiniGame = LoadMiniGame(mMiniGameID);                                     
MiniGame.Initialize();                                                    
mMiniGameManager.AddGroup(mGroupID,MiniGame);                             
}
}
function MGame_MiniGame LoadMiniGame(int Id) {
local MGame_MiniGame MiniGame;
switch (Id) {                                                               
case 0 :                                                                  
MiniGame = new Class'MGame_Chess';                                      
break;                                                                  
case 1 :                                                                  
MiniGame = new Class'MGame_Draughts';                                   
default:                                                                  
}
return MiniGame;                                                            
}
function bool IsPlaying() {
return mMiniGame != None;                                                   
}
function bool IsInviting() {
return mInviting;                                                           
}
event Initialize() {
mGroupID = -1;                                                              
mOfferDrawAccepted = False;                                                 
mSettingsAccepted = False;                                                  
mGameStarted = False;                                                       
}
native function SetThinkTime(float aThinkTime);
native function float GetThinkTime();
delegate OnOfferDrawAccepted(Game_Pawn Player,bool Accepted);
delegate OnOfferDraw(Game_Pawn Player);
delegate OnResign(Game_Pawn Player);
delegate OnSwitchTurn(int PlayerID);
delegate OnMakeMove(int sourceX,int sourceY,int targetX,int targetY);
delegate OnGameEnd(int Status,Game_Pawn Winner);
delegate OnQuickstart(Game_Pawn Player,int GameID);
delegate OnStartMiniGame();
delegate OnLeaveGame(Game_Pawn Opponent);
delegate OnAcceptSettings();
delegate OnCancelSettings(Game_Pawn Player);
delegate OnUpdateSetting(int SettingID,int Value);
delegate OnTimeoutInvitation();
delegate OnCancelInvitation();
delegate OnAcceptInvitation(Game_Pawn Opponent,int Accept);
delegate OnPlayerInvitation(Game_Pawn Player,int GameType);
delegate OnPlayerAvailable(Game_Pawn Opponent,bool Available);
*/
