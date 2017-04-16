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
using SBGame;


namespace SBAIScripts
{


    public class AIScript_Proto_TriggeredSkill : AI_Script
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="AIScript_Proto_TriggeredSkill")]
        public FSkill_Type Skill;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="AIScript_Proto_TriggeredSkill")]
        public Actor Target;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="AIScript_Proto_TriggeredSkill")]
        public float TickTime;
        
        public bool Triggered;
        
        public float TickTimer;
        
        public AIScript_Proto_TriggeredSkill()
        {
        }
    }
}
/*
event UnTrigger(Actor Other,Pawn EventInstigator) {
Triggered = False;                                                          
Super.UnTrigger(Other,EventInstigator);                                     
}
event Trigger(Actor Other,Pawn EventInstigator) {
Super.Trigger(Other,EventInstigator);                                       
Triggered = True;                                                           
}
function bool OnTick(Game_AIController aController,float aDeltaTime) {
local float Distance;
if (TickTimer < TickTime) {                                                 
TickTimer += aDeltaTime;                                                  
} else {                                                                    
TickTimer -= TickTime;                                                    
if (Triggered && Target != None) {                                        
Debug("skill ticking");                                                 
if (!aController.IsAIPaused()) {                                        
Debug("skill pausing");                                               
PauseAI(aController);                                                 
}
if (!HasWeaponDrawn(aController)) {                                     
Debug("skill drawing");                                               
DrawWeapon(aController);                                              
} else {                                                                
SetTarget(aController,Target);                                        
Distance = VSize(aController.Pawn.Location - Target.Location);        
if (!IsMoving(aController)) {                                         
if (Distance < Skill.MinDistance || Distance > Skill.MaxDistance) { 
MoveTo(aController,Target.Location,(Skill.MinDistance + Skill.MaxDistance) / 2);
Debug("skill approaching " @ string(Distance)
@ "between ["
@ string(Skill.MinDistance)
@ "-"
@ string(Skill.MaxDistance)
@ "]");
} else {                                                            
if (CanPerformSkill(aController,Skill)) {                         
PerformSkill(aController,Skill,Target.Location);                
Debug("skill performing");                                      
}
}
} else {                                                              
Debug("skill moving");                                              
}
}
} else {                                                                  
if (HasPausedAI(aController)) {                                         
if (HasWeaponDrawn(aController)) {                                    
sheathWeapon(aController);                                          
Debug("skill sheathing");                                           
} else {                                                              
ContinueAI(aController);                                            
Debug("skill continuing");                                          
}
}
}
}
return Super.OnTick(aController,aDeltaTime);                                
}
*/
