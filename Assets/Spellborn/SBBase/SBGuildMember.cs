using System;
using Engine;

namespace SBBase
{
    [Serializable] public class SBGuildMember : UObject
    {
        public int CharacterID;

        public int ClassType;

        public int Level;

        public string Name = string.Empty;

        public int Location;

        public int RankLevel;

        public bool Online;

        public SBGuildMember()
        {
        }
    }
}