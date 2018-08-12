using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class AnimNotify_FSkill : AnimNotify
    {
        [FoldoutGroup("AnimNotify_FSkill")]
        public NameProperty KeyFrameName;

        public AnimNotify_FSkill()
        {
        }
    }
}