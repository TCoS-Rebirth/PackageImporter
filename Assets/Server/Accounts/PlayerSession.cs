using SBGame;
using Server.Network;

namespace Server.Accounts
{
    public class PlayerSession
    {
        public NetConnection Connection { get; private set; }
        public UserAccount Account { get; private set; }
        public int TransferKey { get; private set; }
        public Game_PlayerCharacter ActiveCharacter { get; private set; }

        public PlayerSession(NetConnection connection, UserAccount account, int transferKey)
        {
            Connection = connection;
            Account = account;
            TransferKey = transferKey;
        }
    }
}
