using System;
using System.Collections.Generic;

namespace Network
{
    public class PacketDispatcher<THeader> where THeader: struct, IConvertible
    {

        readonly Dictionary<ushort, Action<NetworkPacket>> _dispatchTable = new Dictionary<ushort, Action<NetworkPacket>>();

        public PacketDispatcher()
        {
            if (!typeof(THeader).IsEnum) throw new ArgumentException("THeader must be enum");
        }

        public void Add(THeader header, Action<NetworkPacket> handler)
        {
            _dispatchTable.Add((ushort)(object)header, handler);
        }

        public bool Dispatch(NetworkPacket packet)
        {
            Action<NetworkPacket> handler;
            if (_dispatchTable.TryGetValue(packet.Header, out handler))
            {
                handler(packet);
                return true;
            }
            return false;
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class HandlesPacketAttribute: Attribute
    {
        public GameHeader HeaderType { get; set; }

        public HandlesPacketAttribute(GameHeader headerType)
        {
            HeaderType = headerType;
        }
    }
}
