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
    
    
    [System.Serializable] public class SBSunlight : Light
    {
        
        [Sirenix.OdinInspector.FoldoutGroup("SBSunlight")]
        public bool ProjectShadow;
        
        [Sirenix.OdinInspector.FoldoutGroup("SBSunlight")]
        public int FOV;
        
        [Sirenix.OdinInspector.FoldoutGroup("SBSunlight")]
        public int MaxTraceDistance;
        
        [Sirenix.OdinInspector.FoldoutGroup("SBSunlight")]
        public byte BlendingOp;
        
        [Sirenix.OdinInspector.FoldoutGroup("Advanced")]
        public SBProjector AttachedSBProjector;
        
        [FieldConst()]
        public int ProjWidth;
        
        [FieldConst()]
        public int ProjHeight;
        
        [FieldConst()]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        [ArraySizeForExtraction(Size=6)]
        public Plane[] FrustumPlanes = new Plane[0];
        
        [FieldConst()]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        [ArraySizeForExtraction(Size=8)]
        public Vector[] FrustumVertices = new Vector[0];
        
        [FieldConst()]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public Vector FrustumOrigin;
        
        [FieldConst()]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public Box Box;
        
        [FieldConst()]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public int TextureInterface;
        
        [FieldConst()]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public List<Actor> InfluencedActors = new List<Actor>();
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public Vector OldLocation;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public Matrix Matrix;
        
        public SBSunlight()
        {
        }
    }
}
/*
simulated event PostBeginPlay() {
if (Level.NetMode == 1) {                                                   
GotoState('NoProjection');                                                
return;                                                                   
}
AttachProjector();                                                          
}
native function DetachProjector();
native function AttachProjector();
state NoProjection {
function BeginState() {
Disable('Tick');                                                        
}
}
*/
