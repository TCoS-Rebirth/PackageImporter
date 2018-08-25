using System;

namespace SBGame
{
    [Serializable] public class Game_NPCCombatState : Game_CombatState
    {
        public Game_NPCCombatState()
        {
        }
    }
}
/*
native function bool EnsureIdle();
native function bool EnsureCombat(optional byte aPreferedMode);
*/