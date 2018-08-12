using System;
using SBAI;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_Trial50_DrainedMage : AI_Script
    {
        [FoldoutGroup("DrainedMage")]
        public float StartHealth;

        public Game_AIController Controller;

        public AIScript_Trial50_DrainedMage()
        {
        }
    }
}
/*
function bool OnDeath(Game_AIController aController,Actor aCollaborator) {
Controller = None;                                                          
return Super.OnDeath(aController,aCollaborator);                            
}
event Trigger(Actor Other,Pawn EventInstigator) {
if (Controller != None) {                                                   
PlayControllerAnimation(Controller,0,Class'SBAnimationFlags'.14,,,True);  
}
}
function OnBegin(Game_AIController aController) {
Super.OnBegin(aController);                                                 
PauseAI(aController);                                                       
Controller = aController;                                                   
if (StartHealth > 0) {                                                      
Game_Pawn(aController.Pawn).SetHealth(StartHealth);                       
}
DrawWeapon(aController,3);                                                  
SetFreeze(Game_Pawn(aController.Pawn),True,True,True,False,True);           
}
*/