using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Interaction_Event : Interaction_Component
    {
        [FoldoutGroup("Interaction_Event")]
        public NameProperty EventTag;

        public Interaction_Event()
        {
        }
    }
}
/*
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
Super.SvOnStart(aOwner,aInstigator,aReverse);                               
if (!aReverse) {                                                            
aOwner.TriggerEvent(EventTag,aOwner,aInstigator);                         
} else {                                                                    
aOwner.UntriggerEvent(EventTag,aOwner,aInstigator);                       
}
}
*/