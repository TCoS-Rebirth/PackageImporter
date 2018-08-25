using System;
using SBGame;

namespace SBGamePlay
{
    [Serializable] public class EV_AIIdle : Content_Event
    {
        public EV_AIIdle()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
local Game_AIController aI;
aI = Game_AIController(aObject.Controller);                                 
aI.mTargeting.SetDisabled();                                                
aI.StateSignal(41);                                                         
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
return Game_AIController(aObject.Controller) != None;                       
}
*/