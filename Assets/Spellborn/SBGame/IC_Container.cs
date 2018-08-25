using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class IC_Container : Item_Component
    {
        [FoldoutGroup("ExtraInventory")]
        [FieldConst()]
        public int ContainerSlots;

        public IC_Container()
        {
        }
    }
}