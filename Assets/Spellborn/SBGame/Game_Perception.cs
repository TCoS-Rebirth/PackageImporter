using System;
using Engine;

namespace SBGame
{
    [Serializable] public class Game_Perception : UObject
    {
        public bool DebugTracking;

        public Game_Perception()
        {
        }
    }
}
/*
function Notify(Game_Pawn aPawn) {
if (DebugTracking) {                                                        
}
}
function string DebugDescription() {
return "Perception" @ string(self.Class);                                   
}
*/