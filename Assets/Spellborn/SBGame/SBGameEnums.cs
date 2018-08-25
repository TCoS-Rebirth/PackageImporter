using System;
using Engine;

namespace SBGame
{
    [Serializable] public class SBGameEnums : UObject
    {
        public SBGameEnums()
        {
        }

        public enum EquipmentSlot
        {
            ES_CHEST,

            ES_LEFTGLOVE,

            ES_RIGHTGLOVE,

            ES_PANTS,

            ES_SHOES,

            ES_HELMET,

            ES_HELMETDETAIL,

            ES_RIGHTSHOULDER,

            ES_RIGHTSHOULDERDETAIL,

            ES_LEFTSHOULDER,

            ES_LEFTSHOULDERDETAIL,

            ES_RIGHTGAUNTLET,

            ES_LEFTGAUNTLET,

            ES_CHESTARMOUR,

            ES_CHESTARMOURDETAIL,

            ES_BELT,

            ES_LEFTTHIGH,

            ES_LEFTSHIN,

            ES_MELEEWEAPON,

            ES_RANGEDWEAPON,

            ES_LEFTRING,

            ES_RIGHTRING,

            ES_NECKLACE,

            ES_SHIELD,

            ES_RIGHTTHIGH,

            ES_RIGHTSHIN,

            ES_SLOTCOUNT,

            ES_NO_SLOT,
        }
    }
}