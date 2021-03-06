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

namespace Engine
{
    
    
    [System.Serializable] public class AudioSubsystem : Subsystem
    {
        
        [FieldConfig()]
        public float AmbientStreamVolume;
        
        [FieldConfig()]
        public float SoundVolume;
        
        [FieldConfig()]
        public float VoiceVolume;
        
        [FieldConfig()]
        public float MusicVolume;
        
        [FieldConfig()]
        public float VolumeScaleRec;
        
        [FieldConfig()]
        public float InterfaceVolume;
        
        [FieldConfig()]
        public bool UseVoIP;
        
        [FieldConfig()]
        public int AmbientPriority;
        
        [FieldConfig()]
        public int MusicPriority;
        
        [FieldConfig()]
        public int SoundPriority;
        
        [FieldConfig()]
        public int VoicePriority;
        
        [FieldConfig()]
        public int InterfacePriority;
        
        [FieldConfig()]
        public float Own_FootstepsVolume;
        
        [FieldConfig()]
        public float Own_VoicesVolume;
        
        [FieldConfig()]
        public float Own_FXVolume;
        
        [FieldConfig()]
        public float Other_FootstepsVolume;
        
        [FieldConfig()]
        public float Other_VoicesVolume;
        
        [FieldConfig()]
        public float Other_FXVolume;
        
        [FieldConfig()]
        public float NPC_FootstepsVolume;
        
        [FieldConfig()]
        public float NPC_VoicesVolume;
        
        [FieldConfig()]
        public float NPC_FXVolume;
        
        [FieldConfig()]
        public float MonsterVolume;
        
        [FieldConfig()]
        public float WildlifeVolume;
        
        [FieldConfig()]
        public float AmbientFXVolume;
        
        [FieldConfig()]
        public int Own_VoiceRepeatTime;
        
        [FieldConfig()]
        public int Other_VoiceRepeatTime;
        
        [FieldConfig()]
        public int NPC_VoiceRepeatTime;
        
        [FieldConfig()]
        public int Wildlife_IdleFX_RepeatTime;
        
        [FieldConfig()]
        public int Wildlife_CombatFX_RepeatTime;
        
        [FieldConfig()]
        public int Monster_IdleFX_RepeatTime;
        
        [FieldConfig()]
        public int Monster_CombatFX_RepeatTime;
        
        [FieldConfig()]
        public float MainVolume;
        
        [FieldConfig()]
        public int CurrentPreferenceIndex;
        
        [FieldConfig()]
        public bool MuteAll;
        
        [FieldConfig()]
        public bool MuteMusic;
        
        [FieldConfig()]
        public bool MuteInterface;
        
        [FieldConfig()]
        public bool MuteAmbientStream;
        
        [FieldConfig()]
        public bool MuteAmbientFX;
        
        [FieldConfig()]
        public bool MuteFootsteps;
        
        [FieldConfig()]
        public bool MuteFX;
        
        [FieldConfig()]
        public bool MuteVoices;
        
        [FieldConfig()]
        public bool MuteMonsters;
        
        [FieldConfig()]
        public bool UseAmbientSound;
        
        public AudioSubsystem()
        {
        }
    }
}
