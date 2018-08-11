namespace Server
{
    public interface IWorldServer
    {
        string PublicIP { get; }
        int Port { get; }
    }
}