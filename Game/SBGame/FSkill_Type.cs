﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Engine;
using System.Collections.Generic;
using TCosReborn.Framework.Common;


namespace SBGame
{


    public class FSkill_Type : Content_Type
    {
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int mhasskillpower_vtbl;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int mhasskillpower_data;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Group")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public string Group = string.Empty;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Group")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public byte Category;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Skill")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public float CooldownTime;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Skill")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public float AttackSpeed;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Skill")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public byte AttackType;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Skill")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public byte MagicType;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Skill")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public byte LinkedAttribute;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Skill")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public byte SkillComboType;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Skill")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public byte ReticuleSet;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Skillbook")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public List<byte> UsableByClass = new List<byte>();
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Skillbook")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public List<Item_Type> LegalSkillTokens = new List<Item_Type>();
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Skillbook")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public bool LegalSkillTokensUpdate;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public int MinSkillTier;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Description")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        public Texture Logo;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Description")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public LocalizedString Name;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Description")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public LocalizedString Description;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Animation")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public byte Animation;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Animation")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public byte Animation2;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Animation")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public int AnimationVariation;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Animation")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public byte RequiredWeapon;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Animation")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public float AnimationSpeed;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Animation")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public float AnimationTweenTime;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Animation")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public SkeletalMesh AnimationBaseMesh;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Animation")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public bool _ForceNotifyUpdate;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Animation")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public bool WeaponTracer;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Animation")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public bool FreezePawnMovement;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Animation")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public bool FreezePawnRotation;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Animation")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public float AnimationMovementForward;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Animation")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public float AnimationMovementLeft;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Target")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public bool PaintLocation;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Target")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public float PaintLocationMinDistance;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Target")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public float PaintLocationMaxDistance;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="aI")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public byte SkillClassification;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="aI")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public byte RequiredTarget;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="aI")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public float MinDistance;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="aI")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public float MaxDistance;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="aI")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public float TargetDelay;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="aI")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public float TargetCone;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="aI")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public byte StackType;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="aI")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public int StackCount;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="aI")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public float LeetnessRating;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public List<FKeyframeEffects> KeyFrames = new List<FKeyframeEffects>();
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public byte _LastAnimation;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public byte _LastAnimation2;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int _LastAnimationVariation;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public byte _LastRequiredWeapon;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public float _ResultTargetMinRange;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public float _ResultTargetMaxRange;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public bool _RemovedUnwantedEffects;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public bool _DeterminedHasTargetCount;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public bool _ResultHasTargetCount;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public bool _DeterminedTargetRanges;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public bool SkillRollsCombatBar;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public bool SkillRequiresEquippedWeapon;
        
        public FSkill_Type()
        {
        }
        
        public struct FKeyframeEffects
        {
            
            public string KeyFrame;
            
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
