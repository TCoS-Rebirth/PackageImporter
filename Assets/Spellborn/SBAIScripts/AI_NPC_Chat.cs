﻿using System;
using System.Collections.Generic;
using Engine;
using SBGame;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBAIScripts
{
    [Serializable] public class AI_NPC_Chat : AIRegistered
    {
        [FoldoutGroup("Chat")]
        [FieldConst()]
        public List<ChatMessage> ChatMessages = new List<ChatMessage>();

        [FieldConst()]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool OneMessagePerTrigger;

        [FoldoutGroup("Chat")]
        [FieldConst()]
        public bool ChatNPCsInvulnerable;

        [FoldoutGroup("Chat")]
        [FieldConst()]
        public bool PauseAIWhileChatting;

        [FoldoutGroup("Chat")]
        [FieldConst()]
        public byte ChatMode;

        [FoldoutGroup("Chat")]
        [FieldConst()]
        public bool WaitForEachChat;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int mMessageIndex;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private float mMessageTimeout;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private Pawn mInstigator;

        public AI_NPC_Chat()
        {
        }

        [Serializable] public struct ChatMessage
        {
            public NPC_Type ChatNPC;

            public NPC_Type ChatTarget;

            public bool ChatNPCRandom;

            public bool ChatTargetInstigator;

            public LocalizedString Message;

            public byte Emote;

            public float WaitTime;

            public string Event;

            public RegisteredChatNPC RegChatNPC;
        }

        public enum EChatMode
        {
            CM_CONTINUOUS,

            CM_ONE_MESSAGE_PER_TRIGGER,

            CM_RANDOM_MESSAGE_PER_TRIGGER,

            CM_LOOP,
        }
    }
}
/*
event UnTrigger(Actor Other,Pawn EventInstigator) {
Debug("Reset by" @ string(EventInstigator));                                
GotoState('InitializedState');                                              
}
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local int i;
Super.GetActorRelations(oRelations);                                        
i = 0;                                                                      
while (i < ChatMessages.Length) {                                           
GetTaggedRelations(ChatMessages[i].Event,static.RGB(100,100,255),"ChatEvent:" @ ChatMessages[i].Event,oRelations);
i++;                                                                      
}
}
protected function OnUnRegister(RegisteredAI aRegisteredAI) {
local int mi;
mi = 0;                                                                     
while (mi < ChatMessages.Length) {                                          
if (ChatMessages[mi].RegChatNPC == aRegisteredAI) {                       
Debug("removed" @ string(aRegisteredAI)
@ "from message"
@ string(mi));
ChatMessages[mi].RegChatNPC = None;                                     
}
mi++;                                                                     
}
}
function FinishChat() {
local int mi;
local Game_AIController chatController;
Debug("Finished chat");                                                     
if (ChatMode != 1
|| mMessageIndex >= ChatMessages.Length) {          
mMessageIndex = 0;                                                        
}
mi = 0;                                                                     
while (mi < ChatMessages.Length) {                                          
if (ChatMessages[mi].RegChatNPC != None) {                                
chatController = ChatMessages[mi].RegChatNPC.Controller;                
ChatMessages[mi].RegChatNPC.Initialized = False;                        
if (ChatNPCsInvulnerable) {                                             
SetInvulnerable(chatController,ChatMessages[mi].RegChatNPC.WasInVulnerable);
Debug("restoring vulnerability for:"
@ string(ChatMessages[mi].ChatNPC)
@ "to"
@ string(ChatMessages[mi].RegChatNPC.WasInVulnerable));
}
if (HasPausedAI(chatController)) {                                      
ContinueAI(chatController);                                           
}
ChatMessages[mi].RegChatNPC = None;                                     
}
mi++;                                                                     
}
TriggerEvent(Event,self,None);                                              
ChangeAllToNextScript(mInstigator);                                         
mInstigator = None;                                                         
GotoState('InitializedState');                                              
}
function PlayChatMessage() {
local Game_Pawn targetPawn;
local Game_AIController chatController;
if (ChatMode == 2) {                                                        
mMessageIndex = Rand(ChatMessages.Length);                                
}
mMessageTimeout = ChatMessages[mMessageIndex].WaitTime;                     
TriggerEvent(name(ChatMessages[mMessageIndex].Event),self,ChatMessages[mMessageIndex].RegChatNPC.Controller.Pawn);
if (ChatMessages[mMessageIndex].RegChatNPC != None) {                       
Debug("" $ string(mMessageIndex) $ ">"
@ string(ChatMessages[mMessageIndex].RegChatNPC));
chatController = ChatMessages[mMessageIndex].RegChatNPC.Controller;       
if (ChatMessages[mMessageIndex].ChatTargetInstigator
&& mInstigator != None) {
targetPawn = Game_Pawn(mInstigator);                                    
} else {                                                                  
if (ChatMessages[mMessageIndex].ChatTarget != None) {                   
targetPawn = GetNPC(ChatMessages[mMessageIndex].ChatTarget);          
}
}
if (PauseAIWhileChatting && !HasPausedAI(chatController)) {               
PauseAI(chatController);                                                
if (targetPawn != None) {                                               
LookAt(chatController,targetPawn.Location);                           
}
}
if (ChatNPCsInvulnerable) {                                               
ChatMessages[mMessageIndex].RegChatNPC.WasInVulnerable = GetInvulnerable(chatController);
SetInvulnerable(chatController,True);                                   
}
if (ChatMessages[mMessageIndex].Message.Id > 0) {                         
LocalizedChat(chatController,ChatMessages[mMessageIndex].Message,,targetPawn);
}
if (ChatMessages[mMessageIndex].Emote > 0) {                              
PerformEmote(chatController,ChatMessages[mMessageIndex].Emote);         
}
} else {                                                                    
Debug("No registered NPC found for chat message"
@ string(mMessageIndex));
}
GotoState('ChattingState');                                                 
}
state WaitingState {
protected function OnRegisterEmptied() {
GotoState('WaitForParticipantsState');                                  
}
event bool AnnotationDone(Game_AIController aController) {
return WaitForEachChat;                                                 
}
event Trigger(Actor Other,Pawn EventInstigator) {
mInstigator = EventInstigator;                                          
Debug("triggered while waiting by" @ string(mInstigator));              
PlayChatMessage();                                                      
}
}
state ChattingState {
protected function OnRegisterEmptied() {
GotoState('WaitForParticipantsState');                                  
}
event bool AnnotationDone(Game_AIController aController) {
return False;                                                           
}
protected event sv_OnScriptFrame(float DeltaTime) {
mMessageTimeout -= DeltaTime;                                           
if (mMessageTimeout <= 0) {                                             
++mMessageIndex;                                                      
if (ChatMode == 2
|| mMessageIndex >= ChatMessages.Length) {
if (ChatMode == 3) {                                                
mMessageIndex = 0;                                                
PlayChatMessage();                                                
} else {                                                            
FinishChat();                                                     
}
} else {                                                              
if (ChatMode == 1) {                                                
GotoState('WaitingState');                                        
} else {                                                            
PlayChatMessage();                                                
}
}
}
}
}
state WaitForParticipantsState {
function bool InitChat() {
local int i;
local int mi;
local array<RegisteredAI> Register;
local RegisteredChatNPC selectedChatNPC;
local bool foundNPC;
Register = GetRegister();                                               
mi = 0;                                                                 
while (mi < ChatMessages.Length) {                                      
Debug("finding NPCs for message[Sirenix.OdinInspector.FoldoutGroup(" $ string(mi)
$ " of "
$ string(ChatMessages.Length)
$ "]");
foundNPC = False;                                                     
if (ChatMessages[mi].ChatNPCRandom) {                                 
Debug("  looking for [RANDOM] npc");                                
selectedChatNPC = RegisteredChatNPC(GetRandomRegistered());         
if (selectedChatNPC != None) {                                      
foundNPC = True;                                                  
}
} else {                                                              
Debug("  looking in the [REGISTER] for npc");                       
i = 0;                                                              
while (i < Register.Length) {                                       
if (ChatMessages[mi].ChatNPC != None
&& Game_NPCPawn(Register[i].Controller.Pawn).NPCType == ChatMessages[mi].ChatNPC) {
selectedChatNPC = RegisteredChatNPC(Register[i]);               
foundNPC = True;                                                
goto jl018E;                                                    
}
i++;                                                              
}
}
if (foundNPC) {                                                       
ChatMessages[mi].RegChatNPC = selectedChatNPC;                      
Debug("  +++ found"
@ string(Game_NPCPawn(selectedChatNPC.Controller.Pawn).NPCType));
} else {                                                              
if (ChatMessages[mi].ChatNPC != None
&& !ChatMessages[mi].ChatNPCRandom) {
Warning("  --- Chat NPC"
@ string(ChatMessages[mi].ChatNPC)
@ "not found!!!");
return False;                                                     
}
}
mi++;                                                                 
}
return True;                                                            
}
protected function OnRegister(RegisteredAI aRegisteredAI) {
if (InitChat()) {                                                       
PlayChatMessage();                                                    
}
}
function BeginState() {
if (InitChat()) {                                                       
PlayChatMessage();                                                    
}
}
}
auto state InitializedState {
event Trigger(Actor Other,Pawn EventInstigator) {
mInstigator = EventInstigator;                                          
Debug("Chat started by" @ string(mInstigator));                         
GotoState('WaitForParticipantsState');                                  
}
function BeginState() {
mMessageIndex = 0;                                                      
mMessageTimeout = 0.00000000;                                           
mInstigator = None;                                                     
}
}
*/