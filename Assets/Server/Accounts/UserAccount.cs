using System;
using System.Net;

namespace Accounts
{

    public enum AccountPrivilege
    {
        Player,
        Error,
        GM,
        Admin
    }

    /// <summary>
    ///     Represents a User with its rights and access information
    /// </summary>
    [Serializable]
    public class UserAccount
    {
        public int UID { get; private set; }
        public string Name { get; private set; }
        public string PasswordHash { get; private set; }
        public string EMail { get; private set; }
        public AccountPrivilege Level { get; private set; }
        public bool Banned { get; set; }

        public DateTime LastLogin { get; set; }
        public IPAddress LastIP { get; set; }
        public int LoginToken { get; set; }
        public int LastUniverse { get; set; }

        public UserAccount(int id, string name, string pass, string mail, bool banned, AccountPrivilege accPrivileges, DateTime lastLogin, int lastUniverse)
        {
            UID = id;
            Name = name;
            PasswordHash = pass;
            EMail = mail;
            Banned = banned;
            Level = accPrivileges == AccountPrivilege.Error ? AccountPrivilege.Player : accPrivileges;
            LastLogin = lastLogin;
            LastUniverse = lastUniverse;
        }
    }
}