using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_AudioVisual_CameraAmbient : FSkill_EffectClass_AudioVisual_Camera
    {
        [FoldoutGroup("CameraAmbient")]
        [FieldConst()]
        public float AmbientAmount;

        [FoldoutGroup("CameraAmbient")]
        [FieldConst()]
        public byte AmbientBrightness;

        [FoldoutGroup("CameraAmbient")]
        [FieldConst()]
        public byte AmbientHue;

        [FoldoutGroup("CameraAmbient")]
        [FieldConst()]
        public byte AmbientSaturation;

        public FSkill_EffectClass_AudioVisual_CameraAmbient()
        {
        }
    }
}