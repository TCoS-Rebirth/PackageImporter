﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using SBGame;


namespace SBGamePlay
{


    public class CR_Decline : Conversation_Response
    {
        
        public CR_Decline()
        {
        }
    }
}
/*
event bool sv_OnResponse(Game_Pawn aSpeaker,Game_Pawn aPartner) {
if (Super.sv_OnResponse(aSpeaker,aPartner)) {                               
Game_Controller(aSpeaker.Controller).ConversationControl.FailConversation(aPartner);
return True;                                                              
} else {                                                                    
return False;                                                             
}
}
function string GetText() {
return Class'SBDBSync'.GetDescription(1102871635);                          
}
*/
