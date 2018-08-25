﻿using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBAIScripts
{
#pragma warning disable 414   

    [Serializable] public class AI_Script_Pusher : AIRegistered
    {
        [FoldoutGroup("Scripts_Pusher")]
        [FieldConst()]
        public AI_Script Script;

        [FoldoutGroup("Scripts_Pusher")]
        [FieldConst()]
        public int MaxPushedPerTrigger;

        [FoldoutGroup("Scripts_Pusher")]
        [FieldConst()]
        public bool TriggerPushedScript;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private List<PushedScript> mPushedScripts = new List<PushedScript>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int mPushedPerTriggerCount;

        public AI_Script_Pusher()
        {
        }

        [Serializable] public struct PushedScript
        {
            public AI_Script ScriptInstance;

            public Game_PlayerPawn EvenInstigator;

            public List<Game_AIController> controllers;
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
function RemoveControllerFromScript(Game_AIController aController,optional AI_Script aScriptInstance) {
local int ip;
local int ic;
ip = 0;                                                                     
while (ip < mPushedScripts.Length) {                                        
if (aScriptInstance == None
|| mPushedScripts[ip].ScriptInstance == aScriptInstance) {
ic = 0;                                                                 
while (ic < mPushedScripts[ip].controllers.Length) {                    
if (mPushedScripts[ip].controllers[ic] == aController) {              
Debug("End of script" @ aScriptInstance.ScriptName());              
mPushedScripts[ip].controllers.Remove(ic,1);                        
if (mPushedScripts[ip].controllers.Length == 0) {                   
Debug("Clean up script"
@ mPushedScripts[ip].ScriptInstance.ScriptName());
mPushedScripts[ip].ScriptInstance.Destroy();                      
mPushedScripts.Remove(ip,1);                                      
}
return;                                                             
}
ic++;                                                                 
}
}
ip++;                                                                     
}
}
function OnEndScript(Game_AIController aController,AI_Script aScriptInstance) {
Super.OnEndScript(aController,aScriptInstance);                             
RemoveControllerFromScript(aController,aScriptInstance);                    
}
function PopScript(int aPushedScriptID) {
local int ic;
if (mPushedScripts[aPushedScriptID].ScriptInstance != None) {               
ic = 0;                                                                   
while (ic < mPushedScripts[aPushedScriptID].controllers.Length) {         
if (mPushedScripts[aPushedScriptID].controllers[ic].HasMetaController(mPushedScripts[aPushedScriptID].ScriptInstance)) {
StopScript(mPushedScripts[aPushedScriptID].controllers[ic],mPushedScripts[aPushedScriptID].ScriptInstance);
}
ic++;                                                                   
}
}
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
local int ip;
local int ic;
if (Other.IsA('Game_NPCPawn')
|| EventInstigator.IsA('Game_PlayerPawn')) {
ip = 0;                                                                   
while (ip < mPushedScripts.Length) {                                      
if (mPushedScripts[ip].EvenInstigator == EventInstigator) {             
PopScript(ip);                                                        
break;                                                                
} else {                                                                
ic = 0;                                                               
while (ic < mPushedScripts[ip].controllers.Length) {                  
if (mPushedScripts[ip].controllers[ic] == Game_AIController(Game_Pawn(Other).Controller)) {
PopScript(ip);                                                    
goto jl00D9;                                                      
}
ic++;                                                               
}
}
ip++;                                                                   
}
goto jl0112;                                                              
}
ip = 0;                                                                     
while (ip < mPushedScripts.Length) {                                        
PopScript(ip);                                                            
ip++;                                                                     
}
}
function PushScript(Game_AIController aController,AI_Script aScriptInstance,int aPushedScriptID) {
if (MaxPushedPerTrigger == 0
|| mPushedPerTriggerCount < MaxPushedPerTrigger) {
if (!aController.HasMetaController(aScriptInstance)) {                    
mPushedPerTriggerCount++;                                               
StartScript(aController,aScriptInstance);                               
mPushedScripts[aPushedScriptID].controllers[mPushedScripts[aPushedScriptID].controllers.Length] = aController;
}
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
local int ip;
local int ic;
local AI_Script ScriptInstance;
local array<Game_AIController> registeredControllers;
ip = 0;                                                                     
while (ip < mPushedScripts.Length) {                                        
if (mPushedScripts[ip].ScriptInstance == None) {                          
mPushedScripts.Remove(ip,1);                                            
ip--;                                                                   
}
ip++;                                                                     
}
Debug("Pushing script" @ ScriptInstance.ScriptName());                      
if (Script != None) {                                                       
ScriptInstance = AI_Script(Script.Clone(False));                          
registeredControllers = GetRegistered();                                  
mPushedScripts.Insert(mPushedScripts.Length,1);                           
mPushedScripts[mPushedScripts.Length - 1].ScriptInstance = ScriptInstance;
mPushedPerTriggerCount = 0;                                               
if (EventInstigator.IsA('Game_PlayerPawn')) {                             
mPushedScripts[mPushedScripts.Length - 1].EvenInstigator = Game_PlayerPawn(EventInstigator);
}
if (Other != None && Other.IsA('Game_Pawn')
&& Game_Pawn(Other).Controller.IsA('Game_AIController')) {
PushScript(Game_AIController(Game_Pawn(Other).Controller),ScriptInstance,mPushedScripts.Length - 1);
}
ic = 0;                                                                   
while (ic < registeredControllers.Length) {                               
if (registeredControllers[ic].Pawn != Game_Pawn(Other)) {               
PushScript(registeredControllers[ic],ScriptInstance,mPushedScripts.Length - 1);
}
ic++;                                                                   
}
if (TriggerPushedScript) {                                                
ScriptInstance.Trigger(self,EventInstigator);                           
}
}
}
*/