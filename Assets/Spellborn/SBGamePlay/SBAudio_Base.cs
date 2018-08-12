using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGamePlay
{
    [Serializable] public class SBAudio_Base : Actor
    {
        public const float SB_AUDIO_INACTIVE_UPDATE_FREQY = 2.3F;

        public const float SB_AUDIO_ACTIVE_UPDATE_FREQY = 15F;

        [FoldoutGroup("DefaultVolume")]
        public float MaximumRadius;

        [FoldoutGroup("DefaultVolume")]
        public float HotspotFactor;

        [FoldoutGroup("DefaultVolume")]
        public bool AlwaysUseDefault;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public SBInfluenceVolume DefaultVolume;

        [FoldoutGroup("Trigger")]
        public byte TriggeredOn;

        [FoldoutGroup("Trigger")]
        public float TriggerTimer;

        [FoldoutGroup("Trigger")]
        public float UnTriggerTimer;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float CurrentTriggerTimer;

        [FoldoutGroup("Influences")]
        public List<NameProperty> InfluenceVolumeTags = new List<NameProperty>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<SBInfluenceVolume> InfluenceVolumes = new List<SBInfluenceVolume>();

        [FoldoutGroup("Influences")]
        public bool ShowInfluenceBounds;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Box InfluenceBoundingBox;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float TimeToNextUpdate;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float UpdateTimeDelta;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public byte CurrentState;

        public SBAudio_Base()
        {
        }

        public enum SBAudioState
        {
            SBAudioState_Idle,

            SBAudioState_Active,

            SBAudioState_Dead,
        }

        public enum SBAudioInitializer
        {
            SBAudioInit_Proximity,

            SBAudioInit_Event,

            SBAudioInit_Timer,
        }
    }
}
/*
event UnTrigger(Actor Other,Pawn EventInstigator) {
AudioUntrigger(Other,EventInstigator);                                      
}
event Trigger(Actor Other,Pawn EventInstigator) {
AudioTrigger(Other,EventInstigator);                                        
}
final native function AudioUntrigger(Actor Other,Pawn EventInstigator);
final native function AudioTrigger(Actor Other,Pawn EventInstigator);
*/