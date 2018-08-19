using System;
using UnityEngine;

namespace Engine
{
    [Serializable] public struct Vector
    {
        public float X;

        public float Y;

        public float Z;

        public Vector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static implicit operator Vector3(Vector v)
        {
            return Utilities.UnitConversion.ToUnity(v);
        }

        public static implicit operator Vector(Vector3 v)
        {
            return Utilities.UnitConversion.ToUnreal(v);
        }
    }
}