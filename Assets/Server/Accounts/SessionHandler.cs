using System;
using System.Collections.Generic;
using Network;

namespace Accounts
{
    public class SessionHandler: ISessionHandler
    {
        List<PlayerSession> sessions = new List<PlayerSession>();

        public void Begin(PlayerSession session)
        {
            if (session == null) throw new ArgumentException("Session must not be null", nameof(session));
            if (Get<PlayerSession>(session.Connection) != null) throw new Exception("Duplicate session begin");
            sessions.Add(session);
            session.OnBegin();
        }

        public T Get<T>(NetConnection connection) where T: PlayerSession
        {
            for (var i = 0; i < sessions.Count; i++)
            {
                if (sessions[i].Connection == connection) return sessions[i] as T;
            }
            return null;
        }

        public T Get<T>(Predicate<T> predicate) where T : PlayerSession
        {
            for (var i = 0; i < sessions.Count; i++)
            {
                var t = sessions[i] as T;
                if (t != null && predicate(t)) return t;
            }
            return null;
        }

        public int GetCount<T>() where T:PlayerSession
        {
            var count = 0;
            for (int i = 0; i < sessions.Count; i++)
            {
                if (sessions[i] is T) count++;
            }
            return count;
        }

        public void End(PlayerSession session)
        {
            if (!sessions.Remove(session)) throw new Exception("Session not yet begun");
            session.OnEnd();
        }

        public void EndAllSessions()
        {
            for (var i = 0; i < sessions.Count; i++)
            {
                End(sessions[i]);
            }
        }
    }
}
