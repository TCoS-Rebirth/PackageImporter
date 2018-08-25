using System;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGamePlay
{
    [Serializable] public class SBInfluenceVolume : Actor
    {
        public const float SBVOLUME_MIN_DIMENSION = 0.0001F;

        [FoldoutGroup("SBInfluenceVolume")]
        public byte InfluenceFalloff;

        [FoldoutGroup("SBInfluenceVolume")]
        public int NrRenderedSides;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Box BoundingBox;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int HighlightCount;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int ShowDebugCount;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int OverlapCount;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Vector LastCheckPosition;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float CachedInfluenceWeight;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Vector CachedInfluenceLocation;

        public SBInfluenceVolume()
        {
        }

        public enum SBInfluence_Falloff
        {
            SBIF_Linear,

            SBIF_InvSquare,

            SBIF_Logarithmic,
        }
    }
}
/*
native function float GetInfluenceWeight(Vector positionToCheck);
*/