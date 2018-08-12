using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Conversation_Topic : Content_Type
    {
        [FoldoutGroup("Type")]
        public byte TopicType;

        [FoldoutGroup("Conversation")]
        public List<Conversation_Node> Conversations = new List<Conversation_Node>();

        [FoldoutGroup("Conversation")]
        public LocalizedString TopicText;

        [FoldoutGroup("Conversation")]
        public int ButtonImage;

        [FoldoutGroup("Requirements")]
        public int Priority;

        [FoldoutGroup("Requirements")]
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();

        [FoldoutGroup("Requirements")]
        public string ScriptReference = string.Empty;

        [FoldoutGroup("Requirements")]
        public bool AvailableTopic;

        [FoldoutGroup("Requirements")]
        public bool PublicTopic;

        [FoldoutGroup("Events")]
        public List<Content_Event> Events = new List<Content_Event>();

        [FoldoutGroup("Banner")]
        public byte Emote;

        [FoldoutGroup("Banner")]
        public LocalizedString Chat;

        [FoldoutGroup("Banner")]
        [NonSerialized, HideInInspector]
        public string Icon;

        [FoldoutGroup("Banner")]
        [TypeProxyDefinition(TypeName = "Emitter")]
        public Type EmitterClass;

        [FoldoutGroup("Banner")]
        public float BannerTime;

        [FoldoutGroup("Minimap")]
        public float MinimapRange;

        public Conversation_Topic()
        {
        }

        public enum EConversationType
        {
            ECT_None,

            ECT_Free,

            ECT_Greeting,

            ECT_Provide,

            ECT_Mid,

            ECT_Finish,

            ECT_Talk,

            ECT_LastWords,

            ECT_Victory,

            ECT_Thanks,

            ECT_Deliver,
        }
    }
}
/*
function Content_Type GetContext() {
return None;                                                                
}
function bool sv_FilterTopic(export editinline Conversation_Topic aOther) {
if (aOther == self) {                                                       
return False;                                                             
}
if (!aOther.PublicTopic) {                                                  
return False;                                                             
}
return True;                                                                
}
function sv_Start(Game_Pawn aSpeaker,Game_Pawn aPartner) {
local export editinline Conversation_Node bestConv;
sv_OnStart(aSpeaker,aPartner);                                              
bestConv = GetConversationNode(aSpeaker,aPartner);                          
if (bestConv != None) {                                                     
Game_Controller(aSpeaker.Controller).ConversationControl.Converse(aPartner,self,bestConv);
goto jl0065;                                                              
}
}
event bool sv_OnFinish(Game_Pawn aSpeaker,Game_Pawn aPartner) {
local int eventI;
eventI = 0;                                                                 
while (eventI < Events.Length) {                                            
if (Events[eventI] != None
&& !Events[eventI].sv_CanExecute(aSpeaker,aPartner)) {
return False;                                                           
}
eventI++;                                                                 
}
eventI = 0;                                                                 
while (eventI < Events.Length) {                                            
Events[eventI].sv_Execute(aSpeaker,aPartner);                             
eventI++;                                                                 
}
return True;                                                                
}
event sv_OnStart(Game_Pawn aSpeaker,Game_Pawn aPartner) {
}
protected final native function bool CheckPawn(Game_Pawn aSpeaker,Game_Pawn aPartner);
protected final native function Conversation_Node GetConversationNode(Game_Pawn aSpeaker,Game_Pawn aPartner);
final native function Conversation_Node CheckConversation(Game_Pawn aSpeaker,Game_Pawn aPartner);
function string GetText() {
return TopicText.Text;                                                      
}
*/