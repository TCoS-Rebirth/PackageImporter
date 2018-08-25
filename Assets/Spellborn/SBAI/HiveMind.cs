﻿using System;
using System.Collections.Generic;
using SBGame;

namespace SBAI
{
    [Serializable] public class HiveMind : GroupMind
    {
        public const float RedetectTime = 0.5F;

        public List<Game_Pawn> Targets = new List<Game_Pawn>();

        public float RedetectTimer;

        public HiveMind()
        {
        }
    }
}
/*
protected function EnableDetection() {
RedetectTimer = 0.00000000;                                                 
}
protected function DisableDetection() {
RedetectTimer = -1.00000000;                                                
}
function OnBegin(Game_AIController aSpawn) {
local Game_NPCPawn npcPawn;
Super.OnBegin(aSpawn);                                                      
npcPawn = Game_NPCPawn(aSpawn.Pawn);                                        
aSpawn.SetHomeLocation(npcPawn.Location);                                   
}
state Return {
function BeginState() {
DisableDetection();                                                     
CommandTeam(44);                                                        
}
}
state Fight {
function EndState() {
CombatStats.sv_ExitCombat();                                            
}
function OnBegin(Game_AIController aSpawn) {
Global.OnBegin(aSpawn);                                                 
CommandMember(aSpawn,43);                                               
}
function BeginState() {
EnableDetection();                                                      
CombatStats.sv_EnterCombat();                                           
CommandTeam(43);                                                        
}
}
state Alert {
function BeginState() {
EnableDetection();                                                      
}
}
state Idle {
function BeginState() {
EnableDetection();                                                      
}
}
auto state Spawning {
function OnBegin(Game_AIController aSpawn) {
GotoState('Idle');                                                      
OnBegin(aSpawn);                                                        
}
function BeginState() {
DisableDetection();                                                     
}
}
*/