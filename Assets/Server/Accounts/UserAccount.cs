using System;

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
        public string EMail { get; private set; }
        public string Name { get; private set; }
        public string PasswordHash { get; private set; }

        public int UID { get; private set; }
        public bool Banned { get; private set; }

        public bool IsOnline { get; private set; }

        public DateTime LastLogin { get; private set; }
        public int LastUniverse { get; private set; }
        public AccountPrivilege Level { get; private set; }

        public UserAccount(int id, string name, string pass, string mail, bool banned, AccountPrivilege accPrivileges, DateTime lastLogin, bool isOnline, int lastUniverse)
        {
            UID = id;
            Name = name;
            PasswordHash = pass;
            EMail = mail;
            Banned = banned;
            Level = accPrivileges == AccountPrivilege.Error ? AccountPrivilege.Player : accPrivileges;
            LastLogin = lastLogin;
            IsOnline = isOnline;
            LastUniverse = lastUniverse;
        }

        public void SetLastLogin(DateTime time)
        {
            LastLogin = time;
        }

        public void SetIsOnline(bool value)
        {
            IsOnline = value;
        }
    }
}