using System;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_AudioVisual_AmbientGlow : FSkill_EffectClass_AudioVisual
    {
        [FoldoutGroup("AmbientGlow")]
        public byte AmbientGlow;

        [FoldoutGroup("AmbientGlow")]
        public float PulseDuration;

        [FoldoutGroup("AmbientGlow")]
        public bool PulseStartsAtPeak;

        public FSkill_EffectClass_AudioVisual_AmbientGlow()
        {
        }
    }
}