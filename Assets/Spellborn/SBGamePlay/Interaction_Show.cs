using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Interaction_Show : Interaction_Component
    {
        [FoldoutGroup("Interaction_Show")]
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