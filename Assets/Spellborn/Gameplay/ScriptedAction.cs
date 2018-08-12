using System;
using Engine;

namespace Gameplay
{
    public class ScriptedAction : UObject
    {
        //public event Action ActionCompleted; TODO ..maybe ..if even needed

        public virtual string ActionString
        {
            get { return ""; }
        }

        public virtual bool bValidForTrigger
        {
            get { return true; }
        }
    }
}
