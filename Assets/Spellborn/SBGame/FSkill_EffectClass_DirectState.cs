using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_DirectState : FSkill_EffectClass_Direct
    {
        [FoldoutGroup("State")]
        [FieldConst()]
        public byte State;

        [FoldoutGroup("State")]
        [FieldConst()]
        public FSkill_ValueSpecifier Value;

        public FSkill_EffectClass_DirectState()
        {
        }
    }
}
/*
event cl_CombatMessage(export editinline FSkill_Type aSkill,export editinline FSkill_Event_Duff aDuffEvent,Game_Pawn aSource,Game_Pawn aTarget,int aAmount,int aAmount2,int aAmount3) {
local string prefix;
local string Message;
prefix = Class'StringReferences'.default.EffectSourceText.Text;             
if (aDuffEvent != None) {                                                   
Message = Class'StringReferences'.default.EffectDirectStateDuffText.Text; 
} else {                                                                    
if (aTarget != None && aTarget.IsLocalPlayer()) {                         
Message = Class'StringReferences'.default.EffectDirectStateSelfText.Text;
} else {                                                                  
Message = Class'StringReferences'.default.EffectDirectStateTargetText.Text;
}
}
cl_CombatLogMessage(prefix,Message,aSkill,aDuffEvent,aSource,aTarget,aAmount,aAmount2,aAmount3);
if (aTarget != None) {                                                      
aTarget.cl_AddScrollingCombatTypeValue(State,aAmount);                    
}
CheckAutoTarget(aSource,aTarget);                                           
}
*/