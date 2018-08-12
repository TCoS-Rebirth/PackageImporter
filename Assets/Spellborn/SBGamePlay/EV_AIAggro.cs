using System;
using SBGame;

namespace SBGamePlay
{
    [Serializable] public class EV_AIAggro : Content_Event
    {
        public EV_AIAggro()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
local Game_AIController aI;
if (aSubject != None) {                                                     
aI.mTargeting.SetPawn(aSubject);                                          
}
aI.StateSignal(43);                                                         
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
return Game_AIController(aObject.Controller) != None
&& aSubject != None;
}
*/