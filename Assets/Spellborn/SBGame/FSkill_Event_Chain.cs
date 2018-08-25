using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class FSkill_Event_Chain : FSkill_Event_Target
    {
        [FoldoutGroup("Jump")]
        [FieldConst()]
        public int MaxJumps;

        [FoldoutGroup("Jump")]
        [FieldConst()]
        public int TargetsPerJump;

        [FoldoutGroup("Jump")]
        [FieldConst()]
        public int MaxHitsPerTarget;

        [FieldConst()]
        public FSkill_EffectClass_Range Range;

        [FoldoutGroup("Jump")]
        [FieldConst()]
        public float Interval;

        [FoldoutGroup("Jump")]
        [FieldConst()]
        public float IncreasePerJump;

        [FoldoutGroup("Jump")]
        [FieldConst()]
        public bool FairDistribution;

        [FoldoutGroup("Jump")]
        [FieldConst()]
        public bool TargetsPerJumpIsPerTarget;

        [FieldConst()]
        public FSkill_Event Event;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int JumpsLeft;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float NextJumpTime;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<Game_Pawn> JumpSources = new List<Game_Pawn>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int EventMode;

        [FieldConst()]
        private int TargetHitMap;

        [FieldConst()]
        private int TargetHitSet;

        public FSkill_Event_Chain()
        {
        }
    }
}