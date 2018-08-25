using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_Swap : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public Content_Event SwappedAction;

        public EV_Swap()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
SwappedAction.sv_Execute(aSubject,aObject);                                 
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
if (SwappedAction != None) {                                                
return SwappedAction.sv_CanExecute(aSubject,aObject);                     
}
return False;                                                               
}
*/