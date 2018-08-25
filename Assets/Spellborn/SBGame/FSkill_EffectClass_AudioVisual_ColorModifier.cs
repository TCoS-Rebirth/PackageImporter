using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Color = Engine.Color;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_AudioVisual_ColorModifier : FSkill_EffectClass_AudioVisual
    {
        [FoldoutGroup("ColorModifier")]
        [NonSerialized, HideInInspector]
        public Color MultipliedColor;

        [FoldoutGroup("ColorModifier")]
        public float PulseDuration;

        [FoldoutGroup("AmbientGlow")]
        public bool PulseStartsAtPeak;

        public FSkill_EffectClass_AudioVisual_ColorModifier()
        {
        }
    }
}