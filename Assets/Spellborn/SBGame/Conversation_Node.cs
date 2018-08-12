using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class Conversation_Node : Content_Type
    {
        [FoldoutGroup("Text")]
        public LocalizedString Text;

        [FoldoutGroup("Results")]
        public List<Conversation_Response> Responses = new List<Conversation_Response>();

        [FoldoutGroup("Results")]
        public bool locked;

        [FoldoutGroup("Requirements")]
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();

        [FoldoutGroup("Events")]
        public List<Content_Event> Events = new List<Content_Event>();

        public Conversation_Node()
        {
        }
    }
}
/*
event bool sv_OnConversation(Game_Pawn aSpeaker,Game_Pawn aPartner) {
local int eventI;
eventI = 0;                                                                 
while (eventI < Events.Length) {                                            
if (Events[eventI] != None
&& !Events[eventI].sv_CanExecute(aSpeaker,aPartner)) {
return False;                                                           
}
eventI++;                                                                 
}
eventI = 0;                                                                 
while (eventI < Events.Length) {                                            
Events[eventI].sv_Execute(aSpeaker,aPartner);                             
eventI++;                                                                 
}
return True;                                                                
}
final native function bool CheckNode(export editinline Conversation_Topic aTopic,Game_Pawn aSpeaker,Game_Pawn aPartner);
function Render(export editinline Conversation_Topic aTopic,Game_Pawn aSpeaker,Game_Pawn aPartner,Object aRenderSlot) {
}
function string GetText() {
if (Len(Text.Text) > 0) {                                                   
return Text.Text;                                                         
} else {                                                                    
return "Empty Conversation";                                              
}
}
*/