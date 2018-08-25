using System;
using System.Collections.Generic;
using Engine;

namespace SBGame
{
    [Serializable] public class MapSectionInfoInstances : UObject
    {
        public List<MapSectionInfo> mapSectionTable = new List<MapSectionInfo>();

        public MapSectionInfoInstances()
        {
        }
    }
}