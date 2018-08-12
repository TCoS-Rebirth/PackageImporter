using System;

namespace Engine
{
    [Serializable] public struct Color
    {

        public byte B;

        public byte G;

        public byte R;

        public byte A;

        public Color (byte r, byte g, byte b, byte a) { R = r;G = g;B = b;A = a; }
    }
}