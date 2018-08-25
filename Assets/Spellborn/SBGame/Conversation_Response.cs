using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class Conversation_Response : Content_Type
    {
        [FoldoutGroup("Text")]
        public LocalizedString Text;

        [FoldoutGroup("Results")]
        public List<Conversation_Node> Conversations = new List<Conversation_Node>();

        [FoldoutGroup("Requirements")]
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();

        [FoldoutGroup("Events")]
        public List<Content_Event> Events = new List<Content_Event>();

        [FoldoutGroup("Text")]
        public int ButtonImage;

        public Conversation_Response()
        {
        }
    }
}
/*
function Conversation_Node sv_SelectConversation(export editinline Conversation_Topic aTopic,Game_Pawn aSpeaker,Game_Pawn aPartner) {
local export editinline Conversation_Node Node;
local int convI;
convI = 0;                                                                  
while (convI < Conversations.Length) {                                      
Node = Conversations[convI];                                              
if (Node.CheckNode(aTopic,aSpeaker,aPartner)) {                           
return Node;                                                            
}
convI++;                                                                  
}
return None;                                                                
}
event bool sv_OnResponse(Game_Pawn aSpeaker,Game_Pawn aPartner) {
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
function string GetText() {
if (Len(Text.Text) > 0) {                                                   
return Text.Text;                                                         
} else {                                                                    
return "Empty Response";                                                  
}
}
event bool sv_Check(export editinline Conversation_Topic aTopic,Game_Pawn aSpeaker,Game_Pawn aPartner) {
local int reqI;
reqI = 0;                                                                   
while (reqI < Requirements.Length) {                                        
if (Requirements[reqI] != None
&& !Requirements[reqI].CheckPawn(aSpeaker)) {
return False;                                                           
}
reqI++;                                                                   
}
return True;                                                                
}
*/