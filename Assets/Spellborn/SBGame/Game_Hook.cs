using System;
using Engine;

namespace SBGame
{
    [Serializable] public class Game_Hook : UObject
    {
        public byte HookType;

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