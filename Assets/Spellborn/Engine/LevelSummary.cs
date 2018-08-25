using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class LevelSummary : UObject
    {
        [FoldoutGroup("LevelSummary")]
        public string Title = string.Empty;

        [FoldoutGroup("LevelSummary")]
        public string Description = string.Empty;

        [FoldoutGroup("LevelSummary")]
        public string LevelEnterText = string.Empty;

        [FoldoutGroup("LevelSummary")]
        public string Author = string.Empty;

        [FoldoutGroup("LevelSummary")]
        public string DecoTextName = string.Empty;

        [FoldoutGroup("LevelSummary")]
        public int IdealPlayerCountMin;

        [FoldoutGroup("LevelSummary")]
        public int IdealPlayerCountMax;

        [FoldoutGroup("LevelSummary")]
        public string ExtraInfo = string.Empty;

        public LevelSummary()
        {
        }
    }
}