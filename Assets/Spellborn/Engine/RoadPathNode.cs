using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class RoadPathNode : PathNode
    {
        [FoldoutGroup("RoadPathNode")]
        public float MaxRoadDist;

        public RoadPathNode()
        {
        }
    }
}