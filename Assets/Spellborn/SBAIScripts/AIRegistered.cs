﻿using System;
using System.Collections.Generic;
using Engine;
using SBAI;

namespace SBAIScripts
{
#pragma warning disable 414   

    [Serializable] public class AIRegistered : AI_Script
    {
        private List<RegisteredAI> Registered = new List<RegisteredAI>();

        [TypeProxyDefinition(TypeName = "RegisteredAI")]
        public Type RegistrationClass;

        public AIRegistered()
        {
        }
    }
}
/*
function array<Game_AIController> GetRegistered() {
local int ri;
local array<Game_AIController> controllers;
CheckRegister();                                                            
ri = 0;                                                                     
while (ri < Registered.Length) {                                            
controllers[ri] = Registered[ri].Controller;                              
ri++;                                                                     
}
return controllers;                                                         
}
function array<RegisteredAI> GetRegister() {
CheckRegister();                                                            
return Registered;                                                          
}
function bool ChangeAllToNextScript(optional Pawn aInstigator) {
local int ri;
local bool allSucceeded;
local array<RegisteredAI> Register;
allSucceeded = True;                                                        
Register = GetRegister();                                                   
if (NextScript != None) {                                                   
ri = 0;                                                                   
while (ri < Register.Length) {                                            
Debug("change"
@ string(Register[ri].Controller)
@ "to next script");
allSucceeded = allSucceeded
&& ChangeToNextScript(Register[ri].Controller,aInstigator);
ri++;                                                                   
}
}
return allSucceeded;                                                        
}
function RegisteredAI GetRegistration(Game_AIController aController) {
local int ri;
if (aController == None) {                                                  
Warning("GetRegistration: aController is None!");                         
}
ri = 0;                                                                     
while (ri < Registered.Length) {                                            
if (aController == Registered[ri].Controller) {                           
return Registered[ri];                                                  
}
ri++;                                                                     
}
return None;                                                                
}
function RegisteredAI GetRandomRegistered() {
CheckRegister();                                                            
if (Registered.Length > 0) {                                                
return Registered[Rand(Registered.Length)];                               
} else {                                                                    
return None;                                                              
}
}
function RegisteredAI GetLastRegistered() {
CheckRegister();                                                            
if (Registered.Length > 0) {                                                
return Registered[Registered.Length - 1];                                 
} else {                                                                    
return None;                                                              
}
}
function RegisteredAI GetFirstRegistered() {
CheckRegister();                                                            
if (Registered.Length > 0) {                                                
return Registered[0];                                                     
} else {                                                                    
return None;                                                              
}
}
function int GetRegisterSize() {
CheckRegister();                                                            
return Registered.Length;                                                   
}
protected function OnRegisterEmptied() {
}
protected function OnUnRegister(RegisteredAI aRegisteredAI) {
}
protected function OnRegister(RegisteredAI aRegisteredAI) {
}
protected final function UnRegister(Game_AIController aController) {
local int ri;
local bool found;
ri = 0;                                                                     
while (ri < Registered.Length) {                                            
if (Registered[ri].Controller == aController) {                           
RemoveIndexFromRegister(ri);                                            
found = True;                                                           
goto jl0055;                                                            
}
ri++;                                                                     
}
Debug("Unregister[Sirenix.OdinInspector.FoldoutGroup(" $ string(Registered.Length)
$ "]"
@ string(Game_NPCPawn(aController.Pawn).NPCType));
if (!found) {                                                               
Warning("Attempt to remove non registered ai controller");                
}
}
protected final function Register(Game_AIController aController) {
local RegisteredAI lRegistered;
lRegistered = new RegistrationClass;                                        
lRegistered.Controller = aController;                                       
Registered[Registered.Length] = lRegistered;                                
Debug("Register[Sirenix.OdinInspector.FoldoutGroup(" $ string(Registered.Length)
$ "]"
@ string(Game_NPCPawn(aController.Pawn).NPCType));
OnRegister(lRegistered);                                                    
}
protected function CheckRegister() {
local int ri;
ri = 0;                                                                     
while (ri < Registered.Length) {                                            
if (Registered[ri].Controller == None) {                                  
Warning("A RegisterdAI with no controller was found, should not be possible!");
} else {                                                                  
if (Registered[ri].Controller.Pawn == None) {                           
Warning("A controller with no pawn was found, should not be possible!");
}
}
ri++;                                                                     
}
}
private function RemoveIndexFromRegister(int aIndex) {
local RegisteredAI lRegisteredAI;
lRegisteredAI = Registered[aIndex];                                         
Registered.Remove(aIndex,1);                                                
OnUnRegister(lRegisteredAI);                                                
if (Registered.Length == 0) {                                               
OnRegisterEmptied();                                                      
}
}
function bool OnDeath(Game_AIController aController,Actor aCollaborator) {
local bool ret;
Debug("OnDeath unregister" @ CharName(aController));                        
ret = Super.OnDeath(aController,aCollaborator);                             
UnRegister(aController);                                                    
return ret;                                                                 
}
function OnDespawn(Game_AIController aController) {
Debug("OnDespawn unregister" @ CharName(aController));                      
Super.OnDespawn(aController);                                               
UnRegister(aController);                                                    
}
function OnEnd(Game_AIController aController) {
Debug("OnEnd unregister" @ CharName(aController));                          
Super.OnEnd(aController);                                                   
UnRegister(aController);                                                    
}
function OnBegin(Game_AIController aController) {
Debug("OnBegin register" @ CharName(aController));                          
Super.OnBegin(aController);                                                 
Register(aController);                                                      
}
*/