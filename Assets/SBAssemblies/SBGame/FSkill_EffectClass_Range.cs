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
    
    
    [System.Serializable] public class FSkill_EffectClass_Range : FSkill_EffectClass
    {
        
        public const float MAX_SKILLSIZE = 200F;
        
        public const float MAX_SPEED = 1000F;
        
        [Sirenix.OdinInspector.FoldoutGroup("direction")]
        [FieldConst()]
        public Vector LocationOffset;
        
        [Sirenix.OdinInspector.FoldoutGroup("direction")]
        [FieldConst()]
        public int RotationOffset;
        
        [Sirenix.OdinInspector.FoldoutGroup("Angle")]
        [FieldConst()]
        public float Angle;
        
        [Sirenix.OdinInspector.FoldoutGroup("Radius")]
        [FieldConst()]
        public float MinRadius;
        
        [Sirenix.OdinInspector.FoldoutGroup("Radius")]
        [FieldConst()]
        public float MaxRadius;
        
        [Sirenix.OdinInspector.FoldoutGroup("Sorting")]
        [FieldConst()]
        public byte SortingMethod;
        
        public FSkill_EffectClass_Range()
        {
        }
    }
}
/*
native function CalcOffsetLocation(out Vector outLocation,out Rotator outRotation);
final event DrawStaticDebugInfo(Game_Pawn aPawn,Vector aLocation) {
local Vector lLeft;
local Vector lRight;
local Rotator lRotation;
local float oldYaw;
CalcOffsetLocation(aLocation,aPawn.Rotation);                               
lRotation = aPawn.Rotation;                                                 
oldYaw = lRotation.Yaw;                                                     
lRotation.Yaw = oldYaw + static.ConvertDegreesToURU(RotationOffset + Angle / 2);
lRight = vector(lRotation) * MaxRadius + aLocation;                         
lRotation.Yaw = oldYaw + static.ConvertDegreesToURU(RotationOffset - Angle / 2);
lLeft = vector(lRotation) * MaxRadius + aLocation;                          
aPawn.DrawDebugLine(aLocation,lLeft,255,255,255);                           
aPawn.DrawDebugLine(aLocation,lRight,255,255,255);                          
aPawn.DrawDebugCapsule(aLocation,MaxRadius * 2,MinRadius,16,155,0);         
aPawn.DrawDebugSphere(aLocation,MaxRadius,16,220,220,0);                    
}
*/
