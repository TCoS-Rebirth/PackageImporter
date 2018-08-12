using System;
using System.Collections.Generic;
using Engine;
using SBBase;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Deadspell_GameInfo : Game_GameInfo
    {
        [FoldoutGroup("Deadspell")]
        public NameProperty DebugDeadspellTag;

        public SBWorld DeathWorld;

        public SBPortal DeathPortal;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<Game_InstanceInfo> mInstances = new List<Game_InstanceInfo>();

        public Deadspell_GameInfo()
        {
        }
    }
}
/*
event sv_DeadspellFinished(int InstanceID) {
local int idx;
idx = 0;                                                                    
while (idx < mInstances.Length) {                                           
if (mInstances[idx].mInstanceId == InstanceID) {                          
mInstances[idx].sv_InstanceFinished();                                  
sv_RemoveInstanceIfEmpty(idx);                                          
return;                                                                 
}
idx++;                                                                    
}
}
function bool PlayerDied(Controller aController) {
local int idx;
local bool Result;
if (IsServer()
&& Game_PlayerController(aController) != None
&& Game_PlayerPawn(Game_PlayerController(aController).Pawn) != None) {
idx = 0;                                                                  
while (idx < mInstances.Length) {                                         
if (mInstances[idx].sv_ContainsController(Game_PlayerController(aController))) {
Result = mInstances[idx].sv_DeathTeleport(Game_PlayerController(aController));
sv_RemoveInstanceIfEmpty(idx);                                        
return Result;                                                        
}
idx++;                                                                  
}
}
return False;                                                               
}
private function sv_RemoveInstanceIfEmpty(int instanceIdx) {
if (mInstances[instanceIdx].sv_IsEmpty()) {                                 
DestroyInstanceInfo(mInstances[instanceIdx]);                             
mInstances.Remove(instanceIdx,1);                                         
}
}
private function sv_RemovePlayer(Controller PlayerController) {
local int idx;
idx = 0;                                                                    
while (idx < mInstances.Length) {                                           
if (mInstances[idx].sv_ContainsController(Game_PlayerController(PlayerController))) {
mInstances[idx].sv_RemovePlayer(Game_PlayerController(PlayerController));
sv_RemoveInstanceIfEmpty(idx);                                          
return;                                                                 
}
idx++;                                                                    
}
}
private function sv_AddPlayer(Controller PlayerController,string RouteName) {
local int idx;
local Game_InstanceInfo instanceInfo;
local SBRoute SBRoute;
SBRoute = FindRoute(RouteName);                                             
idx = 0;                                                                    
while (idx < mInstances.Length) {                                           
if (PlayerController.Instance == mInstances[idx].sv_GetInstance()) {      
mInstances[idx].sv_AddPlayer(Game_PlayerController(PlayerController),SBRoute);
return;                                                                 
}
idx++;                                                                    
}
instanceInfo = new Class'Game_InstanceInfo';                                
instanceInfo.mInstanceId = PlayerController.Instance;                       
instanceInfo.mFirstLogin = False;                                           
instanceInfo.mTime = 0.00000000;                                            
instanceInfo.mDeathWorld = DeathWorld;                                      
instanceInfo.mDeathPortal = DeathPortal;                                    
if (SBRoute != None) {                                                      
instanceInfo.mDestinationWorld = SBRoute.DestinationWorld;                
instanceInfo.mDestinationPortal = SBRoute.DestinationPortal;              
}
if (Game_Route(SBRoute) != None) {                                          
instanceInfo.mEffectsTag = Game_Route(SBRoute).EffectsTag;                
}
instanceInfo.sv_AddPlayer(Game_PlayerController(PlayerController),SBRoute); 
mInstances[mInstances.Length] = instanceInfo;                               
}
private event sv_Ready(Game_PlayerController PlayerController) {
local int idx;
idx = 0;                                                                    
while (idx < mInstances.Length) {                                           
if (mInstances[idx].sv_ContainsController(PlayerController)) {            
mInstances[idx].sv_TriggerEffects(self,PlayerController);               
mInstances[idx].mFirstLogin = True;                                     
return;                                                                 
}
idx++;                                                                    
}
}
event sv_OnPostLogin(Game_PlayerPawn aPawn) {
Super.sv_OnPostLogin(aPawn);                                                
sv_Ready(Game_PlayerController(aPawn.Controller));                          
}
event sv_OnLogout(int aAccountID,Base_Pawn aPawn) {
if (aPawn != None) {                                                        
sv_RemovePlayer(aPawn.Controller);                                        
}
Super.sv_OnLogout(aAccountID,aPawn);                                        
}
event sv_OnLogin(Game_PlayerController aController,string portalName,string RouteName) {
Super.sv_OnLogin(aController,portalName,RouteName);                         
sv_AddPlayer(aController,RouteName);                                        
}
event PostBeginPlay() {
DeadspellParseInstanceOptions("");                                          
}
native function DestroyInstanceInfo(Game_InstanceInfo instanceInfo);
native function SBRoute FindRoute(string RouteName);
native function DeadspellParseInstanceOptions(string Options);
*/