using System;
using System.Collections.Generic;
using SBBase;

namespace SBGame
{
#pragma warning disable 414   

    [Serializable]
    public class Game_PlayerTeams: Base_Component
    {
        public const int NOTIFY_HUD_CLOSE_ALL = 0;

        public const int NOTIFY_HUD_DISBAND = 3;

        public const int NOTIFY_HUD_KICK = 2;

        public const int NOTIFY_HUD_INVITE_REQ = 1;

        public const int TEAM_MEMBER_INFO_BASE_RATE = 10;

        public const float TEAM_MEMBER_INFO_UPDATE_TIME = 1F;

        public int mTeamID;

        public byte mLootMode;

        public List<Game_TeamMember> mTeamMembers = new List<Game_TeamMember>();

        public Game_Team mTeam;

        public EventNotification mTeamChanged;

        public int mLeaderID;

        private int mLastTeamMemberInfoBase;

        private float mLastTeamMemberInfoUpdate;

        private List<byte> mLastLodData = new List<byte>();

        private float mPartyTravelTimeout;

        private int mPartyTravelTargetWorld;

        private string mPartyTravelPortalName = string.Empty;

        public bool mPartyTravelInProgress;

        public bool mIsJoiningPartyTravel;

        public enum eTeamRequestResult
        {
            TRR_NONE,

            TRR_ACCEPT,

            TRR_DECLINE,

            TRR_BUSY,

            TRR_FULL,

            TRR_INVITE_SUCCESS,

            TRR_MEMBER_IN_OTHER_TEAM,

            TRR_MEMBER_ON_TRAVELING,

            TRR_SELF_INVITE,

            TRR_INSUFFICIENT_RIGHTS,

            TRR_IGNORED_ME,

            TRR_UNKNOWN_CHARACTER,

            TRR_UNKNOWN_MEMBER_WORLD,

            TRR_UNKNOWN_TEAM,

            TRR_EMPTY_TEAM,

            TRR_CREATE_FAILED,

            TRR_INCORRECT_INVITER,

            TRR_KICK_FAILED,

            TRR_LEAVE_FAILED,

            TRR_DISBAND_FAILED,

            TRR_CHANGE_LEADER_FAILED,

            TRR_CHANGE_LOOTMODE_FAILED,

            TRR_GET_TEAM_INFO_FAILED,
        }

        public enum eTeamRemoveMemberCode
        {
            TRMC_NONE,

            TRMC_KICK,

            TRMC_LEAVE,

            TRMC_OFFLINE,

            TRMC_DISBAND,
        }

        public void HandleDeath()
        {
            sv_CancelPartyTravel();
        }

        void sv_CancelPartyTravel()
        {
            if (mPartyTravelTargetWorld != 0)
            {
                sv_CancelPartyTravelForAll();
            }
            if (mPartyTravelInProgress)
            {
                sv_JoinPartyTravel(false);
            }
        }

        void sv_JoinPartyTravel(bool aIsJoining)
        {
            List<Game_Pawn> team;
            Game_PlayerPawn playerPawn;
            Game_PlayerController PlayerController;
            int idx;
            if (mPartyTravelInProgress == false)
            {
                return;
            }
            mIsJoiningPartyTravel = aIsJoining;
            sv_GetTeamMembersOrSolo(out team);
            idx = 0;
            while (idx < team.Count)
            {
                playerPawn = team[idx] as Game_PlayerPawn;
                PlayerController = playerPawn.Controller as Game_PlayerController;
                PlayerController.GroupingTeams.sv2cl_JoinPartyTravel_CallStub(((Outer as Game_Controller).Pawn as Game_PlayerPawn).GetCharacterID(), aIsJoining);
                ++idx;
            }
        }

        void sv2cl_JoinPartyTravel_CallStub(int characterID, bool aIsJoining /*added*/)
        {
            throw new NotImplementedException();
        }

        void sv_CancelPartyTravelForAll()
        {
            List<Game_Pawn> team;
            Game_PlayerPawn playerPawn;
            Game_PlayerController PlayerController;
            int idx;
            sv_GetTeamMembersOrSolo(out team);
            idx = 0;
            while (idx < team.Count)
            {
                playerPawn = team[idx] as Game_PlayerPawn;
                PlayerController = playerPawn.Controller as Game_PlayerController;
                PlayerController.GroupingTeams.sv_CancelPartyTravelForOne();
                ++idx;
            }
            mPartyTravelTargetWorld = 0;
            mPartyTravelPortalName = "";
            mPartyTravelTimeout = 0;
        }

