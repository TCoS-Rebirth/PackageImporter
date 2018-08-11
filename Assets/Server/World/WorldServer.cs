namespace Server.World
{
    public class WorldServer: IWorldServer
    {
        public string PublicIP { get; private set; }
        public int Port { get; private set; }

        public WorldServer(string publicIP, int port)
        {
            PublicIP = publicIP;
            Port = port;
        }

        public void Update()
        {
            
        }
    }
}
