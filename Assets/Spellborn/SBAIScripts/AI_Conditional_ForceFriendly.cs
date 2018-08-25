using System;
using System.Collections.Generic;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AI_Conditional_ForceFriendly : AIRegistered
    {
        [FoldoutGroup("AI_Conditional_ForceFriendly")]
        [FieldConst()]
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();

        [FoldoutGroup("AI_Conditional_ForceFriendly")]
        public bool TriggerAble;

        public AI_Conditional_ForceFriendly()
        {
        }
    }
}
/*
protected function OnRegisterEmptied() {
GotoState('InitializeState');                                               
}
protected function bool sv_Check(Game_Pawn aCandidate) {
local array<Game_Pawn> team;
local int i;
local Game_PlayerController PC;
PC = Game_PlayerController(aCandidate.Controller);                          
if (PC != None && PC.GroupingTeams != None) {                               
PC.GroupingTeams.sv_GetTeamMembers(team);                                 
if (team.Length > 0) {                                                    
i = 0;                                                                  
while (i < team.Length) {                                               
if (sv_CheckSinglePawn(team[i])) {                                    
return True;                                                        
}
i++;                                                                  
}
return False;                                                           
}
}
return sv_CheckSinglePawn(aCandidate);                                      
}
protected function bool sv_CheckSinglePawn(Game_Pawn aCandidate) {
local int reqI;
reqI = 0;                                                                   
while (reqI < Requirements.Length) {                                        
if (Requirements[reqI] != None
&& !Requirements[reqI].CheckPawn(aCandidate)) {
Debug("Requirements check [Sirenix.OdinInspector.FoldoutGroup(" $ string(reqI)
$ "]="
@ string(Requirements[reqI])
@ "failed:"
@ CharName(aCandidate)
@ "is not an enemy");
return False;                                                           
}
reqI++;                                                                   
}
Debug("Requirements check succeeded:"
@ CharName(aCandidate)
@ "is an enemy");
return True;                                                                
}
state DisabledState {
event Trigger(Actor Other,Pawn EventInstigator) {
GotoState('EnabledState');                                              
}
}
state EnabledState {
event UnTrigger(Actor Other,Pawn EventInstigator) {
if (TriggerAble) {                                                      
GotoState('DisabledState');                                           
}
}
function bool OnCheckFriendly(Game_AIController aGame_AIController,Game_Pawn potentialAlly) {
if (sv_Check(potentialAlly)) {                                          
return True;                                                          
}
return OnCheckFriendly(aGame_AIController,potentialAlly);               
}
function bool OnCheckEnemy(Game_AIController aGame_AIController,Game_Pawn potentialEnemy) {
if (sv_Check(potentialEnemy)) {                                         
return False;                                                         
}
return OnCheckEnemy(aGame_AIController,potentialEnemy);                 
}
}
auto state InitializeState {
function BeginState() {
if (TriggerAble) {                                                      
GotoState('DisabledState');                                           
} else {                                                                
GotoState('EnabledState');                                            
}
}
}
*/