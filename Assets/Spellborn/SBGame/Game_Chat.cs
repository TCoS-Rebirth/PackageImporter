using System;
using SBBase;

namespace SBGame
{
    [Serializable] public class Game_Chat : Base_Component
    {
        public const int MAX_CHAT_MESSAGE_LENGTH = 256;

        //public delegate<OnChatMessageReceived> @__OnChatMessageReceived__Delegate;

        //public delegate<OnBeginChatMessageEntry> @__OnBeginChatMessageEntry__Delegate;

        //public delegate<OnBeginSlashChatMessageEntry> @__OnBeginSlashChatMessageEntry__Delegate;

        public Game_Chat()
        {
        }

        public enum EGameChatRanges
        {
            GCR_LOCAL,

            GCR_WORLD,

            GCR_TRADE,

            GCR_TEAM,

            GCR_GUILD,

            GCR_PRIVATE,

            GCR_COMBAT,

            GCR_SYSTEM,

            GCR_BROADCAST,
        }
    }
}
/*
protected native function sv2cl_SendOnScreenMessage_CallStub();
event sv2cl_SendOnScreenMessage(int aLocalizedStringID,optional Color aColor) {
local string lMessage;
lMessage = Class'SBDBSync'.GetDescription(aLocalizedStringID);              
if (lMessage != "") {                                                       
Outer.Player.GUIDesktop.AddScreenMessage(lMessage,aColor);                
goto jl0054;                                                              
}
}
exec function SlashChatMessage() {
if (Outer.GUI.ChatHandle == 0) {                                            
Outer.GUI.ShowChat();                                                     
}
OnBeginSlashChatMessageEntry();                                             
}
exec function EnterChatMessage(optional string aMessage) {
if (Outer.GUI.ChatHandle == 0) {                                            
Outer.GUI.ShowChat();                                                     
}
OnBeginChatMessageEntry(aMessage);                                          
}
function cl_OnMessage(string aSender,string aMessage,int aChannel) {
if (!Outer.GroupingFriends.IsIgnoringName(aSender)) {                       
Game_Desktop(Outer.Player.GUIDesktop).AddMessage(aSender,aMessage,aChannel);
}
}
function cl_NPCMessage(string aSender,string aMessage) {
cl_OnMessage(aSender,aMessage,Class'Game_Desktop'.0);                       
}
protected native function sv2cl_OnMessage_CallStub();
event sv2cl_OnMessage(string aSender,string aMessage,int aChannel) {
cl_OnMessage(aSender,aMessage,aChannel);                                    
}
native function SendMessageToUniverse(byte aRange,int aSenderID,string aReceiver,string aMessage);
protected native function cl2sv_SendMessage_CallStub();
private event cl2sv_SendMessage(byte aRange,string aReceiver,string aMessage) {
local Game_PlayerController PlayerController;
local bool isMe;
if (Game_Pawn(Outer.Pawn).IsMuted(aRange)) {                                
sv2cl_OnMessage_CallStub("","You are muted on this channel!",0);          
return;                                                                   
}
aMessage = Left(aMessage,256);                                              
LogChatMessage(Outer.AccountID,Game_Pawn(Outer.Pawn).Character.sv_GetName(),aMessage);
isMe = StrCmp(aMessage,"/me",3,False) == 0;                                 
if (isMe) {                                                                 
aMessage = Right(aMessage,Len(aMessage) - 3);                             
}
switch (aRange) {                                                           
case 0 :                                                                  
Game_PlayerPawn(Outer.Pawn).sv2rel_SendMessage_CallStub(Game_PlayerPawn(Outer.Pawn).Character.sv_GetName(),aMessage,Class'Game_Desktop'.0);
break;                                                                  
case 1 :                                                                  
foreach Outer.AllActors(Class'Game_PlayerController',PlayerController,'None') {
if (PlayerController != Game_PlayerPawn(Outer.Pawn).Controller) {     
PlayerController.Chat.sv2cl_OnMessage_CallStub(Game_Pawn(Outer.Pawn).Character.sv_GetName(),aMessage,Class'Game_Desktop'.1);
}
}
goto jl02E9;                                                              
case 2 :                                                                    
foreach Outer.AllActors(Class'Game_PlayerController',PlayerController,'None') {
if (PlayerController != Game_PlayerPawn(Outer.Pawn).Controller) {       
PlayerController.Chat.sv2cl_OnMessage_CallStub(Game_Pawn(Outer.Pawn).Character.sv_GetName(),aMessage,Class'Game_Desktop'.2);
}
}
goto jl02E9;                                                              
case 3 :                                                                    
case 4 :                                                                    
SendMessageToUniverse(aRange,Game_PlayerPawn(Outer.Pawn).GetCharacterID(),"",aMessage);
goto jl02E9;                                                              
case 5 :                                                                    
SendMessageToUniverse(5,Game_PlayerPawn(Outer.Pawn).GetCharacterID(),aReceiver,aMessage);
goto jl02E9;                                                              
default:                                                                    
}
}
event cl_SendMessageTo(byte aRange,string aReceiver,string aMessage) {
cl2sv_SendMessage_CallStub(aRange,aReceiver,aMessage);                      
}
event cl_SendMessage(byte aRange,string aMessage) {
cl2sv_SendMessage_CallStub(aRange,"",aMessage);                             
}
native function LogChatMessage(int aAccountID,string aCharacterName,string aMessage);
delegate OnBeginSlashChatMessageEntry();
delegate OnBeginChatMessageEntry(optional string aMessage);
delegate OnChatMessageReceived(byte aRange,string aSender,string aMessage,optional bool me);
*/