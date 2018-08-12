using System;
using System.Collections.Generic;
using Engine;

namespace Gameplay
{
    [Serializable] public class ScriptedSequence : AIScript
    {
        public List<ScriptedAction> Actions = new List<ScriptedAction>();
        public Type ScriptedControllerClass;
    }
}