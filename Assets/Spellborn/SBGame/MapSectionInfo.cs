using System;
using System.Collections.Generic;
using Engine;

namespace SBGame
{
    [Serializable] public class MapSectionInfo : UObject
    {
        public const int RESOLUTION_MAX_RANGE = 4096;

        public const int RESOLUTION_MIN_RANGE = 128;

        public const int RESOLUTION_BREAKOFF_POINT = 512;

        public float X;

        public float Y;

        public float Z;

        public float width;

        public float Height;

        public List<MapResolutionInfo> mapSectionMaterial = new List<MapResolutionInfo>();

        public string mapBaseName = string.Empty;

        public LocalizedString mapSectionName;

        public int Id;

        public int parentID;

        public float scaleStart;

        public float scaleEnd;

        public bool IsDiscovered;

        public MapSectionInfo()
        {
        }
    }
}