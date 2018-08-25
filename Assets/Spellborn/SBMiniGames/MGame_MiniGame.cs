

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
    
    
    [System.Serializable] public class MGame_MiniGame : UObject
    {
        
        public string mConfigGUI = string.Empty;
        
        public string mBoardGUI = string.Empty;
        
        public MGame_Config Config;
        
        public List<Game_Pawn> mPlayers = new List<Game_Pawn>();
        
        public int mPlayerTurnID;
        
        public bool mIsTimedGame;
        
        public bool ThinkTimeOut;
        
        public bool Started;
        
        //public delegate<OnTimeUpdate> @__OnTimeUpdate__Delegate;
        
        public MGame_MiniGame()
        {
        }
    }
}
/*
function Debug() {
}
function Game_Pawn GetCurrentPlayer() {
return mPlayers[mPlayerTurnID];                                             
}
event Stop() {
Started = False;                                                            
}
function Start() {
local int Time;
local int i;
Started = True;                                                             
if (IsTimedGame()) {                                                        
Time = GetMiniGameTime();                                                 
i = 0;                                                                    
while (i < mPlayers.Length) {                                             
MGame_MiniGameProxy(mPlayers[i].MiniGameProxy).SetThinkTime(Time);      
OnTimeUpdate(mPlayers[i],Time);                                         
i++;                                                                    
}
}
}
function SetThinkTime(Game_Pawn aGamePawn,float aThinkTime) {
MGame_MiniGameProxy(aGamePawn.MiniGameProxy).SetThinkTime(aThinkTime);      
OnTimeUpdate(aGamePawn,aThinkTime);                                         
}
function SwitchTurn() {
}
function SetPlayerTurnID(int PlayerID) {
mPlayerTurnID = PlayerID;                                                   
}
function SetPlayerTurn(Game_Pawn Player) {
local int i;
local bool found;
found = False;                                                              
i = 0;                                                                      
while (i < mPlayers.Length && !found) {                                     
if (mPlayers[i] == Player) {                                              
found = True;                                                           
SetPlayerTurnID(i);                                                     
}
i++;                                                                      
}
}
function RemovePlayer(Game_Pawn Player) {
local bool found;
local int i;
found = False;                                                              
MGame_MiniGameProxy(Player.MiniGameProxy).mGroupID = -1;                    
i = 0;                                                                      
while (i < mPlayers.Length - 1) {                                           
if (mPlayers[i] == Player) {                                              
found = True;                                                           
}
if (found) {                                                              
mPlayers[i] = mPlayers[i + 1];                                          
}
i++;                                                                      
}
if (found
|| !found
&& mPlayers[mPlayers.Length - 1] == Player) {
mPlayers.Length = mPlayers.Length - 1;                                    
}
}
function AddPlayer(Game_Pawn Player) {
mPlayers.Length = mPlayers.Length + 1;                                      
mPlayers[mPlayers.Length - 1] = Player;                                     
}
function Initialize() {
Config.Initialize();                                                        
}
function int GetMiniGameTime() {
return 0;                                                                   
}
function bool IsTimedGame() {
return mIsTimedGame;                                                        
}
native function int GetPlayerTurnID();
native function Game_Pawn GetWinner();
native function int GetResult();
native function OnFrame(float aDeltaTime);
delegate OnTimeUpdate(Game_Pawn Player,int aSeconds);
*/
