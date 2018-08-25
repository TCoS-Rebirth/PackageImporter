using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class NPC_AI : Actor
    {
        [FoldoutGroup("Spawning")]
        public bool bControlsSpawning;

        [FoldoutGroup("Spawning")]
        public int ChallengeRating;

        public NPC_AI()
        {
        }
    }
}