﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using SBGame;


namespace SBGamePlay
{


    public class EV_SkillEvent : Content_Event
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Action")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
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
