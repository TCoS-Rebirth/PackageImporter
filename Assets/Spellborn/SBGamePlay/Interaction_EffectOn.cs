using System;
using System.Collections.Generic;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Interaction_EffectOn : Interaction_Component
    {
        [FoldoutGroup("Interaction_EffectOn")]
        public NameProperty EffectTag;

        [FoldoutGroup("Interaction_EffectOn")]
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