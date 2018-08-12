using System;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass : Content_Type
    {
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int mhasskillpower_vtbl;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int mhasskillpower_data;

        [FoldoutGroup("Group")]
        [FieldConst()]
        public byte Category;

        [FoldoutGroup("aI")]
        [FieldConst()]
        public float Aggro;

        public FSkill_EffectClass()
        {
        }
    }
}
/*
native function float sv_GetAggroValue(Game_Pawn aPawn,float aValue);
native event cl_CombatLogMessage(string aPrefixFormatString,string aMessageFormatString,export editinline FSkill_Type aSkill,export editinline FSkill_Event_Duff aDuffEvent,Game_Pawn aSource,Game_Pawn aTarget,int aAmount1,int aAmount2,int aAmount3);
event cl_CombatMessage(export editinline FSkill_Type aSkill,export editinline FSkill_Event_Duff aDuffEvent,Game_Pawn aSource,Game_Pawn aTarget,int aAmount,int aAmount2,int aAmount3) {
}
*/