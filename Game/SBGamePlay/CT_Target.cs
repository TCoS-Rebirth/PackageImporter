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


    public class CT_Target : Conversation_Topic
    {
        
        public CT_Target()
        {
        }
    }
}
/*
function Content_Type GetContext() {
return Quest_Type(Outer.Outer);                                             
}
function string GetText() {
local export editinline Quest_Type quest;
quest = Quest_Type(GetContext());                                           
if (Len(TopicText.Text) != 0) {                                             
return Super.GetText();                                                   
} else {                                                                    
return quest.GetName();                                                   
}
}
*/