using System;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class IC_Consumable : Item_Component
    {
        [FoldoutGroup("Consumable")]
        public byte Type;

        public IC_Consumable()
        {
        }

        public enum IC_ConsumableType
        {
            ICT_Food,

            ICT_Drink,

            ICT_Potion,
        }
    }
}