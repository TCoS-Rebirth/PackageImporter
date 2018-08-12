using System;
using SBAI;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_ClientsideTrigger : AI_Script
    {
        [FoldoutGroup("ClientSideTrigger")]
        public string ClientEvent = string.Empty;

        [FoldoutGroup("ClientSideTrigger")]
        public bool TriggerAllPlayers;

        [FoldoutGroup("ClientSideTrigger")]
        public float Radius;

        public AIScript_ClientsideTrigger()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(ClientEvent,static.RGB(100,100,255),"ClientEvent",oRelations);
}
event Trigger(Actor Other,Pawn EventInstigator) {
local Game_PlayerPawn Player;
if (ClientEvent != "" && ClientEvent != "none") {                           
if (Radius > 0) {                                                         
foreach VisibleCollidingActors(Class'Game_PlayerPawn',Player,Radius) {  
ClientSideTrigger(Game_Pawn(EventInstigator),ClientEvent,Player);     
}
} else {                                                                  
if (TriggerAllPlayers) {                                                
AllPlayerClientTrigger(Game_Pawn(EventInstigator),ClientEvent);       
} else {                                                                
if (Game_PlayerPawn(EventInstigator) != None) {                       
ClientSideTrigger(Game_Pawn(EventInstigator),ClientEvent,Game_PlayerPawn(EventInstigator));
}
}
}
}
}
*/