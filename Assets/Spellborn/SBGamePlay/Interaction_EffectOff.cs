using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Interaction_EffectOff : Interaction_Component
    {
        [FoldoutGroup("Interaction_EffectOff")]
        public NameProperty EffectTag;

        public Interaction_EffectOff()
        {
        }
    }
}
/*
function ClOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local InteractiveLevelElement ile;
Super.ClOnStart(aOwner,aInstigator,aReverse);                               
ile = InteractiveLevelElement(aOwner);                                      
if (ile != None) {                                                          
if (!aReverse) {                                                          
ile.cl_StopTaggedEffects(EffectTag);                                    
}
}
}
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local InteractiveLevelElement ile;
Super.SvOnStart(aOwner,aInstigator);                                        
if (!aReverse) {                                                            
ile = InteractiveLevelElement(aOwner);                                    
ile.sv_StartClientSubAction();                                            
}
}
*/