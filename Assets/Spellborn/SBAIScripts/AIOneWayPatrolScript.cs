using System;

namespace SBAIScripts
{
    [Serializable] public class AIOneWayPatrolScript : AIPatrolScript
    {
        public AIOneWayPatrolScript()
        {
        }
    }
}
/*
state Finished {
function BeginState() {
local array<RegisteredAI> reg;
local int ri;
Debug("Finished");                                                      
reg = GetRegister();                                                    
CurrentPoint = None;                                                    
ri = 0;                                                                 
while (ri < reg.Length) {                                               
ChangeToNextScript(reg[ri].Controller);                               
ri++;                                                                 
}
TriggerEvent(Event,self,None);                                          
GotoState('Pending');                                                   
}
}
*/