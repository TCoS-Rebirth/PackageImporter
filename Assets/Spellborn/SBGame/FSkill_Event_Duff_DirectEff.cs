using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_Event_Duff_DirectEff : UObject
    {
        [FieldConst()]
        public FSkill_EffectClass_Direct effect;

        [FoldoutGroup("DirectEff")]
        [FieldConst()]
        public float Interval;

        [FoldoutGroup("DirectEff")]
        [FieldConst()]
        public float Delay;

        [FoldoutGroup("DirectEff")]
        [FieldConst()]
        public int RepeatCount;

        [FieldConst()]
        public FSkill_Event_FX ExecuteFXEvent;

        public FSkill_Event_Duff_DirectEff()
        {
        }
    }
}