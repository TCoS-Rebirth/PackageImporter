﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using TCosReborn.Framework.Common;


namespace SBBase
{


    public class SBRoute : SBPackageResource
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