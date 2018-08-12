using System;
using Engine;
using SBGame;
using UnityEngine;

namespace SBAIScripts
{
    [Serializable] public class AIScript_ClaimAggro : AIRegistered
    {
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Game_Pawn Claimer;

        public AIScript_ClaimAggro()
        {
        }
    }
}
/*
protected function Unclaim(Game_AIController aController) {
local Game_Pawn pwn;
pwn = Game_Pawn(aController.Pawn);                                          
if (pwn == None) {                                                          
return;                                                                   
}
Debug("Unclaiming" @ CharName(aController)
@ "for"
@ CharName(Claimer));
pwn.CombatStats.sv_ScriptedClaim(None);                                     
}
protected function Claim(Game_AIController aController) {
local Game_Pawn pwn;
pwn = Game_Pawn(aController.Pawn);                                          
if (pwn == None) {                                                          
return;                                                                   
}
Debug("Claiming" @ CharName(aController)
@ "for"
@ CharName(Claimer));
pwn.CombatStats.sv_ScriptedClaim(Claimer);                                  
Aggro(aController);                                                         
}
state ClaimedState {
function EndState() {
local array<Game_AIController> reg;
local int ri;
reg = GetRegistered();                                                  
ri = 0;                                                                 
while (ri < reg.Length) {                                               
Unclaim(reg[ri]);                                                     
ri++;                                                                 
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
Debug("Triggered by" @ CharName(EventInstigator)
@ "while claimed");
}
protected function OnRegisterEmptied() {
OnRegisterEmptied();                                                    
GotoState('UnclaimedState');                                            
}
protected function OnRegister(RegisteredAI aRegisteredAI) {
OnRegister(aRegisteredAI);                                              
Claim(aRegisteredAI.Controller);                                        
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
GotoState('UnclaimedState');                                            
}
function BeginState() {
local array<Game_AIController> reg;
local int ri;
reg = GetRegistered();                                                  
ri = 0;                                                                 
while (ri < reg.Length) {                                               
Claim(reg[ri]);                                                       
ri++;                                                                 
}
}
}
auto state UnclaimedState {
event Trigger(Actor Other,Pawn EventInstigator) {
Claimer = Game_Pawn(EventInstigator);                                   
Debug("Claimed by" @ string(Claimer));                                  
if (Claimer != None) {                                                  
GotoState('ClaimedState');                                            
}
}
function BeginState() {
Claimer = None;                                                         
}
}
*/