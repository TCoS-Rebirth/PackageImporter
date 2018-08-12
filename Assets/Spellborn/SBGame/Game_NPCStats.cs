using System;
using Engine;

namespace SBGame
{
    [Serializable] public class Game_NPCStats : Game_CharacterStats
    {
        [FieldConst()]
        public float mAggroLostHealthRestore;

        public Game_NPCStats()
        {
        }
    }
}
/*
event cl_OnInit() {
Super.cl_OnInit();                                                          
Outer.PauseAnim(IsAnimationFrozen());                                       
}
*/