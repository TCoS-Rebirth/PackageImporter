using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class CT_ProvideQuest : CT_Quest
    {
        [FoldoutGroup("CT_ProvideQuest")]
        public Conversation_Response Accept;

        [FoldoutGroup("CT_ProvideQuest")]
        public Conversation_Response Decline;

        public CT_ProvideQuest()
        {
        }
    }
}
/*
event bool sv_OnFinish(Game_Pawn aSpeaker,Game_Pawn aPartner) {
local export editinline Quest_Type quest;
quest = Quest_Type(Outer);                                                  
if (ObtainQuest(aPartner,quest)) {                                          
return Super.sv_OnFinish(aSpeaker,aPartner);                              
} else {                                                                    
return False;                                                             
}
}
*/