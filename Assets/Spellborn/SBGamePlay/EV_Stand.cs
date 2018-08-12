using System;
using SBGame;

namespace SBGamePlay
{
    [Serializable] public class EV_Stand : Content_Event
    {
        public EV_Stand()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
aObject.sv_Sit(False,False);                                                
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
if (!Game_Controller(aObject.Controller).IsSitting()) {                     
return False;                                                             
}
return True;                                                                
}
*/