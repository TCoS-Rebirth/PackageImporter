using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_DuffGfx : FSkill_EffectClass_Duff
    {
        [FoldoutGroup("FX")]
        [FieldConst()]
        public FSkill_EffectClass_AudioVisual TargetFX;

        public FSkill_EffectClass_DuffGfx()
        {
        }
    }
}