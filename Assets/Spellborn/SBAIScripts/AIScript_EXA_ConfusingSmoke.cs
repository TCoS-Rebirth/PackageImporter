﻿using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_EXA_ConfusingSmoke : AI_Script
    {
        [FoldoutGroup("EXA_ConfusingSmoke")]
        public float SmokeTime;

        [FoldoutGroup("EXA_ConfusingSmoke")]
        public float SmokeVisRange;

        [FoldoutGroup("EXA_ConfusingSmoke")]
        public string EffectTag = string.Empty;

        [FoldoutGroup("EXA_ConfusingSmoke")]
        public Actor ConfusedHome;

        public bool Active;

        public float SmokeTimeOut;

        public List<ConfusedController> SmokeNPCs = new List<ConfusedController>();

        public AIScript_EXA_ConfusingSmoke()
        {
        }

        [Serializable] public struct ConfusedController
        {
            public float OriginalRange;

            public Vector OriginalHome;

            public Game_AIController Controller;
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(EffectTag,static.RGB(100,100,255),"EffectTag:" @ EffectTag,oRelations);
}
function ResetSmokeNPCs() {
local int i;
i = 0;                                                                      
while (i < SmokeNPCs.Length) {                                              
SmokeNPCs[i].Controller.SetVisualRange(SmokeNPCs[i].OriginalRange);       
SmokeNPCs[i].Controller.SetHomeLocation(SmokeNPCs[i].OriginalHome);       
i++;                                                                      
}
SmokeNPCs.Length = 0;                                                       
Active = False;                                                             
if (EffectTag != "" && EffectTag != "none") {                               
UntriggerEvent(name(EffectTag),None,None);                                
}
}
function RemoveSmokeNPC(Game_AIController aController) {
local int i;
local int smokeNPCi;
smokeNPCi = -1;                                                             
i = 0;                                                                      
while (i < SmokeNPCs.Length) {                                              
if (SmokeNPCs[i].Controller == aController) {                             
smokeNPCi = i;                                                          
goto jl0054;                                                            
}
i++;                                                                      
}
if (smokeNPCi >= 0) {                                                       
SmokeNPCs[smokeNPCi].Controller.SetVisualRange(SmokeNPCs[smokeNPCi].OriginalRange);
SmokeNPCs[smokeNPCi].Controller.SetHomeLocation(SmokeNPCs[smokeNPCi].OriginalHome);
SmokeNPCs.Remove(smokeNPCi,1);                                            
}
}
function AddSmokeNPC(Game_AIController aController) {
SmokeNPCs.Insert(SmokeNPCs.Length,1);                                       
SmokeNPCs[SmokeNPCs.Length - 1].Controller = aController;                   
SmokeNPCs[SmokeNPCs.Length - 1].OriginalRange = aController.GetVisualRange();
SmokeNPCs[SmokeNPCs.Length - 1].OriginalHome = aController.GetHomeLocation();
aController.SetHomeLocation(ConfusedHome.Location);                         
aController.SetVisualRange(SmokeVisRange);                                  
}
event OnEnd(Game_AIController aController) {
RemoveSmokeNPC(aController);                                                
Super.OnEnd(aController);                                                   
}
event OnDespawn(Game_AIController aController) {
RemoveSmokeNPC(aController);                                                
Super.OnDespawn(aController);                                               
}
event bool OnDeath(Game_AIController aController,Actor aDeceasedActor) {
RemoveSmokeNPC(aController);                                                
return Super.OnDeath(aController,aDeceasedActor);                           
}
function bool CheckSmokePawn(Game_Pawn anOther) {
local int i;
i = 0;                                                                      
while (i < SmokeNPCs.Length) {                                              
if (Game_Pawn(SmokeNPCs[i].Controller.Pawn) == anOther) {                 
return True;                                                            
}
i++;                                                                      
}
return False;                                                               
}
function bool OnCheckFriendly(Game_AIController aGame_AIController,Game_Pawn aPotentialFriend) {
if (Active
&& CheckSmokePawn(Game_Pawn(aGame_AIController.Pawn))) {   
return !CheckSmokePawn(aPotentialFriend);                                 
}
return Super.OnCheckFriendly(aGame_AIController,aPotentialFriend);          
}
function bool OnCheckEnemy(Game_AIController aGame_AIController,Game_Pawn aPotentialEnemy) {
if (Active
&& CheckSmokePawn(Game_Pawn(aGame_AIController.Pawn))) {   
return CheckSmokePawn(aPotentialEnemy);                                   
}
return Super.OnCheckEnemy(aGame_AIController,aPotentialEnemy);              
}
protected event sv_OnScriptFrame(float DeltaTime) {
if (Active) {                                                               
SmokeTimeOut -= DeltaTime;                                                
if (SmokeTimeOut <= 0) {                                                  
ResetSmokeNPCs();                                                       
}
}
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
if (Active) {                                                               
if (Other.IsA('Game_NPCPawn')) {                                          
RemoveSmokeNPC(Game_AIController(EventInstigator.Controller));          
} else {                                                                  
ResetSmokeNPCs();                                                       
}
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
if (Other.IsA('Game_NPCPawn')) {                                            
if (Active) {                                                             
AddSmokeNPC(Game_AIController(EventInstigator.Controller));             
}
} else {                                                                    
if (!Active) {                                                            
SmokeTimeOut = SmokeTime;                                               
Active = True;                                                          
if (EffectTag != "" && EffectTag != "none") {                           
TriggerEvent(name(EffectTag),None,None);                              
}
}
}
}
*/