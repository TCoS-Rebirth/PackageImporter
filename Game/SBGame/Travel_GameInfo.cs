﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;


namespace SBGame
{


    public class Travel_GameInfo : Deadspell_GameInfo
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Travel")]
        public float DurationSec;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Scenarios")]
        public List<TravelScenario> TravelScenarios = new List<TravelScenario>();
        
        public int mDebugScenario;
        
        public Travel_GameInfo()
        {
        }
        
        public struct TravelScenario
        {
            
            public List<string> StartEvents;
            
            public int FromLevel;
            
            public int ToLevel;
        }
    }
}
/*
event TravelStarted(int InstanceID) {
local int instanceIdx;
local int eventIdx;
local array<int> ScenarioSeverity;
local int si;
local int Pi;
local int pLvl;
local bool anyScenarios;
local Game_Pawn gamePawn;
instanceIdx = 0;                                                            
while (instanceIdx < mInstances.Length) {                                   
if (mInstances[instanceIdx].mInstanceId == InstanceID) {                  
if (mDebugScenario != -1) {                                             
eventIdx = Rand(TravelScenarios[mDebugScenario].StartEvents.Length);  
if (TravelScenarios[mDebugScenario].StartEvents[eventIdx] != 'None') {
gamePawn = mInstances[instanceIdx].mPlayers[0].sv_GetPawn();        
gamePawn.TriggerEvent(TravelScenarios[mDebugScenario].StartEvents[eventIdx],self,gamePawn);
return;                                                             
}
}
si = 0;                                                                 
while (si < TravelScenarios.Length) {                                   
ScenarioSeverity[si] = 0;                                             
Pi = 0;                                                               
while (Pi < mInstances[instanceIdx].mPlayers.Length) {                
pLvl = mInstances[instanceIdx].mPlayers[Pi].sv_GetPawn().CharacterStats.GetFameLevel();
if (pLvl >= TravelScenarios[si].FromLevel
&& pLvl <= TravelScenarios[si].ToLevel) {
ScenarioSeverity[si]++;                                           
anyScenarios = True;                                              
}
Pi++;                                                               
}
si++;                                                                 
}
if (anyScenarios) {                                                     
si = 0;                                                               
while (si < TravelScenarios.Length) {                                 
if (ScenarioSeverity[si] > 0) {                                     
eventIdx = Rand(TravelScenarios[si].StartEvents.Length);          
if (TravelScenarios[si].StartEvents[eventIdx] != 'None') {        
gamePawn = mInstances[instanceIdx].mPlayers[0].sv_GetPawn();    
gamePawn.TriggerEvent(TravelScenarios[mDebugScenario].StartEvents[eventIdx],self,gamePawn);
}
}
si++;                                                               
}
}
return;                                                                 
}
instanceIdx++;                                                            
}
}
native event UnTrigger(Actor Other,Pawn EventInstigator);
event PostBeginPlay() {
Super.PostBeginPlay();                                                      
Tag = 'Travel_GameInfo';                                                    
TravelParseInstanceOptions("");                                             
}
native function TravelParseInstanceOptions(string Options);
*/