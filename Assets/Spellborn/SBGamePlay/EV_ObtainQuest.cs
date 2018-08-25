using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_ObtainQuest : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public Quest_Type quest;

        public EV_ObtainQuest()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
ObtainQuest(aObject,quest);                                                 
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
if (MeetsRequirementsQuest(aObject,quest)) {                                
return True;                                                              
}
return False;                                                               
}
*/