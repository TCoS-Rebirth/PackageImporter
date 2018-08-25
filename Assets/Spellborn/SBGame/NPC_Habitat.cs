using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class NPC_Habitat : Actor
    {
        [FoldoutGroup("aI")]
        public float HabitatRange;

        [FoldoutGroup("Hormones")]
        public float DesolationRate;

        [FoldoutGroup("Habitat")]
        public List<NPC_Spawner> Prey = new List<NPC_Spawner>();

        [FoldoutGroup("Habitat")]
        public List<WanderSmell> Smells = new List<WanderSmell>();

        [FoldoutGroup("Habitat")]
        public int SmellSpawns;

        [FoldoutGroup("Habitat")]
        public List<WanderObstacle> Obstacles = new List<WanderObstacle>();

        [FoldoutGroup("Habitat")]
        public float IntruderAttraction;

        [FoldoutGroup("Habitat")]
        public float SocialAttraction;

        public NPC_Habitat()
        {
        }

        [Serializable] public struct WanderObstacle
        {
            public Actor Obstacle;

            public Vector Offset;

            public float Size;

            public float Range;
        }

        [Serializable] public struct WanderSmell
        {
            public Vector Location;

            public float Strength;

            public float Size;
        }
    }
}
/*
final native function bool CheckHabitat(Vector aLocation);
*/