using System;
using Engine;
using UnityEngine;

namespace SBBase
{
    [Serializable] public class SBPortal : UObject
    {
        public SBWorld TargetWorld;

        public SBPortal EntryPortal;

        public string Tag = string.Empty;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Actor LevelActor;

        public SBPortal()
        {
        }
    }
}