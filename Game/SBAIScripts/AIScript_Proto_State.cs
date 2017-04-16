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


    public class AIScript_Proto_State : AI_Script
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="AIScript_Proto_State")]
        public FSkill_Type Skill;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="AIScript_Proto_State")]
        public Actor Target;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public Game_AIController mController;
        
        public AIScript_Proto_State()
        {
        }
    }
}
/*
function bool OnDeath(Game_AIController aController,Actor aDead) {
if (mController != None && aDead == mController.Pawn) {                     
mController = None;                                                       
GotoState('None');                                                        
}
return Super.OnDeath(aController,aDead);                                    
}
function OnBegin(Game_AIController aController) {
mController = aController;                                                  
Debug("goto Initialized");                                                  
GotoState('Initialized');                                                   
}
state ResetState {
event bool OnWeaponSwapped(Game_AIController aController,byte aMode) {
if (aController == mController && aMode == 0) {                         
Debug("goto Initialized");                                            
GotoState('Initialized');                                             
}
return OnWeaponSwapped(aController,aMode);                              
}
function BeginState() {
Debug("Sheathing");                                                     
sheathWeapon(mController);                                              
}
}
state AttackState {
event UnTrigger(Actor Other,Pawn EventInstigator) {
GotoState('ResetState');                                                
UnTrigger(Other,EventInstigator);                                       
}
event bool OnTimerEnded(Game_AIController aController,Actor aInstigator,name aTag) {
local UObject gimmeName;
gimmeName = Skill;                                                      
Debug("Timer" @ string(aTag) @ "ended");                                
if (aInstigator == self && aController == mController
&& aTag == gimmeName.Name) {
Debug("Reskilling");                                                  
PerformSkill(mController,Skill,Target.Location);                      
return True;                                                          
} else {                                                                
return OnTimerEnded(aController,aInstigator,aTag);                    
}
}
event bool OnSkillFinished(Game_AIController aController,export editinline FSkill_Type aSkill) {
Debug("Skill done");                                                    
return OnSkillFinished(aController,aSkill);                             
}
function EndState() {
StopTimer(mController,name(Skill.GetName()));                           
}
function BeginState() {
local UObject gimmeName;
gimmeName = Skill;                                                      
Debug("Skilling for" @ string(Skill.CooldownTime));                     
PerformSkill(mController,Skill,Target.Location);                        
StartTimer(mController,gimmeName.Name,Skill.CooldownTime + 0.50000000); 
}
}
state MoveState {
event UnTrigger(Actor Other,Pawn EventInstigator) {
GotoState('ResetState');                                                
UnTrigger(Other,EventInstigator);                                       
}
event bool OnArrived(Game_AIController aController,SBPoint aControlPoint,SBPoint aDestinationPoint,Vector aLocation) {
if (aController == mController && aControlPoint == None) {              
Debug("goto AttackState");                                            
GotoState('AttackState');                                             
}
return OnArrived(aController,aControlPoint,aDestinationPoint,aLocation);
}
function BeginState() {
Debug("Moving");                                                        
MoveTo(mController,Target.Location,(Skill.MinDistance + Skill.MaxDistance) / 2);
}
}
state WeaponState {
event UnTrigger(Actor Other,Pawn EventInstigator) {
GotoState('ResetState');                                                
UnTrigger(Other,EventInstigator);                                       
}
event bool OnWeaponSwapped(Game_AIController aController,byte aMode) {
if (aController == mController && aMode != 0) {                         
Debug("goto MoveState");                                              
GotoState('MoveState');                                               
}
return OnWeaponSwapped(aController,aMode);                              
}
function BeginState() {
Debug("Drawing");                                                       
DrawWeapon(mController);                                                
}
}
state Initialized {
event Trigger(Actor Other,Pawn EventInstigator) {
Trigger(Other,EventInstigator);                                         
PauseAI(mController);                                                   
Debug("goto WeaponState");                                              
GotoState('WeaponState');                                               
}
}
*/
