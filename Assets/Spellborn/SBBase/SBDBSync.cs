using System;
using Engine;

namespace SBBase
{
    [Serializable] public class SBDBSync : UObject
    {
        public static T GetResourceObject<T>(int resource_id) where T:UObject
        {
            return GameResources.Instance.GetResource<T>(resource_id);
        }

        static Gameplay.ProgressData GetDataForLevel(int fameLevel)
        {
            return GameResources.Instance.LevelProgression.GetDataForLevel(fameLevel);
        }

        public static float GetQuestFame(int fameLevel)
        {
            return GetDataForLevel(fameLevel).questFame;
        }

        public static float GetKillFame(int fameLevel)
        {
            return GetDataForLevel(fameLevel).killFame;
        }

        public static float GetFameToReachFameLevel(int fameLevel)
        {
            return GetDataForLevel(fameLevel).requiredFamePoints;
        }

        public static int GetAttributePoints(int fameLevel)
        {
            return GetDataForLevel(fameLevel).statPoints;
        }

        public static int GetSkillTokenCount(int fameLevel)
        {
            return GetDataForLevel(fameLevel).skillUpgrades;
        }

        public static int GetSkillCount(int fameLevel)
        {
            return GetDataForLevel(fameLevel).totalSkills;
        }

        public static int GetSkillTier(int fameLevel)
        {
            return GetDataForLevel(fameLevel).skillTier;
        }

        public static int GetCombatBarColumns(int fameLevel)
        {
            return GetDataForLevel(fameLevel).combatTierColumns;
        }

        public static int GetCombatBarRows(int fameLevel)
        {
            return GetDataForLevel(fameLevel).combatTierRows;
        }

        public static int GetHighestFameLevel()
        {
            return GameResources.Instance.LevelProgression.GetHighestFameLevel();
        }

        public static int GetLowestFameLevel()
        {
            return GameResources.Instance.LevelProgression.GetLowestFameLevel();
        }

        #region extra
        public static int GetFameLevelByPoints(int famePoints)
        {
            return GameResources.Instance.LevelProgression.GetFameLevelByPoints(famePoints);
        }

        public static int GetPepRankByPoints(int pepPoints)
        {
            return GameResources.Instance.LevelProgression.GetPepRankByPoints(pepPoints);
        }
        #endregion
    }
}
/*
static native function bool ValidFameLevel(int FameLevel);
static native function int GetFameLevelCount();

static native function int CreateResourceId(string PathName);
static native function string GetPathName(int resource_id);
static native function int GetResourceId(string PathName);
*/