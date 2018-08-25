﻿using System;
using System.Collections.Generic;
using Engine;
using SBBase;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Game_PlayerFriends : Base_Component
    {
        [NonSerialized] public List<SBFriendsMember> FriendsMembers = new List<SBFriendsMember>();

        public enum eFriendsResultCode
        {
            FRC_NONE,
            FRC_ACCEPT,
            FRC_DECLINE,
            FRC_OFFLINE,
            FRC_SELF_INVITE,
            FRC_BUSY,
            FRC_IGNORED_ME,
            FRC_INVITE_SUCCESS,
            FRC_MEMBER_ON_TRAVELING,
            FRC_RELATIONSHIP_ALREADY,
            FRC_UNKNOWN_CHARACTER,
            FRC_INCORRECT_INVITER,
            FRC_ADD_RELATIONSHIP_FAILED,
            FRC_REMOVE_RELATIONSHIP_FAILED,
            FRC_SET_RELATIONSHIP_FAILED,
            FRC_GET_RELATIONSHIP_INFO_FAILED,
        }

        public enum eFriendsListFlag
        {
            FLF_UNKNOWN,
            FLF_FRIEND,
            FLF_FRIEND_READY,
            FLF_IGNORE,
        }

        public override void Initialize(Actor outer)
        {
            base.Initialize(outer);
            GetFriendList();
        }

        void GetFriendList()
        {
            Debug.LogWarning("TODO retrieve friendlist");
        }
    }
}
/*
native function bool IsIgnoringName(string aCharacterName);
native function bool IsIgnoring(Game_Pawn aPawn);
native function bool IsFriendWith(Game_Pawn aPawn);
event RemoveMember(string friendPawnName,bool removeCharacter) {
local int idx;
local SBFriendsMember member;
local string messageStr;
idx = 0;                                                                    
while (idx < FriendsMembers.Length) {                                       
member = FriendsMembers[idx];                                             
if (member.Name == friendPawnName) {                                      
FriendsMembers.Remove(idx,1);                                           
goto jl0059;                                                            
}
++idx;                                                                    
}
if (removeCharacter == True) {                                              
messageStr = "[PLAYERNAME] has been deleted.";                            
static.ReplaceText(messageStr,"[PLAYERNAME]",friendPawnName);             
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
} else {                                                                    
messageStr = Class'StringReferences'.default.PLAYERNAME_has_been_removed_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",friendPawnName);             
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
}
OnRefreshView();                                                            
}
event OnFriendSet(string toPawnName,int Flag,int toPawnID,int toPawnLevel,int toPawnClass,int toPawnWorld,bool isOnline) {
local int i;
i = 0;                                                                      
while (i < FriendsMembers.Length) {                                         
if (FriendsMembers[i].CharacterID == toPawnID) {                          
FriendsMembers[i].Flag = Flag;                                          
FriendsMembers[i].Level = toPawnLevel;                                  
FriendsMembers[i].Class = toPawnClass;                                  
FriendsMembers[i].world = toPawnWorld;                                  
FriendsMembers[i].Online = isOnline;                                    
return;                                                                 
}
++i;                                                                      
}
FriendsMembers.Insert(FriendsMembers.Length,1);                             
FriendsMembers[FriendsMembers.Length - 1] = new Class'SBFriendsMember';     
FriendsMembers[FriendsMembers.Length - 1].Name = toPawnName;                
FriendsMembers[FriendsMembers.Length - 1].Flag = Flag;                      
FriendsMembers[FriendsMembers.Length - 1].CharacterID = toPawnID;           
FriendsMembers[FriendsMembers.Length - 1].Level = toPawnLevel;              
FriendsMembers[FriendsMembers.Length - 1].Class = toPawnClass;              
FriendsMembers[FriendsMembers.Length - 1].world = toPawnWorld;              
FriendsMembers[FriendsMembers.Length - 1].Online = isOnline;                
}
event AddMember(string toPawnName,int Flag,int toPawnID,int toPawnLevel,int toPawnClass,int toPawnWorld) {
local string messageStr;
FriendsMembers.Insert(FriendsMembers.Length,1);                             
FriendsMembers[FriendsMembers.Length - 1] = new Class'SBFriendsMember';     
FriendsMembers[FriendsMembers.Length - 1].Name = toPawnName;                
FriendsMembers[FriendsMembers.Length - 1].Flag = Flag;                      
FriendsMembers[FriendsMembers.Length - 1].CharacterID = toPawnID;           
FriendsMembers[FriendsMembers.Length - 1].Level = toPawnLevel;              
FriendsMembers[FriendsMembers.Length - 1].Class = toPawnClass;              
FriendsMembers[FriendsMembers.Length - 1].world = toPawnWorld;              
switch (Flag) {                                                             
case 1 :                                                                  
FriendsMembers[FriendsMembers.Length - 1].Online = True;                
messageStr = Class'StringReferences'.default.PLAYERNAME_has_been_added_to_your_friend_list_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",toPawnName);               
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
case 3 :                                                                  
FriendsMembers[FriendsMembers.Length - 1].Online = False;               
messageStr = Class'StringReferences'.default.PLAYERNAME_has_been_added_to_your_ignore_list_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",toPawnName);               
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
default:                                                                  
}
OnRefreshView();                                                            
}
event OnFailResult(byte Result,optional string pawnName) {
local string messageStr;
switch (Result) {                                                           
case 6 :                                                                  
messageStr = Class'StringReferences'.default.PLAYERNAME_ignored_you_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",pawnName);                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
case 2 :                                                                  
messageStr = Class'StringReferences'.default.PLAYERNAME_has_declined_your_request_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",pawnName);                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
case 4 :                                                                  
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.You_mumble_to_yourself_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 5 :                                                                  
case 8 :                                                                  
messageStr = Class'StringReferences'.default.PLAYERNAME_is_busy__try_again_later_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",pawnName);                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
case 7 :                                                                  
messageStr = Class'StringReferences'.default.You_have_invited_PLAYERNAME_to_your_friendslist_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",pawnName);                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
case 3 :                                                                  
break;                                                                  
case 9 :                                                                  
messageStr = Class'StringReferences'.default.PLAYERNAME_is_already_on_your_list_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",pawnName);                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
case 10 :                                                                 
messageStr = Class'StringReferences'.default.PLAYERNAME_is_unknown__check_the_spelling_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",pawnName);                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
case 11 :                                                                 
case 15 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Friends_Ignore_System_failed_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 12 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Failed_to_add_that_player_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 13 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Failed_to_remomve_that_player_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 14 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Failed_to_change_relation_.Text,Class'Game_Desktop'.7);
break;                                                                  
default:                                                                  
}
}
event OnSetClass(int CharacterID,int aNewClass) {
local int i;
i = 0;                                                                      
while (i < FriendsMembers.Length) {                                         
if (FriendsMembers[i].CharacterID == CharacterID) {                       
FriendsMembers[i].Class = aNewClass;                                    
OnRefreshView();                                                        
goto jl0066;                                                            
}
++i;                                                                      
}
}
event OnLevelUp(int CharacterID,int aNewLevel) {
local int i;
i = 0;                                                                      
while (i < FriendsMembers.Length) {                                         
if (FriendsMembers[i].CharacterID == CharacterID) {                       
FriendsMembers[i].Level = aNewLevel;                                    
OnRefreshView();                                                        
goto jl0066;                                                            
}
++i;                                                                      
}
}
event Offline(int pawnID) {
local int i;
local string messageStr;
i = 0;                                                                      
while (i < FriendsMembers.Length) {                                         
if (FriendsMembers[i].CharacterID == pawnID) {                            
messageStr = Class'StringReferences'.default.PLAYERNAME_has_gone_offline_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",FriendsMembers[i].Name);   
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
FriendsMembers[i].Online = False;                                       
OnRefreshView();                                                        
goto jl00E1;                                                            
}
++i;                                                                      
}
}
event Online(int pawnID,int worldID) {
local int i;
local string messageStr;
i = 0;                                                                      
while (i < FriendsMembers.Length) {                                         
if (FriendsMembers[i].CharacterID == pawnID) {                            
messageStr = Class'StringReferences'.default.PLAYERNAME_has_come_online_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",FriendsMembers[i].Name);   
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
FriendsMembers[i].Online = True;                                        
FriendsMembers[i].world = worldID;                                      
OnRefreshView();                                                        
OnFriendOnline();                                                       
goto jl0105;                                                            
}
++i;                                                                      
}
}
delegate OnAddMemberReq(string fromPawnName);
event AddMemberReq(string fromPawnName) {
OnAddMemberReq(fromPawnName);                                               
}
event OnRefreshViewNotify() {
OnRefreshView();                                                            
}
delegate OnFriendOnline();
delegate OnRefreshView();
native function MemberInviteAck(string fromPawnName,byte resultCode);
native function RemoveIgnoreMember(string ignorePawnName);
native function AddIgnoreMember(string ignorePawnName);
native function RemoveFriendMember(string friendPawnName);
native function AddFriendMember(string friendPawnName);
*/