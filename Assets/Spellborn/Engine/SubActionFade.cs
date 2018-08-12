using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Engine
{
    [Serializable] public class SubActionFade : MatSubAction
    {
        [FoldoutGroup("Fade")]
        [NonSerialized, HideInInspector]
        public Color FadeColor;

        [FoldoutGroup("Fade")]
        public bool bFadeOut;

        public SubActionFade()
        {
        }
    }
}