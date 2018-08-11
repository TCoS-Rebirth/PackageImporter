using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Server.Utilities
{
    public static class AccountUtility
    {

        static readonly HashSet<int> usedTransferkeys = new HashSet<int>();

        public static string CalculateHash(string input)
        {
            var hash = new StringBuilder();
            var md5provider = new MD5CryptoServiceProvider();
            var bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (var i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        
        public static int GenerateTransferKey()
        {
            var newKey = new Random(DateTime.Now.Minute).Next();
            while (usedTransferkeys.Contains(newKey))
            {
                newKey = new Random(DateTime.Now.Second).Next();
            }
            return newKey;
        }
    }
}
