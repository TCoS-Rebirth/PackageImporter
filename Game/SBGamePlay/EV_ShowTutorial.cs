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


    public class EV_ShowTutorial : Content_Event
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Action")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public Help_Article Article;
        
        public EV_ShowTutorial()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
Game_PlayerController(aSubject.Controller).GUI.sv2cl_ShowTutorial_CallStub(Article.GetResourceId());
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
return True;                                                                
}
*/
