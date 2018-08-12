using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_AudioVisual_CameraBlur : FSkill_EffectClass_AudioVisual_Camera
    {
        [FoldoutGroup("CameraBlur")]
        [FieldConst()]
        public float BlurAmount;

        public FSkill_EffectClass_AudioVisual_CameraBlur()
        {
        }
    }
}