using System;
using System.Collections.Generic;
using Engine;
using SBBase;

namespace SBAI
{
    [Serializable] public class HormoneComponent : Base_Component
    {
        public List<Hormone> Hormones = new List<Hormone>();

        public List<HormoneSynergy> Synergies = new List<HormoneSynergy>();

        [FieldConst()]
        public float cPulseTime;

        public float PulseTimer;

        [FieldConst()]
        public float cPhaseTime;

        public bool bTrace;

        public List<float> TraceLevel = new List<float>();

        public HormoneComponent()
        {
        }

        [Serializable] public struct HormoneSynergy
        {
            public int FromIndex;

            public int ToIndex;

            public float Rate;
        }

        [Serializable] public struct Hormone
        {
            public NameProperty Tag;

            public float mLevel;

            public float Rate;

            public float Intensity;

            public byte signal;
        }
    }
}
/*
protected native function float DeltaValue(float aValue,float aRate);
native function AdjustHormone(name aTag,float aRate);
*/