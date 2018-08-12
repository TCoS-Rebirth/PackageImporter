using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_TargetingSettings : UObject
    {
        [FoldoutGroup("FSkill_TargetingSettings")]
        [FieldConfig()]
        public float MaxFOV;

        [FoldoutGroup("FSkill_TargetingSettings")]
        [FieldConfig()]
        public float DistanceWeight;

        [FoldoutGroup("FSkill_TargetingSettings")]
        [FieldConfig()]
        public bool AllowPreferredTarget;

        public FSkill_TargetingSettings()
        {
        }
    }
}