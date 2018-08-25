using System;

namespace Gameplay
{
    [Serializable] public class ACTION_Freeze : LatentScriptedAction
    {
        public override string ActionString
        {
            get { return "Freeze"; }
        }
    }
}