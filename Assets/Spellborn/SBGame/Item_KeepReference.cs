using System;
using System.Collections.Generic;
using Engine;

namespace SBGame
{
    [Serializable] public class Item_KeepReference : UObject
    {
        public List<Item_Type> AllItems = new List<Item_Type>();

        public Item_KeepReference()
        {
        }
    }
}