using System;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class FSkill_Event_FX : FSkill_Event
    {
        [FieldConst()]
        public Client_FX FX;

        [FoldoutGroup("FX")]
        [FieldConst()]
        public byte EmitterLocation;

        [FoldoutGroup("FX")]
        [FieldConst()]
        public bool ComboFinisherOnlyFX;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private FX_RunData RunData;

        public FSkill_Event_FX()
        {
        }

        [Serializable] public struct Client_FX
        {
            public FSkill_EffectClass_AudioVisual_Sound Sound;

            public FSkill_EffectClass_AudioVisual_CameraShake CameraShake;

            public FSkill_EffectClass_AudioVisual_Emitter Emitter;
        }

        [Serializable] public struct FX_RunData
        {
            public bool ExecutedFX;

            public Actor EmitterActor;
        }
    }
}