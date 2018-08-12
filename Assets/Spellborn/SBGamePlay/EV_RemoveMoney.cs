using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_RemoveMoney : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public int Amount;

        public EV_RemoveMoney()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
RemoveMoney(aSubject,Amount);                                               
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
if (Amount < 0) {                                                           
return False;                                                             
} else {                                                                    
return GetMoney(aSubject) >= Amount;                                      
}
}
*/