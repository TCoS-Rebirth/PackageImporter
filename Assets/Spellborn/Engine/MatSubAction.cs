using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Engine
{
    [Serializable] public class MatSubAction : MatObject
    {
        [FoldoutGroup("Time")]
        public float Delay;

        [FoldoutGroup("Time")]
        public float Duration;

        public byte Status;

        public string Desc = string.Empty;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float PctStarting;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float PctEnding;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float PctDuration;

        public MatSubAction()
        {
        }

        public enum ESAStatus
        {
            SASTATUS_Waiting,

            SASTATUS_Running,

            SASTATUS_Ending,

            SASTATUS_Expired,
        }
    }
}