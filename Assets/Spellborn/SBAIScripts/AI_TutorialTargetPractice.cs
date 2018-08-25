﻿using System;
using System.Collections.Generic;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AI_TutorialTargetPractice : AI_Script
    {
        [FoldoutGroup("AI_TutorialTargetPractice")]
        public List<FSkill_Type> AllowedSkills = new List<FSkill_Type>();

        [FoldoutGroup("AI_TutorialTargetPractice")]
        public string WrongSkillEvent = string.Empty;

        public AI_TutorialTargetPractice()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(WrongSkillEvent,static.RGB(100,100,255),"WrongSkillEvent:" @ WrongSkillEvent,oRelations);
}
function bool OnDebuff(Game_AIController Victim,Game_Pawn aInstigator,export editinline FSkill_EffectClass aEffect,float aValue) {
return Check(aInstigator);                                                  
}
function bool OnBuff(Game_AIController Victim,Game_Pawn aInstigator,export editinline FSkill_EffectClass aEffect,float aValue) {
return Check(aInstigator);                                                  
}
function bool OnDamage(Game_AIController aController,Actor aInstigator,float aDamage) {
return Check(Game_Pawn(aInstigator));                                       
}
function bool CheckSkill(export editinline FSkill_Type aSkill) {
local int si;
si = 0;                                                                     
while (si < AllowedSkills.Length) {                                         
if (AllowedSkills[si] != None && AllowedSkills[si] == aSkill) {           
return True;                                                            
}
si++;                                                                     
}
return False;                                                               
}
function bool Check(Game_Pawn cause) {
local export editinline FSkill_Type attackingSkill;
local float relativeTimeSpent;
if (cause != None) {                                                        
if (cause.Skills.IsAttacking(attackingSkill,relativeTimeSpent)
&& CheckSkill(attackingSkill)) {
Debug("Attacking with right skill" @ string(attackingSkill));           
TriggerEvent(Event,self,cause);                                         
return False;                                                           
}
Debug("Attacking with wrong skill" @ string(attackingSkill));             
TriggerEvent(name(WrongSkillEvent),self,cause);                           
}
return True;                                                                
}
*/