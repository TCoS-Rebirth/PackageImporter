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
    
    
    [System.Serializable] public class AmbientSound : Keypoint
    {
        
        [Sirenix.OdinInspector.FoldoutGroup("Sound")]
        [System.NonSerialized, UnityEngine.HideInInspector]
        public List<SoundEmitter> SoundEmitters = new List<SoundEmitter>();
        
        public float AmbientVolume;
        
        public AmbientSound()
        {
        }
        
        [System.Serializable] public struct SoundEmitter
        {
            
            public float EmitInterval;
            
            public float EmitVariance;
            
            public float EmitTime;
            
            public Sound EmitSound;
        }
    }
}
