using System;
using UnityEngine;

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

        public static implicit operator Quaternion(Rotator rot)
        {
            return Utilities.UnitConversion.ToUnreal(rot);
        }
    }
}