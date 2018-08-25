using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class FSkill_Event_Direct : FSkill_Event_Target
    {
        [FoldoutGroup("Timing")]
        [FieldConst()]
        public int RepeatCount;

        [FoldoutGroup("Timing")]
        [FieldConst()]
        public float Interval;

        [FoldoutGroup("Timing")]
        [FieldConst()]
        public bool KeepTargets;

        [FoldoutGroup("Timing")]
        [FieldConst()]
        public int TargetsPerRepeat;

        [FieldConst()]
        public FSkill_EffectClass_Range Range;

        [FieldConst()]
        public FSkill_EffectClass_DirectDamage Damage;

        [FieldConst()]
        public FSkill_EffectClass_DirectHeal Heal;

        [FieldConst()]
        [ArraySizeForExtraction(Size = 3)]
        public FSkill_EffectClass_DirectState[] _State = new FSkill_EffectClass_DirectState[3];

        [FieldConst()]
        public FSkill_EffectClass_DirectDrain Drain;

        [FieldConst()]
        [ArraySizeForExtraction(Size = 4)]
        public FSkill_Event_Duff[] Buff = new FSkill_Event_Duff[4];

        [FieldConst()]
        [ArraySizeForExtraction(Size = 4)]
        public FSkill_Event_Duff[] Debuff = new FSkill_Event_Duff[4];

        [FieldConst()]
        public FSkill_EffectClass_DirectTeleport Teleport;

        [FieldConst()]
        public FSkill_EffectClass_DirectFireBodySlot FireBodySlot;

        [FieldConst()]
        public FSkill_EffectClass_DirectShapeShift ShapeShift;

        [FoldoutGroup("Damage")]
        [FieldConst()]
        public float DamageMoraleBonus;

        [FoldoutGroup("Sound")]
        [FieldConst()]
        public bool PlayHurtSound;

        [FoldoutGroup("HitFx")]
        [FieldConst()]
        public bool RepeatTargetFX;

        [FieldConst()]
        public FSkill_Event_FX MissFXEvent;

        [FieldConst()]
        public FSkill_Event_FX HitFXEvent;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private bool LeaveTargetsBe;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int ActualRepeatCount;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int ActualTargetCount;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private float NextDirectEventTime;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<Game_Pawn> Targets = new List<Game_Pawn>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private bool FirstExecute;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private Vector DetachedRangePosition;

        public FSkill_Event_Direct()
        {
        }
    }
}