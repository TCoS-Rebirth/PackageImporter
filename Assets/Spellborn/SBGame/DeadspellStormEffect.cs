using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class DeadspellStormEffect : TimedEnvironmentEffect
    {
        [FoldoutGroup("DSIntro")]
        public EnvironmentSettings StormStart;

        [FoldoutGroup("DSIntro")]
        public int IntroDurationSec;

        [FoldoutGroup("DSIntro")]
        public NameProperty IntroEvent;

        [FoldoutGroup("DSTrip")]
        public NameProperty StartEvent;

        [FoldoutGroup("DSTrip")]
        public List<DSProgressEvent> TripEvents = new List<DSProgressEvent>();

        [FoldoutGroup("DSOutro")]
        public EnvironmentSettings StormEnd;

        [FoldoutGroup("DSOutro")]
        public int OutroDurationSec;

        [FoldoutGroup("DSOutro")]
        public NameProperty OutroEvent;

        [FoldoutGroup("DSMusic")]
        public NameProperty MusicTag;

        [FoldoutGroup("DSMusic")]
        public float MusicDelaySec;

        [FoldoutGroup("Preview")]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public byte mPhase;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public EnvironmentSettings mCurrentEnvironmentSettings;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float mOutroIntroTimer;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool bActivated;

        public DeadspellStormEffect()
        {
        }

        [Serializable] public struct DSProgressEvent
        {
            public float TimeFraction;

            public NameProperty Event;
        }

        public enum EDeadSpellPhase
        {
            EDSP_None,

            EDSP_Intro,

            EDSP_Wait,

            EDSP_Trip,

            EDSP_Outro,

            EDSP_Done,
        }
    }
}
/*
event UnTrigger(Actor Other,Pawn EventInstigator) {
bActivated = False;                                                         
}
event Trigger(Actor Other,Pawn EventInstigator) {
bActivated = True;                                                          
}
*/