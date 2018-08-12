namespace Database
{
    public class TransientDatabase: IDatabase
    {
        public IWorldDatabase World { get; }
        public IAccountDatabase Accounts { get; }
        public ICharacterDatabase Characters { get; }

        public TransientDatabase()
        {

        }
    }
}
