using System;
using SBBase;

namespace SBGame
{
    [Serializable] public class Game_Conversation : Base_Component
    {
        public Game_Conversation()
        {
        }
    }
}
/*
protected function Game_Pawn GetPawn() {
return Game_Pawn(Outer.Pawn);                                               
}
event OnFailConversation(Game_Pawn aPartner) {
}
function FailConversation(Game_Pawn aPartner) {
local Game_Controller partnerController;
partnerController = Game_Controller(aPartner.Controller);                   
partnerController.ConversationControl.OnFailConversation(GetPawn());        
}
event OnEndConversation(Game_Pawn aPartner) {
}
event EndAllConversations() {
}
event EndConversation(Game_Pawn aPartner) {
local Game_Controller partnerController;
partnerController = Game_Controller(aPartner.Controller);                   
partnerController.ConversationControl.OnEndConversation(GetPawn());         
}
event OnTopic(Game_Pawn aPartner,export editinline Conversation_Topic aTopic) {
}
function Topic(Game_Pawn aPartner,export editinline Conversation_Topic aTopic) {
local Game_Controller partnerController;
partnerController = Game_Controller(aPartner.Controller);                   
partnerController.ConversationControl.OnTopic(GetPawn(),aTopic);            
}
event OnResponse(Game_Pawn aPartner,export editinline Conversation_Response aResponse) {
}
function Response(Game_Pawn aPartner,export editinline Conversation_Response aResponse) {
local Game_Controller partnerController;
partnerController = Game_Controller(aPartner.Controller);                   
partnerController.ConversationControl.OnResponse(GetPawn(),aResponse);      
}
event OnConversation(Game_Pawn aPartner,export editinline Conversation_Topic aTopic,export editinline Conversation_Node aState,array<Conversation_Response> aResponses,array<Conversation_Topic> aTopics) {
}
function Converse(Game_Pawn aPartner,export editinline Conversation_Topic aTopic,export editinline Conversation_Node aState) {
}
event OnInteraction(Game_Pawn aSource) {
}
function Interact(Game_Pawn aTarget) {
local Game_Controller targetController;
targetController = Game_Controller(aTarget.Controller);                     
targetController.ConversationControl.OnInteraction(GetPawn());              
}
function Banner(Game_Pawn aTarget,export editinline Conversation_Topic aTopic) {
}
event OnReact(Game_Pawn aSource) {
}
event GetAvailableTopics(out array<Conversation_Topic> ret) {
}
final native function Conversation_Topic ChooseTopic(Game_Pawn aPartner);
final native function bool CanConverse(Game_Pawn aPartner);
*/