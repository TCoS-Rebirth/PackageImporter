using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class PvPSettings : UObject
    {
        [FoldoutGroup("PvPSettings")]
        public bool AllowDrawWeapon;

        [FoldoutGroup("PvPSettings")]
        public byte Type;

        [FoldoutGroup("PvPSettings")]
        public bool FriendlyFire;

        [FoldoutGroup("PvPSettings")]
        public int EnableTimeOut;

        [FoldoutGroup("PvPSettings")]
        public bool PvPServerOnly;

        public PvPSettings()
        {
        }

        public enum EPvPTypes
        {
            PVP_None,

            PVP_Off,

            PVP_Guildwars,

            PVP_HouseVSHouse,

            PVP_GuildVSGuild,

            PVP_Deprecated_DO_NOT_USE,

            PVP_FFA,
        }
    }
}