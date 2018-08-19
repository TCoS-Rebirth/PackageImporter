using System;
using User;
using Network;

public interface ISessionHandler
{
    void Begin(PlayerSession session);
    T Get<T>(NetConnection connection) where T:PlayerSession;
    int GetCount<T>() where T:PlayerSession;
    void End(PlayerSession session);
}