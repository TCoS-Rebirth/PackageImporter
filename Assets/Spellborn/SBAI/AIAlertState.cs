using System;

namespace SBAI
{
    [Serializable] public class AIAlertState : AIState
    {
        public bool mEnemy;

        public string mDebugInfo = string.Empty;

        public float mAlertDuration;

        public AIAlertState()
        {
        }
    }
}