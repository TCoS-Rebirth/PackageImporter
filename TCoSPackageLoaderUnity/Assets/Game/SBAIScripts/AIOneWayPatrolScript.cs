﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Engine;
using SBAI;
using SBAIScripts;
using SBBase;
using SBGame;
using SBGamePlay;
using SBMiniGames;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SBAIScripts
{
    
    
    public class AIOneWayPatrolScript : AIPatrolScript
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
