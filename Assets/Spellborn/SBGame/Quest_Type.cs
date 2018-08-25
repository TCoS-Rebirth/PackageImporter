using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class Quest_Type : Content_Type
    {
        [FoldoutGroup("Information")]
        public byte QuestArea;

        [FoldoutGroup("Information")]
        public LocalizedString Name;

        [FoldoutGroup("Information")]
        [FieldConst()]
        public LocalizedString Summary;

        [FoldoutGroup("Information")]
        [FieldConst()]
        public string Tag = string.Empty;

        [FoldoutGroup("Information")]
        [FieldConst()]
        public string Note = string.Empty;

        [FoldoutGroup("Information")]
        [FieldConst()]
        public Quest_Chain QuestChain;

        [FoldoutGroup("Information")]
        [FieldConst()]
        public int Level;

        [FoldoutGroup("ProvideChat")]
        [FieldConst()]
        public bool DeliverByMail;

        [FoldoutGroup("ProvideChat")]
        [FieldConst()]
        public NPC_Type Provider;

        [FoldoutGroup("ProvideChat")]
        [FieldConst()]
        public Conversation_Topic ProvideTopic;

        [FoldoutGroup("MidChat")]
        [FieldConst()]
        public Conversation_Topic MidTopic;

        [FoldoutGroup("MidChat")]
        [FieldConst()]
        public bool ProviderMidChat;

        [FoldoutGroup("MidChat")]
        [FieldConst()]
        public bool FinisherMidChat;

        [FoldoutGroup("FinishChat")]
        [FieldConst()]
        public NPC_Type Finisher;

        [FoldoutGroup("FinishChat")]
        [FieldConst()]
        public Conversation_Topic FinishTopic;

        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();

        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public List<Quest_Type> Prequests = new List<Quest_Type>();

        [FoldoutGroup("Requirement")]
        [FieldConst()]
        public bool Disabled;

        [FoldoutGroup("Target")]
        [FieldConst()]
        public List<Quest_Target> Targets = new List<Quest_Target>();

        [FoldoutGroup("Rewards")]
        [FieldConst()]
        public List<Quest_Reward> Rewards = new List<Quest_Reward>();

        [FieldConst()]
        public int QuestLevelLowerDelta;

        public Quest_Type()
        {
        }

        public enum EQuestArea
        {
            QA_Tech,

            QA_Carnyx,

            QA_Quarterstone,

            QA_Ringfell,

            QA_MountOfHeroes,

            QA_Parliament,

            QA_DeadspellStorm,

            QA_Ancestral,
        }
    }
}
/*
event string GetActiveText(Game_ActiveTextItem aItem) {
local export editinline Quest_Target Target;
local export editinline Quest_Reward reward;
if (aItem == None || aItem.Tag == "N") {                                    
return GetName();                                                         
} else {                                                                    
if (aItem.Tag == "T") {                                                   
Target = Targets[aItem.Ordinality];                                     
if (Target != None) {                                                   
return Target.GetActiveText(aItem.SubItem);                           
} else {                                                                
return "?Target?";                                                    
}
} else {                                                                  
if (aItem.Tag == "R") {                                                 
reward = Rewards[aItem.Ordinality];                                   
if (reward != None) {                                                 
} else {                                                              
return "?Reward?";                                                  
}
} else {                                                                
if (aItem.Tag == "P") {                                               
if (Provider != None) {                                             
return Provider.GetActiveText(aItem.SubItem);                     
} else {                                                            
return "?Provider?";                                              
}
} else {                                                              
if (aItem.Tag == "F") {                                             
if (Finisher != None) {                                           
return Finisher.GetActiveText(aItem.SubItem);                   
} else {                                                          
return "?Finisher?";                                            
}
} else {                                                            
return Super.GetActiveText(aItem);                                
}
}
}
}
}
}
final native function bool CheckPawn(Game_Pawn aCandidate);
final native function sv_OnComplete(Game_Pawn aPawn);
final native function bool sv_CanComplete(Game_Pawn aPawn);
final native function sv_OnAccept(Game_Pawn aPawn);
function string GetName() {
if (Len(Name.Text) > 0) {                                                   
return Name.Text;                                                         
} else {                                                                    
return "Unnamed quest";                                                   
}
}
*/