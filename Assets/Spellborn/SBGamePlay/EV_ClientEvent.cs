using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_ClientEvent : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public string EventTag = string.Empty;

        public EV_ClientEvent()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
if (Game_PlayerPawn(aSubject) != None) {                                    
Game_PlayerPawn(aSubject).sv_ClientSideTrigger(EventTag,aObject);         
} else {                                                                    
if (Game_PlayerPawn(aObject) != None) {                                   
Game_PlayerPawn(aObject).sv_ClientSideTrigger(EventTag,aSubject);       
}
}
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
return aObject != None || aSubject != None;                                 
}
*/