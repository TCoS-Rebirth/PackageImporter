﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using SBGame;


namespace SBAIScripts
{


    public class AIScript_PeriodicSkillOnCollected : AIScript_CollectEventinstigators
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="CollectEventinstigators")]
        public FSkill_Type Skill;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="CollectEventinstigators")]
        public bool RemoveSkillOnUntrigger;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="CollectEventinstigators")]
        public float MinDelay;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="CollectEventinstigators")]
        public float MaxDelay;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="CollectEventinstigators")]
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
