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
    
    
    [System.Serializable] public class Modifier : Material
    {
        
        [Sirenix.OdinInspector.FoldoutGroup("Modifier")]
        [System.NonSerialized, UnityEngine.HideInInspector]
        public Material Material;
        
        public Modifier()
        {
        }
    }
}
/*
function Trigger(Actor Other,Actor EventInstigator) {
if (Material != None) {                                                     
Material.Trigger(Other,EventInstigator);                                  
}
if (FallbackMaterial != None) {                                             
FallbackMaterial.Trigger(Other,EventInstigator);                          
}
}
function Reset() {
if (Material != None) {                                                     
Material.Reset();                                                         
}
if (FallbackMaterial != None) {                                             
FallbackMaterial.Reset();                                                 
}
}
*/
