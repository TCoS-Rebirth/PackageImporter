using System;
using System.Collections.Generic;

namespace Network
{

    public delegate void PacketHandlerDelegate(NetworkPacket packet);

    public class PacketDispatcher<THeader> where THeader: struct, IConvertible
    {

        readonly Dictionary<ushort, PacketHandlerDelegate> _dispatchTable = new Dictionary<ushort, PacketHandlerDelegate>();

        public PacketDispatcher()
        {
            if (!typeof(THeader).IsEnum) throw new ArgumentException("THeader must be enum");
        }

        public void Add(THeader header, PacketHandlerDelegate handler)
        {
            _dispatchTable.Add((ushort)(object)header, handler);
        }

        public bool Dispatch(NetworkPacket packet)
        {
            PacketHandlerDelegate handler;
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
