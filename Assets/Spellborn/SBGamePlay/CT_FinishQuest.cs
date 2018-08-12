using System;

namespace SBGamePlay
{
    [Serializable] public class CT_FinishQuest : CT_Quest
    {
        public CT_FinishQuest()
        {
        }
    }
}
/*
event bool sv_OnFinish(Game_Pawn aSpeaker,Game_Pawn aPartner) {
local export editinline Quest_Type quest;
quest = Quest_Type(Outer);                                                  
if (FinishQuest(aPartner,quest)) {                                          
return Super.sv_OnFinish(aSpeaker,aPartner);                              
} else {                                                                    
return False;                                                             
}
}
*/