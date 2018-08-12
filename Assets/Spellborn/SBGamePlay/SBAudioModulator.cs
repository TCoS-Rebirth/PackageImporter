using System;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGamePlay
{
    [Serializable] public class SBAudioModulator : SBAudioModifier
    {
        public const float MIN_MOD_DAMP_VARIATION = 0.001F;

        public const float MIN_MOD_TIME_DELTA = 0.001F;

        [FoldoutGroup("SBAudioModulator")]
        public float ModTime;

        [FoldoutGroup("SBAudioModulator")]
        public float ModTimeDelta;

        [FoldoutGroup("SBAudioModulator")]
        public float ModTimeVariation;

        [FoldoutGroup("SBAudioModulator")]
        public float ModDamping;

        [FoldoutGroup("SBAudioModulator")]
        public float ModDampingVariation;

        [FoldoutGroup("SBAudioModulator")]
        public byte ModShape;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float ModulationFactor;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float DampTarget;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float ModulationTimerStart;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float ModulationTimerEnd;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float ModulationHelperFactor;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float lastUpdateTime;

        public SBAudioModulator()
        {
        }

        public enum ESBAudioModulationShape
        {
            SBModShape_Linear,

            SBModShape_Sinusoidal,
        }
    }
}