using System;

namespace Engine
{
    [Serializable] public class ReachSpec : UObject
    {
        public int Distance;

        [FieldConst()]
        public NavigationPoint Start;

        [FieldConst()]
        public NavigationPoint End;

        public int CollisionRadius;

        public int CollisionHeight;

        public ReachSpec()
        {
        }
    }
}