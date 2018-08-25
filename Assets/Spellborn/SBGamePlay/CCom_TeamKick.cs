using System;
using SBGame;

namespace SBGamePlay
{
    [Serializable] public class CCom_TeamKick : Game_ConsoleCommand
    {
        public CCom_TeamKick()
        {
        }
    }
}
/*
native function bool Execute(Game_Pawn aPawn,array<string> Params,Game_Pawn aTarget);
*/