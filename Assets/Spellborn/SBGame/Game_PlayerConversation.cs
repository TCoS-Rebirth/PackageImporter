﻿using System;

namespace SBGame
{
    [Serializable] public class Game_PlayerConversation : Game_Conversation
    {
        public Game_ConversationState Conversation;
    }
}
/*
final native function cl_RefreshTopics();
protected native function sv2cl_Banner_CallStub();
protected event sv2cl_Banner(Game_Pawn aSource,int aTopicID) {
local export editinline Conversation_Topic bannerTopic;
bannerTopic = Conversation_Topic(Class'SBDBSync'.GetResourceObject(aTopicID));
aSource.cl_Banner(GetPawn(),bannerTopic);                                   
}
protected native function sv2cl_EndConverse_CallStub();
protected event sv2cl_EndConverse(Game_Pawn aPartner) {
if (Conversation.partner == aPartner) {                                     
Game_NPCPawn(aPartner).ClientFocus = None;                                
Conversation = None;                                                      
Outer.GUI.HideDialogue();                                                 
}
}
protected native function sv2cl_Converse_CallStub();
protected event sv2cl_Converse(Game_Pawn aPartner,int aTopic,int aState,int aResponseFlags,array<int> aTopics) {
Conversation = new Class'Game_ConversationState';                           
Conversation.cl_Initialize(aPartner,aTopic,aState,aResponseFlags,aTopics);  
Outer.GUI.ShowDialogue(Conversation);                                       
Game_NPCPawn(aPartner).ClientFocus = GetPawn();                             
}
protected native function cl2sv_Respond_CallStub();
event cl2sv_Respond(int aResponseId) {
local export editinline Content_Type resptopic;
local export editinline Conversation_Response foundResponse;
local export editinline Conversation_Topic foundTopic;
if (aResponseId == 0) {                                                     
EndConversation(Conversation.partner);                                    
} else {                                                                    
resptopic = Content_Type(Class'SBDBSync'.GetResourceObject(aResponseId)); 
foundResponse = Conversation_Response(resptopic);                         
foundTopic = Conversation_Topic(resptopic);                               
if (foundResponse != None) {                                              
Response(Conversation.partner,foundResponse);                           
}
if (foundTopic != None) {                                                 
Topic(Conversation.partner,foundTopic);                                 
}
if (foundTopic == None && foundResponse == None) {                        
}
}
}
protected native function cl2sv_Interact_CallStub();
event cl2sv_Interact(Game_Pawn aTarget) {
Interact(aTarget);                                                          
}
protected native function cl2sv_React_CallStub();
event cl2sv_React(Game_Pawn aPawn) {
Game_Controller(aPawn.Controller).ConversationControl.OnReact(GetPawn());   
}
native function IsConversing();
event OnEndConversation(Game_Pawn aPartner) {
if (Conversation.partner != None
&& Conversation.partner == aPartner) {
sv2cl_EndConverse_CallStub(aPartner);                                     
Conversation = None;                                                      
Super.OnEndConversation(aPartner);                                        
}
}
event EndAllConversations() {
if (Conversation != None) {                                                 
sv2cl_EndConverse_CallStub(Conversation.partner);                         
EndConversation(Conversation.partner);                                    
Conversation = None;                                                      
}
}
function EndConversation(Game_Pawn aPartner) {
if (aPartner != None
&& aPartner == Conversation.partner) {           
sv2cl_EndConverse_CallStub(aPartner);                                     
Conversation = None;                                                      
Super.EndConversation(aPartner);                                          
}
}
event OnConversation(Game_Pawn aPartner,export editinline Conversation_Topic aTopic,export editinline Conversation_Node aState,array<Conversation_Response> aResponses,array<Conversation_Topic> aTopics) {
local int responseFlags;
local array<int> topicList;
Conversation = new Class'Game_ConversationState';                           
Conversation.partner = aPartner;                                            
Conversation.CurrentTopic = aTopic;                                         
Conversation.CurrentState = aState;                                         
Conversation.Responses = aResponses;                                        
Conversation.Topics = aTopics;                                              
responseFlags = Conversation.ConstructResponseFlags();                      
Conversation.ConstructTopicList(topicList);                                 
sv2cl_Converse_CallStub(aPartner,aTopic.GetResourceId(),aState.GetResourceId(),responseFlags,topicList);
Super.OnConversation(aPartner,aTopic,aState,aResponses,aTopics);            
}
function Banner(Game_Pawn aSource,export editinline Conversation_Topic aTopic) {
sv2cl_Banner_CallStub(aSource,aTopic.GetResourceId());                      
}
*/