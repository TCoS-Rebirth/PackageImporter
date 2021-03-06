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
    
    
    [System.Serializable] public class TexRotator : TexModifier
    {
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        public Matrix M;
        
        [Sirenix.OdinInspector.FoldoutGroup("TexRotator")]
        public byte TexRotationType;
        
        [Sirenix.OdinInspector.FoldoutGroup("TexRotator")]
        public Rotator Rotation;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public bool ConstantRotation;
        
        [Sirenix.OdinInspector.FoldoutGroup("TexRotator")]
        public float UOffset;
        
        [Sirenix.OdinInspector.FoldoutGroup("TexRotator")]
        public float VOffset;
        
        [Sirenix.OdinInspector.FoldoutGroup("TexRotator")]
        public Rotator OscillationRate;
        
        [Sirenix.OdinInspector.FoldoutGroup("TexRotator")]
        public Rotator OscillationAmplitude;
        
        [Sirenix.OdinInspector.FoldoutGroup("TexRotator")]
        public Rotator OscillationPhase;
        
        public TexRotator()
        {
        }
        
        public enum ETexRotationType
        {
            
            TR_FixedRotation ,
            
            TR_ConstantlyRotating ,
            
            TR_OscillatingRotation,
        }
    }
}
