﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using SBGame;
using TCosReborn.Framework.Common;


namespace SBGamePlay
{


    public class MessageSender : SBPackageResource
    {
        
        public const int RANGE_UNKNOWN = 512;
        
        public const int RANGE_SYSTEM = 256;
        
        public const int RANGE_ERROR = 128;
        
        public const int RANGE_PRIVATE = 64;
        
        public const int RANGE_LOCAL = 32;
        
        public const int RANGE_BROADCAST = 16;
        
        public const int RANGE_HOUSE = 8;
        
        public const int RANGE_GUILD = 4;
        
        public const int RANGE_TEAM = 2;
        
        public const int RANGE_FRIENDS = 1;
        
        public Game_PlayerController PC;
        
        public int currentMessageRange;
        
        public float currentRadius;
        
        public string senderName = string.Empty;
        
        public string receiverName = string.Empty;
        
        public string NO_PLAYER_MSG = string.Empty;
        
        public MessageSender()
        {
        }
    }
}
