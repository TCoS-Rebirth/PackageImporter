﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using SBAI;
using SBGame;


namespace SBAIScripts
{


    public class AIScript_CoA_1_Becks_Script : AI_Script
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="AIScript_CoA_1_Becks_Script")]
        public FSkill_Type EnragedSkill;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="AIScript_CoA_1_Becks_Script")]
        public FSkill_Type StunnedSkill;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="AIScript_CoA_1_Becks_Script")]
        public string ActivatedTag = string.Empty;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="AIScript_CoA_1_Becks_Script")]
        public string MidChatTag = string.Empty;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="AIScript_CoA_1_Becks_Script")]
        public string DeathChatTag = string.Empty;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="AIScript_CoA_1_Becks_Script")]
        public float StunTime;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="AIScript_CoA_1_Becks_Script")]
        public float EnragedTime;
        
        public Game_AIController Becks;
        
        public bool IsActive;
        
        public bool MidChatTriggered;
        
        public AIScript_CoA_1_Becks_Script()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(ActivatedTag,static.RGB(100,100,255),"ActivatedTag:" @ ActivatedTag,oRelations);
GetTaggedRelations(MidChatTag,static.RGB(100,100,255),"MidChatTag:" @ MidChatTag,oRelations);
GetTaggedRelations(DeathChatTag,static.RGB(100,100,255),"DeathChatTag:" @ DeathChatTag,oRelations);
}
event bool OnDeath(Game_AIController aController,Actor aDeceasedActor) {
Becks = None;                                                               
return Super.OnDeath(aController,aDeceasedActor);                           
}
function Activate() {
if (!IsActive) {                                                            
IsActive = True;                                                          
TriggerEvent(name(ActivatedTag),self,None);                               
}
}
function bool OnDebuff(Game_AIController Victim,Game_Pawn aInstigator,export editinline FSkill_EffectClass aEffect,float aValue) {
Activate();                                                                 
return Super.OnDebuff(Victim,aInstigator,aEffect,aValue);                   
}
function bool OnBuff(Game_AIController Victim,Game_Pawn aInstigator,export editinline FSkill_EffectClass aEffect,float aValue) {
Activate();                                                                 
return Super.OnBuff(Victim,aInstigator,aEffect,aValue);                     
}
function bool OnDamage(Game_AIController aController,Actor cause,float aDamage) {
if (!MidChatTriggered
&& GetHealth(aController) / GetMaxHealth(aController) >= 0.50000000
&& (GetHealth(aController) - aDamage) / GetMaxHealth(aController) < 0.50000000) {
MidChatTriggered = True;                                                  
TriggerEvent(name(MidChatTag),self,None);                                 
} else {                                                                    
if (GetHealth(aController) - aDamage <= 0.00000000) {                     
TriggerEvent(name(DeathChatTag),self,None);                             
}
}
Activate();                                                                 
return Super.OnDamage(aController,cause,aDamage);                           
}
event Trigger(Actor Other,Pawn EventInstigator) {
if (Becks != None && !Becks.IsDead()
&& !Becks.IsDespawned()) {       
ApplySkillEffects(StunnedSkill,Game_Pawn(Becks.Pawn),Game_Pawn(Becks.Pawn));
if (!HasPausedAI(Becks)) {                                                
PauseAI(Becks);                                                         
}
PlayControllerAnimation(Becks,0,Class'SBAnimationFlags'.33,Class'SBAnimationFlags'.38,0,True);
StartTimer(Becks,'StunEnded',StunTime);                                   
}
}
function bool OnCheckFriendly(Game_AIController aGame_AIController,Game_Pawn potentialAlly) {
if (!IsActive) {                                                            
return True;                                                              
}
return Super.OnCheckFriendly(aGame_AIController,potentialAlly);             
}
function bool OnCheckEnemy(Game_AIController aGame_AIController,Game_Pawn potentialEnemy) {
if (!IsActive) {                                                            
return False;                                                             
}
return Super.OnCheckEnemy(aGame_AIController,potentialEnemy);               
}
function bool OnTimerEnded(Game_AIController aController,Actor aInstigator,name aTag) {
if (aInstigator == self) {                                                  
switch (aTag) {                                                           
case 'StunEnded' :                                                      
if (HasPausedAI(aController)) {                                       
ContinueAI(aController);                                            
}
RemoveSkillDuffs(Game_Pawn(Becks.Pawn),StunnedSkill);                 
ApplySkillEffects(EnragedSkill,Game_Pawn(aController.Pawn),Game_Pawn(aController.Pawn));
StartTimer(aController,'EnragedEnded',EnragedTime);                   
break;                                                                
case 'EnragedEnded' :                                                   
RemoveSkillDuffs(Game_Pawn(aController.Pawn),EnragedSkill);           
break;                                                                
default:                                                                
}
}
return False;                                                               
}
function OnBegin(Game_AIController aController) {
if (Becks == None) {                                                        
Becks = aController;                                                      
goto jl0019;                                                              
}
}
*/
