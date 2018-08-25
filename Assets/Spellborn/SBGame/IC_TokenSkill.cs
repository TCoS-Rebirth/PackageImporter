using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class IC_TokenSkill : Item_Component
    {
        [FoldoutGroup("Token")]
        [FieldConst()]
        public int TokenRank;

        [FoldoutGroup("Token")]
        [FieldConst()]
        public byte Effect1;

        [FoldoutGroup("Token")]
        [FieldConst()]
        public byte Effect2;

        [FoldoutGroup("Token")]
        [FieldConst()]
        public byte Effect3;

        [FoldoutGroup("Token")]
        [FieldConst()]
        public byte Effect4;

        [FoldoutGroup("Token")]
        [FieldConst()]
        public byte Effect5;

        [FoldoutGroup("Token")]
        [FieldConst()]
        public byte Effect6;

        [FoldoutGroup("Token")]
        [FieldConst()]
        public byte Effect7;

        [FoldoutGroup("Token")]
        [FieldConst()]
        public byte Effect8;

        [FoldoutGroup("Token")]
        [FieldConst()]
        public float Value;

        [FoldoutGroup("Token")]
        [FieldConst()]
        public byte ValueMode;

        public IC_TokenSkill()
        {
        }
    }
}
/*
static native function Item_Type FindSkillTokenItemByName(string aTokenName);
static native function GetAllSkillTokenItems(out array<Item_Type> SkillTokenItems);
final event sv_StopToken(Game_Pawn aPawn,export editinline FSkill_Type aSkill) {
if (aPawn != None && aPawn.Skills != None) {                                
aPawn.Skills.sv_IncreaseTokenEffect(aSkill,Effect1,ValueMode,-Value);     
aPawn.Skills.sv_IncreaseTokenEffect(aSkill,Effect2,ValueMode,-Value);     
aPawn.Skills.sv_IncreaseTokenEffect(aSkill,Effect3,ValueMode,-Value);     
aPawn.Skills.sv_IncreaseTokenEffect(aSkill,Effect4,ValueMode,-Value);     
aPawn.Skills.sv_IncreaseTokenEffect(aSkill,Effect5,ValueMode,-Value);     
aPawn.Skills.sv_IncreaseTokenEffect(aSkill,Effect6,ValueMode,-Value);     
aPawn.Skills.sv_IncreaseTokenEffect(aSkill,Effect7,ValueMode,-Value);     
aPawn.Skills.sv_IncreaseTokenEffect(aSkill,Effect8,ValueMode,-Value);     
goto jl0194;                                                              
}
}
final event int sv_StartToken(Game_Pawn aPawn,export editinline FSkill_Type aSkill) {
local int Handle;
if (aPawn != None && aPawn.Skills != None) {                                
aPawn.Skills.sv_IncreaseTokenEffect(aSkill,Effect1,ValueMode,Value);      
aPawn.Skills.sv_IncreaseTokenEffect(aSkill,Effect2,ValueMode,Value);      
aPawn.Skills.sv_IncreaseTokenEffect(aSkill,Effect3,ValueMode,Value);      
aPawn.Skills.sv_IncreaseTokenEffect(aSkill,Effect4,ValueMode,Value);      
aPawn.Skills.sv_IncreaseTokenEffect(aSkill,Effect5,ValueMode,Value);      
aPawn.Skills.sv_IncreaseTokenEffect(aSkill,Effect6,ValueMode,Value);      
aPawn.Skills.sv_IncreaseTokenEffect(aSkill,Effect7,ValueMode,Value);      
aPawn.Skills.sv_IncreaseTokenEffect(aSkill,Effect8,ValueMode,Value);      
goto jl0184;                                                              
}
return Handle;                                                              
}
*/