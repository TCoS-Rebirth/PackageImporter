using System;
using Engine;

namespace Gameplay
{
    [Serializable] public class TriggeredCondition: Triggers
    {
        public bool bTriggerControlled;
        public bool bToggled;
    }
}
