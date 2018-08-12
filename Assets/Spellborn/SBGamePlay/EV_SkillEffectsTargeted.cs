using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_SkillEffectsTargeted : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public FSkill_Type Skill;

        public EV_SkillEffectsTargeted()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
local Game_Pawn executor;
local Game_Pawn Target;
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
executor.Skills.sv_DirectSkillEffects(Skill,Target);                        
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
return Skill != None
&& (aObject != None || aSubject != None);        
}
*/