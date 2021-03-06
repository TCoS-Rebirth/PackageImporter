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
    
    
    [System.Serializable] public class InteractiveHatch : InteractiveLevelElement
    {
        
        [Sirenix.OdinInspector.FoldoutGroup("InteractiveHatch")]
        [FieldConst()]
        public Vector DoorMovement;
        
        [Sirenix.OdinInspector.FoldoutGroup("InteractiveHatch")]
        [FieldConst()]
        public Rotator DoorRotation;
        
        [Sirenix.OdinInspector.FoldoutGroup("InteractiveHatch")]
        [FieldConst()]
        public bool Hide;
        
        [Sirenix.OdinInspector.FoldoutGroup("InteractiveHatch")]
        [FieldConst()]
        public float OpenSpeed;
        
        [Sirenix.OdinInspector.FoldoutGroup("InteractiveHatch")]
        [FieldConst()]
        public float PassableTime;
        
        [Sirenix.OdinInspector.FoldoutGroup("InteractiveHatch")]
        [FieldConst()]
        public string AnnotationTag = string.Empty;
        
        [Sirenix.OdinInspector.FoldoutGroup("InteractiveHatch")]
        public LocalizedString DoorSign;
        
        [Sirenix.OdinInspector.FoldoutGroup("InteractiveHatch")]
        [FieldConst()]
        [System.NonSerialized, UnityEngine.HideInInspector]
        public Sound DoorSound;
        
        public InteractiveHatch()
        {
        }
    }
}
/*
event string cl_GetToolTip() {
return DoorSign.Text;                                                       
}
*/
