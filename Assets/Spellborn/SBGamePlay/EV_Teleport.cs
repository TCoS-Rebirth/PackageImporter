using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_Teleport : Content_Event
    {
        [FoldoutGroup("Action")]
        public int TargetWorld;

        [FoldoutGroup("Action")]
        public string Parameter = string.Empty;

        [FoldoutGroup("Action")]
        public bool IsInstance;

        public EV_Teleport()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
TeleportPawn(aSubject,TargetWorld,IsInstance,Parameter);                    
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
return True;                                                                
}
*/