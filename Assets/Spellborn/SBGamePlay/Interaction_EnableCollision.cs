using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Interaction_EnableCollision : Interaction_Component
    {
        [FoldoutGroup("Interaction_EnableCollision")]
        public bool EnableCollision;

        public Interaction_EnableCollision()
        {
        }
    }
}
/*
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
Super.SvOnStart(aOwner,aInstigator,aReverse);                               
if (aOwner != None) {                                                       
if (!aReverse) {                                                          
aOwner.sv_SetCollision(EnableCollision);                                
} else {                                                                  
aOwner.sv_SetCollision(!EnableCollision);                               
}
}
}
*/