using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class NS_Fixed : NPC_StatTable
    {
        [FoldoutGroup("Stats")]
        public int Body;

        [FoldoutGroup("Stats")]
        public int Mind;

        [FoldoutGroup("Stats")]
        public int Focus;

        [FoldoutGroup("Stats")]
        public int Hitpoints;

        public NS_Fixed()
        {
        }
    }
}
/*
function int GetFocus(int aLevel) {
return Focus;                                                               
}
function int GetMind(int aLevel) {
return Mind;                                                                
}
function int GetBody(int aLevel) {
return Body;                                                                
}
function int GetHitpointsPerLevel(int aLevel) {
return 0;                                                                   
}
function int GetBaseHitpoints(int aLevel) {
return Hitpoints;                                                           
}
*/