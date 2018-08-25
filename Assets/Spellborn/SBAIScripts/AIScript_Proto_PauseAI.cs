using System;

namespace SBAIScripts
{
    [Serializable] public class AIScript_Proto_PauseAI : AIRegistered
    {
        public AIScript_Proto_PauseAI()
        {
        }
    }
}
/*
event UnTrigger(Actor Other,Pawn EventInstigator) {
local array<Game_AIController> regs;
local int ri;
Super.UnTrigger(Other,EventInstigator);                                     
regs = GetRegistered();                                                     
ri = 0;                                                                     
while (ri < regs.Length) {                                                  
ContinueAI(regs[ri]);                                                     
ri++;                                                                     
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
local array<Game_AIController> regs;
local int ri;
Super.Trigger(Other,EventInstigator);                                       
regs = GetRegistered();                                                     
ri = 0;                                                                     
while (ri < regs.Length) {                                                  
PauseAI(regs[ri]);                                                        
ri++;                                                                     
}
}
function OnBegin(Game_AIController aGame_AIController) {
Super.OnBegin(aGame_AIController);                                          
}
*/