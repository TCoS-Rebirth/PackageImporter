using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class AnnotationActor : SBPoint
    {
        [FoldoutGroup("Annotation")]
        public byte AnnotationType;

        [FoldoutGroup("Annotation")]
        public bool CreateNode;

        [FoldoutGroup("Annotation")]
        public Vector Extent;

        [FoldoutGroup("Annotation")]
        public bool FitNode;

        [FoldoutGroup("Annotation")]
        public List<byte> AnnotationMask = new List<byte>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int OriginCell;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool AccessmapLinked;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int mInstances;

        public AnnotationActor()
        {
        }
    }
}