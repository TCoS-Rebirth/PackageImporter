using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_TriggerEvent : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public NameProperty EventTag;

        public EV_TriggerEvent()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
if (aObject != None) {                                                      
aObject.TriggerEvent(EventTag,aObject,aObject);                           
} else {                                                                    
if (aSubject != None) {                                                   
aSubject.TriggerEvent(EventTag,aSubject,aSubject);                      
}
}
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
return aObject != None || aSubject != None;                                 
}
*/