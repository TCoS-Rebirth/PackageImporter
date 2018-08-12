using System;

namespace Engine
{
    [Serializable] public class Scout : Pawn
    {
        [FieldConst()]
        public float MaxLandingVelocity;

        public Scout()
        {
        }
    }
}
/*
simulated function PreBeginPlay() {
}
*/