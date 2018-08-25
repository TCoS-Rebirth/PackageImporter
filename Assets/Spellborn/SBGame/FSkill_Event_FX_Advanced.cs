using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
#pragma warning disable 414       

    [Serializable] public class FSkill_Event_FX_Advanced : FSkill_Event_FX
    {
        [FoldoutGroup("FX")]
        [FieldConst()]
        public List<AdvancedEmitter> Emitters = new List<AdvancedEmitter>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private List<FX_RunData> AdvRunData = new List<FX_RunData>();

        private int EmittersLeftToStart;

        public FSkill_Event_FX_Advanced()
        {
        }

        [Serializable] public struct AdvancedEmitter
        {
            public FSkill_EffectClass_AudioVisual_Emitter Emitter;

            public float Delay;

            public byte Location;
        }
    }
}