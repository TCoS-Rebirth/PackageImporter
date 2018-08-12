using System;
using System.Collections.Generic;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AI_ApplySkillEffectsOnDamager : AI_Script
    {
        [FoldoutGroup("AI_ApplySkillEffectsOnDamager")]
        public List<FSkill_Type> Skills = new List<FSkill_Type>();

        public AI_ApplySkillEffectsOnDamager()
        {
        }
    }
}
/*
function bool OnDamage(Game_AIController aController,Actor cause,float aDamage) {
local int i;
i = 0;                                                                      
while (i < Skills.Length) {                                                 
if (Skills[i] != None) {                                                  
ApplySkillEffects(Skills[i],Game_Pawn(cause),Game_Pawn(cause));         
}
i++;                                                                      
}
return Super.OnDamage(aController,cause,aDamage);                           
}
*/