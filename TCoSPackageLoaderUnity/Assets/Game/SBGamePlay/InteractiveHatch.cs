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
    
    
    public class InteractiveHatch : InteractiveLevelElement
    {
        
        [FieldCategory(Category="InteractiveHatch")]
        [FieldConst()]
        public Vector DoorMovement;
        
        [FieldCategory(Category="InteractiveHatch")]
        [FieldConst()]
        public Rotator DoorRotation;
        
        [FieldCategory(Category="InteractiveHatch")]
        [FieldConst()]
        public bool Hide;
        
        [FieldCategory(Category="InteractiveHatch")]
        [FieldConst()]
        public float OpenSpeed;
        
        [FieldCategory(Category="InteractiveHatch")]
        [FieldConst()]
        public float PassableTime;
        
        [FieldCategory(Category="InteractiveHatch")]
        [FieldConst()]
        public string AnnotationTag = string.Empty;
        
        [FieldCategory(Category="InteractiveHatch")]
        public LocalizedString DoorSign;
        
        [FieldCategory(Category="InteractiveHatch")]
        [FieldConst()]
        [IgnoreFieldExtraction()]
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
