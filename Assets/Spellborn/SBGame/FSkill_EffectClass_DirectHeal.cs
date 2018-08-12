using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_DirectHeal : FSkill_EffectClass_Direct
    {
        [FoldoutGroup("Heal")]
        [FieldConst()]
        public FSkill_ValueSpecifier Heal;

        [FoldoutGroup("aI")]
        [FieldConst()]
        public float AggroMultiplier;

        public FSkill_EffectClass_DirectHeal()
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
Message = Class'StringReferences'.default.EffectHealDuffText.Text;        
} else {                                                                    
Message = Class'StringReferences'.default.EffectHealText.Text;            
}
cl_CombatLogMessage(prefix,Message,aSkill,aDuffEvent,aSource,aTarget,aAmount,aAmount2,aAmount3);
if (aTarget != None) {                                                      
aTarget.cl_AddScrollingCombatTypeValue(3,aAmount);                        
}
CheckAutoTarget(aSource,aTarget);                                           
}
*/