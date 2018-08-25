using System;
using Engine;
using SBGame;

namespace SBGamePlay
{
    [Serializable] public class CT_Greeting : Conversation_Topic
    {
        public LocalizedString DefaultText;

        public CT_Greeting()
        {
        }
    }
}
/*
function string GetText() {
if (Len(TopicText.Text) != 0) {                                             
return Super.GetText();                                                   
} else {                                                                    
return DefaultText.Text;                                                  
}
}
*/