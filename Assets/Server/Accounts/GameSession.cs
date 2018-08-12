using System;
using System.Net;
using System.Reflection;
using Network;
using SBBase;
using SBGame;
using UnityEngine;

namespace Accounts
{
    public class GameSession: PlayerSession
    {
        public Game_PlayerInfo Info { get; private set; }
        PacketDispatcher<GameHeader> dispatcher;
        public MapIDs ActiveMap { get; private set; }

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
                var attribute = methods[i].GetCustomAttribute<HandlesPacketAttribute>();
                if (attribute == null) continue;
                var parameters = methods[i].GetParameters();
                if (parameters.Length != 1 || parameters[0].ParameterType != typeof(NetworkPacket))
                {
                    throw new Exception(string.Format("Method {0} requires exactly 1 parameter of type {1}", methods[i].Name, nameof(NetworkPacket)));
                }
                var handler = (Action<NetworkPacket>)Delegate.CreateDelegate(typeof(Action<NetworkPacket>), methods[i]);
                dispatcher.Add(attribute.HeaderType, handler);
            }
        }

        void Log(string message)
        {
            Debug.Log(string.Format("Session({0}):{1}", Account.Name, message));
        }

        /// <summary>
        ///     Instructs the player client to load a specific map
        /// </summary>
        /// <param name="newMap"></param>
        public void LoadClientMap(MapIDs newMap)
        {
            var m = GameHeader.S2C_WORLD_PRE_LOGIN.CreatePacket();
            m.WriteInt32((int) PacketStatusCode.NO_ERROR);
            m.WriteInt32((int) newMap);
            Connection.SendMessage(m);
            ActiveMap = newMap;
        }

        public override void OnBegin()
        {
            Log("Started");
            LoadClientMap(MapIDs.CHARACTER_SELECTION);
        }

        public override void OnEnd()
        {
            Log("Ended");
        }

        [HandlesPacket(GameHeader.C2S_WORLD_PRE_LOGIN_ACK)]
        void C2S_WORLD_PRE_LOGIN_ACK(NetworkPacket packet)
        {
            /*var status = */packet.ReadInt32();
            if (ActiveMap == MapIDs.CHARACTER_SELECTION)
            {
                var charDB = ServiceRegistry.GetService<IDatabase>().Characters;
                var chars = charDB.GetCharacters(Account.UID);
                var outMsg = GameHeader.S2C_CS_LOGIN.CreatePacket();
                outMsg.WriteInt32(chars.Count);
                for (var i = 0; i < chars.Count; i++)
                {
                    outMsg.Write(chars[i].Item1);
                    outMsg.Write(chars[i].Item2);
                    var items = charDB.GetItems(chars[i].Item1.Id);
                    outMsg.WriteInt32(items.Count);
                    for (var j = 0; j < items.Count; j++)
                    {
                        outMsg.Write(items[i]);
                    }
                }
                outMsg.WriteInt32(chars.Count);
                for (int i = 0; i < chars.Count; i++)
                {
                    outMsg.WriteInt32(chars[i].Item1.Id);
                    outMsg.WriteInt32(0); //TODO fame value
                }
                Connection.SendMessage(outMsg);
            }
            else
            {

            }
        }

        [HandlesPacket(GameHeader.C2S_CS_CREATE_CHARACTER)]
        void C2S_CS_CREATE_CHARACTER(NetworkPacket packet)
        {
            var lod0 = packet.ReadByteArray();
            var lod1 = packet.ReadByteArray();
            var lod2 = packet.ReadByteArray();
            var lod3 = packet.ReadByteArray();
            var name = packet.ReadString();
            var archeType = packet.ReadInt32();
            var skillDeck = new DB_SkillDeck();
            skillDeck.mName = name; //TODO investigate - probably wrong
            for (var i = 0; i < 5; i++)
            {
                skillDeck.mSkills.Add(packet.ReadInt32());
            }
            var shieldIndicator = packet.ReadInt32();
            //Lods parsing
            Array.Reverse(lod0);
            Array.Reverse(lod1);
            Array.Reverse(lod2);
            Array.Reverse(lod3);
            //lod0
            int rightGauntletColour1 = lod0[5];
            int rightGauntletColour2 = lod0[6];
            int leftGauntletColour1 = lod0[7];
            int leftGauntletColour2 = lod0[8];
            int rightGloveColour1 = lod0[9];
            int rightGloveColour2 = lod0[10];
            int leftGloveColour1 = lod0[11];
            int leftGloveColour2 = lod0[12];
            //Lod0 rest
            int voiceId = lod0[0]; //
            int rightArmTattooId = (byte) (lod0[3] & 0x0F);
            int chestTattooId = (byte) (lod0[4] & 0x0F);
            int leftArmTattooId = (byte) ((lod0[4] & 0xF0) >> 4);
            //Lod1
            int shinRightColour1 = lod1[0];
            int shinRightColour2 = lod1[1];
            int shinLeftColour1 = lod1[2];
            int shinLeftColour2 = lod1[3];
            int thighRightColour1 = lod1[4];
            int thighRightColour2 = lod1[5];
            int thighLeftColour1 = lod1[6];
            int thighLeftColour2 = lod1[7];
            int beltColour1 = lod1[8];
            int beltColour2 = lod1[9];
            int rightShoulderColour1 = lod1[10];
            int rightShoudlerColour2 = lod1[11];
            int leftShoulderColour1 = lod1[12];
            int leftShoulderColour2 = lod1[13];
            int helmetColour1 = lod1[14];
            int helmetColour2 = lod1[15];
            int shoesColour1 = lod1[16];
            int shoesColour2 = lod1[17];
            int pantsColour1 = lod1[18];
            int pantsColour2 = lod1[19];
            //Lod2
            int rangedWeaponId = (byte) (((lod2[1] & 0x0F) << 2) | ((lod2[2] & 0xC0) >> 6));
            int shieldId = (byte) (((lod2[2] & 0x3F) << 2) | ((lod2[3] & 0xC0) >> 6));
            int meleeWeaponId = (byte) (((lod2[3] & 0x3F) << 2) | ((lod2[4] & 0xC0) >> 6));
            int shinRightId = (byte) (lod2[4] & 0x3F);
            int shinLeftId = (byte) ((lod2[5] & 0xFC) >> 2);
            int thighRightId = (byte) (((lod2[5] & 0x03) << 4) | ((lod2[6] & 0xF0) >> 4));
            int thighLeftId = (byte) (((lod2[6] & 0x0F) << 2) | ((lod2[7] & 0xC0) >> 6));
            int beltId = (byte) (lod2[7] & 0x3F);
            int gauntletRightId = (byte) ((lod2[8] & 0xFC) >> 2);
            int gauntletLeftId = (byte) (((lod2[8] & 0x03) << 4) | ((lod2[9] & 0xF0) >> 4));
            int shoulderRightId = (byte) (((lod2[9] & 0x0F) << 2) | ((lod2[10] & 0xC0) >> 6));
            int shoulderLeftId = (byte) (lod2[10] & 0x3F);
            int helmetId = (byte) ((lod2[11] & 0xFC) >> 2);
            int shoesId = (byte) (((lod2[11] & 0x03) << 5) | ((lod2[12] & 0xF8) >> 3));
            int pantsId = (byte) (((lod2[12] & 0x07) << 4) | ((lod2[13] & 0xF0) >> 4));
            int gloveRightId = (byte) (((lod2[13] & 0x0F) << 2) | ((lod2[14] & 0xC0) >> 6));
            int gloveLeftId = (byte) (lod2[14] & 0x3F);
            //Lod3
            int chestArmourColour1 = (byte) (((lod3[0] & 0xFE) << 1) | (lod3[1] >> 7));
            int chestArmourColour2 = (byte) (((lod3[1] & 0x7F) << 1) | (lod3[2] >> 7));
            int chestArmourId = (byte) ((lod3[2] & 0x7E) >> 1);
            int torsoColour1 = (byte) ((lod3[2] << 7) | (lod3[3] >> 1));
            int torsoColour2 = (byte) ((lod3[3] << 7) | (lod3[4] >> 1));
            int torsoId = (byte) ((lod3[4] << 7) | (lod3[5] >> 1));
            int hairColour = (byte) ((lod3[5] << 7) | (lod3[6] >> 1));
            int hairStyleId = (byte) (((lod3[6] & 0x01) << 5) | (lod3[7] >> 3));
            int bodyColour = (byte) ((lod3[7] << 5) | (lod3[8] >> 3));
            int headTypeId = (byte) (((lod3[8] & 0x07) << 4) | ((lod3[9] & 0xF0) >> 4));
            int bodyTypeId = (byte) ((lod3[9] & 0x0C) >> 2);
            int genderId = (byte) ((lod3[9] & 0x02) >> 1);
            int raceId = (byte) (lod3[9] & 0x01);

            throw new NotImplementedException();
        }
    }
}