using System;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Appearance_RightGlove : Appearance_Base
    {
        [FoldoutGroup("Sections")]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool UseOnRightHand;

        [FoldoutGroup("Sections")]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool UseOnRightArmLower;

        public Appearance_RightGlove()
        {
        }
    }
}