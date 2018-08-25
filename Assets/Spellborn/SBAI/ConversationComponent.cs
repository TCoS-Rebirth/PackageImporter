﻿using System;
using System.Collections.Generic;
using SBGame;

namespace SBAI
{
    [Serializable] public class ConversationComponent : Game_Conversation
    {
        public bool mEnabled;

        public List<Game_ConversationState> mConversations = new List<Game_ConversationState>();

        public List<Game_Pawn> mQueuedConversations = new List<Game_Pawn>();

        public ConversationComponent()
        {
        }
    }
}
/*
event OnFailConversation(Game_Pawn aPartner) {
local Game_ConversationState convState;
Super.OnFailConversation(aPartner);                                         
convState = FindConversation(aPartner);                                     
convState.Failed = True;                                                    
}
function FailConversation(Game_Pawn aPartner) {
local Game_ConversationState convState;
Super.FailConversation(aPartner);                                           
convState = FindConversation(aPartner);                                     
convState.Failed = True;                                                    
}
event OnEndConversation(Game_Pawn aPartner) {
local int confFound;
confFound = FindConversationIndex(aPartner);                                
if (confFound == -1) {                                                      
} else {                                                                    
if (!Outer.MetaControllerMessage(25,aPartner)) {                          
}
Super.OnEndConversation(aPartner);                                        
mConversations.Remove(confFound,1);                                       
Outer.StateSignal(17);                                                    
}
}
event EndAllConversations() {
local int convI;
convI = 0;                                                                  
while (convI < mConversations.Length) {                                     
StopConversation(mConversations[convI].partner);                          
convI++;                                                                  
}
mConversations.Remove(0,mConversations.Length);                             
mQueuedConversations.Remove(0,mQueuedConversations.Length);                 
}
event EndConversation(Game_Pawn aPartner) {
local int confFound;
confFound = FindConversationIndex(aPartner);                                
if (confFound == -1) {                                                      
} else {                                                                    
if (!Outer.MetaControllerMessage(25,aPartner)) {                          
}
StopConversation(aPartner);                                               
mConversations.Remove(confFound,1);                                       
Outer.StateSignal(17);                                                    
}
}
function OnTopic(Game_Pawn aPartner,export editinline Conversation_Topic aTopic) {
local bool topicFound;
local int topicI;
local Game_ConversationState convState;
convState = FindConversation(aPartner);                                     
if (convState == None) {                                                    
EndConversation(aPartner);                                                
return;                                                                   
}
topicFound = False;                                                         
topicI = 0;                                                                 
while (topicI < convState.Topics.Length) {                                  
if (convState.Topics[topicI] == aTopic) {                                 
topicFound = True;                                                      
goto jl0084;                                                            
}
topicI++;                                                                 
}
if (!topicFound) {                                                          
EndConversation(aPartner);                                                
return;                                                                   
}
aTopic.sv_Start(Outer.GetNPCPawn(),aPartner);                               
}
function OnResponse(Game_Pawn aPartner,export editinline Conversation_Response aResponse) {
local int responseI;
local bool responseFound;
local Game_ConversationState convState;
local export editinline Conversation_Node nextState;
convState = FindConversation(aPartner);                                     
if (convState == None) {                                                    
EndConversation(aPartner);                                                
return;                                                                   
}
responseFound = False;                                                      
responseI = 0;                                                              
while (responseI < convState.CurrentState.Responses.Length) {               
if (convState.Responses[responseI] == aResponse) {                        
responseFound = True;                                                   
goto jl008D;                                                            
}
responseI++;                                                              
}
if (!responseFound) {                                                       
EndConversation(aPartner);                                                
} else {                                                                    
aResponse.sv_OnResponse(aPartner,Outer.GetNPCPawn());                     
if (!convState.Failed) {                                                  
if (aResponse.Conversations.Length == 0) {                              
convState.CurrentTopic.sv_OnFinish(GetPawn(),aPartner);               
EndConversation(aPartner);                                            
} else {                                                                
nextState = aResponse.sv_SelectConversation(convState.CurrentTopic,Outer.GetNPCPawn(),aPartner);
if (nextState != None) {                                              
Converse(aPartner,convState.CurrentTopic,nextState);                
} else {                                                              
if (convState.CurrentState.Responses[responseI].Conversations.Length > 0) {
}
EndConversation(aPartner);                                          
}
}
} else {                                                                  
EndConversation(aPartner);                                              
}
}
}
function Converse(Game_Pawn aPartner,export editinline Conversation_Topic aTopic,export editinline Conversation_Node aState) {
local int convI;
local Game_ConversationState convState;
if (aState != None) {                                                       
convState = FindConversation(aPartner);                                   
if (convState == None) {                                                  
convI = mConversations.Length;                                          
convState = new Class'Game_ConversationState';                          
mConversations[convI] = convState;                                      
}
convState.sv_Initialize(Outer.GetNPCPawn(),aPartner,aTopic,aState);       
aState.sv_OnConversation(Outer.GetNPCPawn(),aPartner);                    
if (!convState.Failed) {                                                  
if (aState.Responses.Length == 0) {                                     
aTopic.sv_OnFinish(GetPawn(),aPartner);                               
}
convState.sv_Initialize(Outer.GetNPCPawn(),aPartner,aTopic,aState);     
Game_Controller(aPartner.Controller).ConversationControl.OnConversation(GetPawn(),convState.CurrentTopic,convState.CurrentState,convState.Responses,convState.Topics);
} else {                                                                  
EndConversation(aPartner);                                              
}
Super.Converse(convState.partner,convState.CurrentTopic,convState.CurrentState);
} else {                                                                    
EndConversation(aPartner);                                                
}
}
event OnInteraction(Game_Pawn aSource) {
if (!Outer.MetaControllerMessage(15,aSource,)) {                            
if (CanConverse(aSource)) {                                               
Outer.StateSignal(16);                                                  
if (mEnabled) {                                                         
StartConversation(aSource);                                           
} else {                                                                
QueueConversation(aSource);                                           
}
}
Super.OnInteraction(aSource);                                             
}
}
event OnReact(Game_Pawn aSource) {
local Game_Controller partnerController;
local export editinline Conversation_Topic bestTopic;
partnerController = Game_Controller(aSource.Controller);                    
if (partnerController != None) {                                            
bestTopic = ChooseTopic(aSource);                                         
if (bestTopic != None) {                                                  
partnerController.ConversationControl.Banner(GetPawn(),bestTopic);      
}
}
Super.OnReact(aSource);                                                     
}
protected event StopConversation(Game_Pawn aPawn) {
EndConversation(aPawn);                                                     
}
protected event StartConversation(Game_Pawn aPawn) {
local export editinline Conversation_Topic bestTopic;
Game_Controller(aPawn.Controller).sv_FireHook(Class'Content_Type'.4,Outer.Pawn,0);
bestTopic = ChooseTopic(aPawn);                                             
if (bestTopic != None) {                                                    
bestTopic.sv_Start(GetPawn(),aPawn);                                      
}
}
protected function QueueConversation(Game_Pawn aPawn) {
local int qi;
qi = 0;                                                                     
while (qi < mQueuedConversations.Length) {                                  
if (mQueuedConversations[qi] == aPawn) {                                  
return;                                                                 
}
qi++;                                                                     
}
mQueuedConversations[mQueuedConversations.Length] = aPawn;                  
}
function int FindConversationIndex(Game_Pawn aPartner) {
local int confFound;
local int convI;
confFound = -1;                                                             
convI = 0;                                                                  
while (convI < mConversations.Length) {                                     
if (mConversations[convI].partner == aPartner) {                          
return convI;                                                           
}
convI++;                                                                  
}
return -1;                                                                  
}
function Game_ConversationState FindConversation(Game_Pawn aPartner) {
local int convI;
local Game_PlayerPawn playerPawn;
playerPawn = Game_PlayerPawn(aPartner);                                     
if (playerPawn == None) {                                                   
return None;                                                              
}
convI = 0;                                                                  
while (convI < mConversations.Length) {                                     
if (mConversations[convI].partner == aPartner) {                          
return mConversations[convI];                                           
}
convI++;                                                                  
}
return None;                                                                
}
native function GetAvailableTopics(out array<Conversation_Topic> ret);
*/