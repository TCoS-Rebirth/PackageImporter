using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_PartyTeleport : Content_Event
    {
        [FoldoutGroup("Action")]
        public int TargetWorld;

        [FoldoutGroup("Action")]
        public string portalName = string.Empty;

        public EV_PartyTeleport()
        {
        }
    }
}
/*
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
local Game_Team team;
team = aSubject.GetTeam();                                                  
if (team == None) {                                                         
TeleportPawn(aSubject,TargetWorld,False,portalName);                      
return;                                                                   
}
Game_PlayerController(aSubject.Controller).GroupingTeams.sv_StartPartyTravel(TargetWorld,portalName);
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
return True;                                                                
}
*/