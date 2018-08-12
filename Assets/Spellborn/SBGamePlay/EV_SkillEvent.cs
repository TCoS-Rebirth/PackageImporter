using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_SkillEvent : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public FSkill_Event_Duff duffEvent;

        public EV_SkillEvent()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
aSubject.Skills.sv_AddSpecialDuffEvent(duffEvent);                          
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
return duffEvent != None && aSubject != None
&& aSubject.Skills != None;
}
*/