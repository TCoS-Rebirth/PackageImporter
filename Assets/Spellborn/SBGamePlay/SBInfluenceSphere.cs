using System;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGamePlay
{
    [Serializable] public class SBInfluenceSphere : SBInfluenceVolume
    {
        [FoldoutGroup("SBInfluenceSphere")]
        public float MaximumRadius;

        [FoldoutGroup("SBInfluenceSphere")]
        public float HotspotFactor;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float HsRadiusSquared;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float MaxRadiusSquared;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float InvFadeDistanceSqr;

        public SBInfluenceSphere()
        {
        }
    }
}