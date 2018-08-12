using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Interaction_Freeze : Interaction_Component
    {
        [FoldoutGroup("Interaction_Freeze")]
        public bool Freeze;

        [FoldoutGroup("Interaction_Freeze")]
        public bool FreezeMovement;

        [FoldoutGroup("Interaction_Freeze")]
        public bool FreezeRotation;

        [FoldoutGroup("Interaction_Freeze")]
        public bool FreezeAnimation;

        public Interaction_Freeze()
        {
        }
    }
}
/*
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
Super.SvOnStart(aOwner,aInstigator,aReverse);                               
if (!aReverse) {                                                            
DoFreeze(aInstigator,Freeze);                                             
} else {                                                                    
DoFreeze(aInstigator,!Freeze);                                            
}
}
protected function DoFreeze(Game_Pawn aInstigator,bool aFreeze) {
if (FreezeMovement) {                                                       
aInstigator.CharacterStats.FreezeMovement(aFreeze);                       
}
if (FreezeRotation) {                                                       
aInstigator.CharacterStats.FreezeRotation(aFreeze);                       
}
if (FreezeAnimation) {                                                      
aInstigator.CharacterStats.FreezeAnimation(aFreeze);                      
}
}
*/