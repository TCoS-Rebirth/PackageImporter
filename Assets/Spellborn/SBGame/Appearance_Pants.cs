using System;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Appearance_Pants : Appearance_Base
    {
        [FoldoutGroup("Sections")]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool UseOnPelvis;

        [FoldoutGroup("Sections")]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool UseOnThighs;

        [FoldoutGroup("Sections")]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool UseOnCalves;

        public Appearance_Pants()
        {
        }
    }
}