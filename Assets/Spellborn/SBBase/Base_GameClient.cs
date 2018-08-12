using System;
using Engine;

namespace SBBase
{
    [Serializable] public class Base_GameClient : GameEngine
    {
        public int @__LogoutState;

        public int @__CurrentConnectedServer;

        public int @__mUniverseDataPtr;

        public int mWorldID;

        public bool IsPvPServer;

        public int @__mSplashScreenCloserPtr;

        public PlayerController GPlayerController;

        [FieldConst()]
        public float CellUpdateTime;

        [FieldConst()]
        public int CurrentCell;

        public Base_GameClient()
        {
        }
    }
}
/*
native function QueryUniverses();
native function CancelConnectToUniverse();
native function ConnectToUniverse(int universeID);
native function CancelConnectToLogin();
native function int ConnectToLoginServer(string aUsername,string aPassword);
native function ForcedLogin(int Status);
native function StopSceneDump();
native function StartSceneDump();
native function string GetUserName();
native function ApplyPatch();
native function ContentUpdateErrorOK();
native function CancelContentUpdate();
native function float GetContentUpdateProgress(out int peerCount,out float upSpeed,out float downSpeed,out string errorMessage);
native function Logout(optional int forcedReason);
*/