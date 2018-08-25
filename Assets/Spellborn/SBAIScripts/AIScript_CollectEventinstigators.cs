﻿using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_CollectEventinstigators : AI_Script
    {
        [FoldoutGroup("CollectEventinstigators")]
        public bool OnlyPlayers;

        [FoldoutGroup("CollectEventinstigators")]
        public List<Actor> Collectors = new List<Actor>();

        public List<Game_Controller> Instigators = new List<Game_Controller>();

        public AIScript_CollectEventinstigators()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local ActorRelation newRelation;
local int i;
Super.GetActorRelations(oRelations);                                        
i = 0;                                                                      
while (i < Collectors.Length) {                                             
newRelation.mActor = Collectors[i];                                       
newRelation.mDescription = "";                                            
newRelation.mColour = static.RGB(100,255,100);                            
oRelations[oRelations.Length] = newRelation;                              
i++;                                                                      
}
}
function int FindInstigator(Game_Controller aController) {
local int i;
i = 0;                                                                      
while (i < Instigators.Length) {                                            
if (Instigators[i] == aController) {                                      
return i;                                                               
}
i++;                                                                      
}
return -1;                                                                  
}
function CleanInstigators(optional Game_Controller aController) {
local int i;
i = 0;                                                                      
while (i < Instigators.Length) {                                            
if (Instigators[i] == aController || Instigators[i] == None
|| Instigators[i].IsDead()) {
Instigators.Remove(i,1);                                                
} else {                                                                  
i++;                                                                    
}
i = i;                                                                    
}
}
function RemoveInstigator(Game_Controller aInstigator) {
CleanInstigators(aInstigator);                                              
}
function DoUnTriggerAction(Actor Other,Pawn EventInstigator) {
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
local int i;
local bool UnhandledTrigger;
Super.UnTrigger(Other,EventInstigator);                                     
if (!OnlyPlayers
|| EventInstigator.IsA('Game_PlayerPawn')) {         
if (Collectors.Length > 0) {                                              
UnhandledTrigger = True;                                                
i = 0;                                                                  
while (i < Collectors.Length) {                                         
if (Collectors[i] == Other) {                                         
RemoveInstigator(Game_Controller(EventInstigator.Controller));      
UnhandledTrigger = False;                                           
}
i++;                                                                  
}
} else {                                                                  
RemoveInstigator(Game_Controller(EventInstigator.Controller));          
UnhandledTrigger = False;                                               
}
} else {                                                                    
UnhandledTrigger = True;                                                  
}
if (UnhandledTrigger) {                                                     
DoUnTriggerAction(Other,EventInstigator);                                 
}
}
function AddInstigator(Game_Controller aInstigator) {
local int i;
i = 0;                                                                      
while (i < Instigators.Length) {                                            
if (Instigators[i] == aInstigator) {                                      
return;                                                                 
}
i++;                                                                      
}
Instigators[Instigators.Length] = aInstigator;                              
}
function DoTriggerAction(Actor Other,Pawn EventInstigator) {
}
event Trigger(Actor Other,Pawn EventInstigator) {
local int i;
local bool UnhandledTrigger;
Super.Trigger(Other,EventInstigator);                                       
CleanInstigators();                                                         
if (!OnlyPlayers
|| EventInstigator.IsA('Game_PlayerPawn')) {         
Debug("Added"
@ string(Game_Controller(EventInstigator.Controller))
@ "to collection");
if (Collectors.Length > 0) {                                              
UnhandledTrigger = True;                                                
i = 0;                                                                  
while (i < Collectors.Length) {                                         
if (Collectors[i] == Other) {                                         
AddInstigator(Game_Controller(EventInstigator.Controller));         
UnhandledTrigger = False;                                           
}
i++;                                                                  
}
} else {                                                                  
AddInstigator(Game_Controller(EventInstigator.Controller));             
UnhandledTrigger = False;                                               
}
} else {                                                                    
UnhandledTrigger = True;                                                  
}
if (UnhandledTrigger) {                                                     
DoTriggerAction(Other,EventInstigator);                                   
}
}
*/