using System;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;
using Color = Engine.Color;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_AudioVisual_CameraFog : FSkill_EffectClass_AudioVisual_Camera
    {
        [FoldoutGroup("CameraFog")]
        [FieldConst()]
        public float FogColorAmount;

        [FoldoutGroup("CameraFog")]
        [FieldConst()]
        [NonSerialized, HideInInspector]
        public Color FogColor;

        [FoldoutGroup("CameraFog")]
        [FieldConst()]
        public float FogDensity;

        public FSkill_EffectClass_AudioVisual_CameraFog()
        {
        }
    }
}