using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class NPC_Effects : Content_API
    {
        [FoldoutGroup("NPC_Effects")]
        public List<FSkill_EffectClass_AudioVisual> EffectList = new List<FSkill_EffectClass_AudioVisual>();

        public NPC_Effects()
        {
        }
    }
}
/*
function Apply(Game_Pawn aPawn) {
local int i;
if (IsClient()) {                                                           
if (aPawn.Effects != None) {                                              
i = 0;                                                                  
while (i < EffectList.Length) {                                         
aPawn.Effects.cl_Start(EffectList[i],Class'Game_Effects'.-1073741824,0.00000000,0.00000000,Class'FSkill_EffectClass_AudioVisual'.-1.00000000);
i++;                                                                  
}
}
}
}
*/