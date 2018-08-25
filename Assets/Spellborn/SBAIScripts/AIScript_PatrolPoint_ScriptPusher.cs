using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_PatrolPoint_ScriptPusher : AI_Script
    {
        [FoldoutGroup("PatrolPoint_ScriptPusher")]
        [FieldConst()]
        public bool TriggerAble;

        [FoldoutGroup("PatrolPoint_ScriptPusher")]
        [FieldConst()]
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();

        [FoldoutGroup("PatrolPoint_ScriptPusher")]
        [FieldConst()]
        public AI_Script Script;

        [FoldoutGroup("PatrolPoint_ScriptPusher")]
        [FieldConst()]
        public bool TriggerPushedScript;

        public List<AttachedPatrolScrtipt> AttachedScripts = new List<AttachedPatrolScrtipt>();

        public AIScript_PatrolPoint_ScriptPusher()
        {
        }

        [Serializable] public struct AttachedPatrolScrtipt
        {
            public Game_AIController Controller;

            public AI_Script Script;
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local ActorRelation newRelation;
Super.GetActorRelations(oRelations);                                        
if (Script != None) {                                                       
newRelation.mActor = Script;                                              
newRelation.mDescription = "Pushed script";                               
newRelation.mColour = static.RGB(255,255,50);                             
oRelations[oRelations.Length] = newRelation;                              
}
}
function bool CheckRequirements(Game_AIController aController) {
local int reqI;
reqI = 0;                                                                   
while (reqI < Requirements.Length) {                                        
if (Requirements[reqI] != None
&& !Requirements[reqI].CheckPawn(Game_Pawn(aController.Pawn))) {
Debug("requirement" @ string(reqI) @ "failed");                         
return False;                                                           
}
reqI++;                                                                   
}
return True;                                                                
}
event OnDetach(Game_AIController aController,AIPoint aPoint) {
local int i;
i = 0;                                                                      
while (i < AttachedScripts.Length) {                                        
if (AttachedScripts[i].Controller == aController) {                       
StopScript(AttachedScripts[i].Controller,AttachedScripts[i].Script);    
AttachedScripts[i].Script.Destroy();                                    
AttachedScripts.Remove(i,1);                                            
Debug("DETACH"
@ AttachedScripts[i].Script.ScriptName()
@ ", #attached scripts:"
@ string(AttachedScripts.Length));
return;                                                                 
}
i++;                                                                      
}
Super.OnDetach(aController,aPoint);                                         
}
state DisabledState {
event Trigger(Actor Other,Pawn EventInstigator) {
if (TriggerAble) {                                                      
GotoState('EnabledState');                                            
}
}
}
state EnabledState {
event UnTrigger(Actor Other,Pawn EventInstigator) {
if (TriggerAble) {                                                      
GotoState('DisabledState');                                           
}
}
event bool AnnotationDone(Game_AIController aController) {
local int i;
i = 0;                                                                  
while (i < AttachedScripts.Length) {                                    
if (AttachedScripts[i].Controller == aController) {                   
if (AttachedScripts[i].Script.AnnotationDone(aController)) {        
return True;                                                      
goto jl005A;                                                      
}
return False;                                                       
}
i++;                                                                  
}
return AnnotationDone(aController);                                     
}
event OnAttach(Game_AIController aController,AIPoint aPoint) {
local AI_Script ScriptInstance;
OnAttach(aController,aPoint);                                           
if (CheckRequirements(aController)) {                                   
ScriptInstance = AI_Script(Script.Clone(False));                      
AttachedScripts.Insert(AttachedScripts.Length,1);                     
AttachedScripts[AttachedScripts.Length - 1].Script = ScriptInstance;  
AttachedScripts[AttachedScripts.Length - 1].Controller = aController; 
StartScript(aController,ScriptInstance);                              
if (TriggerPushedScript) {                                            
ScriptInstance.Trigger(self,aController.Pawn);                      
}
Debug("Attached" @ ScriptInstance.ScriptName()
@ ", #attached scripts:"
@ string(AttachedScripts.Length)
@ string(AttachedScripts[AttachedScripts.Length - 1].Controller)
@ string(aController));
}
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