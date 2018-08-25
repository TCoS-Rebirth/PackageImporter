﻿using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_AQOrmo_Vhelgar_Hunter : AIRegistered
    {
        [FoldoutGroup("VhelgarHunter")]
        [FieldConst()]
        [TypeProxyDefinition(TypeName = "AIStateMachine")]
        public Type ActiveMachineClass;

        [FoldoutGroup("VhelgarHunter")]
        [FieldConst()]
        public string DeathEvent = string.Empty;

        [FoldoutGroup("VhelgarHunter")]
        [FieldConst()]
        public List<Actor> EscapePoints = new List<Actor>();

        public bool Active;

        public AIScript_AQOrmo_Vhelgar_Hunter()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local ActorRelation newRelation;
local int i;
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(DeathEvent,static.RGB(100,100,255),"DeathEvent:" @ DeathEvent,oRelations);
i = 0;                                                                      
while (i < EscapePoints.Length) {                                           
newRelation.mActor = EscapePoints[i];                                     
newRelation.mDescription = "Escape point";                                
newRelation.mColour = static.RGB(100,255,100);                            
oRelations[oRelations.Length] = newRelation;                              
i++;                                                                      
}
}
function bool OnDeath(Game_AIController aController,Actor aCollaborator) {
if (Active && DeathEvent != "" && DeathEvent != "none") {                   
TriggerEvent(name(DeathEvent),self,aController.Pawn);                     
}
return Super.OnDeath(aController,aCollaborator);                            
}
function bool OnTimerEnded(Game_AIController aGame_AIController,Actor aInstigator,name aTag) {
if (aInstigator == self && aTag == 'DespawnHunter') {                       
ContinueAI(aGame_AIController);                                           
Despawn(aGame_AIController);                                              
}
return Super.OnTimerEnded(aGame_AIController,aInstigator,aTag);             
}
event Trigger(Actor Other,Pawn EventInstigator) {
local int i;
local array<Game_AIController> registeredControllers;
registeredControllers = GetRegistered();                                    
if (!Active) {                                                              
Active = True;                                                            
i = 0;                                                                    
while (i < registeredControllers.Length) {                                
SwapStateMachine(registeredControllers[i],new ActiveMachineClass);      
i++;                                                                    
}
} else {                                                                    
Active = False;                                                           
i = 0;                                                                    
while (i < registeredControllers.Length) {                                
PauseAI(registeredControllers[i]);                                      
sheathWeapon(registeredControllers[i]);                                 
MoveTo(registeredControllers[i],EscapePoints[Rand(EscapePoints.Length)].Location);
StartTimer(registeredControllers[i],'DespawnHunter',5.00000000);        
i++;                                                                    
}
}
}
*/