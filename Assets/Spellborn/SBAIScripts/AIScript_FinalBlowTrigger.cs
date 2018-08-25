using System;
using SBAI;

namespace SBAIScripts
{
    [Serializable] public class AIScript_FinalBlowTrigger : AI_Script
    {
        public bool PendingDeath;

        public Game_AIController Controller;

        public AIScript_FinalBlowTrigger()
        {
        }
    }
}
/*
event OnBegin(Game_AIController aController) {
PendingDeath = False;                                                       
Super.OnBegin(aController);                                                 
}
function bool OnDamage(Game_AIController Victim,Actor cause,float aDamage) {
if (GetHealth(Victim) - aDamage <= 0) {                                     
TriggerEvent(Event,self,Pawn(cause));                                     
PendingDeath = True;                                                      
Controller = Victim;                                                      
SetFreeze(Game_Pawn(Victim.Pawn),True,False,False,False,True);            
SetInvulnerable(Victim,True);                                             
return True;                                                              
}
return Super.OnDamage(Victim,cause,aDamage);                                
}
event Trigger(Actor Other,Pawn EventInstigator) {
Super.Trigger(Other,EventInstigator);                                       
if (PendingDeath) {                                                         
DealDamage(None,Game_Pawn(Controller.Pawn),GetHealth(Controller));        
}
}
*/