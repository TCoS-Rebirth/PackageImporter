using System;
using SBAI;

namespace SBAIScripts
{
    [Serializable] public class RegisteredStateSwitch : RegisteredAI
    {
        public AIStateMachine OldStateMachine;

        public RegisteredStateSwitch()
        {
        }
    }
}