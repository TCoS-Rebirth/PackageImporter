using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class StatueLocation : Actor
    {
        [FoldoutGroup("Statue")]
        public NameProperty LocationTag;

        public StatueLocation()
        {
        }
    }
}