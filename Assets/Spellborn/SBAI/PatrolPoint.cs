using System;
using System.Collections.Generic;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAI
{
    [Serializable] public class PatrolPoint : AIPoint
    {
        [FoldoutGroup("PatrolPoint")]
        public bool PausePatrolScript;

        [FoldoutGroup("PatrolPoint")]
        public bool bWalking;

        [FoldoutGroup("PatrolPoint")]
        public float MinimalPathHeight;

        [FoldoutGroup("Debugging")]
        public bool ShowPrecomputedPaths;

        public List<SBPath> PatrolPaths = new List<SBPath>();

        public PatrolPoint()
        {
        }
    }
}