using System;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Appearance_LeftGlove : Appearance_Base
    {
        [FoldoutGroup("Sections")]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool UseOnLeftHand;

        [FoldoutGroup("Sections")]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool UseOnLeftArmLower;

        public Appearance_LeftGlove()
        {
        }
    }
}