        void sv2cl_CancelPartyTravel_CallStub() { throw new NotImplementedException(); }

        void sv_CancelPartyTravelForOne()
        {
            mPartyTravelInProgress = false;
            mIsJoiningPartyTravel = false;
            sv2cl_CancelPartyTravel_CallStub();
        }

        void sv_GetTeamMembersOrSolo(out List<Game_Pawn> oTeam)
        {
            if (mTeam != null)
            {
                oTeam = mTeam.mMembers;
            }
            else
            {
                oTeam = new List<Game_Pawn>() { Outer as Game_Pawn };
            }
        }
    }
}
/*
native function bool IsTeamLeader();
native function bool InTeamWith(Game_Pawn aPawn);
function sv_GetCreditTeam(out array<Game_Pawn> aMembers,Vector aCenterLocation) {
local int ti;
local Game_Pawn ownPawn;
local Game_Pawn teamPawn;
ownPawn = Game_Pawn(Outer.Pawn);                                            
aMembers.Length = 0;                                                        
if (mTeam != None) {                                                        
ti = 0;                                                                   
while (ti < mTeam.mMembers.Length) {                                      
teamPawn = mTeam.mMembers[ti];                                          
if (teamPawn == ownPawn) {                                              
aMembers[aMembers.Length] = ownPawn;                                  
} else {                                                                
if (VSize(teamPawn.Location - aCenterLocation) < teamPawn.CombatStats.CreditRange) {
if (!Game_PlayerPawn(teamPawn).sv_IsFreeToPlayCapped()) {           
aMembers[aMembers.Length] = teamPawn;                             
}
}
}
ti++;                                                                   
}
} else {                                                                    
aMembers[0] = ownPawn;                                                    
}
}
event sv_GetTeamMembers(out array<Game_Pawn> oTeam) {
if (mTeam != None) {                                                        
oTeam = mTeam.mMembers;                                                   
} else {                                                                    
oTeam.Length = 0;                                                         
}
}
private event sv_PartyTravel() {
local array<Game_Pawn> team;
local Game_PlayerPawn playerPawn;
local Game_PlayerController PlayerController;
local int idx;
local Game_GameServer Engine;
Engine = Game_GameServer(Class'Actor'.static.GetGameEngine());              
sv_GetTeamMembersOrSolo(team);                                              
idx = 0;                                                                    
while (idx < team.Length) {                                                 
playerPawn = Game_PlayerPawn(team[idx]);                                  
PlayerController = Game_PlayerController(playerPawn.Controller);          
if (PlayerController.GroupingTeams.mIsJoiningPartyTravel == True) {       
Engine.LoginToWorldByID(mPartyTravelTargetWorld,PlayerController.CharacterID,mPartyTravelPortalName,"");
}
PlayerController.GroupingTeams.mPartyTravelInProgress = False;            
PlayerController.GroupingTeams.mIsJoiningPartyTravel = False;             
++idx;                                                                    
}
mPartyTravelTargetWorld = 0;                                                
mPartyTravelPortalName = "";                                                
mPartyTravelTimeout = 0.00000000;                                           
}
private event sv2cl_CancelPartyTravel() {
OnPartyTravelCancel();                                                      
}
protected native function cl2sv_CancelPartyTravel_CallStub();
event cl2sv_CancelPartyTravel() {
sv_CancelPartyTravel();                                                     
}
private event sv2cl_JoinPartyTravel(int aMember,bool aIsJoining) {
OnPartyTravelJoin(aMember,aIsJoining);                                      
}

protected native function cl2sv_JoinPartyTravel_CallStub();
event cl2sv_JoinPartyTravel(bool aIsJoining) {
sv_JoinPartyTravel(aIsJoining);                                             
}
function sv_StartPartyTravel(int aTargetWorld,string aPortalName) {
local array<Game_Pawn> team;
local Game_PlayerPawn playerPawn;
local Game_PlayerController PlayerController;
local int idx;
sv_GetTeamMembersOrSolo(team);                                              
idx = 0;                                                                    
while (idx < team.Length) {                                                 
playerPawn = Game_PlayerPawn(team[idx]);                                  
PlayerController = Game_PlayerController(playerPawn.Controller);          
if (PlayerController.GroupingTeams.mPartyTravelInProgress == True) {      
return;                                                                 
}
++idx;                                                                    
}
mPartyTravelTargetWorld = aTargetWorld;                                     
mPartyTravelPortalName = aPortalName;                                       
mPartyTravelTimeout = 11.00000000;                                          
idx = 0;                                                                    
while (idx < team.Length) {                                                 
playerPawn = Game_PlayerPawn(team[idx]);                                  
PlayerController = Game_PlayerController(playerPawn.Controller);          
PlayerController.GroupingTeams.mPartyTravelInProgress = True;             
if (PlayerController == Outer) {                                          
PlayerController.GroupingTeams.mIsJoiningPartyTravel = True;            
PlayerController.GUI.sv2cl_ShowPartyTravelOverview_CallStub();          
} else {                                                                  
PlayerController.GroupingTeams.mIsJoiningPartyTravel = False;           
PlayerController.GUI.sv2cl_ShowPartyTravelConfirmation_CallStub();      
}
++idx;                                                                    
}
}
delegate OnPartyTravelJoin(int aMember,bool aIsJoining);
delegate OnPartyTravelCancel();
event cl_ReceiveCharacterStatsUpdate(int CharacterID,float aHealth,float aPhysique,float aMorale,float aConcentration,int aStateRankShift,float aDuffUpdateTime,array<int> aDuffs,array<byte> aLodData) {
local int i;
local int j;
local export editinline Game_PlayerAppearance Appearance;
i = 0;                                                                      
while (i < mTeamMembers.Length) {                                           
if (mTeamMembers[i].MemberHandle == CharacterID) {                        
mTeamMembers[i].Health = aHealth;                                       
mTeamMembers[i].Physique = aPhysique;                                   
mTeamMembers[i].Morale = aMorale;                                       
mTeamMembers[i].Concentration = aConcentration;                         
mTeamMembers[i].StateRankShift = aStateRankShift;                       
if (mTeamMembers[i].AppearancePawn == None) {                           
mTeamMembers[i].AppearancePawn = Outer.Spawn(Class'Game_TeamMemberPawn');
mTeamMembers[i].AppearancePawn.cl_OnInit();                           
}
j = 0;                                                                  
while (j < aLodData.Length) {                                           
if (j >= mTeamMembers[i].LastAppearanceUpdateLod.Length
|| mTeamMembers[i].LastAppearanceUpdateLod[j] != aLodData[j]) {
mTeamMembers[i].LastAppearanceUpdateLod = aLodData;                 
Appearance = Game_PlayerAppearance(Game_PlayerPawn(mTeamMembers[i].AppearancePawn).Appearance.GetBase());
Appearance.mLODData3 = aLodData;                                    
Appearance.ConditionalUnpackLODData();                              
goto jl01FC;                                                        
}
++j;                                                                  
}
if (mTeamMembers[i].LastDuffUpdateTime != aDuffUpdateTime) {            
mTeamMembers[i].LastDuffUpdateTime = aDuffUpdateTime;                 
mTeamMembers[i].Buffs.Length = aDuffs.Length;                         
j = 0;                                                                
while (j < aDuffs.Length) {                                           
mTeamMembers[i].Buffs[j] = FSkill_Event_Duff(Class'SBDBSync'.GetResourceObject(aDuffs[j]));
++j;                                                                
}
}
return;                                                                 
}
++i;                                                                      
}
}
event cl_ReceiveCharacterStatsBase(int CharacterID,int worldID,float LocationX,float LocationY,bool aIsFeminine,int aArchetype,int aDiscipline,float aMaxHealth,int aPePRank,int aFameLevel) {
local int i;
i = 0;                                                                      
while (i < mTeamMembers.Length) {                                           
if (mTeamMembers[i].MemberHandle == CharacterID) {                        
mTeamMembers[i].worldID = worldID;                                      
mTeamMembers[i].LocationX = LocationX;                                  
mTeamMembers[i].LocationY = LocationY;                                  
mTeamMembers[i].IsFeminine = aIsFeminine;                               
mTeamMembers[i].Archetype = aArchetype;                                 
mTeamMembers[i].Discipline = aDiscipline;                               
mTeamMembers[i].MaxHealth = aMaxHealth;                                 
mTeamMembers[i].Pep = aPePRank;                                         
mTeamMembers[i].Fame = aFameLevel;                                      
return;                                                                 
}
++i;                                                                      
}
}
event sv_SendCharacterStats() {
local export editinline Game_CharacterStats Stats;
local export editinline Game_Skills Skills;
local export editinline Game_PlayerAppearance Appearance;
local Game_GameServer sv;
sv = Game_GameServer(Class'Actor'.static.GetGameEngine());                  
if (sv == None) {                                                           
return;                                                                   
}
Stats = Game_Pawn(Outer.Pawn).CharacterStats;                               
Skills = Game_Pawn(Outer.Pawn).Skills;                                      
Appearance = Game_PlayerAppearance(Game_Pawn(Outer.Pawn).Appearance.GetCurrent());
Appearance.RepackLodDataAll();                                              
if (mLastTeamMemberInfoBase <= 0) {                                         
sv_SendCharacterStatsBaseData(Outer.CharacterID,sv.GetWorldID(),Game_Pawn(Outer.Pawn).Location.X,Game_Pawn(Outer.Pawn).Location.Y,Game_Pawn(Outer.Pawn).Appearance.IsFeminine(),Stats.GetArchetype(),Stats.GetCharacterClass(),Stats.mRecord.MaxHealth,Stats.mRecord.PePRank,Stats.mRecord.FameLevel);
mLastTeamMemberInfoBase = 10;                                             
} else {                                                                    
mLastTeamMemberInfoBase--;                                                
}
sv_SendCharacterStatsUpdateData(Outer.CharacterID,Stats.mHealth,Stats.mPhysiqueLevel,Stats.mMoraleLevel,Stats.mConcentrationLevel,Stats.mStateRankShift,Skills.mLastDuffUpdateTime,Skills.TeamDuffList,Appearance.mLODData3);
mLastTeamMemberInfoUpdate = Outer.Level.TimeSeconds;                        
}
native function sv_SendCharacterStatsUpdateData(int CharacterID,float aHealth,float aPhysique,float aMorale,float aConcentration,int aStateRankShift,float aDuffUpdateTime,array<int> aDuffs,array<byte> aLodData);
native function sv_SendCharacterStatsBaseData(int CharacterID,int worldID,float LocationX,float LocationY,bool aIsFeminine,int aArchetype,int aDiscipline,float aMaxHealth,int aPePRank,int aFameLevel);
event sv_RemovedPawnFromTeam() {
mTeamID = 0;                                                                
mLeaderID = 0;                                                              
mLootMode = Class'Loot_Transaction'.0;                                      
mTeam.RemoveMember(Game_Pawn(Outer.Pawn));                                  
mTeam = None;                                                               
}
event sv_AddedPawnToTeam(int teamID) {
local Game_PlayerController PlayerController;
local Game_Team team;
if (mTeamID != 0 && mTeamID != teamID) {                                    
return;                                                                   
}
mTeamID = teamID;                                                           
team = None;                                                                
foreach Outer.DynamicActors(Class'Game_PlayerController',PlayerController,'None') {
if (PlayerController != Outer) {                                          
if (PlayerController.GroupingTeams.mTeamID == mTeamID) {                
team = PlayerController.GroupingTeams.mTeam;                          
}
}
}
if (team == None) {                                                         
team = new Class'Game_Team';                                              
}
if (team.IsMember(Game_Pawn(Outer.Pawn)) == False) {                        
team.AddMember(Game_Pawn(Outer.Pawn));                                    
}
mLastTeamMemberInfoUpdate = 0.00000000;                                     
mLastTeamMemberInfoBase = 0;                                                
}
event sv_SetLootMode(byte LootMode) {
mLootMode = LootMode;                                                       
}
event sv_SetLeader(int leaderID) {
mLeaderID = leaderID;                                                       
}
event TeamChangeLeader(int teamID,int leaderID,int newLeaderID) {
local int i;
local string newLeaderName;
local string messageStr;
if (mTeamID != teamID) {                                                    
return;                                                                   
}
newLeaderName = Game_PlayerPawn(Outer.Pawn).GetCharacterName();             
i = 0;                                                                      
while (i < mTeamMembers.Length) {                                           
if (mTeamMembers[i].MemberHandle == newLeaderID) {                        
mTeamMembers[i].IsLeader = True;                                        
newLeaderName = mTeamMembers[i].Name;                                   
} else {                                                                  
mTeamMembers[i].IsLeader = False;                                       
}
++i;                                                                      
}
messageStr = Class'StringReferences'.default.LEADERNAME_is_now_party_leader_.Text;
static.ReplaceText(messageStr,"[LEADERNAME]",newLeaderName);                
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
RefreshTeam();                                                              
}
event TeamDestroy(byte removeCode) {
local int i;
i = 0;                                                                      
while (i < mTeamMembers.Length) {                                           
mTeamMembers[i].AppearancePawn.Appearance.cl_OnShutdown();                
mTeamMembers[i].AppearancePawn.Destroy();                                 
i++;                                                                      
}
mTeamMembers.Length = 0;                                                    
mTeamID = 0;                                                                
mLootMode = Class'Loot_Transaction'.0;                                      
mTeamChanged.Trigger();                                                     
switch (removeCode) {                                                       
case 1 :                                                                  
Outer.Player.GUIDesktop.ShowStdWindow(46,1);                            
Outer.Player.GUIDesktop.UpdateStdWindow(46,2,None,"",0);                
break;                                                                  
case 2 :                                                                  
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.You_have_left_the_party_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 4 :                                                                  
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Your_party_has_been_disbanded_.Text,Class'Game_Desktop'.7);
Outer.Player.GUIDesktop.ShowStdWindow(46,1);                            
Outer.Player.GUIDesktop.UpdateStdWindow(46,3,None,"",0);                
break;                                                                  
default:                                                                  
}
}
event TeamRemoveMember(int teamID,int removeMemberID,byte removeCode) {
local int i;
local string messageStr;
if (mTeamID != teamID) {                                                    
return;                                                                   
}
i = 0;                                                                      
while (i < mTeamMembers.Length) {                                           
if (mTeamMembers[i].MemberHandle == removeMemberID) {                     
if (mTeamMembers[i].AppearancePawn != None) {                           
if (mTeamMembers[i].AppearancePawn.Appearance != None) {              
mTeamMembers[i].AppearancePawn.Appearance.cl_OnShutdown();          
}
mTeamMembers[i].AppearancePawn.Destroy();                             
}
switch (removeCode) {                                                   
case 1 :                                                              
messageStr = Class'StringReferences'.default.PLAYERNAME_has_been_kicked_from_the_party_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",mTeamMembers[i].Name); 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                              
case 2 :                                                              
messageStr = Class'StringReferences'.default.PLAYERNAME_has_left_the_party_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",mTeamMembers[i].Name); 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                              
case 3 :                                                              
messageStr = Class'StringReferences'.default.PLAYERNAME_has_gone_offline_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",mTeamMembers[i].Name); 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                              
default:                                                              
}
mTeamMembers.Remove(i,1);                                               
goto jl027A;                                                            
}
++i;                                                                      
}
RefreshTeam();                                                              
}
event TeamAddMember(int teamID,int memberID,int memberWorld,string memberName,bool Leader) {
local string messageStr;
TeamSetMember(teamID,memberID,memberWorld,memberName,Leader);               
messageStr = Class'StringReferences'.default.PLAYERNAME_has_joined_your_party_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",memberName);                   
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
}
event TeamSetMember(int teamID,int memberID,int memberWorld,string memberName,bool Leader) {
if (mTeamID == teamID) {                                                    
mTeamMembers.Insert(mTeamMembers.Length,1);                               
mTeamMembers[mTeamMembers.Length - 1] = new Class'Game_TeamMember';       
mTeamMembers[mTeamMembers.Length - 1].MemberHandle = memberID;            
mTeamMembers[mTeamMembers.Length - 1].Name = memberName;                  
mTeamMembers[mTeamMembers.Length - 1].worldID = memberWorld;              
mTeamMembers[mTeamMembers.Length - 1].IsLeader = Leader;                  
mTeamMembers[mTeamMembers.Length - 1].AppearancePawn = None;              
RefreshTeam();                                                            
}
}
event TeamInviteReq(int teamID,string fromPawnName) {
Outer.Player.GUIDesktop.ShowStdWindow(46,1);                                
Outer.Player.GUIDesktop.UpdateStdWindow(46,1,None,fromPawnName,teamID);     
}
event OnFailResult(byte Code,optional string pawnName) {
local string messageStr;
switch (Code) {                                                             
case 10 :                                                                 
messageStr = Class'StringReferences'.default.PLAYERNAME_ignored_you_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",pawnName);                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
case 2 :                                                                  
messageStr = Class'StringReferences'.default.PLAYERNAME_declined_to_join_your_party_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",pawnName);                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
case 3 :                                                                  
case 7 :                                                                  
messageStr = Class'StringReferences'.default.PLAYERNAME_is_busy_try_again_later_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",pawnName);                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
case 4 :                                                                  
messageStr = Class'StringReferences'.default.PLAYERNAME_cannot_join_your_party_because_it_is_full_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",pawnName);                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
case 5 :                                                                  
messageStr = Class'StringReferences'.default.You_have_invited_PLAYERNAME_to_your_party_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",pawnName);                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
case 6 :                                                                  
messageStr = Class'StringReferences'.default.PLAYERNAME_is_already_in_a_party_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",pawnName);                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
case 8 :                                                                  
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.You_mumble_to_yourself_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 11 :                                                                 
messageStr = Class'StringReferences'.default.PLAYERNAME_is_unknown__check_the_spelling_.Text;
static.ReplaceText(messageStr,"[PLAYERNAME]",pawnName);                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
case 9 :                                                                  
messageStr = Class'StringReferences'.default.You_are_currently_not_allowed_to_do_that_.Text;
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",messageStr,Class'Game_Desktop'.7);
break;                                                                  
case 16 :                                                                 
case 12 :                                                                 
case 13 :                                                                 
case 15 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Party_System_Error_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 14 :                                                                 
break;                                                                  
case 20 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Failed_to_change_party_leader_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 19 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Party_disband_failed_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 17 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Failed_to_kick_party_member_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 18 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Failed_to_leave_the_Party_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 21 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Failed_to_change_the_Party_Loot_Mode_.Text,Class'Game_Desktop'.7);
break;                                                                  
case 22 :                                                                 
Game_Desktop(Outer.Player.GUIDesktop).AddMessage("",Class'StringReferences'.default.Failed_to_get_party_member_information_.Text,Class'Game_Desktop'.7);
break;                                                                  
default:                                                                  
}
}
event Offline(int pawnID) {
local int i;
i = 0;                                                                      
while (i < mTeamMembers.Length) {                                           
if (mTeamMembers[i].MemberHandle == pawnID) {                             
goto jl0042;                                                            
}
++i;                                                                      
}
}
event Online(int pawnID,int worldID) {
local int i;
i = 0;                                                                      
while (i < mTeamMembers.Length) {                                           
if (mTeamMembers[i].MemberHandle == pawnID) {                             
mTeamMembers[i].worldID = worldID;                                      
RefreshTeam();                                                          
goto jl0062;                                                            
}
++i;                                                                      
}
}
event RefreshTeam() {
mTeamChanged.Trigger();                                                     
}
function byte GetTeamLootMode() {
return mLootMode;                                                           
}
function int GetTeamID() {
return mTeamID;                                                             
}
function int GetPlayerCharacterID() {
return Game_Pawn(Outer.Pawn).GetCharacterID();                              
}
native function TeamInviteAck(int teamID,string fromPawnName,byte _result);
native function GetTeamInfo();
native function TeamSetLootMode(byte LootMode);
native function TeamDisband();
native function TeamLeaderChange(int newLeaderPawnID);
native function TeamKick(int kickPawnID);
native function TeamLeave();
native function TeamInvite(string toPawnName);
event cl_SetLootMode(int aTeamID,byte aLootMode) {
if (mTeamID == aTeamID) {                                                   
OnSetLootMode(mLootMode,aLootMode);                                       
mLootMode = aLootMode;                                                    
RefreshTeam();                                                            
}
}
delegate OnSetLootMode(byte oldLootMode,byte newlootMode);
function cl_OnShutdown() {
Super.cl_OnShutdown();                                                      
mTeamChanged.Delete();                                                      
}
function cl_OnInit() {
Super.cl_OnInit();                                                          
GetTeamInfo();                                                              
}
function Init() {
mTeamChanged = new Class'EventNotification';                                
}
*/
