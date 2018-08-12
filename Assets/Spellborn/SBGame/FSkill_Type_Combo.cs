using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_Type_Combo : FSkill_Type
    {
        [FoldoutGroup("Combo")]
        [FieldConst()]
        public byte OpenerComboType;

        public FSkill_Type_Combo()
        {
        }
    }
}