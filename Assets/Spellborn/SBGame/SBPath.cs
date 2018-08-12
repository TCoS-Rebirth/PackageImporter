using System;
using System.Collections.Generic;
using Engine;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class SBPath : UObject
    {
        public List<Vector> Path = new List<Vector>();

        public List<AnnotationActor> Annotations = new List<AnnotationActor>();

        public AnnotationActor ControlPoint;

        public bool Complete;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int PathIndex;

        public SBPath()
        {
        }
    }
}