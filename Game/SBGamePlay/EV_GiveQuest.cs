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


    public class EV_GiveQuest : Content_Event
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Action")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public Quest_Type quest;
        
        public EV_GiveQuest()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
ObtainQuest(aSubject,quest);                                                
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
if (MeetsRequirementsQuest(aSubject,quest)) {                               
return True;                                                              
}
return False;                                                               
}
*/
