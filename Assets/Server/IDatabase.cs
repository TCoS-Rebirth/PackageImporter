using System;
using System.Collections.Generic;
using System.Net;
using User;
using SBBase;
using Database;

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
    UserAccount Get(int uid, IPAddress ip);
    UserAccount Get(string name, string pass = "");
    bool Save(UserAccount account);
}

public interface ICharacterDatabase
{
    int AllocateCharacterID();
    int AllocateSkillDeckID();
    int AllocateItemID();
    DB_Character GetCharacter(int uid, int accountID);
    bool Save(DBPlayerCharacter character);
    DB_CharacterSheet GetSheet(int uid);
    IList<DBPlayerCharacter> GetCharacters(int accountID);
    List<DB_Item> GetItems(int characterID);
    bool Save(List<DB_Item> items);
    DB_Skill GetSkill(int uid);
    bool Save(DB_Skill skill);
    DB_SkillDeck GetSkillDeck(int uid);
    bool Save(DB_SkillDeck deck);

    bool DeleteCharacter(int uid, int accountID);
}