using System;
using System.Collections.Generic;
using Engine;
using SBGame;

namespace SBGamePlay
{
    [Serializable] public class MessageHandler : UObject
    {
        public const int HANDLER_NOT_FOUND = -1;

        public Game_PlayerController PC;

        public MessageFilter filter;

        public List<CommandHandler> handlers = new List<CommandHandler>();

        public MessageHandler()
        {
        }

        [Serializable] public struct CommandHandler
        {
            public string Command;

            public string handlerClassName;
        }
    }
}