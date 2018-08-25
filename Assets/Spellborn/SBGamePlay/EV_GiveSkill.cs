using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_GiveSkill : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public FSkill_Type Skill;

        public EV_GiveSkill()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
LearnSkill(aSubject,Skill);                                                 
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
if (CanLearnSkill(aSubject,Skill)) {                                        
return True;                                                              
}
return False;                                                               
}
*/