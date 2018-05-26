﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Framework.Attributes;

namespace SBGame
{
    
    
    public class Game_InstanceInfo : UObject
    {
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public int mInstanceId;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public bool mFirstLogin;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public float mTime;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public SBWorld mDeathWorld;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public SBPortal mDeathPortal;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public SBWorld mDestinationWorld;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public SBPortal mDestinationPortal;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public NameProperty mEffectsTag;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public List<Game_PlayerInfo> mPlayers = new List<Game_PlayerInfo>();
        
        public Game_InstanceInfo()
        {
        }
    }
}
/*
function sv_RemovePlayer(Game_PlayerController PlayerController) {
local int idx;
idx = 0;                                                                    
while (idx < mPlayers.Length) {                                             
if (mPlayers[idx].mController == PlayerController) {                      
DestroyPlayerInfo(mPlayers[idx]);                                       
mPlayers.Remove(idx,1);                                                 
return;                                                                 
}
idx++;                                                                    
}
}
function sv_AddPlayer(Game_PlayerController PlayerController,SBRoute SBRoute) {
local Game_PlayerInfo playerInfo;
playerInfo = new Class'Game_PlayerInfo';                                    
playerInfo.mController = PlayerController;                                  
if (Game_Route(SBRoute) != None) {                                          
playerInfo.mDeathWorld = Game_Route(SBRoute).DeathWorld;                  
playerInfo.mDeathPortal = Game_Route(SBRoute).DeathPortal;                
}
mPlayers[mPlayers.Length] = playerInfo;                                     
}
function bool sv_ContainsName(string PlayerName) {
local int idx;
idx = 0;                                                                    
while (idx < mPlayers.Length) {                                             
if (mPlayers[idx].sv_GetName() == PlayerName) {                           
return True;                                                            
}
idx++;                                                                    
}
return False;                                                               
}
function bool sv_ContainsController(Game_PlayerController PlayerController) {
local int idx;
idx = 0;                                                                    
while (idx < mPlayers.Length) {                                             
if (mPlayers[idx].sv_GetController().CharacterID == PlayerController.CharacterID) {
return True;                                                            
}
idx++;                                                                    
}
return False;                                                               
}
function sv_TriggerEffects(Game_GameInfo GameInfo,Game_PlayerController PlayerController) {
local int idx;
if (mEffectsTag == 'None') {                                                
return;                                                                   
}
idx = 0;                                                                    
while (idx < mPlayers.Length) {                                             
if (mPlayers[idx].sv_GetController().CharacterID == PlayerController.CharacterID) {
GameInfo.TriggerEvent(mEffectsTag,GameInfo,mPlayers[idx].sv_GetPawn()); 
return;                                                                 
}
idx++;                                                                    
}
}
function bool sv_DeathTeleport(Game_PlayerController PlayerController) {
local int idx;
idx = 0;                                                                    
while (idx < mPlayers.Length) {                                             
if (mPlayers[idx].sv_GetController().CharacterID == PlayerController.CharacterID) {
if (mPlayers[idx].mDeathWorld != None) {                                
mPlayers[idx].sv_Teleport(mPlayers[idx].mDeathWorld,mPlayers[idx].mDeathPortal);
mPlayers.Remove(idx,1);                                               
return True;                                                          
}
if (mDeathWorld != None) {                                              
mPlayers[idx].sv_Teleport(mDeathWorld,mDeathPortal);                  
mPlayers.Remove(idx,1);                                               
return True;                                                          
}
return False;                                                           
}
idx++;                                                                    
}
return False;                                                               
}
function sv_InstanceFinished() {
local int idx;
idx = 0;                                                                    
while (idx < mPlayers.Length) {                                             
mPlayers[idx].sv_Teleport(mDestinationWorld,mDestinationPortal);          
idx++;                                                                    
}
idx = 0;                                                                    
while (idx < mPlayers.Length) {                                             
DestroyPlayerInfo(mPlayers[idx]);                                         
idx++;                                                                    
}
mPlayers.Length = 0;                                                        
}
function bool sv_IsEmpty() {
return mPlayers.Length == 0;                                                
}
function int sv_GetInstance() {
return mInstanceId;                                                         
}
native function DestroyPlayerInfo(Game_PlayerInfo playerInfo);
*/
