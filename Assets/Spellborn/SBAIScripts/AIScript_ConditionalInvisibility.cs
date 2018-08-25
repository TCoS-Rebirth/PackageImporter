using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_ConditionalInvisibility : AI_Script
    {
        [FoldoutGroup("AIScript_ConditionalInvisibility")]
        [FieldConst()]
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();

        [FoldoutGroup("AIScript_ConditionalInvisibility")]
        public bool TriggerAble;

        public AIScript_ConditionalInvisibility()
        {
        }
    }
}
/*
protected function OnRegisterEmptied() {
GotoState('InitializeState');                                               
}
protected function bool sv_Check(Game_Pawn aCandidate) {
local int reqI;
reqI = 0;                                                                   
while (reqI < Requirements.Length) {                                        
if (Requirements[reqI] != None
&& !Requirements[reqI].CheckPawn(aCandidate)) {
Debug("Requirements check failed:" @ CharName(aCandidate)
@ "is not invisible");
return False;                                                           
}
reqI++;                                                                   
}
Debug("Requirements check succeeded:"
@ CharName(aCandidate)
@ "is invisible");
return True;                                                                
}
state DisabledState {
event bool OnCheckInvisibility(Game_AIController aController,Game_Pawn aPawn) {
Debug("Invisiblity Check while disabled");                              
return OnCheckInvisibility(aController,aPawn);                          
}
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
event bool OnCheckInvisibility(Game_AIController aController,Game_Pawn aPawn) {
if (sv_Check(aPawn)) {                                                  
return True;                                                          
} else {                                                                
return False;                                                         
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