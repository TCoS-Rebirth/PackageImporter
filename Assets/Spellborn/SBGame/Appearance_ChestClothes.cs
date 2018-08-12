using System;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Appearance_ChestClothes : Appearance_Base
    {
        [FoldoutGroup("Sections")]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool UseOnTorso;

        [FoldoutGroup("Sections")]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool UseOnRightArmUpper;

        [FoldoutGroup("Sections")]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool UseOnLeftArmUpper;

        [FoldoutGroup("Sections")]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool UseOnRightArmLower;

        [FoldoutGroup("Sections")]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool UseOnLeftArmLower;

        public Appearance_ChestClothes()
        {
        }
    }
}