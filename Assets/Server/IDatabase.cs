using System;
using System.Collections.Generic;
using System.Net;
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
    UserAccount Get(int uid, IPAddress ip);
    UserAccount Get(string name, string pass = "");
    bool Save(UserAccount account);
}

public interface ICharacterDatabase
{
    DB_Character GetCharacter(int uid);
    bool Save(Tuple<DB_Character, DB_CharacterSheet> character);
    DB_CharacterSheet GetSheet(int uid);
    IList<Tuple<DB_Character, DB_CharacterSheet>> GetCharacters(int accountID);
    List<DB_Item> GetItems(int characterID);
    bool Save(List<DB_Item> items);
    DB_Skill GetSkill(int uid);
    bool Save(DB_Skill skill);
    DB_SkillDeck GetSkillDeck(int uid);
    bool Save(DB_SkillDeck deck);
}