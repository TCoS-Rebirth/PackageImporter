using System;
using Engine;

namespace Gameplay
{
    [Serializable] public class Action_TRIGGEREVENT : LatentScriptedAction
    {
        public NameProperty Event = "";
    }
}