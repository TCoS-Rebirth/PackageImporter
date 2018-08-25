using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class SubActionCameraEffect : MatSubAction
    {
        [FoldoutGroup("SubActionCameraEffect")]
        public string CameraEffect;

        [FoldoutGroup("SubActionCameraEffect")]
        public float StartAlpha;

        [FoldoutGroup("SubActionCameraEffect")]
        public float EndAlpha;

        [FoldoutGroup("SubActionCameraEffect")]
        public bool DisableAfterDuration;

        public SubActionCameraEffect()
        {
        }
    }
}