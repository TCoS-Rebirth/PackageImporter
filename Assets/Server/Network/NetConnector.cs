using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Fasterflect;
using UnityEngine;

namespace Network
{
    public class NetConnector
    {
        readonly List<NetConnection> connections = new List<NetConnection>();

        readonly Queue<NetworkPacket> packetQueu = new Queue<NetworkPacket>();
        readonly Queue<NetConnection> disconnections = new Queue<NetConnection>();
        readonly int port;

        readonly ManualResetEvent messageWaitEvent = new ManualResetEvent(false);
        AutoResetEvent workerDoneEvent = new AutoResetEvent(false);

        Socket listenSocket;

        BackgroundWorker queueWorker;

        volatile bool shutDownRequested;

        Thread _thread;

        public NetConnector(int port)
        {
            this.port = port;
        }

        public bool IsRunning
        {
            get { return _thread != null & listenSocket.IsBound; }
        }

        public int GetConnectionCount()
        {
            lock (connections)
            {
                return connections.Count;
            }
        }

        public NetConnection GetConnection(Predicate<NetConnection> condition)
        {
            lock (connections)
            {
                for (var i = 0; i < connections.Count; i++)
                {
                    if (condition(connections[i]))
                    {
                        return connections[i];
                    }
                }
            }
            return null;
        }

        public bool TryGetPacket(out NetworkPacket networkPacket)
        {
            lock (packetQueu)
            {
                if (packetQueu.Count > 0)
                {
                    networkPacket = packetQueu.Dequeue();
                    return true;
                }
            }
            networkPacket = null;
            return false;
        }

        public bool CheckDisconnected(out NetConnection connection)
        {
            lock (disconnections)
            {
                if (disconnections.Count > 0)
                {
                    connection = disconnections.Dequeue();
                    return true;
                }
            }
            connection = null;
            return false;
        }

        public bool Start()
        {
            _thread = new Thread(Listen) {Name = string.Format("TcpServer:{0}", port)};
            _thread.Start();
            queueWorker = new BackgroundWorker {WorkerSupportsCancellation = true};
            queueWorker.DoWork += ResolveSendPacketQueues;
            queueWorker.RunWorkerAsync();
            return true;
        }

        public void Shutdown()
        {
            shutDownRequested = true;
            if (queueWorker != null)
            {
                queueWorker.CancelAsync();
                workerDoneEvent.WaitOne(1000);
            }
            FlushSendQueue();
            if (_thread != null)
            {
                try
                {
                    listenSocket.Shutdown(SocketShutdown.Receive);
                }
                catch { }
                listenSocket.Close();
                lock (connections)
                {
                    for (var i = 0; i < connections.Count; i++)
                    {
                        HandleDisconnect(connections[i]);
                    }
                }
                messageWaitEvent.Set();
                if (_thread != null)
                {
                    _thread.Abort();
                    _thread.Join(1000);
                }
            }
            lock (connections)
            {
                connections.Clear();
            }
        }

        void Listen()
        {
            var localEndPoint = new IPEndPoint(IPAddress.Any, port);
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listenSocket.Bind(localEndPoint);
                listenSocket.Listen(100);
                while (!shutDownRequested)
                {
                    if (Thread.CurrentThread.ThreadState == ThreadState.StopRequested || Thread.CurrentThread.ThreadState == ThreadState.Aborted)
                    {
                        break;
                    }
                    if (shutDownRequested) break;
                    messageWaitEvent.Reset();
                    try
                    {
                        listenSocket.BeginAccept(AcceptConnection, listenSocket);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                        break;
                    }
                    messageWaitEvent.WaitOne();
                }
            }
            catch (Exception e)
            {
                if (!(e is ThreadAbortException)) Debug.LogException(e);
            }
        }

