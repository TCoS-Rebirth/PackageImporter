using System;
using Engine;
using SBGame;
using UnityEngine;

namespace SBGamePlay
{
    [Serializable] public class Interaction_RotateToFace : Interaction_Component
    {
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Rotator OriginalOrientation;

        public Interaction_RotateToFace()
        {
        }
    }
}
/*
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local Rotator Orientation;
Super.SvOnStart(aOwner,aInstigator,aReverse);                               
if (!aReverse) {                                                            
OriginalOrientation = aInstigator.Rotation;                               
Orientation = rotator(aOwner.Location - aInstigator.Location);            
if (aInstigator.Physics == 1) {                                           
Orientation.Pitch = 0;                                                  
Orientation.Roll = 0;                                                   
}
aInstigator.sv_RotateToOrientation(Orientation);                          
} else {                                                                    
aInstigator.sv_RotateToOrientation(OriginalOrientation);                  
}
}
*/