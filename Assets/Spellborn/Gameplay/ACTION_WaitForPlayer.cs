using System;

namespace Gameplay
{
    [Serializable] public class ACTION_WaitForPlayer : LatentScriptedAction
    {

        public float Distance = 150f;

        public override string ActionString
        {
            get { return "Wait for player"; }
        }

        public override bool bValidForTrigger
        {
            get { return false; }
        }
    }
}