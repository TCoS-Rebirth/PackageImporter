using System;
using SBGame;

namespace SBGamePlay
{
    [Serializable] public class EV_AIFollow : Content_Event
    {
        public EV_AIFollow()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
local Game_AIController aI;
aI = Game_AIController(aObject.Controller);                                 
if (aSubject != None) {                                                     
aI.mTargeting.SetPawn(aSubject);                                          
} else {                                                                    
aI.mTargeting.SetNearestPawn();                                           
}
aI.StateSignal(46);                                                         
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
return Game_AIController(aObject.Controller) != None
&& aSubject != None;
}
*/