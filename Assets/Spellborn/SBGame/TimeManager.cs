using System;
using Engine;

namespace SBGame
{
    [Serializable] public class TimeManager : TimedEnvironmentEffect
    {
        public EnvironmentSettings mCurrentEnvironmentSettings;

        public TimeManager()
        {
        }
    }
}
/*
event PostBeginPlay() {
if (IsServer() || IsEditor()) {                                             
return;                                                                   
}
SetDrawType(0);                                                             
}
native event cl_OnFrame(float delta);
*/