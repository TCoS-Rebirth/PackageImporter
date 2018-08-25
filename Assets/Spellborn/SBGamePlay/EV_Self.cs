using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_Self : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public Content_Event SelfAction;

        public EV_Self()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
SelfAction.sv_Execute(aObject,aObject);                                     
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
if (SelfAction != None) {                                                   
return SelfAction.sv_CanExecute(aObject,aObject);                         
}
return False;                                                               
}
*/