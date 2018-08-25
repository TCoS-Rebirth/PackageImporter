using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGamePlay
{
    [Serializable] public class Interaction_RandomTimer : Interaction_Component
    {
        [FoldoutGroup("Interaction_RandomTimer")]
        public Range RangeSeconds;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float mTimer;

        public Interaction_RandomTimer()
        {
        }
    }
}
/*
function ClOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
Super.ClOnStart(aOwner,aInstigator,aReverse);                               
}
function SvOnCancel(Game_Actor aOwner,Game_Pawn aInstigator) {
Super.SvOnCancel(aOwner,aInstigator);                                       
mTimer = 0.00000000;                                                        
}
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
Super.SvOnStart(aOwner,aInstigator,aReverse);                               
if (!aReverse) {                                                            
mTimer = RangeSeconds.Min + FRand() * (RangeSeconds.Max - RangeSeconds.Min);
}
}
*/