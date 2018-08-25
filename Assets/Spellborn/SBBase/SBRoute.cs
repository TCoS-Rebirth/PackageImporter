using System;
using Engine;

namespace SBBase
{
    [Serializable] public class SBRoute : UObject
    {
        public LocalizedString ShardName;

        public SBWorld TravelWorld;

        public SBPortal TravelPortal;

        public SBWorld DestinationWorld;

        public SBPortal DestinationPortal;

        public bool AllowRentACabin;

        public int CrewCost;

        public int CabinCost;

        public string WorldPortalTag = string.Empty;

        public SBRoute()
        {
        }
    }
}