using System;
using Engine;

namespace SBGame
{
    [Serializable] public class MapNote : UObject
    {
        public const int MAX_TARGETS_SIZE = 8;

        public LocalizedString Title;

        public LocalizedString Level;

        public LocalizedString Information;

        public byte Target;

        public float X;

        public float Y;

        public int Id;

        [ArraySizeForExtraction(Size = 8)]
        public LocalizedString[] TargetTexts = new LocalizedString[0];

        public MapNote()
        {
        }

        public enum MapNoteTargetEnum
        {
            MNTE_NPC,

            MNTE_HostileNPC,

            MNTE_Structure,

            MNTE_Resource,

            MNTE_Custom1,

            MNTE_Custom2,

            MNTE_Custom3,

            MNTE_Custom4,
        }
    }
}