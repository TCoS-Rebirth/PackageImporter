using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_GiveMoney : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public int Amount;

        public EV_GiveMoney()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
GiveMoney(aSubject,Amount);                                                 
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
if (Amount < 0) {                                                           
return False;                                                             
} else {                                                                    
return True;                                                              
}
}
*/