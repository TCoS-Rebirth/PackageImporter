using System;
using System.Collections.Generic;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AI_TriggerActions : AIRegistered
    {
        [FoldoutGroup("TriggerActions")]
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();

        [FoldoutGroup("TriggerActions")]
        public List<Content_Event> Actions = new List<Content_Event>();

        [FoldoutGroup("TriggerActions")]
        public List<Content_Event> Unactions = new List<Content_Event>();

        public AI_TriggerActions()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local int i;
Super.GetActorRelations(oRelations);                                        
i = 0;                                                                      
while (i < Actions.Length) {                                                
Actions[i].GetActorRelations(self,oRelations);                            
i++;                                                                      
}
i = 0;                                                                      
while (i < Unactions.Length) {                                              
Unactions[i].GetActorRelations(self,oRelations);                          
i++;                                                                      
}
i = 0;                                                                      
while (i < Requirements.Length) {                                           
Requirements[i].GetActorRelations(self,oRelations);                       
i++;                                                                      
}
}
function PerformActionsOnRegistered(array<Content_Event> aActions,array<Content_Requirement> aRequirements) {
local int i;
local int reqI;
local int actI;
local Game_Pawn gPawn;
local bool canPerformActions;
local array<Game_AIController> registeredControllers;
registeredControllers = GetRegistered();                                    
i = 0;                                                                      
while (i < registeredControllers.Length) {                                  
canPerformActions = True;                                                 
gPawn = Game_Pawn(registeredControllers[i].Pawn);                         
if (gPawn != None && gPawn.SBRole == 1) {                                 
reqI = 0;                                                               
while (reqI < aRequirements.Length) {                                   
if (aRequirements[reqI] != None
&& !aRequirements[reqI].CheckPawn(gPawn)) {
Warning("Requirement" @ string(reqI) @ "failed!");                  
canPerformActions = False;                                          
goto jl00F5;                                                        
}
reqI++;                                                               
}
if (!canPerformActions) {                                               
goto jl0200;                                                          
}
actI = 0;                                                               
while (actI < aActions.Length) {                                        
if (aActions[actI] != None
&& !aActions[actI].sv_CanExecute(gPawn,gPawn)) {
Warning("Can't perform action" @ string(actI)
@ "!"); 
canPerformActions = False;                                          
goto jl0190;                                                        
}
actI++;                                                               
}
if (!canPerformActions) {                                               
} else {                                                                
actI = 0;                                                             
while (actI < aActions.Length) {                                      
if (aActions[actI] != None) {                                       
aActions[actI].sv_Execute(gPawn,gPawn);                           
}
actI++;                                                             
}
ChangeToNextScript(registeredControllers[i]);                         
}
}
i++;                                                                      
}
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
PerformActionsOnRegistered(Unactions,Requirements);                         
Super.UnTrigger(Other,EventInstigator);                                     
}
event Trigger(Actor Other,Pawn EventInstigator) {
Super.Trigger(Other,EventInstigator);                                       
PerformActionsOnRegistered(Actions,Requirements);                           
}
*/