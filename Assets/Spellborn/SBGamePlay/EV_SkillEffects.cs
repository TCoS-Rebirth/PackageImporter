using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_SkillEffects : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public FSkill_Type Skill;

        public EV_SkillEffects()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
if (aObject != None) {                                                      
aObject.Skills.sv_DirectSkillEffects(Skill,aObject);                      
} else {                                                                    
aSubject.Skills.sv_DirectSkillEffects(Skill,aSubject);                    
}
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
return Skill != None
&& (aObject != None || aSubject != None);        
}
*/