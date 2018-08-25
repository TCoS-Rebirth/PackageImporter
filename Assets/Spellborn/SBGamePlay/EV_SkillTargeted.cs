using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_SkillTargeted : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public FSkill_Type Skill;

        public EV_SkillTargeted()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
local Game_Pawn executor;
local Game_Pawn Target;
local bool sheathe;
if (aObject != None) {                                                      
executor = aObject;                                                       
} else {                                                                    
executor = aSubject;                                                      
}
if (aSubject != None) {                                                     
Target = aSubject;                                                        
} else {                                                                    
Target = aObject;                                                         
}
if (!executor.combatState.CheckWeaponType(Skill.RequiredWeapon)) {          
sheathe = executor.combatState.CombatReady();                             
executor.combatState.sv_SwitchToWeaponType(Skill.RequiredWeapon);         
}
if (Target != None) {                                                       
executor.Skills.ExecuteL(Skill,Target.Location,executor.Level.TimeSeconds);
} else {                                                                    
executor.Skills.ExecuteL(Skill,executor.Location,executor.Level.TimeSeconds);
}
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
return Skill != None
&& aObject.Skills.CanActivateSpecificSkill(Skill) == 0
&& (aObject != None || aSubject != None);
}
*/