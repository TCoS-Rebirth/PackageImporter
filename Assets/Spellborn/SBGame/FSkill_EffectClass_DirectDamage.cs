using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_DirectDamage : FSkill_EffectClass_Direct
    {
        [FoldoutGroup("Damage")]
        [FieldConst()]
        public FSkill_ValueSpecifier Damage;

        [FoldoutGroup("Damage")]
        [FieldConst()]
        public bool IgnoreResist;

        [FoldoutGroup("Damage")]
        [FieldConst()]
        public float RearIncrease;

        [FoldoutGroup("Damage")]
        [FieldConst()]
        public Vector Momentum;

        [FoldoutGroup("aI")]
        [FieldConst()]
        public float AggroMultiplier;

        public FSkill_EffectClass_DirectDamage()
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
Message = Class'StringReferences'.default.EffectDirectDamageOverTimeText.Text;
} else {                                                                    
Message = Class'StringReferences'.default.EffectDirectDamageText.Text;    
}
cl_CombatLogMessage(prefix,Message,aSkill,aDuffEvent,aSource,aTarget,aAmount,aAmount2,aAmount3);
if (aTarget != None) {                                                      
aTarget.cl_AddScrollingCombatTypeValue(3,-aAmount);                       
}
CheckAutoTarget(aSource,aTarget);                                           
}
*/