using System;

namespace Gameplay
{
    [Serializable] public class ACTION_GotoAction : LatentScriptedAction
    {
        public int ActionNumber=0;
        public override string ActionString
        {
            get { return "go to action"; }
        }
    }
}