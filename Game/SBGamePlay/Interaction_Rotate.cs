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
using SBGame;


namespace SBGamePlay
{


    public class Interaction_Rotate : Interaction_Component
    {
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
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
