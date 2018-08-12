using System;
using SBAI;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_Trial45_StatueCollapse : AI_Script
    {
        [FoldoutGroup("StatueCollapse")]
        public string ClientEvent = string.Empty;

        [FoldoutGroup("StatueCollapse")]
        public bool ShakeCamera;

        [FoldoutGroup("StatueCollapse")]
        public float ShakeDelay;

        [FoldoutGroup("StatueCollapse")]
        public string ShakeEvent = string.Empty;

        public bool Shaked;

        public bool Triggered;

        public float ShakeTimeOut;

        public AIScript_Trial45_StatueCollapse()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
GetTaggedRelations(ClientEvent,static.RGB(100,100,255),"ClientEvent:" @ ClientEvent,oRelations);
GetTaggedRelations(ShakeEvent,static.RGB(100,100,255),"ShakeEvent:" @ ShakeEvent,oRelations);
}
function DoShake() {
local Game_PlayerController lController;
foreach AllActors(Class'Game_PlayerController',lController) {               
Game_Pawn(lController.Pawn).sv2clrel_PlayPawnEffect_CallStub(13);         
}
if (ShakeEvent != "" && ShakeEvent != "none") {                             
TriggerEvent(name(ShakeEvent),self,None);                                 
}
Shaked = True;                                                              
}
protected event sv_OnScriptFrame(float DeltaTime) {
if (Triggered && !Shaked && ShakeCamera) {                                  
ShakeTimeOut -= DeltaTime;                                                
if (ShakeTimeOut <= 0) {                                                  
DoShake();                                                              
}
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
Triggered = True;                                                           
if (ShakeCamera) {                                                          
if (ShakeDelay > 0) {                                                     
ShakeTimeOut = ShakeDelay;                                              
} else {                                                                  
DoShake();                                                              
}
}
if (ClientEvent != "" && ClientEvent != "none") {                           
AllPlayerClientTrigger(None,ClientEvent);                                 
}
}
*/