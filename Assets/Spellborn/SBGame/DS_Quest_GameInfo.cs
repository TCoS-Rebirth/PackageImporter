using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class DS_Quest_GameInfo : Deadspell_GameInfo
    {
        [FoldoutGroup("QuestEvents")]
        public List<QuestEvent> QuestEvents = new List<QuestEvent>();

        [FoldoutGroup("QuestEvents")]
        public NameProperty QuestStartEvent;

        [FoldoutGroup("QuestEvents")]
        public string StartPortalNavigationTag = string.Empty;

        public int CurrentEvent;

        public float CurrentPerc;

        public float TargetPerc;

        public float PercPerSec;

        [FoldoutGroup("Travel")]
        public float WaitSecHack;

        [FoldoutGroup("Travel")]
        public float OutroSecHack;

        public float mTime;

        public float mOutroTime;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool mQuestStarted;

        public bool mQuestFinished;

        public DS_Quest_GameInfo()
        {
        }

        [Serializable] public struct QuestEvent
        {
            public NameProperty Event;

            public float Duration;

            public float TargetPerc;
        }
    }
}
/*
event Trigger(Actor Other,Pawn EventInstigator) {
TargetPerc = QuestEvents[CurrentEvent].TargetPerc;                          
PercPerSec = (TargetPerc - CurrentPerc) / Max(QuestEvents[CurrentEvent].Duration,1);
if (++CurrentEvent <= QuestEvents.Length) {                                 
Tag = QuestEvents[CurrentEvent].Event;                                    
}
}
event PostBeginPlay() {
Super.PostBeginPlay();                                                      
DSQuestParseInstanceOptions("");                                            
mTime = -WaitSecHack;                                                       
if (QuestEvents.Length > 0) {                                               
Tag = QuestEvents[0].Event;                                               
CurrentEvent = 0;                                                         
CurrentPerc = 0.00000000;                                                 
}
}
native function DSQuestParseInstanceOptions(string Options);
*/