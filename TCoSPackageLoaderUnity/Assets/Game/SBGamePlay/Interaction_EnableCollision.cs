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
    
    
    public class Interaction_EnableCollision : Interaction_Component
    {
        
        [FieldCategory(Category="Interaction_EnableCollision")]
        public bool EnableCollision;
        
        public Interaction_EnableCollision()
        {
        }
    }
}
/*
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
Super.SvOnStart(aOwner,aInstigator,aReverse);                               
if (aOwner != None) {                                                       
if (!aReverse) {                                                          
aOwner.sv_SetCollision(EnableCollision);                                
} else {                                                                  
aOwner.sv_SetCollision(!EnableCollision);                               
}
}
}
*/
