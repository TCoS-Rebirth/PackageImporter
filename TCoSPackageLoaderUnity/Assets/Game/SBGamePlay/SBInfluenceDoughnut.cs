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
    
    
    public class SBInfluenceDoughnut : SBInfluenceVolume
    {
        
        [FieldCategory(Category="SBInfluenceDoughnut")]
        public float DoughnutRadius;
        
        [FieldCategory(Category="SBInfluenceDoughnut")]
        public float MaximumRadius;
        
        [FieldCategory(Category="SBInfluenceDoughnut")]
        public float HotspotFactor;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public float HsRadiusSquared;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public float MaxRadiusSquared;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public float InvFactor;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public float DoughnutRadiusSquared;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public Vector planeNormal;
        
        public SBInfluenceDoughnut()
        {
        }
    }
}
