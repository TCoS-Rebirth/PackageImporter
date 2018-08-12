using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_AudioVisual_CameraShake : FSkill_EffectClass_AudioVisual_LocalView
    {
        [FoldoutGroup("CameraShake")]
        [FieldConst()]
        public Vector MinVect;

        [FoldoutGroup("CameraShake")]
        [FieldConst()]
        public Vector MaxVect;

        [FoldoutGroup("CameraShake")]
        [FieldConst()]
        public float Duration;

        [FoldoutGroup("CameraShake")]
        [FieldConst()]
        public float TransitionTime;

        public FSkill_EffectClass_AudioVisual_CameraShake()
        {
        }
    }
}
/*
event DoShake(Game_Pawn Pawn) {
local Game_PlayerController PC;
if (IsClient() && Pawn != None && Pawn.Controller != None) {                
PC = Game_PlayerController(Pawn.Controller);                              
if (PC != None) {                                                         
PC.Camera.SetCameraShake(MinVect,MaxVect,Duration,TransitionTime);      
}
}
}
*/