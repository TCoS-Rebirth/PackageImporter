using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_PersistentValue : Content_Event
    {
        public Content_Type context;

        [FoldoutGroup("Action")]
        public int VariableID;

        [FoldoutGroup("Action")]
        public int Value;

        public EV_PersistentValue()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
SetPersistentVariable(aSubject,VariableID,Value);                           
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
if (VariableID < 0) {                                                       
return False;                                                             
}
if (!aSubject.IsPlayerPawn()) {                                             
return False;                                                             
}
return True;                                                                
}
*/