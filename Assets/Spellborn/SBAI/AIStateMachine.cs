using System;

namespace SBAI
{
    [Serializable] public class AIStateMachine : AIState
    {
        public AIState mCurrentState;

        public AIState mAbortedState;

        public AIState mNextState;

        public bool mDebugging;

        public AIStateMachine()
        {
        }
    }
}
/*
native event byte StateSignal(byte signal);
*/