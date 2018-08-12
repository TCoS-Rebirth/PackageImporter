using System;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_DuffShare : FSkill_EffectClass_Duff
    {
        [FoldoutGroup("Sharing")]
        [FieldConst()]
        public byte EffectType;

        [FoldoutGroup("Sharing")]
        [FieldConst()]
        public byte AttackType;

        [FoldoutGroup("Sharing")]
        [FieldConst()]
        public byte MagicType;

        [FoldoutGroup("Sharing")]
        [FieldConst()]
        public byte Mode;

        [FoldoutGroup("Sharing")]
        [FieldConst()]
        public float ShareRatio;

        [FoldoutGroup("Sharing")]
        [FieldConst()]
        public byte Type;

        [FoldoutGroup("Sharing")]
        [FieldConst()]
        public bool IsBloodLink;

        [FoldoutGroup("Uses")]
        [FieldConst()]
        public float UseInterval;

        [FoldoutGroup("Uses")]
        [FieldConst()]
        public int Uses;

        [FoldoutGroup("Uses")]
        [FieldConst()]
        public float IncreasePerUse;

        [FoldoutGroup("SharingFX")]
        [FieldConst()]
        public FSkill_EffectClass_AudioVisual_Emitter SourceFX;

        [FoldoutGroup("SharingFX")]
        [FieldConst()]
        public FSkill_EffectClass_AudioVisual_Emitter TargetFX;

        [FoldoutGroup("Applicant")]
        [FieldConst()]
        [NonSerialized, HideInInspector]
        public string Icon;

        [FoldoutGroup("Applicant")]
        [FieldConst()]
        public string Description = string.Empty;

        [FieldConst()]
        public FSkill_ValueSpecifier _ShareValue;

        public FSkill_EffectClass_DuffShare()
        {
        }
    }
}
/*
event cl_CombatMessage(export editinline FSkill_Type aSkill,export editinline FSkill_Event_Duff aDuffEvent,Game_Pawn aSource,Game_Pawn aTarget,int aAmount,int aAmount2,int aAmount3) {
local string prefix;
local string Message;
if (Type == 1) {                                                            
if (aTarget != None && aTarget.IsLocalPlayer()) {                         
prefix = Class'StringReferences'.default.EffectSourceText.Text;         
if (aAmount3 == 0) {                                                    
Message = Class'StringReferences'.default.EffectDuffShareReturnSelfEETText.Text;
} else {                                                                
Message = Class'StringReferences'.default.EffectDuffShareReturnSelfText.Text;
}
aTarget.cl_AddScrollingCombatTypeValue(3,-aAmount);                     
} else {                                                                  
prefix = Class'StringReferences'.default.EffectYouText.Text;            
if (aAmount3 == 0) {                                                    
Message = Class'StringReferences'.default.EffectDuffShareReturnTargetEETText.Text;
} else {                                                                
Message = Class'StringReferences'.default.EffectDuffShareReturnTargetText.Text;
}
if (aTarget != None) {                                                  
aTarget.cl_AddScrollingCombatTypeValue(3,-aAmount);                   
}
}
} else {                                                                    
if (aTarget != None && aTarget.IsLocalPlayer()) {                         
prefix = Class'StringReferences'.default.EffectSourceText.Text;         
if (aAmount3 == 0) {                                                    
Message = Class'StringReferences'.default.EffectDuffShareDivideSelfEETText.Text;
} else {                                                                
Message = Class'StringReferences'.default.EffectDuffShareDivideSelfText.Text;
}
aTarget.cl_AddScrollingCombatTypeValue(3,-aAmount);                     
} else {                                                                  
prefix = Class'StringReferences'.default.EffectYouText.Text;            
if (aAmount3 == 0) {                                                    
Message = Class'StringReferences'.default.EffectDuffShareDivideTargetEETText.Text;
} else {                                                                
Message = Class'StringReferences'.default.EffectDuffShareDivideTargetText.Text;
}
if (aTarget != None) {                                                  
aTarget.cl_AddScrollingCombatTypeValue(3,-aAmount);                   
}
}
}
cl_CombatLogMessage(prefix,Message,aSkill,aDuffEvent,aSource,aTarget,aAmount,aAmount2,aAmount3);
}
final native function float GetShareEffect(float aSkillValue,int aNumUses);
final native function bool MatchEffect(byte aShareType,byte aAttackType,byte aMagicType,byte aEffectType);
*/