using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_DuffDrain : FSkill_EffectClass_Duff
    {
        [FoldoutGroup("Drain")]
        [FieldConst()]
        public byte DrainedCharacterStat;

        [FoldoutGroup("Drain")]
        [FieldConst()]
        public byte GainedCharacterStat;

        [FoldoutGroup("Drain")]
        [FieldConst()]
        public FSkill_ValueSpecifier DrainedAmount;

        [FoldoutGroup("Drain")]
        [FieldConst()]
        public float Multiplier;

        [FoldoutGroup("Drain")]
        [FieldConst()]
        public FSkill_ValueSpecifier MultiplierVS;

        public FSkill_EffectClass_DuffDrain()
        {
        }
    }
}
/*
event cl_CombatMessage(export editinline FSkill_Type aSkill,export editinline FSkill_Event_Duff aDuffEvent,Game_Pawn aSource,Game_Pawn aTarget,int aAmount,int aAmount2,int aAmount3) {
local string prefix;
local string Message;
prefix = Class'StringReferences'.default.EffectSourceText.Text;             
if (aSource != None && aSource.IsLocalPlayer()) {                           
Message = Class'StringReferences'.default.EffectDuffDrainTargetText.Text; 
} else {                                                                    
Message = Class'StringReferences'.default.EffectDuffDrainSelfText.Text;   
}
cl_CombatLogMessage(prefix,Message,None,aDuffEvent,aSource,aTarget,aAmount,aAmount2,aAmount3);
}
*/