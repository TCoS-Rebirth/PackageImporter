using System;
using Engine;
using SBAI;

namespace SBAIScripts
{
    [Serializable] public class RegisteredEscort : RegisteredAI
    {
        public AIStateMachine OriginalMachine;

        public bool Touching;

        public bool Invulnerable;

        public Vector HomeLocation;

        public RegisteredEscort()
        {
        }
    }
}