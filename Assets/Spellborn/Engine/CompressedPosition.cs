using System;

namespace Engine
{
    [Serializable] public struct CompressedPosition
    {

        public Vector Location;

        public Rotator Rotation;

        public Vector Velocity;
    }
}