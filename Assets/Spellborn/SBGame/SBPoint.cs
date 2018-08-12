using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class SBPoint : Actor
    {
        [FoldoutGroup("Paths")]
        public List<SBPathConnection> Connections = new List<SBPathConnection>();

        public SBPoint()
        {
        }

        [Serializable] public struct SBPathConnection
        {
            public SBPoint ConnectedActor;

            public float MoveSpeed;

            public bool Walking;
        }
    }
}