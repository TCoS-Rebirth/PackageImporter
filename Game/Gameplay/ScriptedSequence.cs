using System.Collections.Generic;
using Engine;
using TCosReborn.Framework.Common;

namespace Gameplay
{
    public class ScriptedSequence: AIScript
    {
        public List<ScriptedAction> Actions = new List<ScriptedAction>();
        public SerializableTypeProxy ScriptedControllerClass;
    }
}
