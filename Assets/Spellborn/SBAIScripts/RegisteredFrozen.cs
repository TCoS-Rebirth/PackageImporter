using System;

namespace SBAIScripts
{
    [Serializable] public class RegisteredFrozen : RegisteredAI
    {
        public bool IsFrozen;

        public bool WasInVulnerable;

        public RegisteredFrozen()
        {
        }
    }
}