﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Engine;
using SBAI;
using SBAIScripts;
using SBBase;
using SBGame;
using SBGamePlay;
using SBMiniGames;
using System;
using System.Collections;
using System.Collections.Generic;
using Framework.Attributes;

namespace SBGamePlay
{
    
    
    public class SBAudioPlayer : SBAudio_Base
    {
        
        [FieldCategory(Category="SBAudioPlayer")]
        public byte MaximumVolume;
        
        [FieldCategory(Category="SBAudioPlayer")]
        public bool Looping;
        
        [FieldCategory(Category="SBAudioPlayer")]
        public bool Locational;
        
        [FieldCategory(Category="SBAudioPlayer")]
        public int Pitch;
        
        [FieldCategory(Category="SBAudioPlayer")]
        public byte AudioType;
        
        [FieldCategory(Category="Trigger")]
        public byte InitialTrigger;
        
        [FieldCategory(Category="Trigger")]
        public byte LaterTriggers;
        
        [FieldCategory(Category="Trigger")]
        public float TriggerFadeTime;
        
        [FieldCategory(Category="Trigger")]
        public float UnTriggerFadeTime;
        
        [FieldCategory(Category="Sounds")]
        public List<SBSoundEditor> Sounds = new List<SBSoundEditor>();
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public List<SBSound> CachedSounds = new List<SBSound>();
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public bool bCachedSoundsDirty;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public bool bTriggeredOnce;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public bool bBaseVolumeCached;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public bool bPreventNewAudio;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public Vector MeanLocation;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public SBAudioManager AudioManager;
        
        [FieldCategory(Category="Modifiers")]
        public List<SBAudioModifierProps> ModifierProperties = new List<SBAudioModifierProps>();
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public List<SBAudioModifier> ModifierInstances = new List<SBAudioModifier>();
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public float ActualPitch;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public int SoundFlags;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public float ActualMaxVolume;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public float CurrentVolume;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public SBPlayerActiveAudio DayAudio;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public SBPlayerActiveAudio NightAudio;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public SBPlayerActiveAudio IndependantAudio;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        private byte mCachedTriggerType;
        
        public SBAudioPlayer()
        {
        }
        
        public struct SBPlayerActiveAudio
        {
            
            public int Index;
            
            public int TrackHandle;
            
            public bool bPlaying;
        }
        
        public struct SBAudioModifierProps
        {
            
            public byte ModifierType;
            
            public byte ModulationShape;
            
            public float ModulationTime;
            
            public float ModulationTimeDelta;
            
            public float ModulationTimeVariation;
            
            public float ModulationDamping;
            
            public float ModulationDampingVariation;
        }
        
        public struct SBExcludedAudio
        {
            
            public NameProperty ActorName;
            
            public byte AudioType;
            
            public bool Excluded;
        }
        
        public struct SBSoundEditor
        {
            
            public string OggFilename;
            
            public Sound Sound;
            
            public byte WhenPlayed;
        }
        
        public struct SBSound
        {
            
            public Sound Sound;
            
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
            
            SBTrigBehaviour_TimeDependant ,
            
            SBTrigBehaviour_Reset ,
            
            SBTrigBehaviour_None,
        }
        
        public enum ESBSoundTimeOfDay
        {
            
            SoundTOD_Always ,
            
            SoundTOD_Day ,
            
            SoundTOD_Night,
        }
    }
}
