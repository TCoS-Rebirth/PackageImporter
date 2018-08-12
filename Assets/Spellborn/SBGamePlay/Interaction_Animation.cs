using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGamePlay
{
    [Serializable] public class Interaction_Animation : Interaction_Component
    {
        [FoldoutGroup("Interaction_Animation")]
        [FieldConst()]
        public string animName = string.Empty;

        [FoldoutGroup("Interaction_Animation")]
        [FieldConst()]
        public float LoopDuration;

        [FoldoutGroup("Interaction_Animation")]
        [FieldConst()]
        public float speed;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float mTimer;

        public Interaction_Animation()
        {
        }
    }
}
/*
function ClOnEnd(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
Super.ClOnEnd(aOwner,aInstigator,aReverse);                                 
if (!aReverse) {                                                            
if (LoopDuration > 0.00000000) {                                          
aInstigator.ClearAnimsByType(9,0.00000000);                             
}
}
}
function ClOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
Super.ClOnStart(aOwner,aInstigator,aReverse);                               
if (aInstigator != None && animName != "") {                                
if (!aReverse) {                                                          
if (LoopDuration > 0.00000000) {                                        
aInstigator.PlayTopLevelAnim(name(animName),speed,0.20000000,True,False);
} else {                                                                
aInstigator.PlayTopLevelAnim(name(animName),speed,0.20000000,False,False);
}
}
}
}
function SvOnEnd(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local InteractiveLevelElement ile;
ile = InteractiveLevelElement(aOwner);                                      
if (ile != None) {                                                          
if (!aReverse) {                                                          
mTimer = LoopDuration;                                                  
if (LoopDuration > 0.00000000) {                                        
ile.sv_EndClientSubAction();                                          
}
}
}
Super.SvOnEnd(aOwner,aInstigator,aReverse);                                 
}
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local InteractiveLevelElement ile;
Super.SvOnStart(aOwner,aInstigator,aReverse);                               
ile = InteractiveLevelElement(aOwner);                                      
if (ile != None && animName != "") {                                        
if (!aReverse) {                                                          
ile.sv_StartClientSubAction();                                          
mTimer = 0.00000000;                                                    
}
}
}
*/