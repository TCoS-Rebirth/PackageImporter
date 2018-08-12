using System;
using System.Collections.Generic;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_ActionsOnCollected : AIScript_CollectEventinstigators
    {
        [FoldoutGroup("CollectEventinstigators")]
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();

        [FoldoutGroup("CollectEventinstigators")]
        public List<Content_Event> Actions = new List<Content_Event>();

        public AIScript_ActionsOnCollected()
        {
        }
    }
}
/*
function DoTriggerAction(Actor Other,Pawn EventInstigator) {
local int reqI;
local int actI;
local int i;
local Game_Pawn aPawn;
local bool doExecute;
CleanInstigators();                                                         
i = 0;                                                                      
while (i < Instigators.Length) {                                            
aPawn = Game_Pawn(Instigators[i].Pawn);                                   
doExecute = True;                                                         
if (aPawn != None) {                                                      
if (aPawn.SBRole == 1) {                                                
reqI = 0;                                                             
while (reqI < Requirements.Length) {                                  
if (Requirements[reqI] != None
&& !Requirements[reqI].CheckPawn(aPawn)) {
doExecute = False;                                                
}
reqI++;                                                             
}
actI = 0;                                                             
while (actI < Actions.Length) {                                       
if (Actions[actI] != None
&& !Actions[actI].sv_CanExecute(aPawn,aPawn)) {
doExecute = False;                                                
}
actI++;                                                             
}
if (doExecute) {                                                      
actI = 0;                                                           
while (actI < Actions.Length) {                                     
Actions[actI].sv_Execute(aPawn,aPawn);                            
actI++;                                                           
}
}
}
} else {                                                                  
Warning("Instigator is not a Game Pawn!");                              
}
i++;                                                                      
}
}
*/