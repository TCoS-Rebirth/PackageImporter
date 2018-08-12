using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_PeriodicSkillOnCollected : AIScript_CollectEventinstigators
    {
        [FoldoutGroup("CollectEventinstigators")]
        public FSkill_Type Skill;

        [FoldoutGroup("CollectEventinstigators")]
        public bool RemoveSkillOnUntrigger;

        [FoldoutGroup("CollectEventinstigators")]
        public float MinDelay;

        [FoldoutGroup("CollectEventinstigators")]
        public float MaxDelay;

        [FoldoutGroup("CollectEventinstigators")]
        public bool ApplyImmediately;

        public float SkillTimeOut;

        public AIScript_PeriodicSkillOnCollected()
        {
        }
    }
}
/*
function RemoveInstigator(Game_Controller aInstigator) {
Super.RemoveInstigator(aInstigator);                                        
if (RemoveSkillOnUntrigger) {                                               
RemoveSkillDuffs(Game_Pawn(aInstigator.Pawn),Skill);                      
}
}
function AddInstigator(Game_Controller aInstigator) {
Super.AddInstigator(aInstigator);                                           
if (ApplyImmediately) {                                                     
ApplySkillEffects(Skill,Game_Pawn(aInstigator.Pawn),Game_Pawn(aInstigator.Pawn));
}
}
protected event sv_OnScriptFrame(float DeltaTime) {
local int i;
if (Skill == None) {                                                        
Failure("no skill selected!");                                            
}
if (Instigators.Length > 0) {                                               
SkillTimeOut -= DeltaTime;                                                
if (SkillTimeOut <= 0) {                                                  
CleanInstigators();                                                     
i = 0;                                                                  
while (i < Instigators.Length) {                                        
ApplySkillEffects(Skill,Game_Pawn(Instigators[i].Pawn),Game_Pawn(Instigators[i].Pawn));
i++;                                                                  
}
SkillTimeOut = RandomFloat(MinDelay,MaxDelay);                          
}
}
}
*/