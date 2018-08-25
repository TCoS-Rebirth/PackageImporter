using System;
using SBGame;

namespace SBGamePlay
{
    [Serializable] public class Interaction_Quest : Interaction_Component
    {
        public Interaction_Quest()
        {
        }
    }
}
/*
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local InteractiveLevelElement ile;
Super.SvOnStart(aOwner,aInstigator);                                        
if (aInstigator != None) {                                                  
if (!aReverse) {                                                          
ile = InteractiveLevelElement(aOwner);                                  
Game_Controller(aInstigator.Controller).sv_FireHook(Class'Content_Type'.3,ile,ile.GetActiveMenuOption(aInstigator));
}
}
}
*/