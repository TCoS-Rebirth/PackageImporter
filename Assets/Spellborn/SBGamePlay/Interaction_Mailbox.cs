using System;
using SBGame;

namespace SBGamePlay
{
    [Serializable] public class Interaction_Mailbox : Interaction_Component
    {
        public Interaction_Mailbox()
        {
        }
    }
}
/*
function ClOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
Super.ClOnStart(aOwner,aInstigator,aReverse);                               
if (aInstigator != None) {                                                  
if (!aReverse) {                                                          
if (aInstigator.IsLocalPlayer()) {                                      
Game_PlayerController(aInstigator.Controller).Player.GUIDesktop.ShowStdWindow(Class'GUI_BaseDesktop'.52,Class'GUI_BaseDesktop'.1);
}
}
}
}
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local InteractiveLevelElement ile;
Super.SvOnStart(aOwner,aInstigator,aReverse);                               
ile = InteractiveLevelElement(aOwner);                                      
if (ile != None) {                                                          
if (!aReverse) {                                                          
ile.sv_StartClientSubAction();                                          
}
}
}
*/