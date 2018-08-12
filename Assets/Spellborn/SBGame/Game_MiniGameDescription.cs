using System;
using Engine;

namespace SBGame
{
    [Serializable] public class Game_MiniGameDescription : UObject
    {
        public string Title = string.Empty;

        public string Description = string.Empty;

        public Game_MiniGameDescription()
        {
        }
    }
}