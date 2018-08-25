using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Interaction_Enable : Interaction_Component
    {
        [FoldoutGroup("Interaction_Enable")]
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