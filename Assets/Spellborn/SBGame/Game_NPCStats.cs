using System;
using Engine;

namespace SBGame
{
    [Serializable] public class Game_NPCStats : Game_CharacterStats
    {
        [FieldConst()]
        public float mAggroLostHealthRestore;
    }
}
/*
event cl_OnInit() {
Super.cl_OnInit();                                                          
Outer.PauseAnim(IsAnimationFrozen());                                       
}
*/