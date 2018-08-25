using System;
using System.Collections.Generic;
using Engine;

namespace SBBase
{
    [Serializable] public class SBTravel : UObject
    {
        public string Tag = string.Empty;

        public List<SBRoute> Routes = new List<SBRoute>();

        public SBTravel()
        {
        }
    }
}