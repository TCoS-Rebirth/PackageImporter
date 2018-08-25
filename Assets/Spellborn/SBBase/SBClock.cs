﻿using System;
using Engine;
using UnityEngine;

namespace SBBase
{
    [Serializable] public class SBClock : Base_Component
    {
        private int mReplicatedRealWorldTime;

        private int mCurrentRealWorldTime;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int mSBTime;

        private float mLastUpdate;

        private int mInitialUpdatePerformed;

        private float mTimeSpeedUpFactor;

        private int mTimeDelta;

        public SBClock()
        {
        }

        public enum EDayTime
        {
            EDT_Night,

            EDT_Morning,

            EDT_Afternoon,

            EDT_Evening,
        }
    }
}
/*
function string NaturalFormat(float aRelativeTimeOfDay) {
local int hours;
local int minutes;
minutes = aRelativeTimeOfDay * 24 * 60;                                     
hours = minutes / 60;                                                       
minutes -= hours * 60;                                                      
if (minutes > 10) {                                                         
return "" $ string(hours) $ ":" $ string(minutes);                        
} else {                                                                    
return "" $ string(hours) $ ":0" $ string(minutes);                       
}
}
event float SetFixedRelativeTimeOfDay(float aFixedRelativeTimeOfDay) {
if (aFixedRelativeTimeOfDay < 0) {                                          
Outer.mFixedRelativeTimeOfDay = -1.00000000;                              
} else {                                                                    
Outer.mFixedRelativeTimeOfDay = FClamp(aFixedRelativeTimeOfDay,0.00000000,0.99900001);
}
return Outer.mFixedRelativeTimeOfDay;                                       
}
event SetTimeSpeedUpFactor(float aSpeedUpFactor) {
mTimeSpeedUpFactor = aSpeedUpFactor;                                        
}
native function byte GetTimeOfDay();
function int GetCurrentTime() {
return mCurrentRealWorldTime;                                               
}
native function string GetFormatted(string aFormat);
native function float GetRelativeTimeOfDay();
native event cl_OnUpdate();
native event cl_OnFrame(float delta);
*/