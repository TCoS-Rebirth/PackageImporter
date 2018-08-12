using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGamePlay
{
    [Serializable] public class Interaction_MovePlayer : Interaction_Component
    {
        [FoldoutGroup("Interaction_MovePlayer")]
        public float DistanceBeforeSnap;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private Vector mOriginalLocation;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private Vector mTargetLocation;

        public Interaction_MovePlayer()
        {
        }
    }
}
/*
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local InteractiveLevelElement ile;
Super.SvOnStart(aOwner,aInstigator,aReverse);                               
ile = InteractiveLevelElement(aOwner);                                      
if (aInstigator != None && ile != None) {                                   
if (!aReverse) {                                                          
mOriginalLocation = aInstigator.Location;                               
mTargetLocation = ile.AbsPosition;                                      
} else {                                                                  
mTargetLocation = mOriginalLocation;                                    
}
aInstigator.sv_MoveTo(mTargetLocation,None,DistanceBeforeSnap);           
}
}
*/