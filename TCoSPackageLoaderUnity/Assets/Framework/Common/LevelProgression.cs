using System;
using System.Collections.Generic;

#if UNITY_EDITOR

#endif

namespace Framework.Common
{
    public static class LevelProgression
    {
        public static List<ProgressData> ProgressData = new List<ProgressData>();

        static List<PePProgress> pepProgressData = new List<PePProgress>
        {
            new PePProgress(0, 0),
            new PePProgress(1, 5000),
            new PePProgress(2, 15000),
            new PePProgress(3, 35000),
            new PePProgress(4, 75000),
            new PePProgress(5, 150000)
};

        public static ProgressData GetDataForLevel(int level)
        {
            if (level <= 100 && level >= 1)
            {
                return ProgressData[level - 1];
            }
            throw new ArgumentOutOfRangeException("level", "Level must be between 1 and 100");
        }

         public static ProgressData GetLevelbyFamepoints(int points)
        {
            for (var i = 0; i < ProgressData.Count; i++)
            {
                if (ProgressData[i].requiredFamePoints >= points)
                {
                    return ProgressData[Math.Max(0, i - 1)];
                }
            }
            return ProgressData[ProgressData.Count - 1];
        }

         public static PePProgress GetPepLevelByPePpoints(int points)
        {
            for (var i = 0; i < pepProgressData.Count; i++)
            {
                if (pepProgressData[i].RequiredPoints >= points)
                {
                    return pepProgressData[Math.Max(0, i - 1)];
                }
            }
            return pepProgressData[pepProgressData.Count - 1];
        }

    }

    [Serializable]
    public class ProgressData
    {
        public int bodySlots;

        public int combatTierColumns;

        public int combatTierRows;

        public int decks;

        public int killFame;

        public int level;

        public int questFame;

        public int requiredFamePoints;

        public int skillTier;

        public int skillUpgrades;

        public int special;

        public int statPoints;

        public int totalSkills;
    }

    [Serializable]
    public class PePProgress
    {
        public readonly int Level;
        public readonly int RequiredPoints;

        public PePProgress(int level, int points)
        {
            Level = level;
            RequiredPoints = points;
        }
    }
}