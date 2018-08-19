using System;
using System.Collections.Generic;
using System.Net;
using User;
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
    int AllocateCharacterID();
    int AllocateSkillDeckID();
    int AllocateItemID();
    DB_Character GetCharacter(int uid, int accountID);
    bool Save(Tuple<DB_Character, DB_CharacterSheet> character);
    DB_CharacterSheet GetSheet(int uid);
    IList<Tuple<DB_Character, DB_CharacterSheet>> GetCharacters(int accountID);
    List<DB_Item> GetItems(int characterID);
    bool Save(List<DB_Item> items);
    DB_Skill GetSkill(int uid);
    bool Save(DB_Skill skill);
    DB_SkillDeck GetSkillDeck(int uid);
    bool Save(DB_SkillDeck deck);

    bool DeleteCharacter(int uid, int accountID);
}