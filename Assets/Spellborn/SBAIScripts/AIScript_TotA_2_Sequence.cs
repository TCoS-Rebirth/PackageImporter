using System;
using Engine;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBAIScripts
{
    [Serializable] public class AIScript_TotA_2_Sequence : AI_Script
    {
        [FoldoutGroup("AIScript_TotA_2_Sequence")]
        public string SuccesEvent = string.Empty;

        [FoldoutGroup("AIScript_TotA_2_Sequence")]
        public string FailEvent = string.Empty;

        [FoldoutGroup("AIScript_TotA_2_Sequence")]
        public string BaseTimeoutEventString = string.Empty;

        [FoldoutGroup("AIScript_TotA_2_Sequence")]
        public float TimeoutTime;

        [FoldoutGroup("AIScript_TotA_2_Sequence")]
        public int MaxTimeout;

        [FoldoutGroup("AIScript_TotA_2_Sequence")]
        public int KillCountTarget;

        [FoldoutGroup("AIScript_TotA_2_Sequence")]
        public NPC_Type JudgeNPCType;

        [FoldoutGroup("AIScript_TotA_2_Sequence")]
        public NPC_Type EnemyNPCtype;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int TimeoutCount;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int killcount;

        public Game_AIController Judge;

        public AIScript_TotA_2_Sequence()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local int i;
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(SuccesEvent,static.RGB(100,100,255),"SuccesEvent:" @ SuccesEvent,oRelations);
GetTaggedRelations(FailEvent,static.RGB(100,100,255),"FailEvent:" @ FailEvent,oRelations);
i = 1;                                                                      
while (i < MaxTimeout) {                                                    
GetTaggedRelations(BaseTimeoutEventString $ string(i),static.RGB(100,100,255),"BaseTimeoutEvent" $ string(i) $ ":"
@ BaseTimeoutEventString
$ string(i),oRelations);
i++;                                                                      
}
}
function bool OnDeath(Game_AIController aController,Actor aCollaborator) {
if (++killcount == KillCountTarget) {                                       
StopTimer(aController,'TimeoutTimer');                                    
TimeoutCount = 0;                                                         
TriggerEvent(name(SuccesEvent),self,None);                                
}
return Super.OnDeath(aController,aCollaborator);                            
}
function bool OnTimerEnded(Game_AIController aGame_AIController,Actor aInstigator,name aTag) {
if (aInstigator == self) {                                                  
switch (aTag) {                                                           
case 'TimeoutTimer' :                                                   
TimeoutCount++;                                                       
if (!aGame_AIController.IsDead()
&& !aGame_AIController.IsDespawned()) {
UntriggerEvent(name(BaseTimeoutEventString $ string(TimeoutCount)),self,None);
}
if (TimeoutCount < MaxTimeout) {                                      
StartTimer(aGame_AIController,'TimeoutTimer',TimeoutTime);          
} else {                                                              
TriggerEvent(name(FailEvent),self,None);                            
}
break;                                                                
default:                                                                
}
}
return False;                                                               
}
function OnBegin(Game_AIController aController) {
local Game_Pawn enemyPawn;
Super.OnBegin(aController);                                                 
if (Game_NPCPawn(aController.Pawn).NPCType == EnemyNPCtype) {               
TimeoutCount = 0;                                                         
StartTimer(aController,'TimeoutTimer',TimeoutTime);                       
if (Judge != None) {                                                      
if (!HasPausedAI(Judge)) {                                              
PauseAI(Judge);                                                       
}
LookAt(Judge,aController.Pawn.Location);                                
}
} else {                                                                    
if (Game_NPCPawn(aController.Pawn).NPCType == JudgeNPCType) {             
Judge = aController;                                                    
enemyPawn = GetNPC(EnemyNPCtype);                                       
if (enemyPawn != None) {                                                
if (!HasPausedAI(aController)) {                                      
PauseAI(aController);                                               
}
LookAt(aController,enemyPawn.Location);                               
}
}
}
}
*/