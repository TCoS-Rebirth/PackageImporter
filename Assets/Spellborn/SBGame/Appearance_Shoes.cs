using System;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Appearance_Shoes : Appearance_Base
    {
        [FoldoutGroup("Sections")]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool UseOnFeet;

        [FoldoutGroup("Sections")]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool UseOnCalves;

        [FoldoutGroup("Sections")]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool UseOnThighs;

        public Appearance_Shoes()
        {
        }
    }
}