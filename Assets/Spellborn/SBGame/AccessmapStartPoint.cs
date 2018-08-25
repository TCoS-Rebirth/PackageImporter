using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class AccessmapStartPoint : NavigationPoint
    {
        [FoldoutGroup("AccessmapStartPoint")]
        public Vector extend;

        [FoldoutGroup("Debug")]
        public bool IsActive;

        public AccessmapStartPoint()
        {
        }
    }
}