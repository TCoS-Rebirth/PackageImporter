using System;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_Type_BodySlot : FSkill_Type
    {
        [FoldoutGroup("BodySlot")]
        public bool IsPlayerStartable;

        public FSkill_Type_BodySlot()
        {
        }
    }
}