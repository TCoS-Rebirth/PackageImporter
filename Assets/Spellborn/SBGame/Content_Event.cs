using System;

namespace SBGame
{
    [Serializable] public class Content_Event : Content_Type
    {
        public Content_Event()
        {
        }
    }
}
/*
native function GetActorRelations(Actor aSource,out array<ActorRelation> oRelations);
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
return True;                                                                
}
*/