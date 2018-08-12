using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_QuestProgress : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public Quest_Type quest;

        [FoldoutGroup("Action")]
        [FieldConst()]
        public int TargetNr;

        [FoldoutGroup("Action")]
        [FieldConst()]
        public int Progress;

        public EV_QuestProgress()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
local export editinline Quest_Target Target;
Target = quest.Targets[TargetNr];                                           
Game_PlayerPawn(aSubject).questLog.sv_SetTargetProgress(Target,Progress,aObject);
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
local export editinline Quest_Target Target;
Target = quest.Targets[TargetNr];                                           
if (Target != None) {                                                       
if (HasQuest(aSubject,quest)) {                                           
return True;                                                            
}
}
return False;                                                               
}
*/