using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_GiveQuest : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
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