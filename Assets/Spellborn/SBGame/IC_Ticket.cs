using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class IC_Ticket : Item_Component
    {
        [FoldoutGroup("Ticket")]
        [FieldConst()]
        public byte AccessLevel;

        [FoldoutGroup("Ticket")]
        [FieldConst()]
        public bool TeleportOnUse;

        public IC_Ticket()
        {
        }

        public enum EAccessLevel
        {
            AL_ArenaPVP,

            AL_ArenaPVE,

            AL_DeadSpellTravel,
        }
    }
}