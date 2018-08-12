using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_AQOrmo_Generic_Mage : AIRegistered
    {
        [FoldoutGroup("GenericOrmoMage")]
        [FieldConst()]
        public NPC_Type OrmoburuNPC;

        [FoldoutGroup("GenericOrmoMage")]
        [FieldConst()]
        public string ChargingEvent = string.Empty;

        public bool Active;

        public Game_Pawn OrmoburuPawn;

        public AIScript_AQOrmo_Generic_Mage()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(ChargingEvent,static.RGB(255,100,255),"ChargingEvent:" @ ChargingEvent,oRelations);
}
function bool OnDeath(Game_AIController aController,Actor aCollaborator) {
if (ChargingEvent != "" && ChargingEvent != "None") {                       
UntriggerEvent(name(ChargingEvent),self,aController.Pawn);                
}
ContinueAI(aController);                                                    
return Super.OnDeath(aController,aCollaborator);                            
}
event Trigger(Actor Other,Pawn EventInstigator) {
local int i;
local array<Game_AIController> registeredControllers;
registeredControllers = GetRegistered();                                    
Active = True;                                                              
if (OrmoburuPawn == None) {                                                 
OrmoburuPawn = GetNPC(OrmoburuNPC);                                       
}
i = 0;                                                                      
while (i < registeredControllers.Length) {                                  
PauseAI(registeredControllers[i]);                                        
SetTarget(registeredControllers[i],OrmoburuPawn);                         
SetFreeze(Game_Pawn(registeredControllers[i].Pawn),True,True,False,False);
i++;                                                                      
}
if (ChargingEvent != "" && ChargingEvent != "None") {                       
TriggerEvent(name(ChargingEvent),self,registeredControllers[i].Pawn);     
}
}
*/