using System;
using Engine;

namespace SBBase
{
    [Serializable] public class SBFriendsMember : UObject
    {
        public string Name = string.Empty;

        public int Flag;

        public int CharacterID;

        public int Level;

        public int Class;

        public int world;

        public bool Online;

        public SBFriendsMember()
        {
        }
    }
}