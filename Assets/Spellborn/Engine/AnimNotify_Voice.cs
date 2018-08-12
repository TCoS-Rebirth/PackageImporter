using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class AnimNotify_Voice : AnimNotify
    {
        [FoldoutGroup("AnimNotify_Voice")]
        public byte VoiceType;

        [FoldoutGroup("AnimNotify_Voice")]
        public int Radius;

        [FoldoutGroup("AnimNotify_Voice")]
        public NameProperty MeshSoundPropertiesGroup;

        public AnimNotify_Voice()
        {
        }
    }
}