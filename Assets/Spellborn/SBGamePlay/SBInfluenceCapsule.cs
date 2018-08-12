using System;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGamePlay
{
    [Serializable] public class SBInfluenceCapsule : SBInfluenceVolume
    {
        [FoldoutGroup("SBInfluenceCapsule")]
        public float MaximumRadius;

        [FoldoutGroup("SBInfluenceCapsule")]
        public float AxisLength;

        [FoldoutGroup("SBInfluenceCapsule")]
        public float HotspotFactor;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float HsRadiusSquared;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float MaxRadiusSquared;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Vector AxisVector;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Vector AxisVectorStart;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float InvFactor;

        public SBInfluenceCapsule()
        {
        }
    }
}