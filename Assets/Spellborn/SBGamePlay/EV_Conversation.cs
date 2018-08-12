using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_Conversation : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public Conversation_Topic Conversation;

        public EV_Conversation()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
local Game_Controller cont;
local export editinline Conversation_Node Start;
cont = Game_Controller(aObject.Controller);                                 
Start = Conversation.CheckConversation(aObject,aSubject);                   
cont.ConversationControl.Converse(aSubject,Conversation,Start);             
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
local Game_Controller cont;
local export editinline Conversation_Node Start;
cont = Game_Controller(aObject.Controller);                                 
if (cont != None) {                                                         
if (cont.ConversationControl.CanConverse(aSubject)) {                     
Start = Conversation.CheckConversation(aObject,aSubject);               
if (Start != None) {                                                    
return True;                                                          
}
}
}
return False;                                                               
}
*/