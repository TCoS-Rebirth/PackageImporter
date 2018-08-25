﻿using System;
using System.Collections.Generic;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAI
{
    [Serializable] public class GroupMind : AI_MetaController
    {
        public NPC_Taxonomy mFaction;

        public float LootTimeout;

        public Meta_CombatStats CombatStats;

        [FoldoutGroup("GroupMind")]
        public float VisualRange;

        [FoldoutGroup("GroupMind")]
        public float LineOfSightRange;

        [FoldoutGroup("GroupMind")]
        public float ThreatRange;

        [FoldoutGroup("GroupMind")]
        public float ChaseRange;

        [FoldoutGroup("GroupMind")]
        public NPC_Habitat Habitat;

        [FoldoutGroup("GroupMind")]
        public float SocialAggroFactor;

        public List<GroupMember> GroupMembers = new List<GroupMember>();

        public Game_Team mTeam;

        public GroupMind()
        {
        }

        [Serializable] public struct GroupMember
        {
            public Game_AIController Controller;

            public Game_NPCPawn Pawn;

            public bool Alive;

            public int FameLevel;

            public int PePRank;

            public NPC_Type Type;

            public Type State;
        }
    }
}
/*
protected final native function bool NoneInState(class<AIState> aState);
protected final native function bool AllInState(class<AIState> aState,bool aAllowIdle);
final native function CommandMember(Game_AIController aGame_AIController,byte aSignal);
final native function CommandTeam(byte aSignal);
function GiveKillCredit(Vector aCenterLocation) {
local Game_Pawn Killer;
local Game_PlayerController PlayerController;
local array<Game_Pawn> Enemies;
local float singleFame;
local float totalFame;
local float singlePep;
local float totalPep;
local int gi;
local Loot_Manager lootManager;
local array<LootTable> Loot;
local int li;
Killer = CombatStats.sv_GetKiller();                                        
if (Killer != None) {                                                       
PlayerController = Game_PlayerController(Killer.Controller);              
if (PlayerController != None) {                                           
PlayerController.GroupingTeams.sv_GetCreditTeam(Enemies,aCenterLocation);
if (Enemies.Length > 0) {                                               
CombatStats.sv_QuestCredit(Enemies);                                  
totalFame = 0.00000000;                                               
totalPep = 0.00000000;                                                
gi = 0;                                                               
while (gi < GroupMembers.Length) {                                    
if (!GroupMembers[gi].Type.IndividualKillCredit) {                  
CombatStats.sv_FamePepCredit(Enemies,GroupMembers[gi].Type.CreditMultiplier,GroupMembers[gi].FameLevel,GroupMembers[gi].PePRank,singleFame,singlePep);
totalFame += singleFame;                                          
totalPep += singlePep;                                            
li = 0;                                                           
while (li < GroupMembers[gi].Type.Loot.Length) {                  
Loot[Loot.Length] = GroupMembers[gi].Type.Loot[li];             
li++;                                                           
}
}
gi++;                                                               
}
CombatStats.sv_FamePepDistribution(Enemies,totalFame,totalPep);       
if (mFaction != None) {                                               
mFaction.AppendLoot(Loot);                                          
}
if (Loot.Length > 0) {                                                
lootManager = Class'Loot_Manager'.static.sv_GetInstance();          
if (lootManager != None) {                                          
lootManager.sv_CreateTransaction(Loot,Enemies,LootTimeout,PlayerController.GroupingTeams.GetTeamLootMode());
}
}
}
}
goto jl024E;                                                              
}
CombatStats.sv_OnEndAggro();                                                
}
event bool OnDetectEnemy(Game_AIController anObserver,Game_Pawn anEnemy) {
local Game_PlayerController PlayerController;
PlayerController = Game_PlayerController(anEnemy.Controller);               
if (PlayerController != None) {                                             
PlayerController.sv_FireHook(Class'Content_Type'.9,mFaction,0);           
}
return True;                                                                
}
event OnDespawn(Game_AIController GroupMember) {
local int gi;
gi = 0;                                                                     
while (gi < GroupMembers.Length) {                                          
if (GroupMembers[gi].Controller == GroupMember) {                         
mTeam.RemoveMember(GroupMembers[gi].Pawn);                              
GroupMembers.Remove(gi,1);                                              
goto jl0069;                                                            
}
gi++;                                                                     
}
}
function bool OnDeath(Game_AIController GroupMember,Actor deceasedActor) {
local int gi;
local bool found;
local bool alldead;
alldead = True;                                                             
gi = 0;                                                                     
while (gi < GroupMembers.Length) {                                          
if (GroupMembers[gi].Pawn == deceasedActor) {                             
mTeam.RemoveMember(GroupMembers[gi].Pawn);                              
GroupMembers[gi].Alive = False;                                         
found = True;                                                           
goto jl0076;                                                            
}
alldead = alldead && !GroupMembers[gi].Alive;                             
gi++;                                                                     
}
if (alldead) {                                                              
GiveKillCredit(deceasedActor.Location);                                   
}
return False;                                                               
}
function NPC_Taxonomy GetFaction() {
return mFaction;                                                            
}
event SetFaction(export editinline NPC_Taxonomy aFaction) {
mFaction = aFaction;                                                        
}
event OnCreateComponents() {
Super.OnCreateComponents();                                                 
CombatStats = new (self) Class'Meta_CombatStats';                           
}
function OnBegin(Game_AIController aSpawn) {
local int i;
local GroupMember newGroupMember;
local Game_NPCPawn npcPawn;
Super.OnBegin(aSpawn);                                                      
i = 0;                                                                      
while (i < GroupMembers.Length) {                                           
if (!GroupMembers[i].Alive) {                                             
GroupMembers.Remove(i,1);                                               
i--;                                                                    
}
i++;                                                                      
}
npcPawn = Game_NPCPawn(aSpawn.Pawn);                                        
newGroupMember.Controller = aSpawn;                                         
newGroupMember.Pawn = npcPawn;                                              
newGroupMember.Alive = True;                                                
newGroupMember.FameLevel = npcPawn.NPCFameLevel;                            
newGroupMember.PePRank = npcPawn.NPCPePRank;                                
newGroupMember.Type = npcPawn.NPCType;                                      
GroupMembers[GroupMembers.Length] = newGroupMember;                         
npcPawn.CombatStats.LinkSocialStats(CombatStats,SocialAggroFactor);         
mTeam.AddMember(npcPawn);                                                   
}
function bool OnSpawn(Game_AIController aController,export editinline NPC_Type aNPCType,Vector aLocation) {
aController.Habitat = Habitat;                                              
aController.ThreatRange = ThreatRange;                                      
aController.ChaseRange = ChaseRange;                                        
aController.SetVisualRange(VisualRange);                                    
aController.SetLineOfSightRange(LineOfSightRange);                          
aController.FearFactor = 0.30000001;                                        
aController.AggressionFactor = 0.69999999;                                  
aController.SocialFactor = 0.00000000;                                      
aController.BoredomFactor = 0.50000000;                                     
return Super.OnSpawn(aController,aNPCType,aLocation);                       
}
*/