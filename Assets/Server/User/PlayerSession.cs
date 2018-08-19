using Network;

namespace User
{
    public abstract class PlayerSession
    {
        public NetConnection Connection { get; private set; }
        public UserAccount Account { get; private set; }

        protected PlayerSession(NetConnection connection, UserAccount account)
        {
            Connection = connection;
            Account = account;
        }

        public abstract void OnBegin();
        public abstract void OnEnd();
    }
}