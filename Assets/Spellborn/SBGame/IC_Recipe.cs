using System;
using System.Collections.Generic;
using Engine;

namespace SBGame
{
    [Serializable] public class IC_Recipe : Item_Component
    {
        [FieldConst()]
        public List<RecipeComponent> Components = new List<RecipeComponent>();

        [FieldConst()]
        public List<RecipeComponent> RecycleComponents = new List<RecipeComponent>();

        [FieldConst()]
        public Item_Type ProducedItem;

        public IC_Recipe()
        {
        }

        [Serializable] public struct RecipeComponent
        {
            public Item_Type Item;

            public int Quantity;
        }
    }
}
/*
final event int GetCraftPrice() {
return ProducedItem.GetSellValue() * 0.25000000;                            
}
*/