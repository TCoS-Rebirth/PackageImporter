using SBBase;
using Network;

public static class PacketWriteExtensions
{

    public static void WriteLoginStream(this NetworkPacket packet, IActorPacketStream streamWriter)
    {
        streamWriter.WriteLoginStream(packet);
    }
}
