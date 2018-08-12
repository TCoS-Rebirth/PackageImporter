using System;

namespace SBAIScripts
{
    [Serializable] public class RegisteredChatNPC : RegisteredAI
    {
        public bool WasInVulnerable;

        public bool Initialized;

        public RegisteredChatNPC()
        {
        }
    }
}