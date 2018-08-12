using System;
using Engine;

namespace SBGame
{
    [Serializable] public class NPC_AttackSheet_ClassBased_Settings : UObject
    {
        [ArraySizeForExtraction(Size = 15)]
        public float[] SkillTypeFallOff = new float[0];

        public float LevelAggroMedian;

        public NPC_AttackSheet_ClassBased_Settings()
        {
        }
    }
}