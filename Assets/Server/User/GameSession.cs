using System;
using System.Reflection;
using Network;
using SBGame;
using UnityEngine;
using System.Linq;
using World;
using SBBase;

namespace User
{
    public partial class GameSession: PlayerSession
    {
        PacketDispatcher<GameHeader> dispatcher;
        public MapIDs ActiveClientMap { get; private set; }
        public GameMap ActiveCharacterMap { get; private set; }
        public Game_PlayerController ActiveCharacter { get; private set; }

        public GameSession(NetConnection connection, UserAccount account) : base(connection, account)
        {
            dispatcher = new PacketDispatcher<GameHeader>();
            AddHandlers();
        }

        public void HandlePacket(NetworkPacket packet)
        {
            if (!dispatcher.Dispatch(packet))
            {
                Debug.LogWarning("Unhandled packet: " + (GameHeader) packet.Header);
            }
        }

        void AddHandlers()
        {
            var methods = GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            for (var i = 0; i < methods.Length; i++)
            {
                if (methods[i].ReturnType != typeof(void)) continue;
                var attribute = methods[i].GetCustomAttributes(typeof(HandlesPacketAttribute), false).FirstOrDefault() as HandlesPacketAttribute;
                if (attribute == null) continue;
                var parameters = methods[i].GetParameters();
                if (parameters.Length != 1 || parameters[0].ParameterType != typeof(NetworkPacket))
                {
                    throw new Exception(string.Format("Method {0} requires exactly 1 parameter of type {1}", methods[i].Name, typeof(NetworkPacket).Name));
                }
                var handler = (PacketHandlerDelegate)Delegate.CreateDelegate(typeof(PacketHandlerDelegate), this, methods[i]);
                dispatcher.Add(attribute.HeaderType, handler);
            }
        }

        void Log(string message)
        {
            Debug.Log(string.Format("Session({0}):{1}", Account.Name, message));
        }

        /// <summary>
        ///     Instructs the player client to load a specific map (S2C_WORLD_PRE_LOGIN)
        /// </summary>
        /// <param name="newMap"></param>
        public void LoadClientMap(MapIDs newMap)
        {
            var m = GameHeader.S2C_WORLD_PRE_LOGIN.CreatePacket();
            m.WriteInt32((int) PacketStatusCode.NO_ERROR);
            m.WriteInt32((int) newMap);
            Connection.SendMessage(m);
            ActiveClientMap = newMap;
        }

        public override void OnBegin()
        {
            Log("Started");
            LoadClientMap(MapIDs.CHARACTER_SELECTION);
        }

        public override void OnEnd()
        {
            if (ActiveCharacter != null)
            {
                Debug.LogWarning("TODO save character after logout");
                ActiveCharacterMap.Remove(ActiveCharacter);
                GameObject.Destroy(ActiveCharacter.gameObject);
            }
            Log("Ended");
        }

        [HandlesPacket(GameHeader.C2S_WORLD_LOGOUT)]
        void C2S_WORLD_LOGOUT(NetworkPacket packet)
        {
            Connection.SendMessage(GameHeader.S2C_WORLD_LOGOUT_ACK.CreatePacket());
            Connection.Disconnect();
        }

        [HandlesPacket(GameHeader.C2S_WORLD_PRE_LOGIN_ACK)]
        void C2S_WORLD_PRE_LOGIN_ACK(NetworkPacket packet)
        {
            /*var status = */packet.ReadInt32();
            if (ActiveClientMap == MapIDs.CHARACTER_SELECTION)
            {
                var charDB = ServiceContainer.GetService<IDatabase>().Characters;
                var chars = charDB.GetCharacters(Account.UID);
                var outMsg = GameHeader.S2C_CS_LOGIN.CreatePacket();
                outMsg.WriteInt32(chars.Count);
                for (var i = 0; i < chars.Count; i++)
                {
                    outMsg.Write(chars[i].Character);
                    outMsg.Write(chars[i].Sheet);
                    var items = charDB.GetItems(chars[i].Character.Id);
                    outMsg.Write(items);
                }
                outMsg.WriteInt32(chars.Count);
                for (int i = 0; i < chars.Count; i++)
                {
                    outMsg.WriteInt32(chars[i].Character.Id);
                    outMsg.WriteInt32(SBDBSync.GetFameLevelByPoints((int)chars[i].Sheet.FamePoints));
                }
                Connection.SendMessage(outMsg);
            }
            else
            {
                if (ActiveCharacter == null)
                {
                    Connection.Disconnect();//character must exist
                    return;
                }
                var msg = GameHeader.S2C_WORLD_LOGIN.CreatePacket();
                msg.WriteInt32((int)PacketStatusCode.NO_ERROR);
                msg.WriteLoginStream(ActiveCharacter);
                Connection.SendMessage(msg);
            }
        }
    }
}