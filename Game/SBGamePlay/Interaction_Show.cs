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


    public class Interaction_Show : Interaction_Component
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Interaction_Show")]
        public bool Show;
        
        public Interaction_Show()
        {
        }
    }
}
/*
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local InteractiveLevelElement ile;
Super.SvOnStart(aOwner,aInstigator,aReverse);                               
ile = InteractiveLevelElement(aOwner);                                      
if (ile != None) {                                                          
if (!aReverse) {                                                          
ile.sv_Show(Show);                                                      
} else {                                                                  
ile.sv_Show(!Show);                                                     
}
}
}
*/
