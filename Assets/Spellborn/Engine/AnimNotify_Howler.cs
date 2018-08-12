using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class AnimNotify_Howler : AnimNotify
    {
        [FoldoutGroup("AnimNotify_Howler")]
        public bool bHide;

        public AnimNotify_Howler()
        {
        }
    }
}