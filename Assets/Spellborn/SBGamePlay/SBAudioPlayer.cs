using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGamePlay
{
    [Serializable] public class SBAudioPlayer : SBAudio_Base
    {
        [FoldoutGroup("SBAudioPlayer")]
        public byte MaximumVolume;

        [FoldoutGroup("SBAudioPlayer")]
        public bool Looping;

        [FoldoutGroup("SBAudioPlayer")]
        public bool Locational;

        [FoldoutGroup("SBAudioPlayer")]
        public int Pitch;

        [FoldoutGroup("SBAudioPlayer")]
        public byte AudioType;

        [FoldoutGroup("Trigger")]
        public byte InitialTrigger;

        [FoldoutGroup("Trigger")]
        public byte LaterTriggers;

        [FoldoutGroup("Trigger")]
        public float TriggerFadeTime;

        [FoldoutGroup("Trigger")]
        public float UnTriggerFadeTime;

        [FoldoutGroup("Sounds")]
        public List<SBSoundEditor> Sounds = new List<SBSoundEditor>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<SBSound> CachedSounds = new List<SBSound>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool bCachedSoundsDirty;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool bTriggeredOnce;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool bBaseVolumeCached;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool bPreventNewAudio;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Vector MeanLocation;

        [FoldoutGroup("Modifiers")]
        public List<SBAudioModifierProps> ModifierProperties = new List<SBAudioModifierProps>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<SBAudioModifier> ModifierInstances = new List<SBAudioModifier>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float ActualPitch;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int SoundFlags;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float ActualMaxVolume;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float CurrentVolume;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public SBPlayerActiveAudio DayAudio;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public SBPlayerActiveAudio NightAudio;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public SBPlayerActiveAudio IndependantAudio;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private byte mCachedTriggerType;

        public SBAudioPlayer()
        {
        }

        [Serializable] public struct SBPlayerActiveAudio
        {
            public int Index;

            public int TrackHandle;

            public bool bPlaying;
        }

        [Serializable] public struct SBAudioModifierProps
        {
            public byte ModifierType;

            public byte ModulationShape;

            public float ModulationTime;

            public float ModulationTimeDelta;

            public float ModulationTimeVariation;

            public float ModulationDamping;

            public float ModulationDampingVariation;
        }

        [Serializable] public struct SBExcludedAudio
        {
            public NameProperty ActorName;

            public byte AudioType;

            public bool Excluded;
        }

        [Serializable] public struct SBSoundEditor
        {
            public string OggFilename;

            public byte WhenPlayed;
        }

        [Serializable] public struct SBSound
        {
            public float StartTime;

            public float Duration;

            public bool IsOgg;

            public byte WhenPlayed;
        }

        public enum AudioModifierType
        {
            Audio_VolumeModulator,
        }

        public enum ESBTriggerBehaviour
        {
            SBTrigBehaviour_TimeDependant,

            SBTrigBehaviour_Reset,

            SBTrigBehaviour_None,
        }

        public enum ESBSoundTimeOfDay
        {
            SoundTOD_Always,

            SoundTOD_Day,

            SoundTOD_Night,
        }
    }
}