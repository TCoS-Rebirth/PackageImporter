using System;
using System.Net;
using User;
using Network;
using SBGame;
using UnityEngine;

namespace World
{
    public class WorldServer: IWorldServer
    {
        public string PublicIP { get; private set; }
        public int Port { get; private set; }

        NetConnector server;

        public WorldServer(string publicIP, int port)
        {
            server = new NetConnector(port);
            PublicIP = publicIP;
            Port = port;
        }

        public void Start()
        {
            server.Start();
            Debug.Log("WorldServer started");
        }

        public void Stop()
        {
            if (server != null)
            {
                Debug.Log("Shutting down WorldServer");
                server.Shutdown();
                Debug.Log("WorldServer shut down");
            }
        }

        public void Update()
        {
            NetworkPacket packet;
            while (server.TryGetPacket(out packet))
            {
                switch (packet.Header)
                {
                    case (ushort)GameHeader.CONNECT: break;
                    case (ushort)GameHeader.DISCONNECT: HandleDisconnect(packet.Connection);
                        break;
                    case (ushort)GameHeader.C2S_TRAVEL_CONNECT: HandleTravelConnect(packet);
                        break;
                    default:
                        var session = ServiceContainer.GetService<ISessionHandler>().Get<GameSession>(packet.Connection);
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

        void HandleTravelConnect(NetworkPacket m)
        {
            var token = m.ReadInt32();
            var ipAddress = (m.Connection.ClientSocket.RemoteEndPoint as IPEndPoint).Address;
            var sessionHandler = ServiceContainer.GetService<ISessionHandler>();
            var account = ServiceContainer.GetService<IDatabase>().Accounts.Get(token, ipAddress);
            if (account != null)
            {
                Debug.Log(string.Format("User '{0}' connected", account.Name));
                var gameSession = new GameSession(m.Connection, account);
                sessionHandler.Begin(gameSession);
            }
            else
            {
                Debug.Log("Connection attempt with invalid login session encountered");
                m.Connection.Disconnect();
            }
        }

        static void HandleDisconnect(NetConnection con)
        {
            var sessionHandler = ServiceContainer.GetService<ISessionHandler>();
            var session = sessionHandler.Get<GameSession>(con);
            if (session != null)
            {
                Debug.Log(session.Account.Name + " disconnected");
                sessionHandler.End(session);
            }
        }
    }
}
