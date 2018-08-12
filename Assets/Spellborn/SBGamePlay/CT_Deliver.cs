using System;

namespace SBGamePlay
{
    [Serializable] public class CT_Deliver : CT_Target
    {
        public CT_Deliver()
        {
        }
    }
}
/*
event bool sv_OnFinish(Game_Pawn aSpeaker,Game_Pawn aPartner) {
local export editinline Quest_Type quest;
local export editinline QT_Deliver Target;
Target = QT_Deliver(Outer);                                                 
quest = Quest_Type(Target.Outer);                                           
if (Game_PlayerPawn(aPartner).questLog.sv_SetTargetAsCompleted(Target,aSpeaker)) {
return Super.sv_OnFinish(aSpeaker,aPartner);                              
} else {                                                                    
return False;                                                             
}
}
*/