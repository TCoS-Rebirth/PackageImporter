

using Engine;
using SBAI;
using SBAIScripts;
using SBBase;
using SBGame;
using SBGamePlay;
using SBMiniGames;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SBGamePlay
{
    
    
    [System.Serializable] public class TriggerableBarrier : Game_Actor
    {
        
        [Sirenix.OdinInspector.FoldoutGroup("TriggerableBarrier")]
        public bool bInitiallyOpen;
        
        [Sirenix.OdinInspector.FoldoutGroup("TriggerableBarrier")]
        public bool bAutoInvisibleEffect;
        
        public TriggerableBarrier()
        {
        }
    }
}
/*
function SetOpened(bool Open) {
if (IsServer()) {                                                           
sv_SetEnabled(!Open);                                                     
sv_SetCollision(!Open,!Open);                                             
}
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
SetOpened(False);                                                           
}
event Trigger(Actor Other,Pawn EventInstigator) {
SetOpened(True);                                                            
}
function PostBeginPlay() {
local export editinline FSkill_EffectClass_AudioVisual_ColorModifier TransparentEffect;
SetOpened(bInitiallyOpen);                                                  
if (bAutoInvisibleEffect) {                                                 
TransparentEffect = FSkill_EffectClass_AudioVisual_ColorModifier(static.DynamicLoadObject("EffectsMiscGP.Transparent_Effect",Class'FSkill_EffectClass_AudioVisual_ColorModifier',True));
EnabledEffects[EnabledEffects.Length] = TransparentEffect;                
DisabledEffects[DisabledEffects.Length] = TransparentEffect;              
}
Super.PostBeginPlay();                                                      
}
*/
