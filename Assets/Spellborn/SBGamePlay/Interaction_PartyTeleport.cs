using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Interaction_PartyTeleport : Interaction_Component
    {
        [FoldoutGroup("Interaction_PartyTeleport")]
        public int TargetWorld;

        [FoldoutGroup("Interaction_PartyTeleport")]
        public string portalName = string.Empty;

        public Interaction_PartyTeleport()
        {
        }
    }
}
/*
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local Game_Team team;
Super.SvOnStart(aOwner,aInstigator);                                        
if (!aReverse) {                                                            
team = aInstigator.GetTeam();                                             
if (team == None) {                                                       
TeleportPawn(aInstigator,TargetWorld,False,portalName);                 
return;                                                                 
}
Game_PlayerController(aInstigator.Controller).GroupingTeams.sv_StartPartyTravel(TargetWorld,portalName);
}
}
*/