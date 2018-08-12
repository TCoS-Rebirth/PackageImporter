using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_FinishQuest : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public Quest_Type quest;

        public EV_FinishQuest()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
FinishQuest(aSubject,quest);                                                
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
if (HasCompletedQuest(aSubject,quest)) {                                    
if (quest.sv_CanComplete(aSubject)) {                                     
return True;                                                            
}
}
return False;                                                               
}
*/