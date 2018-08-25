using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_UntriggerEvent : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public NameProperty EventTag;

        public EV_UntriggerEvent()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
if (aObject != None) {                                                      
aObject.UntriggerEvent(EventTag,aObject,aObject);                         
} else {                                                                    
if (aSubject != None) {                                                   
aSubject.UntriggerEvent(EventTag,aSubject,aSubject);                    
}
}
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
return aObject != None || aSubject != None;                                 
}
*/