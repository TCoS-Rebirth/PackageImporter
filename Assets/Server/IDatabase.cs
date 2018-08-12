using Accounts;
using SBBase;

public interface IDatabase
{
    IWorldDatabase World { get; }
    IAccountDatabase Accounts { get; }
    ICharacterDatabase Characters { get; }
}

public interface IWorldDatabase
{
    UniverseInfo LoadInfo();
    bool Save(UniverseInfo info);
}

public interface IAccountDatabase
{
    UserAccount Get(int uid);
    UserAccount Get(string name);
    bool Save(UserAccount account);
}

public interface ICharacterDatabase
{
    DB_Character Load(int uid);
    bool Save(DB_Character character);
}