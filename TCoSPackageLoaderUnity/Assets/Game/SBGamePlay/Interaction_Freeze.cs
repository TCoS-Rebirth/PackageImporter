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
    
    
    public class Interaction_Freeze : Interaction_Component
    {
        
        [FieldCategory(Category="Interaction_Freeze")]
        public bool Freeze;
        
        [FieldCategory(Category="Interaction_Freeze")]
        public bool FreezeMovement;
        
        [FieldCategory(Category="Interaction_Freeze")]
        public bool FreezeRotation;
        
        [FieldCategory(Category="Interaction_Freeze")]
        public bool FreezeAnimation;
        
        public Interaction_Freeze()
        {
        }
    }
}
/*
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
Super.SvOnStart(aOwner,aInstigator,aReverse);                               
if (!aReverse) {                                                            
DoFreeze(aInstigator,Freeze);                                             
} else {                                                                    
DoFreeze(aInstigator,!Freeze);                                            
}
}
protected function DoFreeze(Game_Pawn aInstigator,bool aFreeze) {
if (FreezeMovement) {                                                       
aInstigator.CharacterStats.FreezeMovement(aFreeze);                       
}
if (FreezeRotation) {                                                       
aInstigator.CharacterStats.FreezeRotation(aFreeze);                       
}
if (FreezeAnimation) {                                                      
aInstigator.CharacterStats.FreezeAnimation(aFreeze);                      
}
}
*/
