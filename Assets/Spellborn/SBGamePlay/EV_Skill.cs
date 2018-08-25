using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_Skill : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public FSkill_Type Skill;

        public EV_Skill()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
local Game_Pawn executor;
local bool sheathe;
if (aObject != None) {                                                      
executor = aObject;                                                       
} else {                                                                    
executor = aSubject;                                                      
}
if (!executor.combatState.CheckWeaponType(Skill.RequiredWeapon)) {          
sheathe = executor.combatState.CombatReady();                             
executor.combatState.sv_SwitchToWeaponType(Skill.RequiredWeapon);         
}
executor.Skills.Execute(Skill,executor.Level.TimeSeconds);                  
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
return Skill != None
&& aObject.Skills.CanActivateSpecificSkill(Skill) == 0
&& (aObject != None || aSubject != None);
}
*/