using System;
using TCosReborn;
using TCosReborn.Framework.Common;

namespace Gameplay
{
    public class ScriptedAction : SBPackageResource
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
