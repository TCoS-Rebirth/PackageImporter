using System;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_AudioVisual_CameraLight : FSkill_EffectClass_AudioVisual_Camera
    {
        [FoldoutGroup("CameraLight")]
        public float SunlightsBrightness;

        public FSkill_EffectClass_AudioVisual_CameraLight()
        {
        }
    }
}