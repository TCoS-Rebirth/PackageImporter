using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Gameplay
{
    public class LevelProgression : ScriptableObject
    {
        [SerializeField, ReadOnly]
        List<ProgressData> progressData = new List<ProgressData>();

#if UNITY_EDITOR
        public void EditorAddProgressData(ProgressData pd)
        {
            progressData.Add(pd);
        }
#endif

        [SerializeField, ReadOnly]
        List<PePProgress> pepProgressData = new List<PePProgress>
        {
            new PePProgress(0, 0),
            new PePProgress(1, 5000),
            new PePProgress(2, 15000),
            new PePProgress(3, 35000),
            new PePProgress(4, 75000),
            new PePProgress(5, 150000)
        };

        public int GetPepRankByPoints(int pepPoints)
        {
            for (int i = pepProgressData.Count; i-->0;)
            {
                if (pepPoints >= pepProgressData[i].RequiredPoints) return pepProgressData[i].Level;
            }
            throw new Exception("Pep points don't map to a valid level");
        }

        public int GetFameLevelByPoints(int famePoints)
        {
            for(int i = progressData.Count; i-- > 0;)
            {
                if (famePoints >= progressData[i].requiredFamePoints) return progressData[i].level;
            }
            throw new Exception("fame points don't map to a valid level");
        }

        public ProgressData GetDataForLevel(int level)
        {
            if (level <= 100 && level >= 1)
            {
                return progressData[level - 1];
            }
            throw new ArgumentOutOfRangeException("level", "Level must be between 1 and 100");
        }

        public ProgressData GetLevelbyFamepoints(int points)
        {
            for (var i = 0; i < progressData.Count; i++)
            {
                if (progressData[i].requiredFamePoints >= points)
                {
                    return progressData[Math.Max(0, i - 1)];
                }
            }
            return progressData[progressData.Count - 1];
        }

        public int GetHighestFameLevel()
        {
            return progressData[progressData.Count - 1].level;
        }

        public int GetLowestFameLevel()
        {
            return progressData[0].level;
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
        public int Level;
        public int RequiredPoints;

        public PePProgress(int level, int points)
        {
            Level = level;
            RequiredPoints = points;
        }
    }
}