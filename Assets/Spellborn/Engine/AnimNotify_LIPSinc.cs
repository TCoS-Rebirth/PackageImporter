using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class AnimNotify_LIPSinc : AnimNotify
    {
        [FoldoutGroup("AnimNotify_LIPSinc")]
        public NameProperty LIPSincAnimName;

        [FoldoutGroup("AnimNotify_LIPSinc")]
        public float Volume;

        [FoldoutGroup("AnimNotify_LIPSinc")]
        public int Radius;

        [FoldoutGroup("AnimNotify_LIPSinc")]
        public float Pitch;

        public AnimNotify_LIPSinc()
        {
        }
    }
}