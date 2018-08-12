using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class AnimNotify_MatSubAction : AnimNotify
    {
        [FoldoutGroup("AnimNotify_MatSubAction")]
        public MatSubAction SubAction;

        public AnimNotify_MatSubAction()
        {
        }
    }
}