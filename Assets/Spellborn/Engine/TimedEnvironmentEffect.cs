using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class TimedEnvironmentEffect : EnvironmentEffect
    {
        [FoldoutGroup("Preview")]
        public float UpdateSpeed;

        public float UpdateTimer;

        [FoldoutGroup("Events")]
        public List<EventRange> Events = new List<EventRange>();

        public float mDefaultTime;

        public TimedEnvironmentEffect()
        {
        }

        [Serializable] public struct EventRange
        {
            public NameProperty Event;

            public NameProperty InRangeEvent;

            public NameProperty OutOfRangeEvent;

            public float RangeBeginTime;

            public float RangeEndTime;

            public int WasInRange;
        }
    }
}