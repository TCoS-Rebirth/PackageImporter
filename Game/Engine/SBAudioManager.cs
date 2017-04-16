﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using TCosReborn.Framework.Common;


namespace Engine
{


    public class SBAudioManager : SBPackageResource
    {
        
        public const float SBMIN_ALLOWED_VOLUME = 0.001F;
        
        public const int SBFADER_INVALID = -1;
        
        public List<SBAudioTypeParams> GroupParameters = new List<SBAudioTypeParams>();
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public List<SBAudioStream> SBStream = new List<SBAudioStream>();
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public List<SBAudioFader> GroupFaders = new List<SBAudioFader>();
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public List<SBAudioFader> TrackFaders = new List<SBAudioFader>();
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public List<SBExemptFromFade> FadeExemptList = new List<SBExemptFromFade>();
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        private List<MusicTrackInfo> GlobalMusic = new List<MusicTrackInfo>();
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        private float mCachedRelativeTOD;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        private float mDayAudioAmplitudeFactor;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        private float mNightAudioAmplitudeFactor;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        private float mDawnStart;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        private float mDuskStart;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        private byte mCurrentAudioTimePeriod;
        
        [TCosReborn.Framework.Attributes.FieldConfigAttribute()]
        public float DayNightFadeThreshold;
        
        [TCosReborn.Framework.Attributes.FieldConfigAttribute()]
        public float DawnDuration;
        
        [TCosReborn.Framework.Attributes.FieldConfigAttribute()]
        public float DuskDuration;
        
        [TCosReborn.Framework.Attributes.FieldConfigAttribute()]
        private float ExplorationMusicTimeout;
        
        [TCosReborn.Framework.Attributes.FieldConfigAttribute()]
        private float mCurrentExpMusicTimer;
        
        [TCosReborn.Framework.Attributes.FieldConfigAttribute()]
        public float SoundNotifierRadiusFactor;
        
        [TCosReborn.Framework.Attributes.FieldConfigAttribute()]
        public float MusicAmbientFadeOutDuration;
        
        [TCosReborn.Framework.Attributes.FieldConfigAttribute()]
        public float MusicAmbientFadeInDuration;
        
        [TCosReborn.Framework.Attributes.FieldConfigAttribute()]
        public float MusicAmbientFadeInBeforeEnd;
        
        private List<GroupFadeProperties> DefaultMusicFades = new List<GroupFadeProperties>();
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        private Engine mOwner;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        private AudioSubsystem mAudio;
        
        public SBAudioManager()
        {
        }
        
        public struct FaderInfo
        {
            
            public bool GroupFader;
            
            public int FaderHandle;
            
            public int FaderID;
            
            public float FadeOutTime;
            
            public float FadeInTime;
            
            public float FadeOutDelay;
            
            public float FadeInDelay;
        }
        
        public struct GroupFadeProperties
        {
            
            public byte AudioType;
            
            public float FadeOutTime;
            
            public float FadeInTime;
            
            public float FadeOutDelay;
            
            public float FadeInDelay;
        }
        
        public struct MusicTrackInfo
        {
            
            public int MusicHandle;
            
            public List<FaderInfo> ActiveFaders;
        }
        
        public struct SBExemptFromFade
        {
            
            public string ActorTagName;
            
            public bool TimerActive;
            
            public float RemoveExemptionTimer;
        }
        
        public struct SBAudioTypeParams
        {
            
            public byte AudioType;
            
            public int Priority;
            
            public float MaximumVolumeFactor;
            
            public float CurrentVolumeFactor;
            
            public bool Mute;
        }
        
        public struct SBAudioStream
        {
            
            public byte AudioType;
            
            public byte OwnerType;
            
            public float Volume;
            
            public float Pitch;
            
            public int StreamHandle;
            
            public int Priority;
            
            public Sound SoundObject;
            
            public Actor SoundOwner;
            
            public Vector Location;
            
            public float MaxRadius;
            
            public int SoundFlags;
            
            public float CurrentTime;
            
            public float TotalDuration;
            
            public int AudioStreamId;
            
            public bool Initialized;
            
            public bool Looped;
        }
        
        public struct SBAudioFader
        {
            
            public int Handle;
            
            public string TrackOwnerTag;
            
            public int Id;
            
            public float CurrentFadeTime;
            
            public float TotalFadeTime;
            
            public float StartFactor;
            
            public float TargetFactor;
            
            public float FadeFactor;
            
            public bool CullAtTarget;
        }
        
        public enum SBAM_DayNightPeriod
        {
            
            SBDNP_Day ,
            
            SBDNP_Dawn ,
            
            SBDNP_Night ,
            
            SBDNP_Dusk,
        }
        
        public enum SBAM_CharacterType
        {
            
            SBCT_None ,
            
            SBCT_Player ,
            
            SBCT_Client ,
            
            SBCT_NPC,
        }
        
        public enum SBAM_AudioType
        {
            
            SBAM_AmbientStream ,
            
            SBAM_AmbientFX ,
            
            SBAM_MonsterFX ,
            
            SBAM_WildlifeFX ,
            
            SBAM_CharacterFX ,
            
            SBAM_CharacterFootstep ,
            
            SBAM_CharacterVoice ,
            
            SBAM_Music ,
            
            SBAM_Interface ,
            
            SBAM_SpecialMusic,
        }
    }
}
/*
final native function OnShutdown();
final native function ResetExplorationMusicTimer();
final native function float GetExplorationMusicTimerValue();
final native function SetDefaultExplorationMusicTimeout(float aNewValue);
final native function float GetDefaultExplorationMusicTimeout();
final native function StopMusicTrack(int aTrackHandle,optional float aFadeOutTime);
final native function StopMusicFile(string anOggFilename,optional float aFadeOutTime);
final native function int PlayMusic(string anOggFilename,float aVolume,bool aLooped,optional float aFadeInTime,optional bool aSpecialMusic,optional array<GroupFadeProperties> aGroupFaders);
final native function int PlayInterfaceSound(Sound s,float Volume);
final native function StopAudioTrack(int aTrackHandle,optional Actor aOwner,optional float aFadeOutTime);
final native function StopAudioType(byte aAudioType,optional float FadeTime);
*/
