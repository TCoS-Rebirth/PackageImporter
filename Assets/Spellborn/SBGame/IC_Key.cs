using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class IC_Key : Item_Component
    {
        [FoldoutGroup("Key")]
        [FieldConst()]
        public string UnlockTag = string.Empty;

        public IC_Key()
        {
        }
    }
}