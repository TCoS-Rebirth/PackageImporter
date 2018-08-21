using System;
using System.Collections.Generic;
using System.Net;
using User;
using SBBase;
using Utilities;
using UnityEngine;
using Sirenix.Serialization;

namespace Database
{
    [UnityEngine.CreateAssetMenu]
    public class TransientDatabase: Sirenix.OdinInspector.SerializedScriptableObject, IDatabase
    {

        [SerializeField] WorldDatabase wdb;
        [SerializeField] AccountDatabase adb;
        [SerializeField] CharacterDatabase cdb;

        public IWorldDatabase World { get { return wdb; } }
        public IAccountDatabase Accounts { get { return adb; } }
        public ICharacterDatabase Characters { get { return cdb; } }

        [Sirenix.OdinInspector.Button]
        public void Create()
        {
            wdb = new WorldDatabase();
            adb = new AccountDatabase();
            cdb = new CharacterDatabase();
        }

        void OnEnable()
        {
            adb.Reset();
        }

        [Serializable] class WorldDatabase: IWorldDatabase
        {
            public UniverseInfo LoadInfo()
            {
                throw new System.NotImplementedException();
            }

            public bool Save(UniverseInfo info)
            {
                throw new System.NotImplementedException();
            }
        }

        [Serializable] class AccountDatabase : IAccountDatabase
        {

            [SerializeField] List<UserAccount> accounts = new List<UserAccount>();

            public void Reset()
            {
                accounts = new List<UserAccount>();
            }

            public UserAccount Get(int loginToken, IPAddress loginIP)
            {
                for (var i = 0; i < accounts.Count; i++)
                {
                    if (accounts[i].LastIP.Equals(loginIP) && accounts[i].LoginToken == loginToken) return accounts[i];
                }
                return null;
            }

            public UserAccount Get(string name, string pass)
            {
                for (var i = 0; i < accounts.Count; i++)
                {
                    if (accounts[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase)) return accounts[i];
                }
                var acc = new UserAccount(accounts.Count, name, AccountUtility.CalculateHash(pass), "None@None.com", false, AccountPrivilege.Player, DateTime.Now, 0);
                accounts.Add(acc);
                return acc;
            }

            public bool Save(UserAccount account)
            {
                return true;
            }
        }

        [Serializable] class CharacterDatabase : ICharacterDatabase
        {

            [SerializeField] List<DBPlayerCharacter> characterData = new List<DBPlayerCharacter>();
            [SerializeField] List<DB_Item> itemData = new List<DB_Item>();
            [SerializeField] List<DB_Skill> skillData = new List<DB_Skill>();
            [SerializeField] List<DB_SkillDeck> skillDecks = new List<DB_SkillDeck>();

            public int AllocateCharacterID()
            {
                var id = 0;
                for (var i = 0; i < characterData.Count; i++)
                {
                    if (characterData[i].Character.Id >= id) id = characterData[i].Character.Id + 1;
                }
                return id;
            }

            public int AllocateSkillDeckID()
            {
                return AllocateCharacterID();
            }

            public int AllocateItemID()
            {
                return AllocateCharacterID();
            }

            public DB_Character GetCharacter(int uid, int accountID)
            {
                for (var i = 0; i < characterData.Count; i++)
                {
                    if (characterData[i].Character.Id == uid && characterData[i].Character.AccountID == accountID) return characterData[i].Character;
                }
                throw new NullReferenceException("Character does not exist: " + uid);
            }

            public bool Save(DBPlayerCharacter character)
            {
                if (!characterData.Contains(character)) characterData.Add(character);
                return true;
            }

            public bool DeleteCharacter(int uid, int accountID)
            {
                for (var c = characterData.Count; c-->0;)
                {
                    if (characterData[c].Character.Id != uid) continue;
                    if (characterData[c].Character.AccountID != accountID) continue;
                    for (var i = itemData.Count; i-->0;)
                    {
                        if (itemData[i].CharacterID == uid) itemData.RemoveAt(i);
                    }
                    for (var i = skillDecks.Count; i-->0;)
                    {
                        if (skillDecks[i].mName == characterData[c].Character.Name) //TODO replace
                        {
                            skillDecks.RemoveAt(i);
                        }
                    }
                    characterData.RemoveAt(c);
                    return true;
                }
                return false;
            }

            public DB_CharacterSheet GetSheet(int uid)
            {
                for (var i = 0; i < characterData.Count; i++)
                {
                    if (characterData[i].Character.Id == uid) return characterData[i].Sheet;
                }
                throw new NullReferenceException("Character sheet does not exist: " + uid);
            }

            public IList<DBPlayerCharacter> GetCharacters(int accountID)
            {
                var chars = new List<DBPlayerCharacter>();
                for (var i = 0; i < characterData.Count; i++)
                {
                    if (characterData[i].Character.AccountID == accountID) chars.Add(characterData[i]);
                }
                return chars;
            }

            public List<DB_Item> GetItems(int characterID)
            {
                var items = new List<DB_Item>();
                for (var i = 0; i < itemData.Count; i++)
                {
                    if (itemData[i].CharacterID == characterID) items.Add(itemData[i]);
                }
                return items;
            }

            public bool Save(List<DB_Item> items)
            {
                for (var i = 0; i < items.Count; i++)
                {
                    if (!itemData.Contains(items[i])) itemData.Add(items[i]);
                }
                return true;
            }

            public DB_Skill GetSkill(int skillID)
            {
                for (var i = 0; i < skillData.Count; i++)
                {
                    if (skillData[i].ActionRid == skillID) return skillData[i];
                }
                throw new Exception("Skill does not exist: " + skillID);
            }

            public bool Save(DB_Skill skill)
            {
                if (!skillData.Contains(skill)) skillData.Add(skill);
                return true;
            }

            public DB_SkillDeck GetSkillDeck(int uid)
            {
                for (var i = 0; i < skillDecks.Count; i++)
                {
                    if (skillDecks[i].Id == uid) return skillDecks[i];
                }
                throw new Exception("Skilldeck does not exist: " + uid);
            }

            public bool Save(DB_SkillDeck deck)
            {
                if (!skillDecks.Contains(deck)) skillDecks.Add(deck);
                return true;
            }
        }
    }
}
