using System;
using System.Collections.Generic;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class NS_Rotator : NPC_StatTable
    {
        [FoldoutGroup("stat")]
        public List<byte> Rotation = new List<byte>();

        [FoldoutGroup("stat")]
        public int DefaultBody;

        [FoldoutGroup("stat")]
        public int DefaultMind;

        [FoldoutGroup("stat")]
        public int DefaultFocus;

        [FoldoutGroup("stat")]
        public int Hitpoints;

        [FoldoutGroup("stat")]
        public int HpPerLevel;

        public NS_Rotator()
        {
        }

        public enum ERotStatPriority
        {
            ERSP_Body,

            ERSP_Focus,

            ERSP_Mind,
        }
    }
}
/*
protected function int GetPointsForStat(int aLevel,byte aStat) {
local int totalPoints;
local int i;
local int ret;
ret = 0;                                                                    
totalPoints = PointsAtLevel(aLevel);                                        
if (Rotation.Length != 0) {                                                 
i = 0;                                                                    
while (i < totalPoints) {                                                 
if (Rotation[i % Rotation.Length] == aStat) {                           
ret += PointsMultiplier;                                              
}
i++;                                                                    
}
}
return ret;                                                                 
}
function int GetFocus(int aLevel) {
return DefaultFocus + GetPointsForStat(aLevel,1);                           
}
function int GetMind(int aLevel) {
return DefaultMind + GetPointsForStat(aLevel,2);                            
}
function int GetBody(int aLevel) {
return DefaultBody + GetPointsForStat(aLevel,0);                            
}
function int GetHitpointsPerLevel(int aLevel) {
return HpPerLevel;                                                          
}
function int GetBaseHitpoints(int aLevel) {
return Hitpoints;                                                           
}
*/