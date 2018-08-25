using System;
using SBAI;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_Trial35_Wounded_Miner : AI_Script
    {
        [FoldoutGroup("Miner")]
        public int StartHealth;

        [FoldoutGroup("Miner")]
        public byte PainEmote;

        [FoldoutGroup("Miner")]
        public float PainDelay;

        [FoldoutGroup("Miner")]
        public float PainDelayRange;

        [FoldoutGroup("Miner")]
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