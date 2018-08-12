using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_SetFaction : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public NPC_Taxonomy DesiredFaction;

        public EV_SetFaction()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
if (aSubject != None) {                                                     
aSubject.Character.sv_SetFaction(DesiredFaction);                         
} else {                                                                    
aObject.Character.sv_SetFaction(DesiredFaction);                          
}
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
return aSubject != None || aObject != None;                                 
}
*/