using System;
using Engine;

namespace SBGame
{
    [Serializable] public class Game_RadialMenuOptions : UObject
    {
        public Game_RadialMenuOptions()
        {
        }

        public enum ERadialMenuOptions
        {
            RMO_MAIN,

            RMO_STATS,

            RMO_NOTHING,

            RMO_HELP,

            RMO_USE,

            RMO_OPENDOOR,

            RMO_SIT,

            RMO_TRADE,

            RMO_LOOT,

            RMO_INTERACT,

            RMO_CONVERSATION,

            RMO_TEAM_KICK,

            RMO_TEAM_INVITE,

            RMO_FRIEND_INVITE,

            RMO_GUILD_INVITE,

            RMO_TRAVEL,

            RMO_MAIL,

            RMO_ARENA,

            RMO_MINIGAME_INVITE,

            RMO_WHISPER,

            RMO_SHOP_BUY_FORGE,

            RMO_SHOP_BUY_TAILOR,

            RMO_SHOP_BUY_SOUL,

            RMO_SHOP_BUY_RUNE,

            RMO_SHOP_BUY_SPIRIT,

            RMO_SHOP_BUY_TAVERN,

            RMO_SHOP_BUY_GENERAL,

            RMO_SHOP_CRAFT_FORGE,

            RMO_SHOP_CRAFT_SOUL,

            RMO_SHOP_CRAFT_RUNE,

            RMO_SHOP_CRAFT_SPIRIT,

            RMO_SHOP_CRAFT_TAVERN,

            RMO_SHOP_CRAFT_GENERAL,

            RMO_SHOP_PAINTING,

            RMO_SHOP_SIGIL_FORGING,

            RMO_SHOP_DRAGON,

            RMO_MAX,
        }
    }
}