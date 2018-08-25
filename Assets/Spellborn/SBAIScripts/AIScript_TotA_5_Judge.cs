using System;

namespace SBAIScripts
{
    [Serializable] public class AIScript_TotA_5_Judge : AIRegistered
    {
        public AIScript_TotA_5_Judge()
        {
        }
    }
}
/*
event Trigger(Actor Other,Pawn EventInstigator) {
local RegisteredAI lRegistered;
lRegistered = GetFirstRegistered();                                         
if (lRegistered != None) {                                                  
if (!HasPausedAI(lRegistered.Controller)) {                               
PauseAI(lRegistered.Controller);                                        
}
MoveTo(lRegistered.Controller,EventInstigator.Location);                  
LookAt(lRegistered.Controller,EventInstigator.Location);                  
}
}
*/