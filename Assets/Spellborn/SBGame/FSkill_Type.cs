using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class FSkill_Type : Content_Type
    {
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int mhasskillpower_vtbl;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int mhasskillpower_data;

        [FoldoutGroup("Group")]
        [FieldConst()]
        public string Group = string.Empty;

        [FoldoutGroup("Group")]
        [FieldConst()]
        public byte Category;

        [FoldoutGroup("Skill")]
        [FieldConst()]
        public float CooldownTime;

        [FoldoutGroup("Skill")]
        [FieldConst()]
        public float AttackSpeed;

        [FoldoutGroup("Skill")]
        [FieldConst()]
        public byte AttackType;

        [FoldoutGroup("Skill")]
        [FieldConst()]
        public byte MagicType;

        [FoldoutGroup("Skill")]
        [FieldConst()]
        public byte LinkedAttribute;

        [FoldoutGroup("Skill")]
        [FieldConst()]
        public byte SkillComboType;

        [FoldoutGroup("Skill")]
        [FieldConst()]
        public byte ReticuleSet;

        [FoldoutGroup("Skillbook")]
        [FieldConst()]
        public List<byte> UsableByClass = new List<byte>();

        [FoldoutGroup("Skillbook")]
        [FieldConst()]
        public List<Item_Type> LegalSkillTokens = new List<Item_Type>();

        [FoldoutGroup("Skillbook")]
        [FieldConst()]
        public bool LegalSkillTokensUpdate;

        [FieldConst()]
        public int MinSkillTier;

        [FoldoutGroup("Description")]
        [FieldConst()]
        [NonSerialized, HideInInspector]
        public string Logo;

        [FoldoutGroup("Description")]
        [FieldConst()]
        public LocalizedString Name;

        [FoldoutGroup("Description")]
        [FieldConst()]
        public LocalizedString Description;

        [FoldoutGroup("Animation")]
        [FieldConst()]
        public byte Animation;

        [FoldoutGroup("Animation")]
        [FieldConst()]
        public byte Animation2;

        [FoldoutGroup("Animation")]
        [FieldConst()]
        public int AnimationVariation;

        [FoldoutGroup("Animation")]
        [FieldConst()]
        public byte RequiredWeapon;

        [FoldoutGroup("Animation")]
        [FieldConst()]
        public float AnimationSpeed;

        [FoldoutGroup("Animation")]
        [FieldConst()]
        public float AnimationTweenTime;

        [FoldoutGroup("Animation")]
        [FieldConst()]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool _ForceNotifyUpdate;

        [FoldoutGroup("Animation")]
        [FieldConst()]
        public bool WeaponTracer;

        [FoldoutGroup("Animation")]
        [FieldConst()]
        public bool FreezePawnMovement;

        [FoldoutGroup("Animation")]
        [FieldConst()]
        public bool FreezePawnRotation;

        [FoldoutGroup("Animation")]
        [FieldConst()]
        public float AnimationMovementForward;

        [FoldoutGroup("Animation")]
        [FieldConst()]
        public float AnimationMovementLeft;

        [FoldoutGroup("Target")]
        [FieldConst()]
        public bool PaintLocation;

        [FoldoutGroup("Target")]
        [FieldConst()]
        public float PaintLocationMinDistance;

        [FoldoutGroup("Target")]
        [FieldConst()]
        public float PaintLocationMaxDistance;

        [FoldoutGroup("aI")]
        [FieldConst()]
        public byte SkillClassification;

        [FoldoutGroup("aI")]
        [FieldConst()]
        public byte RequiredTarget;

        [FoldoutGroup("aI")]
        [FieldConst()]
        public float MinDistance;

        [FoldoutGroup("aI")]
        [FieldConst()]
        public float MaxDistance;

        [FoldoutGroup("aI")]
        [FieldConst()]
        public float TargetDelay;

        [FoldoutGroup("aI")]
        [FieldConst()]
        public float TargetCone;

        [FoldoutGroup("aI")]
        [FieldConst()]
        public byte StackType;

        [FoldoutGroup("aI")]
        [FieldConst()]
        public int StackCount;

        [FoldoutGroup("aI")]
        [FieldConst()]
        public float LeetnessRating;

        [FieldConst()]
        public List<FKeyframeEffects> KeyFrames = new List<FKeyframeEffects>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public byte _LastAnimation;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public byte _LastAnimation2;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int _LastAnimationVariation;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public byte _LastRequiredWeapon;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float _ResultTargetMinRange;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float _ResultTargetMaxRange;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool _RemovedUnwantedEffects;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool _DeterminedHasTargetCount;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool _ResultHasTargetCount;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool _DeterminedTargetRanges;

        [FieldConst()]
        public bool SkillRollsCombatBar;

        [FieldConst()]
        public bool SkillRequiresEquippedWeapon;

        public FSkill_Type()
        {
        }

        [Serializable] public struct FKeyframeEffects
        {
            public NameProperty KeyFrame;

            public float Time;

            public FSkill_EventGroup Group;
        }
    }
}
/*
final native function bool IsComboNone();
final native function bool IsComboNormal();
final native function bool IsComboFinisher();
final native function bool IsComboOpener();
final native function float GetSkillCooldown(Game_Pawn aPawn);
final native function float GetSkillDuration(Game_Pawn aPawn,int VarNr);
final static native function FSkill_Type FindSkillByName(string aSkillName);
final static native function GetAllSkills(out array<FSkill_Type> skillTypes);
final native function bool SupportsClass(byte aClass);
final native function float GetTargetMaxRange(Game_Pawn aPawn);
final native function bool HasTargetCount();
final native function bool IsInRange(float aDistance);
final event string GetName() {
if (Len(Name.Text) > 0) {                                                   
return Name.Text;                                                         
} else {                                                                    
return "<Unnamed Skill>";                                                 
}
}
*/