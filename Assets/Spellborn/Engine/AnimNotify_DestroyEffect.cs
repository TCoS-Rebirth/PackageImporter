using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class AnimNotify_DestroyEffect : AnimNotify
    {
        [FoldoutGroup("AnimNotify_DestroyEffect")]
        public NameProperty DestroyTag;

        [FoldoutGroup("AnimNotify_DestroyEffect")]
        public bool bExpireParticles;

        public AnimNotify_DestroyEffect()
        {
        }
    }
}