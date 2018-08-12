using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class FSkill_Event_Duff : FSkill_Event_FX
    {
        [FieldConst()]
        public List<FSkill_Event_Duff_DirectEff> DirectEffects = new List<FSkill_Event_Duff_DirectEff>();

        [FieldConst()]
        public List<FSkill_Event_Duff_DuffEff> DuffEffects = new List<FSkill_Event_Duff_DuffEff>();

        [FieldConst()]
        public FSkill_Event Event;

        [FoldoutGroup("Events")]
        [FieldConst()]
        public float EventInterval;

        [FoldoutGroup("Events")]
        [FieldConst()]
        public int EventRepeatCount;

        [FieldConst()]
        public List<FSkill_Event_Duff_CondEv> ConditionalEvents = new List<FSkill_Event_Duff_CondEv>();

        [FoldoutGroup("Duff")]
        [FieldConst()]
        public LocalizedString Name;

        [FoldoutGroup("Duff")]
        [FieldConst()]
        [NonSerialized, HideInInspector]
        public string Icon;

        [FoldoutGroup("Duff")]
        [FieldConst()]
        public bool Visible;

        [FoldoutGroup("Duff")]
        [FieldConst()]
        public LocalizedString Description;

        [FoldoutGroup("Duff")]
        [FieldConst()]
        public float Duration;

        [FoldoutGroup("Duff")]
        [FieldConst()]
        public byte StackType;

        [FoldoutGroup("Duff")]
        [FieldConst()]
        public int StackCount;

        [FoldoutGroup("Duff")]
        [FieldConst()]
        public byte Priority;

        [FieldConst()]
        public bool RunUntilAbort;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<DirectEffectRunData> DirectEffectTimers = new List<DirectEffectRunData>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<DuffEffectRunData> DuffEffectTimers = new List<DuffEffectRunData>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<ConditionalEventRunData> ConditionalEventTimers = new List<ConditionalEventRunData>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float EventTimer;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int EventActualRepeatCount;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool DuffEventDone;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool UninstallWhenDone;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<Game_Pawn> Targets = new List<Game_Pawn>();

        public FSkill_Event_Duff()
        {
        }

        [Serializable] public struct ConditionalEventRunData
        {
            public float EarliestStartTime;

            public int UsesLeft;
        }

        [Serializable] public struct DirectEffectRunData
        {
            public float NextStartTime;

            public int ActualRepeatCount;
        }

        [Serializable] public struct DuffEffectRunData
        {
            public float NextStartTime;

            public int ActualRepeatCount;

            public List<FSkill_EffectClass_Duff.DuffRestoreData> History;
        }
    }
}
/*
final event string GetName() {
if (Len(Name.Text) > 0) {                                                   
return Name.Text;                                                         
} else {                                                                    
return "<Unnamed Buff or Debuff>";                                        
}
}
native function sv_FireCondition(array<Game_Pawn> aConditionTriggerPawn,Game_Pawn aOriginPawn,byte aCondition,optional byte aAttackType,optional byte aMagicType,optional byte aEffectType);
*/