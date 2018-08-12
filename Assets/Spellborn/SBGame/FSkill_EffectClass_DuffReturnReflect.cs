using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_DuffReturnReflect : FSkill_EffectClass_Duff
    {
        [FoldoutGroup("ReturnReflect")]
        [FieldConst()]
        public byte Mode;

        [FoldoutGroup("ReturnReflect")]
        [FieldConst()]
        public byte AttackType;

        [FoldoutGroup("ReturnReflect")]
        [FieldConst()]
        public byte MagicType;

        [FoldoutGroup("ReturnReflect")]
        [FieldConst()]
        public byte EffectType;

        [FoldoutGroup("ReturnReflect")]
        [FieldConst()]
        public float Multiplier;

        [FoldoutGroup("Uses")]
        [FieldConst()]
        public float UseInterval;

        [FoldoutGroup("Uses")]
        [FieldConst()]
        public int Uses;

        [FoldoutGroup("Uses")]
        [FieldConst()]
        public float IncreasePerUse;

        [FoldoutGroup("ReturnReflectFX")]
        [FieldConst()]
        public FSkill_EffectClass_AudioVisual_Emitter SourceFX;

        [FoldoutGroup("ReturnReflectFX")]
        [FieldConst()]
        public FSkill_EffectClass_AudioVisual_Emitter TargetFX;

        [FieldConst()]
        public FSkill_ValueSpecifier _ReturnReflectValue;

        public FSkill_EffectClass_DuffReturnReflect()
        {
        }
    }
}
/*
event cl_CombatMessage(export editinline FSkill_Type aSkill,export editinline FSkill_Event_Duff aDuffEvent,Game_Pawn aSource,Game_Pawn aTarget,int aAmount,int aAmount2,int aAmount3) {
local string prefix;
local string Message;
if (Mode == 0) {                                                            
if (aTarget != None && aTarget.IsLocalPlayer()) {                         
prefix = Class'StringReferences'.default.EffectSourceText.Text;         
if (aAmount3 == 0) {                                                    
Message = Class'StringReferences'.default.EffectDuffReturnSelfEETText.Text;
} else {                                                                
Message = Class'StringReferences'.default.EffectDuffReturnSelfText.Text;
}
aTarget.cl_AddScrollingCombatTypeValue(3,-aAmount);                     
} else {                                                                  
prefix = Class'StringReferences'.default.EffectYouText.Text;            
if (aAmount3 == 0) {                                                    
Message = Class'StringReferences'.default.EffectDuffReturnTargetEETText.Text;
} else {                                                                
Message = Class'StringReferences'.default.EffectDuffReturnTargetText.Text;
}
if (aTarget != None) {                                                  
aTarget.cl_AddScrollingCombatTypeValue(3,-aAmount);                   
}
}
} else {                                                                    
if (aTarget != None && aTarget.IsLocalPlayer()) {                         
prefix = Class'StringReferences'.default.EffectSourceText.Text;         
if (aAmount3 == 0) {                                                    
Message = Class'StringReferences'.default.EffectDuffReflectSelfEETText.Text;
} else {                                                                
Message = Class'StringReferences'.default.EffectDuffReflectSelfText.Text;
}
aTarget.cl_AddScrollingCombatTypeValue(3,-aAmount);                     
} else {                                                                  
prefix = Class'StringReferences'.default.EffectYouText.Text;            
if (aAmount3 == 0) {                                                    
Message = Class'StringReferences'.default.EffectDuffReflectTargetEETText.Text;
} else {                                                                
Message = Class'StringReferences'.default.EffectDuffReflectTargetText.Text;
}
if (aTarget != None) {                                                  
aTarget.cl_AddScrollingCombatTypeValue(3,-aAmount);                   
}
}
}
cl_CombatLogMessage(prefix,Message,aSkill,aDuffEvent,aSource,aTarget,aAmount,aAmount2,aAmount3);
}
final native function float GetReturnReflectEffect(export editinline FSkill_Event aSkillEvent,float aSkillValue,int aNumUses);
final native function bool MatchEffect(byte aMode,byte aAttackType,byte aMagicType,byte aEffectType);
*/