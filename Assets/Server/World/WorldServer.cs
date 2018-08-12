using System;
using System.Net;
using Accounts;
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
                    case (ushort)GameHeader.DISCONNECT: HandleDisconnect(packet);
                        break;
                    case (ushort)GameHeader.C2S_TRAVEL_CONNECT: HandleTravelConnect(packet);
                        break;
                    default:
                        var session = ServiceRegistry.GetService<ISessionHandler>().Get<GameSession>(packet.Connection);
                        if (session != null) session.HandlePacket(packet);
                        else
                        {
                            throw new Exception("Packet sender has not active session");
                        }
                        break;
                }
            }
        }

        void HandleTravelConnect(NetworkPacket m)
        {
            var token = m.ReadInt32();
            var ipAddress = (m.Connection.ClientSocket.RemoteEndPoint as IPEndPoint).Address;
            var sessionHandler = ServiceRegistry.GetService<ISessionHandler>();
            var account = ServiceRegistry.GetService<IDatabase>().Accounts.Get(token, ipAddress);
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

        static void HandleDisconnect(NetworkPacket m)
        {
            var sessionHandler = ServiceRegistry.GetService<ISessionHandler>();
            var session = sessionHandler.Get<LoginSession>(m.Connection);
            if (session != null) Debug.Log(session.Account.Name + " disconnected");
            sessionHandler.End(session);
        }
    }
}
