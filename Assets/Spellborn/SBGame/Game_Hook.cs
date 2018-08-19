using System;
using Engine;

namespace SBGame
{
    [Serializable] public class Game_Hook : UObject
    {
        public Content_Type.EContentHook HookType;

        public Content_Type Owner;

        public bool Fire;

        public Game_Hook()
        {
        }
    }
}
/*
event string GetDescription() {
return "[Hook: Initiator=" @ string(Owner)
@ "Type=]"
@ string(HookType);
}
*/