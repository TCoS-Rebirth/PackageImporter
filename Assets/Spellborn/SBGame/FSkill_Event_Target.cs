using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class FSkill_Event_Target : FSkill_Event_FX
    {
        [FoldoutGroup("Target")]
        [FieldConst()]
        public int MaxTargets;

        [FoldoutGroup("Target")]
        [FieldConst()]
        public byte TargetBase;

        [FoldoutGroup("Target")]
        [FieldConst()]
        public byte TargetSelf;

        [FoldoutGroup("Target")]
        [FieldConst()]
        public byte TargetEnemies;

        [FoldoutGroup("Target")]
        [FieldConst()]
        public byte TargetFriendlies;

        [FieldConst()]
        public byte TargetNeutrals;

        [FoldoutGroup("Target")]
        [FieldConst()]
        public byte TargetSpirits;

        [FoldoutGroup("Target")]
        [FieldConst()]
        public byte TargetBloodlinks;

        [FoldoutGroup("Target")]
        [FieldConst()]
        public byte TargetPartyMembers;

        [FoldoutGroup("Target")]
        [FieldConst()]
        public byte TargetGuildMembers;

        [FoldoutGroup("Target")]
        [FieldConst()]
        public byte TargetPets;

        [FoldoutGroup("Target")]
        [FieldConst()]
        public List<NPC_Taxonomy> LimitToTaxonomy = new List<NPC_Taxonomy>();

        [FoldoutGroup("Target")]
        [FieldConst()]
        public bool TargetAttached;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private bool DidNeedRangeCheck;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private bool DidHasAutoTargets;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private bool ResultNeedRangeCheck;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private bool ResultHasAutoTargets;

        public FSkill_Event_Target()
        {
        }
    }
}