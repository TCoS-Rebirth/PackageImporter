using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_ShowTutorial : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
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