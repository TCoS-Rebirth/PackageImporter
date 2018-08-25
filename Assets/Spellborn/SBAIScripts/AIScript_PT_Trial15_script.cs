﻿using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_PT_Trial15_script : AI_Script
    {
        [FoldoutGroup("Trial_Script")]
        public List<BirthSign> BirthSigns = new List<BirthSign>();

        [FoldoutGroup("Trial_Script")]
        [FieldConst()]
        public NameProperty FinalCompletionTag;

        [FoldoutGroup("Trial_Script")]
        [FieldConst()]
        public float AdvanceTimeout;

        [FoldoutGroup("Trial_Script")]
        [FieldConst()]
        public NameProperty FirstCompletionTag;

        [FoldoutGroup("Trial_Script")]
        [FieldConst()]
        public NameProperty TimerFailedEvent;

        [FoldoutGroup("Trial_Script")]
        [FieldConst()]
        public AIScript_PT_Trial15_Siltor_Script SiltorScript;

        [FoldoutGroup("Trial_Script")]
        [FieldConst()]
        public AIScript_PT_Trial15_Lezu_Script LezuScript;

        [FoldoutGroup("Trial_Script")]
        public FSkill_Type mDemonicEmbraceSkill;

        [FoldoutGroup("Trial_Script")]
        public FSkill_Type mLezuHealSkill;

        [FoldoutGroup("Trial_Script")]
        public Trigger mLezuTrigger;

        [FoldoutGroup("Trial_Script")]
        public float mQuestTime;

        public bool TryAdvance;

        public float AdvanceTimer;

        public bool HealingPossible;

        public bool SiltorHasAppeared;

        public bool IsAligningBirthsigns;

        public float QuestTimer;

        public int CurrentBirthSign;

        public AIScript_PT_Trial15_script()
        {
        }

        [Serializable] public struct BirthSign
        {
            public string ActivateEvent;

            public string ActivateSoundEvent;

            public string SpawnEvent;

            public Trigger ProximityTrigger;
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local ActorRelation newRelation;
local int i;
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(string(TimerFailedEvent),static.RGB(100,100,255),"TimerFailedEvent:" @ string(TimerFailedEvent),oRelations);
if (mLezuTrigger != None) {                                                 
newRelation.mActor = mLezuTrigger;                                        
newRelation.mDescription = "mLezuTrigger";                                
newRelation.mColour = static.RGB(100,255,100);                            
oRelations[oRelations.Length] = newRelation;                              
}
i = 0;                                                                      
while (i < BirthSigns.Length) {                                             
GetTaggedRelations(BirthSigns[i].ActivateEvent,static.RGB(100,100,255),"BirthSign" @ string(i) @ " ActivateEvent:"
@ BirthSigns[i].ActivateEvent,oRelations);
GetTaggedRelations(BirthSigns[i].ActivateSoundEvent,static.RGB(100,100,255),"BirthSign" @ string(i) @ " ActivateSoundEvent:"
@ BirthSigns[i].ActivateSoundEvent,oRelations);
GetTaggedRelations(BirthSigns[i].SpawnEvent,static.RGB(100,100,255),"BirthSign" @ string(i) @ " SpawnEvent:"
@ BirthSigns[i].SpawnEvent,oRelations);
if (BirthSigns[i].ProximityTrigger != None) {                             
newRelation.mActor = BirthSigns[i].ProximityTrigger;                    
newRelation.mDescription = "BirthSign" @ string(i) @ " ProximityTrigger";
newRelation.mColour = static.RGB(100,255,100);                          
oRelations[oRelations.Length] = newRelation;                            
}
i++;                                                                      
}
}
function Advance() {
local Game_PlayerController lController;
if (BirthSigns.Length > 0) {                                                
CurrentBirthSign = Rand(BirthSigns.Length - 1);                           
TriggerEvent(name(BirthSigns[CurrentBirthSign].ActivateEvent),self,None); 
TriggerEvent(name(BirthSigns[CurrentBirthSign].SpawnEvent),self,None);    
AllPlayerClientTrigger(None,BirthSigns[CurrentBirthSign].ActivateSoundEvent);
} else {                                                                    
foreach AllActors(Class'Game_PlayerController',lController) {             
FireScriptHook(lController,FinalCompletionTag);                         
}
IsAligningBirthsigns = False;                                             
}
}
protected event sv_OnScriptFrame(float DeltaTime) {
if (IsAligningBirthsigns) {                                                 
QuestTimer += DeltaTime;                                                  
if (QuestTimer >= mQuestTime) {                                           
IsAligningBirthsigns = False;                                           
TryAdvance = False;                                                     
TriggerEvent(TimerFailedEvent,self,None);                               
}
if (TryAdvance) {                                                         
AdvanceTimer += DeltaTime;                                              
if (AdvanceTimer >= AdvanceTimeout) {                                   
TryAdvance = False;                                                   
AdvanceTimer = 0.00000000;                                            
Advance();                                                            
}
}
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
local Game_PlayerController lController;
TryAdvance = False;                                                         
if (Other.IsA('Trigger')) {                                                 
if (Other == mLezuTrigger) {                                              
if (HealingPossible) {                                                  
ApplySkillEffectsToPlayers(mLezuHealSkill,Game_Pawn(LezuScript.mLezu.Pawn));
HealingPossible = False;                                              
}
if (BirthSigns.Length == 0) {                                           
RemoveSkillEffectsFromPlayers(mDemonicEmbraceSkill);                  
}
} else {                                                                  
if (Other == BirthSigns[CurrentBirthSign].ProximityTrigger) {           
HealingPossible = False;                                              
RemoveSkillEffectsFromPlayers(mDemonicEmbraceSkill);                  
}
}
} else {                                                                    
if (Other.IsA('AI_NPC_Chat')) {                                           
if (!SiltorHasAppeared) {                                               
SiltorHasAppeared = True;                                             
foreach AllActors(Class'Game_PlayerController',lController) {         
FireScriptHook(lController,FirstCompletionTag);                     
}
} else {                                                                
TryAdvance = True;                                                    
IsAligningBirthsigns = True;                                          
}
goto jl01A4;                                                            
}
if (Other.IsA('NPC_HumanoidPawn')) {                                      
IsAligningBirthsigns = False;                                           
} else {                                                                  
if (Other.IsA('InteractiveLevelElement')) {                             
UntriggerEvent(name(BirthSigns[CurrentBirthSign].ActivateEvent),self,None);
ApplySkillEffectsToPlayers(mDemonicEmbraceSkill,Game_Pawn(SiltorScript.mSiltor.Pawn));
HealingPossible = True;                                               
TryAdvance = True;                                                    
IsAligningBirthsigns = True;                                          
BirthSigns.Remove(CurrentBirthSign,1);                                
}
}
}
}
function PostBeginPlay() {
CurrentBirthSign = -1;                                                      
}
*/