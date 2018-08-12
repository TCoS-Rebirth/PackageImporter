using System.Collections.Generic;

namespace Network
{

    public enum PacketStatusCode
    {
        NO_ERROR = 0,
        UNKNOWN_ERROR = 1
    }

    public partial class NetworkPacket
    {

        byte[] buffer = new byte[0];

        int position;

        public NetworkPacket(ushort header)
        {
            Header = header;
            buffer = new byte[0];
            position = 0;
        }

        NetworkPacket()
        {
        }

        public NetConnection Connection { get; set; }

        public ushort Header { get; private set; }

        public uint Size
        {
            get { return (uint) buffer.Length; }
        }

        public byte[] Buffer
        {
            get { return buffer; }
            set
            {
                buffer = value;
                position = 0;
            }
        }

        public int Position
        {
            get { return position; }
            set { position = value; }
        }

        internal static NetworkPacket CreateFromIncoming(NetConnection connection, int header, byte[] buf)
        {
            var m = new NetworkPacket
            {
                Connection = connection,
                Header = (ushort) header,
                buffer = buf,
                position = 0
            };
            return m;
        }

        internal byte[] FinalizeForSending()
        {
            var b = new List<byte>();
            b.Add((byte) Header);
            b.Add((byte) (Header >> 8));
            b.Add((byte) Size);
            b.Add((byte) (Size >> 8));
            b.AddRange(Buffer);
            return b.ToArray();
        }
    }
}