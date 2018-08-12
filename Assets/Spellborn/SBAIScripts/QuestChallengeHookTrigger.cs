using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class QuestChallengeHookTrigger : AI_Script
    {
        [FoldoutGroup("QuestChallengeHookTrigger")]
        [FieldConst()]
        public string ChallengeTag = string.Empty;

        [FoldoutGroup("QuestChallengeHookTrigger")]
        [FieldConst()]
        public string UnTriggerChallengeTag = string.Empty;

        [FoldoutGroup("QuestChallengeHookTrigger")]
        [FieldConst()]
        public float Radius;

        [FoldoutGroup("QuestChallengeHookTrigger")]
        [FieldConst()]
        public bool ApplyToInstigatorOnly;

        [FoldoutGroup("QuestChallengeHookTrigger")]
        [FieldConst()]
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();

        public QuestChallengeHookTrigger()
        {
        }
    }
}
/*
function DoFireHook(name aTag,Game_PlayerController aController) {
local Game_PlayerController lController;
local int reqI;
if (ApplyToInstigatorOnly) {                                                
reqI = 0;                                                                 
while (reqI < Requirements.Length) {                                      
if (Requirements[reqI] != None
&& !Requirements[reqI].CheckPawn(Game_Pawn(aController.Pawn))) {
Warning("Requirement failed" @ string(reqI));                         
return;                                                               
}
reqI++;                                                                 
}
FireScriptHook(aController,aTag);                                         
} else {                                                                    
if (Radius > 0) {                                                         
foreach RadiusActors(Class'Game_PlayerController',lController,Radius,self.Location) {
reqI = 0;                                                             
while (reqI < Requirements.Length) {                                  
if (Requirements[reqI] != None
&& !Requirements[reqI].CheckPawn(Game_Pawn(lController.Pawn))) {
Warning("QuestChallengeHookTrigger; Requirement failed"
@ string(reqI));
return;                                                           
}
reqI++;                                                             
}
FireScriptHook(lController,aTag);                                     
}
goto jl0249;                                                            
}
foreach DynamicActors(Class'Game_PlayerController',lController) {         
reqI = 0;                                                               
while (reqI < Requirements.Length) {                                    
if (Requirements[reqI] != None
&& !Requirements[reqI].CheckPawn(Game_Pawn(lController.Pawn))) {
Warning("QuestChallengeHookTrigger; Requirement failed"
@ string(reqI));
return;                                                             
}
reqI++;                                                               
}
FireScriptHook(lController,aTag);                                       
}
}
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
if (UnTriggerChallengeTag != ""
&& UnTriggerChallengeTag != "none") { 
DoFireHook(name(UnTriggerChallengeTag),Game_PlayerController(EventInstigator.Controller));
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
if (ChallengeTag != "" && ChallengeTag != "none") {                         
DoFireHook(name(ChallengeTag),Game_PlayerController(EventInstigator.Controller));
}
}
*/