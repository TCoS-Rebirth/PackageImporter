using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QR_Skill : Quest_Reward
    {
        [FoldoutGroup("reward")]
        public FSkill_Type learnedSkill;

        public QR_Skill()
        {
        }
    }
}
/*
function string GetText() {
if (learnedSkill != None) {                                                 
return learnedSkill.GetName();                                            
} else {                                                                    
return "<No skill>";                                                      
}
}
*/