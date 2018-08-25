using System;

namespace Gameplay
{
    [Serializable] public class ACTION_MoveToPlayer : LatentScriptedAction
    {
        public override string ActionString
        {
            get { return "Move To player"; }
        }

        public override bool bValidForTrigger
        {
            get { return false; }
        }
    }
}