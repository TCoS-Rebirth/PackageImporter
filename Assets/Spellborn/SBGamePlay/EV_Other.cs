using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_Other : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public Content_Event OtherAction;

        public EV_Other()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
OtherAction.sv_Execute(aSubject,aSubject);                                  
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
if (OtherAction != None) {                                                  
return OtherAction.sv_CanExecute(aSubject,aSubject);                      
}
return False;                                                               
}
*/