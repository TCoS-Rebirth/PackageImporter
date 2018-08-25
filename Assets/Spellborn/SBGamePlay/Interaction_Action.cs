using System;
using System.Collections.Generic;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Interaction_Action : Interaction_Component
    {
        [FoldoutGroup("Interaction_Action")]
        public List<Content_Event> Actions = new List<Content_Event>();

        public Interaction_Action()
        {
        }
    }
}
/*
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local int aI;
local bool doExecute;
Super.SvOnStart(aOwner,aInstigator);                                        
if (!aReverse) {                                                            
doExecute = True;                                                         
aI = 0;                                                                   
while (aI < Actions.Length) {                                             
if (Actions[aI] != None
&& !Actions[aI].sv_CanExecute(aInstigator,aInstigator)) {
doExecute = False;                                                    
goto jl0086;                                                          
}
aI++;                                                                   
}
if (doExecute) {                                                          
aI = 0;                                                                 
while (aI < Actions.Length) {                                           
if (Actions[aI] != None) {                                            
Actions[aI].sv_Execute(aInstigator,aInstigator);                    
}
aI++;                                                                 
}
}
}
}
*/