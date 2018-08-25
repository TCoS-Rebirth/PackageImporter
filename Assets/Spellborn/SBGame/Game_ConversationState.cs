using System;
using System.Collections.Generic;
using Engine;

namespace SBGame
{
    [Serializable] public class Game_ConversationState : UObject
    {
        [NonSerialized] public Game_Pawn partner;
        [NonSerialized] public Conversation_Topic CurrentTopic;
        [NonSerialized] public Conversation_Node CurrentState;
        [NonSerialized] public List<Conversation_Response> Responses = new List<Conversation_Response>();
        [NonSerialized] public List<Conversation_Topic> Topics = new List<Conversation_Topic>();
        [NonSerialized] public bool Failed;
    }
}
/*
function ConstructTopicList(out array<int> ret) {
local int ti;
ti = 0;                                                                     
while (ti < Topics.Length) {                                                
ret[ti] = Topics[ti].GetResourceId();                                     
ti++;                                                                     
}
}
function int ConstructResponseFlags() {
local int ret;
local int rii;
local int rio;
rii = 0;                                                                    
while (rii < Responses.Length) {                                            
rio = 0;                                                                  
while (rio < CurrentState.Responses.Length) {                             
if (CurrentState.Responses[rio] == Responses[rii]) {                    
ret = ret | 1 << rio;                                                 
goto jl007D;                                                          
}
rio++;                                                                  
}
rii++;                                                                    
}
return ret;                                                                 
}
function cl_Initialize(Game_Pawn aPartner,int aTopic,int aState,int aResponseFlags,array<int> aTopicList) {
local int rii;
local int rio;
local int ti;
partner = aPartner;                                                         
CurrentTopic = Conversation_Topic(Class'SBDBSync'.GetResourceObject(aTopic));
CurrentState = Conversation_Node(Class'SBDBSync'.GetResourceObject(aState));
rio = 0;                                                                    
Responses.Length = 0;                                                       
rii = 0;                                                                    
while (rii < CurrentState.Responses.Length) {                               
if ((aResponseFlags & 1 << rii) != 0) {                                   
Responses[rio] = CurrentState.Responses[rii];                           
rio++;                                                                  
}
rii++;                                                                    
}
Topics.Length = 0;                                                          
ti = 0;                                                                     
while (ti < aTopicList.Length) {                                            
Topics[ti] = Conversation_Topic(Class'SBDBSync'.GetResourceObject(aTopicList[ti]));
ti++;                                                                     
}
}
function sv_Initialize(Game_Pawn aSpeaker,Game_Pawn aPartner,export editinline Conversation_Topic aTopic,export editinline Conversation_Node aState) {
local int responseI;
local int topicI;
local array<Conversation_Topic> AvailableTopics;
partner = aPartner;                                                         
CurrentState = aState;                                                      
CurrentTopic = aTopic;                                                      
Failed = False;                                                             
Responses.Length = 0;                                                       
Topics.Length = 0;                                                          
responseI = 0;                                                              
while (responseI < CurrentState.Responses.Length) {                         
if (CurrentState.Responses[responseI].sv_Check(aTopic,aPartner,aSpeaker)) {
Responses[Responses.Length] = CurrentState.Responses[responseI];        
}
responseI++;                                                              
}
if (!CurrentState.locked) {                                                 
AvailableTopics.Length = 0;                                               
Game_Controller(aSpeaker.Controller).ConversationControl.GetAvailableTopics(AvailableTopics);
topicI = 0;                                                               
while (topicI < AvailableTopics.Length) {                                 
if (aTopic == None
|| aTopic.sv_FilterTopic(AvailableTopics[topicI])
&& AvailableTopics[topicI].CheckConversation(aSpeaker,aPartner) != None) {
Topics[Topics.Length] = AvailableTopics[topicI];                      
}
topicI++;                                                               
}
}
}
*/