using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class IC_TokenItem : Item_Component
    {
        [FoldoutGroup("IC_TokenItem")]
        [FieldConst()]
        public int TokenRank;

        [FoldoutGroup("IC_TokenItem")]
        [FieldConst()]
        public byte SlotType;

        [FoldoutGroup("IC_TokenItem")]
        [FieldConst()]
        public int ForgePrice;

        [FoldoutGroup("IC_TokenItem")]
        [FieldConst()]
        public int ForgeReplacePrice;

        [FoldoutGroup("IC_TokenItem")]
        [FieldConst()]
        public int ForgeRemovePrice;

        [FoldoutGroup("IC_TokenItem")]
        public List<FSkill_EffectClass_Duff> EquipEffects = new List<FSkill_EffectClass_Duff>();

        [FoldoutGroup("IC_TokenItem")]
        public List<FSkill_EffectClass_AudioVisual> WeaponTracers = new List<FSkill_EffectClass_AudioVisual>();

        public IC_TokenItem()
        {
        }
    }
}
/*
private final native function int sv_GetNextTokenHandle();
final event sv_StopToken(Game_Pawn aPawn,out int aHandle) {
local int Count;
if (aHandle != 0 && aPawn != None && aPawn.Skills != None) {                
Count = aPawn.Skills.sv_RemoveSpecialDuffEffect(aHandle);                 
aHandle = 0;                                                              
}
}
final event int sv_StartToken(Game_Pawn aPawn) {
local int Handle;
local int i;
if (aPawn != None && aPawn.Skills != None) {                                
Handle = sv_GetNextTokenHandle();                                         
i = 0;                                                                    
while (i < EquipEffects.Length) {                                         
aPawn.Skills.sv_AddSpecialDuffEffect(EquipEffects[i],0.00000000,Handle);
++i;                                                                    
}
}
return Handle;                                                              
}
*/