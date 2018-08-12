using System;
using System.Collections.Generic;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AI_ApplySkillEffectsOnKiller : AIRegistered
    {
        [FoldoutGroup("TriggerSkillEffects")]
        public List<FSkill_Type> Skills = new List<FSkill_Type>();

        [FoldoutGroup("TriggerSkillEffects")]
        public bool OnlyLast;

        public AI_ApplySkillEffectsOnKiller()
        {
        }
    }
}
/*
function bool OnDamage(Game_AIController aController,Actor cause,float aDamage) {
local int i;
if (GetHealth(aController) - aDamage < 0.00000000
&& cause.IsA('Game_PlayerPawn')
&& (GetRegisterSize() == 1 || !OnlyLast)) {
i = 0;                                                                    
while (i < Skills.Length) {                                               
if (Skills[i] != None) {                                                
ApplySkillEffects(Skills[i],Game_Pawn(cause),Game_Pawn(cause));       
}
i++;                                                                    
}
}
return Super.OnDamage(aController,cause,aDamage);                           
}
*/