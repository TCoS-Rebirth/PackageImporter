using System;
using System.Net;
using Network;
using UnityEngine;
using Utilities;

namespace Accounts
{
    public class LoginSession: PlayerSession
    {
        PacketDispatcher<LoginHeader> dispatcher;

        public LoginSession(NetConnection connection, UserAccount account) : base(connection, account)
        {
            Account.LastLogin = DateTime.Now;
            dispatcher = new PacketDispatcher<LoginHeader>();
            AddHandlers();
        }

        void AddHandlers()
        {
            dispatcher.Add(LoginHeader.C2L_QUERY_UNIVERSE_LIST, HandleQueryUniverseList);
            dispatcher.Add(LoginHeader.C2L_UNIVERSE_SELECTED, HandleUniverseSelection);
        }

        public void HandlePacket(NetworkPacket packet)
        {
            if (!dispatcher.Dispatch(packet))
            {
                Debug.LogWarning("Unhandled packet: " + (LoginHeader) packet.Header);
            }
        }

        void Log(string message)
        {
            Debug.Log(string.Format("Session({0}):{1}", Account.Name, message));
        }

        public override void OnBegin()
        {
            var ipEndPoint = Connection.ClientSocket.RemoteEndPoint as IPEndPoint;
            Account.LastIP = ipEndPoint.Address;
            Log("Started");
        }

        public override void OnEnd()
        {
            Log("Ended");
        }

        void HandleQueryUniverseList(NetworkPacket m)
        {
            var outMessage = LoginHeader.L2C_QUERY_UNIVERSE_LIST_ACK.CreatePacket();
            outMessage.WriteInt32((int) PacketStatusCode.NO_ERROR);
            outMessage.WriteInt32(1);//count
            outMessage.WriteInt32(0);//ID
            outMessage.WriteString(GameServer.UniverseInfo.Name);
            outMessage.WriteString(GameServer.UniverseInfo.Language);
            outMessage.WriteString(GameServer.UniverseInfo.Type);
            outMessage.WriteString(ServiceRegistry.GetService<ISessionHandler>().GetCount<GameSession>().ToString());
            Connection.SendMessage(outMessage);
        }

        void HandleUniverseSelection(NetworkPacket m)
        {
            Account.LoginToken = AccountUtility.GenerateTransferToken();
            ServiceRegistry.GetService<IDatabase>().Accounts.Save(Account);
            /*var selectedID = */m.ReadInt32();
            var worldServer = ServiceRegistry.GetService<IWorldServer>();
            var outMessage = LoginHeader.L2C_UNIVERSE_SELECTED_ACK.CreatePacket();
            outMessage.WriteInt32((int) PacketStatusCode.NO_ERROR);
            outMessage.WriteInt32(0); //selectedID
            outMessage.WriteString("Complete_Universe");
            outMessage.WriteInt32(Account.LoginToken);
            outMessage.WriteByteArrayWithoutLength(IPAddress.Parse(worldServer.PublicIP).GetAddressBytes());
            outMessage.WriteUint16((ushort) worldServer.Port);
            Connection.SendMessage(outMessage);
        }
    }
}
