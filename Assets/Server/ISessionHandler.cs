using Accounts;
using Network;

public interface ISessionHandler
{
    void StartSession(PlayerSession session);
    PlayerSession GetSession(NetConnection connection);
    PlayerSession GetSession(int transferKey);
    int GetSessionCount();
    void EndSession(PlayerSession session);
}