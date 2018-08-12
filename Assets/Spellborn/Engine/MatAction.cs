using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Engine
{
    [Serializable] public class MatAction : MatObject
    {
        [FoldoutGroup("MatAction")]
        public InterpolationPoint IntPoint;

        [FoldoutGroup("MatAction")]
        public string Comment = string.Empty;

        [FoldoutGroup("Time")]
        public float Duration;

        [FoldoutGroup("Sub")]
        public List<MatSubAction> SubActions = new List<MatSubAction>();

        [FoldoutGroup("Path")]
        public bool bSmoothCorner;

        [FoldoutGroup("Path")]
        public Vector StartControlPoint;

        [FoldoutGroup("Path")]
        public Vector EndControlPoint;

        [FoldoutGroup("Path")]
        public bool bConstantPathVelocity;

        [FoldoutGroup("Path")]
        public float PathVelocity;

        public float PathLength;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<Vector> SampleLocations = new List<Vector>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float PctStarting;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float PctEnding;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float PctDuration;

        public MatAction()
        {
        }
    }
}