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

namespace SBGame
{
    
    
    public class PathConfigurationActor : Actor
    {
        
        [FieldCategory(Category="PathConfigurationActor")]
        public bool mUseAccessmap;
        
        [FieldCategory(Category="PathConfigurationActor")]
        public float mNoiseRatio;
        
        [FieldCategory(Category="PathConfigurationActor")]
        public float mNoiseFactor;
        
        [FieldCategory(Category="PathConfigurationActor")]
        public float mTrackerSpeed;
        
        [FieldCategory(Category="PathConfigurationActor")]
        public int mLookAheadCount;
        
        [FieldCategory(Category="PathConfigurationActor")]
        public int mMaxDepth;
        
        [FieldCategory(Category="PathConfigurationActor")]
        public float mMinMoveDistance;
        
        [FieldCategory(Category="PathConfigurationActor")]
        public float mReplanThreshold;
        
        [FieldCategory(Category="PathConfigurationActor")]
        public float mMaxFailureDistance;
        
        [FieldCategory(Category="PathConfigurationActor")]
        public float mRandomizationFactor;
        
        [FieldCategory(Category="PathConfigurationActor")]
        public float mRandomDistance;
        
        [FieldCategory(Category="PathConfigurationActor")]
        public float mFacingDistance;
        
        public PathConfigurationActor()
        {
        }
    }
}
