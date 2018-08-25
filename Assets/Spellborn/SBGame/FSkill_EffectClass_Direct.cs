using System;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_Direct : FSkill_EffectClass
    {
        public FSkill_EffectClass_Direct()
        {
        }
    }
}
/*
protected function CheckAutoTarget(Game_Pawn aSource,Game_Pawn aTarget) {
if (aSource != None && aTarget != None
&& aSource.IsLocalPlayer()
&& aSource != aTarget) {
Game_PlayerController(aSource.Controller).Input.AutoTarget(aTarget);      
}
}
*/