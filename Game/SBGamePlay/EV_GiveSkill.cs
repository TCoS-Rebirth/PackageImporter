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


    public class EV_GiveSkill : Content_Event
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Action")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
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
