using System;
using SBGame;

namespace SBGamePlay
{
    [Serializable] public class EV_Die : Content_Event
    {
        public EV_Die()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
aObject.SetHealth(0.00000000);                                              
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
return True;                                                                
}
*/