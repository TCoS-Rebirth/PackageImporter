namespace Server.Network
{
    static class PacketExtensions
    {
        public static NetworkPacket CreatePacket(this LoginHeader header)
        {
            return new NetworkPacket((ushort) header);
        }

        public static NetworkPacket CreatePacket(this GameHeader header)
        {
            return new NetworkPacket((ushort) header);
        }
    }
}
