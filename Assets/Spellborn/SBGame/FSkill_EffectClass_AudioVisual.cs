using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_AudioVisual : FSkill_EffectClass
    {
        public const int INFINITE_EFFECT_DURATION = -1;

        [FoldoutGroup("DefaultTiming")]
        [FieldConst()]
        public float InitialDelayDuration;

        [FoldoutGroup("DefaultTiming")]
        [FieldConst()]
        public float IntroDuration;

        [FoldoutGroup("DefaultTiming")]
        [FieldConst()]
        public float OutroDuration;

        [FoldoutGroup("DefaultTiming")]
        [FieldConst()]
        public float RunningDuration;

        [FoldoutGroup("DefaultPriority")]
        [FieldConst()]
        public int Priority;

        public FSkill_EffectClass_AudioVisual()
        {
        }

        [Serializable] public struct RunningEffectData
        {
            public int Handle;

            public int ServerSideHandle;

            public float RunningTime;

            public float StateRunningTime;

            public FSkill_EffectClass_AudioVisual effect;

            public float InitialDelayDuration;

            public float IntroDuration;

            public float RunningDuration;

            public float OutroDuration;

            public byte EffectState;

            public float ProceduralAmplitude;

            public float SequenceAmplitude;

            public float Amplitude;

            public int Priority;

            public int UserData;

            public int InstanceData;

            public UObject InstanceDataObject;

            public bool WantsClientTick;

            public int Next;
        }

        public enum EAVEffectState
        {
            AVES_Init,

            AVES_InitialDelay,

            AVES_Intro,

            AVES_Running,

            AVES_Outro,

            AVES_DeInit,
        }
    }
}