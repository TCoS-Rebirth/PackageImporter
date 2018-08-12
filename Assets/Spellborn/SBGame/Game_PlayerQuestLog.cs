using System;

namespace SBGame
{
    [Serializable] public class Game_PlayerQuestLog : Game_QuestLog
    {
        public Game_PlayerQuestLog()
        {
        }
    }
}
/*
protected event bool sv_CheckQuest(export editinline Quest_Type aQuest) {
return aQuest.CheckPawn(Outer);                                             
}
protected native function sv2cl_SetTargetProgress_CallStub();
protected event sv2cl_SetTargetProgress(int aQuestID,int TargetNr,int aProgress) {
local export editinline Quest_Type quest;
quest = Quest_Type(Class'SBDBSync'.GetResourceObject(aQuestID));            
if (quest == None) {                                                        
} else {                                                                    
SetTargetProgress(quest,TargetNr,aProgress);                              
ComputeTargetActivation(quest);                                           
Game_PlayerConversation(Game_Controller(Outer.Controller).ConversationControl).cl_RefreshTopics();
}
}
protected native function sv2cl_RemoveQuest_CallStub();
event sv2cl_RemoveQuest(int aQuestID) {
local export editinline Quest_Type quest;
quest = Quest_Type(Class'SBDBSync'.GetResourceObject(aQuestID));            
if (quest == None) {                                                        
} else {                                                                    
RemoveQuest(quest);                                                       
Game_PlayerConversation(Game_Controller(Outer.Controller).ConversationControl).cl_RefreshTopics();
}
}
protected function cl_CompleteQuest(int aQuestID) {
local export editinline Quest_Type quest;
quest = Quest_Type(Class'SBDBSync'.GetResourceObject(aQuestID));            
if (quest == None) {                                                        
} else {                                                                    
RemoveQuest(quest);                                                       
AddCompletedQuest(quest);                                                 
Game_PlayerConversation(Game_Controller(Outer.Controller).ConversationControl).cl_RefreshTopics();
}
}
protected native function sv2cl_CompleteQuest_CallStub();
protected event sv2cl_CompleteQuest(int aQuestID) {
cl_CompleteQuest(aQuestID);                                                 
}
protected function cl_AddQuest(int aQuestID,array<int> aProgress) {
local export editinline Quest_Type quest;
quest = Quest_Type(Class'SBDBSync'.GetResourceObject(aQuestID));            
if (quest == None) {                                                        
} else {                                                                    
AddQuest(quest,aProgress);                                                
Game_PlayerConversation(Game_Controller(Outer.Controller).ConversationControl).cl_RefreshTopics();
}
}
protected native function sv2cl_AddQuest_CallStub();
protected event sv2cl_AddQuest(int aQuestID,array<int> aProgress) {
cl_AddQuest(aQuestID,aProgress);                                            
}
protected native function sv2cl_FinishQuest_CallStub();
protected event sv2cl_FinishQuest(int aQuestID) {
cl_CompleteQuest(aQuestID);                                                 
OnFinishQuest(aQuestID);                                                    
}
protected native function sv2cl_AcceptQuest_CallStub();
protected event sv2cl_AcceptQuest(int aQuestID,array<int> aProgress) {
cl_AddQuest(aQuestID,aProgress);                                            
OnAcceptQuest(aQuestID);                                                    
}
native function CheckMailQuests();
protected native function cl2sv_SwirlyOption_CallStub();
event cl2sv_SwirlyOption(byte aMainOption,byte aSubOption) {
Game_Controller(Outer.Controller).sv_FireHook(3,None,aMainOption << 16 | aSubOption);
}
protected native function cl2sv_SwirlyOptionPawn_CallStub();
event cl2sv_SwirlyOptionPawn(Game_Pawn aPawn,byte aMainOption,byte aSubOption) {
Game_Controller(Outer.Controller).sv_FireHook(3,Game_NPCPawn(aPawn),aMainOption << 16 | aSubOption);
}
protected native function cl2sv_AbandonQuest_CallStub();
event cl2sv_AbandonQuest(int aQuestID) {
local export editinline Quest_Type quest;
quest = Quest_Type(Class'SBDBSync'.GetResourceObject(aQuestID));            
if (quest != None) {                                                        
if (!sv_AbandonQuest(quest)) {                                            
}
goto jl003D;                                                              
}
}
function cl_OnInit() {
Super.cl_OnInit();                                                          
Init();                                                                     
Game_PlayerConversation(Game_PlayerController(Outer.Controller).ConversationControl).cl_RefreshTopics();
}
private final native function Init();
*/