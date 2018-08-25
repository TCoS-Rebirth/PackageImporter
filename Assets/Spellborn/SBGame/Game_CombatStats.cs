﻿using System;
using System.Collections.Generic;
using Engine;
using SBBase;

namespace SBGame
{
    [Serializable] public class Game_CombatStats : Base_Component
    {
        public Game_Pawn mScriptedClaim;
        public bool mInCombat;
        public float mCombatDuration;
        public float mIdleDuration;
        public List<ParticipantStruct> mParticipants = new List<ParticipantStruct>();
        public List<Game_Pawn> mAggroDistribution = new List<Game_Pawn>();
        public float mTotalPositiveContribution;
        public float mTotalNegativeContribution;
        public float mReceivedAggro;
        public bool mGatherStatistics;
        public int mSkillsExecuted;
        public int mSkillsHit;
        public int mSkillsMissed;
        public List<SocialStruct> mSocialStats = new List<SocialStruct>();
        [FieldConfig()]
        public float AggroDecay;
        [FieldConfig()]
        public float CreditRange;
        [FieldConfig()]
        public float CreditIdle;
        [FieldConfig()]
        public float BasePep;
        [FieldConfig()]
        public float LevelBonus;
        [FieldConfig()]
        public float MaxLevelBonus;
        [FieldConfig()]
        public float LevelPenalty;
        [FieldConfig()]
        public float MaxLevelPenalty;
        [FieldConfig()]
        public float DistributionFudge;
        public Game_Pawn mLastAttackedPawn;

        [Serializable] public struct SocialStruct
        {
            public Game_CombatStats LinkedStats;
            public float Weight;
        }

        [Serializable] public struct ParticipantStruct
        {
            public Game_Pawn Pwnie;
            public float PositiveContribution;
            public float NegativeContribution;
            public float LastContributionTime;
            public float FirstContributionTime;
            public bool ScriptedClaim;
        }

        public Game_Pawn sv_GetKiller()
        {
            throw new NotImplementedException();
        }
    }
}
/*
protected native function bool GetOuterDead();
protected event string GetOuterName() {
return "Unknown";                                                           
}
protected native function sv2cl_UpdateInCombat_CallStub();
protected event sv2cl_UpdateInCombat(bool aInCombat) {
mInCombat = aInCombat;                                                      
}
native function sv_ExitCombat();
native function sv_EnterCombat();
function LinkSocialStats(export editinline Game_CombatStats aStats,float aWeight) {
local SocialStruct newSocialLink;
newSocialLink.LinkedStats = aStats;                                         
newSocialLink.Weight = aWeight;                                             
mSocialStats[mSocialStats.Length] = newSocialLink;                          
}
function sv_FamePepDistribution(array<Game_Pawn> Enemies,float aFame,float aPep) {
local int enemyI;
local int AverageLevel;
local array<float> ContributionMultipliers;
local float TotalContribution;
local int LevelDifference;
if (aFame <= 0.00000000 && aPep <= 0.00000000) {                            
return;                                                                   
}
AverageLevel = 0;                                                           
enemyI = 0;                                                                 
while (enemyI < Enemies.Length) {                                           
AverageLevel += Enemies[enemyI].CharacterStats.GetFameLevel();            
enemyI++;                                                                 
}
AverageLevel /= Enemies.Length;                                             
TotalContribution = 0.00000000;                                             
enemyI = 0;                                                                 
while (enemyI < Enemies.Length) {                                           
LevelDifference = Enemies[enemyI].CharacterStats.GetFameLevel() - AverageLevel;
ContributionMultipliers[enemyI] = GetTeamContributionMultiplier(LevelDifference);
TotalContribution += ContributionMultipliers[enemyI];                     
enemyI++;                                                                 
}
enemyI = 0;                                                                 
while (enemyI < ContributionMultipliers.Length) {                           
ContributionMultipliers[enemyI] /= TotalContribution;                     
enemyI++;                                                                 
}
enemyI = 0;                                                                 
while (enemyI < Enemies.Length) {                                           
Game_PlayerStats(Enemies[enemyI].CharacterStats).IncreaseFamePoints(Round(ContributionMultipliers[enemyI] * aFame));
Game_PlayerStats(Enemies[enemyI].CharacterStats).IncreasePePPoints(Round(ContributionMultipliers[enemyI] * aPep));
enemyI++;                                                                 
}
}
function sv_FamePepCredit(array<Game_Pawn> Enemies,float aMultiplier,int aLevel,int aPePRank,out float oFame,out float oPep) {
local float Multiplier;
local float killFame;
killFame = Class'SBDBSync'.GetKillFame(aLevel);                             
Multiplier = GetKillMultiplier(Enemies,aLevel,aPePRank);                    
oFame = aMultiplier * Multiplier * killFame;                                
oPep = aMultiplier * Multiplier * BasePep;                                  
}
protected function float GetTeamContributionMultiplier(int aLevelDifference) {
return 1.00000000 / (1 + Exp(-DistributionFudge * aLevelDifference));       
}
protected function float GetKillMultiplier(array<Game_Pawn> Enemies,int aLevel,int aPep) {
local int enemyI;
local int GroupLevel;
local int LevelDifference;
local float ret;
GroupLevel = 0;                                                             
enemyI = 0;                                                                 
while (enemyI < Enemies.Length) {                                           
if (Enemies[enemyI].CharacterStats.GetFameLevel() > GroupLevel) {         
GroupLevel = Enemies[enemyI].CharacterStats.GetFameLevel();             
}
enemyI++;                                                                 
}
LevelDifference = aLevel - GroupLevel;                                      
ret = GetPepMultiplier(aPep);                                               
ret *= GetLevelDifferenceMultiplier(LevelDifference);                       
return ret;                                                                 
}
protected function float GetPepMultiplier(int aPep) {
switch (aPep) {                                                             
case 0 :                                                                  
return 1.00000000;                                                      
case 1 :                                                                  
return 1.20000005;                                                      
case 2 :                                                                  
return 1.50000000;                                                      
case 3 :                                                                  
return 2.00000000;                                                      
case 4 :                                                                  
return 3.00000000;                                                      
case 5 :                                                                  
return 5.00000000;                                                      
default:                                                                  
return 1.00000000;                                                      
}
}
}
final native function float GetLevelDifferenceMultiplier(int aLevelDifference);
function sv_QuestCredit(array<Game_Pawn> Enemies) {
}
event Game_Pawn sv_GetLastAttackedPawn() {
return mLastAttackedPawn;                                                   
}
function sv_SetLastAttackedPawn(Game_Pawn Pawn) {
mLastAttackedPawn = Pawn;                                                   
}
event Game_Pawn sv_GetLastAttacker() {
local int partI;
local float lastParticipation;
local int lastIndex;
lastIndex = -1;                                                             
partI = 0;                                                                  
while (partI < mParticipants.Length) {                                      
if (mParticipants[partI].NegativeContribution > 0.00000000) {             
if (mParticipants[partI].Pwnie != None) {                               
if (mParticipants[partI].LastContributionTime > lastParticipation) {  
lastIndex = partI;                                                  
lastParticipation = mParticipants[partI].LastContributionTime;      
}
}
}
partI++;                                                                  
}
if (lastIndex != -1) {                                                      
return mParticipants[lastIndex].Pwnie;                                    
} else {                                                                    
return None;                                                              
}
}
function bool sv_InCombatWith(Game_Pawn aPawn) {
local int partI;
if (mScriptedClaim != None && mScriptedClaim == aPawn) {                    
return True;                                                              
}
partI = 0;                                                                  
while (partI < mParticipants.Length) {                                      
if (mParticipants[partI].Pwnie == aPawn) {                                
return True;                                                            
}
partI++;                                                                  
}
return False;                                                               
}
final native function sv_AddParticipants(out array<Game_Pawn> oParticipants);
native function sv_ScriptedClaim(Game_Pawn aClaimer);
native function sv_CombatParticipation(Game_Pawn aParticipant,float Contribution);
event bool InCombat() {
return mInCombat;                                                           
}
*/