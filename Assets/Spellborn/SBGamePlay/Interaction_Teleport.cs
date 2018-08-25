using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Interaction_Teleport : Interaction_Component
    {
        [FoldoutGroup("Interaction_Teleport")]
        public int DestinationWorld;

        [FoldoutGroup("Interaction_Teleport")]
        public string Parameter = string.Empty;

        [FoldoutGroup("Interaction_Teleport")]
        public bool IsInstance;

        public Interaction_Teleport()
        {
        }
    }
}
/*
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
Super.SvOnStart(aOwner,aInstigator);                                        
if (!aReverse) {                                                            
TeleportPawn(aInstigator,DestinationWorld,IsInstance,Parameter);          
}
}
*/