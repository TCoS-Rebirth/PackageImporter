using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_DirectShapeShift : FSkill_EffectClass_Direct
    {
        [FoldoutGroup("ShapeShift")]
        [FieldConst()]
        public NPC_Type Shape;

        [FieldConst()]
        public FSkill_ValueSpecifier _ShapeShiftValue;

        public FSkill_EffectClass_DirectShapeShift()
        {
        }
    }
}