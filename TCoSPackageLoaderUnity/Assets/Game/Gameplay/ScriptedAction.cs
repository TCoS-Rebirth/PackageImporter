using System;
using TCosReborn;

namespace Gameplay
{
    [System.Serializable] public class ScriptedAction : SBPackageResource
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
