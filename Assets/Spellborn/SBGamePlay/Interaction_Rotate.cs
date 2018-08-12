using System;
using Engine;
using SBGame;
using UnityEngine;

namespace SBGamePlay
{
    [Serializable] public class Interaction_Rotate : Interaction_Component
    {
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Rotator OriginalOrientation;

        public Interaction_Rotate()
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
OriginalOrientation = aInstigator.Rotation;                             
aInstigator.sv_RotateToOrientation(ile.AbsRotation);                    
} else {                                                                  
aInstigator.sv_RotateToOrientation(OriginalOrientation);                
}
}
}
*/