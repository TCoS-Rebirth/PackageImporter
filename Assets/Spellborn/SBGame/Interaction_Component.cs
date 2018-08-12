using System;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Interaction_Component : Content_API
    {
        [FoldoutGroup("Interaction")]
        public bool Reverse;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool mCancel;

        public Interaction_Component()
        {
        }
    }
}
/*
function ClOnCancel(Game_Actor aOwner,Game_Pawn aInstigator) {
mCancel = True;                                                             
}
function ClOnEnd(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
}
function ClOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
mCancel = False;                                                            
}
event SvOnCancel(Game_Actor aOwner,Game_Pawn aInstigator) {
mCancel = True;                                                             
}
event SvOnEnd(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
}
event SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,optional bool aReverse) {
mCancel = False;                                                            
}
*/