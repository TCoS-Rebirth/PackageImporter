using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class AnimNotify_Script : AnimNotify
    {
        [FoldoutGroup("AnimNotify_Script")]
        public NameProperty NotifyName;

        public AnimNotify_Script()
        {
        }
    }
}