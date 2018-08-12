using System;
using System.Collections.Generic;
using SBBase;

namespace SBGame
{
    [Serializable] public class Game_Mail : Base_Component
    {
        public const int MAIL_CHECK_TIME = 300;

        public const int MAIL_MAX_ITEMS = 4;

        public const int MES_ATT3_REMOVED = 1024;

        public const int MES_ATT2_REMOVED = 512;

        public const int MES_ATT1_REMOVED = 256;

        public const int MES_ATT0_REMOVED = 128;

        public const int MES_SEND_DELETED = 32;

        public const int MES_RECI_DELETED = 16;

        public const int MES_FORWARDED = 8;

        public const int MES_REPLIED = 4;

        public const int MES_READ = 2;

        public const int MES_SENT = 1;

        public List<MailEntry> mMailInbox = new List<MailEntry>();

        public List<MailEntry> mMailOutbox = new List<MailEntry>();

        public bool mRequestingMails;

        public int mLastCheckTime;

        //public delegate<OnSendMailStatus> @__OnSendMailStatus__Delegate;

        //public delegate<OnUpdateEntries> @__OnUpdateEntries__Delegate;

        //public delegate<OnInboxMailDetails> @__OnInboxMailDetails__Delegate;

        //public delegate<OnOutboxMailDetails> @__OnOutboxMailDetails__Delegate;

        public Game_Mail()
        {
        }

        [Serializable] public struct MailAttachment
        {
            public int ItemTypeID;

            public int StackSize;

            public byte Color1;

            public byte Color2;
        }

        [Serializable] public struct MailEntry
        {
            public List<MailAttachment> Attachments;

            public Quest_Type quest;

            public string sender;

            public string Recipient;

            public string Subject;

            public string Body;

            public int MailID;

            public int Status;

            public int TimeStamp;

            public int Money;

            public bool Details;

            public bool Attached;
        }
    }
}
/*
protected native function sv2cl_GiveQuest_CallStub();
event sv2cl_GiveQuest(int mailIndex) {
OnInboxMailDetails(mailIndex);                                              
}
function bool sv_GiveQuest(int mailIndex) {
local Game_PlayerPawn pwn;
local export editinline Quest_Type quest;
local int eventI;
local export editinline Content_Event eventObject;
pwn = Game_PlayerPawn(Outer.Pawn);                                          
quest = mMailInbox[mailIndex].quest;                                        
if (pwn != None && quest != None) {                                         
if (quest.CheckPawn(pwn)) {                                               
if (pwn.questLog.sv_AcceptQuest(quest)) {                               
if (quest.ProvideTopic != None) {                                     
eventI = 0;                                                         
while (eventI < quest.ProvideTopic.Events.Length) {                 
eventObject = quest.ProvideTopic.Events[eventI];                  
if (eventObject != None
&& !eventObject.sv_CanExecute(None,pwn)) {
return False;                                                   
}
eventI++;                                                         
}
eventI = 0;                                                         
while (eventI < quest.ProvideTopic.Events.Length) {                 
quest.ProvideTopic.Events[eventI].sv_Execute(None,pwn);           
eventI++;                                                         
}
}
return True;                                                          
}
} else {                                                                  
return False;                                                           
}
} else {                                                                    
return False;                                                             
}
}
protected native function cl2sv_GiveQuest_CallStub();
event cl2sv_GiveQuest(int mailIndex) {
if (sv_GiveQuest(mailIndex)) {                                              
sv2cl_GiveQuest_CallStub(mailIndex);                                      
}
}
function cl_GiveQuest(int mailIndex) {
cl2sv_GiveQuest_CallStub(mailIndex);                                        
}
protected native function cl2sv_DeleteMail_CallStub();
native event cl2sv_DeleteMail(int mailIndex,bool aFromInbox);
function cl_DeleteOutboxMail(int mailIndex) {
cl2sv_DeleteMail_CallStub(mailIndex,False);                                 
mMailOutbox.Remove(mailIndex,1);                                            
OnUpdateEntries();                                                          
}
function cl_DeleteInboxMail(int mailIndex) {
cl2sv_DeleteMail_CallStub(mailIndex,True);                                  
mMailInbox.Remove(mailIndex,1);                                             
OnUpdateEntries();                                                          
}
protected native function sv2cl_UpdateOutbox_CallStub();
event sv2cl_UpdateOutbox(int mailIndex,int MailID,int Status,string Recipient,string Subject,int TimeStamp,bool Attached) {
if (mailIndex >= mMailOutbox.Length) {                                      
mMailOutbox.Length = mailIndex + 1;                                       
}
mMailOutbox[mailIndex].MailID = MailID;                                     
mMailOutbox[mailIndex].Status = Status;                                     
mMailOutbox[mailIndex].sender = Game_Pawn(Outer.Pawn).GetCharacterName();   
mMailOutbox[mailIndex].Recipient = Recipient;                               
mMailOutbox[mailIndex].Subject = Subject;                                   
mMailOutbox[mailIndex].TimeStamp = TimeStamp;                               
mMailOutbox[mailIndex].Attached = Attached;                                 
}
protected native function sv2cl_UpdateOutboxDetails_CallStub();
event sv2cl_UpdateOutboxDetails(int mailIndex,string Body,int aMoney,array<MailAttachment> aAttachments) {
mMailOutbox[mailIndex].Body = Body;                                         
mMailOutbox[mailIndex].Attachments = aAttachments;                          
mMailOutbox[mailIndex].Money = aMoney;                                      
mMailOutbox[mailIndex].Details = True;                                      
OnOutboxMailDetails(mailIndex);                                             
}
protected native function cl2sv_GetOutboxDetails_CallStub();
event cl2sv_GetOutboxDetails(int mailIndex) {
sv2cl_UpdateOutboxDetails_CallStub(mailIndex,mMailOutbox[mailIndex].Body,mMailOutbox[mailIndex].Money,mMailOutbox[mailIndex].Attachments);
}
function cl_GetOutboxDetails(int mailIndex) {
if (!mMailOutbox[mailIndex].Details) {                                      
cl2sv_GetOutboxDetails_CallStub(mailIndex);                               
} else {                                                                    
OnOutboxMailDetails(mailIndex);                                           
}
}
protected native function sv2cl_UpdateInboxQuest_CallStub();
event sv2cl_UpdateInboxQuest(int mailIndex,int Status,int questId,int TimeStamp) {
local export editinline Quest_Type quest;
quest = Quest_Type(Class'SBDBSync'.GetResourceObject(questId));             
if (quest != None) {                                                        
if (mailIndex >= mMailInbox.Length) {                                     
mMailInbox.Length = mailIndex + 1;                                      
}
mMailInbox[mailIndex].Status = Status;                                    
mMailInbox[mailIndex].sender = quest.Provider.GetLongName();              
mMailInbox[mailIndex].Recipient = Game_Pawn(Outer.Pawn).Character.sv_GetName();
mMailInbox[mailIndex].Subject = quest.Name.Text;                          
mMailInbox[mailIndex].TimeStamp = TimeStamp;                              
mMailInbox[mailIndex].Details = False;                                    
mMailInbox[mailIndex].quest = quest;                                      
}
}
protected native function sv2cl_UpdateInbox_CallStub();
event sv2cl_UpdateInbox(int mailIndex,int MailID,int Status,string sender,string Subject,int TimeStamp,bool Attached) {
if (mailIndex >= mMailInbox.Length) {                                       
mMailInbox.Length = mailIndex + 1;                                        
}
mMailInbox[mailIndex].MailID = MailID;                                      
mMailInbox[mailIndex].Status = Status;                                      
mMailInbox[mailIndex].sender = sender;                                      
mMailInbox[mailIndex].Recipient = Game_Pawn(Outer.Pawn).GetCharacterName(); 
mMailInbox[mailIndex].Subject = Subject;                                    
mMailInbox[mailIndex].TimeStamp = TimeStamp;                                
mMailInbox[mailIndex].Attached = Attached;                                  
mMailInbox[mailIndex].Details = False;                                      
}
protected native function sv2cl_UpdateInboxDetails_CallStub();
event sv2cl_UpdateInboxDetails(int mailIndex,string Body,int aMoney,array<MailAttachment> aAttachments) {
mMailInbox[mailIndex].Body = Body;                                          
mMailInbox[mailIndex].Attachments = aAttachments;                           
mMailInbox[mailIndex].Money = aMoney;                                       
mMailInbox[mailIndex].Details = True;                                       
OnInboxMailDetails(mailIndex);                                              
}
protected native function cl2sv_GetInboxDetails_CallStub();
event cl2sv_GetInboxDetails(int mailIndex) {
sv_SetInboxMailStatus(mailIndex,2);                                         
sv2cl_UpdateInboxDetails_CallStub(mailIndex,mMailInbox[mailIndex].Body,mMailInbox[mailIndex].Money,mMailInbox[mailIndex].Attachments);
}
function cl_GetInboxDetails(int mailIndex) {
local export editinline Quest_Type quest;
if (!mMailInbox[mailIndex].Details) {                                       
mMailInbox[mailIndex].Status = mMailInbox[mailIndex].Status | 2;          
if (mMailInbox[mailIndex].quest == None) {                                
cl2sv_GetInboxDetails_CallStub(mailIndex);                              
} else {                                                                  
quest = mMailInbox[mailIndex].quest;                                    
mMailInbox[mailIndex].Body = Outer.TextParser.Parse(quest.ProvideTopic.Conversations[0].Text.Text,quest.Provider,quest,Outer.Pawn,0);
OnInboxMailDetails(mailIndex);                                          
}
} else {                                                                    
OnInboxMailDetails(mailIndex);                                            
}
}
native function sv_SetInboxMailStatus(int mailIndex,int Flag);
function sv_OnSentMail(int aErrorCode) {
sv2cl_SendMailStatus_CallStub(aErrorCode);                                  
if (aErrorCode == 0) {                                                      
sv_RetrieveMailEntries(True);                                             
}
}
protected native function sv2cl_SendMailStatus_CallStub();
event sv2cl_SendMailStatus(int aErrorCode) {
OnSendMailStatus(aErrorCode);                                               
OnUpdateEntries();                                                          
}
protected native function cl2sv_SendMail_CallStub();
private native event cl2sv_SendMail(string aRecipient,string aSubject,string aBody,int aMoney,array<int> aAttachedItems);
function cl_SendMail(string aRecipient,string aSubject,string aBody,int aMoney,array<int> aAttachedItems) {
cl2sv_SendMail_CallStub(aRecipient,aSubject,aBody,aMoney,aAttachedItems);   
}
protected native function sv2cl_UpdateEntriesDone_CallStub();
event sv2cl_UpdateEntriesDone() {
OnUpdateEntries();                                                          
}
function sv_OnReceivedMailItems(int aErrorCode) {
mRequestingMails = False;                                                   
sv_OnEntriesReceived();                                                     
}
private event sv_OnEntriesReceived() {
local int i;
i = 0;                                                                      
while (i < mMailInbox.Length) {                                             
if (mMailInbox[i].quest == None) {                                        
sv2cl_UpdateInbox_CallStub(i,mMailInbox[i].MailID,mMailInbox[i].Status,mMailInbox[i].sender,mMailInbox[i].Subject,mMailInbox[i].TimeStamp,mMailInbox[i].Attached);
} else {                                                                  
sv2cl_UpdateInboxQuest_CallStub(i,mMailInbox[i].Status,mMailInbox[i].quest.GetResourceId(),mMailInbox[i].TimeStamp);
}
++i;                                                                      
}
i = 0;                                                                      
while (i < mMailOutbox.Length) {                                            
sv2cl_UpdateOutbox_CallStub(i,mMailOutbox[i].MailID,mMailOutbox[i].Status,mMailOutbox[i].Recipient,mMailOutbox[i].Subject,mMailOutbox[i].TimeStamp,mMailOutbox[i].Attached);
++i;                                                                      
}
sv2cl_UpdateEntriesDone_CallStub();                                         
}
native function sv_RetrieveMailEntries(bool aForceUpdate);
protected native function cl2sv_RequestEntries_CallStub();
event cl2sv_RequestEntries() {
sv_RetrieveMailEntries(False);                                              
}
delegate OnOutboxMailDetails(int mailIndex);
delegate OnInboxMailDetails(int mailIndex);
delegate OnUpdateEntries();
delegate OnSendMailStatus(int aErrorCode);
*/