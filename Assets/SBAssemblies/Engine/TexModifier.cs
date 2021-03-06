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
    
    
    [System.Serializable] public class TexModifier : Modifier
    {
        
        public byte TexCoordSource;
        
        [Sirenix.OdinInspector.FoldoutGroup("TexModifier")]
        public byte TexCoordCount;
        
        [Sirenix.OdinInspector.FoldoutGroup("TexModifier")]
        public bool TexCoordProjected;
        
        public int texmodifier_dummy;
        
        public TexModifier()
        {
        }
        
        public enum ETexCoordCount
        {
            
            TCN_2DCoords ,
            
            TCN_3DCoords ,
            
            TCN_4DCoords,
        }
        
        public enum ETexCoordSrc
        {
            
            TCS_Stream0 ,
            
            TCS_Stream1 ,
            
            TCS_Stream2 ,
            
            TCS_Stream3 ,
            
            TCS_Stream4 ,
            
            TCS_Stream5 ,
            
            TCS_Stream6 ,
            
            TCS_Stream7 ,
            
            TCS_WorldCoords ,
            
            TCS_CameraCoords ,
            
            TCS_WorldEnvMapCoords ,
            
            TCS_CameraEnvMapCoords ,
            
            TCS_ProjectorCoords ,
            
            TCS_NoChange,
        }
    }
}
