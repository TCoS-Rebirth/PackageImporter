using System;

namespace Engine
{
    [Serializable] public class TerrainInfo : Info
    {
        [FieldConst()]
        public int HeightmapX;

        [FieldConst()]
        public int HeightmapY;

        [FieldConst()]
        public int SectorsX;

        [FieldConst()]
        public int SectorsY;

        public TerrainInfo()
        {
        }
    }
}
/*
final native function PokeTerrain(Vector WorldLocation,int Radius,int MaxDepth);
*/