﻿using System;

namespace SBGame
{
#pragma warning disable 414   

    [Serializable] public class Game_PlayerCharacter : Game_Character
    {
        private string mName = string.Empty;
        private int mMoney;
        private string mGuildName = string.Empty;

        [NonSerialized] public EventNotification mMoneyChanged;

        public override void WriteLoginStream(IPacketWriter writer)
        {
            //writer.Write()
        }
    }
}
/*
protected event cl_SetFaction(int aFactionId) {
local Game_Controller gc;
Super.cl_SetFaction(aFactionId);                                            
if (Outer.IsLocalPlayer() && Outer.Controller != None) {                    
gc = Game_Controller(Outer.Controller);                                   
if (gc != None && gc.ConversationControl != None) {                       
Game_PlayerConversation(gc.ConversationControl).cl_RefreshTopics();     
}
}
}
function string cl_GetBaseFullName() {
return mName;                                                               
}
event string cl_GetBaseName() {
return mName;                                                               
}
function string GetGuildName() {
return mGuildName;                                                          
}
protected native function sv2clrel_UpdateGuildName_CallStub();
event sv2clrel_UpdateGuildName(string aGuildName) {
mGuildName = aGuildName;                                                    
}
event sv_SetGuildName(string aGuildName) {
mGuildName = aGuildName;                                                    
sv2clrel_UpdateGuildName_CallStub(mGuildName);                              
}
event sv_SetFaction(export editinline NPC_Taxonomy aFaction) {
Super.sv_SetFaction(aFaction);                                              
if (mFaction != None) {                                                     
sv2clrel_SetFaction_CallStub(mFaction.GetResourceId());                   
Class'SBDBAsync'.SetCharacterFaction(Outer,Outer.GetCharacterID(),mFaction.GetResourceId());
} else {                                                                    
sv2clrel_SetFaction_CallStub(0);                                          
Class'SBDBAsync'.SetCharacterFaction(Outer,Outer.GetCharacterID(),0);     
}
}
protected native function sv2cl_UpdateMoney_CallStub();
protected event sv2cl_UpdateMoney(int aMoney) {
mMoney = aMoney;                                                            
mMoneyChanged.Trigger();                                                    
}
event sv_SetMoney(int aMoney) {
mMoney = aMoney;                                                            
sv2cl_UpdateMoney_CallStub(mMoney);                                         
}
event sv_ChangeMoney(int aDelta) {
mMoney += aDelta;                                                           
sv2cl_UpdateMoney_CallStub(mMoney);                                         
}
function cl_OnShutdown() {
Super.cl_OnShutdown();                                                      
mMoneyChanged.Delete();                                                     
}
function cl_OnInit() {
Super.cl_OnInit();                                                          
Init();                                                                     
mMoneyChanged = new Class'EventNotification';                               
}
private final native function Init();
*/