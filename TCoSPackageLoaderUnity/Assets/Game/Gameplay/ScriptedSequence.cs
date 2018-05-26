using System.Collections.Generic;
using Engine;

namespace Gameplay
{
    public class ScriptedSequence: AIScript
    {
        public List<ScriptedAction> Actions = new List<ScriptedAction>();
        public System.Type ScriptedControllerClass;
    }
}
