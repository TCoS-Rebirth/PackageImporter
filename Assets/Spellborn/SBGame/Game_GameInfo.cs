﻿using System;
using Engine;
using SBBase;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Game_GameInfo : Base_GameInfo
    {

        public SBClock mClock;

        public bool InitializedStatues;

        [FoldoutGroup("Arena")]
        [FieldConst()]
        public bool HaveArenaManager;

        [FoldoutGroup("Arena")]
        [FieldConst()]
        public bool HaveArenaProxy;

        [FoldoutGroup("Arena")]
        public int ArenaInstanceWorldId;

        [FoldoutGroup("MiniGames")]
        [FieldConst()]
        public bool HaveMiniGameProxy;

        public Game_MiniGameManager MiniGameManager;

        [FoldoutGroup("Game_GameInfo")]
        public NameProperty PlayerEvent;

        public Game_TradeManager mTradeManager;

        public Game_GameInfo()
        {
        }
    }
}
/*
private native function sv_NativeOnLogout(Game_PlayerPawn aPawn);
function array<Game_MiniGameDescription> GetMiniGames() {
local array<Game_MiniGameDescription> MiniGames;
MiniGames.Length = 2;                                                       
MiniGames[0] = new Class'Game_MiniGameDescription';                         
MiniGames[0].Title = Class'StringReferences'.default.Classic_Chess.Text;    
MiniGames[0].Description = "Minigame";                                      
MiniGames[0].IconMaterial = mChessIcon;                                     
MiniGames[1] = new Class'Game_MiniGameDescription';                         
MiniGames[1].Title = Class'StringReferences'.default.International_Checkers.Text;
MiniGames[1].Description = "Minigame";                                      
MiniGames[1].IconMaterial = mCheckersIcon;                                  
return MiniGames;                                                           
}
protected final function Game_Desktop cl_GetDesktop() {
return Game_Desktop(Base_GameClient(Class'Actor'.static.GetGameEngine()).GPlayerController.Player.GUIDesktop);
}
event sv_CreateStatues() {
Class'Game_StatuePawn'.StaticCreateStatuePawns(self);                       
}
event PlayerStart sv_GetPlayerStart(string aNavigationTag) {
local NavigationPoint navpoint;
local PlayerStart preferredStart;
local PlayerStart curStart;
navpoint = Level.NavigationPointList;                                       
while (navpoint != None) {                                                  
curStart = PlayerStart(navpoint);                                         
if (curStart != None) {                                                   
if (preferredStart == None) {                                           
preferredStart = curStart;                                            
}
if (aNavigationTag == curStart.NavigationTag) {                         
preferredStart = curStart;                                            
goto jl008D;                                                          
}
}
navpoint = navpoint.nextNavigationPoint;                                  
}
return preferredStart;                                                      
}
event cl_OnUpdate() {
Super.cl_OnUpdate();                                                        
if (mClock != None) {                                                       
mClock.cl_OnUpdate();                                                     
}
}
event cl_OnTick(float delta) {
Super.cl_OnTick(delta);                                                     
if (mClock != None) {                                                       
mClock.cl_OnFrame(delta);                                                 
}
}
event cl_OnLogout(Actor controllerActor) {
local Game_Desktop desktop;
desktop = cl_GetDesktop();                                                  
desktop.HideAllWindows();                                                   
desktop.Clear();                                                            
Super.cl_OnLogout(controllerActor);                                         
}
event sv_OnLogout(int aAccountID,Base_Pawn aPawn) {
local Game_PlayerPawn pp;
pp = Game_PlayerPawn(aPawn);                                                
if (pp != None) {                                                           
if (PlayerEvent != 'None') {                                              
UntriggerEvent(PlayerEvent,self,pp);                                    
}
if (MiniGameManager != None) {                                            
MiniGameManager.sv_OnLogout(pp);                                        
}
if (mTradeManager != None) {                                              
mTradeManager.sv_OnLogout(pp);                                          
}
sv_NativeOnLogout(pp);                                                    
}
Super.sv_OnLogout(aAccountID,aPawn);                                        
}
event sv_OnPostLogin(Game_PlayerPawn aPawn) {
local string Message;
aPawn.sv_SetInvisible(False);                                               
aPawn.UpdateTouching();                                                     
Message = Class'StringReferences'.default.Now_entering_zone_chat_WORLDNAME.Text;
static.ReplaceText(Message,"[WORLDNAME]",sv_GetWorldName());                
Game_PlayerController(aPawn.Controller).Chat.sv2cl_OnMessage_CallStub("",Message,Class'Game_Desktop'.1);
Message = Class'StringReferences'.default.Now_entering_trade_chat_WORLDNAME.Text;
static.ReplaceText(Message,"[WORLDNAME]",sv_GetWorldName());                
Game_PlayerController(aPawn.Controller).Chat.sv2cl_OnMessage_CallStub("",Message,Class'Game_Desktop'.2);
}
native function string sv_GetWorldName();
event sv_OnLogin(Game_PlayerController aController,string portalName,string RouteName);
event OnCreateComponents() {
local class<Game_MiniGameManager> MiniGameManagerClass;
Super.OnCreateComponents();                                                 
mClock = new (self) Class'SBClock';                                         
if (IsServer()) {                                                           
mTradeManager = new (self) Class'Game_TradeManager';                      
if (HaveMiniGameProxy) {                                                  
MiniGameManagerClass = Class<Game_MiniGameManager>(static.DynamicLoadObject("SBMiniGames.MGame_MiniGameManager",Class'Class'));
MiniGameManager = new (self) MiniGameManagerClass;                      
}
}
}
event sv_OnShutdown() {
Super.sv_OnShutdown();                                                      
}
event sv_OnInit() {
Super.sv_OnInit();                                                          
}
*/