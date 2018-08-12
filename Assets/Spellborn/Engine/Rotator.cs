using System;

namespace Engine
{
    [Serializable] public struct Rotator
    {
        public int Pitch;

        public int Yaw;

        public int Roll;

        public Rotator(int pitch, int yaw, int roll)
        {
            Pitch = pitch;
            Yaw = yaw;
            Roll = roll;
        }
    }
}