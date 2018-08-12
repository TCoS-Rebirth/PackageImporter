using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class SubActionTrigger : MatSubAction
    {
        [FoldoutGroup("Trigger")]
        public NameProperty EventName;

        public SubActionTrigger()
        {
        }
    }
}