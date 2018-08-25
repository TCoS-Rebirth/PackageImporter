using System;
using SBGame;

namespace SBGamePlay
{
    [Serializable] public class NA_Invisible : NPC_Appearance
    {
        public NA_Invisible()
        {
        }
    }
}
/*
function Game_Appearance CreateAndApply(Game_Pawn aPawn,export editinline Game_Appearance aAppearance) {
aPawn.bHidden = True;                                                       
aPawn.SetDrawType(0);                                                       
return aAppearance;                                                         
}
*/