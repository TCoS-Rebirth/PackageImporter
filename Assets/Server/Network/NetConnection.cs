using System.Collections.Generic;
using System.Net.Sockets;

namespace Network
{
    public class NetConnection
    {
        public readonly Queue<NetworkPacket> MessageQueue = new Queue<NetworkPacket>();
        internal volatile bool PendingDisconnect;

        public NetConnection(Socket socket)
        {
            ClientSocket = socket;
        }

        public Socket ClientSocket { get; private set; }

        public void Disconnect()
        {
            if (ClientSocket.Connected)
            {
                PendingDisconnect = true;
                //ClientSocket.Disconnect(false);
            }
        }

        /// <summary>
        ///     Use this to send network messages to the client
        /// </summary>
        public void SendMessage(NetworkPacket msg)
        {
            if (ClientSocket == null || !ClientSocket.Connected)
            {
                return;
            }
            msg.Connection = this;
            lock (MessageQueue)
            {
                MessageQueue.Enqueue(msg);
            }
        }

        #region Internal

        internal void SetupReceiveState(ReceiveState newState)
        {
            State = newState;
            switch (State)
            {
                case ReceiveState.Header:
                    incomingReadBuffer = new byte[4];
                    break;
                case ReceiveState.Body:
                    incomingMessageHeader = (ushort) (incomingReadBuffer[0] | incomingReadBuffer[1] << 8);
                    incomingMessageSize = (ushort) (incomingReadBuffer[2] | incomingReadBuffer[3] << 8);
                    incomingReadBuffer = new byte[incomingMessageSize];
                    break;
            }
        }

        internal NetworkPacket ReceiveMessage()
        {
            var m = NetworkPacket.CreateFromIncoming(this, incomingMessageHeader, incomingReadBuffer);
            incomingReadBuffer = new byte[4];
            State = ReceiveState.Header;
            return m;
        }

        internal ushort incomingMessageHeader;
        internal ushort incomingMessageSize;
        internal byte[] incomingReadBuffer;

        internal enum ReceiveState
        {
            Header,
            Body
        }

        internal ReceiveState State = ReceiveState.Header;

        #endregion
    }
}