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
    
    
    public class AnimNotify_SBSound : AnimNotify
    {
        
        [FieldCategory(Category="AnimNotify_SBSound")]
        [IgnoreFieldExtraction()]
        public Sound Sound;
        
        [FieldCategory(Category="AnimNotify_SBSound")]
        public int Radius;
        
        [FieldCategory(Category="AnimNotify_SBSound")]
        public NameProperty MeshSoundPropertiesGroup;
        
        [FieldCategory(Category="AnimNotify_SBSound")]
        public byte SoundType;
        
        public AnimNotify_SBSound()
        {
        }
    }
}
