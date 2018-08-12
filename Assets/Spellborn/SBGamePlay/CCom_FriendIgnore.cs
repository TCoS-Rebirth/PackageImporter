using System;
using SBGame;

namespace SBGamePlay
{
    [Serializable] public class CCom_FriendIgnore : Game_ConsoleCommand
    {
        public CCom_FriendIgnore()
        {
        }
    }
}
/*
native function bool Execute(Game_Pawn aPawn,array<string> Params,Game_Pawn aTarget);
*/