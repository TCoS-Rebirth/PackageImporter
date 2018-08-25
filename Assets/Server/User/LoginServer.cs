using System;
using System.Net;
using User;
using Network;
using UnityEngine;
using Utilities;

public class LoginServer
{

    public enum eLoginRequestResult
    {
        LRR_NONE,
        LRR_INVALID_REVISION,
        LRR_INVALID_USERNAME,
        LRR_INVALID_PASSWORD,
        LRR_AUTHENTICATE_FAILED,
        LRR_LOGIN_ADD_FAILED,
        LRR_LOGIN_CONNECT_FAILED,
        LRR_INVALID_ACTIVE_CODE,
        LRR_BANNED_ACCOUNT,
        LRR_SUSPENDED_ACCOUNT,
        LRR_DISABLED_ACCOUNT
    }

    NetConnector server;

    const int SupportedClientVersion = 28430;

    public LoginServer(int port)
    {
        server = new NetConnector(port);
    }

    public void Start()
    {
        server.Start();
        Debug.Log("LoginServer started");
    }

    public void Stop()
    {
            
        if (server != null)
        {
            Debug.Log("Shutting down LoginServer");
            server.Shutdown();
            Debug.Log("LoginServer shut down");
        }
    }

    public void Update()
    {
        NetworkPacket packet;
        while (server.TryGetPacket(out packet))
        {
            switch (packet.Header)
            {
                case (ushort)LoginHeader.CONNECT: break;
                case (ushort)LoginHeader.DISCONNECT: HandleDisconnect(packet.Connection);
                    break;
                case (ushort) LoginHeader.C2L_USER_LOGIN: HandleAuthChallenge(packet);
                    break;
                default:
                    var session = ServiceContainer.GetService<ISessionHandler>().Get<LoginSession>(packet.Connection);
                    if (session != null) session.HandlePacket(packet);
                    else
                    {
                        throw new Exception("Packet sender has no active session");
                    }
                    break;
            }
        }
        NetConnection disconnected;
        while (server.CheckDisconnected(out disconnected)) HandleDisconnect(disconnected);
    }

    void HandleAuthChallenge(NetworkPacket m)
    {
        var db = ServiceContainer.GetService<IDatabase>();
        var clientVersion = (int) m.ReadUInt32();
        var name = m.ReadString();
        var password = m.ReadString();
        if (SupportedClientVersion != clientVersion)
        {
            SendAuthResult(m.Connection, eLoginRequestResult.LRR_INVALID_REVISION);
            return;
        }
        var acc = db.Accounts.Get(name, password);
        if (acc == null)
        {
            SendAuthResult(m.Connection, eLoginRequestResult.LRR_INVALID_USERNAME);
            return;
        }
        if (acc.Banned)
        {
            SendAuthResult(m.Connection, eLoginRequestResult.LRR_BANNED_ACCOUNT);
            return;
        }
        if (ServiceContainer.GetService<ISessionHandler>().Get<GameSession>(m.Connection) != null)
        {
            Debug.LogWarning(string.Format("Account '{0}' - Gamesession already active", acc.Name));
            SendAuthResult(m.Connection, eLoginRequestResult.LRR_LOGIN_ADD_FAILED);
            return;
        }
        if (acc.PasswordHash != AccountUtility.CalculateHash(password))
        {
            SendAuthResult(m.Connection, eLoginRequestResult.LRR_INVALID_PASSWORD);
            return;
        }
        var session = new LoginSession(m.Connection, acc);
        SendAuthResult(m.Connection, eLoginRequestResult.LRR_NONE);
        ServiceContainer.GetService<ISessionHandler>().Begin(session);
    }

    static void SendAuthResult(NetConnection netConnection, eLoginRequestResult result)
    {
        var m = LoginHeader.L2C_USER_LOGIN_ACK.CreatePacket();
        m.WriteInt32((int) PacketStatusCode.NO_ERROR);
        m.WriteInt32((int) result);
        netConnection.SendMessage(m);
    }

    static void HandleDisconnect(NetConnection con)
    {
        var sessionHandler = ServiceContainer.GetService<ISessionHandler>();
        var session = sessionHandler.Get<LoginSession>(con);
        if (session != null)
        {
            Debug.Log(session.Account.Name + " disconnected");
            sessionHandler.End(session);
        }
    }
}