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
using SBAI;
using SBAIScripts;
using SBBase;
using SBGame;
using SBGamePlay;
using SBMiniGames;
using System;
using System.Collections;
using System.Collections.Generic;
using Framework.Attributes;

namespace SBGame
{
    
    
    [System.Serializable] public class IC_TokenSkill : Item_Component
    {
        
        [Sirenix.OdinInspector.FoldoutGroup("Token")]
        [FieldConst()]
        public int TokenRank;
        
        [Sirenix.OdinInspector.FoldoutGroup("Token")]
        [FieldConst()]
        public byte Effect1;
        
        [Sirenix.OdinInspector.FoldoutGroup("Token")]
        [FieldConst()]
        public byte Effect2;
        
        [Sirenix.OdinInspector.FoldoutGroup("Token")]
        [FieldConst()]
        public byte Effect3;
        
        [Sirenix.OdinInspector.FoldoutGroup("Token")]
        [FieldConst()]
        public byte Effect4;
        
        [Sirenix.OdinInspector.FoldoutGroup("Token")]
        [FieldConst()]
        public byte Effect5;
        
        [Sirenix.OdinInspector.FoldoutGroup("Token")]
        [FieldConst()]
        public byte Effect6;
        
        [Sirenix.OdinInspector.FoldoutGroup("Token")]
        [FieldConst()]
        public byte Effect7;
        
        [Sirenix.OdinInspector.FoldoutGroup("Token")]
        [FieldConst()]
        public byte Effect8;
        
        [Sirenix.OdinInspector.FoldoutGroup("Token")]
        [FieldConst()]
        public float Value;
        
        [Sirenix.OdinInspector.FoldoutGroup("Token")]
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
