using System;
using System.Net;
using Accounts;
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
    PacketDispatcher<LoginHeader> dispatcher;

    const int SupportedClientVersion = 28430;

    public LoginServer(int port)
    {
        server = new NetConnector(port);
        dispatcher = new PacketDispatcher<LoginHeader>();
    }

    public int GetConnectionCount()
    {
        return server.GetConnectionCount();
    }

    public void Start()
    {
        RegisterHandlers();
        server.Start();
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
        while (server.TryGetPacket(out packet)) dispatcher.Dispatch(packet);
    }

    void RegisterHandlers()
    {
        dispatcher.RegisterHandler(LoginHeader.C2L_USER_LOGIN, HandleAuthChallenge);
        dispatcher.RegisterHandler(LoginHeader.C2L_QUERY_UNIVERSE_LIST, HandleQueryUniverseList);
        dispatcher.RegisterHandler(LoginHeader.C2L_UNIVERSE_SELECTED, HandleUniverseSelection);
        dispatcher.RegisterHandler(LoginHeader.DISCONNECT, HandleDisconnect);
    }

    #region Handler

    void HandleAuthChallenge(NetworkPacket m)
    {
        var db = ServiceRegistry.GetService<IDatabase>();
        var clientVersion = (int) m.ReadUInt32();
        var name = m.ReadString();
        var password = m.ReadString();
        if (SupportedClientVersion != clientVersion)
        {
            SendAuthResult(m.Connection, eLoginRequestResult.LRR_INVALID_REVISION);
            return;
        }
        var acc = db.Accounts.Get(name);
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
        if (acc.IsOnline)
        {
            SendAuthResult(m.Connection, eLoginRequestResult.LRR_LOGIN_ADD_FAILED);
        }
        if (acc.PasswordHash != AccountUtility.CalculateHash(password))
        {
            SendAuthResult(m.Connection, eLoginRequestResult.LRR_INVALID_PASSWORD);
        }
        else
        {
            acc.SetLastLogin(DateTime.Now);
            if (db.Accounts.Save(acc))
            {
                var session = new PlayerSession(m.Connection, acc, AccountUtility.GenerateTransferKey());
                Debug.Log("Player authenticated: " + acc.Name);
                SendAuthResult(m.Connection, eLoginRequestResult.LRR_NONE);
                ServiceRegistry.GetService<ISessionHandler>().StartSession(session);
            }
            else
            {
                Debug.LogWarning("Error updating account for login");
                SendAuthResult(m.Connection, eLoginRequestResult.LRR_LOGIN_CONNECT_FAILED);
            }
        }
    }

    static void SendAuthResult(NetConnection netConnection, eLoginRequestResult result)
    {
        var m = L2C_USER_LOGIN_ACK(result);
        netConnection.SendMessage(m);
    }

    void HandleQueryUniverseList(NetworkPacket m)
    {
        var outMessage = L2C_QUERY_UNIVERSE_LIST_ACK(m);
        m.Connection.SendMessage(outMessage);
    }

    void HandleUniverseSelection(NetworkPacket m)
    {
        /*var selectedID = */m.ReadInt32();
        var session = ServiceRegistry.GetService<ISessionHandler>().GetSession(m.Connection);
        var msg = L2C_UNIVERSE_SELECTED_ACK(session.TransferKey);
        m.Connection.SendMessage(msg);
    }

    static void HandleDisconnect(NetworkPacket m)
    {
        var sessionHandler = ServiceRegistry.GetService<ISessionHandler>();
        var session = sessionHandler.GetSession(m.Connection);
        if (session != null) Debug.Log(session.Account.Name + " disconnected");
        sessionHandler.EndSession(session);
    }

    #endregion

    #region Packet creation

    static NetworkPacket L2C_USER_LOGIN_ACK(eLoginRequestResult result)
    {
        var m = LoginHeader.L2C_USER_LOGIN_ACK.CreatePacket();
        m.WriteInt32((int) PacketStatusCode.NO_ERROR);
        m.WriteInt32((int) result);
        return m;
    }

    NetworkPacket L2C_QUERY_UNIVERSE_LIST_ACK(NetworkPacket inMessage)
    {
        var m = LoginHeader.L2C_QUERY_UNIVERSE_LIST_ACK.CreatePacket();
        m.WriteInt32((int) PacketStatusCode.NO_ERROR);
        m.WriteInt32(1);
        m.WriteInt32(0);
        m.WriteString(GameServer.UniverseInfo.Name);
        m.WriteString(GameServer.UniverseInfo.Language);
        m.WriteString(GameServer.UniverseInfo.Type);
        m.WriteString(ServiceRegistry.GetService<ISessionHandler>().GetSessionCount().ToString());
        return m;
    }

    static NetworkPacket L2C_UNIVERSE_SELECTED_ACK(int transferKey)
    {
        var worldServer = ServiceRegistry.GetService<IWorldServer>();
        var m = LoginHeader.L2C_UNIVERSE_SELECTED_ACK.CreatePacket();
        m.WriteInt32((int) PacketStatusCode.NO_ERROR);
        m.WriteInt32(0);
        m.WriteString("Complete_Universe");
        m.WriteInt32(transferKey);
        m.WriteByteArrayWithoutLength(IPAddress.Parse(worldServer.PublicIP).GetAddressBytes());
        m.WriteUint16((ushort) worldServer.Port);
        return m;
    }

    #endregion
}