using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class AnimNotify_SBSound : AnimNotify
    {
        [FoldoutGroup("AnimNotify_SBSound")]
        public int Radius;

        [FoldoutGroup("AnimNotify_SBSound")]
        public NameProperty MeshSoundPropertiesGroup;

        [FoldoutGroup("AnimNotify_SBSound")]
        public byte SoundType;

        public AnimNotify_SBSound()
        {
        }
    }
}