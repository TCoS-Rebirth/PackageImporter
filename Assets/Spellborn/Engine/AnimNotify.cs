using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Engine
{
    [Serializable] public class AnimNotify : UObject
    {
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int Revision;

        [FoldoutGroup("AnimNotify")]
        public bool AlwaysNotify;

        public AnimNotify()
        {
        }
    }
}