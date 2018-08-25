using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class NPC_StatTable : Content_Type
    {
        [FoldoutGroup("Preview")]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int PreviewLevel;

        [FoldoutGroup("Preview")]
        [FieldConst()]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<StatPreview> Preview = new List<StatPreview>();

        [FoldoutGroup("stat")]
        public int BasePoints;

        [FoldoutGroup("stat")]
        public int LevelPerPoints;

        [FoldoutGroup("stat")]
        public int PointsMultiplier;

        public NPC_StatTable()
        {
        }

        [Serializable] public struct StatPreview
        {
            public int B;

            public int M;

            public int F;
        }
    }
}
/*
protected event MakePreview() {
local int i;
Preview.Length = PreviewLevel;                                              
i = 0;                                                                      
while (i < Preview.Length) {                                                
Preview[i].B = GetBody(i);                                                
Preview[i].M = GetMind(i);                                                
Preview[i].F = GetFocus(i);                                               
i++;                                                                      
}
}
protected function int PointsAtLevel(int aLevel) {
return BasePoints + aLevel / LevelPerPoints;                                
}
function int GetFocus(int aLevel) {
return 0;                                                                   
}
function int GetMind(int aLevel) {
return 0;                                                                   
}
function int GetBody(int aLevel) {
return 0;                                                                   
}
function int GetHitpointsPerLevel(int aLevel) {
return 10;                                                                  
}
function int GetBaseHitpoints(int aLevel) {
return 100;                                                                 
}
*/