using System.Collections.Generic;
using Engine;

namespace Gameplay
{
    [System.Serializable] public class ScriptedSequence: AIScript
    {
        public List<ScriptedAction> Actions = new List<ScriptedAction>();
        public System.Type ScriptedControllerClass;
    }
}
