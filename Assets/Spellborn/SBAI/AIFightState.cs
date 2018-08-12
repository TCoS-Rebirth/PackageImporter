using System;

namespace SBAI
{
    [Serializable] public class AIFightState : AIState
    {
        public byte mTerminatingState;

        public string mDebugInfo = string.Empty;

        public string mOldDebugInfo = string.Empty;

        public string mDebugAction = string.Empty;

        public string mDebugSignal = string.Empty;

        public AIFightState()
        {
        }
    }
}