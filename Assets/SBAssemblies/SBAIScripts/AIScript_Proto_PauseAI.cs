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
    
    
    [System.Serializable] public class AIScript_Proto_PauseAI : AIRegistered
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
