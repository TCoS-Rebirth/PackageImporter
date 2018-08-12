using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class AnimNotify_Trigger : AnimNotify_Scripted
    {
        [FoldoutGroup("AnimNotify_Trigger")]
        public NameProperty EventName;

        public AnimNotify_Trigger()
        {
        }
    }
}
/*
event Notify(Actor Owner) {
Owner.TriggerEvent(EventName,Owner,Pawn(Owner));                            
}
*/