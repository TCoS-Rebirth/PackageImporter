using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_Event_Summon : FSkill_Event_FX
    {
        [FieldConst()]
        public FSkill_EffectClass_AudioVisual_Emitter SummonEmitter;

        [FoldoutGroup("Pet")]
        [FieldConst()]
        public NPC_Type NPC;

        public bool SpawnedPet;

        public FSkill_Event_Summon()
        {
        }
    }
}