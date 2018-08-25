using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class IC_LabyrinthKey : IC_Key
    {
        [FoldoutGroup("Key")]
        [FieldConst()]
        public int MinSpawnLevel;

        [FoldoutGroup("Key")]
        [FieldConst()]
        public int MaxSpawnLevel;

        public IC_LabyrinthKey()
        {
        }
    }
}