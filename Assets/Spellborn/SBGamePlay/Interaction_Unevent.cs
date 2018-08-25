using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Interaction_Unevent : Interaction_Component
    {
        [FoldoutGroup("Interaction_Unevent")]
        public NameProperty EventTag;

        public Interaction_Unevent()
        {
        }
    }
}
/*
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
Super.SvOnStart(aOwner,aInstigator,aReverse);                               
if (!aReverse) {                                                            
aOwner.UntriggerEvent(EventTag,aOwner,aInstigator);                       
} else {                                                                    
aOwner.TriggerEvent(EventTag,aOwner,aInstigator);                         
}
}
*/