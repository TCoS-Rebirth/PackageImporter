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
    
    
    public class Interaction_Rotate : Interaction_Component
    {
        
        [IgnoreFieldExtraction()]
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
