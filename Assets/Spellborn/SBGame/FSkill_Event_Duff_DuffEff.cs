using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_Event_Duff_DuffEff : UObject
    {
        [FieldConst()]
        public FSkill_EffectClass_Duff effect;

        [FoldoutGroup("DuffEff")]
        [FieldConst()]
        public float Interval;

        [FoldoutGroup("DuffEff")]
        [FieldConst()]
        public float Delay;

        [FoldoutGroup("DuffEff")]
        [FieldConst()]
        public int RepeatCount;

        [FieldConst()]
        public FSkill_Event_FX ExecuteFXEvent;

        public FSkill_Event_Duff_DuffEff()
        {
        }
    }
}