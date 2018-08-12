using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_DirectTeleport : FSkill_EffectClass_Direct
    {
        public const int MAX_TELEPORT_RETRIES = 4;

        [FoldoutGroup("Teleport")]
        [FieldConst()]
        public byte Mode;

        [FoldoutGroup("Teleport")]
        [FieldConst()]
        public byte Rotation;

        [FoldoutGroup("Offset")]
        [FieldConst()]
        public float Offset;

        [FieldConst()]
        public FSkill_ValueSpecifier _TeleportValue;

        public FSkill_EffectClass_DirectTeleport()
        {
        }
    }
}
/*
event cl_CombatMessage(export editinline FSkill_Type aSkill,export editinline FSkill_Event_Duff aDuffEvent,Game_Pawn aSource,Game_Pawn aTarget,int aAmount,int aAmount2,int aAmount3) {
assert(aTarget != None && aTarget.IsLocalPlayer());                         
cl_CombatLogMessage(Class'StringReferences'.default.EffectSourceText.Text,Class'StringReferences'.default.EffectTeleportText.Text,aSkill,aDuffEvent,aSource,aTarget,aAmount,aAmount2,aAmount3);
CheckAutoTarget(aSource,aTarget);                                           
}
*/