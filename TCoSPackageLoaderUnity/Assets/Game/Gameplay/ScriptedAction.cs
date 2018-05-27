using System;
using Engine;
using TCosReborn;

namespace Gameplay
{
    [System.Serializable] public class ScriptedAction : UObject
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
