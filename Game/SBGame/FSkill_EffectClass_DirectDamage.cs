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


namespace SBGame
{


    public class FSkill_EffectClass_DirectDamage : FSkill_EffectClass_Direct
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Damage")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public FSkill_ValueSpecifier Damage;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Damage")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public bool IgnoreResist;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Damage")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public float RearIncrease;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Damage")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public Vector Momentum;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="aI")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
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
