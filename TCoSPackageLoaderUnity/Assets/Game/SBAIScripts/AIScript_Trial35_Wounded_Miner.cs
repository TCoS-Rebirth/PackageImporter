﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Engine;
using SBAI;
using SBAIScripts;
using SBBase;
using SBGame;
using SBGamePlay;
using SBMiniGames;
using System;
using System.Collections;
using System.Collections.Generic;
using Framework.Attributes;

namespace SBAIScripts
{
    
    
    public class AIScript_Trial35_Wounded_Miner : AI_Script
    {
        
        [FieldCategory(Category="Miner")]
        public int StartHealth;
        
        [FieldCategory(Category="Miner")]
        public byte PainEmote;
        
        [FieldCategory(Category="Miner")]
        public float PainDelay;
        
        [FieldCategory(Category="Miner")]
        public float PainDelayRange;
        
        [FieldCategory(Category="Miner")]
        public string ChallengeFailTag = string.Empty;
        
        public AIScript_Trial35_Wounded_Miner()
        {
        }
    }
}
/*
event bool OnDeath(Game_AIController aController,Actor aDeceasedActor) {
local Game_PlayerController lController;
foreach AllActors(Class'Game_PlayerController',lController) {               
FireScriptHook(lController,name(ChallengeFailTag));                       
}
return Super.OnDeath(aController,aDeceasedActor);                           
}
function bool OnDamage(Game_AIController Victim,Actor aInstigator,float aDamage) {
StopTimer(Victim,'PainEmote');                                              
StartTimer(Victim,'PainEmote',PainDelay + FRand() * PainDelayRange);        
return Super.OnDamage(Victim,aInstigator,aDamage);                          
}
event bool OnTimerEnded(Game_AIController aController,Actor aInstigator,name aTag) {
PerformEmote(aController,PainEmote);                                        
StartTimer(aController,'PainEmote',PainDelay + FRand() * PainDelayRange);   
return Super.OnTimerEnded(aController,aInstigator,aTag);                    
}
function OnBegin(Game_AIController aController) {
if (StartHealth > 0) {                                                      
Game_Pawn(aController.Pawn).SetHealth(StartHealth);                       
}
SetFreeze(Game_Pawn(aController.Pawn),True,False,False,False,True);         
StartTimer(aController,'PainEmote',PainDelay + FRand() * PainDelayRange);   
Super.OnBegin(aController);                                                 
}
*/
