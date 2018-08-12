using System;

namespace Engine
{
    [Serializable] public class ActorGroup : UObject
    {
        public string Description = string.Empty;

        public bool Hidden;

        public bool SelectionLocked;

        public ActorGroup()
        {
        }
    }
}