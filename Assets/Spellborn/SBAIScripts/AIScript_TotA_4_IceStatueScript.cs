﻿using System;
using System.Collections.Generic;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_TotA_4_IceStatueScript : AI_Script
    {
        [FoldoutGroup("AIScript_TotA_4_IceStatueScript")]
        public FSkill_EffectClass_AudioVisual FreezeSkinEffect;

        [FoldoutGroup("AIScript_TotA_4_IceStatueScript")]
        public FSkill_Type FreezeSkill;

        [FoldoutGroup("AIScript_TotA_4_IceStatueScript")]
        public float FreezeTime;

        public List<TotA_4_Enemy> Enemies = new List<TotA_4_Enemy>();

        public AIScript_TotA_4_IceStatueScript()
        {
        }

        [Serializable] public struct TotA_4_Enemy
        {
            public Game_AIController Controller;

            public bool Frozen;
        }
    }
}
/*
function bool OnCheckFriendly(Game_AIController aController,Game_Pawn potentialAlly) {
if (IsFrozen(aController)) {                                                
return True;                                                              
} else {                                                                    
return Super.OnCheckFriendly(aController,potentialAlly);                  
}
}
function bool OnCheckEnemy(Game_AIController aController,Game_Pawn potentialEnemy) {
if (IsFrozen(aController)) {                                                
return False;                                                             
} else {                                                                    
return Super.OnCheckEnemy(aController,potentialEnemy);                    
}
}
function SetFreeze(Game_Pawn aPawn,bool aOnOff,bool Movement,bool Rotation,bool Animation,optional bool Stats) {
local int i;
Super.SetFreeze(aPawn,aOnOff,Movement,Rotation,Animation);                  
i = 0;                                                                      
while (i < Enemies.Length) {                                                
if (Enemies[i].Controller == aPawn.Controller) {                          
Enemies[i].Frozen = aOnOff;                                             
if (aOnOff) {                                                           
ApplySkillEffects(FreezeSkill,aPawn,aPawn);                           
ApplyAudioVisualEffect(aPawn,FreezeSkinEffect);                       
} else {                                                                
RemoveSkillDuffs(aPawn,FreezeSkill);                                  
RemoveAudioVisualEffects(aPawn);                                      
}
goto jl00CE;                                                            
}
i++;                                                                      
}
}
function bool OnTimerEnded(Game_AIController aController,Actor aInstigator,name aTag) {
if (aTag == 'Unfreeze') {                                                   
SetFreeze(Game_Pawn(aController.Pawn),False,True,True,True);              
ContinueAI(aController);                                                  
Game_Pawn(aController.Pawn).SetHealth(GetMaxHealth(aController));         
}
return False;                                                               
}
function bool OnDamage(Game_AIController aController,Actor cause,float aDamage) {
if (!IsFrozen(aController)
&& GetHealth(aController) - aDamage <= 0) {
SetFreeze(Game_Pawn(aController.Pawn),True,True,True,True);               
Game_Pawn(aController.Pawn).SetHealth(GetMaxHealth(aController));         
PauseAI(aController);                                                     
StartTimer(aController,'Unfreeze',FreezeTime);                            
return True;                                                              
} else {                                                                    
return Super.OnDamage(aController,cause,aDamage);                         
}
}
function bool OnDeath(Game_AIController aController,Actor aCollaborator) {
local int i;
i = 0;                                                                      
while (i < Enemies.Length) {                                                
if (Enemies[i].Controller == aController) {                               
StopTimer(aController,'Unfreeze');                                      
SetFreeze(Game_Pawn(aController.Pawn),False,True,True,True);            
Enemies.Remove(i,1);                                                    
goto jl0077;                                                            
}
i++;                                                                      
}
return Super.OnDeath(aController,aCollaborator);                            
}
function bool IsFrozen(Game_AIController aController) {
local int i;
i = 0;                                                                      
while (i < Enemies.Length) {                                                
if (aController == Enemies[i].Controller) {                               
return Enemies[i].Frozen;                                               
}
i++;                                                                      
}
return False;                                                               
}
function OnBegin(Game_AIController aController) {
Super.OnBegin(aController);                                                 
Enemies.Insert(Enemies.Length,1);                                           
Enemies[Enemies.Length - 1].Controller = aController;                       
}
*/