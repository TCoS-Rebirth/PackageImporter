using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class AnimNotify_Sound : AnimNotify
    {
        [FoldoutGroup("AnimNotify_Sound")]
        public float Volume;

        [FoldoutGroup("AnimNotify_Sound")]
        public int Radius;

        public AnimNotify_Sound()
        {
        }
    }
}