﻿using System;
using System.Collections.Generic;
using Engine;
using SBBase;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Game_PlayerGuilds : Base_Component
    {
        public const int GRR_GUILD_TOURNAMENTS_SIGN_UP = 524288;
        public const int GRR_ACCEPT_GUILD_QUESTS = 262144;
        public const int GRR_ACCESS_GUILD_VAULT = 131072;
        public const int GRR_ADD_CHEST_TO_GUILD_VAULT = 65536;
        public const int GRR_BUY_TROHPY_SLOTS = 32768;
        public const int GRR_OTHER_PLAYERS_TROPHY_REMOVE = 16384;
        public const int GRR_SET_EVENT_PRIO = 8192;
        public const int GRR_EDIT_GUILD_EVENTS = 4096;
        public const int GRR_REMOVE_GUILD_EVENTS = 2048;
        public const int GRR_ADD_GUILD_EVENTS = 1024;
        public const int GRR_SET_MOTD = 32;
        public const int GRR_ALL_RIGHTS = -1;
        public const int GRR_MANAGE_RANKS = 2097152;
        public const int GRR_FIGHT_RANKED_FIGHTS = 1048576;
        public const int GRR_OFFICERS_DESCRIPTION_W = 512;
        public const int GRR_OFFICERS_DESCRIPTION_R = 256;
        public const int GRR_OTHER_PLAYERS_DESCRIPTION_W = 128;
        public const int GRR_SET_PLAYER_RANK = 64;
        public const int GRR_INVITE_PLAYERS = 16;
        public const int GRR_OFFICERS_CHAT_W = 8;
        public const int GRR_OFFICERS_CHAT_R = 4;
        public const int GRR_GUILD_CHAT_W = 2;
        public const int GRR_GUILD_CHAT_R = 1;
        public const int CREATE_GUILD_COST = 5000;

        [NonSerialized] public bool mInGuild;
        [NonSerialized] public int mGuildID;
        [NonSerialized] public string mGuildName = string.Empty;
        [NonSerialized] public byte mGuildLogoID;
        [NonSerialized] public byte mGuildColor1;
        [NonSerialized] public byte mGuildColor2;
        [NonSerialized] public string mGuildMOTD = string.Empty;
        [NonSerialized] public int mGuildRanking;
        [NonSerialized] public int mGuildYourRank;
        [NonSerialized] public EventNotification mGuildChanged;
        [NonSerialized] public List<ranks> mRanks = new List<ranks>();
        [NonSerialized] public List<SBGuildMember> mGuildMembers = new List<SBGuildMember>();

        [Serializable] public struct ranks
        {
            public int Level;
            public string Name;
            public int Rights;
        }

        public enum eGuildRequestResult
        {
            GRR_NONE,
            GRR_BUSY,
            GRR_ACCEPT,
            GRR_DECLINE,
            GRR_INVITE_SUCCESS,
            GRR_MEMBER_IN_OTHER_GUILD,
            GRR_MEMBER_ON_TRAVELING,
            GRR_IGNORED_ME,
            GRR_INSUFFICIENT_RIGHTS,
            GRR_INCORRECT_INVITER,
            GRR_UNKNOWN_CHARACTER,
            GRR_UNKNOWN_MEMBER_WORLD,
            GRR_UNKNOWN_GUILD,
            GRR_EMPTY_GUILD,
            GRR_UNKNOWN_RANK,
            GRR_DEFAULT_RANK,
            GRR_CREATE_FAILED,
            GRR_NOT_ENOUGH_COST,
            GRR_ALREADY_EXIST_GUILD_NAME,
            GRR_DISBAND_FAILED,
            GRR_ADD_MEMBER_FAILED,
            GRR_REMOVE_MEMBER_FAILED,
            GRR_MEMBER_RANK_SET_FAILED,
            GRR_INVITE_FAILED,
            GRR_KICK_FAILED,
            GRR_LEAVE_FAILED,
            GRR_PROMOTE_FAILED,
            GRR_DEMOTE_FAILED,
            GRR_RANK_SET_FAILED,
            GRR_RANK_UPDATE_FAILED,
            GRR_RANK_DELETE_FAILED,
            GRR_RANK_RIGHTS_FAILED,
            GRR_SET_MOTD_FAILED,
            GRR_GET_GUILD_INFO_FAILED,
            GRR_GUILD_DATA_DB_FAILED,
            GRR_GUILD_RANK_DB_FAILED,
            GRR_GUILD_MEMBER_DB_FAILED,
        }

        public enum eGuildRemoveMemberCode
        {
            GRMC_NONE,
            GRMC_KICK,
            GRMC_LEAVE,
            GRMC_REMOVE_CHARACTER,
            GRMC_DISBAND,
        }

        public override void Initialize(Actor outer)
        {
            base.Initialize(outer);
            GetGuildInfo();
        }

        void GetGuildInfo()
        {
            Debug.LogWarning("TODO retrieve guild info");
        }
    }
}
/*
native event SBGuildMember GetGuildMember(string aPlayerName);
native event bool InGuildWith(Game_Pawn aPawn);
event GuildMOTDSet(int guildID,string motd) {
if (mGuildID != guildID) {                                                  
return;                                                                   
}
mGuildMOTD = motd;                                                          
RefreshGuildList();                                                         
}
event GuildSetRightsRank(int guildID,int RankLevel,int Rights) {
local int i;
if (mGuildID != guildID) {                                                  
return;                                                                   
}
i = 0;                                                                      
while (i < mRanks.Length) {                                                 
if (mRanks[i].Level == RankLevel) {                                       
mRanks[i].Rights = Rights;                                              
goto jl0065;                                                            
}
++i;                                                                      
}
RefreshGuildRanks();                                                        
}
event GuildDeleteRank(int guildID,int deleteRankLevel,int demoteRankLevel) {
local int i;
if (mGuildID != guildID) {                                                  
return;                                                                   
}
i = 0;                                                                      
while (i < mRanks.Length) {                                                 
if (mRanks[i].Level == deleteRankLevel) {                                 
mRanks[i].Level = -1;                                                   
mRanks[i].Name = "";                                                    
mRanks[i].Rights = 0;                                                   
RefreshGuildRanks();                                                    
goto jl0090;                                                            
}
i++;                                                                      
}
i = 0;                                                                      
while (i < mGuildMembers.Length) {                                          
if (mGuildMembers[i].RankLevel == deleteRankLevel) {                      
mGuildMembers[i].RankLevel = demoteRankLevel;                           
}
if (mGuildMembers[i].CharacterID == GetPlayerCharacterID()) {             
mGuildYourRank = mGuildMembers[i].RankLevel;                            
}
++i;                                                                      
}
RefreshGuildList();                                                         
}
event GuildSetRank(int guildID,int RankLevel,string rankName,int Rights) {
if (mGuildID != guildID) {                                                  
return;                                                                   
}
SetGuildRank(RankLevel,rankName,Rights);                                    
RefreshGuildRanks();                                                        
RefreshGuildList();                                                         
}
event GuildPromoteDemoteMember(int guildID,int memberID,int RankLevel) {
local int i;
local string messageStr;
if (mGuildID != guildID) {                                                  
return;                                                                   
}
i = 0;                                                                      
while (i < mGuildMembers.Length) {                                          
if (mGuildMembers[i].CharacterID == memberID) {                           
mGuildMembers[i].RankLevel = RankLevel;                                 
if (memberID == GetPlayerCharacterID()) {                               
mGuildYourRank = RankLevel;                                           
}
if (RankLevel == 10) {                                                  
messageStr = "[PLAYERNAME] is the new Guild Master!";                 
static.ReplaceText(messageStr,"[PLAYERNAME]",mGuildMembers[i].Name);  
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
}
goto jl0126;                                                            
}
++i;                                                                      
}
RefreshGuildList();                                                         
}
event GuildRemoveMember(int guildID,int CharacterID,byte removeCode) {
local int i;
local string messageStr;
if (CharacterID == GetPlayerCharacterID()) {                                
GuildDestroy(removeCode);                                                 
} else {                                                                    
if (mGuildID == guildID) {                                                
i = 0;                                                                  
while (i < mGuildMembers.Length) {                                      
if (mGuildMembers[i].CharacterID == CharacterID) {                    
switch (removeCode) {                                               
case 1 :                                                          
messageStr = Class'StringReferences'.default.PLAYERNAME_has_been_kicked_from_your_guild.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",mGuildMembers[i].Name);
Game_Desktop(Outer.Player.GUIDesktop).AddScreenMessage(messageStr);
break;                                                          
case 2 :                                                          
messageStr = Class'StringReferences'.default.PLAYERNAME_has_left_your_guild.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",mGuildMembers[i].Name);
Game_Desktop(Outer.Player.GUIDesktop).AddScreenMessage(messageStr);
break;                                                          
case 3 :                                                          
messageStr = "[PLAYERNAME] has been deleted from your guild";   
static.ReplaceText(messageStr,"[PLAYERNAME]",mGuildMembers[i].Name);
Game_Desktop(Outer.Player.GUIDesktop).AddScreenMessage(messageStr);
break;                                                          
default:                                                          
}
mGuildMembers.Remove(i,1);                                          
RefreshGuildList();                                                 
goto jl0212;                                                        
}
++i;                                                                  
}
}
}
}
event GuildAddMember(int guildID,int CharacterID,int ClassType,int Level,string Name,int Location,int RankLevel,bool Online) {
local string messageStr;
if (mGuildID == guildID) {                                                  
SetGuildMember(CharacterID,ClassType,Level,Name,Location,RankLevel,Online);
RefreshGuildList();                                                       
if (GetPlayerCharacterID() == CharacterID) {                              
Game_Desktop(Outer.Player.GUIDesktop).AddScreenMessage(Class'StringReferences'.default.You_have_joined_a_guild.Text);
} else {                                                                  
messageStr = Class'StringReferences'.default.PLAYERNAME_has_joined_your_guild.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",Name);                     
Game_Desktop(Outer.Player.GUIDesktop).AddScreenMessage(messageStr);     
}
}
}
delegate OnGuildInviteReq(string fromPawnName,int fromUserID,int guildID,string guildName,int LogoId,int Color1,int Color2);
event GuildInviteReq(string fromPawnName,int fromUserID,int guildID,string guildName,int LogoId,int Color1,int Color2) {
OnGuildInviteReq(fromPawnName,fromUserID,guildID,guildName,LogoId,Color1,Color2);
}
event GuildDestroy(byte removeCode) {
switch (removeCode) {                                                       
case 1 :                                                                  
Game_Desktop(Outer.Player.GUIDesktop).AddScreenMessage(Class'StringReferences'.default.You_have_been_kicked_from_your_guild.Text);
break;                                                                  
case 2 :                                                                  
Game_Desktop(Outer.Player.GUIDesktop).AddScreenMessage(Class'StringReferences'.default.You_have_left_your_guild.Text);
break;                                                                  
case 4 :                                                                  
Game_Desktop(Outer.Player.GUIDesktop).AddScreenMessage(Class'StringReferences'.default.Your_guild_has_been_disbanded.Text);
break;                                                                  
default:                                                                  
}
mGuildMembers.Length = 0;                                                   
ClearGuildInfo();                                                           
RefreshGuildList();                                                         
RefreshGuildRanks();                                                        
}
event CreateGuild(bool inviteAck) {
if (inviteAck) {                                                            
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.You_have_joined_a_guild_.Text,Class'Game_Desktop'.7);
} else {                                                                    
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.You_have_created_a_guild_.Text,Class'Game_Desktop'.7);
}
}
event SetGuildRank(int RankLevel,string rankName,int Rights) {
local ranks Data;
local int i;
i = 0;                                                                      
while (i < mRanks.Length) {                                                 
if (mRanks[i].Level == RankLevel) {                                       
mRanks[i].Name = rankName;                                              
mRanks[i].Rights = Rights;                                              
return;                                                                 
}
i++;                                                                      
}
i = 0;                                                                      
while (i < mRanks.Length) {                                                 
if (mRanks[i].Level == -1) {                                              
mRanks[i].Name = rankName;                                              
mRanks[i].Rights = Rights;                                              
mRanks[i].Level = RankLevel;                                            
return;                                                                 
}
i++;                                                                      
}
Data.Name = rankName;                                                       
Data.Level = RankLevel;                                                     
Data.Rights = Rights;                                                       
mRanks[mRanks.Length] = Data;                                               
}
event SetGuildMember(int CharacterID,int ClassType,int Level,string Name,int Location,int RankLevel,bool Online) {
mGuildMembers.Insert(mGuildMembers.Length,1);                               
mGuildMembers[mGuildMembers.Length - 1] = new Class'SBGuildMember';         
mGuildMembers[mGuildMembers.Length - 1].CharacterID = CharacterID;          
mGuildMembers[mGuildMembers.Length - 1].ClassType = ClassType;              
mGuildMembers[mGuildMembers.Length - 1].Level = Level;                      
mGuildMembers[mGuildMembers.Length - 1].Name = Name;                        
mGuildMembers[mGuildMembers.Length - 1].Location = Location;                
mGuildMembers[mGuildMembers.Length - 1].RankLevel = RankLevel;              
mGuildMembers[mGuildMembers.Length - 1].Online = Online;                    
if (CharacterID == GetPlayerCharacterID()) {                                
mGuildYourRank = RankLevel;                                               
}
}
event SetGuild(int guildID,string guildName,int LogoId,int Color1,int Color2,int ranking,string motd) {
mGuildMembers.Length = 0;                                                   
ClearGuildInfo();                                                           
mGuildID = guildID;                                                         
mGuildName = guildName;                                                     
mGuildLogoID = LogoId;                                                      
mGuildColor1 = Color1;                                                      
mGuildColor2 = Color2;                                                      
mGuildRanking = ranking;                                                    
mGuildMOTD = motd;                                                          
mInGuild = True;                                                            
}
event OnFailResult(byte Result,optional string pawnName) {
local string messageStr;
switch (Result) {                                                           
case 16 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Failed_to_create_guild_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 17 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.You_do_not_have_enough_money_guild_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 18 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.A_guild_with_that_name_already_exists_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 19 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Failed_to_disband_guild_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 8 :                                                                  
messageStr = Class'StringReferences'.default.You_are_currently_not_allowed_to_do_that_.Text;
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
case 20 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Failed_to_add_guild_member_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 21 :                                                                 
break;                                                                  
case 24 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Failed_to_kick_guild_member_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 25 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Failed_to_leave_the_guild_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 26 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Failed_to_promote_guild_member_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 27 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Failed_to_demote_guild_member_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 28 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Failed_to_add_the_guild_rank_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 29 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Failed_to_set_the_guild_rank_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 30 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Failed_to_delete_the_guild_rank_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 31 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Failed_to_set_the_guild_rank_rights_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 32 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Failed_to_set_the_guild_Message_of_the_Day_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 22 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Failed_to_change_guild_member_rank_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 33 :                                                                 
case 34 :                                                                 
case 35 :                                                                 
case 36 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Guild_system_error_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 1 :                                                                  
case 6 :                                                                  
messageStr = Class'StringReferences'.default.PLAYERNAME_is_busy_try_again_later_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",pawnName);                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
case 3 :                                                                  
messageStr = Class'StringReferences'.default.PLAYERNAME_has_declined_to_join_your_guild_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",pawnName);                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
case 4 :                                                                  
messageStr = Class'StringReferences'.default.You_have_invited_PLAYERNAME_to_your_guild_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",pawnName);                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
case 5 :                                                                  
messageStr = Class'StringReferences'.default.PLAYERNAME_is_already_in_another_guild_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",pawnName);                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
case 10 :                                                                 
messageStr = Class'StringReferences'.default.PLAYERNAME_is_unknown__check_the_spelling_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",pawnName);                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
case 7 :                                                                  
messageStr = Class'StringReferences'.default.PLAYERNAME_ignored_you_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",pawnName);                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
case 9 :                                                                  
case 11 :                                                                 
case 12 :                                                                 
case 14 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Guild_system_error_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 13 :                                                                 
break;                                                                  
case 15 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.You_cannot_alter_the_three_default_guild_ranks_.Text,Class'Game_Desktop'.7);
break;                                                                  
default:                                                                  
}
}
event OnSetClass(int CharacterID,int aNewClass) {
local int i;
i = 0;                                                                      
while (i < mGuildMembers.Length) {                                          
if (mGuildMembers[i].CharacterID == CharacterID) {                        
mGuildMembers[i].ClassType = aNewClass;                                 
RefreshGuildList();                                                     
goto jl0062;                                                            
}
++i;                                                                      
}
}
event OnLevelUp(int CharacterID,int aNewLevel) {
local int i;
i = 0;                                                                      
while (i < mGuildMembers.Length) {                                          
if (mGuildMembers[i].CharacterID == CharacterID) {                        
mGuildMembers[i].Level = aNewLevel;                                     
RefreshGuildList();                                                     
goto jl0062;                                                            
}
++i;                                                                      
}
}
event Offline(int pawnID) {
local int i;
i = 0;                                                                      
while (i < mGuildMembers.Length) {                                          
if (mGuildMembers[i].CharacterID == pawnID) {                             
mGuildMembers[i].Online = False;                                        
RefreshGuildList();                                                     
goto jl005F;                                                            
}
++i;                                                                      
}
}
delegate OnGuildOnline();
event Online(int pawnID,int worldID) {
local int i;
i = 0;                                                                      
while (i < mGuildMembers.Length) {                                          
if (mGuildMembers[i].CharacterID == pawnID) {                             
mGuildMembers[i].Online = True;                                         
mGuildMembers[i].Location = worldID;                                    
RefreshGuildList();                                                     
OnGuildOnline();                                                        
goto jl0083;                                                            
}
++i;                                                                      
}
}
delegate OnGuildRanksRefresh();
event RefreshGuildRanks() {
SortRankList();                                                             
OnGuildRanksRefresh();                                                      
}
delegate OnGuildListRefresh();
event RefreshGuildList() {
OnGuildListRefresh();                                                       
mGuildChanged.Trigger();                                                    
}
function int GetRankRights(int RankLevel) {
local int i;
i = 0;                                                                      
while (i < mRanks.Length) {                                                 
if (mRanks[i].Level == RankLevel) {                                       
return mRanks[i].Rights;                                                
}
++i;                                                                      
}
return 0;                                                                   
}
function SortRankList() {
local int i;
local int j;
local ranks Data;
i = 0;                                                                      
while (i < mRanks.Length - 1) {                                             
j = i + 1;                                                                
while (j < mRanks.Length) {                                               
if (mRanks[i].Level < mRanks[j].Level) {                                
Data = mRanks[i];                                                     
mRanks[i] = mRanks[j];                                                
mRanks[j] = Data;                                                     
}
j++;                                                                    
}
i++;                                                                      
}
}
function string GetGuildRankName(int RankLevel) {
local int i;
i = 0;                                                                      
while (i < mRanks.Length) {                                                 
if (mRanks[i].Level == RankLevel) {                                       
return mRanks[i].Name;                                                  
}
++i;                                                                      
}
return "";                                                                  
}
function ClearGuildInfo() {
local int i;
mGuildID = 0;                                                               
mGuildName = "";                                                            
mGuildLogoID = 0;                                                           
mGuildColor1 = 0;                                                           
mGuildColor2 = 0;                                                           
mGuildRanking = 0;                                                          
mGuildMOTD = "";                                                            
mInGuild = False;                                                           
i = 0;                                                                      
while (i < mRanks.Length) {                                                 
mRanks[i].Level = -1;                                                     
mRanks[i].Name = "";                                                      
mRanks[i].Rights = 0;                                                     
++i;                                                                      
}
}
function bool AllowRights(int rankRightConst) {
if ((GetRankRights(mGuildYourRank) & rankRightConst) == rankRightConst) {   
return True;                                                              
}
return False;                                                               
}
function int GetPlayerCharacterID() {
return Game_Pawn(Outer.Pawn).GetCharacterID();                              
}
native function GuildInviteAck(int guildID,string fromPawnName,int fromUserID,int responseCode);
native function GuildSetMOTD(string motd);
native function GuildRankSetRights(int RankLevel,int rightsFlag);
native function GuildRankDelete(int RankLevel);
native function GuildRankSet(int RankLevel,string rankName);
native function GuildDemote(int demotePawnID);
native function GuildPromote(int promotePawnID);
native function GuildLeave();
native function GuildKick(int kickPawnID);
native function GuildInvite(string toPawnName);
native function GuildDisband();
native function GuildCreate(string guildName,int LogoId,int col1,int col2);
function cl_OnShutdown() {
Super.cl_OnShutdown();                                                      
mGuildChanged.Delete();                                                     
}
*/