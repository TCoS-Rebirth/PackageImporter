﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using SBGame;


namespace SBGamePlay
{


    public class Interaction_Enable : Interaction_Component
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Interaction_Enable")]
        public bool Enabled;
        
        public Interaction_Enable()
        {
        }
    }
}
/*
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,optional bool aReverse) {
local InteractiveLevelElement ile;
Super.SvOnStart(aOwner,aInstigator);                                        
ile = InteractiveLevelElement(aOwner);                                      
if (ile != None) {                                                          
if (!aReverse) {                                                          
ile.sv_SetEnabled(Enabled);                                             
} else {                                                                  
ile.sv_SetEnabled(!Enabled);                                            
}
}
}
*/