        void AcceptConnection(IAsyncResult res)
        {
            messageWaitEvent.Set();
            var listenerSocket = (Socket) res.AsyncState;
            lock (connections)
            {
                try
                {
                    var clientSocket = listenerSocket.EndAccept(res);
                    if (clientSocket != null)
                    {
                        var nc = new NetConnection(clientSocket);
                        clientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                        connections.Add(nc);
                        nc.SetupReceiveState(NetConnection.ReceiveState.Header);
                        clientSocket.BeginReceive(nc.incomingReadBuffer, 0, 4, SocketFlags.None, ReadMessageCallback, nc);
                    }
                }
                catch (Exception e)
                {
                    if (!(e is ObjectDisposedException))
                    {
                        Debug.LogException(e);
                    }
                }
            }
        }

        void ReadMessageCallback(IAsyncResult ar)
        {
            var connection = ar.AsyncState as NetConnection;
            if (connection == null || !connection.ClientSocket.Connected)
            {
                if (connection != null)
                {
                    HandleDisconnect(connection);
                }
                return;
            }
            try
            {
                var bytesRead = connection.ClientSocket.EndReceive(ar);
                if (bytesRead == 0)
                {
                    HandleDisconnect(connection);
                    return;
                }
            }
            catch (Exception)
            {
                HandleDisconnect(connection);
                return;
            }
            if (connection.State == NetConnection.ReceiveState.Header)
            {
                connection.SetupReceiveState(NetConnection.ReceiveState.Body);
                if (connection.incomingMessageSize > 0)
                {
                    connection.ClientSocket.BeginReceive(connection.incomingReadBuffer, 0, connection.incomingMessageSize, SocketFlags.None, ReadMessageCallback,
                        connection);
                }
                else
                {
                    var m = connection.ReceiveMessage();
                    HandlePacketReceived(m);
                }
            }
            else
            {
                var m = connection.ReceiveMessage();
                HandlePacketReceived(m);
            }
        }

        void HandlePacketReceived(NetworkPacket networkPacket)
        {
            lock (packetQueu) packetQueu.Enqueue(networkPacket);
            if (!networkPacket.Connection.ClientSocket.Connected)
            {
                return;
            }
            try //Start listening for next networkPacket
            {
                networkPacket.Connection.SetupReceiveState(NetConnection.ReceiveState.Header);
                networkPacket.Connection.ClientSocket.BeginReceive(networkPacket.Connection.incomingReadBuffer, 0, 4, 0, ReadMessageCallback, networkPacket.Connection);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        void HandleDisconnect(NetConnection connection)
        {
            if (connection.ClientSocket != null)
            {
                try
                {
                    connection.ClientSocket.Shutdown(SocketShutdown.Both);
                }
                catch { } //if already shutdown, ignore
                connection.ClientSocket.Close(33);
            }
            lock (connections)
            {
                connections.Remove(connection);
            }
            lock (disconnections)
            {
                disconnections.Enqueue(connection);
            }
        }

        void ResolveSendPacketQueues(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            if (Thread.CurrentThread.Name == null)
            {
                Thread.CurrentThread.Name = "NetconnectorSendQueue";
            }
            while (!worker.CancellationPending & !shutDownRequested)
            {
                FlushSendQueue();
                Thread.Sleep(50);
            } //while
            workerDoneEvent.Set();
        }

        void FlushSendQueue()
        {
            lock (connections)
            {
                for (var i = connections.Count; i-- > 0;)
                {
                    lock (connections[i].MessageQueue)
                    {
                        if (connections[i].MessageQueue.Count <= 0) continue;
                        if (!connections[i].ClientSocket.Connected) continue;
                        var messageBytes = new List<byte>();
                        while (connections[i].MessageQueue.Count > 0)
                        {
                            var m = connections[i].MessageQueue.Dequeue();
                            if (m != null)
                            {
                                messageBytes.AddRange(m.FinalizeForSending());
                            }
                        }
                        connections[i].ClientSocket.Send(messageBytes.ToArray());
                    }//networkPacket queue lock
                    if (connections[i].PendingDisconnect)
                    {
                        connections[i].PendingDisconnect = false;
                        connections[i].ClientSocket.Disconnect(false);
                    }
                } //loop
            } // connections lock
        }
    }
}