using System;
using System.Collections.Generic;
using Engine;

namespace SBGame
{
    [Serializable] public class Arena_GameInfo : Game_GameInfo
    {
        public const float COUNTDOWN_TIME = 10F;

        public const float CONNECTION_TIME = 60F;

        public string mArenaTag = string.Empty;

        public string mArenaManagerTag = string.Empty;

        public string mArenaChannel = string.Empty;

        public float mConnectRetryTimer;

        public float mConnectionTimer;

        public byte mGameType;

        public int mReturnWorld;

        public int mReturnInstance;

        public float mCountDownLeft;

        public int mCountDownLastSecond;

        public byte mGameResult;

        public float mGameResultTimer;

        [ArraySizeForExtraction(Size = 2)]
        public ArenaGameInfoTeam[] mTeam = new ArenaGameInfoTeam[0];

        public byte mCommunicationState;

        public byte mGameState;

        [FieldConst()]
        public bool TournamentFight;

        [FieldConst()]
        public bool GuildFight;

        [FieldConst()]
        public bool GroupFight;

        [FieldConst()]
        public bool Challenge;

        [FieldConst()]
        public int FightId;

        public Arena_GameInfo()
        {
        }

        [Serializable] public struct ArenaGameInfoPlayer
        {
            public int Id;

            public Game_PlayerController Controller;

            public bool Connected;

            public string Name;

            public int UserData;
        }

        [Serializable] public struct ArenaGameInfoTeam
        {
            public PlayerStart Start;

            public List<ArenaGameInfoPlayer> Players;
        }

        public enum EGameState
        {
            GS_INIT,

            GS_WAITING_FOR_SETUP,

            GS_WAITING_FOR_LOGINS,

            GS_COUNTING_DOWN,

            GS_FIGHTING,

            GS_SENDING_RESULT,
        }

        public enum ECommunicationState
        {
            CS_NOT_CONNECTED,

            CS_CONNECTED,
        }

        public enum EArenaPawnState
        {
            APS_Connecting,

            APS_Disconnected,

            APS_Alive,

            APS_Dead,
        }

        public enum EArenaFightResult
        {
            AFR_Cancelled,

            AFR_Team0Won,

            AFR_Team1Won,
        }

        public enum EArenaGameType
        {
            AGT_DeathMatch,

            AGT_TimeTrial,

            AGT_LastManStanding,
        }
    }
}
/*
protected event sv_UpdateCountdownToClients() {
}
protected native function byte sv_GetPawnState(byte aTeam,int aPlayer);
native function sv_PlayerStateUpdated(Game_PlayerPawn aPawn,optional byte aForcedState);
protected native function sv_SendPlayerList(Game_PlayerPawn aPawn);
protected native function sv_LogoutAllPlayers();
protected native function int sv_SetCharacter(int CharacterID,Game_PlayerController aPC);
protected native function bool sv_AllowCharacterToJoin(int CharacterID);
protected native function string sv_GetCommandlineOptions();
function int sv_GetUserData(Game_PlayerController aController) {
return 0;                                                                   
}
function sv_SetUserData(Game_PlayerController aController,int aUserdata) {
}
native function int sv_GetTeamSize(int aTeam);
event sv_StartGame() {
}
event sv_StartCountdown() {
}
event sv_StopGame(byte aResult) {
}
function bool PlayerRespawned(Controller aController) {
return False;                                                               
}
function bool PlayerDied(Controller aController) {
return False;                                                               
}
event sv_OnLogout(int aAccountID,Base_Pawn aPawn) {
Super.sv_OnLogout(aAccountID,aPawn);                                        
}
event sv_OnInit() {
local PlayerStart ps;
Super.sv_OnInit();                                                          
SetAllPropertyTexts(sv_GetCommandlineOptions());                            
mArenaChannel = "_tournament_" $ mArenaManagerTag;                          
foreach AllActors(Class'PlayerStart',ps) {                                  
mTeam[ps.TeamNumber].Start = ps;                                          
}
}
*/