using System;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_Duff : FSkill_EffectClass
    {
        [FoldoutGroup("XCombo")]
        public float ComboEffectDuration;

        public FSkill_EffectClass_Duff()
        {
        }

        [Serializable] public struct DuffRestoreData
        {
            public Game_Pawn Pawn;

            public float Value;

            public float Value2;

            public int InstallID;

            public int InstallID2;
        }
    }
}
/*
final native function Undo(export editinline FSkill_Event_Duff aEvent,const out DuffRestoreData aRestoreData);
final native function Apply(export editinline FSkill_Event_Duff aEvent,Game_Pawn aTarget,out array<DuffRestoreData> outHistory,float aAltBaseValue,export editinline FSkill_Event_FX aPerTargetFX);
*/