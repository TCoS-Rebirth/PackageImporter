using System;
using System.Collections.Generic;
using Server.Network;
using UnityEngine;

namespace Server.Accounts
{
    public class SessionHandler: ISessionHandler
    {

        List<PlayerSession> activeSessions = new List<PlayerSession>();

        public void StartSession(PlayerSession session)
        {
            if (session == null) throw new ArgumentException("Session must not be null", "session");
            activeSessions.Add(session);
        }

        public PlayerSession GetSession(int transferKey)
        {
            for (int i = 0; i < activeSessions.Count; i++)
            {
                if (activeSessions[i].TransferKey == transferKey) return activeSessions[i];
            }
            return null;
        }

        public PlayerSession GetSession(NetConnection connection)
        {
            for (int i = 0; i < activeSessions.Count; i++)
            {
                if (activeSessions[i].Connection == connection) return activeSessions[i];
            }
            return null;
        }

        public int GetSessionCount()
        {
            return activeSessions.Count;
        }

        public void EndSession(PlayerSession session)
        {
            Debug.Log("EndSession not yet implemented");
        }

        public void EndAllSessions()
        {
            for (int i = 0; i < activeSessions.Count; i++)
            {
                EndSession(activeSessions[i]);
            }
        }
    }
}
