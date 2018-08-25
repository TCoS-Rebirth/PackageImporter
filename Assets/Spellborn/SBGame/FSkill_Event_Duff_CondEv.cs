using System;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class FSkill_Event_Duff_CondEv : UObject
    {
        [FoldoutGroup("CondEv")]
        [FieldConst()]
        public FSkill_Event Event;

        [FoldoutGroup("CondEv")]
        [FieldConst()]
        public int Uses;

        [FoldoutGroup("CondEv")]
        [FieldConst()]
        public int MaximumTriggersPerUse;

        [FoldoutGroup("CondEv")]
        [FieldConst()]
        public float Interval;

        [FoldoutGroup("CondEv")]
        [FieldConst()]
        public float Delay;

        [FoldoutGroup("CondEv")]
        [FieldConst()]
        public float IncreasePerUse;

        [FoldoutGroup("CondEv")]
        [FieldConst()]
        public byte Condition;

        [FoldoutGroup("CondEv")]
        [FieldConst()]
        public byte AttackType;

        [FoldoutGroup("CondEv")]
        [FieldConst()]
        public byte MagicType;

        [FoldoutGroup("CondEv")]
        [FieldConst()]
        public byte EffectType;

        [FoldoutGroup("CondEv")]
        [FieldConst()]
        public byte Target;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool Running;

        public FSkill_Event_Duff_CondEv()
        {
        }
    }
}