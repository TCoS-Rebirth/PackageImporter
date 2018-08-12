using System;

namespace Engine
{
    [Serializable] public class AIMarker : SmallNavigationPoint
    {
        public AIScript markedScript;

        public AIMarker()
        {
        }
    }
}