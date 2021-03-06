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
#pragma warning disable 414   
    
    [System.Serializable] public class SBShadowMap : UObject
    {
        
        [FieldConst()]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        private float mMaxTraceDistance;
        
        [FieldConst()]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        private float mProjWidth;
        
        [FieldConst()]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        private float mProjHeight;
        
        [FieldConst()]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        private Vector mFrustumOrigin;
        
        [FieldConst()]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        private Vector mLocation;
        
        [FieldConst()]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        private Rotator mRotation;
        
        [FieldConst()]
        private Light mLight;
        
        [FieldConst()]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        private Matrix mWorldToCamera;
        
        [FieldConst()]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        private Matrix mCameraToScreen;
        
        [FieldConst()]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        private float mViewportScale;
        
        [FieldConst()]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        private float mNearClippingPlane;
        
        [FieldConst()]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        private float mFarClippingPlane;
        
        [FieldConst()]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        private float mPCFRadiusInTexels;
        
        [FieldConst()]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        private float mProjectorScale;
        
        [FieldConst()]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        private int mTextureInterface;
        
        [FieldConst()]
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        [ArraySizeForExtraction(Size=6)]
        private int[] mCubemapFaces = new int[0];
        
        public SBShadowMap()
        {
        }
    }
}
