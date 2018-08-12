using Server.Network;
using UnityEngine;

namespace Server.World
{
    public class WorldServer: IWorldServer
    {
        public string PublicIP { get; private set; }
        public int Port { get; private set; }

        NetConnector server;
        PacketDispatcher<GameHeader> dispatcher;

        public WorldServer(string publicIP, int port)
        {
            server = new NetConnector(port);
            dispatcher = new PacketDispatcher<GameHeader>();
            PublicIP = publicIP;
            Port = port;
        }

        public void Start()
        {
            RegisterHandlers();
            server.Start();
        }

        public void Stop()
        {
            if (server != null)
            {
                Debug.Log("Shutting down WorldServer");
                server.Shutdown();
                Debug.Log("WorldServer shut down");
            }
        }

        public void Update()
        {
            NetworkPacket packet;
            while (server.TryGetPacket(out packet)) dispatcher.Dispatch(packet);
        }

        void RegisterHandlers()
        {

        }
    }
}
