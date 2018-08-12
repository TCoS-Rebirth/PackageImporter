using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class IC_BodySlot : Item_Component
    {
        [FoldoutGroup("Skill")]
        [FieldConst()]
        public FSkill_Type_BodySlot FakeSkill;

        [FoldoutGroup("Skill")]
        [FieldConst()]
        public bool UserStartable;

        [FoldoutGroup("BodySlot")]
        [FieldConst()]
        public byte Type;

        [FoldoutGroup("BodySlot")]
        [FieldConst()]
        public byte ForClass;

        public IC_BodySlot()
        {
        }

        public enum IC_BodySlotType
        {
            ICBS_Spirit,

            ICBS_Soul,

            ICBS_Rune,
        }
    }
}
/*
event OnUse(Game_Pawn aPawn,Game_Item aItem) {
local byte skillStartFailure;
if (FakeSkill != None) {                                                    
if (aPawn.Skills != None) {                                               
skillStartFailure = aPawn.Skills.CanActivateSpecificSkill(FakeSkill,True);
if (skillStartFailure == 7 && !UserStartable
|| skillStartFailure == 0) {
aPawn.Skills.Execute(FakeSkill,aPawn.Level.TimeSeconds);              
goto jl00A9;                                                          
}
goto jl00AC;                                                            
}
goto jl00AF;                                                              
}
}
event bool CanUse(Game_Pawn aPawn,Game_Item aItem) {
if (!UserStartable) {                                                       
return True;                                                              
}
if (ForClass != aPawn.CharacterStats.GetCharacterClass()
&& ForClass != aPawn.CharacterStats.GetArchetype()) {
return False;                                                             
}
if (FakeSkill != None) {                                                    
if (aPawn.Skills != None) {                                               
if (aPawn.Skills.CanActivateSpecificSkill(FakeSkill) == 0) {            
if (ForClass == 5) {                                                  
if (aPawn.combatState.CombatReady()) {                              
aPawn.combatState.sv_SheatheWeapon();                             
}
}
return Super.CanUse(aPawn,aItem);                                     
}
}
}
return False;                                                               
}
*/