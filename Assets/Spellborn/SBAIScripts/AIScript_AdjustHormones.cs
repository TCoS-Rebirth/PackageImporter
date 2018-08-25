using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_AdjustHormones : AI_Script
    {
        [FoldoutGroup("AIScript_AdjustHormones")]
        [FieldConst()]
        public List<Hormone> Hormones = new List<Hormone>();

        [FoldoutGroup("AIScript_AdjustHormones")]
        [FieldConst()]
        public bool StartActive;

        public AIScript_AdjustHormones()
        {
        }

        [Serializable] public struct Hormone
        {
            public string Tag;

            public float Bonus;
        }
    }
}
/*
state EnabledState {
event bool OnTick(Game_AIController aController,float aDeltaTime) {
local int i;
i = 0;                                                                  
while (i < Hormones.Length) {                                           
AdjustHormone(aController,name(Hormones[i].Tag),Hormones[i].Bonus * aDeltaTime);
i++;                                                                  
}
return OnTick(aController,aDeltaTime);                                  
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
GotoState('DisabledState');                                             
}
}
state DisabledState {
event Trigger(Actor Other,Pawn EventInstigator) {
GotoState('EnabledState');                                              
}
}
auto state Initialize {
function BeginState() {
if (StartActive) {                                                      
GotoState('EnabledState');                                            
} else {                                                                
GotoState('DisabledState');                                           
}
}
}
*/