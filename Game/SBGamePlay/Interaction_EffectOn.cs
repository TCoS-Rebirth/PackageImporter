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
using System.Collections.Generic;


namespace SBGamePlay
{


    public class Interaction_EffectOn : Interaction_Component
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Interaction_EffectOn")]
        public string EffectTag = string.Empty;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Interaction_EffectOn")]
        public List<FSkill_EffectClass_AudioVisual> Effects = new List<FSkill_EffectClass_AudioVisual>();
        
        public Interaction_EffectOn()
        {
        }
    }
}
/*
function ClOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local InteractiveLevelElement ile;
local int ei;
Super.ClOnStart(aOwner,aInstigator,aReverse);                               
ile = InteractiveLevelElement(aOwner);                                      
if (ile != None) {                                                          
if (!aReverse) {                                                          
ei = 0;                                                                 
while (ei < Effects.Length) {                                           
if (Effects[ei] != None) {                                            
ile.cl_StartTaggedEffect(EffectTag,Effects[ei]);                    
}
ei++;                                                                 
}
} else {                                                                  
ile.cl_StopTaggedEffects(EffectTag);                                    
}
}
}
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local InteractiveLevelElement ile;
Super.SvOnStart(aOwner,aInstigator);                                        
ile = InteractiveLevelElement(aOwner);                                      
if (ile != None) {                                                          
ile.sv_StartClientSubAction();                                            
}
}
*/
