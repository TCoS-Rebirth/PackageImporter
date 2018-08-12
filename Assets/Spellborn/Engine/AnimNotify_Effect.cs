using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Engine
{
    [Serializable] public class AnimNotify_Effect : AnimNotify
    {
        [FoldoutGroup("AnimNotify_Effect")]
        [TypeProxyDefinition(TypeName = "Actor")]
        public Type EffectClass;

        [FoldoutGroup("AnimNotify_Effect")]
        public NameProperty Bone;

        [FoldoutGroup("AnimNotify_Effect")]
        public Vector OffsetLocation;

        [FoldoutGroup("AnimNotify_Effect")]
        public Rotator OffsetRotation;

        [FoldoutGroup("AnimNotify_Effect")]
        public bool Attach;

        [FoldoutGroup("AnimNotify_Effect")]
        public NameProperty Tag;

        [FoldoutGroup("AnimNotify_Effect")]
        public float DrawScale;

        [FoldoutGroup("AnimNotify_Effect")]
        public Vector DrawScale3D;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private Actor LastSpawnedEffect;

        public AnimNotify_Effect()
        {
        }
    }
}