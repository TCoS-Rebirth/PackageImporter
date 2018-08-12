using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Interaction_ShowTutorial : Interaction_Component
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public Help_Article Article;

        public Interaction_ShowTutorial()
        {
        }
    }
}
/*
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
Super.SvOnStart(aOwner,aInstigator,aReverse);                               
if (!aReverse) {                                                            
Game_PlayerController(aInstigator.Controller).GUI.sv2cl_ShowTutorial_CallStub(Article.GetResourceId());
}
}
*/