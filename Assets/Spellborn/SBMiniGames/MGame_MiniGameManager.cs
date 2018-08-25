﻿

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
    
    
    [System.Serializable] public class MGame_MiniGameManager : Game_MiniGameManager
    {
        
        public List<int> mFreeIDs = new List<int>();
        
        public int mLastID;
        
        public int mMiniGames;
        
        public MGame_MiniGameManager()
        {
        }
    }
}
/*
event sv_Debug(Game_Pawn aPlayer) {
local int i;
local Game_Pawn Opponent;
local MGame_MiniGame MiniGame;
MiniGame = MGame_BoardGame(GetGroup(MGame_MiniGameProxy(aPlayer.MiniGameProxy).mGroupID));
if (MiniGame != None) {                                                     
MiniGame.Debug();                                                         
i = 0;                                                                    
while (i < MiniGame.mPlayers.Length) {                                    
Opponent = MiniGame.mPlayers[i];                                        
if (Opponent != aPlayer) {                                              
MGame_MiniGameProxy(Opponent.MiniGameProxy).sv2cl_DebugMinigame_CallStub();
}
i++;                                                                    
}
}
}
event sv_MakePromotion(Game_Pawn Player,int X,int Y,int piece) {
local int i;
local Game_Pawn Opponent;
local MGame_BoardGame MiniGame;
MiniGame = MGame_BoardGame(GetGroup(MGame_MiniGameProxy(Player.MiniGameProxy).mGroupID));
MGame_Chess(MiniGame).MakePromotion(X,Y,piece,False);                       
i = 0;                                                                      
while (i < MiniGame.mPlayers.Length) {                                      
Opponent = MiniGame.mPlayers[i];                                          
if (Opponent != Player) {                                                 
MGame_MiniGameProxy(Opponent.MiniGameProxy).sv2cl_MakePromotion_CallStub(X,Y,piece);
}
i++;                                                                      
}
}
event sv_AcceptDraw(Game_Pawn Player,bool Accepted) {
local int i;
local Game_Pawn receiver;
local int GroupId;
local MGame_MiniGame MiniGame;
GroupId = MGame_MiniGameProxy(Player.MiniGameProxy).mGroupID;               
MGame_MiniGameProxy(Player.MiniGameProxy).mOfferDrawAccepted = Accepted;    
MiniGame = GetGroup(GroupId);                                               
if (Accepted) {                                                             
if (sv_AllPlayersAcceptedDraw(GroupId)) {                                 
i = 0;                                                                  
while (i < MiniGame.mPlayers.Length) {                                  
receiver = MiniGame.mPlayers[i];                                      
MGame_MiniGameProxy(receiver.MiniGameProxy).sv2cl_OfferDrawAccepted_CallStub(Player,True);
i++;                                                                  
}
}
} else {                                                                    
i = 0;                                                                    
while (i < MiniGame.mPlayers.Length) {                                    
receiver = MiniGame.mPlayers[i];                                        
if (receiver != Player) {                                               
MGame_MiniGameProxy(receiver.MiniGameProxy).sv2cl_OfferDrawAccepted_CallStub(Player,False);
}
i++;                                                                    
}
}
}
event bool sv_AllPlayersAcceptedDraw(int GroupId) {
local int i;
local MGame_MiniGame MiniGame;
MiniGame = GetGroup(GroupId);                                               
i = 0;                                                                      
while (i < MiniGame.mPlayers.Length) {                                      
if (!MGame_MiniGameProxy(MiniGame.mPlayers[i].MiniGameProxy).mOfferDrawAccepted) {
return False;                                                           
}
i++;                                                                      
}
return True;                                                                
}
event sv_OfferDraw(Game_Pawn Player) {
local int i;
local Game_Pawn Opponent;
local MGame_BoardGame MiniGame;
MiniGame = MGame_BoardGame(GetGroup(MGame_MiniGameProxy(Player.MiniGameProxy).mGroupID));
MGame_MiniGameProxy(Player.MiniGameProxy).mOfferDrawAccepted = True;        
i = 0;                                                                      
while (i < MiniGame.mPlayers.Length) {                                      
Opponent = MiniGame.mPlayers[i];                                          
if (Opponent != Player) {                                                 
MGame_MiniGameProxy(Opponent.MiniGameProxy).mOfferDrawAccepted = False; 
MGame_MiniGameProxy(Opponent.MiniGameProxy).sv2cl_OfferDraw_CallStub(Player);
}
i++;                                                                      
}
}
event sv_Resign(Game_Pawn Player) {
local int i;
local Game_Pawn Opponent;
local MGame_BoardGame MiniGame;
MiniGame = MGame_BoardGame(GetGroup(MGame_MiniGameProxy(Player.MiniGameProxy).mGroupID));
MiniGame.Stop();                                                            
i = 0;                                                                      
while (i < MiniGame.mPlayers.Length) {                                      
Opponent = MiniGame.mPlayers[i];                                          
if (Opponent != Player) {                                                 
MGame_MiniGameProxy(Opponent.MiniGameProxy).sv2cl_Resign_CallStub(Player);
}
i++;                                                                      
}
}
event sv_SwitchTurn(Game_Pawn aCurrentPlayer) {
local int i;
local MGame_BoardGame MiniGame;
local Game_Pawn Player;
local Game_Pawn Winner;
local int endStatus;
local float thinkTimeLeft;
thinkTimeLeft = MGame_MiniGameProxy(aCurrentPlayer.MiniGameProxy).GetThinkTime();
MiniGame = MGame_BoardGame(GetGroup(MGame_MiniGameProxy(aCurrentPlayer.MiniGameProxy).mGroupID));
MiniGame.SwitchTurn();                                                      
endStatus = MiniGame.GetResult();                                           
if (endStatus != Class'MGame_MiniGameProxy'.0) {                            
Winner = MiniGame.GetWinner();                                            
}
i = 0;                                                                      
while (i < MiniGame.mPlayers.Length) {                                      
Player = MiniGame.mPlayers[i];                                            
MGame_MiniGameProxy(Player.MiniGameProxy).sv2cl_SwitchTurn_CallStub(MiniGame.GetPlayerTurnID(),thinkTimeLeft);
if (endStatus != Class'MGame_MiniGameProxy'.0) {                          
MGame_MiniGameProxy(Player.MiniGameProxy).sv2cl_GameEnd_CallStub(endStatus,Winner);
}
i++;                                                                      
}
}
event sv_MakeMove(Game_Pawn Mover,int originX,int originY,int destinationX,int destinationY) {
local int i;
local Game_Pawn Player;
local MGame_BoardGame MiniGame;
MiniGame = MGame_BoardGame(GetGroup(MGame_MiniGameProxy(Mover.MiniGameProxy).mGroupID));
if (MiniGame.ValidMove(originX,originY,destinationX,destinationY)) {        
MiniGame.MakeMove(originX,originY,destinationX,destinationY);             
i = 0;                                                                    
while (i < MiniGame.mPlayers.Length) {                                    
Player = MiniGame.mPlayers[i];                                          
if (Player != Mover) {                                                  
MGame_MiniGameProxy(Player.MiniGameProxy).sv2cl_MakeMove_CallStub(originX,originY,destinationX,destinationY);
}
i++;                                                                    
}
goto jl00FD;                                                              
}
}
event sv_StartMiniGame(int aGroupID) {
local int i;
local Game_Pawn Player;
local MGame_MiniGame MiniGame;
MiniGame = GetGroup(aGroupID);                                              
MiniGame.Start();                                                           
i = 0;                                                                      
while (i < MiniGame.mPlayers.Length) {                                      
Player = MiniGame.mPlayers[i];                                            
MGame_MiniGameProxy(Player.MiniGameProxy).SetThinkTime(MiniGame.GetMiniGameTime());
MGame_MiniGameProxy(Player.MiniGameProxy).sv2cl_StartMiniGame_CallStub(); 
MGame_MiniGameProxy(Player.MiniGameProxy).sv2cl_SwitchTurn_CallStub(MiniGame.GetPlayerTurnID(),MiniGame.GetMiniGameTime());
i++;                                                                      
}
}
event sv_AcceptSettings(Game_Pawn sender) {
local int i;
local Game_Pawn receiver;
local int GroupId;
local MGame_MiniGame MiniGame;
GroupId = MGame_MiniGameProxy(sender.MiniGameProxy).mGroupID;               
MGame_MiniGameProxy(sender.MiniGameProxy).mSettingsAccepted = True;         
MiniGame = GetGroup(GroupId);                                               
if (sender == MiniGame.mPlayers[0]) {                                       
i = 0;                                                                    
while (i < MiniGame.mPlayers.Length) {                                    
receiver = MiniGame.mPlayers[i];                                        
if (receiver != sender) {                                               
MGame_MiniGameProxy(receiver.MiniGameProxy).sv2cl_AcceptSettings_CallStub();
}
i++;                                                                    
}
} else {                                                                    
if (sv_AllPlayersAcceptedSettings(GroupId)) {                             
sv_StartMiniGame(GroupId);                                              
}
}
}
event bool sv_AllPlayersAcceptedSettings(int GroupId) {
local int i;
local Game_Pawn Player;
local MGame_MiniGame MiniGame;
MiniGame = GetGroup(GroupId);                                               
i = 0;                                                                      
while (i < MiniGame.mPlayers.Length) {                                      
Player = MiniGame.mPlayers[i];                                            
if (!MGame_MiniGameProxy(Player.MiniGameProxy).mSettingsAccepted) {       
return False;                                                           
}
i++;                                                                      
}
return True;                                                                
}
event sv_CancelSettings(Game_Pawn sender) {
local int i;
local Game_Pawn receiver;
local MGame_MiniGame MiniGame;
MiniGame = GetGroup(MGame_MiniGameProxy(sender.MiniGameProxy).mGroupID);    
if (MGame_MiniGameProxy(sender.MiniGameProxy).mGroupID >= 0) {              
sv_LeaveGame(sender);                                                     
i = 0;                                                                    
while (i < MiniGame.mPlayers.Length) {                                    
receiver = MiniGame.mPlayers[i];                                        
if (receiver != sender) {                                               
MGame_MiniGameProxy(receiver.MiniGameProxy).sv2cl_CancelSettings_CallStub(sender);
}
i++;                                                                    
}
}
}
event sv_UpdateSetting(Game_Pawn sender,int Setting,int Option) {
local int i;
local Game_Pawn receiver;
local int GroupId;
local MGame_MiniGame MiniGame;
GroupId = MGame_MiniGameProxy(sender.MiniGameProxy).mGroupID;               
MiniGame = GetGroup(GroupId);                                               
i = 0;                                                                      
while (i < MiniGame.mPlayers.Length) {                                      
receiver = MiniGame.mPlayers[i];                                          
if (receiver != sender) {                                                 
MGame_MiniGameProxy(receiver.MiniGameProxy).sv2cl_UpdateSetting_CallStub(Setting,Option);
}
i++;                                                                      
}
}
event sv_PlayerDied(Game_Pawn aDeadPlayer) {
local int GroupId;
local int i;
local Game_Pawn Player;
local MGame_MiniGame MiniGame;
GroupId = MGame_MiniGameProxy(aDeadPlayer.MiniGameProxy).mGroupID;          
if (GroupId >= 0) {                                                         
MiniGame = GetGroup(GroupId);                                             
MiniGame.Stop();                                                          
sv_RemoveFromGroup(aDeadPlayer);                                          
i = 0;                                                                    
while (i < MiniGame.mPlayers.Length) {                                    
Player = MiniGame.mPlayers[i];                                          
MGame_MiniGameProxy(Player.MiniGameProxy).sv2cl_GameEnd_CallStub(Class'MGame_MiniGameProxy'.4,aDeadPlayer);
i++;                                                                    
}
MGame_MiniGameProxy(aDeadPlayer.MiniGameProxy).sv2cl_GameEnd_CallStub(Class'MGame_MiniGameProxy'.4,aDeadPlayer);
}
}
event sv_LeaveGame(Game_Pawn aSender) {
local int GroupId;
local int i;
local Game_Pawn receiver;
local MGame_MiniGame MiniGame;
GroupId = MGame_MiniGameProxy(aSender.MiniGameProxy).mGroupID;              
if (GroupId >= 0) {                                                         
MiniGame = GetGroup(GroupId);                                             
MiniGame.Stop();                                                          
sv_RemoveFromGroup(aSender);                                              
i = 0;                                                                    
while (i < MiniGame.mPlayers.Length) {                                    
receiver = MiniGame.mPlayers[i];                                        
MGame_MiniGameProxy(receiver.MiniGameProxy).sv2cl_LeaveGame_CallStub(aSender);
i++;                                                                    
}
}
}
event bool sv_IsPlayerAvailable(Game_Pawn Player) {
return MGame_MiniGameProxy(Player.MiniGameProxy).mGroupID == -1;            
}
event sv_RemoveFromGroup(Game_Pawn aPlayer) {
local int Id;
local MGame_MiniGame MiniGame;
Id = MGame_MiniGameProxy(aPlayer.MiniGameProxy).mGroupID;                   
MiniGame = GetGroup(Id);                                                    
if (MiniGame != None) {                                                     
MiniGame.RemovePlayer(aPlayer);                                           
if (MiniGame.mPlayers.Length == 0) {                                      
RemoveGroup(Id);                                                        
sv_FreeID(Id);                                                          
}
}
}
event sv_AddToGroup(int aGroupID,Game_Pawn aPlayer) {
local MGame_MiniGame MiniGame;
MiniGame = GetGroup(aGroupID);                                              
MiniGame.AddPlayer(aPlayer);                                                
MGame_MiniGameProxy(aPlayer.MiniGameProxy).mGroupID = aGroupID;             
}
event sv_FreeID(int Id) {
mFreeIDs[mFreeIDs.Length] = Id;                                             
}
event int sv_GrabID() {
local int Id;
Id = -1;                                                                    
if (mFreeIDs.Length > 0) {                                                  
Id = mFreeIDs[mFreeIDs.Length - 1];                                       
mFreeIDs.Length = mFreeIDs.Length - 1;                                    
} else {                                                                    
Id = mLastID;                                                             
mLastID++;                                                                
}
return Id;                                                                  
}
function sv_OnLogout(Game_PlayerPawn aPawn) {
sv_LeaveGame(aPawn);                                                        
}
native function RemoveGroup(int GroupId);
native function AddGroup(int GroupId,MGame_MiniGame pMiniGame);
native function MGame_MiniGame GetGroup(int GroupId);
*/
