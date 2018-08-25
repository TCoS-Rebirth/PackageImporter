﻿using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBAI
{
    [Serializable] public class SquadMind : GroupMind
    {
        private Game_AIController mLeader;

        private AIStateMachine mLeaderOldMachine;

        private Vector mLeaderOldHome;

        [FoldoutGroup("SquadMind")]
        [TypeProxyDefinition(TypeName = "AIStateMachine")]
        public Type LeaderMachineClass;

        public SquadMind()
        {
        }
    }
}
/*
function bool IsLeader(Game_AIController aGame_AIController) {
return aGame_AIController != None && mLeader == aGame_AIController;         
}
native function PromoteLeader(Game_AIController aNewLeader);
native function bool PickNewLeader();
event OnDespawn(Game_AIController GroupMember) {
Super.OnDespawn(GroupMember);                                               
if (GroupMember == mLeader) {                                               
mLeader = None;                                                           
PickNewLeader();                                                          
}
}
function bool OnDeath(Game_AIController GroupMember,Actor deceasedActor) {
local bool ret;
ret = Super.OnDeath(GroupMember,deceasedActor);                             
if (GroupMember == mLeader) {                                               
mLeader = None;                                                           
PickNewLeader();                                                          
}
return ret;                                                                 
}
function OnBegin(Game_AIController aSpawn) {
local Game_NPCPawn npcPawn;
Super.OnBegin(aSpawn);                                                      
npcPawn = Game_NPCPawn(aSpawn.Pawn);                                        
if (npcPawn != None) {                                                      
if (mLeader == None) {                                                    
aSpawn.SetHomeLocation(Location);                                       
PromoteLeader(aSpawn);                                                  
} else {                                                                  
aSpawn.SetHomeLocation(npcPawn.Location);                               
}
}
}
state Patrol {
function OnBegin(Game_AIController aSpawn) {
Global.OnBegin(aSpawn);                                                 
CommandMember(aSpawn,47);                                               
}
function BeginState() {
CommandTeam(47);                                                        
}
}
state Return {
function BeginState() {
CommandTeam(44);                                                        
}
}
state Fight {
function EndState() {
CombatStats.sv_ExitCombat();                                            
}
function bool OnDeath(Game_AIController GroupMember,Actor deceasedActor) {
local bool ret;
ret = Global.OnDeath(GroupMember,deceasedActor);                        
if (AllInState(Class'AIRetreatState',True)) {                           
GotoState('Return');                                                  
}
return ret;                                                             
}
function bool OnSpawn(Game_AIController aController,export editinline NPC_Type aNPCType,Vector aLocation) {
return True;                                                            
}
function OnBegin(Game_AIController aSpawn) {
Global.OnBegin(aSpawn);                                                 
CommandMember(aSpawn,43);                                               
}
function BeginState() {
CombatStats.sv_EnterCombat();                                           
CommandTeam(43);                                                        
}
}
state Alert {
function OnBegin(Game_AIController aSpawn) {
Global.OnBegin(aSpawn);                                                 
CommandMember(aSpawn,42);                                               
}
function BeginState() {
CommandTeam(42);                                                        
}
}
auto state Idle {
function BeginState() {
}
}
*/