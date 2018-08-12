using System;

namespace Engine
{
    [Serializable] public struct Box
    {

        public Vector Min;

        public Vector Max;

        public byte IsValid;
    }
}