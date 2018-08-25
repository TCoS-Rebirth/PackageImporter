using System;
using UnityEngine;

namespace Engine
{
    [Serializable] public struct BoundingVolume
    {
        public Vector Min;
        public Vector Max;
        public byte IsValid;
        public Plane Sphere;
    }
}