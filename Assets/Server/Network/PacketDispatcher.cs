using System;
using System.Collections.Generic;
using UnityEngine;

namespace Network
{
    public class PacketDispatcher<THeader> where THeader: struct, IConvertible
    {

        readonly Dictionary<ushort, Action<NetworkPacket>> _dispatchTable = new Dictionary<ushort, Action<NetworkPacket>>();

        public PacketDispatcher()
        {
            if (!typeof(THeader).IsEnum) throw new ArgumentException("THeader must be enum");
        }

        public void RegisterHandler(THeader header, Action<NetworkPacket> handler)
        {
            _dispatchTable.Add((ushort)(object)header, handler);
        }

        public void Dispatch(NetworkPacket packet)
        {
            Action<NetworkPacket> handler;
            if (_dispatchTable.TryGetValue(packet.Header, out handler))
            {
                handler(packet);
            }
            else
            {
                Debug.LogWarning("PacketID is not registered: " + packet.Header);
            }
        }
    }
}
