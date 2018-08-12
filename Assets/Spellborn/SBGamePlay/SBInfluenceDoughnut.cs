using System;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGamePlay
{
    [Serializable] public class SBInfluenceDoughnut : SBInfluenceVolume
    {
        [FoldoutGroup("SBInfluenceDoughnut")]
        public float DoughnutRadius;

        [FoldoutGroup("SBInfluenceDoughnut")]
        public float MaximumRadius;

        [FoldoutGroup("SBInfluenceDoughnut")]
        public float HotspotFactor;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float HsRadiusSquared;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float MaxRadiusSquared;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float InvFactor;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float DoughnutRadiusSquared;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Vector planeNormal;

        public SBInfluenceDoughnut()
        {
        }
    }
}