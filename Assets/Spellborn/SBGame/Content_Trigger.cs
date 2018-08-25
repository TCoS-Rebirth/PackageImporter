﻿using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class Content_Trigger : InsideTrigger
    {
        [FoldoutGroup("PseudoScript")]
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();

        [FoldoutGroup("PseudoScript")]
        public List<Content_Event> Actions = new List<Content_Event>();

        [FoldoutGroup("PseudoScript")]
        public List<Content_Event> Unactions = new List<Content_Event>();

        [FoldoutGroup("PseudoScript")]
        public List<Content_Event> FirstInActions = new List<Content_Event>();

        [FoldoutGroup("PseudoScript")]
        public List<Content_Event> LastOutUnactions = new List<Content_Event>();

        public Content_Trigger()
        {
        }
    }
}
/*
function OnLeavePawn(Game_Pawn aPawn) {
local int actionI;
local bool doExecute;
if (aPawn.SBRole == 1) {                                                    
doExecute = True;                                                         
actionI = 0;                                                              
while (actionI < Unactions.Length) {                                      
if (Unactions[actionI] != None
&& !Unactions[actionI].sv_CanExecute(aPawn,aPawn)) {
doExecute = False;                                                    
goto jl0084;                                                          
}
actionI++;                                                              
}
if (doExecute) {                                                          
actionI = 0;                                                            
while (actionI < Unactions.Length) {                                    
Unactions[actionI].sv_Execute(aPawn,aPawn);                           
actionI++;                                                            
}
}
if (PawnsInside.Length == 0) {                                            
doExecute = True;                                                       
actionI = 0;                                                            
while (actionI < LastOutUnactions.Length) {                             
if (LastOutUnactions[actionI] != None
&& !LastOutUnactions[actionI].sv_CanExecute(aPawn,aPawn)) {
doExecute = False;                                                  
goto jl0144;                                                        
}
actionI++;                                                            
}
if (doExecute) {                                                        
actionI = 0;                                                          
while (actionI < LastOutUnactions.Length) {                           
LastOutUnactions[actionI].sv_Execute(aPawn,aPawn);                  
actionI++;                                                          
}
}
}
}
Super.OnLeavePawn(aPawn);                                                   
}
function OnEnterPawn(Game_Pawn aPawn) {
local int actionI;
local bool doExecute;
Super.OnEnterPawn(aPawn);                                                   
if (aPawn.SBRole == 1) {                                                    
doExecute = True;                                                         
actionI = 0;                                                              
while (actionI < Actions.Length) {                                        
if (Actions[actionI] != None
&& !Actions[actionI].sv_CanExecute(aPawn,aPawn)) {
doExecute = False;                                                    
goto jl008F;                                                          
}
actionI++;                                                              
}
if (doExecute) {                                                          
actionI = 0;                                                            
while (actionI < Actions.Length) {                                      
Actions[actionI].sv_Execute(aPawn,aPawn);                             
actionI++;                                                            
}
}
if (PawnsInside.Length == 1) {                                            
doExecute = True;                                                       
actionI = 0;                                                            
while (actionI < FirstInActions.Length) {                               
if (FirstInActions[actionI] != None
&& !FirstInActions[actionI].sv_CanExecute(aPawn,aPawn)) {
doExecute = False;                                                  
goto jl014F;                                                        
}
actionI++;                                                            
}
if (doExecute) {                                                        
actionI = 0;                                                          
while (actionI < FirstInActions.Length) {                             
FirstInActions[actionI].sv_Execute(aPawn,aPawn);                    
actionI++;                                                          
}
}
}
}
}
function bool CheckPawn(Game_Pawn aPawn) {
local int reqI;
if (aPawn.SBRole == 1) {                                                    
if (aPawn != None) {                                                      
reqI = 0;                                                               
while (reqI < Requirements.Length) {                                    
if (Requirements[reqI] != None
&& !Requirements[reqI].CheckPawn(aPawn)) {
return False;                                                       
}
reqI++;                                                               
}
}
return True;                                                              
} else {                                                                    
return False;                                                             
}
}
*/