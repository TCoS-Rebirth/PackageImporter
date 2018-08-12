using System;
using Engine;

namespace SBBase
{
    [Serializable] public class Base_GameServer : GameEngine
    {
        public int ServerMode;

        public string ServerOptions = string.Empty;

        public bool IsPvPServer;

        private int mGameServerData;

        public Base_GameServer()
        {
        }
    }
}
/*
event sv_OnCreateInstanceNAck(int InstanceID) {
}
event sv_OnCreateInstanceAck(int InstanceID,int zoneID) {
}
native function bool LoginToWorldByID(int _worldID,int _characterID,string _portalName,string _routeName);
native function int GetPortalDestinationWorldID(Object _gamePortal);
native function bool LoginToWorldByPortal(Object _gamePortal,int _characterID);
*/